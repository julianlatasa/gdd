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
    public partial class FacturarEstadia : Form
    {
        int codReserva, idCliente, formaDePago;

        public FacturarEstadia(int codReserva, int idCliente, int formaDePago)
        {
            this.codReserva = codReserva;
            this.idCliente = idCliente;
            this.formaDePago = formaDePago;
            InitializeComponent();

            facturarEstadia();
        }

        private void facturarEstadia()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].FACTURACION_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = codReserva;
            cmd.Parameters.Add("@formaPago", SqlDbType.Int).Value = formaDePago;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LineaFactura lineaFactura = new LineaFactura(reader);
                        nro.Text = lineaFactura.nro.ToString();
                        codReserva2.Text = codReserva.ToString();
                        fecha.Text = lineaFactura.fecha;
                        total.Text = lineaFactura.total.ToString();
                        lineas.Items.Add(lineaFactura);
                    }
                }
                reader.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message, "Facturar Estadía");
            }

            sqlConnection.Close();
        }
    }
}
