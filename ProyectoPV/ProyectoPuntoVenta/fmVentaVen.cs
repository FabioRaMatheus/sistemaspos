using ProyectoPuntoVenta.Logica;
using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Drawing.Printing;
using System.Net;
using ClosedXML.Excel;


namespace ProyectoPuntoVenta
{
    public partial class fmVentaVen : Form
    {
        private static int _IdPersona;
        int total;
        int pagado;
        int cambio;
        public int idventaImpre;
        public fmVentaVen(int idpersona = 0)
        {
            InitializeComponent();
            _IdPersona = idpersona;
        }
        DataTable dtventa = new DataTable();

        private void btnexportarventa_Click(object sender, EventArgs e)
        {
            if (dgdataventa.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Venta_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string informe = "Informe";
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtventa, informe);
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnconsultarventa_Click(object sender, EventArgs e)
        {
            dtventa = VentaLogica.Instancia.ReporteCaja(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"),Form1.oPersona.IdPersona.ToString());
            if (dtventa != null)
            {
                dgdataventa.DataSource = dtventa;
                 total = dgdataventa.Rows.Cast<DataGridViewRow>()
                .Sum(x => (int?)x.Cells[7].Value ?? 0);
                 pagado = dgdataventa.Rows.Cast<DataGridViewRow>()
                .Sum(x => (int?)x.Cells[8].Value ?? 0);
                 cambio = dgdataventa.Rows.Cast<DataGridViewRow>()
                .Sum(x => (int?)x.Cells[9].Value ?? 0);
               
               // Decimal TotalPrice = Convert.ToDecimal(dtventa.Compute("SUM(Total Pagar)", "TipoVenta=='P'"));
                int TotalPriceD = dtventa.AsEnumerable().Where(row => row.Field<int>("TipoVenta") ==0).Sum(row => row.Field<int>("Total Pagar"));
                total = dtventa.AsEnumerable().Where(row => row.Field<int>("TipoVenta") == 1).Sum(row => row.Field<int>("Total Pagar"));
                //double pagos = dtventa.Compute("SUM(TotalPagar)", "TipoVenta='P'");
                textBox1.Text = total.ToString("0,00");
                textBox2.Text = pagado.ToString("0,00");
                textBox3.Text = cambio.ToString("0,00");
                textBox9.Text = TotalPriceD.ToString("0,00");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirVenta imp = new ImprimirVenta(0, total.ToString(), total.ToString(), cambio.ToString(), txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"));
            imp.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int respuesta = ProductoLogica.Instancia.copySeguriddad();
            if (respuesta == -1)
            {
                MessageBox.Show("Copia de seguridad realizada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("No se pudo realizar la copia de seguridad, contactar a soporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var form = new ModalProducto())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtcodigoproducto.Text = form.codigo;
                    txtnombreproducto.Text = form.nombre;
                    txtidproducto.Text = form.idproducto.ToString();
                    txtprecioventa.Text = form.precioventa;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtdocumentocliente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el numero de documento\npara registrar una devolución", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdocumentocliente.Focus();
                return;
            }

            if (int.Parse(txtdocumentocliente.Text.Trim()) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor\npara registrar una devolución", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar un producto como minimo\npara registrar una devolución", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Compra oCompra = new Compra()
            {
                oPersona = new Persona() { IdPersona = _IdPersona },
                oProveedor = new Proveedor() { IdProveedor = int.Parse(txtdocumentocliente.Text.Trim()) },
                MontoTotal = Convert.ToDecimal(textBox5.Text, new CultureInfo("es-PE")),
                TipoDocumento = "Devolucion",
                NumeroDocumento = txtdocumentocliente.Text.Trim()
            };

            //row.Cells["IdProducto"].Value = txtidproducto.Text;
            //row.Cells["Codigo"].Value = txtcodigoproducto.Text.Trim();
            //row.Cells["NombreProducto"].Value = txtnombreproducto.Text.Trim();
            //row.Cells["Cantidad"].Value = txtpreciocompra.Text.Trim();
            //row.Cells["PrecioCompra"].Value = txtprecioventa.Text;
            ////row.Cells["PrecioVenta"].Value = decimal.Parse(txtprecioventa.Text)* txtcantidad.Value;
            //row.Cells["SubTotal"].Value = subtotal.ToString("0.00", new CultureInfo("es-PE"));
            List<DetalleCompra> olista = new List<DetalleCompra>();
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {

                    //oProducto = new Producto() { IdProducto = int.Parse(row.Cells["IdProducto"].Value.ToString()) },
                    //    Cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString()),
                    //    PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString(), new CultureInfo("es-Co")),
                    //    SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-Co"))


                    int idp = int.Parse(row.Cells["IdProducto"].Value.ToString());
                    int idcan = int.Parse(row.Cells["Cantidad"].Value.ToString());
                    decimal PrecioCompraDev = Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString());
                    decimal PrecioVentaDEv = Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString());
                    decimal TotalDev = Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());

                    olista.Add(new DetalleCompra()
                    {
                        oProducto = new Producto() { IdProducto = idp },
                        Cantidad = idcan,
                        PrecioCompra = PrecioCompraDev,
                        PrecioVenta = PrecioVentaDEv,
                        Total = TotalDev
                    });
                }
            }
            oCompra.oDetalleCompra = olista;

            int idventa = CompraLogica.Instancia.DevVentas(oCompra);
            if (idventa == 0)
            {
                //    if (CompraLogica.Instancia.DevVentas(oCompra))
                //{
                MessageBox.Show("No se pudo registrar la devolucion en compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                limpiar();
                imprimir(idventa);
                MessageBox.Show("La devolucion en ventas fue registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            textBox4.Text = idventa.ToString("0,0");
        }
        public void imprimir(int idventa)
        {
            idventaImpre = idventa;
            var printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            string ipCaja = "";
            int vtaIp = 0;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {

                ipCaja = ip.ToString();
                vtaIp = ipCaja.Length - 1;

            }

            //    return;

            Font font = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            //int _IdVenta=74;

            int width = 300;
            int widthDet = 600;
            int y = 30;


            string tickettexto = Properties.Resources.Ticket.ToString();
            Tienda otienda = TiendaLogica.Instancia.Obtener();
            Venta oVenta = VentaLogica.Instancia.ListarVentaDev().Where(v => v.IdVenta == idventaImpre).FirstOrDefault();
            List<DetalleVenta> oDetalleVenta = VentaLogica.Instancia.ListarDetalleVentaDev().Where(dv => dv.IdVenta == idventaImpre).ToList();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(otienda.RazonSocial.ToUpper(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Documento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Correo, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Telefono, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(oVenta.TipoDocumento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);

            e.Graphics.DrawString("Tiquete Devolución Nro:" + oVenta.NumeroDocumento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Fecha de Compra:" + oVenta.FechaRegistro, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Caja:" + ipCaja.Substring(vtaIp, 1).ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cajero:" + Form1.oPersona.Nombre.ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Nit/CC:" + txtdocumentocliente.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cliente:" + txtnombrecliente.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Tel:" + " ", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Dir:" + " ", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));

            Font fontDet = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);

            e.Graphics.DrawString("================================", fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);
            y = y + 40;
            //e.Graphics.DrawString("Detalle de la compra", fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);

            e.Graphics.DrawString("CANT", fontDet, Brushes.Black, new Rectangle(5, y, widthDet, 35));
            e.Graphics.DrawString("PRODUCTO", fontDet, Brushes.Black, new Rectangle(50, y, widthDet, 35));
            e.Graphics.DrawString("VL/UN", fontDet, Brushes.Black, new Rectangle(140, y, widthDet, 35));
            e.Graphics.DrawString("V/TOTA", fontDet, Brushes.Black, new Rectangle(210, y, widthDet, 35));


            StringBuilder tr = new StringBuilder();
            foreach (DetalleVenta dv in oDetalleVenta)
            {
                y = y + 30;
                e.Graphics.DrawString(dv.Cantidad.ToString(), fontDet, Brushes.Black, new Rectangle(5, y, widthDet, 15));
                string tamNombre = dv.oProducto.Nombre;
                if (tamNombre.Length > 15)
                {
                    e.Graphics.DrawString(dv.oProducto.Nombre.Substring(1, 15), fontDet, Brushes.Black, new Rectangle(50, y, widthDet, 15));

                }
                else
                {
                    e.Graphics.DrawString(dv.oProducto.Nombre, fontDet, Brushes.Black, new Rectangle(50, y, widthDet, 15));
                }
                e.Graphics.DrawString(dv.PrecioVenta.ToString("0,0", new CultureInfo("es-Co")), fontDet, Brushes.Black, new Rectangle(150, y, widthDet, 15));
                e.Graphics.DrawString(dv.SubTotal.ToString("0,0", new CultureInfo("es-Co")), fontDet, Brushes.Black, new Rectangle(210, y, widthDet, 15));
            }
            e.Graphics.DrawString("================================", font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Detalle de la Devolución", font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);


            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            Font fontDetPie = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);
            e.Graphics.DrawString("================================", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Total a pagar:" + oVenta.TotalPagar.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Pagado con:" + oVenta.PagoCon.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Cambio:" + oVenta.Cambio.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("================================", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("REGIMEN SIMPLIFICADO:", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);




        }
        public void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodigoproducto.Text = "";
            txtnombreproducto.Text = "";
            txtcantidad.Value = 1;
            txtprecioventa.Text = "";
            //txtprecioventa.Text = "";
        }
        private void limpiar()
        {
            limpiarProducto();
            //cbotipodocumento.SelectedIndex = 0;
            //txtnumerodocumento.Text = "";
            //txtdocumentoproveedor.Text = "";
            //txtidproveedor.Text = "0";
            //txtnombreproveedor.Text = "";
            dgdata.Rows.Clear();
            //lblmontototal.Text = "0";
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            decimal subtotal;
            bool producto_existe = false;





            string cantiDev = txtcantidad.Value.ToString();
            

            if (int.Parse(cantiDev) == 0)
            {
                MessageBox.Show("Debe indicar cantidad a ingresar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventa.Select();
                return;
            }

            if (txtcantidad.Value <1)
            {
                MessageBox.Show("La cantidad a devolver debe ser mayor a cero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto primero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcodigoproducto.Select();
                return;
            }


            bool errorCompra = false;
            bool errorVenta = false;
            try
            {
                preciocompra = Convert.ToDecimal(txtprecioventa.Text.Trim(), new CultureInfo("es-PE"));
            }
            catch
            {
                errorCompra = true;
            }

            try
            {
                precioventa = Convert.ToDecimal(txtprecioventa.Text.Trim(), new CultureInfo("es-PE"));
            }
            catch
            {
                errorVenta = true;
            }

            if (errorCompra)
            {
                MessageBox.Show("Error al convertir el tipo de moneda - Precio Compra\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (errorVenta)
            //{
            //    MessageBox.Show("Error al convertir el tipo de moneda - Precio Venta\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}


            foreach (DataGridViewRow fila in dgdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    MessageBox.Show("Pruducto ya fue seleccionado para devolución", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
            }

            if (!producto_existe)
            {
                int rowId = dgdata.Rows.Add();
                DataGridViewRow row = dgdata.Rows[rowId];
                //subtotal = Convert.ToDecimal(txtcantidad.Text.Trim()) * preciocompra;
                decimal preciocompraDev = decimal.Parse(txtprecioventa.Text);
                subtotal = Convert.ToDecimal(txtcantidad.Value) * preciocompraDev;

                row.Cells["IdProducto"].Value = txtidproducto.Text;
               // row.Cells["id"].Value = txtcodigoproducto.Text.Trim();
                row.Cells["NombreProducto"].Value = txtnombreproducto.Text.Trim();
                row.Cells["Cantidad"].Value = txtcantidad.Value;
                row.Cells["PrecioVenta"].Value = preciocompraDev.ToString("0,0");
                //row.Cells["PrecioVenta"].Value = precioventa.ToString("0.00", new CultureInfo("es-PE"));
                row.Cells["SubTotal"].Value = subtotal.ToString("0,0"); 

                limpiarProducto();
                calcularTotal();
                txtcodigoproducto.Focus();
            }
            //-----------------

            //// if (!producto_existe) {

            //bool resultado = VentaLogica.Instancia.ControlStock(int.Parse(txtidproducto.Text), int.Parse(txtcantidad.Text.Trim()), true);

            //if (resultado)
            //{
            //    int rowId = dgdata.Rows.Add();
            //    DataGridViewRow row = dgdata.Rows[rowId];

            //    if (this.label18.Visible == true)
            //    {
            //        row.Cells["Cantidad"].Value = 1;
            //        txtcantidad.Text = "1";
            //    }
            //    else
            //    {
            //        row.Cells["Cantidad"].Value = txtcantidad.Text.Trim();
            //    }
            //    subtotal = Convert.ToDecimal(txtcantidad.Text.Trim()) * precioventa;

            //    row.Cells["IdProducto"].Value = txtidproducto.Text;
            //    row.Cells["NombreProducto"].Value = txtnombreproducto.Text.Trim();
            //    row.Cells["PrecioVenta"].Value = precioventa.ToString("0,0");
            //    row.Cells["SubTotal"].Value = subtotal.ToString("0,0");

            //    calcularTotal();
            //    limpiarProducto();
            //    txtcodigoproducto.Focus();
            //   }

                //---
            }
        private void calcularTotal()
        {

            decimal total = 0;
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-CO"));
                }
            }

            //txttotalpagar.Text = Convert.ToString(total.ToString("N2"));
            textBox5.Text = total.ToString();

        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            double p_Saldo;

            using (var form = new ModalPersona())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtdocumentocliente.Text = form.documento;
                    txtnombrecliente.Text = form.nombre;
                    txtidcliente.Text = form.idcliente;
                    if (form.Cupo != "0")
                    {

                        if (form.Saldo != "")
                        {
                            p_Saldo = Convert.ToDouble(form.Cupo) - Convert.ToDouble(form.Saldo);
                        }
                        else
                        {
                            p_Saldo = 0;
                        }
                    }
                    else
                    {
                        p_Saldo = Convert.ToDouble(form.Cupo);
                    }
                    this.textBox1.Text = Convert.ToString(p_Saldo.ToString("N2"));
                    // calcular cuando debe y elcupo para restar________________

                    ///__________________________________________________
                    this.textBox1.Enabled = false;
                    txtcodigoproducto.Focus();
                }
            }
        }

        private void fmVentaVen_Load(object sender, EventArgs e)
        {
            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn Boton = new DataGridViewButtonColumn();

            Boton.HeaderText = "Eliminar";
            Boton.Width = 100;
            Boton.Text = "";
            Boton.Name = "btnEliminar";
            Boton.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdata.Columns.Add(Boton);
            dgdata.Columns.Add("IdProducto", "IdProducto");
            dgdata.Columns.Add("NombreProducto", "Nombre Producto");
            dgdata.Columns.Add("Cantidad", "Cantidad");
            dgdata.Columns.Add("PrecioVenta", "Precio Venta");
            dgdata.Columns.Add("SubTotal", "SubTotal");

            dgdata.Columns["btnEliminar"].Width = 100;
            dgdata.Columns["NombreProducto"].Width = 280;
            dgdata.Columns["Cantidad"].Width = 140;
            dgdata.Columns["PrecioVenta"].Width = 140;
            dgdata.Columns["SubTotal"].Width = 140;

            dgdata.Columns["IdProducto"].Visible = false;
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    int _idproducto = int.Parse(dgdata.Rows[index].Cells["IdProducto"].Value.ToString());
                    int _cantidad = int.Parse(dgdata.Rows[index].Cells["Cantidad"].Value.ToString());
                    bool resultado = VentaLogica.Instancia.ControlStock(_idproducto, _cantidad, false);

                    if (resultado)
                    {
                        dgdata.Rows.RemoveAt(index);
                        calcularTotal();
                    }
                }
            }
        }

        private void dgdata_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dgdata.Columns[e.ColumnIndex].Name;
                if (colname != "btnEliminar")
                {
                    dgdata.Cursor = Cursors.Default;
                }
                else
                {
                    dgdata.Cursor = Cursors.Hand;
                }
            }
        }

        private void dgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete32, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtventa = VentaLogica.Instancia.ReporteCompraCev(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"), Form1.oPersona.IdPersona.ToString());
            if (dtventa != null)
            {
                dataGridView1.DataSource = dtventa;
                total = dataGridView1.Rows.Cast<DataGridViewRow>()
               .Sum(x => (int?)x.Cells[7].Value ?? 0);
                pagado = dataGridView1.Rows.Cast<DataGridViewRow>()
               .Sum(x => (int?)x.Cells[8].Value ?? 0);
                cambio = dataGridView1.Rows.Cast<DataGridViewRow>()
               .Sum(x => (int?)x.Cells[9].Value ?? 0);
                textBox8.Text = total.ToString("0,00");
                textBox7.Text = pagado.ToString("0,00");
                textBox6.Text = cambio.ToString("0,00");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Venta_Devoluciones{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string informe = "Informe";
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtventa, informe);
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            var printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += ImprimirCaja;
            printDocument1.Print();
        }
        private void ImprimirCaja(object sender, PrintPageEventArgs e)
        {
            string ipCaja = "";
            int vtaIp = 0;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {

                ipCaja = ip.ToString();
                vtaIp = ipCaja.Length - 1;

            }

            //    return;

            Font font = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            //int _IdVenta=74;

            int width = 300;
            int widthDet = 600;
            int y = 30;


            string tickettexto = Properties.Resources.Ticket.ToString();
            Tienda otienda = TiendaLogica.Instancia.Obtener();
            Venta oVenta = VentaLogica.Instancia.ListarVentaDev().Where(v => v.IdVenta == idventaImpre).FirstOrDefault();
            //List<DetalleVenta> oDetalleVenta = VentaLogica.Instancia.ListarDetalleVentaDev().Where(dv => dv.IdVenta == idventaImpre).ToList();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(otienda.RazonSocial.ToUpper(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Documento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Correo, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Telefono, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            //e.Graphics.DrawString(oVenta.TipoDocumento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);

            e.Graphics.DrawString("Arqueo de Caja:", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Fecha:" + txtfechainicio.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Caja:" + ipCaja.Substring(vtaIp, 1).ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cajero:" + Form1.oPersona.Nombre.ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Nit/CC:" + txtdocumentocliente.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cliente:" + txtnombrecliente.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Tel:" + " ", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Dir:" + " ", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));

            Font fontDet = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);

            e.Graphics.DrawString("==================================", fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Ventas del dia:" + this.textBox1.Text, fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Ventas por Credito:" + this.textBox9.Text, fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            //e.Graphics.DrawString("Pagado con:" + this.textBox2.Text, fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            //e.Graphics.DrawString("Cambio" + this.textBox3.Text, fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            //e.Graphics.DrawString("Cliente:" + txtnombrecliente.Text, fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            //e.Graphics.DrawString("Tel:" + " ", fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            //e.Graphics.DrawString("Dir:" + " ", fontDet, Brushes.Black, new Rectangle(0, y += 20, width, 35));




            //e.Graphics.DrawString("================================", fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);
            //e.Graphics.DrawString("Ventas del dia:" + this.textBox1.Text, fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);
            //e.Graphics.DrawString("Ventas por Credito:"+this.textBox9.Text, fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);
            //e.Graphics.DrawString("Pagado con:" + this.textBox2.Text, fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);
            //e.Graphics.DrawString("Cambio" + this.textBox3.Text,fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);


            //e.Graphics.DrawString("CANT", fontDet, Brushes.Black, new Rectangle(5, y, widthDet, 35));
            //e.Graphics.DrawString("PRODUCTO", fontDet, Brushes.Black, new Rectangle(50, y, widthDet, 35));
            //e.Graphics.DrawString("VL/UN", fontDet, Brushes.Black, new Rectangle(140, y, widthDet, 35));
            //e.Graphics.DrawString("V/TOTA", fontDet, Brushes.Black, new Rectangle(210, y, widthDet, 35));


            //StringBuilder tr = new StringBuilder();
            //foreach (DetalleVenta dv in oDetalleVenta)
            //{
            //    y = y + 30;
            //    e.Graphics.DrawString(dv.Cantidad.ToString(), fontDet, Brushes.Black, new Rectangle(5, y, widthDet, 15));
            //    string tamNombre = dv.oProducto.Nombre;
            //    if (tamNombre.Length > 15)
            //    {
            //        e.Graphics.DrawString(dv.oProducto.Nombre.Substring(1, 15), fontDet, Brushes.Black, new Rectangle(50, y, widthDet, 15));

            //    }
            //    else
            //    {
            //        e.Graphics.DrawString(dv.oProducto.Nombre, fontDet, Brushes.Black, new Rectangle(50, y, widthDet, 15));
            //    }
            //    e.Graphics.DrawString(dv.PrecioVenta.ToString("0,0", new CultureInfo("es-Co")), fontDet, Brushes.Black, new Rectangle(150, y, widthDet, 15));
            //    e.Graphics.DrawString(dv.SubTotal.ToString("0,0", new CultureInfo("es-Co")), fontDet, Brushes.Black, new Rectangle(210, y, widthDet, 15));
            //}
            //e.Graphics.DrawString("================================", font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            //e.Graphics.DrawString("Detalle de la Devolución", font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);


            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            Font fontDetPie = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);
            //e.Graphics.DrawString("================================", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            //e.Graphics.DrawString("Total a pagar:" + oVenta.TotalPagar.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            //e.Graphics.DrawString("Pagado con:" + oVenta.PagoCon.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            //e.Graphics.DrawString("Cambio:" + oVenta.Cambio.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            //e.Graphics.DrawString("================================", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("REGIMEN SIMPLIFICADO:", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);


        }

        private void dgdataventa_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            int vPagos;
           
            foreach (DataGridViewRow Myrow in dgdataventa.Rows)
            {
                vPagos = Convert.ToInt32(Myrow.Cells["TipoVenta"].Value);
                /// Condicion que se colorea toda la fila si el valor de la celda 4 de la fila es 0
                /// //Convert.ToInt32(Myrow.Cells[4].Value)
                if (vPagos == 0)
                {
                    ///Colorea la letra de la celda
                    Myrow.DefaultCellStyle.ForeColor = Color.White;
                    /// Colorea el fondo de la celda
                    Myrow.DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    ///Colorea la letra de la celda
                    Myrow.DefaultCellStyle.ForeColor = Color.Red;
                    /// Colorea el fondo de la celda
                    Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
    }
}
