using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class AltaHotel : Form
    {
        public AltaHotel()
        {
            InitializeComponent();
        }

        private void AltaHotel_Load(object sender, EventArgs e)
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
            Control[] controles = { nombre, email, telefono, direccion, ciudad, pais, fechaCreacion, cantEstrellas };

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
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            ciudad.Clear();
            pais.Clear();
            fechaCreacion.Clear();
            cantEstrellas.SelectedIndex = 0;
            habilitado.Checked = true;
        }
    }
}
