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

        private void resultados_MouseClick(object sender, MouseEventArgs e)
        {
            if (resultados.SelectedItems.Count > 0)
            {
                ListadoCliente listadoCliente = new ListadoCliente();
                listadoCliente.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
                { Show(); };
                DialogResult dr = listadoCliente.ShowDialog();
                Hide();

                if (dr == DialogResult.OK)
                {
                    if(crearEstadia(listadoCliente.idCliente))
                        Close();
                }
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            codReserva.Clear();
        }

        private bool crearEstadia(int idCliente)
        {
            bool resultado = false;
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ESTADIA_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.Int).Value = habitaciones[resultados.SelectedItems[0].Index].numero;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = Int32.Parse(codReserva.Text);
            cmd.Parameters.Add("@idUsuario", SqlDbType.Char).Value = Conexion.usuario;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                resultado = true;
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
            resultados.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "ESTADIA_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = codReserva.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    habitaciones.Add(new Habitacion(reader));
                }
            }
            habitaciones.ForEach(h =>
            {
                resultados.Items.Add(h.numero.ToString()).SubItems.Add(h.piso.ToString());
            });

            reader.Close();
            sqlConnection.Close();
        }
    }
}
