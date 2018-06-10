namespace FrbaHotel.AbmHotel
{
    partial class ModificarHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarHotel));
            this.limpiar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.MaskedTextBox();
            this.fechaCreacion = new System.Windows.Forms.MaskedTextBox();
            this.pais = new System.Windows.Forms.ComboBox();
            this.ciudad = new System.Windows.Forms.ComboBox();
            this.estrellas2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bajaTemporal = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.regimenesList = new System.Windows.Forms.CheckedListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 273);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(292, 273);
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
            this.groupBox2.Controls.Add(this.telefono);
            this.groupBox2.Controls.Add(this.fechaCreacion);
            this.groupBox2.Controls.Add(this.pais);
            this.groupBox2.Controls.Add(this.ciudad);
            this.groupBox2.Controls.Add(this.estrellas2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.nombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 255);
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
            this.fechaCreacion.Location = new System.Drawing.Point(104, 202);
            this.fechaCreacion.Mask = "00/00/0000";
            this.fechaCreacion.Name = "fechaCreacion";
            this.fechaCreacion.Size = new System.Drawing.Size(114, 20);
            this.fechaCreacion.TabIndex = 5;
            this.fechaCreacion.ValidatingType = typeof(System.DateTime);
            // 
            // pais
            // 
            this.pais.FormattingEnabled = true;
            this.pais.Items.AddRange(new object[] {
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
            this.pais.Location = new System.Drawing.Point(104, 175);
            this.pais.Name = "pais";
            this.pais.Size = new System.Drawing.Size(114, 21);
            this.pais.TabIndex = 4;
            // 
            // ciudad
            // 
            this.ciudad.FormattingEnabled = true;
            this.ciudad.Items.AddRange(new object[] {
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
            this.ciudad.Location = new System.Drawing.Point(104, 149);
            this.ciudad.Name = "ciudad";
            this.ciudad.Size = new System.Drawing.Size(114, 21);
            this.ciudad.TabIndex = 4;
            // 
            // estrellas2
            // 
            this.estrellas2.FormattingEnabled = true;
            this.estrellas2.Items.AddRange(new object[] {
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
            this.estrellas2.Location = new System.Drawing.Point(104, 122);
            this.estrellas2.Name = "estrellas2";
            this.estrellas2.Size = new System.Drawing.Size(114, 21);
            this.estrellas2.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 205);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "País";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // bajaTemporal
            // 
            this.bajaTemporal.Location = new System.Drawing.Point(134, 273);
            this.bajaTemporal.Name = "bajaTemporal";
            this.bajaTemporal.Size = new System.Drawing.Size(114, 23);
            this.bajaTemporal.TabIndex = 5;
            this.bajaTemporal.Text = "Baja Temporal";
            this.bajaTemporal.UseVisualStyleBackColor = true;
            this.bajaTemporal.Click += new System.EventHandler(this.bajaTemporal_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.regimenesList);
            this.groupBox1.Location = new System.Drawing.Point(242, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 255);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regímenes";
            // 
            // regimenesList
            // 
            this.regimenesList.FormattingEnabled = true;
            this.regimenesList.Location = new System.Drawing.Point(6, 21);
            this.regimenesList.Name = "regimenesList";
            this.regimenesList.Size = new System.Drawing.Size(113, 229);
            this.regimenesList.TabIndex = 0;
            // 
            // ModificarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 301);
            this.Controls.Add(this.bajaTemporal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarHotel";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Hotel";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ModificarHotel_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox estrellas2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pais;
        private System.Windows.Forms.ComboBox ciudad;
        private System.Windows.Forms.Button bajaTemporal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox regimenesList;

    }
}