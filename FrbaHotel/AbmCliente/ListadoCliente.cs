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
            string sql = "select * from CLIENTE WHERE clie_tipo_doc = "+tipoIdentificacion+
                " AND clie_numero_doc = "+nroIdentificacion+ " AND clie_nombre like '%" + nombre + 
                "%' AND clie_apellido like '%" + apellido + "%' AND clie_email = '"+email+"'";
            com = new SqlCommand(sql, db);

            //com = new SqlCommand("CLIENTE_Buscar '','',1,'',''", db);

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
            

            try
            {
                /*sql = "Select pais_id from pais where pais_nombre like '%" + paisDeOrigen.Text + "%'";

                com = new SqlCommand(sql, db);
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                SqlDataAdapter dba = new SqlDataAdapter(com);
                dba.Fill(dt);

                DataSet dbs = new DataSet();
                DataRow row;
                if (dt.Rows.Count >= 1)
                {
                    row = dt.Rows[0];
                    id_pais = row.Field<int>("pais_id");
                }
                else
                    id_pais = 0;


                dt.Clear();
                sql = "Select naci_id from NACIONALIDAD";


                com = new SqlCommand(sql, db);
                dba = new SqlDataAdapter(com);
                dba.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    id_nac = dt.Rows[0].Field<int>("naci_id");
                }
                else
                    id_nac = 0;

                String domicilio = direccion.Text + ' ' + altura.Text + ' ' + departamento.Text;

                com = new SqlCommand("CLIENTE_CREAR", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@tipo_doc", tipoDocumento.SelectedValue);
                com.Parameters.AddWithValue("@numero_doc", documento.Text);
                com.Parameters.AddWithValue("@nombre", nombre.Text);
                com.Parameters.AddWithValue("@apellido", apellido.Text);
                com.Parameters.AddWithValue("@email", email.Text);
                com.Parameters.AddWithValue("@telefono", telefono.Text);
                com.Parameters.AddWithValue("@domicilio", domicilio);
                com.Parameters.AddWithValue("@fecha_nac", DateTime.Parse(fechaNacimiento.Text));
                com.Parameters.AddWithValue("@pais", id_pais);
                com.Parameters.AddWithValue("@nacionalidad", id_nac);

                if (com.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cliente ingresado con exito", "Alta cliente");

                }
                else
                {
                    MessageBox.Show("No se pudo ingresar al cliente", "Alta cliente");
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el procedimiento de alta de Clientes: " + ex.Message, "Alta cliente");
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

        }


        private void modificar_Click(object sender, EventArgs e)
        {
            //DataRowView selectedRow = result_busq.CurrentRow.Cells["id"];
            MessageBox.Show(result_busq.CurrentRow.Cells["clie_id"].Value.ToString());
            modificacionCliente modCli = new modificacionCliente(result_busq.CurrentRow);
            modCli.Show();
            
        }
    }
}
