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
    public partial class Estadistico4 : Form
    {
        string desde, hasta;

        public Estadistico4(string desde, string hasta)
        {
            this.desde = desde;
            this.hasta = hasta;
            InitializeComponent();

            resultados.Items.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ESTADISTICO_4";
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
                    //ListViewItem item = new ListViewItem(reader.GetInt32(0).ToString());
                    //item.SubItems.Add(reader.GetString(1));
                    //item.SubItems.Add(reader.GetInt32(2).ToString());
                    //item.SubItems.Add(reader.GetInt32(3).ToString());
                    //resultados.Items.Add(item);
                    string[] cols = { reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString() };
                    resultados.Items.Add(reader.GetInt32(0).ToString()).SubItems.AddRange(cols);
                }
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
