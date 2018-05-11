using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
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
            Boolean esValido = true;
            if (String.IsNullOrEmpty(nombre.Text))
                esValido = false;
            else
                MessageBox.Show("Campo NOMBRE es obligatorio");

            if (funcionalidades.SelectedItems.Count == 0)
                esValido = false;
            else
                MessageBox.Show("Seleccione una funcionalidad");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            funcionalidades.ClearSelected();
            activo.Checked = true;
        }
    }
}
