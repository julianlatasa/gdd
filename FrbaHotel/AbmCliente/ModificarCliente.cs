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
    public partial class ModificarCliente : Form
    {
        Cliente cliente;

        public ModificarCliente(Cliente cliente)
        {
            this.cliente = cliente;
            InitializeComponent();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            obtenerPaises();
            obtenerTipoDocumento();

            nombre.Text = cliente.nombre;
            apellido.Text = cliente.apellido;
            tipoDocumento.SelectedItem = tipoDocumento.Items.Cast<TipoDocumento>().ToList().First(tp => tp.id == cliente.tipoDocumento);
            documento.Text = cliente.numeroDocumento;
            email.Text = cliente.email;
            telefono.Text = cliente.telefono;
            direccion.Text = cliente.domicilio.Split('|')[0];
            altura.Text = cliente.domicilio.Split('|')[1];
            departamento.Text = cliente.domicilio.Split('|')[2];
            localidad.Text = cliente.localidad;
            pais.SelectedItem = pais.Items.Cast<Pais>().ToList().First(tp => tp.id == cliente.pais);
            nacionalidad.SelectedItem = nacionalidad.Items.Cast<Pais>().ToList().First(tp => tp.id == cliente.nacionalidad);
            fechaNacimiento.Text = cliente.fechaNacimiento;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                modificarCliente();
                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { nombre, apellido, tipoDocumento, documento, email, direccion, altura, pais };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            MaskedTextBox[] controles2 = { telefono, fechaNacimiento };
            foreach (MaskedTextBox control in controles2.Where(e => !e.MaskCompleted))
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
            localidad.Clear();
            pais.SelectedIndex = 0;
            tipoDocumento.SelectedIndex = 0;
            nacionalidad.SelectedIndex = 0;
        }

        private void modificarCliente()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "CLIENTE_Modificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = cliente.id;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido.Text;
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = ((TipoDocumento)tipoDocumento.SelectedItem).id;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar).Value = documento.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = String.Format("{0}|{1}|{2}", direccion.Text, altura.Text, departamento.Text);
            try
            {
                cmd.Parameters.Add("@fechaNacimiento", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaNacimiento.Text);
            }
            catch (Exception) { MessageBox.Show("Formato de fecha incorrecto", "Error"); return; }
            cmd.Parameters.Add("@pais", SqlDbType.Int).Value = ((Pais)pais.SelectedItem).id;
            cmd.Parameters.Add("@nacionalidad", SqlDbType.Int).Value = ((Pais)nacionalidad.SelectedItem).id;
            cmd.Parameters.Add("@localidad", SqlDbType.VarChar).Value = localidad.Text;
            cmd.Parameters.Add("@habilitado", SqlDbType.Char).Value = habilitado.Checked ? '1' : '0';
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }

            sqlConnection.Close();
        }

        private void obtenerTipoDocumento()
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
                    tipoDocumento.Items.Add(new TipoDocumento(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerPaises()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM PAIS";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nacionalidad.Items.Add(new Pais(reader));
                    pais.Items.Add(new Pais(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
