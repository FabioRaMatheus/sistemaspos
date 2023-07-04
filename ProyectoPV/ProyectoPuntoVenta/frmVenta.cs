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
using System.Text.RegularExpressions;

namespace ProyectoPuntoVenta
{
    public partial class frmVenta : Form
    {
        private static int _IdPersona;
        private delegate void DelegadoAcceso(string accion);
        public int idventaImpre;
        public frmVenta(int idpersona = 0)
        {
            InitializeComponent();
            _IdPersona = idpersona;
            txtidproveedor.Text = "1";
            this.textBox4.Text = "0";
            this.textBox5.Text = "0";
            btnbuscarcliente.PerformClick();

        }
        private void frmVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                btnterminarventa.PerformClick();
            }
            if (e.KeyCode == Keys.C)
            {
                btncalcular.PerformClick();
            }
            if (e.KeyCode == Keys.A) //para tecla +
            {
                btnagregarproducto.PerformClick();
            }
            if (e.KeyCode == Keys.T) //para tecla +
            {
                btnterminarventa.PerformClick();
            }


        }
        private void frmVenta_Load(object sender, EventArgs e)
        {

            //try
            //{
            //    serialPort1 = new SerialPort("COM1", 2400, Parity.None, 8, StopBits.One);
            //    serialPort1.Handshake = Handshake.None;
            //    serialPort1.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            //    serialPort1.ReadTimeout = 500;
            //    serialPort1.WriteTimeout = 500;
            //    serialPort1.Open();
            //    serialPort1.Write("0P");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Boleta", Text = "Boleta" });
            cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Factura", Text = "Factura" });
            cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Devolucion", Text = "Devolucion" });
            cbotipodocumento.DisplayMember = "Text";
            cbotipodocumento.ValueMember = "Value";
            cbotipodocumento.SelectedIndex = 0;



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
            dgdata.Columns.Add("Iva", "Iva");

            dgdata.Columns["btnEliminar"].Width = 100;
            dgdata.Columns["NombreProducto"].Width = 280;
            dgdata.Columns["Cantidad"].Width = 140;
            dgdata.Columns["PrecioVenta"].Width = 140;
            dgdata.Columns["SubTotal"].Width = 140;
            dgdata.Columns["Iva"].Width = 140;

            dgdata.Columns["IdProducto"].Visible = false;
        }
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.Enabled == true)
            {
                Thread.Sleep(500);
                string data = serialPort1.ReadExisting();
                this.BeginInvoke(new DelegadoAcceso(si_DataReceived), new object[] { data });
            }
        }

        private void si_DataReceived(string accion)
        {
            label18.Text = accion;

        }
        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            double p_Saldo;
            
            using (var form = new ModalPersona())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = form.documento;
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
                            p_Saldo = Convert.ToDouble(form.Cupo);
                        }
                    }
                    else
                    {
                        p_Saldo = Convert.ToDouble(form.Cupo);
                    }
                    this.textBox1.Text=Convert.ToString(p_Saldo.ToString("N2")); 
                    // calcular cuando debe y elcupo para restar________________

                    ///__________________________________________________
                    this.textBox1.Enabled = false;
                    txtcodigoproducto.Focus(); 
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var form = new ModalProducto())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtcodigoproducto.Text = form.codigo;
                    txtstock.Text = form.stock;
                    txtnombreproducto.Text = form.nombre;
                    txtidproducto.Text = form.idproducto.ToString();
                    txtprecioventa.Text =Convert.ToString(Convert.ToDouble(form.precioventa).ToString("N2"));
                    this.textBox6.Text = form.promocion.ToString();
                    txtIva.Text = form.Iva;

                    if (form.codigo == "1")
                    {
                        this.label18.Visible = false;
                        this.txtcantidad.ReadOnly = true;
                        this.txtcantidad.Enabled = true;
                        this.txtprecioventa.Enabled = true;
                        this.txtprecioventa.ReadOnly = false;
                        this.textBox2.Text = "1";
                    }
                    else
                    {


                        this.textBox2.Text = "0";
                        //form.precioventa.ToLower();
                        if (form.pesado == "Si")
                        {
                            this.label18.Visible = true;
                            this.txtcantidad.ReadOnly = false;
                            this.txtcantidad.Enabled = false;
                           
                        }
                        else
                        {
                            if (form.promocion == "Si")
                            {
                                this.label18.Visible = true;
                                this.txtcantidad.ReadOnly = false;
                                this.txtcantidad.Enabled = true;
                                this.txtprecioventa.Enabled = true;
                                this.txtprecioventa.ReadOnly = false;
                            }
                            else
                            {
                                this.label18.Visible = false;
                                this.txtcantidad.ReadOnly = true;
                                this.txtcantidad.Enabled = true;
                                this.txtprecioventa.Enabled = false;
                                this.txtprecioventa.ReadOnly = true;
                            }
                        }
                        if (form.promocion != "Si")
                        {
                            this.btnagregarproducto.PerformClick();
                        }
                        else
                        {
                            this.txtprecioventa.Select();

                        }
                    }
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

                    if (resultado) {
                        dgdata.Rows.RemoveAt(index);
                        calcularTotal();
                    }
                }
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            decimal precioventa = 0;
            decimal subtotal;
            decimal iva19=0;
            decimal iva5=0;
            bool producto_existe = false;




            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto primero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (int.Parse(txtstock.Text) < int.Parse(txtcantidad.Text))
            {
                MessageBox.Show("No hay suficiente stock del producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarProducto();
                txtcodigoproducto.Focus();
                return;
            }

            bool errorVenta = false;
            try
            {
                precioventa = Convert.ToDecimal(txtprecioventa.Text.Trim(), new CultureInfo("es-CO"));
                iva19 = Convert.ToDecimal(txtIva.Text.Trim(), new CultureInfo("es-CO"));
            }
            catch
            {
                errorVenta = true;
            }

            if (errorVenta)
            {
                MessageBox.Show("Error al convertir el tipo de moneda - Precio Venta\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dgdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

           // if (!producto_existe) {

                bool resultado = VentaLogica.Instancia.ControlStock(int.Parse(txtidproducto.Text),int.Parse(txtcantidad.Text.Trim()),true);

                if (resultado) {
                    int rowId = dgdata.Rows.Add();
                    DataGridViewRow row = dgdata.Rows[rowId];

                    if (this.label18.Visible == true)
                    {
                    if (this.textBox6.Text == "No")
                            {
                                row.Cells["Cantidad"].Value = 1;
                                txtcantidad.Text = "1";
                            }
                            else
                            {
                            row.Cells["Cantidad"].Value = txtcantidad.Text;

                         }
                        
                    }
                    else
                    {
                        row.Cells["Cantidad"].Value = txtcantidad.Text.Trim();
                    }
                    subtotal = Convert.ToDecimal(txtcantidad.Text.Trim()) * precioventa;
                if (iva19 ==19)
                {
                    iva19 = Convert.ToDecimal(txtcantidad.Text.Trim()) * (iva19 / 100) * precioventa;
                }
                if (iva19 == 5)
                {
                    iva19 = Convert.ToDecimal(txtcantidad.Text.Trim()) * (iva19 / 100) * precioventa;
                }
                if (iva19 == 1)
                {
                    iva19 = 0;
                }
                

                    row.Cells["IdProducto"].Value = txtidproducto.Text;
                    row.Cells["NombreProducto"].Value = txtnombreproducto.Text.Trim();
                    row.Cells["PrecioVenta"].Value = precioventa.ToString("0,0");
                    row.Cells["SubTotal"].Value = subtotal.ToString("0,0");
                    row.Cells["iva"].Value = iva19.ToString("0,0");

                calcularTotal();
                    limpiarProducto();
                    txtcodigoproducto.Focus();
                //}
            }

            
        }

        public void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtstock.Text = "0";
            txtcodigoproducto.Text = "";
            txtnombreproducto.Text = "";
            txtcantidad.Value = 1;
            txtprecioventa.Text = "";
        }

        private void calcularTotal()
        {

            decimal total = 0;
            decimal totalIva = 0;
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-CO"));
                    totalIva += Convert.ToDecimal(row.Cells["Iva"].Value.ToString(), new CultureInfo("es-CO"));
                }
            }

            //txttotalpagar.Text = Convert.ToString(total.ToString("N2"));
            txttotalpagar.Text=total.ToString("0,0");

        }

        private void btnterminarventa_Click(object sender, EventArgs e)
        {



            string iva19 = "0";
            string iva5 = "0";


            if (txtidproveedor.Text.Trim() == "" || txtnombrecliente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar todos los datos del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidproveedor.Select();
                return;
            }

            if (dgdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar un producto como minimo\npara registrar una venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //ModalPago formPago = new ModalPago();
            //formPago.valorCompra = this.txttotalpagar.Text;
            //formPago.Pagacon = this.txtpagocon.Text;
            //formPago.vueltas = txtcambio.Text;


            //formPago.valIva19 = "0";
            //formPago.valIva4 = "0";
            //formPago.NumFactura = "";



            if (txtpagocon.Text.Trim() == "0")
            {
                MessageBox.Show("Debe ingresar con cuanto paga el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagocon.Focus();
                return;
            }

            if (!calcularcambio())
            {
                MessageBox.Show("Error al convertir el tipo de moneda - Paga con\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal totalVaidar = Convert.ToDecimal(txttotalpagar.Text, new CultureInfo("es-CO"));
            int pagocliente = int.Parse(RemoverCAracteresNoValidos(txtpagocon.Text));
            //caso si hay una devolucion autoriada
            //_____________________________________________
            if (this.textBox4.Text != "0")
            {

                int pagacon = int.Parse(RemoverCAracteresNoValidos(txtpagocon.Text)) + int.Parse(this.textBox5.Text.ToString() );
                pagocliente = pagacon;

            }
            //________________________________________
            if (pagocliente < totalVaidar)
            {
                MessageBox.Show("Debe ingresar un valor mayor o igual a valor de la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagocon.Text = "0"; 
                txtpagocon.Focus();
                return;
            }

         if (MessageBox.Show("¿Desea realizar el pago ?", "Pagar factura", MessageBoxButtons.YesNo) == DialogResult.No)
            {

                MessageBox.Show("Pago cancelado");
                limpiar();
                txtcodigoproducto.Focus();
                this.textBox3.Text = "0";
                this.textBox4.Text = "0";
                this.textBox5.Text = "0";
                return;

            }

            
            string v_TipoVenta="";
            if (textBox1.Text != "0")
            {

                if (dgdata.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgdata.Rows)
                    {
                        string codProd =this.textBox2.Text;
                        if (codProd == "1")
                        {
                            v_TipoVenta = "P";
                        }
                        else
                        {
                            v_TipoVenta = "C";
                        }

                    }
                }
             
            }
            else
            {
                v_TipoVenta = "V";
            }



            Venta oVenta = new Venta()
            {
                TipoDocumento = ((ComboBoxItem)cbotipodocumento.SelectedItem).Value.ToString(),
                oPersona = new Persona() { IdPersona = _IdPersona },
                DocumentoCliente = txtidproveedor.Text.Trim(),
                NombreCliente = txtnombrecliente.Text.Trim(),
                TotalPagar = Convert.ToDecimal(txttotalpagar.Text, new CultureInfo("es-Co")),
                PagoCon = Convert.ToDecimal(RemoverCAracteresNoValidos(txtpagocon.Text), new CultureInfo("es-Co")),
                Cambio = Convert.ToDecimal(txtcambio.Text, new CultureInfo("es-Co")),
                TipoVenta = v_TipoVenta.ToString()

        };

            List<DetalleVenta> olista = new List<DetalleVenta>();
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    olista.Add(new DetalleVenta()
                    {
                        oProducto = new Producto() { IdProducto = int.Parse(row.Cells["IdProducto"].Value.ToString()) },
                        Cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString()),
                        PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString(), new CultureInfo("es-Co")),
                        SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-Co"))
                       
                    });
                }
            }
            oVenta.oDetalleVenta = olista;



            int idventa = VentaLogica.Instancia.Registrar(oVenta);
            if (idventa != 0)
            {
                DataTable dtIva = VentaLogica.Instancia.reporteIva(idventa.ToString());
                if (dtIva.Rows.Count > 0)
                {

                    foreach (DataRow row in dtIva.Rows)
                    {
                        if (row["iva"].ToString() == "5")
                        {
                            iva5 = row["valor"].ToString();
                        }
                        if (row["iva"].ToString() == "19")
                        {
                            iva19 = row["valor"].ToString();
                        }
                    }
                }

                if (this.textBox5.Text!="0")
                {
                    cruzarDev(int.Parse(this.textBox3.Text), idventa);
                }
                if (MessageBox.Show("La venta fue registrada\n¿Desea imprimir el ticket ahora?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ImprimirVenta imp = new ImprimirVenta(idventa);
                    //imp.ShowDialog();
                    //this.textBox3.Text = "0";
                    //this.textBox4.Text = "0";
                    //this.textBox5.Text = "0";
                  
                   

                    imprimir(idventa);

                    using (var form = new ModalVenta())
                    {
                        //var p = this.Parent.PointToScreen(this.Location);
                        //p.Offset((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
                        //form.StartPosition = FormStartPosition.Manual;
                        form.valorFactura = this.txttotalpagar.Text;
                        form.valorPagado = this.txtpagocon.Text;
                        form.valorVuelas = txtcambio.Text;
                        form.numfac = idventa.ToString();
                        form.valor19 = iva19.ToString();
                        form.valor5 = iva5.ToString();
                        var result = form.ShowDialog();
                        this.textBox3.Text = "0";
                        this.textBox4.Text = "0";
                        this.textBox5.Text = "0";

                    }


                }
                else
                {
                    printDocument1 = new System.Drawing.Printing.PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += abrircaja;
                    printDocument1.Print();

                    
                   

                    using (var form = new ModalVenta())
                    {

                        //var p = this.Parent.PointToScreen(this.Location);
                        //p.Offset((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
                        //form.StartPosition = FormStartPosition.Manual;

                        //form.StartPosition=FormStartPosition.CenterScreen;

                        


                        form.valorFactura = this.txttotalpagar.Text;
                        form.valorPagado = this.txtpagocon.Text;
                        form.valorVuelas = txtcambio.Text;
                        form.numfac = idventa.ToString();
                        form.valor19 = iva19.ToString();
                        form.valor5 = iva5.ToString();
                        var result = form.ShowDialog();




                        this.textBox3.Text = "0";
                        this.textBox4.Text = "0";
                        this.textBox5.Text = "0";

                    }


                }
               
            }
            else
            {
                MessageBox.Show("No se pudo registrar la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }





            //if (textBox1.Text !="0")
            //{

            //    MessageBox.Show("Registrada en la cuenta por cobrar del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}
            limpiar();
            this.txtcodigoproducto.Focus();

        }
        public void abrircaja(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 2, FontStyle.Regular, GraphicsUnit.Point);
            int y = 1;
            int width = 1;
            string tickettexto = Properties.Resources.Ticket.ToString();
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(".", font, Brushes.Black, new Rectangle(0, y += 1, width, 1), stringFormat);
        }
        public  void cruzarDev(int idventa, int venta)
            {
            bool resultado = VentaLogica.Instancia.actDevoluciones(idventa, venta);
        }
        public void imprimir(int idventa)
        {
            idventaImpre = idventa;
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();  
        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            string ipCaja="";
            int vtaIp=0;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {

                ipCaja = ip.ToString();
                vtaIp = ipCaja.Length-1;

            }

            //    return;

            Font font = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            //int _IdVenta=74;

            int width = 300;
            int widthDet = 800;
            int y = 30;


            string tickettexto = Properties.Resources.Ticket.ToString();
            Tienda otienda = TiendaLogica.Instancia.Obtener();
            Venta oVenta = VentaLogica.Instancia.ListarVenta().Where(v => v.IdVenta == idventaImpre).FirstOrDefault();
            List<DetalleVenta> oDetalleVenta = VentaLogica.Instancia.ListarDetalleVenta().Where(dv => dv.IdVenta == idventaImpre).ToList();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(otienda.RazonSocial.ToUpper(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Documento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Correo, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(otienda.Telefono, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString(oVenta.TipoDocumento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);

            e.Graphics.DrawString("Tiquete de Venta Nro:" + oVenta.NumeroDocumento, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Fecha de Compra:" + oVenta.FechaRegistro, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Caja:" + ipCaja.Substring(vtaIp,1).ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cajero:" + Form1.oPersona.Nombre.ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Nit/CC:" +txtidproveedor.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cliente:" + txtnombrecliente.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Tel:" +" ", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Dir:" + " " , font, Brushes.Black, new Rectangle(0, y += 20, width, 35));

            Font fontDet = new Font("Arial", 5, FontStyle.Regular, GraphicsUnit.Point);
           
            e.Graphics.DrawString("================================", fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);
            y = y + 40;
            //e.Graphics.DrawString("Detalle de la compra", fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);

            e.Graphics.DrawString("CANT", fontDet, Brushes.Black, new Rectangle(5, y, widthDet, 30));
            e.Graphics.DrawString("PRODUCTO", fontDet, Brushes.Black, new Rectangle(30, y, widthDet, 30));
            e.Graphics.DrawString("VL/UN", fontDet, Brushes.Black, new Rectangle(170, y, widthDet, 30));
            e.Graphics.DrawString("V/TOTA", fontDet, Brushes.Black, new Rectangle(210, y , widthDet, 30));

            
            StringBuilder tr = new StringBuilder();
            foreach (DetalleVenta dv in oDetalleVenta)
            {
                y=y+15;
                e.Graphics.DrawString(dv.Cantidad.ToString(), fontDet, Brushes.Black, new Rectangle(5, y, widthDet, 15));
                //string tamNombre = dv.oProducto.Nombre;
                //if (tamNombre.Length > 15)
                //{
                //    e.Graphics.DrawString(dv.oProducto.Nombre.Substring(1, 30), fontDet, Brushes.Black, new Rectangle(50, y, widthDet, 15));

                //}
                //else
                //{
                    e.Graphics.DrawString(dv.oProducto.Nombre, fontDet, Brushes.Black, new Rectangle(20, y, widthDet, 15));
                //}
                e.Graphics.DrawString(dv.PrecioVenta.ToString("0,0", new CultureInfo("es-Co")), fontDet, Brushes.Black, new Rectangle(170, y, widthDet, 15));
                e.Graphics.DrawString(dv.SubTotal.ToString("0,0", new CultureInfo("es-Co")), fontDet, Brushes.Black, new Rectangle(210, y, widthDet, 15));
            }
            e.Graphics.DrawString("================================", font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Detalle del pago", font, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);

            
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            Font fontDetPie = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);
            e.Graphics.DrawString(" " , fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Total a pagar:"+oVenta.TotalPagar.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Pagado con:"+oVenta.PagoCon.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Cambio:"+oVenta.Cambio.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("================================", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("REGIMEN SIMPLIFICADO:", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);




        }

        private void limpiar()
        {
            //txtdocumentocliente.Text = "";
            //txtnombrecliente.Text = "";
            txttotalpagar.Text = "0";
            txtpagocon.Text = "0";
            txtcambio.Text = "0";
            dgdata.Rows.Clear();

        }

        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {

                   

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }

        }

        

        private void btncalcular_Click(object sender, EventArgs e)
        {
            if (txtpagocon.Text.Length>0)
            {
                double numero = Convert.ToDouble(txtpagocon.Text);
                // puedes probas estas dos maneras de aplicar formato
                // primera:
                txtpagocon.Text = numero.ToString("N0");
                // segunda:
                //txtpagocon.Text = string.Format("###,###,###,00", numero);
                txtpagocon.Text = string.Format("{0:c0}", txtpagocon.Text);

                if (!calcularcambio())
                {
                    MessageBox.Show("Error al convertir el tipo de moneda - Paga con\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            txtpagocon.Select(txtpagocon.Text.Length, 0);
        }
        private string RemoverCAracteresNoValidos(string palabras)
        {
            return Regex.Replace(palabras, "[.]+", "", RegexOptions.Compiled);
        }

        private bool calcularcambio() {

            bool respuesta = true;
            decimal pagacon;

            decimal total = Convert.ToDecimal(txttotalpagar.Text, new CultureInfo("es-CO"));

            if (!decimal.TryParse(RemoverCAracteresNoValidos(txtpagocon.Text.Trim()), NumberStyles.AllowDecimalPoint, new CultureInfo("es-CO"), out pagacon))
            {
                respuesta = false;
            }
            else {
                if (pagacon < total)
                {
                    txtcambio.Text = "0";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    txtcambio.Text = cambio.ToString("0,0");
                }
            }
            return respuesta;
        }

        private void txtcodigoproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                Producto pr = ProductoLogica.Instancia.Listar().Where(p => p.Codigo == txtcodigoproducto.Text.Trim()).FirstOrDefault();
                if (pr != null) {
                    txtcodigoproducto.Text = pr.Codigo;
                    txtstock.Text = pr.Stock.ToString();
                    txtnombreproducto.Text = pr.Nombre;
                    txtidproducto.Text = pr.IdProducto.ToString();
                    txtprecioventa.Text = pr.PrecioVenta.ToString("0.00", new CultureInfo("es-CO"));
                    this.btnagregarproducto.PerformClick();
                }
                
            }
        }

        private void txtcodigoproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
        }

        private void txtpagocon_Leave(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imprimir(idventaImpre);
        }

        private void frmVenta_KeyUp(object sender, KeyEventArgs e)



        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.N))
            {
                MessageBox.Show("Se ha pulsado la combinación de teclas Control + N");
            }
        }

        private void frmVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Pesiono la tecla"+e.KeyChar);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(this.textBox3.Text))
            //{
            //    MessageBox.Show("Error Indique numero devolución autorizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.textBox3.Text = "0"; 
            //    this.textBox3.Select();
            //    return;
            //}
            //else
            //{

                using (var form = new ModalDevVentas())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {


                    //txtcodigoproducto.Text = form.idVenta;
                    //txtstock.Text = form.totalPagar;
                    try
                    {
                        idventaImpre = int.Parse(form.idVenta);
                        this.textBox3.Text = form.idVenta.ToString();
                    }
                    catch (Exception ex)
                    {
                        idventaImpre = 0;
                        this.textBox3.Text = "0";
                    }

                     
                        Venta oVenta = VentaLogica.Instancia.ListarVentaDev().Where(v => v.IdVenta == idventaImpre).FirstOrDefault();
                        if (oVenta == null)
                        {
                            this.textBox4.Text = "0";
                            this.textBox5.Text = "0";
                            MessageBox.Show("Error Indique numero devolución autorizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.textBox3.Select();
                            return;
                        }
                        else
                        {
                            //List<DetalleVenta> oDetalleVenta = VentaLogica.Instancia.ListarDetalleVentaDev().Where(dv => dv.IdVenta == idventaImpre).ToList();
                            this.textBox4.Text = oVenta.PagoCon.ToString("0,0");
                            this.textBox5.Text = Math.Round(oVenta.PagoCon, 0).ToString();
                        }
                  }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmVenta_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {


                this.WindowState = FormWindowState.Normal;
                var numaleatorio = new Random();
                this.Size = new Size(250, 300);
                this.Location = new Point(1000, numaleatorio.Next(50, 400));

            }
        }
    }
}
