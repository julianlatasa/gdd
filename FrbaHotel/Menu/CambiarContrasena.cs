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

namespace FrbaHotel
{
    public partial class CambiarContrasena : Form
    {
        public CambiarContrasena()
        {
            InitializeComponent();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                cambiarContrasena();
                Close();
            }
        }

        private bool validar()
        {
            Boolean esValido = true;
            if (String.IsNullOrEmpty(contrasena.Text))
            {
                esValido = false;
                MessageBox.Show("Campo NUEVA CONTRASEÑA es obligatorio");
            }

            if (String.IsNullOrEmpty(repetirContrasena.Text))
            {
                esValido = false;
                MessageBox.Show("Campo REPETIR CONTRASEÑA es obligatorio");
            }

            if (contrasena.Text != repetirContrasena.Text)
            {
                esValido = false;
                MessageBox.Show("Ambos campos deben ser idénticos");
            }

            return esValido;
        }

        private void cambiarContrasena()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].USUARIO_Cambiar_Contrasena";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
