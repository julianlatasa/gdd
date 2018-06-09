using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.AbmCliente
{
    public partial class ListadoCliente : Form
    {
        SqlConnection db;
        SqlCommand com;
        public ListadoCliente()
        {
            InitializeComponent();
        }

        private void ListadoCliente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2018DataSet.CLIENTE' table. You can move, or remove it, as needed.
            this.cLIENTETableAdapter.Fill(this.gD1C2018DataSet.CLIENTE);



            db = new SqlConnection(Properties.Settings.Default.Conection);
            string sql = "select tipo_id, tipo_nombre from TIPO_DOCUMENTO";
            com = new SqlCommand(sql, db);
            DataTable dt = new DataTable();
            SqlDataAdapter dba = new SqlDataAdapter(com);

            try
            {

                
                DataSet dbs = new DataSet(db.ConnectionString);

                dba.Fill(dt);
                tipoIdentificacion.DisplayMember = "tipo_nombre";
                tipoIdentificacion.ValueMember = "tipo_id";
                tipoIdentificacion.DataSource = dt;
                MessageBox.Show("Conectado", "Mensaje");
                
            }
            catch (Exception)
            {
                MessageBox.Show("No conectado", "error");
            }

            //db.Close();
            
            sql = "select * from CLIENTE";
            com = new SqlCommand(sql, db);
            dba = new SqlDataAdapter(com);

            DataTable dtCli = new DataTable();
            //dba.Fill(dt);
            dba.Fill(dtCli);
            
            result_busq.DataSource = dtCli;
            
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            db = new SqlConnection(Properties.Settings.Default.Conection);
            /*string sql = "select * from CLIENTE WHERE clie_tipo_doc = "+tipoIdentificacion+
                " AND clie_numero_doc = "+nroIdentificacion+ " AND clie_nombre like '%" + nombre + 
                "%' AND clie_apellido like '%" + apellido + "%' AND clie_email = '"+email+"'";
            */
            //com = new SqlCommand(sql, db);
            
            try
            {

            com = new SqlCommand("CLIENTE_Buscar", db);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@nombre", nombre.Text);
            com.Parameters.AddWithValue("@apellido", apellido.Text);
            com.Parameters.AddWithValue("@tipoDocumento", tipoIdentificacion.SelectedValue);
            com.Parameters.AddWithValue("@nroDocumento", nroIdentificacion.Text);
            com.Parameters.AddWithValue("@email", email.Text);
            //db.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter dba = new SqlDataAdapter(com);
            dba.Fill(dt);
            result_busq.DataSource = dt;
            

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el procedimiento de Busqueda de Clientes: " + ex.Message, "Lista clientes");
            }

        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Eliminar fila?", "Eliminar", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {

            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            nroIdentificacion.Clear();
            email.Clear();
        }

        private void resultados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void result_busq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modificacionCliente modCli = new modificacionCliente(result_busq.CurrentRow, this);
            modCli.Show();
        }


        private void modificar_Click(object sender, EventArgs e)
        {
            //DataRowView selectedRow = result_busq.CurrentRow.Cells["id"];
            modificacionCliente modCli = new modificacionCliente(result_busq.CurrentRow, this);
            modCli.Show();

            this.Hide();
            
        }

        private void Eliminar_Click_1(object sender, EventArgs e)
        {

            MessageBoxButtons msg_eliminar = MessageBoxButtons.YesNo;
            if (MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar cliente", msg_eliminar) == DialogResult.Yes)
            {
                try
                {
                    db = new SqlConnection(Properties.Settings.Default.Conection);
                    db.Open();
                    DataGridViewRow row = result_busq.CurrentRow;
                    com = new SqlCommand("CLIENTE_Eliminar", db);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@clie_id", row.Cells["clie_id"].Value.ToString());
                    com.Parameters.AddWithValue("@tipoDocumento", row.Cells["clie_tipo_doc"].Value.ToString());
                    com.Parameters.AddWithValue("@nroDocumento", row.Cells["clie_numero_doc"].Value.ToString());

                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cliente Eliminado con exito", "Eliminar cliente");

                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar al cliente", "Eliminar cliente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Al eliminar Cliente: " + ex.Message, "Eliminar cliente");
                }

                result_busq.Refresh();
            }
        }
    }
}
