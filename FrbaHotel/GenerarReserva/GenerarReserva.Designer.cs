namespace FrbaHotel.GenerarReserva
{
    partial class GenerarReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarReserva));
            this.reservar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.fechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tipoRegimen = new System.Windows.Forms.ComboBox();
            this.resultados = new System.Windows.Forms.ListView();
            this.usuario1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.documento1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rol1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hotel1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seleccionar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.consultarDisponibilidad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reservar
            // 
            this.reservar.Location = new System.Drawing.Point(161, 335);
            this.reservar.Name = "reservar";
            this.reservar.Size = new System.Drawing.Size(75, 23);
            this.reservar.TabIndex = 5;
            this.reservar.Text = "Reservar";
            this.reservar.UseVisualStyleBackColor = true;
            this.reservar.Click += new System.EventHandler(this.reservar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.fechaHasta);
            this.groupBox2.Controls.Add(this.fechaDesde);
            this.groupBox2.Controls.Add(this.tipoRegimen);
            this.groupBox2.Controls.Add(this.tipoHabitacion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 128);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Reserva";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fecha hasta";
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.FormattingEnabled = true;
            this.tipoHabitacion.Items.AddRange(new object[] {
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
            this.tipoHabitacion.Location = new System.Drawing.Point(104, 70);
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.Size = new System.Drawing.Size(114, 21);
            this.tipoHabitacion.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Tipo de Habitación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha desde";
            // 
            // fechaDesde
            // 
            this.fechaDesde.Location = new System.Drawing.Point(104, 18);
            this.fechaDesde.Mask = "00/00/0000";
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(114, 20);
            this.fechaDesde.TabIndex = 7;
            this.fechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // fechaHasta
            // 
            this.fechaHasta.Location = new System.Drawing.Point(104, 44);
            this.fechaHasta.Mask = "00/00/0000";
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(114, 20);
            this.fechaHasta.TabIndex = 7;
            this.fechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tipo de Régimen";
            // 
            // tipoRegimen
            // 
            this.tipoRegimen.FormattingEnabled = true;
            this.tipoRegimen.Items.AddRange(new object[] {
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
            this.tipoRegimen.Location = new System.Drawing.Point(104, 97);
            this.tipoRegimen.Name = "tipoRegimen";
            this.tipoRegimen.Size = new System.Drawing.Size(114, 21);
            this.tipoRegimen.TabIndex = 4;
            // 
            // resultados
            // 
            this.resultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.usuario1,
            this.documento1,
            this.rol1,
            this.hotel1,
            this.seleccionar});
            this.resultados.Location = new System.Drawing.Point(12, 175);
            this.resultados.Name = "resultados";
            this.resultados.Size = new System.Drawing.Size(223, 154);
            this.resultados.TabIndex = 8;
            this.resultados.UseCompatibleStateImageBehavior = false;
            // 
            // usuario1
            // 
            this.usuario1.Text = "Usuario";
            // 
            // documento1
            // 
            this.documento1.DisplayIndex = 2;
            this.documento1.Text = "Documento";
            // 
            // rol1
            // 
            this.rol1.DisplayIndex = 3;
            this.rol1.Text = "Rol";
            // 
            // hotel1
            // 
            this.hotel1.DisplayIndex = 4;
            this.hotel1.Text = "Hotel";
            // 
            // seleccionar
            // 
            this.seleccionar.DisplayIndex = 1;
            this.seleccionar.Text = "";
            // 
            // consultarDisponibilidad
            // 
            this.consultarDisponibilidad.Location = new System.Drawing.Point(160, 146);
            this.consultarDisponibilidad.Name = "consultarDisponibilidad";
            this.consultarDisponibilidad.Size = new System.Drawing.Size(75, 23);
            this.consultarDisponibilidad.TabIndex = 6;
            this.consultarDisponibilidad.Text = "Consultar";
            this.consultarDisponibilidad.UseVisualStyleBackColor = true;
            this.consultarDisponibilidad.Click += new System.EventHandler(this.consultarDisponibilidad_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 368);
            this.Controls.Add(this.resultados);
            this.Controls.Add(this.consultarDisponibilidad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reservar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerarReserva";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Reserva";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reservar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipoHabitacion;
        private System.Windows.Forms.MaskedTextBox fechaHasta;
        private System.Windows.Forms.MaskedTextBox fechaDesde;
        private System.Windows.Forms.ComboBox tipoRegimen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView resultados;
        private System.Windows.Forms.ColumnHeader usuario1;
        private System.Windows.Forms.ColumnHeader documento1;
        private System.Windows.Forms.ColumnHeader rol1;
        private System.Windows.Forms.ColumnHeader hotel1;
        private System.Windows.Forms.ColumnHeader seleccionar;
        private System.Windows.Forms.Button consultarDisponibilidad;
        private System.Windows.Forms.Button button1;

    }
}