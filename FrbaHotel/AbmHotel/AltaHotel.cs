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
    public partial class AltaHotel : Form
    {
        public AltaHotel()
        {
            InitializeComponent();

            obtenerEstrellas();
            obtenerPaises();
            obtenerCiudades();
            obtenerRegimenes();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idHotel = crearHotel();

                regimenesList.CheckedItems.Cast<Regimen>().ToList().ForEach(r =>
                {
                    asignarRegimen(idHotel, r.id);
                });

                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { nombre, email, direccion, ciudad, pais, estrellas };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            MaskedTextBox[] controles2 = { telefono };
            foreach (MaskedTextBox control in controles2.Where(e => !e.MaskCompleted))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (regimenesList.CheckedItems.Count == 0)
            {
                errores += "Seleccione un régimen.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            ciudad.SelectedIndex = 0;
            pais.SelectedIndex = 0;
            estrellas.SelectedIndex = 0;
        }

        private int crearHotel()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].HOTEL_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = direccion.Text;
            cmd.Parameters.Add("@pais", SqlDbType.Int).Value = ((Pais)pais.SelectedItem).id;
            cmd.Parameters.Add("@ciudad", SqlDbType.Int).Value = ((Ciudad)ciudad.SelectedItem).id;
            cmd.Parameters.Add("@estrellas", SqlDbType.Int).Value = ((Estrella)estrellas.SelectedItem).numero;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            int idHotel = reader.GetInt32(0);

            reader.Close();
            sqlConnection.Close();

            return idHotel;
        }

        private void obtenerRegimenes()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].REGIMEN WHERE regi_habilitado = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    regimenesList.Items.Add(new Regimen(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void asignarRegimen(int idHotel, int idRegimen)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].HOTEL_Asignar_Regimen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = idRegimen;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void obtenerCiudades()
        {
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
    }
}
