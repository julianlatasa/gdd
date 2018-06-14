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
            AltaHotel altaHotel = new AltaHotel();
            altaHotel.ShowDialog();
            obtenerHoteles();
        }

        private void obtenerHoteles()
        {
            hoteles.Clear();
            resultados.Rows.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].HOTEL_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            if (pais.SelectedIndex > 0)
                cmd.Parameters.Add("@pais", SqlDbType.Int).Value = ((Pais)pais.SelectedItem).id;
            if (ciudad.SelectedIndex > 0)
                cmd.Parameters.Add("@ciudad", SqlDbType.Int).Value = ((Ciudad)ciudad.SelectedItem).id;
            if (estrellas.SelectedIndex > 0)
                cmd.Parameters.Add("@estrellas", SqlDbType.Char).Value = ((Estrella)estrellas.SelectedItem).numero;
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
            hoteles.ForEach(h =>
            {
                string[] cols = { h.nombre, h.estrellas.ToString(), 
                                    ciudad.Items.Cast<Ciudad>().ToList().First(c => c.id == h.ciudad).nombre, 
                                    pais.Items.Cast<Pais>().ToList().First(p => p.id == h.pais).nombre, "Seleccionar" };
                resultados.Rows.Add(cols);
            });

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerCiudades()
        {
            ciudad.Items.Add(new Ciudad());
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].CIUDAD";
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
            pais.Items.Add(new Pais());
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].PAIS";
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
            estrellas.Items.Add(new Estrella());
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].ESTRELLAS";
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

        private void resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ModificarHotel modificarHotel = new ModificarHotel(hoteles[e.RowIndex]);
                modificarHotel.ShowDialog();
                obtenerHoteles();
            }
        }
    }
}
