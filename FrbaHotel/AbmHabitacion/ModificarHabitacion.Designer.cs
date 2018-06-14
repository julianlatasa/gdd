namespace FrbaHotel.AbmHabitacion
{
    partial class ModificarHabitacion
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarHabitacion));
            this.limpiar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ubicacionHotel = new System.Windows.Forms.ComboBox();
            this.tipoHabitacion = new System.Windows.Forms.ComboBox();
            this.comodidades = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.habilitado = new System.Windows.Forms.CheckBox();
            this.labelHa = new System.Windows.Forms.Label();
            this.pisoHabitacion = new System.Windows.Forms.MaskedTextBox();
            this.nroHabitacion = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 350);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 8;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(192, 350);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 9;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ubicacionHotel);
            this.groupBox2.Controls.Add(this.tipoHabitacion);
            this.groupBox2.Controls.Add(this.comodidades);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.habilitado);
            this.groupBox2.Controls.Add(this.labelHa);
            this.groupBox2.Controls.Add(this.pisoHabitacion);
            this.groupBox2.Controls.Add(this.nroHabitacion);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.descripcion);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 332);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Habitación";
            // 
            // ubicacionHotel
            // 
            this.ubicacionHotel.FormattingEnabled = true;
            this.ubicacionHotel.Items.AddRange(new object[] {
            "Vista al exterior",
            "Vista al interior"});
            this.ubicacionHotel.Location = new System.Drawing.Point(128, 66);
            this.ubicacionHotel.Name = "ubicacionHotel";
            this.ubicacionHotel.Size = new System.Drawing.Size(114, 21);
            this.ubicacionHotel.TabIndex = 3;
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.Enabled = false;
            this.tipoHabitacion.FormattingEnabled = true;
            this.tipoHabitacion.Location = new System.Drawing.Point(128, 92);
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.Size = new System.Drawing.Size(114, 21);
            this.tipoHabitacion.TabIndex = 4;
            // 
            // comodidades
            // 
            this.comodidades.FormattingEnabled = true;
            this.comodidades.Location = new System.Drawing.Point(128, 209);
            this.comodidades.Name = "comodidades";
            this.comodidades.Size = new System.Drawing.Size(114, 94);
            this.comodidades.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Piso dentro del Hotel";
            // 
            // habilitado
            // 
            this.habilitado.AutoSize = true;
            this.habilitado.Checked = true;
            this.habilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.habilitado.Location = new System.Drawing.Point(128, 309);
            this.habilitado.Name = "habilitado";
            this.habilitado.Size = new System.Drawing.Size(15, 14);
            this.habilitado.TabIndex = 7;
            this.habilitado.UseVisualStyleBackColor = true;
            // 
            // labelHa
            // 
            this.labelHa.AutoSize = true;
            this.labelHa.Location = new System.Drawing.Point(9, 309);
            this.labelHa.Name = "labelHa";
            this.labelHa.Size = new System.Drawing.Size(54, 13);
            this.labelHa.TabIndex = 9;
            this.labelHa.Text = "Habilitado";
            // 
            // pisoHabitacion
            // 
            this.pisoHabitacion.Enabled = false;
            this.pisoHabitacion.Location = new System.Drawing.Point(128, 40);
            this.pisoHabitacion.Mask = "99999";
            this.pisoHabitacion.Name = "pisoHabitacion";
            this.pisoHabitacion.Size = new System.Drawing.Size(114, 20);
            this.pisoHabitacion.TabIndex = 2;
            this.pisoHabitacion.ValidatingType = typeof(int);
            // 
            // nroHabitacion
            // 
            this.nroHabitacion.Enabled = false;
            this.nroHabitacion.Location = new System.Drawing.Point(128, 14);
            this.nroHabitacion.Mask = "99999";
            this.nroHabitacion.Name = "nroHabitacion";
            this.nroHabitacion.Size = new System.Drawing.Size(114, 20);
            this.nroHabitacion.TabIndex = 1;
            this.nroHabitacion.ValidatingType = typeof(int);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Comodidades";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(128, 118);
            this.descripcion.Multiline = true;
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(114, 85);
            this.descripcion.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tipo de Habitación";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ubicación en el Hotel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nro de Habitación";
            // 
            // ModificarHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 383);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarHabitacion";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Habitación";
            this.TopMost = true;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox nroHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitado;
        private System.Windows.Forms.Label labelHa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox comodidades;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.ComboBox tipoHabitacion;
        private System.Windows.Forms.MaskedTextBox pisoHabitacion;
        private System.Windows.Forms.ComboBox ubicacionHotel;

    }
}