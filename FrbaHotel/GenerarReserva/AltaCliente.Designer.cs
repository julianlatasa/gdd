namespace FrbaHotel.GenerarReserva
{
    partial class AltaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaCliente));
            this.limpiar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fechaNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.telefono = new System.Windows.Forms.MaskedTextBox();
            this.altura = new System.Windows.Forms.MaskedTextBox();
            this.nacionalidad = new System.Windows.Forms.ComboBox();
            this.pais = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tipoDocumento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.localidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.departamento = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.documento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 377);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 15;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(161, 377);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 14;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fechaNacimiento);
            this.groupBox2.Controls.Add(this.telefono);
            this.groupBox2.Controls.Add(this.altura);
            this.groupBox2.Controls.Add(this.nacionalidad);
            this.groupBox2.Controls.Add(this.pais);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tipoDocumento);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.localidad);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.departamento);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.documento);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.apellido);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 359);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Cliente";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Location = new System.Drawing.Point(104, 332);
            this.fechaNacimiento.Mask = "00/00/0000";
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(114, 20);
            this.fechaNacimiento.TabIndex = 13;
            this.fechaNacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(104, 149);
            this.telefono.Mask = "(999)0000-0000";
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(114, 20);
            this.telefono.TabIndex = 6;
            // 
            // altura
            // 
            this.altura.Location = new System.Drawing.Point(104, 200);
            this.altura.Mask = "99999";
            this.altura.Name = "altura";
            this.altura.Size = new System.Drawing.Size(114, 20);
            this.altura.TabIndex = 8;
            this.altura.ValidatingType = typeof(int);
            // 
            // nacionalidad
            // 
            this.nacionalidad.FormattingEnabled = true;
            this.nacionalidad.Location = new System.Drawing.Point(104, 305);
            this.nacionalidad.Name = "nacionalidad";
            this.nacionalidad.Size = new System.Drawing.Size(114, 21);
            this.nacionalidad.TabIndex = 12;
            // 
            // pais
            // 
            this.pais.FormattingEnabled = true;
            this.pais.Location = new System.Drawing.Point(104, 278);
            this.pais.Name = "pais";
            this.pais.Size = new System.Drawing.Size(114, 21);
            this.pais.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nacionalidad";
            // 
            // tipoDocumento
            // 
            this.tipoDocumento.FormattingEnabled = true;
            this.tipoDocumento.Location = new System.Drawing.Point(104, 69);
            this.tipoDocumento.Name = "tipoDocumento";
            this.tipoDocumento.Size = new System.Drawing.Size(114, 21);
            this.tipoDocumento.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "País de origen";
            // 
            // localidad
            // 
            this.localidad.Location = new System.Drawing.Point(104, 252);
            this.localidad.Name = "localidad";
            this.localidad.Size = new System.Drawing.Size(114, 20);
            this.localidad.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Localidad";
            // 
            // departamento
            // 
            this.departamento.Location = new System.Drawing.Point(104, 226);
            this.departamento.Name = "departamento";
            this.departamento.Size = new System.Drawing.Size(114, 20);
            this.departamento.TabIndex = 9;
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
            this.direccion.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha Nacimiento";
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
            this.email.TabIndex = 5;
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
            // documento
            // 
            this.documento.Location = new System.Drawing.Point(104, 96);
            this.documento.Name = "documento";
            this.documento.Size = new System.Drawing.Size(114, 20);
            this.documento.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Documento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tipo documento";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(104, 44);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(114, 20);
            this.apellido.TabIndex = 2;
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
            this.nombre.TabIndex = 1;
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
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 408);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaCliente";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Cliente";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AltaCliente_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox tipoDocumento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox documento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox departamento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox telefono;
        private System.Windows.Forms.MaskedTextBox altura;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox localidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nacionalidad;
        private System.Windows.Forms.ComboBox pais;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox fechaNacimiento;
        private System.Windows.Forms.Label label4;

    }
}