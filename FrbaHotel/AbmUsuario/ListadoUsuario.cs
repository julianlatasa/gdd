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

namespace FrbaHotel.AbmUsuario
{
    public partial class ListadoUsuario : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public ListadoUsuario()
        {
            InitializeComponent();

            obtenerRoles();
            obtenerHoteles();
            obtenerUsuarios();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            obtenerUsuarios();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            usuario.Clear();
            rolCombobox.SelectedIndex = 0;
            hotelCombobox.SelectedIndex = 0;
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            AltaUsuario altaUsuario = new AltaUsuario();
            altaUsuario.ShowDialog();
            obtenerUsuarios();
        }

        private void obtenerUsuarios()
        {
            usuarios.Clear();
            resultados.Rows.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].USUARIO_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.Text;
            if (rolCombobox.SelectedIndex > 0)
                cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = ((Rol)rolCombobox.SelectedItem).id;
            if (hotelCombobox.SelectedIndex > 0)
                cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = ((Hotel)hotelCombobox.SelectedItem).id;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] cols = { reader.GetString(0), "Seleccionar" };
                    resultados.Rows.Add(cols);
                    usuarios.Add(new Usuario(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerHoteles()
        {
            hotelCombobox.Items.Add(new Hotel());
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].HOTEL";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hotelCombobox.Items.Add(new Hotel(reader));
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerRoles()
        {
            rolCombobox.Items.Add(new Rol());
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].ROL WHERE rol_habilitado = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rolCombobox.Items.Add(new Rol(reader));
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
                ModificarUsuario modificarUsuario = new ModificarUsuario((Usuario)usuarios[e.RowIndex]);
                modificarUsuario.ShowDialog();
                obtenerUsuarios();
            }
        }

    }
}
