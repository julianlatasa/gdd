namespace FrbaHotel.RegistrarEstadia
{
    partial class ElegirFormaDePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElegirFormaDePago));
            this.seleccionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.formaDePago = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // seleccionar
            // 
            this.seleccionar.Location = new System.Drawing.Point(128, 39);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(108, 23);
            this.seleccionar.TabIndex = 5;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Forma de Pago";
            // 
            // formaDePago
            // 
            this.formaDePago.FormattingEnabled = true;
            this.formaDePago.Location = new System.Drawing.Point(97, 11);
            this.formaDePago.Name = "formaDePago";
            this.formaDePago.Size = new System.Drawing.Size(138, 21);
            this.formaDePago.TabIndex = 7;
            // 
            // ElegirFormaDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 70);
            this.Controls.Add(this.formaDePago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seleccionar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ElegirFormaDePago";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elegir Forma de Pago";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ElegirFormaDePago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox formaDePago;


    }
}