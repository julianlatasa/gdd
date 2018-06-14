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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            rolNombre.Text = Conexion.rolNombre;

            if (Conexion.rolNombre == "INVITADO")
                cambiarContrasena.Visible = false;

            popularBotones();
        }

        private void popularBotones()
        {
            panelBotones.Controls.Clear();
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT f.func_id, f.func_nombre FROM [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD f JOIN [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL fr ON fr.func_id = f.func_id AND fr.rol_id = " + Conexion.rol + " ORDER BY f.func_id";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    generarBotonParaFuncionalidad(reader.GetInt32(reader.GetOrdinal("func_id")));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void generarBotonParaFuncionalidad(int idFuncionalidad)
        {
            Button boton = new Button();
            boton.Location = new System.Drawing.Point(3, panelBotones.Controls.Count * 43);
            boton.Size = new System.Drawing.Size(180, 40);
            boton.TabIndex = panelBotones.Controls.Count;
            boton.UseVisualStyleBackColor = true;

            switch (idFuncionalidad)
            {
                case 1:
                    boton.Text = "ABM de Rol";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmRol.ListadoRol()).ShowDialog(); popularBotones(); };
                    break;
                case 2:
                    boton.Text = "ABM de Usuario";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmUsuario.ListadoUsuario()).ShowDialog(); popularBotones(); };
                    break;
                case 3:
                    boton.Text = "ABM de Cliente";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmCliente.ListadoCliente()).ShowDialog(); popularBotones(); };
                    break;
                case 4:
                    boton.Text = "ABM de Hotel";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmHotel.ListadoHotel()).ShowDialog(); popularBotones(); };
                    break;
                case 5:
                    boton.Text = "ABM de Habitación";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmHabitacion.ListadoHabitacion()).ShowDialog(); popularBotones(); };
                    break;
                case 6:
                    boton.Text = "Generar una Reserva";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.GenerarReserva.GenerarReserva()).ShowDialog(); popularBotones(); };
                    break;
                case 7:
                    boton.Text = "Modificar una Reserva";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.GenerarModificacionReserva.IngresarReserva()).ShowDialog(); popularBotones(); };
                    break;
                case 8:
                    boton.Text = "Registrar Estadía(check-in)";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.RegistrarEstadia.RegistrarEstadia()).ShowDialog(); popularBotones(); };
                    break;
                case 9:
                    boton.Text = "Registrar Estadía(check-out)";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.RegistrarEstadia.RegistrarSalida()).ShowDialog(); popularBotones(); };
                    break;
                case 10:
                    boton.Text = "Registrar Consumibles";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.RegistrarConsumible.RegistrarConsumible()).ShowDialog(); popularBotones(); };
                    break;
                case 11:
                    boton.Text = "Listado Estadístico";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.ListadoEstadistico.ListadoEstadistico()).ShowDialog(); popularBotones(); };
                    break;
            }

            panelBotones.Controls.Add(boton);
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Conexion.hotel = 0;
            Conexion.rol = 0;
            Conexion.rolNombre = null;
            Conexion.usuario = null;
            Close();
        }

        private void cambiarContrasena_Click(object sender, EventArgs e)
        {
            CambiarContrasena cambiarContrasena = new CambiarContrasena();
            cambiarContrasena.FormClosed += delegate(System.Object o, System.Windows.Forms.FormClosedEventArgs ee)
            { Show(); };
            cambiarContrasena.Show();
            Hide();
        }
    }
}
