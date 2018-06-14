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
    public partial class RegistrarSalida : Form
    {
        int idClienteReserva;

        public RegistrarSalida()
        {
            InitializeComponent();
        }

        private void checkOut_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            
            ListadoCliente listadoCliente = new ListadoCliente();

            //listadoCliente.clie

            DialogResult dr = listadoCliente.ShowDialog();

            if (dr == DialogResult.OK)
            {
                if (checkOut2(listadoCliente.idCliente))
                {
                    if (listadoCliente.idCliente == idClienteReserva)
                    {
                        generarFacturacion();
                        Close();
                    }
                }
            }
        }

        private void generarFacturacion()
        {
            ElegirFormaDePago elegirFormaDePago = new ElegirFormaDePago(Int32.Parse(codReserva.Text), idClienteReserva);
            elegirFormaDePago.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
            { Close(); };
            elegirFormaDePago.Show();
            Hide();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            codReserva.Clear();
            nroHabitacion.Clear();
        }

        private bool checkOut2(int idCliente)
        {
            bool resultado = false;
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "ESTADIA_Checkout";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.Int).Value = Int32.Parse(nroHabitacion.Text);
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = Int32.Parse(codReserva.Text);
            cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();

                idClienteReserva = reader.GetInt32(0);
                resultado = true;
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Registrar Salida");
            }

            sqlConnection.Close();
            return resultado;
        }
    }
}
