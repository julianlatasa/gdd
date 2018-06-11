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
using FrbaHotel.Objetos;

namespace FrbaHotel.AbmHotel
{
    public partial class BajaTemporal : Form
    {
        private Hotel hotel;

        public BajaTemporal(Hotel hotel)
        {
            this.hotel = hotel;
            InitializeComponent();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                crearBajaTemporal();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { descripcion, fechaDesde, fechaHasta };

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
            descripcion.Clear();
            fechaDesde.Clear();
            fechaHasta.Clear();
        }

        private void crearBajaTemporal()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "HOTEL_Asignar_Baja_Temporal";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = hotel.id;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion.Text;
            cmd.Parameters.Add("@fechaDesde", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaDesde.Text);
            cmd.Parameters.Add("@fechaHasta", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaHasta.Text);
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }

            sqlConnection.Close();
        }
    }
}
