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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class CancelarReserva : Form
    {
        public string motivo2;

        public CancelarReserva()
        {
            InitializeComponent();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (motivo.Text.Length > 0)
            {
                motivo2 = motivo.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
