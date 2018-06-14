using FrbaHotel.GenerarReserva;
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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void visualizar_Click(object sender, EventArgs e)
        {
            if(anio.Text.Length > 0 && trimestre.SelectedItem != null && estadistica.SelectedItem != null)
            {
                int anio2 = Int32.Parse(anio.Text);
                int trimestre2 = Int32.Parse(trimestre.Text);
                string desde = (new DateTime(anio2, trimestre2 * 3-2, 1)).ToShortDateString();
                string hasta = (new DateTime(anio2, trimestre2 * 3, DateTime.DaysInMonth(anio2, trimestre2*3))).ToShortDateString();

                switch (estadistica.SelectedIndex)
                {
                    case 0:
                        (new Estadistico1(desde, hasta)).ShowDialog();
                        break;
                    case 1:
                        (new Estadistico2(desde, hasta)).ShowDialog();
                        break;
                    case 2:
                        (new Estadistico3(desde, hasta)).ShowDialog();
                        break;
                    case 3:
                        (new Estadistico4(desde, hasta)).ShowDialog();
                        break;
                    case 4:
                        (new Estadistico5(desde, hasta)).ShowDialog();
                        break;
                }
            }
        }
    }
}
