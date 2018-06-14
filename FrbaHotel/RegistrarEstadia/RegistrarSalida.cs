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
        int idClienteReserva, idCliente;

        public RegistrarSalida()
        {
            InitializeComponent();
        }

        private void checkOut_Click(object sender, EventArgs e)
        {
            if (checkOut2())
            {
                if (idCliente == idClienteReserva)
                {
                    generarFacturacion();
                    Close();
                }
            }
        }

        private void generarFacturacion()
        {
            ElegirFormaDePago elegirFormaDePago = new ElegirFormaDePago(Int32.Parse(codReserva.Text), idClienteReserva);
            elegirFormaDePago.ShowDialog();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            codReserva.Clear();
            nroHabitacion.Clear();
        }

        private bool checkOut2()
        {
            bool resultado = false;
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ESTADIA_Checkout";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Parameters.Add("@nroHabitacion", SqlDbType.Int).Value = Int32.Parse(nroHabitacion.Text);
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = Int32.Parse(codReserva.Text);
            cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();

                idClienteReserva = reader.GetInt32(0);
                idCliente = reader.GetInt32(1);
                resultado = true;
                MessageBox.Show("Salida registrada con éxito.", "Registrar Salida");
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
