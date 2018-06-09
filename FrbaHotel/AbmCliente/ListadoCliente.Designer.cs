namespace FrbaHotel.AbmCliente
{
    partial class ListadoCliente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoCliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nroIdentificacion = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.result_busq = new System.Windows.Forms.DataGridView();
            this.gD1C2018DataSet = new FrbaHotel.GD1C2018DataSet();
            this.cLIENTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cLIENTETableAdapter = new FrbaHotel.GD1C2018DataSetTableAdapters.CLIENTETableAdapter();
            this.modificar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result_busq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2018DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLIENTEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nroIdentificacion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tipoIdentificacion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.apellido);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // nroIdentificacion
            // 
            this.nroIdentificacion.Location = new System.Drawing.Point(103, 99);
            this.nroIdentificacion.Mask = "99999999";
            this.nroIdentificacion.Name = "nroIdentificacion";
            this.nroIdentificacion.Size = new System.Drawing.Size(137, 20);
            this.nroIdentificacion.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nro. identificación";
            // 
            // tipoIdentificacion
            // 
            this.tipoIdentificacion.FormattingEnabled = true;
            this.tipoIdentificacion.Location = new System.Drawing.Point(103, 71);
            this.tipoIdentificacion.Name = "tipoIdentificacion";
            this.tipoIdentificacion.Size = new System.Drawing.Size(137, 21);
            this.tipoIdentificacion.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo identificación";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(103, 125);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(137, 20);
            this.email.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "E-mail";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(103, 45);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(137, 20);
            this.apellido.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Apellido";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(103, 19);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(137, 20);
            this.nombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(13, 172);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 1;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(178, 173);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 1;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // result_busq
            // 
            this.result_busq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_busq.Location = new System.Drawing.Point(12, 202);
            this.result_busq.Name = "result_busq";
            this.result_busq.Size = new System.Drawing.Size(241, 150);
            this.result_busq.TabIndex = 3;
            this.result_busq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.result_busq_CellContentClick);
            // 
            // gD1C2018DataSet
            // 
            this.gD1C2018DataSet.DataSetName = "GD1C2018DataSet";
            this.gD1C2018DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cLIENTEBindingSource
            // 
            this.cLIENTEBindingSource.DataMember = "CLIENTE";
            this.cLIENTEBindingSource.DataSource = this.gD1C2018DataSet;
            // 
            // cLIENTETableAdapter
            // 
            this.cLIENTETableAdapter.ClearBeforeFill = true;
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(178, 370);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(75, 23);
            this.modificar.TabIndex = 4;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(12, 370);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Eliminar.TabIndex = 5;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click_1);
            // 
            // ListadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 405);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.result_busq);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoCliente";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Clientes";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ListadoCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result_busq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2018DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLIENTEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.ComboBox tipoIdentificacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox nroIdentificacion;
        private System.Windows.Forms.DataGridView result_busq;
        private GD1C2018DataSet gD1C2018DataSet;
        private System.Windows.Forms.BindingSource cLIENTEBindingSource;
        private GD1C2018DataSetTableAdapters.CLIENTETableAdapter cLIENTETableAdapter;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button Eliminar;


    }
}