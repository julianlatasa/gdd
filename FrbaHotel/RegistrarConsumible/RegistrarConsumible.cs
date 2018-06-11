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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class RegistrarConsumible : Form
    {
        List<Consumible> consumibles = new List<Consumible>();

        public RegistrarConsumible()
        {
            InitializeComponent();
        }

        private void RegistrarConsumible_Load(object sender, EventArgs e)
        {
            obtenerConsumibles();
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            registarConsumible();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            codReserva.Clear();
            consumible.SelectedIndex = 0;
            cantidad.Clear();
        }

        private void obtenerConsumibles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM CONSUMIBLE";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    consumibles.Add(new Consumible(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void registarConsumible()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "CONSUMIBLE_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = Int32.Parse(codReserva.Text);
            cmd.Parameters.Add("@idConsumible", SqlDbType.Int).Value = ((Consumible) consumible.SelectedItem).id;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Int32.Parse(cantidad.Text);
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                consumible.SelectedIndex = 0;
                cantidad.Text = "1";
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Registrar Consumible");
            }

            sqlConnection.Close();
        }
    }
}
