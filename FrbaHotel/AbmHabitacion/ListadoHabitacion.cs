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

namespace FrbaHotel.AbmHabitacion
{
    public partial class ListadoHabitacion : Form
    {
        private List<Habitacion> habitaciones = new List<Habitacion>();

        public ListadoHabitacion()
        {
            InitializeComponent();

            buscarHabitaciones();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            (new AltaHabitacion()).ShowDialog();
            buscarHabitaciones();
        }

        private void buscarHabitaciones()
        {
            resultados.Rows.Clear();
            habitaciones.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].HABITACION_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = Conexion.hotel;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    habitaciones.Add(new Habitacion(reader));
                }
            }
            habitaciones.ForEach(h =>
            {
                string[] cols = { h.numero.ToString(), h.piso.ToString(), "Seleccionar" };
                resultados.Rows.Add(cols);
            });

            reader.Close();
            sqlConnection.Close();
        }

        private void resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                (new ModificarHabitacion(habitaciones[e.RowIndex])).ShowDialog();
                buscarHabitaciones();
            }
        }
    }
}
