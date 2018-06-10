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
            popularBotones();
        }

        private void popularBotones()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT f.func_id, f.func_nombre FROM FUNCIONALIDADES f JOIN FUNCIONALIDAD_ROL fr ON fr.func_id = f.func_id AND fr.rol_id = " + Conexion.rol;
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
            boton.Size = new System.Drawing.Size(205, 40);
            boton.TabIndex = panelBotones.Controls.Count;
            boton.UseVisualStyleBackColor = true;

            switch (idFuncionalidad)
            {
                case 1:
                    boton.Text = "ABM de Rol";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmRol.ListadoRol()).ShowDialog(); };
                    break;
                case 2:
                    boton.Text = "ABM de Usuario";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmUsuario.ListadoUsuario()).ShowDialog(); };
                    break;
                case 3:
                    boton.Text = "ABM de Cliente";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmCliente.ListadoCliente()).ShowDialog(); };
                    break;
                case 4:
                    boton.Text = "ABM de Hotel";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmHotel.ListadoHotel()).ShowDialog(); };
                    break;
                case 5:
                    boton.Text = "ABM de Habitación";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.AbmHabitacion.ListadoHabitacion()).ShowDialog(); };
                    break;
                case 6:
                    boton.Text = "Generar o Modificar una Reserva";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.GenerarReserva.GenerarReserva()).ShowDialog(); };
                    break;
                case 7:
                    boton.Text = "Cancelar Reserva";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.CancelarReserva.Form1()).ShowDialog(); };
                    break;
                case 8:
                    boton.Text = "Registrar Estadía(check-in/check-out)";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.RegistrarEstadia.Form1()).ShowDialog(); };
                    break;
                case 9:
                    boton.Text = "Registrar Consumibles";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.RegistrarConsumible.Form1()).ShowDialog(); };
                    break;
                case 10:
                    boton.Text = "Listado Estadístico";
                    boton.Click += delegate(System.Object o, System.EventArgs e)
                    { (new FrbaHotel.ListadoEstadistico.Form1()).ShowDialog(); };
                    break;
            }

            this.Controls.Add(boton);
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cambiarContrasena_Click(object sender, EventArgs e)
        {
            (new CambiarContrasena()).ShowDialog();
        }
    }
}
