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
        }

        private void ListadoHabitacion_Load(object sender, EventArgs e)
        {
            buscarHabitaciones();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            (new AltaHabitacion()).ShowDialog();
        }

        private void resultados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (new ModificarHabitacion(habitaciones[resultados.SelectedItems[0].Index])).ShowDialog();
        }

        private void buscarHabitaciones()
        {
            resultados.Items.Clear();
            habitaciones.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "HABITACION_Buscar";
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
                resultados.Items.Add(h.numero.ToString()).SubItems.Add(h.piso.ToString());
            });

            reader.Close();
            sqlConnection.Close();
        }
    }
}
