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
    public partial class ListadoCliente : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        public int idCliente;

        public ListadoCliente()
        {
            InitializeComponent();

            obtenerTiposDocumentos();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            obtenerClientes();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            AltaCliente altaCliente = new AltaCliente();
            DialogResult dr = altaCliente.ShowDialog();

            if (dr == DialogResult.OK)
            {
                idCliente = altaCliente.idCliente;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            tipoIdentificacion.SelectedIndex = 0;
            nroIdentificacion.Clear();
            email.Clear();
        }

        private void obtenerTiposDocumentos()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tipoIdentificacion.Items.Add(new TipoDocumento(reader));
                }
            }
            tipoIdentificacion.SelectedIndex = 0;

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerClientes()
        {
            clientes.Clear();
            resultados.Rows.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].CLIENTE_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido.Text;
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = ((TipoDocumento)tipoIdentificacion.SelectedItem).id;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.Text).Value = nroIdentificacion.Text;
            cmd.Parameters.Add("@email", SqlDbType.Text).Value = email.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente(reader));
                    }
                }
                clientes.ForEach(c =>
                {
                    string[] cols = { c.numeroDocumento, c.apellido, c.nombre, "Seleccionar" };
                    resultados.Rows.Add(cols);
                });

                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Busqueda de Cliente");
            }
        }

        private void resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                idCliente = clientes[e.RowIndex].id;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
