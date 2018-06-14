namespace FrbaHotel.ListadoEstadistico
{
    partial class Estadistico3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estadistico3));
            this.resultados = new System.Windows.Forms.ListView();
            this.Hotel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // resultados
            // 
            this.resultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Hotel,
            this.Cantidad});
            this.resultados.Enabled = false;
            this.resultados.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.resultados.Location = new System.Drawing.Point(13, 13);
            this.resultados.MultiSelect = false;
            this.resultados.Name = "resultados";
            this.resultados.Size = new System.Drawing.Size(248, 284);
            this.resultados.TabIndex = 0;
            this.resultados.UseCompatibleStateImageBehavior = false;
            this.resultados.View = System.Windows.Forms.View.Details;
            // 
            // Hotel
            // 
            this.Hotel.Text = "Hotel";
            this.Hotel.Width = 155;
            // 
            // Cantidad
            // 
            this.Cantidad.Text = "Cantidad";
            // 
            // Estadistico3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 309);
            this.Controls.Add(this.resultados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Estadistico3";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadístico";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView resultados;
        private System.Windows.Forms.ColumnHeader Hotel;
        private System.Windows.Forms.ColumnHeader Cantidad;




    }
}