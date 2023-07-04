namespace ProyectoPuntoVenta
{
    partial class frmConta
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtfechafin = new System.Windows.Forms.DateTimePicker();
            this.txtfechainicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnconsultarventa = new System.Windows.Forms.Button();
            this.dgdatacartera = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnexportarcompras = new System.Windows.Forms.Button();
            this.dgdataproducto = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dtElectronica = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.FechaFinal = new System.Windows.Forms.DateTimePicker();
            this.fechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdatacartera)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdataproducto)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtElectronica)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::ProyectoPuntoVenta.Properties.Resources.gastospng;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 69);
            this.button1.TabIndex = 0;
            this.button1.Tag = "Gastos";
            this.button1.Text = "Gastos";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::ProyectoPuntoVenta.Properties.Resources.gastos;
            this.button2.Location = new System.Drawing.Point(73, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 69);
            this.button2.TabIndex = 1;
            this.button2.Tag = "Ingresos";
            this.button2.Text = "Ingresos";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 77);
            this.panel1.TabIndex = 2;
            // 
            // button8
            // 
            this.button8.Image = global::ProyectoPuntoVenta.Properties.Resources.factura;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button8.Location = new System.Drawing.Point(361, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(73, 69);
            this.button8.TabIndex = 5;
            this.button8.Text = "Factura";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.Image = global::ProyectoPuntoVenta.Properties.Resources.devol;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(287, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(73, 69);
            this.button5.TabIndex = 4;
            this.button5.Text = "Devolucion";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = global::ProyectoPuntoVenta.Properties.Resources.stock;
            this.button4.Location = new System.Drawing.Point(216, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 69);
            this.button4.TabIndex = 3;
            this.button4.Text = "Inventario";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::ProyectoPuntoVenta.Properties.Resources.pagos;
            this.button3.Location = new System.Drawing.Point(142, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 69);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cartera";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtfechafin);
            this.panel2.Controls.Add(this.txtfechainicio);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnconsultarventa);
            this.panel2.Controls.Add(this.dgdatacartera);
            this.panel2.Location = new System.Drawing.Point(13, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 440);
            this.panel2.TabIndex = 5;
            // 
            // txtfechafin
            // 
            this.txtfechafin.CustomFormat = "dd/MM/yyyy";
            this.txtfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechafin.Location = new System.Drawing.Point(405, 13);
            this.txtfechafin.Name = "txtfechafin";
            this.txtfechafin.Size = new System.Drawing.Size(187, 20);
            this.txtfechafin.TabIndex = 47;
            // 
            // txtfechainicio
            // 
            this.txtfechainicio.CustomFormat = "dd/MM/yyyy";
            this.txtfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechainicio.Location = new System.Drawing.Point(117, 13);
            this.txtfechainicio.Name = "txtfechainicio";
            this.txtfechainicio.Size = new System.Drawing.Size(187, 20);
            this.txtfechainicio.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Fecha Fin:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 46;
            this.label9.Text = "Fecha Inicio:";
            // 
            // btnconsultarventa
            // 
            this.btnconsultarventa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnconsultarventa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconsultarventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconsultarventa.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnconsultarventa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnconsultarventa.Location = new System.Drawing.Point(621, 11);
            this.btnconsultarventa.Name = "btnconsultarventa";
            this.btnconsultarventa.Size = new System.Drawing.Size(134, 25);
            this.btnconsultarventa.TabIndex = 44;
            this.btnconsultarventa.Text = "Consultar";
            this.btnconsultarventa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnconsultarventa.UseVisualStyleBackColor = false;
            this.btnconsultarventa.Click += new System.EventHandler(this.btnconsultarventa_Click);
            // 
            // dgdatacartera
            // 
            this.dgdatacartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdatacartera.Location = new System.Drawing.Point(14, 68);
            this.dgdatacartera.Name = "dgdatacartera";
            this.dgdatacartera.Size = new System.Drawing.Size(1105, 367);
            this.dgdatacartera.TabIndex = 0;
            this.dgdatacartera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdatacartera_CellClick);
            this.dgdatacartera.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgdatacartera_RowPostPaint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnexportarcompras);
            this.panel3.Controls.Add(this.dgdataproducto);
            this.panel3.Location = new System.Drawing.Point(14, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1131, 446);
            this.panel3.TabIndex = 6;
            // 
            // btnexportarcompras
            // 
            this.btnexportarcompras.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnexportarcompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportarcompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportarcompras.Image = global::ProyectoPuntoVenta.Properties.Resources.excel;
            this.btnexportarcompras.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexportarcompras.Location = new System.Drawing.Point(456, 399);
            this.btnexportarcompras.Name = "btnexportarcompras";
            this.btnexportarcompras.Size = new System.Drawing.Size(134, 40);
            this.btnexportarcompras.TabIndex = 48;
            this.btnexportarcompras.Text = "Exportar";
            this.btnexportarcompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportarcompras.UseVisualStyleBackColor = false;
            this.btnexportarcompras.Click += new System.EventHandler(this.btnexportarcompras_Click);
            // 
            // dgdataproducto
            // 
            this.dgdataproducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdataproducto.Location = new System.Drawing.Point(12, 13);
            this.dgdataproducto.Name = "dgdataproducto";
            this.dgdataproducto.Size = new System.Drawing.Size(1105, 382);
            this.dgdataproducto.TabIndex = 0;
            this.dgdataproducto.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgdataproducto_RowPostPaint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Controls.Add(this.dateTimePicker2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.button7);
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(14, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1132, 430);
            this.panel4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Total";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Yellow;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(165, 359);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(147, 30);
            this.textBox1.TabIndex = 56;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(387, 39);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker1.TabIndex = 54;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(99, 39);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker2.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "Fecha Fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 53;
            this.label3.Text = "Fecha Inicio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "Reporte devolucionesen ventas";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.Location = new System.Drawing.Point(603, 37);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(134, 25);
            this.button7.TabIndex = 50;
            this.button7.Text = "Consultar";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::ProyectoPuntoVenta.Properties.Resources.excel;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.Location = new System.Drawing.Point(414, 375);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(134, 40);
            this.button6.TabIndex = 49;
            this.button6.Text = "Exportar";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1104, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.dataGridView2);
            this.panel5.Controls.Add(this.dtElectronica);
            this.panel5.Location = new System.Drawing.Point(24, 105);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1109, 426);
            this.panel5.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(906, 399);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(184, 26);
            this.textBox3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(513, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(354, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Valor minimo para generar factura ( 5 UVT)";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox2.Location = new System.Drawing.Point(310, 400);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 26);
            this.textBox2.TabIndex = 3;
            this.textBox2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(17, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Valor Factura antes de impuestos";
            this.label5.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(14, 203);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1088, 193);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dtElectronica
            // 
            this.dtElectronica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtElectronica.Location = new System.Drawing.Point(14, 13);
            this.dtElectronica.Name = "dtElectronica";
            this.dtElectronica.Size = new System.Drawing.Size(1088, 184);
            this.dtElectronica.TabIndex = 0;
            this.dtElectronica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtElectronica_CellClick);
            this.dtElectronica.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtElectronica_CellContentClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.FechaFinal);
            this.panel6.Controls.Add(this.fechaInicial);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.button9);
            this.panel6.Controls.Add(this.chart1);
            this.panel6.Location = new System.Drawing.Point(27, 107);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1005, 432);
            this.panel6.TabIndex = 9;
            this.panel6.Visible = false;
            // 
            // FechaFinal
            // 
            this.FechaFinal.CustomFormat = "dd/MM/yyyy";
            this.FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinal.Location = new System.Drawing.Point(390, 38);
            this.FechaFinal.Name = "FechaFinal";
            this.FechaFinal.Size = new System.Drawing.Size(187, 20);
            this.FechaFinal.TabIndex = 48;
            // 
            // fechaInicial
            // 
            this.fechaInicial.CustomFormat = "dd/MM/yyyy";
            this.fechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicial.Location = new System.Drawing.Point(102, 38);
            this.fechaInicial.Name = "fechaInicial";
            this.fechaInicial.Size = new System.Drawing.Size(187, 20);
            this.fechaInicial.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(308, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 46;
            this.label7.Text = "Fecha Fin:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 47;
            this.label8.Text = "Fecha Inicio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 20);
            this.label11.TabIndex = 45;
            this.label11.Text = "Reporte de Ingresos";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.Location = new System.Drawing.Point(606, 36);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(134, 25);
            this.button9.TabIndex = 44;
            this.button9.Text = "Consultar";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(22, 64);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(957, 500);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // frmConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 558);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmConta";
            this.Text = "Contabilidad";
            this.Load += new System.EventHandler(this.frmConta_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdatacartera)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdataproducto)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtElectronica)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgdatacartera;
        private System.Windows.Forms.DateTimePicker txtfechafin;
        private System.Windows.Forms.DateTimePicker txtfechainicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnconsultarventa;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgdataproducto;
        private System.Windows.Forms.Button btnexportarcompras;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtElectronica;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker FechaFinal;
        private System.Windows.Forms.DateTimePicker fechaInicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}