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

namespace FrbaHotel
{
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void user_button_Click(object sender, EventArgs e)
        {
            FrbaHotel.Login.Login login = new FrbaHotel.Login.Login();
            login.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
            { Show(); };
            login.Show();
            Hide();
        }

        private void guest_button_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].GUEST_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            Conexion.rol = reader.GetInt32(reader.GetOrdinal("rol_id"));
            Conexion.usuario = reader.GetString(reader.GetOrdinal("usua_usuario")).Trim().ToUpper();
            Conexion.rolNombre = Conexion.usuario;

            reader.Close();
            sqlConnection.Close();

            Menu menu = new Menu();
            menu.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
            { Show(); };
            menu.Show();
            Hide();
        }
    }
}
