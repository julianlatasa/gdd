using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {

            }
        }

        private Boolean validar()
        {
            Control[] controles = { nombre, apellido, tipoDocumento, documento, email, telefono, direccion, altura, fechaNacimiento, localidad, paisDeOrigen, nacionalidad };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            documento.Clear();
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            altura.Clear();
            departamento.Clear();
            fechaNacimiento.Clear();
            localidad.Clear();
            paisDeOrigen.Clear();
            nacionalidad.Clear();
            habilitado.Checked = true;
        }
    }
}
