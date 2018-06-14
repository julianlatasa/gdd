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

            obtenerHoteles();
            obtenerTiposHabitacion();
            obtenerRegimenes();

            if (Conexion.usuario != "INVITADO")
            {
                hotel.Enabled = false;
                hotel.SelectedItem = hotel.Items.OfType<Hotel>().ToList().First(h => h.id == Conexion.hotel);
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
            Control[] controles = { hotel, duracion, tipoHabitacion, nroPersonas, nroHabitaciones };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            MaskedTextBox[] controles2 = { fechaDesde };
            foreach (MaskedTextBox control in controles2.Where(e => !e.MaskCompleted))
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
            nroHabitaciones.Clear();
        }

        private void obtenerRegimenes()
        {
            tipoRegimen.Items.Add(new Regimen());
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].REGIMEN WHERE regi_habilitado = 1";
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
            tipoHabitacion.SelectedIndex = 0;

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerHoteles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].HOTEL";
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

        private void reservar2(int idCliente, int index)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].RESERVA_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = ((Hotel)hotel.SelectedItem).id;
            try
            {
                cmd.Parameters.Add("@fechaDesde", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaDesde.Text);
            }
            catch (Exception) { MessageBox.Show("Formato de fecha incorrecto", "Error"); return; }
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion.Text;
            cmd.Parameters.Add("@tipoHabitacion", SqlDbType.Int).Value = ((TipoHabitacion)tipoHabitacion.SelectedItem).id;
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = tipoRegimen.SelectedItem != null ? ((Regimen)tipoRegimen.SelectedItem).id : consultas[index].idRegimen;
            cmd.Parameters.Add("@precio", SqlDbType.Float).Value = consultas[index].precio;
            cmd.Parameters.Add("@habitaciones", SqlDbType.VarChar).Value = nroHabitaciones.Text;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
            cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = Conexion.usuario;
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
            resultados.Rows.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].RESERVA_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = ((Hotel)hotel.SelectedItem).id;
            try
            {
                cmd.Parameters.Add("@fechaDesde", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaDesde.Text);
            }
            catch (Exception) { MessageBox.Show("Formato de fecha incorrecto", "Error"); return; }
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion.Text;
            cmd.Parameters.Add("@tipoHabitacion", SqlDbType.Int).Value = ((TipoHabitacion)tipoHabitacion.SelectedItem).id;
            cmd.Parameters.Add("@nroPersonas", SqlDbType.Int).Value = Int32.Parse(nroPersonas.Text);
            cmd.Parameters.Add("@nrohabitaciones", SqlDbType.Int).Value = Int32.Parse(nroHabitaciones.Text);
            cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = Conexion.usuario;
            if (tipoRegimen.SelectedIndex > 0)
                cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = ((Regimen)tipoRegimen.SelectedItem).id;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        consultas.Add(new Consulta(reader));
                    }
                }
                consultas.ForEach(c =>
                {
                    string[] cols = { c.descripcionRegimen, c.precio.ToString(), "Seleccionar" };
                    resultados.Rows.Add(cols);
                });

                reader.Close();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Generar Reserva");
            }

            sqlConnection.Close();
        }

        private void resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (validar())
                {
                    ListadoCliente listadoCliente = new ListadoCliente();
                    DialogResult dr = listadoCliente.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        reservar2(listadoCliente.idCliente, e.RowIndex);
                        Close();
                    }
                }
            }
        }
    }
}
