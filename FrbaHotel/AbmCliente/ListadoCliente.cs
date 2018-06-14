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

namespace FrbaHotel.AbmCliente
{
    public partial class ListadoCliente : Form
    {
        List<Cliente> clientes = new List<Cliente>();

        public ListadoCliente()
        {
            InitializeComponent();

            obtenerTiposDocumentos();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            obtenerClientes();
        }

        private void resultados_MouseClick(object sender, MouseEventArgs e)
        {
            (new ModificarCliente(clientes[resultados.SelectedItems[0].Index])).ShowDialog();
            obtenerClientes();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            (new AltaCliente()).ShowDialog();
            obtenerClientes();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            nroIdentificacion.Clear();
            tipoIdentificacion.SelectedIndex = 0;
            email.Clear();
        }

        private void obtenerTiposDocumentos()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM TIPO_DOCUMENTO";
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
            resultados.Items.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "CLIENTE_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido.Text;
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = ((TipoDocumento)tipoIdentificacion.SelectedItem).id;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar).Value = nroIdentificacion.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Connection = sqlConnection;


            sqlConnection.Open();

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
                string[] cols = { c.apellido, c.nombre };
                resultados.Items.Add(c.numeroDocumento).SubItems.AddRange(cols);
            });
            reader.Close();
            sqlConnection.Close();
        }
    }
}
