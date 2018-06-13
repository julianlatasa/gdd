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

namespace FrbaHotel.GenerarReserva
{
    public partial class GenerarReserva : Form
    {
        private List<Consulta> consultas = new List<Consulta>();

        public GenerarReserva()
        {
            InitializeComponent();
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            obtenerHoteles();
            obtenerTiposHabitacion();
            obtenerRegimenes();

            if (Conexion.usuario != "INVITADO")
            {
                hotel.Enabled = false;
                //List<Hotel> hoteles = (List<Hotel>)hotel.Items.OfType<Hotel>().ToList(); 
                //hotel.SelectedItem = hoteles.First(h => h.id == Conexion.hotel);
                hotel.SelectedItem = hotel.Items.OfType<Hotel>().ToList().First(h => h.id == Conexion.hotel);


            }
        }

        private void reservar_Click(object sender, EventArgs e)
        {
            if (resultados.SelectedItems.Count > 0)
            {
                ListadoCliente listadoCliente = new ListadoCliente();
                DialogResult dr = listadoCliente.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    reservar2(listadoCliente.idCliente);
                    Close();
                }
            }
        }

        private void consultarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                consultarDisponibilidad2();
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

        private void reservar2(int idCliente)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "RESERVA_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = ((Hotel)hotel.SelectedItem).id;
            try
            {
                cmd.Parameters.Add("@fechaDesde", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaDesde.Text);
            }
            catch (Exception) { MessageBox.Show("Formato de fecha incorrecto", "Error"); return; }
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion.Text;
            cmd.Parameters.Add("@tipoHabitacion", SqlDbType.Int).Value = ((TipoHabitacion)tipoHabitacion.SelectedItem).id;
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = ((Regimen)tipoRegimen.SelectedItem).id;
            cmd.Parameters.Add("@precio", SqlDbType.Int).Value = consultas[resultados.SelectedItems[0].Index].precio;
            cmd.Parameters.Add("@habitaciones", SqlDbType.VarChar).Value = nroHabitaciones.Text;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            try
            {
                reader.Read();
                MessageBox.Show(String.Format("Código de reserva: {0,5}", reader.GetInt32(0).ToString()));
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Generar Reserva");
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void consultarDisponibilidad2()
        {
            consultas.Clear();
            resultados.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            cmd.CommandText = "RESERVA_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = ((Hotel)hotel.SelectedItem).id;
            try
            {
                cmd.Parameters.Add("@fechaDesde", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaDesde.Text);
            }
            catch (Exception) { MessageBox.Show("Formato de fecha incorrecto", "Error"); return; }
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion.Text;
            cmd.Parameters.Add("@tipoHabitacion", SqlDbType.Int).Value = ((TipoHabitacion)tipoHabitacion.SelectedItem).id;
            cmd.Parameters.Add("@nroPersonas", SqlDbType.VarChar).Value = nroPersonas.Text;
            cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = Conexion.usuario;
            if (tipoRegimen.SelectedIndex >= 0)
                cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = ((Regimen)tipoRegimen.SelectedItem).id;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            //TODO Ver procedimiento se queda en EXEC RESERVA_Cancelar y pierde la conexion
            try
            {
                reader = cmd.ExecuteReader();
                //reader.Read();
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
