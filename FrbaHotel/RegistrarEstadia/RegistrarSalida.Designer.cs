namespace FrbaHotel.RegistrarEstadia
{
    partial class RegistrarSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarSalida));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nroHabitacion = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codReserva = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkOut = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nroHabitacion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.codReserva);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // nroHabitacion
            // 
            this.nroHabitacion.Location = new System.Drawing.Point(103, 45);
            this.nroHabitacion.Mask = "99999999";
            this.nroHabitacion.Name = "nroHabitacion";
            this.nroHabitacion.Size = new System.Drawing.Size(114, 20);
            this.nroHabitacion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nro. Habitación";
            // 
            // codReserva
            // 
            this.codReserva.Location = new System.Drawing.Point(103, 19);
            this.codReserva.Mask = "99999999";
            this.codReserva.Name = "codReserva";
            this.codReserva.Size = new System.Drawing.Size(114, 20);
            this.codReserva.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód. Reserva";
            // 
            // checkOut
            // 
            this.checkOut.Location = new System.Drawing.Point(160, 93);
            this.checkOut.Name = "checkOut";
            this.checkOut.Size = new System.Drawing.Size(75, 23);
            this.checkOut.TabIndex = 4;
            this.checkOut.Text = "Check-out";
            this.checkOut.UseVisualStyleBackColor = true;
            this.checkOut.Click += new System.EventHandler(this.checkOut_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(13, 93);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 3;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // RegistrarSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 123);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.checkOut);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarSalida";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Salida";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox codReserva;
        private System.Windows.Forms.MaskedTextBox nroHabitacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button checkOut;
        private System.Windows.Forms.Button limpiar;


    }
}