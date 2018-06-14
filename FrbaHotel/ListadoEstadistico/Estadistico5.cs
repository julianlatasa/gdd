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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class Estadistico5 : Form
    {
        string desde, hasta;

        public Estadistico5(string desde, string hasta)
        {
            this.desde = desde;
            this.hasta = hasta;
            InitializeComponent();

            resultados.Items.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ESTADISTICO_5";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@desde", SqlDbType.SmallDateTime).Value = desde;
            cmd.Parameters.Add("@hasta", SqlDbType.SmallDateTime).Value = hasta;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] cols = { reader.GetString(1), reader.GetInt32(2).ToString() };
                    resultados.Items.Add(reader.GetString(0)).SubItems.AddRange(cols);
                }
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
