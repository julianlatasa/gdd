using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            if (validar())
            {

            }
        }

        private Boolean validar()
        {
            Boolean esValido = true;
            if (String.IsNullOrEmpty(usuario.Text))
                esValido = false;
            else
                MessageBox.Show("Campo USUARIO es obligatorio");

            if (String.IsNullOrEmpty(contrasena.Text))
                esValido = false;
            else
                MessageBox.Show("Campo CONTRASEÑA es obligatorio");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            usuario.Clear();
            contrasena.Clear();
        }
    }
}
