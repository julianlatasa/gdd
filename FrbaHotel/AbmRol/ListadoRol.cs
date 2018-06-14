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

namespace FrbaHotel.AbmRol
{
    public partial class ListadoRol : Form
    {
        private List<Rol> roles = new List<Rol>();

        public ListadoRol()
        {
            InitializeComponent();
        }

        private void ListadoRol_Load(object sender, EventArgs e)
        {
            buscarRoles();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            buscarRoles();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            AltaRol altaRol = new AltaRol();
            altaRol.ShowDialog();
            buscarRoles();
        }

        private void buscarRoles()
        {
            resultados.Rows.Clear();
            roles.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ROL_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombreRol", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    roles.Add(new Rol(reader));
                }
            }
            roles.ForEach(r => {
                string[] cols = { r.nombre, "Seleccionar" };
                resultados.Rows.Add(cols); 
            });
            
            reader.Close();
            sqlConnection.Close();
        }

        private void resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ModificarRol modificarRol = new ModificarRol(roles[e.RowIndex]);
                modificarRol.ShowDialog();
                buscarRoles();
            }
        }

    }
}
