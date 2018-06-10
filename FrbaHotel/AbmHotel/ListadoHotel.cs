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
    public partial class ListadoHotel : Form
    {
        List<Hotel> hoteles = new List<Hotel>();

        public ListadoHotel()
        {
            InitializeComponent();
        }

        private void ListadoUsuario_Load(object sender, EventArgs e)
        {
            obtenerEstrellas();
            obtenerPaises();
            obtenerCiudades();
            obtenerHoteles();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            obtenerHoteles();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            estrellas.SelectedIndex = 0;
            ciudad.SelectedIndex = 0;
            pais.SelectedIndex = 0;
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            (new AltaHotel(estrellas.Items.Cast<Estrella>().ToList(), pais.Items.Cast<Pais>().ToList(), ciudad.Items.Cast<Ciudad>().ToList())).ShowDialog();
        }

        private void resultados_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void obtenerHoteles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "HOTEL_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@pais", SqlDbType.Int).Value = ((Pais) pais.SelectedItem).id;
            cmd.Parameters.Add("@ciudad", SqlDbType.Int).Value = ((Ciudad) ciudad.SelectedItem).id;
            cmd.Parameters.Add("@estrellas", SqlDbType.Char).Value = ((Estrella) estrellas.SelectedItem).numero;
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
            hoteles.ForEach(h => { resultados.Items.Add(h.ToString()); });

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerCiudades()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM CIUDAD";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ciudad.Items.Add(new Ciudad(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerPaises()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM PAIS";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pais.Items.Add(new Pais(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerEstrellas()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM ESTRELLAS";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    estrellas.Items.Add(new Estrella(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
