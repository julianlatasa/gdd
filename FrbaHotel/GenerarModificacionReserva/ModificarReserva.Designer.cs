namespace FrbaHotel.GenerarModificacionReserva
{
    partial class ModificarReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarReserva));
            this.reservar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nroHabitaciones = new System.Windows.Forms.MaskedTextBox();
            this.nroPersonas = new System.Windows.Forms.MaskedTextBox();
            this.duracion = new System.Windows.Forms.MaskedTextBox();
            this.fechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.tipoRegimen = new System.Windows.Forms.ComboBox();
            this.hotel = new System.Windows.Forms.ComboBox();
            this.tipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultados = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.consultarDisponibilidad = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reservar
            // 
            this.reservar.Location = new System.Drawing.Point(161, 413);
            this.reservar.Name = "reservar";
            this.reservar.Size = new System.Drawing.Size(75, 23);
            this.reservar.TabIndex = 5;
            this.reservar.Text = "Modificar";
            this.reservar.UseVisualStyleBackColor = true;
            this.reservar.Click += new System.EventHandler(this.reservar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nroHabitaciones);
            this.groupBox2.Controls.Add(this.nroPersonas);
            this.groupBox2.Controls.Add(this.duracion);
            this.groupBox2.Controls.Add(this.fechaDesde);
            this.groupBox2.Controls.Add(this.tipoRegimen);
            this.groupBox2.Controls.Add(this.hotel);
            this.groupBox2.Controls.Add(this.tipoHabitacion);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 206);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Duración";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fecha desde";
            // 
            // nroHabitaciones
            // 
            this.nroHabitaciones.Location = new System.Drawing.Point(104, 177);
            this.nroHabitaciones.Mask = "99999";
            this.nroHabitaciones.Name = "nroHabitaciones";
            this.nroHabitaciones.Size = new System.Drawing.Size(114, 20);
            this.nroHabitaciones.TabIndex = 7;
            this.nroHabitaciones.ValidatingType = typeof(int);
            // 
            // nroPersonas
            // 
            this.nroPersonas.Location = new System.Drawing.Point(104, 150);
            this.nroPersonas.Mask = "99999";
            this.nroPersonas.Name = "nroPersonas";
            this.nroPersonas.Size = new System.Drawing.Size(114, 20);
            this.nroPersonas.TabIndex = 6;
            this.nroPersonas.ValidatingType = typeof(int);
            // 
            // duracion
            // 
            this.duracion.Location = new System.Drawing.Point(104, 70);
            this.duracion.Mask = "99999";
            this.duracion.Name = "duracion";
            this.duracion.Size = new System.Drawing.Size(114, 20);
            this.duracion.TabIndex = 3;
            this.duracion.ValidatingType = typeof(int);
            // 
            // fechaDesde
            // 
            this.fechaDesde.Location = new System.Drawing.Point(104, 44);
            this.fechaDesde.Mask = "00/00/0000";
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(114, 20);
            this.fechaDesde.TabIndex = 2;
            this.fechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // tipoRegimen
            // 
            this.tipoRegimen.FormattingEnabled = true;
            this.tipoRegimen.Location = new System.Drawing.Point(104, 123);
            this.tipoRegimen.Name = "tipoRegimen";
            this.tipoRegimen.Size = new System.Drawing.Size(114, 21);
            this.tipoRegimen.TabIndex = 5;
            // 
            // hotel
            // 
            this.hotel.FormattingEnabled = true;
            this.hotel.Location = new System.Drawing.Point(104, 17);
            this.hotel.Name = "hotel";
            this.hotel.Size = new System.Drawing.Size(114, 21);
            this.hotel.TabIndex = 1;
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.FormattingEnabled = true;
            this.tipoHabitacion.Location = new System.Drawing.Point(104, 96);
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.Size = new System.Drawing.Size(114, 21);
            this.tipoHabitacion.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nro. Habitaciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nro. de Personas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tipo de Régimen";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 99);
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
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hotel";
            // 
            // resultados
            // 
            this.resultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.resultados.Location = new System.Drawing.Point(13, 253);
            this.resultados.MultiSelect = false;
            this.resultados.Name = "resultados";
            this.resultados.Size = new System.Drawing.Size(223, 154);
            this.resultados.View = System.Windows.Forms.View.Details;
            this.resultados.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.resultados.TabIndex = 8;
            this.resultados.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Regimen";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Precio";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Disponibles";
            // 
            // consultarDisponibilidad
            // 
            this.consultarDisponibilidad.Location = new System.Drawing.Point(161, 224);
            this.consultarDisponibilidad.Name = "consultarDisponibilidad";
            this.consultarDisponibilidad.Size = new System.Drawing.Size(75, 23);
            this.consultarDisponibilidad.TabIndex = 8;
            this.consultarDisponibilidad.Text = "Consultar";
            this.consultarDisponibilidad.UseVisualStyleBackColor = true;
            this.consultarDisponibilidad.Click += new System.EventHandler(this.consultarDisponibilidad_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(13, 224);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 9;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(12, 413);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 5;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // ModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 443);
            this.Controls.Add(this.resultados);
            this.Controls.Add(this.consultarDisponibilidad);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.reservar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarReserva";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Reserva";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ModificarReserva_Load);
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
        private System.Windows.Forms.MaskedTextBox fechaDesde;
        private System.Windows.Forms.ComboBox tipoRegimen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView resultados;
        private System.Windows.Forms.Button consultarDisponibilidad;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox nroPersonas;
        private System.Windows.Forms.MaskedTextBox duracion;
        private System.Windows.Forms.ComboBox hotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox nroHabitaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;

    }
}