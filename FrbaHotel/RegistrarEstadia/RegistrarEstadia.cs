using FrbaHotel.GenerarReserva;
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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class RegistrarEstadia : Form
    {
        List<Habitacion> habitaciones = new List<Habitacion>();

        public RegistrarEstadia()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            obtenerHabitaciones();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            codReserva.Clear();
        }

        private bool crearEstadia(int idCliente, int index)
        {
            bool resultado = false;
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ESTADIA_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.Int).Value = habitaciones[index].numero;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = Int32.Parse(codReserva.Text);
            cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                resultado = true;
                MessageBox.Show("Estadía registrada con éxito", "Registrar Estadía");
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Registrar Estadía");
            }

            sqlConnection.Close();
            return resultado;
        }

        private void obtenerHabitaciones()
        {
            habitaciones.Clear();
            resultados.Rows.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ESTADIA_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = Int32.Parse(codReserva.Text);
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Habitacion habitacion = new Habitacion(reader);
                    habitaciones.Add(habitacion);
                    string[] cols = { habitacion.numero.ToString(), habitacion.piso.ToString(), "Seleccionar" };
                    resultados.Rows.Add(cols);
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ListadoCliente listadoCliente = new ListadoCliente();
                DialogResult dr = listadoCliente.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (crearEstadia(listadoCliente.idCliente, e.RowIndex))
                        Close();
                }
            }
        }       
    }
}
