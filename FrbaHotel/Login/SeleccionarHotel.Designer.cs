namespace FrbaHotel
{
    partial class SeleccionarHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarHotel));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaHoteles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaHoteles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Hotel";
            // 
            // listaHoteles
            // 
            this.listaHoteles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listaHoteles.FullRowSelect = true;
            this.listaHoteles.GridLines = true;
            this.listaHoteles.Location = new System.Drawing.Point(7, 20);
            this.listaHoteles.MultiSelect = false;
            this.listaHoteles.Name = "listaHoteles";
            this.listaHoteles.Size = new System.Drawing.Size(211, 211);
            this.listaHoteles.TabIndex = 0;
            this.listaHoteles.UseCompatibleStateImageBehavior = false;
            this.listaHoteles.View = System.Windows.Forms.View.Tile;
            this.listaHoteles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listaHoteles_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hotel";
            // 
            // SeleccionarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 257);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarHotel";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Hotel";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.SeleccionarHotel_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listaHoteles;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}