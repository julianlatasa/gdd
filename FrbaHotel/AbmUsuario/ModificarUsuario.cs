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
    public partial class ModificarUsuario : Form
    {
        private Usuario usuario2;
        private int[] rolesMarcados;
        private int[] hotelesMarcados;

        public ModificarUsuario(Usuario usuario)
        {
            this.usuario2 = usuario;
            InitializeComponent();
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            obtenerTiposDocumentos();

            usuario.Text = usuario2.usuario;
            nombre.Text = usuario2.nombre;
            apellido.Text = usuario2.apellido;
            tipoIdentificacion.SelectedItem = tipoIdentificacion.Items.Cast<TipoDocumento>().First(tp => tp.id == usuario2.tipoDocumento);
            nroIdentificacion.Text = usuario2.nroDocumento;
            email.Text = usuario2.email;
            telefono.Text = usuario2.telefono;
            if (usuario2.domicilio != null)
            {
                direccion.Text = usuario2.domicilio.Split('|')[0];
                altura.Text = usuario2.domicilio.Split('|')[1];
                departamento.Text = usuario2.domicilio.Split('|')[2];
            }
            fechaNacimiento.Text = Convert.ToDateTime(usuario2.fechaDeNacimiento).ToString("dd/MM/yyyy");
            habilitado.Checked = usuario2.habilitado;

            rolesMarcados = obtenerRolesMarcados();
            hotelesMarcados = obtenerHotelesMarcados();

            obtenerRoles();
            obtenerHoteles();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                modificarUsuario();

                List<Rol> roles2 = rolesList.CheckedItems.Cast<Rol>().ToList();
                List<Hotel> hoteles2 = hotelesList.CheckedItems.Cast<Hotel>().ToList();

                roles2.FindAll(r => !rolesMarcados.Contains(r.id)).ForEach(r =>
                {
                    asignarRol(r.id);
                });

                rolesMarcados.Where(r => roles2.Any(r2 => r2.id == r)).ToList().ForEach(r =>
                {
                    eliminarRol(r);
                });

                hoteles2.FindAll(h => !hotelesMarcados.Contains(h.id)).ForEach(h =>
                {
                    asignarHotel(h.id);
                });

                hotelesMarcados.Where(h => hoteles2.Any(h2 => h2.id == h)).ToList().ForEach(h =>
                {
                    eliminarHotel(h);
                });

                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { usuario, contrasena, nombre, apellido, tipoIdentificacion, nroIdentificacion, email, direccion, altura, departamento };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            MaskedTextBox[] controles2 = { telefono, fechaNacimiento };
            foreach (MaskedTextBox control in controles2.Where(e => !e.MaskCompleted))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (rolesList.CheckedItems.Count == 0)
            {
                errores += "Seleccione un rol.\n";
                esValido = false;
            }

            if (hotelesList.CheckedItems.Count == 0)
            {
                errores += "Seleccione un hotel.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            usuario.Clear();
            contrasena.Clear();
            nombre.Clear();
            apellido.Clear();
            nroIdentificacion.Clear();
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            altura.Clear();
            departamento.Clear();
            fechaNacimiento.Clear();
            for (int i = 0; i < rolesList.Items.Count; i++) rolesList.SetItemChecked(i, false);
            for (int i = 0; i < hotelesList.Items.Count; i++) hotelesList.SetItemChecked(i, false);
            habilitado.Checked = true;
        }

        private int[] obtenerRolesMarcados()
        {
            List<int> idRoles = new List<int>();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT rol_id FROM USUARIO_ROL WHERE usua_usuario = '" + usuario2.usuario + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idRoles.Add(reader.GetInt32(reader.GetOrdinal("rol_id")));
                }
            }

            reader.Close();
            sqlConnection.Close();

            return idRoles.ToArray();
        }

        private int[] obtenerHotelesMarcados()
        {
            List<int> idHoteles = new List<int>();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT hote_id FROM USUARIO_HOTEL WHERE usua_usuario = '" + usuario2.usuario + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idHoteles.Add(reader.GetInt32(reader.GetOrdinal("hote_id")));
                }
            }

            reader.Close();
            sqlConnection.Close();

            return idHoteles.ToArray();
        }

        private void obtenerHoteles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM HOTEL";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Hotel hotel = new Hotel(reader);
                    hotelesList.Items.Add(hotel, hotelesMarcados.Any(h => h == hotel.id));
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void obtenerRoles()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM ROL WHERE rol_habilitado = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Rol rol = new Rol(reader);
                    rolesList.Items.Add(rol, rolesMarcados.Any(r => r == rol.id));
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        private bool modificarUsuario()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Modificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.Text;
            cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena.Text;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido.Text;
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = ((TipoDocumento)tipoIdentificacion.SelectedItem).id;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar).Value = nroIdentificacion.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = String.Format("{0}|{1}|{2}", direccion.Text, altura.Text, departamento.Text);
            try
            {
                cmd.Parameters.Add("@fechaNacimiento", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaNacimiento.Text);
            }
            catch (Exception) { MessageBox.Show("Formato de fecha incorrecto", "Error"); return false; }
            cmd.Parameters.Add("@habilitado", SqlDbType.Char).Value = habilitado.Checked ? '1' : '0';
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Usuario modificado con exito.", "Modificar Usuario");
                return true;
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }

            sqlConnection.Close();
            return false;
        }

        private void asignarHotel(int idHotel)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Asignar_Hotel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.Text;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void eliminarHotel(int idHotel)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Eliminar_Hotel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void asignarRol(int idRol)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Asignar_Rol";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.Text;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void eliminarRol(int idRol)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Eliminar_Rol";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Conexion.usuario;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void obtenerTiposDocumentos()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM TIPO_DOCUMENTO";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tipoIdentificacion.Items.Add(new TipoDocumento(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
