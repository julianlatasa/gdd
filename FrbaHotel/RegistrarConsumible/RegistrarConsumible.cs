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

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE";
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
            consumibles.ForEach(c => consumible.Items.Add(c));
            consumible.SelectedIndex = 0;

            reader.Close();
            sqlConnection.Close();
        }

        private void registarConsumible()
        {
            if (validar())
            {
                SqlConnection sqlConnection = Conexion.getSqlConnection();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_Crear";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idReserva", SqlDbType.Int).Value = Int32.Parse(codReserva.Text);
                cmd.Parameters.Add("@idConsumible", SqlDbType.Int).Value = ((Consumible)consumible.SelectedItem).id;
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = Int32.Parse(cantidad.Text);
                cmd.Connection = sqlConnection;

                sqlConnection.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    consumible.SelectedIndex = 0;
                    cantidad.Text = "1";
                    MessageBox.Show("Consumible registrado a la reserva " + codReserva.Text, "Registrar Consumible");
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.Message, "Registrar Consumible");
                }

                sqlConnection.Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { codReserva, consumible, cantidad };

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

    }
}
