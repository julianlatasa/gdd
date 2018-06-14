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
    public partial class IngresarReserva : Form
    {
        public IngresarReserva()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (codigoReserva.Text.Length > 0)
            {
                if (buscarReserva())
                {
                    ModificarReserva modificarReserva = new ModificarReserva(Int32.Parse(codigoReserva.Text));
                    modificarReserva.ShowDialog();
                }
            }
        }

        private bool buscarReserva()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = " + Int32.Parse(codigoReserva.Text);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            bool resultado = false;

            if (reader.HasRows)
            {
                reader.Read();
                resultado = reader.GetInt32(0) > 0;
            }

            reader.Close();
            sqlConnection.Close();

            return resultado;
        }
    }
}
