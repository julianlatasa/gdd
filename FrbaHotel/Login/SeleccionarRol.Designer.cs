namespace FrbaHotel
{
    partial class SeleccionarRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarRol));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaRoles = new System.Windows.Forms.ListView();
            this.seleccionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaRoles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Rol";
            // 
            // listaRoles
            // 
            this.listaRoles.Location = new System.Drawing.Point(7, 20);
            this.listaRoles.MultiSelect = false;
            this.listaRoles.Name = "listaRoles";
            this.listaRoles.Size = new System.Drawing.Size(211, 211);
            this.listaRoles.TabIndex = 0;
            this.listaRoles.UseCompatibleStateImageBehavior = false;
            // 
            // seleccionar
            // 
            this.seleccionar.Location = new System.Drawing.Point(161, 255);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(75, 23);
            this.seleccionar.TabIndex = 5;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // SeleccionarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 290);
            this.Controls.Add(this.seleccionar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarRol";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Rol";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SeleccionarRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.ListView listaRoles;

    }
}