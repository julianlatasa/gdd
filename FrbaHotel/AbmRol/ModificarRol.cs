using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Objetos;

namespace FrbaHotel
{
    public partial class ModificarRol : Form
    {
        private Rol rol;
        private int[] funcionalidadesMarcadas;

        public ModificarRol(Rol rol)
        {
            this.rol = rol;
            InitializeComponent();
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            nombre.Text = rol.nombre;
            activo.Checked = rol.habilitado;
            funcionalidadesMarcadas = marcarFuncionalidadesRol();
            llenarListaFuncionalidades(funcionalidadesMarcadas);
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                modificarRol();

                List<Funcionalidad> funcionalidades2 = funcionalidades.CheckedItems.Cast<Funcionalidad>().ToList();
                
                funcionalidades2.FindAll(f => !funcionalidadesMarcadas.Contains(f.id)).ForEach(f =>
                {
                    asignarFuncionalidad(rol.id, f.id);
                });

                funcionalidadesMarcadas.Where(f => !funcionalidades2.Any(f2 => f2.id == f)).ToList().ForEach(f =>
                {
                    eliminarFuncionalidad(rol.id, f);
                });
                Close();
            }
        }

        private Boolean validar()
        {
            Boolean esValido = true;
            if (String.IsNullOrEmpty(nombre.Text))
            {
                esValido = false;
                MessageBox.Show("Campo NOMBRE es obligatorio");
            }
            
            if (funcionalidades.CheckedItems.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione una funcionalidad");
            }

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            for (int i = 0; i < funcionalidades.Items.Count; i++) funcionalidades.SetItemChecked(i, false);
            activo.Checked = true;
        }

        private int[] marcarFuncionalidadesRol()
        {
            List<int> idFuncionalidades = new List<int>();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL WHERE rol_id = " + rol.id;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idFuncionalidades.Add(reader.GetInt32(reader.GetOrdinal("func_id")));
                }
            }

            reader.Close();
            sqlConnection.Close();

            return idFuncionalidades.ToArray();
        }

        private void llenarListaFuncionalidades(int[] funcionalidadesMarcadas)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Funcionalidad funcionalidad = new Funcionalidad(reader);
                    funcionalidades.Items.Add(funcionalidad, funcionalidadesMarcadas.Any(f => f == funcionalidad.id));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void modificarRol()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ROL_Modificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = rol.id;
            cmd.Parameters.Add("@nombreRol", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@habilitado", SqlDbType.Char).Value = activo.Checked ? '1' : '0';
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void asignarFuncionalidad(int idRol, int idFuncionalidad)
        {
            try
            {
                SqlConnection sqlConnection = Conexion.getSqlConnection();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ROL_Asignar_Funcionalidad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
                cmd.Parameters.Add("@idFuncionalidad", SqlDbType.Int).Value = idFuncionalidad;
                cmd.Connection = sqlConnection;

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eliminarFuncionalidad(int idRol, int idFuncionalidad)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "[DON_GATO_Y_SU_PANDILLA].ROL_Eliminar_Funcionalidad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
            cmd.Parameters.Add("@idFuncionalidad", SqlDbType.Int).Value = idFuncionalidad;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
