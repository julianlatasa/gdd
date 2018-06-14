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
    public partial class ElegirFormaDePago : Form
    {
        int codReserva, idCliente;

        public ElegirFormaDePago(int codReserva, int idCliente)
        {
            this.codReserva = codReserva;
            this.idCliente = idCliente;
            InitializeComponent();

            obtenerFormasDePago();
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            if (formaDePago.SelectedItem != null)
            {
                FacturarEstadia facturarEstadia = new FacturarEstadia(codReserva, idCliente, ((FormaDePago) formaDePago.SelectedItem).id);
                facturarEstadia.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
                { Close(); };
                facturarEstadia.ShowDialog();
            }
        }

        private void obtenerFormasDePago()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].FORMA_PAGO";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    formaDePago.Items.Add(new FormaDePago(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
