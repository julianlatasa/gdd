using FrbaHotel.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class ModificarHabitacion : Form
    {
        private Habitacion habitacion;
        private int[] comodidadesMarcadas;

        public ModificarHabitacion(Habitacion habitacion)
        {
            this.habitacion = habitacion;
            InitializeComponent();

            nroHabitacion.Text = habitacion.numero.ToString();
            pisoHabitacion.Text = habitacion.piso.ToString();
            ubicacionHotel.SelectedIndex = habitacion.vista == "S" ? 0 : 1;
            habilitado.Checked = habitacion.habilitado;
            descripcion.Text = habitacion.descripcion;

            comodidadesMarcadas = obtenerComodidadesMarcadas();

            obtenerTipos();
            obtenerComodidades();

            tipoHabitacion.SelectedItem = tipoHabitacion.Items.Cast<TipoHabitacion>().ToList().First(th => th.id == habitacion.tipo);
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                modificarHabitacion();

                comodidades.CheckedItems.Cast<Comodidad>().ToList().ForEach(c =>
                {
                    asignarComodidad(c.id);
                });

                comodidadesMarcadas.Where(r => !comodidades.CheckedItems.Cast<Comodidad>().Any(r2 => r2.id == r)).ToList().ForEach(r =>
                {
                    eliminarComodidad(r);
                });

                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { nroHabitacion, pisoHabitacion, ubicacionHotel, tipoHabitacion, descripcion };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (comodidades.CheckedItems.Count == 0)
            {
                errores += "Seleccione una comodidad.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            ubicacionHotel.SelectedIndex = 0;
            descripcion.Clear();
            for (int i = 0; i < comodidades.Items.Count; i++) comodidades.SetItemChecked(i, false);
            habilitado.Checked = true;
        }

        private int[] obtenerComodidadesMarcadas()
        {
            List<int> idComodidades = new List<int>();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].HABITACION_COMODIDAD WHERE habi_hotel = " + Conexion.hotel + " AND habi_numero = " + habitacion.numero;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idComodidades.Add(reader.GetInt32(reader.GetOrdinal("como_id")));
                }
            }

            reader.Close();
            sqlConnection.Close();

            return idComodidades.ToArray();
        }

        private void obtenerTipos()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tipoHabitacion.Items.Add(new TipoHabitacion(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerComodidades()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].COMODIDAD";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Comodidad comodidad = new Comodidad(reader);
                    comodidades.Items.Add(comodidad, comodidadesMarcadas.Any(f => f == comodidad.id));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void modificarHabitacion()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].HABITACION_Modificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.VarChar).Value = nroHabitacion.Text;
            cmd.Parameters.Add("@piso", SqlDbType.VarChar).Value = pisoHabitacion.Text;
            cmd.Parameters.Add("@vista", SqlDbType.Char).Value = ubicacionHotel.SelectedIndex == 0 ? 'S' : 'N';
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion.Text;
            cmd.Parameters.Add("@habilitado", SqlDbType.Char).Value = habilitado.Checked ? '1' : '0';
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void asignarComodidad(int idComodidad)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].HABITACION_Asignar_Comodidad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.Int).Value = nroHabitacion.Text;
            cmd.Parameters.Add("@idComodidad", SqlDbType.Int).Value = idComodidad;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void eliminarComodidad(int idComodidad)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].HABITACION_Eliminar_Comodidad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.Int).Value = nroHabitacion.Text;
            cmd.Parameters.Add("@idComodidad", SqlDbType.Int).Value = idComodidad;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
