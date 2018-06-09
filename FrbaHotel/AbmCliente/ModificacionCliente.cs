using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class modificacionCliente : Form
    {
        SqlConnection db;
        SqlCommand com;
        public modificacionCliente(DataGridViewRow row)
        {
            InitializeComponent();

            db = new SqlConnection(Properties.Settings.Default.Conection);
            String sql = "Select pais_nombre from pais where pais_id = " + row.Cells["clie_pais"].Value.ToString();

            com = new SqlCommand(sql, db);
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            SqlDataAdapter dba = new SqlDataAdapter(com);
            dba.Fill(dt);

            DataSet dbs = new DataSet();
            DataRow rowPais;
            DataRow rowNac;
            rowPais = dt.Rows[0];
                   
            String pais = rowPais.Field<String>("pais_nombre");
            sql = "Select naci_descripcion from nacionalidad where naci_id = " + row.Cells["clie_nacionalidad"].Value.ToString();

            com = new SqlCommand(sql, db);
            dt = new DataTable();
            dc = new DataColumn();
            dba = new SqlDataAdapter(com);
            dba.Fill(dt);

            dbs = new DataSet();
            rowNac = dt.Rows[0];

            String nac = rowNac.Field<String>("naci_descripcion");

            sql = "Select pers_telefono from persona where pers_tipo_doc = " + row.Cells["clie_tipo_doc"].Value.ToString() +
                "and pers_numero_doc = " + row.Cells["clie_numero_doc"].Value.ToString();

            com = new SqlCommand(sql, db);
            dt = new DataTable();
            dc = new DataColumn();
            dba = new SqlDataAdapter(com);
            dba.Fill(dt);

            dbs = new DataSet();

            String tel = dt.Rows[0].Field<String>("pers_telefono");

            DateTime fechaNac = Convert.ToDateTime(row.Cells["clie_fecha_nac"].Value.ToString());

            this.nombre.Text = row.Cells["clie_nombre"].Value.ToString();
            this.apellido.Text = row.Cells["clie_apellido"].Value.ToString();
            this.documento.Text = row.Cells["clie_numero_doc"].Value.ToString();
            this.email.Text = row.Cells["clie_email"].Value.ToString();
            this.direccion.Text = row.Cells["clie_domicilio"].Value.ToString();
            this.telefono.Text = tel;
            this.fechaNacimiento.Text = fechaNac.ToString("dd/MM/yyyy");
            this.nacionalidad.Text = nac;
            this.paisDeOrigen.Text = pais;
            this.localidad.Text = row.Cells["clie_pais"].Value.ToString();

            this.nombre.Text = row.Cells["clie_nombre"].Value.ToString();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            
                db = new SqlConnection(Properties.Settings.Default.Conection);
                string sql = "select tipo_id, tipo_nombre from TIPO_DOCUMENTO";
                com = new SqlCommand(sql, db);
                DataTable dt = new DataTable();
            

                try
                {
                   
                    SqlDataAdapter dba = new SqlDataAdapter(com);
                    
                    DataSet dbs = new DataSet(db.ConnectionString);
                    
                    dba.Fill(dt);                    
                    tipoDocumento.DisplayMember = "tipo_nombre";
                    tipoDocumento.ValueMember = "tipo_id";
                    tipoDocumento.DataSource = dt;

                }
                    catch (Exception )
                {
                    MessageBox.Show("No conectado","error");
                }
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            int id_pais, id_nac;
            String sql;
            if (validar())
            {
                db = new SqlConnection(Properties.Settings.Default.Conection);
                try
                {
                    db.Open();
                    sql = "Select pais_id from pais where pais_nombre like '%" + paisDeOrigen.Text + "%'";
                 
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

                    com = new SqlCommand("CLIENTE_Modificar", db);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@idCliente", tipoDocumento.SelectedValue);
                    com.Parameters.AddWithValue("@tipoDocumento", tipoDocumento.SelectedValue);
                    com.Parameters.AddWithValue("@nroDocumento", documento.Text);
                    com.Parameters.AddWithValue("@nombre", nombre.Text);
                    com.Parameters.AddWithValue("@apellido", apellido.Text);
                    com.Parameters.AddWithValue("@email", email.Text);
                    com.Parameters.AddWithValue("@telefono", telefono.Text);
                    com.Parameters.AddWithValue("@domicilio", domicilio);
                    com.Parameters.AddWithValue("@fechaNacimiento", DateTime.Parse(fechaNacimiento.Text));
                    com.Parameters.AddWithValue("@pais", id_pais);
                    com.Parameters.AddWithValue("@nacionalidad", id_nac);
                    com.Parameters.AddWithValue("@habilitado", habilitado.Checked?'1':'0');


                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cliente Modificado con exito", "Modificacion cliente");

                    }
                    else
                    {
                        MessageBox.Show("No se pudo Modificar al cliente","Modificacion cliente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el procedimiento de alta de Clientes: "+ex.Message,"Modificacion cliente");
                }
            }
        }

        private Boolean validar()
        {
            Control[] controles = { nombre, apellido, tipoDocumento, documento, email, telefono, direccion, altura, fechaNacimiento, localidad, paisDeOrigen, nacionalidad };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            documento.Clear();
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            altura.Clear();
            departamento.Clear();
            fechaNacimiento.Clear();
            localidad.Clear();
            paisDeOrigen.Clear();
            nacionalidad.Clear();
            habilitado.Checked = true;
        }

    }
}
