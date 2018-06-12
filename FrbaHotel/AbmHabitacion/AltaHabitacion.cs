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
    public partial class AltaHabitacion : Form
    {
        public AltaHabitacion()
        {
            InitializeComponent();

            obtenerTipos();
            obtenerComodidades();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                crearHabitacion();

                comodidades.CheckedItems.Cast<Comodidad>().ToList().ForEach(c =>
                {
                    asignarComodidad(c.id);
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
            nroHabitacion.Clear();
            pisoHabitacion.Clear();
            ubicacionHotel.SelectedIndex = 0;
            tipoHabitacion.SelectedIndex = 0;
            descripcion.Clear();
            for (int i = 0; i < comodidades.Items.Count; i++) comodidades.SetItemChecked(i, false);
        }

        private void obtenerTipos()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM TIPO_HABITACION";
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

            cmd.CommandText = "SELECT * FROM COMODIDAD";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comodidades.Items.Add(new Comodidad(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void crearHabitacion()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "HABITACION_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.Int).Value = Int32.Parse(nroHabitacion.Text);
            cmd.Parameters.Add("@piso", SqlDbType.Int).Value = Int32.Parse(pisoHabitacion.Text);
            cmd.Parameters.Add("@vista", SqlDbType.Char).Value = ubicacionHotel.SelectedIndex == 0 ? 'S' : 'N';
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = ((TipoHabitacion)tipoHabitacion.SelectedItem).id;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { MessageBox.Show("La habitación ya existe.", "Crear Habitación"); }

            sqlConnection.Close();
        }

        private void asignarComodidad(int idComodidad)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "HABITACION_Asignar_Comodidad";
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
