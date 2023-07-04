namespace ProyectoPuntoVenta
{
    partial class frmDevCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidproveedor = new System.Windows.Forms.TextBox();
            this.txtcantidad = new System.Windows.Forms.NumericUpDown();
            this.btnbuscarproducto = new System.Windows.Forms.Button();
            this.btnbuscarproveedor = new System.Windows.Forms.Button();
            this.cbotipodocumento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnumerodocumento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtpreciocompra = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnombreproducto = new System.Windows.Forms.TextBox();
            this.txtnombreproveedor = new System.Windows.Forms.TextBox();
            this.txtdocumentoproveedor = new System.Windows.Forms.TextBox();
            this.txtcodigoproducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblmontototal = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.txtidproducto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 573);
            this.label1.TabIndex = 30;
            // 
            // txtidproveedor
            // 
            this.txtidproveedor.Location = new System.Drawing.Point(187, 124);
            this.txtidproveedor.Name = "txtidproveedor";
            this.txtidproveedor.Size = new System.Drawing.Size(16, 20);
            this.txtidproveedor.TabIndex = 31;
            this.txtidproveedor.Text = "0";
            this.txtidproveedor.Visible = false;
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(16, 377);
            this.txtcantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtcantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(244, 20);
            this.txtcantidad.TabIndex = 50;
            this.txtcantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnbuscarproducto
            // 
            this.btnbuscarproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnbuscarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarproducto.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnbuscarproducto.Location = new System.Drawing.Point(223, 285);
            this.btnbuscarproducto.Name = "btnbuscarproducto";
            this.btnbuscarproducto.Size = new System.Drawing.Size(37, 21);
            this.btnbuscarproducto.TabIndex = 48;
            this.btnbuscarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarproducto.UseVisualStyleBackColor = false;
            this.btnbuscarproducto.Click += new System.EventHandler(this.btnbuscarproducto_Click);
            // 
            // btnbuscarproveedor
            // 
            this.btnbuscarproveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnbuscarproveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarproveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarproveedor.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnbuscarproveedor.Location = new System.Drawing.Point(223, 147);
            this.btnbuscarproveedor.Name = "btnbuscarproveedor";
            this.btnbuscarproveedor.Size = new System.Drawing.Size(37, 21);
            this.btnbuscarproveedor.TabIndex = 45;
            this.btnbuscarproveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarproveedor.UseVisualStyleBackColor = false;
            this.btnbuscarproveedor.Click += new System.EventHandler(this.btnbuscarproveedor_Click);
            // 
            // cbotipodocumento
            // 
            this.cbotipodocumento.BackColor = System.Drawing.Color.White;
            this.cbotipodocumento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbotipodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotipodocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotipodocumento.FormattingEnabled = true;
            this.cbotipodocumento.Location = new System.Drawing.Point(16, 56);
            this.cbotipodocumento.Name = "cbotipodocumento";
            this.cbotipodocumento.Size = new System.Drawing.Size(244, 23);
            this.cbotipodocumento.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 15);
            this.label8.TabIndex = 40;
            this.label8.Text = "Nombre Producto:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 15);
            this.label14.TabIndex = 39;
            this.label14.Text = "RUC / Documento Proveedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Codigo Producto:";
            // 
            // txtnumerodocumento
            // 
            this.txtnumerodocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumerodocumento.Location = new System.Drawing.Point(16, 102);
            this.txtnumerodocumento.Name = "txtnumerodocumento";
            this.txtnumerodocumento.Size = new System.Drawing.Size(244, 21);
            this.txtnumerodocumento.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 37;
            this.label6.Text = "Número Factura:";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprecioventa.Location = new System.Drawing.Point(16, 461);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(244, 21);
            this.txtprecioventa.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 484);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 15);
            this.label13.TabIndex = 35;
            this.label13.Text = "Observaciones";
            // 
            // txtpreciocompra
            // 
            this.txtpreciocompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpreciocompra.Location = new System.Drawing.Point(16, 419);
            this.txtpreciocompra.Name = "txtpreciocompra";
            this.txtpreciocompra.Size = new System.Drawing.Size(244, 21);
            this.txtpreciocompra.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 403);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 15);
            this.label12.TabIndex = 34;
            this.label12.Text = "Cantidad a devolver";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Cantidad Compradas";
            // 
            // txtnombreproducto
            // 
            this.txtnombreproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtnombreproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreproducto.Location = new System.Drawing.Point(16, 331);
            this.txtnombreproducto.Name = "txtnombreproducto";
            this.txtnombreproducto.ReadOnly = true;
            this.txtnombreproducto.Size = new System.Drawing.Size(244, 21);
            this.txtnombreproducto.TabIndex = 49;
            // 
            // txtnombreproveedor
            // 
            this.txtnombreproveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtnombreproveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreproveedor.Location = new System.Drawing.Point(16, 176);
            this.txtnombreproveedor.Name = "txtnombreproveedor";
            this.txtnombreproveedor.ReadOnly = true;
            this.txtnombreproveedor.Size = new System.Drawing.Size(244, 21);
            this.txtnombreproveedor.TabIndex = 46;
            // 
            // txtdocumentoproveedor
            // 
            this.txtdocumentoproveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtdocumentoproveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdocumentoproveedor.Location = new System.Drawing.Point(16, 147);
            this.txtdocumentoproveedor.Name = "txtdocumentoproveedor";
            this.txtdocumentoproveedor.ReadOnly = true;
            this.txtdocumentoproveedor.Size = new System.Drawing.Size(201, 21);
            this.txtdocumentoproveedor.TabIndex = 44;
            // 
            // txtcodigoproducto
            // 
            this.txtcodigoproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigoproducto.Location = new System.Drawing.Point(16, 285);
            this.txtcodigoproducto.Name = "txtcodigoproducto";
            this.txtcodigoproducto.Size = new System.Drawing.Size(201, 21);
            this.txtcodigoproducto.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "Tipo Documento:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "Devolucion en Compras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Detalle Producto";
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.Image = global::ProyectoPuntoVenta.Properties.Resources.add24;
            this.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnagregar.Location = new System.Drawing.Point(16, 528);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(244, 38);
            this.btnagregar.TabIndex = 53;
            this.btnagregar.Text = "Agregar producto";
            this.btnagregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::ProyectoPuntoVenta.Properties.Resources.check24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(1021, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 38);
            this.button1.TabIndex = 73;
            this.button1.Text = "Devolucion en  Compra";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblmontototal
            // 
            this.lblmontototal.AutoSize = true;
            this.lblmontototal.BackColor = System.Drawing.Color.White;
            this.lblmontototal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmontototal.Location = new System.Drawing.Point(1104, 498);
            this.lblmontototal.Name = "lblmontototal";
            this.lblmontototal.Size = new System.Drawing.Size(17, 17);
            this.lblmontototal.TabIndex = 67;
            this.lblmontototal.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(990, 498);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 17);
            this.label16.TabIndex = 68;
            this.label16.Text = "Monto Total:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(308, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(311, 20);
            this.label9.TabIndex = 69;
            this.label9.Text = "Resumen de de la devolución Compra";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(298, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(938, 455);
            this.label7.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(298, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(938, 62);
            this.label10.TabIndex = 72;
            // 
            // dgdata
            // 
            this.dgdata.AllowUserToAddRows = false;
            this.dgdata.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgdata.ColumnHeadersHeight = 30;
            this.dgdata.EnableHeadersVisualStyles = false;
            this.dgdata.GridColor = System.Drawing.Color.DimGray;
            this.dgdata.Location = new System.Drawing.Point(312, 94);
            this.dgdata.MultiSelect = false;
            this.dgdata.Name = "dgdata";
            this.dgdata.ReadOnly = true;
            this.dgdata.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgdata.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgdata.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgdata.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowTemplate.Height = 30;
            this.dgdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdata.Size = new System.Drawing.Size(914, 393);
            this.dgdata.TabIndex = 74;
            this.dgdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdata_CellContentClick);
            this.dgdata.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgdata_CellMouseClick);
            this.dgdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgdata_CellPainting);
            // 
            // txtidproducto
            // 
            this.txtidproducto.Location = new System.Drawing.Point(165, 259);
            this.txtidproducto.Name = "txtidproducto";
            this.txtidproducto.Size = new System.Drawing.Size(16, 20);
            this.txtidproducto.TabIndex = 75;
            this.txtidproducto.Text = "0";
            this.txtidproducto.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 76;
            this.button2.Text = "Ver Detalle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 503);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 21);
            this.textBox1.TabIndex = 77;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(15, 442);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 15);
            this.label17.TabIndex = 78;
            this.label17.Text = "Precio de compra:";
            // 
            // frmDevCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 573);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtidproducto);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblmontototal);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.txtidproveedor);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.btnbuscarproducto);
            this.Controls.Add(this.btnbuscarproveedor);
            this.Controls.Add(this.cbotipodocumento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnumerodocumento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtprecioventa);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtpreciocompra);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtnombreproducto);
            this.Controls.Add(this.txtnombreproveedor);
            this.Controls.Add(this.txtdocumentoproveedor);
            this.Controls.Add(this.txtcodigoproducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDevCompras";
            this.Text = "frmDevCompras";
            this.Load += new System.EventHandler(this.frmDevCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidproveedor;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.Button btnbuscarproducto;
        private System.Windows.Forms.Button btnbuscarproveedor;
        private System.Windows.Forms.ComboBox cbotipodocumento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnumerodocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtpreciocompra;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnombreproducto;
        private System.Windows.Forms.TextBox txtnombreproveedor;
        private System.Windows.Forms.TextBox txtdocumentoproveedor;
        private System.Windows.Forms.TextBox txtcodigoproducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblmontototal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgdata;
        private System.Windows.Forms.TextBox txtidproducto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label17;
    }
}