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
    public partial class AltaCliente : Form
    {
        public int idCliente;

        public AltaCliente()
        {
            InitializeComponent();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            obtenerPaises();
            obtenerNacionalidad();
            obtenerTipoDocumento();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                crearCliente();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { nombre, apellido, tipoDocumento, documento, email, telefono, direccion, altura, pais };

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
            localidad.Clear();
            pais.SelectedIndex = 0;
            tipoDocumento.SelectedIndex = 0;
            nacionalidad.SelectedIndex = 0;
        }

        private void crearCliente()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "CLIENTE_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido.Text;
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = ((TipoDocumento)tipoDocumento.SelectedItem).id;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar).Value = documento.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = String.Format("{0}|{1}|{2}", direccion.Text, altura.Text, departamento.Text);
            cmd.Parameters.Add("@fechaNacimiento", SqlDbType.SmallDateTime).Value = fechaNacimiento.Text;
            cmd.Parameters.Add("@pais", SqlDbType.Int).Value = ((Pais)pais.SelectedItem).id;
            cmd.Parameters.Add("@nacionalidad", SqlDbType.Int).Value = ((Nacionalidad)nacionalidad.SelectedItem).id;
            cmd.Parameters.Add("@localidad", SqlDbType.VarChar).Value = localidad.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                idCliente = reader.GetInt32(0);
                reader.Close();
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

        private void obtenerNacionalidad()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM NACIONALIDAD";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pais.Items.Add(new Nacionalidad(reader));
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
                    pais.Items.Add(new Pais(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
