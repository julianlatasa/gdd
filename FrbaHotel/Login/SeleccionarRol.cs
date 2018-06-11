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

namespace FrbaHotel
{
    public partial class SeleccionarRol : Form
    {
        List<Rol> roles = new List<Rol>();

        public SeleccionarRol()
        {
            InitializeComponent();
        }

        private void SeleccionarRol_Load(object sender, EventArgs e)
        {
            obtenerRoles();

            if (roles.Count == 1)
            {
                asignarRolActivo(roles[0]);
                irAMenuPrincipal();
            }
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            seleccionarRol();
            irAMenuPrincipal();
        }

        private void obtenerRoles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT r.rol_nombre, r.rol_id FROM ROL r JOIN USUARIO_ROL ur ON r.rol_id = ur.rol_id AND ur.usua_usuario = '" + Conexion.usuario + "' WHERE r.rol_habilitado = 1";
            cmd.CommandType = CommandType.Text;
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
            roles.ForEach(h => { listaRoles.Items.Add(h.nombre); });

            reader.Close();
            sqlConnection.Close();
        }

        private void seleccionarRol()
        {
            Rol rol = roles[listaRoles.SelectedItems[0].Index];

            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Asignar_Rol_Activo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = rol.id;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();
            asignarRolActivo(rol);

            sqlConnection.Close();
            //this.Close();
        }

        private void asignarRolActivo(Rol rol)
        {
            Conexion.rol = rol.id;
            Conexion.rolNombre = rol.nombre;
        }

        private void irAMenuPrincipal()
        {
            Menu menu = new Menu();
            menu.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
            { Close(); };
            menu.Show();
            Close();
        }
    }
}
