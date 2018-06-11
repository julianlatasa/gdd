﻿using System;
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
        private List<Rol> roles;
        private List<Hotel> hoteles;
        private int[] rolesMarcados;
        private int[] hotelesMarcados;

        public ModificarUsuario(Usuario usuario, List<Rol> roles, List<Hotel> hoteles)
        {
            this.usuario2 = usuario;
            this.roles = roles;
            this.hoteles = hoteles;
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

            roles.ForEach(r => { rolesList.Items.Add(r, rolesMarcados.Any(rm => rm == r.id)); });
            hoteles.ForEach(h => { hotelesList.Items.Add(h, hotelesMarcados.Any(hm => hm == h.id)); });
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
            Control[] controles = { usuario, contrasena, nombre, apellido, tipoIdentificacion, nroIdentificacion, email, telefono, direccion, altura, fechaNacimiento };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            if (rolesList.SelectedItems.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un rol");
            }

            if (hotelesList.SelectedItems.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un hotel");
            }

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
            rolesList.ClearSelected();
            hotelesList.ClearSelected();
            habilitado.Checked = true;
        }

        private int[] obtenerRolesMarcados()
        {
            List<int> idRoles = new List<int>();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT rol_id FROM USUARIO_ROL WHERE usua_usuario = '" + usuario2.usuario +"'";
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
            cmd.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = ((TipoDocumento) tipoIdentificacion.SelectedItem).id;
            cmd.Parameters.Add("@nroDocumento", SqlDbType.VarChar).Value = nroIdentificacion.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = String.Format("{0}|{1}|{2}", direccion.Text, altura.Text, departamento.Text);
            cmd.Parameters.Add("@fechaNacimiento", SqlDbType.SmallDateTime).Value = ConvertFecha.fechaVsABd(fechaNacimiento.Text);
            cmd.Parameters.Add("@habilitado", SqlDbType.Char).Value = habilitado.Checked ? 1 : 0;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Usuario modificado con exito.","Modificar Usuario");
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
