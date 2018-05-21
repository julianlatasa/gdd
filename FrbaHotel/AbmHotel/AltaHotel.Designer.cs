namespace FrbaHotel.AbmHotel
{
    partial class AltaHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaHotel));
            this.limpiar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.habilitado = new System.Windows.Forms.CheckBox();
            this.labelHa = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.MaskedTextBox();
            this.fechaCreacion = new System.Windows.Forms.MaskedTextBox();
            this.cantEstrellas = new System.Windows.Forms.ComboBox();
            this.regimen = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pais = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ciudad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 297);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(161, 297);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 5;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.habilitado);
            this.groupBox2.Controls.Add(this.labelHa);
            this.groupBox2.Controls.Add(this.telefono);
            this.groupBox2.Controls.Add(this.fechaCreacion);
            this.groupBox2.Controls.Add(this.cantEstrellas);
            this.groupBox2.Controls.Add(this.regimen);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.pais);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ciudad);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.nombre);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 279);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Hotel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "E-mail";
            // 
            // habilitado
            // 
            this.habilitado.AutoSize = true;
            this.habilitado.Checked = true;
            this.habilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.habilitado.Location = new System.Drawing.Point(104, 254);
            this.habilitado.Name = "habilitado";
            this.habilitado.Size = new System.Drawing.Size(15, 14);
            this.habilitado.TabIndex = 10;
            this.habilitado.UseVisualStyleBackColor = true;
            // 
            // labelHa
            // 
            this.labelHa.AutoSize = true;
            this.labelHa.Location = new System.Drawing.Point(9, 254);
            this.labelHa.Name = "labelHa";
            this.labelHa.Size = new System.Drawing.Size(54, 13);
            this.labelHa.TabIndex = 9;
            this.labelHa.Text = "Habilitado";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(104, 70);
            this.telefono.Mask = "(999)0000-0000";
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(114, 20);
            this.telefono.TabIndex = 7;
            // 
            // fechaCreacion
            // 
            this.fechaCreacion.Location = new System.Drawing.Point(104, 228);
            this.fechaCreacion.Mask = "00/00/0000";
            this.fechaCreacion.Name = "fechaCreacion";
            this.fechaCreacion.Size = new System.Drawing.Size(114, 20);
            this.fechaCreacion.TabIndex = 5;
            this.fechaCreacion.ValidatingType = typeof(System.DateTime);
            // 
            // cantEstrellas
            // 
            this.cantEstrellas.FormattingEnabled = true;
            this.cantEstrellas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cantEstrellas.Location = new System.Drawing.Point(104, 122);
            this.cantEstrellas.Name = "cantEstrellas";
            this.cantEstrellas.Size = new System.Drawing.Size(114, 21);
            this.cantEstrellas.TabIndex = 4;
            // 
            // regimen
            // 
            this.regimen.FormattingEnabled = true;
            this.regimen.Location = new System.Drawing.Point(104, 201);
            this.regimen.Name = "regimen";
            this.regimen.Size = new System.Drawing.Size(114, 21);
            this.regimen.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 231);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Fecha de creación";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Cant de Estrellas";
            // 
            // pais
            // 
            this.pais.Location = new System.Drawing.Point(104, 175);
            this.pais.Name = "pais";
            this.pais.Size = new System.Drawing.Size(114, 20);
            this.pais.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "País";
            // 
            // ciudad
            // 
            this.ciudad.Location = new System.Drawing.Point(104, 149);
            this.ciudad.Name = "ciudad";
            this.ciudad.Size = new System.Drawing.Size(114, 20);
            this.ciudad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ciudad";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(104, 96);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(114, 20);
            this.direccion.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Dirección";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Teléfono";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(104, 44);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(114, 20);
            this.email.TabIndex = 3;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(104, 18);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(114, 20);
            this.nombre.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tipo de Regimen";
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
            // AltaHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 326);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaHotel";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear Hotel";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AltaHotel_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox telefono;
        private System.Windows.Forms.MaskedTextBox fechaCreacion;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitado;
        private System.Windows.Forms.Label labelHa;
        private System.Windows.Forms.ComboBox cantEstrellas;
        private System.Windows.Forms.ComboBox regimen;
        private System.Windows.Forms.TextBox pais;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ciudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;

    }
}