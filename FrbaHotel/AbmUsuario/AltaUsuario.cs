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
    public partial class AltaUsuario : Form
    {
        private List<Rol> roles;
        private List<Hotel> hoteles;

        public AltaUsuario(List<Rol> roles, List<Hotel> hoteles)
        {
            this.roles = roles;
            this.hoteles = hoteles;
            InitializeComponent();
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            obtenerTiposDocumentos();
            rolesList.Items.AddRange(roles.ToArray());
            hotelesList.Items.AddRange(hoteles.ToArray());
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (crearUsuario())
                {
                    rolesList.CheckedItems.Cast<Rol>().ToList().ForEach(r =>
                    {
                        asignarRol(r.id);
                    });

                    hotelesList.CheckedItems.Cast<Hotel>().ToList().ForEach(h =>
                    {
                        asignarHotel(h.id);
                    });

                    Close();
                }
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
        }

        private bool crearUsuario()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "USUARIO_Crear";
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
            cmd.Parameters.Add("@fechaNacimiento", SqlDbType.SmallDateTime).Value = fechaNacimiento.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
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
