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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ModificarReserva : Form
    {
        int idReserva;
        private List<Consulta> consultas = new List<Consulta>();

        public ModificarReserva(int idReserva)
        {
            this.idReserva = idReserva;
            InitializeComponent();
        }

        private void ModificarReserva_Load(object sender, EventArgs e)
        {
            Text = String.Format("Modificar Reserva #{0,5}", idReserva);
            obtenerHoteles();
            obtenerTiposHabitacion();
            obtenerRegimenes();
            obtenerReserva(idReserva);

            if(Conexion.usuario != "INVITADO")
            {
                hotel.Enabled = false;
                hotel.SelectedItem = hotel.Items.OfType<Hotel>().ToList().First(h => h.id == Conexion.hotel);
            }
        }

        private void reservar_Click(object sender, EventArgs e)
        {
            if(resultados.SelectedItems.Count > 0)
            {
                modificarReserva();
                Close();
            }
        }

        private void consultarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                consultarDisponibilidad2();
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            CancelarReserva cancelarReserva = new CancelarReserva();
            DialogResult dr = cancelarReserva.ShowDialog();

            if (dr == DialogResult.OK)
            {
                cancelarReserva2(cancelarReserva.motivo2);
                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { hotel, fechaDesde, duracion, tipoHabitacion, nroPersonas, nroHabitaciones };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            hotel.SelectedIndex = 0;
            fechaDesde.Clear();
            duracion.Clear();
            tipoHabitacion.SelectedIndex = 0;
            tipoRegimen.SelectedIndex = 0;
            nroPersonas.Clear();
        }

        private void obtenerRegimenes()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM REGIMEN WHERE regi_habilitado = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tipoRegimen.Items.Add(new Regimen(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerTiposHabitacion()
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

        private void obtenerHoteles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM HOTEL";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hotel.Items.Add(new Hotel(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerReserva(int idReserva)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Select rese_desde, rese_duracion, rese_tipo_habitacion, rese_regimen from RESERVA where rese_id = "+idReserva.ToString();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                fechaDesde.Text = reader.GetDateTime(reader.GetOrdinal("rese_desde")).ToString("dd/MM/yyyy");
                duracion.Text = reader.GetInt32(reader.GetOrdinal("rese_duracion")).ToString();
                tipoRegimen.SelectedItem = tipoRegimen.Items.OfType<Regimen>().ToList().Find(r =>
                    r.id == reader.GetInt32(reader.GetOrdinal("rese_regimen")));
                tipoHabitacion.SelectedItem = tipoHabitacion.Items.OfType<TipoHabitacion>().ToList().Find(h =>
                    h.id == reader.GetInt32(reader.GetOrdinal("rese_tipo_habitacion")));

            }

        }

        private void cancelarReserva2(string motivo)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "RESERVA_Cancelar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = idReserva;
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = Conexion.usuario;
            cmd.Parameters.Add("@motivo", SqlDbType.VarChar).Value = motivo;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Cancelar Reserva");
            }

            sqlConnection.Close();
        }

        private void modificarReserva()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "RESERVA_Modificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = idReserva;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = ((Hotel) hotel.SelectedItem).id;
            cmd.Parameters.Add("@fechaDesde", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaDesde.Text);
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion.Text;
            cmd.Parameters.Add("@tipoHabitacion", SqlDbType.Int).Value = ((TipoHabitacion) tipoHabitacion.SelectedItem).id;
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = ((Regimen) tipoRegimen.SelectedItem).id;
            cmd.Parameters.Add("@precio", SqlDbType.Int).Value = consultas[resultados.SelectedItems[0].Index].precio;
            cmd.Parameters.Add("@habitaciones", SqlDbType.VarChar).Value = nroHabitaciones.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Modificar Reserva");
            }

            sqlConnection.Close();
        }

        private void consultarDisponibilidad2()
        {
            consultas.Clear();
            resultados.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "RESERVA_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = ((Hotel) hotel.SelectedItem).id;
            cmd.Parameters.Add("@fechaDesde", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaDesde.Text);
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion.Text;
            cmd.Parameters.Add("@tipoHabitacion", SqlDbType.Int).Value = ((TipoHabitacion) tipoHabitacion.SelectedItem).id;
            if(tipoRegimen.SelectedIndex >= 0)
                cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = ((Regimen) tipoRegimen.SelectedItem).id;
            cmd.Parameters.Add("@nroPersonas", SqlDbType.VarChar).Value = nroPersonas.Text;
            cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            try
            {
                reader.Read();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        consultas.Add(new Consulta(reader));
                    }
                }
                consultas.ForEach(c =>
                {
                    string[] cols = { c.precio.ToString(), 
                                    c.habitaciones.ToString() };
                    resultados.Items.Add(c.descripcionRegimen).SubItems.AddRange(cols);
                });
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Generar Reserva");
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
