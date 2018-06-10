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

namespace FrbaHotel
{
    public partial class SeleccionarHotel : Form
    {
        List<Hotel> hoteles = new List<Hotel>();

        public SeleccionarHotel()
        {
            InitializeComponent();
        }

        private void SeleccionarHotel_Load(object sender, EventArgs e)
        {
            obtenerHoteles();
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            seleccionarHotel();
        }

        private void obtenerHoteles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT h.hote_nombre, h.hote_id FROM HOTEL h JOIN USUARIO_HOTEL uh ON h.hote_id = uh.hote_id AND uh.usua_usuario = " + Conexion.usuario;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hoteles.Add(new Hotel(reader));
                }
            }
            hoteles.ForEach(h => { listaHoteles.Items.Add(h.nombre); });

            reader.Close();
            sqlConnection.Close();
        }

        private void seleccionarHotel()
        {
            int idHotel = hoteles[listaHoteles.SelectedItems[0].Index].id;

            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Asignar_Hotel_Activo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();
            Conexion.hotel = idHotel;

            sqlConnection.Close();
        }

        private void irASeleccionarRolActivo()
        {
            SeleccionarHotel seleccionarHotel = new SeleccionarHotel();
            seleccionarHotel.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
            { Close(); };
            seleccionarHotel.Show();
            Hide();
        }
    }
}
