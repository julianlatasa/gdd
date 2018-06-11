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

namespace FrbaHotel.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (iniciarSesion())
                    irASeleccionarHotelActivo();
            }
        }

        private bool validar()
        {
            Boolean esValido = true;
            if (String.IsNullOrEmpty(usuario.Text))
            {
                esValido = false;
                MessageBox.Show("Campo USUARIO es obligatorio");
            }

            if (String.IsNullOrEmpty(contrasena.Text))
            {
                esValido = false;
                MessageBox.Show("Campo CONTRASEÑA es obligatorio");
            }

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            usuario.Clear();
            contrasena.Clear();
        }

        private bool iniciarSesion()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "USUARIO_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.Text;
            cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                Conexion.usuario = reader.GetString(0);
                reader.Close();
                sqlConnection.Close();

                return true;
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
                contrasena.Clear();
                sqlConnection.Close();
            }

            return false;
        }

        private void irASeleccionarHotelActivo()
        {
            SeleccionarHotel seleccionarHotel = new SeleccionarHotel();
            this.Hide();
            seleccionarHotel.ShowDialog();
            //SeleccionarRol seleccionarRol = new SeleccionarRol();
            //seleccionarRol.ShowDialog();
            //(new Menu()).Show();
            Close();
        }
    }
}
