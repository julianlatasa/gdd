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
    public partial class AltaCliente : Form
    {
        SqlConnection db;
        SqlCommand com;
        public AltaCliente()
        {
            InitializeComponent();
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
                    MessageBox.Show("Conectado","Mensaje");
                    MessageBox.Show(dt.Rows[0].Field<String>("tipo_nombre").ToString(), "Mensaje");

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
                        MessageBox.Show("No se pudo ingresar al cliente","Alta cliente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el procedimiento de alta de Clientes: "+ex.Message,"Alta cliente");
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

            String sql = "select * from cliente where clie_email = '" + email.Text + "'";
            db = new SqlConnection(Properties.Settings.Default.Conection);
            try
            {
                db.Open();
                com = new SqlCommand(sql, db);
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                SqlDataAdapter dba = new SqlDataAdapter(com);
                dba.Fill(dt);

                DataSet dbs = new DataSet();
                if (dt.Rows.Count >= 1)
                {
                    errores += "El email " + email.Text + " ya fue utilizado.\n";
                    esValido = false;
                }
                db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el procedimiento de Alta de Clientes: " + ex.Message, "Alta cliente");
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
