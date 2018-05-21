namespace FrbaHotel.GenerarReserva
{
    partial class ModalCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModalCliente));
            this.registrado = new System.Windows.Forms.Button();
            this.sinRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registrado
            // 
            this.registrado.Location = new System.Drawing.Point(69, 12);
            this.registrado.Name = "registrado";
            this.registrado.Size = new System.Drawing.Size(110, 38);
            this.registrado.TabIndex = 5;
            this.registrado.Text = "Registrado";
            this.registrado.UseVisualStyleBackColor = true;
            this.registrado.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // sinRegistrar
            // 
            this.sinRegistrar.Location = new System.Drawing.Point(69, 56);
            this.sinRegistrar.Name = "sinRegistrar";
            this.sinRegistrar.Size = new System.Drawing.Size(110, 38);
            this.sinRegistrar.TabIndex = 5;
            this.sinRegistrar.Text = "Sin Registrar";
            this.sinRegistrar.UseVisualStyleBackColor = true;
            this.sinRegistrar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // ModalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 111);
            this.Controls.Add(this.sinRegistrar);
            this.Controls.Add(this.registrado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalCliente";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ModalCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button registrado;
        private System.Windows.Forms.Button sinRegistrar;

    }
}