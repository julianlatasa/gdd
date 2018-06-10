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
    public partial class ModificarHotel : Form
    {
        private List<Estrella> estrellas;
        private List<Pais> paises;
        private List<Ciudad> ciudades;
        private int[] regimenesMarcados;
        private Hotel hotel;

        public ModificarHotel(Hotel hotel, List<Estrella> estrellas, List<Pais> paises, List<Ciudad> ciudades)
        {
            this.hotel = hotel;
            this.estrellas = estrellas;
            this.paises = paises;
            this.ciudades = ciudades;
            InitializeComponent();
        }

        private void ModificarHotel_Load(object sender, EventArgs e)
        {
            estrellas2.Items.AddRange(estrellas.ToArray());
            pais.Items.AddRange(paises.ToArray());
            ciudad.Items.AddRange(ciudades.ToArray());

            regimenesMarcados = obtenerRegimenesMarcados();

            obtenerRegimenes();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                modificarHotel();

                List<Regimen> regimenes = regimenesList.CheckedItems.Cast<Regimen>().ToList();

                regimenes.FindAll(r => !regimenesMarcados.Contains(r.id)).ForEach(r =>
                {
                    asignarRegimen(hotel.id, r.id);
                });

                regimenesMarcados.Where(r => regimenes.Any(r2 => r2.id == r)).ToList().ForEach(r =>
                {
                    eliminarRegimen(hotel.id, r);
                });

                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { nombre, email, telefono, direccion, ciudad, pais, fechaCreacion, estrellas2 };

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

        private void bajaTemporal_Click(object sender, EventArgs e)
        {
            using (BajaTemporal bajaTemporal = new BajaTemporal(hotel))
            {
                DialogResult dr = bajaTemporal.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            ciudad.SelectedIndex = 0;
            pais.SelectedIndex = 0;
            estrellas2.SelectedIndex = 0;
            fechaCreacion.Clear();
        }

        private void modificarHotel()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "HOTEL_Modificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = hotel.id;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = direccion.Text;
            cmd.Parameters.Add("@pais", SqlDbType.Int).Value = nombre.Text;
            cmd.Parameters.Add("@ciudad", SqlDbType.Int).Value = nombre.Text;
            cmd.Parameters.Add("@estrellas", SqlDbType.Int).Value = nombre.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private int[] obtenerRegimenesMarcados()
        {
            List<int> idRegimenes = new List<int>();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT regi_id FROM HOTEL_REGIMEN WHERE hote_id = " + hotel.id;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idRegimenes.Add(reader.GetInt32(reader.GetOrdinal("regi_id")));
                }
            }

            reader.Close();
            sqlConnection.Close();

            return idRegimenes.ToArray();
        }

        private void obtenerRegimenes()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM REGIMEN WHERE regi_habilitado = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Regimen regimen = new Regimen(reader);
                    regimenesList.Items.Add(regimen, regimenesMarcados.Any(f => f == regimen.id));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void asignarRegimen(int idHotel, int idRegimen)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "HOTEL_Asignar_Regimen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = idRegimen;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void eliminarRegimen(int idHotel, int idRegimen)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "HOTEL_Eliminar_Regimen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = idRegimen;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
