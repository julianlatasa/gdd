namespace FrbaHotel.RegistrarConsumible
{
    partial class RegistrarConsumible
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarConsumible));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.consumible = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cantidad = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codReserva = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.consumible);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cantidad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.codReserva);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Consumible";
            // 
            // consumible
            // 
            this.consumible.FormattingEnabled = true;
            this.consumible.Location = new System.Drawing.Point(103, 48);
            this.consumible.Name = "consumible";
            this.consumible.Size = new System.Drawing.Size(114, 21);
            this.consumible.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Consumible";
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(103, 75);
            this.cantidad.Mask = "99999999";
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(114, 20);
            this.cantidad.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cantidad";
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
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(161, 129);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(75, 23);
            this.confirmar.TabIndex = 4;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(14, 129);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // RegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 161);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.confirmar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarConsumible";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Consumible";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RegistrarConsumible_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox codReserva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.ComboBox consumible;
        private System.Windows.Forms.MaskedTextBox cantidad;
        private System.Windows.Forms.Label label3;


    }
}