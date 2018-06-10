namespace FrbaHotel.AbmUsuario
{
    partial class ModificarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarUsuario));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contrasena = new System.Windows.Forms.TextBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.habilitado = new System.Windows.Forms.CheckBox();
            this.labelHa = new System.Windows.Forms.Label();
            this.nroIdentificacion = new System.Windows.Forms.MaskedTextBox();
            this.telefono = new System.Windows.Forms.MaskedTextBox();
            this.altura = new System.Windows.Forms.MaskedTextBox();
            this.fechaNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.tipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.departamento = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rolesList = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hotelesList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Contraseña";
            // 
            // usuario
            // 
            this.usuario.Enabled = false;
            this.usuario.Location = new System.Drawing.Point(104, 18);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(114, 20);
            this.usuario.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.contrasena);
            this.groupBox1.Controls.Add(this.usuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 73);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Usuario";
            // 
            // contrasena
            // 
            this.contrasena.Location = new System.Drawing.Point(104, 44);
            this.contrasena.Name = "contrasena";
            this.contrasena.Size = new System.Drawing.Size(114, 20);
            this.contrasena.TabIndex = 3;
            this.contrasena.UseSystemPasswordChar = true;
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 401);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(353, 401);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 5;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.habilitado);
            this.groupBox2.Controls.Add(this.labelHa);
            this.groupBox2.Controls.Add(this.nroIdentificacion);
            this.groupBox2.Controls.Add(this.telefono);
            this.groupBox2.Controls.Add(this.altura);
            this.groupBox2.Controls.Add(this.fechaNacimiento);
            this.groupBox2.Controls.Add(this.tipoIdentificacion);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.departamento);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.apellido);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 304);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Persona";
            // 
            // habilitado
            // 
            this.habilitado.AutoSize = true;
            this.habilitado.Checked = true;
            this.habilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.habilitado.Location = new System.Drawing.Point(104, 281);
            this.habilitado.Name = "habilitado";
            this.habilitado.Size = new System.Drawing.Size(15, 14);
            this.habilitado.TabIndex = 10;
            this.habilitado.UseVisualStyleBackColor = true;
            // 
            // labelHa
            // 
            this.labelHa.AutoSize = true;
            this.labelHa.Location = new System.Drawing.Point(9, 281);
            this.labelHa.Name = "labelHa";
            this.labelHa.Size = new System.Drawing.Size(54, 13);
            this.labelHa.TabIndex = 9;
            this.labelHa.Text = "Habilitado";
            // 
            // nroIdentificacion
            // 
            this.nroIdentificacion.Location = new System.Drawing.Point(104, 96);
            this.nroIdentificacion.Mask = "99999999";
            this.nroIdentificacion.Name = "nroIdentificacion";
            this.nroIdentificacion.Size = new System.Drawing.Size(114, 20);
            this.nroIdentificacion.TabIndex = 7;
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(104, 149);
            this.telefono.Mask = "(999)0000-0000";
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(114, 20);
            this.telefono.TabIndex = 7;
            // 
            // altura
            // 
            this.altura.Location = new System.Drawing.Point(104, 200);
            this.altura.Mask = "99999";
            this.altura.Name = "altura";
            this.altura.Size = new System.Drawing.Size(114, 20);
            this.altura.TabIndex = 6;
            this.altura.ValidatingType = typeof(int);
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Location = new System.Drawing.Point(104, 252);
            this.fechaNacimiento.Mask = "00/00/0000";
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(114, 20);
            this.fechaNacimiento.TabIndex = 5;
            this.fechaNacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // tipoIdentificacion
            // 
            this.tipoIdentificacion.FormattingEnabled = true;
            this.tipoIdentificacion.Location = new System.Drawing.Point(104, 69);
            this.tipoIdentificacion.Name = "tipoIdentificacion";
            this.tipoIdentificacion.Size = new System.Drawing.Size(114, 21);
            this.tipoIdentificacion.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 255);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Fecha nacimiento";
            // 
            // departamento
            // 
            this.departamento.Location = new System.Drawing.Point(104, 226);
            this.departamento.Name = "departamento";
            this.departamento.Size = new System.Drawing.Size(114, 20);
            this.departamento.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 229);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Departamento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Altura";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(104, 174);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(114, 20);
            this.direccion.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Dirección";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Teléfono";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(104, 122);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(114, 20);
            this.email.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "E-mail";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nro. identificación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tipo identificación";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(104, 44);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(114, 20);
            this.apellido.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Apellido";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(104, 18);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(114, 20);
            this.nombre.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rolesList);
            this.groupBox3.Location = new System.Drawing.Point(243, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 190);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Roles";
            // 
            // rolesList
            // 
            this.rolesList.FormattingEnabled = true;
            this.rolesList.Location = new System.Drawing.Point(7, 21);
            this.rolesList.Name = "rolesList";
            this.rolesList.Size = new System.Drawing.Size(172, 154);
            this.rolesList.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hotelesList);
            this.groupBox4.Location = new System.Drawing.Point(243, 213);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(185, 182);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hoteles";
            // 
            // hotelesList
            // 
            this.hotelesList.FormattingEnabled = true;
            this.hotelesList.Location = new System.Drawing.Point(7, 20);
            this.hotelesList.Name = "hotelesList";
            this.hotelesList.Size = new System.Drawing.Size(172, 154);
            this.hotelesList.TabIndex = 0;
            // 
            // ModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 431);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarUsuario";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Usuario";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ModificarUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.TextBox contrasena;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox tipoIdentificacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox departamento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox telefono;
        private System.Windows.Forms.MaskedTextBox altura;
        private System.Windows.Forms.MaskedTextBox fechaNacimiento;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.CheckBox habilitado;
        private System.Windows.Forms.Label labelHa;
        private System.Windows.Forms.MaskedTextBox nroIdentificacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox rolesList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox hotelesList;

    }
}