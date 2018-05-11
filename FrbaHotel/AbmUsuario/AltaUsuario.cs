using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {

            }
        }

        private Boolean validar()
        {
            Control[] controles = { usuario, contrasena, rol, nombre, apellido, tipoIdentificacion, nroIdentificacion, email, telefono, direccion, altura, fechaNacimiento, hotel };

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
            usuario.Clear();
            contrasena.Clear();
            rol.SelectedIndex = 0;
            nombre.Clear();
            apellido.Clear();
            nroIdentificacion.Clear();
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            altura.Clear();
            departamento.Clear();
            fechaNacimiento.Clear();
            hotel.SelectedIndex = -1;
            habilitado.Checked = true;
        }
    }
}
