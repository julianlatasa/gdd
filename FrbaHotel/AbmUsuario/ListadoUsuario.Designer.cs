﻿namespace FrbaHotel.AbmUsuario
{
    partial class ListadoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoUsuario));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hotel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.resultados = new System.Windows.Forms.ListView();
            this.usuario1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.documento1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rol1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hotel1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seleccionar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hotel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rol);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.usuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // hotel
            // 
            this.hotel.FormattingEnabled = true;
            this.hotel.Location = new System.Drawing.Point(103, 70);
            this.hotel.Name = "hotel";
            this.hotel.Size = new System.Drawing.Size(114, 21);
            this.hotel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hotel";
            // 
            // rol
            // 
            this.rol.FormattingEnabled = true;
            this.rol.Location = new System.Drawing.Point(103, 43);
            this.rol.Name = "rol";
            this.rol.Size = new System.Drawing.Size(114, 21);
            this.rol.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rol";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(103, 19);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(114, 20);
            this.usuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(13, 120);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 1;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(161, 120);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 1;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // resultados
            // 
            this.resultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.usuario1,
            this.documento1,
            this.rol1,
            this.hotel1,
            this.seleccionar});
            this.resultados.Location = new System.Drawing.Point(13, 150);
            this.resultados.Name = "resultados";
            this.resultados.Size = new System.Drawing.Size(223, 154);
            this.resultados.TabIndex = 2;
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
            // ListadoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 314);
            this.Controls.Add(this.resultados);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoUsuario";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Roles";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ListadoUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.ListView resultados;
        private System.Windows.Forms.ColumnHeader usuario1;
        private System.Windows.Forms.ColumnHeader seleccionar;
        private System.Windows.Forms.ComboBox rol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox hotel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader documento1;
        private System.Windows.Forms.ColumnHeader rol1;
        private System.Windows.Forms.ColumnHeader hotel1;


    }
}