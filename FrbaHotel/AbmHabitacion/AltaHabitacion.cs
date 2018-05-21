using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class AltaHabitacion : Form
    {
        public AltaHabitacion()
        {
            InitializeComponent();
        }

        private void AltaHabitacion_Load(object sender, EventArgs e)
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
            Control[] controles = { nroHabitacion, pisoHabitacion, ubicacionHotel, tipoHabitacion, descripcion };

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
            nroHabitacion.Clear();
            pisoHabitacion.Clear();
            ubicacionHotel.SelectedIndex = 0;
            tipoHabitacion.SelectedIndex = 0;
            descripcion.Clear();
            comodidades.ClearSelected();
            habilitado.Checked = true;
        }
    }
}
