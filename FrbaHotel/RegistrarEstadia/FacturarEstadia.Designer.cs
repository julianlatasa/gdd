namespace FrbaHotel.RegistrarEstadia
{
    partial class FacturarEstadia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturarEstadia));
            this.label1 = new System.Windows.Forms.Label();
            this.nro = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.codReserva2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.lineas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro";
            // 
            // nro
            // 
            this.nro.Location = new System.Drawing.Point(102, 9);
            this.nro.Name = "nro";
            this.nro.Size = new System.Drawing.Size(88, 13);
            this.nro.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cod. Reserva";
            // 
            // codReserva2
            // 
            this.codReserva2.Location = new System.Drawing.Point(102, 31);
            this.codReserva2.Name = "codReserva2";
            this.codReserva2.Size = new System.Drawing.Size(88, 13);
            this.codReserva2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(196, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(196, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total";
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(244, 9);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(75, 13);
            this.fecha.TabIndex = 0;
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(244, 31);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(75, 13);
            this.total.TabIndex = 0;
            // 
            // lineas
            // 
            this.lineas.FormattingEnabled = true;
            this.lineas.Location = new System.Drawing.Point(15, 55);
            this.lineas.Name = "lineas";
            this.lineas.Size = new System.Drawing.Size(304, 199);
            this.lineas.TabIndex = 1;
            // 
            // FacturarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 270);
            this.Controls.Add(this.lineas);
            this.Controls.Add(this.total);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.codReserva2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nro);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacturarEstadia";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación Estadía";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FacturarEstadia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label codReserva2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.ListBox lineas;



    }
}