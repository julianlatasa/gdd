using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarReserva
{
    public partial class GenerarReserva : Form
    {
        public GenerarReserva()
        {
            InitializeComponent();
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {

        }

        private void reservar_Click(object sender, EventArgs e)
        {

        }

        private void consultarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (validar())
            {

            }
        }

        private Boolean validar()
        {
            Control[] controles = { fechaDesde, fechaHasta, tipoHabitacion };

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
            fechaDesde.Clear();
            fechaHasta.Clear();
            tipoHabitacion.SelectedIndex = 0;
            tipoRegimen.SelectedIndex = 0;
        }
    }
}
