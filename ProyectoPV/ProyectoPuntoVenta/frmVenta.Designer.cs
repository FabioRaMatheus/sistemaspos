namespace ProyectoPuntoVenta
{
    partial class frmVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnombreproducto = new System.Windows.Forms.TextBox();
            this.txtnombrecliente = new System.Windows.Forms.TextBox();
            this.txtidproveedor = new System.Windows.Forms.TextBox();
            this.txtcodigoproducto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txttotalpagar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtpagocon = new System.Windows.Forms.TextBox();
            this.txtcambio = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbotipodocumento = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtidcliente = new System.Windows.Forms.TextBox();
            this.txtidproducto = new System.Windows.Forms.TextBox();
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.btnbuscarproducto = new System.Windows.Forms.Button();
            this.btnbuscarcliente = new System.Windows.Forms.Button();
            this.btnagregarproducto = new System.Windows.Forms.Button();
            this.btnterminarventa = new System.Windows.Forms.Button();
            this.btncalcular = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nombre Producto:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Nombre Completo:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Número Documento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(315, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Resumen de Venta";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(302, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(952, 360);
            this.label7.TabIndex = 73;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 296);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Precio Venta:";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtprecioventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprecioventa.Location = new System.Drawing.Point(21, 314);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.ReadOnly = true;
            this.txtprecioventa.Size = new System.Drawing.Size(244, 21);
            this.txtprecioventa.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cantidad:";
            // 
            // txtnombreproducto
            // 
            this.txtnombreproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtnombreproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreproducto.Location = new System.Drawing.Point(21, 269);
            this.txtnombreproducto.Name = "txtnombreproducto";
            this.txtnombreproducto.ReadOnly = true;
            this.txtnombreproducto.Size = new System.Drawing.Size(244, 21);
            this.txtnombreproducto.TabIndex = 4;
            // 
            // txtnombrecliente
            // 
            this.txtnombrecliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrecliente.Location = new System.Drawing.Point(21, 109);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.Size = new System.Drawing.Size(244, 21);
            this.txtnombrecliente.TabIndex = 2;
            // 
            // txtidproveedor
            // 
            this.txtidproveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidproveedor.Location = new System.Drawing.Point(21, 64);
            this.txtidproveedor.Name = "txtidproveedor";
            this.txtidproveedor.Size = new System.Drawing.Size(201, 21);
            this.txtidproveedor.TabIndex = 1;
            // 
            // txtcodigoproducto
            // 
            this.txtcodigoproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigoproducto.Location = new System.Drawing.Point(21, 223);
            this.txtcodigoproducto.Name = "txtcodigoproducto";
            this.txtcodigoproducto.Size = new System.Drawing.Size(201, 21);
            this.txtcodigoproducto.TabIndex = 3;
            this.txtcodigoproducto.TextChanged += new System.EventHandler(this.txtcodigoproducto_TextChanged);
            this.txtcodigoproducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigoproducto_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Detalle Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detalle Producto";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 589);
            this.label1.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(302, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(952, 42);
            this.label10.TabIndex = 74;
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(21, 359);
            this.txtcantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(244, 20);
            this.txtcantidad.TabIndex = 6;
            this.txtcantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(306, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(952, 143);
            this.label4.TabIndex = 74;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(310, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total a Pagar:";
            // 
            // txttotalpagar
            // 
            this.txttotalpagar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txttotalpagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalpagar.Location = new System.Drawing.Point(396, 445);
            this.txttotalpagar.Name = "txttotalpagar";
            this.txttotalpagar.ReadOnly = true;
            this.txttotalpagar.Size = new System.Drawing.Size(225, 68);
            this.txttotalpagar.TabIndex = 9;
            this.txttotalpagar.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(635, 464);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Paga con:";
            // 
            // txtpagocon
            // 
            this.txtpagocon.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpagocon.Location = new System.Drawing.Point(707, 446);
            this.txtpagocon.Name = "txtpagocon";
            this.txtpagocon.Size = new System.Drawing.Size(215, 68);
            this.txtpagocon.TabIndex = 10;
            this.txtpagocon.Text = "0";
            this.txtpagocon.TextChanged += new System.EventHandler(this.btncalcular_Click);
            this.txtpagocon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpagocon_KeyPress);
            this.txtpagocon.Leave += new System.EventHandler(this.txtpagocon_Leave);
            // 
            // txtcambio
            // 
            this.txtcambio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtcambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcambio.Location = new System.Drawing.Point(1000, 444);
            this.txtcambio.Name = "txtcambio";
            this.txtcambio.ReadOnly = true;
            this.txtcambio.Size = new System.Drawing.Size(212, 68);
            this.txtcambio.TabIndex = 12;
            this.txtcambio.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(928, 464);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Cambio:";
            // 
            // cbotipodocumento
            // 
            this.cbotipodocumento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbotipodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotipodocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotipodocumento.FormattingEnabled = true;
            this.cbotipodocumento.Location = new System.Drawing.Point(1056, 25);
            this.cbotipodocumento.Name = "cbotipodocumento";
            this.cbotipodocumento.Size = new System.Drawing.Size(188, 23);
            this.cbotipodocumento.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(949, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "Tipo Documento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo Producto:";
            // 
            // txtidcliente
            // 
            this.txtidcliente.Location = new System.Drawing.Point(206, 37);
            this.txtidcliente.Name = "txtidcliente";
            this.txtidcliente.Size = new System.Drawing.Size(16, 20);
            this.txtidcliente.TabIndex = 0;
            this.txtidcliente.Text = "0";
            this.txtidcliente.Visible = false;
            // 
            // txtidproducto
            // 
            this.txtidproducto.Location = new System.Drawing.Point(206, 197);
            this.txtidproducto.Name = "txtidproducto";
            this.txtidproducto.Size = new System.Drawing.Size(16, 20);
            this.txtidproducto.TabIndex = 0;
            this.txtidproducto.Text = "0";
            this.txtidproducto.Visible = false;
            // 
            // dgdata
            // 
            this.dgdata.AllowUserToAddRows = false;
            this.dgdata.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgdata.ColumnHeadersHeight = 30;
            this.dgdata.EnableHeadersVisualStyles = false;
            this.dgdata.GridColor = System.Drawing.Color.DimGray;
            this.dgdata.Location = new System.Drawing.Point(316, 82);
            this.dgdata.MultiSelect = false;
            this.dgdata.Name = "dgdata";
            this.dgdata.ReadOnly = true;
            this.dgdata.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgdata.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgdata.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgdata.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowTemplate.Height = 30;
            this.dgdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdata.Size = new System.Drawing.Size(925, 333);
            this.dgdata.TabIndex = 85;
            this.dgdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdata_CellContentClick);
            this.dgdata.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdata_CellMouseEnter);
            this.dgdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgdata_CellPainting);
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(184, 197);
            this.txtstock.Name = "txtstock";
            this.txtstock.Size = new System.Drawing.Size(16, 20);
            this.txtstock.TabIndex = 0;
            this.txtstock.Text = "0";
            this.txtstock.Visible = false;
            // 
            // btnbuscarproducto
            // 
            this.btnbuscarproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnbuscarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarproducto.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnbuscarproducto.Location = new System.Drawing.Point(228, 223);
            this.btnbuscarproducto.Name = "btnbuscarproducto";
            this.btnbuscarproducto.Size = new System.Drawing.Size(37, 21);
            this.btnbuscarproducto.TabIndex = 83;
            this.btnbuscarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarproducto.UseVisualStyleBackColor = false;
            this.btnbuscarproducto.Click += new System.EventHandler(this.btnbuscarproducto_Click);
            // 
            // btnbuscarcliente
            // 
            this.btnbuscarcliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnbuscarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcliente.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnbuscarcliente.Location = new System.Drawing.Point(228, 64);
            this.btnbuscarcliente.Name = "btnbuscarcliente";
            this.btnbuscarcliente.Size = new System.Drawing.Size(37, 21);
            this.btnbuscarcliente.TabIndex = 82;
            this.btnbuscarcliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarcliente.UseVisualStyleBackColor = false;
            this.btnbuscarcliente.Click += new System.EventHandler(this.btnbuscarcliente_Click);
            // 
            // btnagregarproducto
            // 
            this.btnagregarproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnagregarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregarproducto.Image = global::ProyectoPuntoVenta.Properties.Resources.add24;
            this.btnagregarproducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnagregarproducto.Location = new System.Drawing.Point(21, 437);
            this.btnagregarproducto.Name = "btnagregarproducto";
            this.btnagregarproducto.Size = new System.Drawing.Size(244, 38);
            this.btnagregarproducto.TabIndex = 7;
            this.btnagregarproducto.Text = "Agregar producto";
            this.btnagregarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnagregarproducto.UseVisualStyleBackColor = false;
            this.btnagregarproducto.Click += new System.EventHandler(this.btnagregarproducto_Click);
            // 
            // btnterminarventa
            // 
            this.btnterminarventa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnterminarventa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnterminarventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnterminarventa.Image = global::ProyectoPuntoVenta.Properties.Resources.check24;
            this.btnterminarventa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnterminarventa.Location = new System.Drawing.Point(1103, 530);
            this.btnterminarventa.Name = "btnterminarventa";
            this.btnterminarventa.Size = new System.Drawing.Size(141, 38);
            this.btnterminarventa.TabIndex = 13;
            this.btnterminarventa.Text = "Terminar &Venta";
            this.btnterminarventa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnterminarventa.UseVisualStyleBackColor = false;
            this.btnterminarventa.Click += new System.EventHandler(this.btnterminarventa_Click);
            // 
            // btncalcular
            // 
            this.btncalcular.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btncalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncalcular.Location = new System.Drawing.Point(824, 538);
            this.btncalcular.Name = "btncalcular";
            this.btncalcular.Size = new System.Drawing.Size(139, 23);
            this.btncalcular.TabIndex = 11;
            this.btncalcular.Text = "Procesar &XPago";
            this.btncalcular.UseVisualStyleBackColor = false;
            this.btncalcular.Click += new System.EventHandler(this.btncalcular_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 402);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 86;
            this.label18.Text = "Peso(lib)";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Orange;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(695, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 33);
            this.textBox1.TabIndex = 87;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(560, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 17);
            this.label19.TabIndex = 88;
            this.label19.Text = "Cupo de Credito:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(227, 402);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(38, 20);
            this.textBox2.TabIndex = 89;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(314, 545);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(213, 25);
            this.label20.TabIndex = 90;
            this.label20.Text = "Alt + x : procesar pago ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(533, 546);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(217, 25);
            this.label21.TabIndex = 91;
            this.label21.Text = "Alt + v : procesar venta ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(18, 508);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(119, 15);
            this.label22.TabIndex = 92;
            this.label22.Text = "Número Devolución:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(21, 530);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(179, 20);
            this.textBox3.TabIndex = 93;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 21);
            this.button1.TabIndex = 94;
            this.button1.Text = "&Devolucion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(20, 556);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(38, 15);
            this.label23.TabIndex = 95;
            this.label23.Text = "Valor:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Yellow;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Red;
            this.textBox4.Location = new System.Drawing.Point(69, 555);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(179, 26);
            this.textBox4.TabIndex = 96;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(314, 515);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(262, 25);
            this.label24.TabIndex = 97;
            this.label24.Text = "Alt + d : procesar Devolución";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(155, 502);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 98;
            this.textBox5.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(161, 156);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(61, 20);
            this.textBox6.TabIndex = 99;
            this.textBox6.Visible = false;
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(94, 156);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(61, 20);
            this.txtIva.TabIndex = 100;
            this.txtIva.Visible = false;
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1283, 589);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btncalcular);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.txtstock);
            this.Controls.Add(this.txtidproducto);
            this.Controls.Add(this.txtidcliente);
            this.Controls.Add(this.btnbuscarproducto);
            this.Controls.Add(this.btnbuscarcliente);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbotipodocumento);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnagregarproducto);
            this.Controls.Add(this.btnterminarventa);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtprecioventa);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtcambio);
            this.Controls.Add(this.txtnombreproducto);
            this.Controls.Add(this.txtpagocon);
            this.Controls.Add(this.txttotalpagar);
            this.Controls.Add(this.txtnombrecliente);
            this.Controls.Add(this.txtidproveedor);
            this.Controls.Add(this.txtcodigoproducto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Name = "frmVenta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.frmVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVenta_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmVenta_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmVenta_KeyUp);
            this.Resize += new System.EventHandler(this.frmVenta_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnagregarproducto;
        private System.Windows.Forms.Button btnterminarventa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnombreproducto;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.TextBox txtidproveedor;
        private System.Windows.Forms.TextBox txtcodigoproducto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttotalpagar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtpagocon;
        private System.Windows.Forms.TextBox txtcambio;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbotipodocumento;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnbuscarcliente;
        private System.Windows.Forms.Button btnbuscarproducto;
        private System.Windows.Forms.TextBox txtidcliente;
        private System.Windows.Forms.TextBox txtidproducto;
        private System.Windows.Forms.DataGridView dgdata;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Button btncalcular;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtIva;
    }
}