using ClosedXML.Excel;
using ProyectoPuntoVenta.Logica;
using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProyectoPuntoVenta
{
    public partial class frmConta : Form
    {
        DataTable dtcompra = new DataTable();
        DataTable dtDevEntas = new DataTable();
        DataTable dtproducto = new DataTable();
        DataSet dtVentasELect= new DataSet();
        DataTable dtparametros = new DataTable();
        int TotalPrice;
        Int64 valorFactElectronica;
        public frmConta(int idpersona = 0)
        {
            InitializeComponent();
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            dtparametros = PersonaLogica.Instancia.Parametros();
            TotalPrice = Convert.ToInt16(dtparametros.Compute("SUM(stockmin)", string.Empty));
            valorFactElectronica = Convert.ToInt64(dtparametros.Compute("SUM(uvtIva)", string.Empty));
            this.textBox3.Text = valorFactElectronica.ToString("N0"); 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = true;
        }
        public void vercartera()
        {
            double suma, abonos, saldos;
            dtcompra = CompraLogica.Instancia.ReporteCarteraConta(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"));
            if (dtcompra != null)
            {
                dgdatacartera.DataSource = dtcompra;
                suma = dgdatacartera.Rows.OfType<DataGridViewRow>().
                         Sum(x => Convert.ToDouble(x.Cells["Monto total"].Value));
                abonos = dgdatacartera.Rows.OfType<DataGridViewRow>().
                       Sum(x => Convert.ToDouble(x.Cells["pagos"].Value));

                //this.textBox1.Text = string.Format("{0:N2}", suma);
                //this.textBox2.Text = string.Format("{0:N2}", abonos);
                //this.textBox3.Text = string.Format("{0:N2}", suma - abonos);
            }
        }

        private void btnconsultarventa_Click(object sender, EventArgs e)
        {
            //dtventa = VentaLogica.Instancia.Reporte(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"), Form1.oPersona.IdPersona.ToString());

            double suma, abonos;
            dtcompra = CompraLogica.Instancia.ReporteCarteraConta(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"));
            if (dtcompra != null)
            {
                dgdatacartera.DataSource = dtcompra;
                suma = dgdatacartera.Rows.OfType<DataGridViewRow>().
                         Sum(x => Convert.ToDouble(x.Cells["Monto total"].Value));
                abonos = dgdatacartera.Rows.OfType<DataGridViewRow>().
                       Sum(x => Convert.ToDouble(x.Cells["pagos"].Value));

                //this.textBox1.Text = string.Format("{0:N2}", suma/2);
                //this.textBox2.Text = string.Format("{0:N2}", abonos/2);
                //this.textBox3.Text = string.Format("{0:N2}", (suma - abonos)/2);
            }
    }

        private void dgdatacartera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string idFactura = "";
            string fecha = "";
            string idValor = "";
            string idFac = "";
            string idValdev = "";
            idFactura = dgdatacartera.Rows[dgdatacartera.CurrentRow.Index].Cells[4].Value.ToString();
            fecha = dgdatacartera.Rows[dgdatacartera.CurrentRow.Index].Cells[1].Value.ToString();
            idValor = dgdatacartera.Rows[dgdatacartera.CurrentRow.Index].Cells[5].Value.ToString();
            idFac = dgdatacartera.Rows[dgdatacartera.CurrentRow.Index].Cells[11].Value.ToString();
            idValdev = dgdatacartera.Rows[dgdatacartera.CurrentRow.Index].Cells[13].Value.ToString();
            using (var form = new FpagoFacturas(idFactura, fecha, idValor, idFac, idValdev))
            {
                form.ShowDialog(this);
            }
            vercartera();
        }

        private void dgdatacartera_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int vPagos;
            int vDeuda;
            int vDev;
            foreach (DataGridViewRow Myrow in dgdatacartera.Rows)
            {
                vPagos = Convert.ToInt32(Myrow.Cells["pagos"].Value);
                vDeuda = Convert.ToInt32(Myrow.Cells[5].Value);
                try
                {
                    if (String.IsNullOrEmpty(Myrow.Cells[13].Value.ToString()))
                    {
                        vDev = 0;
                    }
                    else
                    {
                        vDev = Convert.ToInt32(Myrow.Cells[13].Value);
                    }
                }
                catch (Exception ex)
                {
                    vDev = 0;
                } 
                

                vDeuda = vDeuda - (vPagos + vDev);
                /// Condicion que se colorea toda la fila si el valor de la celda 4 de la fila es 0
                /// //Convert.ToInt32(Myrow.Cells[4].Value)
                if (vDeuda == 0)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel3.Visible = true;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
            dtproducto = ProductoLogica.Instancia.ListarExport();
            this.dgdataproducto.DataSource = dtproducto;
         
        }

        private void dgdataproducto_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int vPagos;
            foreach (DataGridViewRow Myrow in dgdataproducto.Rows)
            {
                vPagos = Convert.ToInt32(Myrow.Cells["stock"].Value);
                /// Condicion que se colorea toda la fila si el valor de la celda 4 de la fila es 0
                /// //Convert.ToInt32(Myrow.Cells[4].Value)
                if (vPagos< TotalPrice)
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

        private void btnexportarcompras_Click(object sender, EventArgs e)
        {
            if (dgdataproducto.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_productos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtproducto, "Informe");
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = true;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dtDevEntas = VentaLogica.Instancia.ReporteVentaDev(dateTimePicker2.Value.ToString("dd/MM/yyyy"), dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            if (dtDevEntas != null)
            {
                dataGridView1.DataSource = dtDevEntas;
                double sumaVentas = dataGridView1.Rows.OfType<DataGridViewRow>().
                        Sum(x => Convert.ToDouble(x.Cells["Total Pagar"].Value));

                this.textBox1.Text = sumaVentas.ToString("0,00");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgdataproducto.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_devoluciones en ventas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel dataGridView1|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtDevEntas, "Informe");
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

        private void button8_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = true;
            this.panel6.Visible = false;
            this.dataGridView2.Visible = false;
            dtVentasELect = ProductoLogica.Instancia.facElectronica();
            this.dtElectronica.Rows.Clear();
            foreach (DataRow dr in dtVentasELect.Tables[0].Rows)
            {

                int rowId = dtElectronica.Rows.Add();
                DataGridViewRow row = dtElectronica.Rows[rowId];
                row.Cells["Id"].Value = rowId.ToString();
                row.Cells["NumeroFactura"].Value = dr[0].ToString();
                row.Cells["Documento"].Value = dr[1].ToString();
                row.Cells["Secuencia"].Value = dr[2].ToString();
                row.Cells["IdUsuario"].Value = dr[3].ToString();
                row.Cells["DocumentoCiente"].Value = dr[4].ToString();
                row.Cells["NombreCliente"].Value = dr[5].ToString();
                row.Cells["Totalpagar"].Value = dr[6].ToString();
                row.Cells["PagoCon"].Value = dr[7].ToString();
                row.Cells["Cambio"].Value = dr[8].ToString();
                row.Cells["FechaVenta"].Value = dr[9].ToString();
                row.Cells["TipoVenta"].Value = dr[10].ToString();
            }


            //dtElectronica.Columns.Add("Id", "Id");
            //dtElectronica.Columns.Add("NumeroFactura", "Numero Factura");
            //dtElectronica.Columns.Add("Documento", "Documento");
            //dtElectronica.Columns.Add("IdUsuario", "IdUsuario");
            //dtElectronica.Columns.Add("DocumentoCiente", "Documento Cliente");
            //dtElectronica.Columns.Add("NombreCliente", "Nombre Cliente");
            //dtElectronica.Columns.Add("Totalpagar", "Total a Pagar");
            //dtElectronica.Columns.Add("PagoCon", "Pago Con");
            //dtElectronica.Columns.Add("Cambio", "Cambio");
            //dtElectronica.Columns.Add("FechaVenta", "Fecha Venta");
            //dtElectronica.Columns.Add("TipoVenta", "Tipo Venta");

            //dtElectronica.Columns["Id"].Width = 50;
            //dtElectronica.Columns["NombreCliente"].Width = 300;




            //this.dtElectronica.DataSource = dtproducto;
        }

        private void dtElectronica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dtElectronica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            textBox2.Text = "0";
            int idFactura;
            int index = e.RowIndex;
            try
            {
                DataSet dtDetalle = new DataSet();
                if (index >= 0)
                {
                    idFactura = int.Parse(dtElectronica.Rows[index].Cells[1].Value.ToString());
                    dtDetalle = ProductoLogica.Instancia.facElectronicaDetalle(idFactura.ToString());
                    foreach (DataRow dr in dtDetalle.Tables[0].Rows)
                    {
                        
                        int rowId = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[rowId];
                            row.Cells["Id"].Value = rowId.ToString();
                            row.Cells["NumeroFactura"].Value = dr[0].ToString();
                            row.Cells["CodigoProducto"].Value = dr[1].ToString();
                            row.Cells["NombreProducto"].Value = dr[2].ToString();
                            row.Cells["Iva"].Value = dr[3].ToString();
                            row.Cells["Cantidad"].Value = dr[4].ToString();
                            row.Cells["Subtotal"].Value = dr[5].ToString();
                            row.Cells["Total"].Value = dr[6].ToString();
                            row.Cells["ValorBase"].Value = dr[7].ToString();
                    }
                                   
         
                    decimal sum = (decimal)dtDetalle.Tables[0].Compute("Sum(ValorBase)", "ValorBase>0");


                    textBox2.Text = sum.ToString("N0");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione factura valida","Factura");
                this.dataGridView2.Visible = false;
                this.label5.Visible = false;
                this.textBox2.Visible = false;
                return;
            }
            
            this.dataGridView2.Visible = true;
            this.label5.Visible = true;
            this.textBox2.Visible = true;
            
        }

        private void frmConta_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns.Add("Id", "Id");
            dataGridView2.Columns.Add("NumeroFactura", "Numero Factura");
            dataGridView2.Columns.Add("CodigoProducto", "Numero Producto");
            dataGridView2.Columns.Add("NombreProducto", "Descripcion Producto");
            dataGridView2.Columns.Add("Iva", "Iva");
            dataGridView2.Columns.Add("Cantidad", "cantidad");
            dataGridView2.Columns.Add("Subtotal", "Subtotal");
            dataGridView2.Columns.Add("Total", "Total");
            dataGridView2.Columns.Add("ValorBase", "Valor Base");
            dataGridView2.Columns["Id"].Width = 50;
            dataGridView2.Columns["NombreProducto"].Width = 300;
            dataGridView2.Columns["Iva"].Width = 50;


            dtElectronica.Columns.Add("Id", "Id");
            dtElectronica.Columns.Add("NumeroFactura", "Numero Factura");
            dtElectronica.Columns.Add("Documento", "Documento");
            dtElectronica.Columns.Add("Secuencia", "Secuencia");
            dtElectronica.Columns.Add("IdUsuario", "IdUsuario");
            dtElectronica.Columns.Add("DocumentoCiente", "Documento Cliente");
            dtElectronica.Columns.Add("NombreCliente", "Nombre Cliente");
            dtElectronica.Columns.Add("Totalpagar", "Total a Pagar");
            dtElectronica.Columns.Add("PagoCon", "Pago Con");
            dtElectronica.Columns.Add("Cambio", "Cambio");
            dtElectronica.Columns.Add("FechaVenta", "Fecha Venta");
            dtElectronica.Columns.Add("TipoVenta", "Tipo Venta");

            dtElectronica.Columns["Id"].Width = 50;
            dtElectronica.Columns["NombreCliente"].Width = 300;



            //dtElectronica.Columns["Cupo"].Width = 100;
            //dtElectronica.Columns["Id"].Visible = false;
            dtElectronica.Columns["TipoVenta"].Visible = false;
            dtElectronica.Columns["IdUsuario"].Visible = false;
            dtElectronica.Columns["Secuencia"].Visible = false;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dtventa = new DataTable();
            dtventa = VentaLogica.Instancia.reporteGrafVentas(fechaInicial.Value.ToString("yyyy-MM-dd"), FechaFinal.Value.ToString("yyyy-MM-dd"));
            if (dtventa != null)
            {
                this.chart1.Series.Clear();
                this.chart1.Titles.Clear();
                this.chart1.ChartAreas.Clear();


                this.chart1.Palette = ChartColorPalette.Excel;
                ChartArea areagrafico = new ChartArea();

                this.chart1.ChartAreas.Add(areagrafico);

                Series serie = new Series("Periodo");
                serie.ChartType = SeriesChartType.Column;
                

                Title titulo = new Title("Promedio de venta");
                titulo.Font = new Font("tahoma", 16, FontStyle.Bold);
                this.chart1.Titles.Add(titulo);   

                serie.XValueMember = "mes";
                serie.YValueMembers = "totalventa";
                serie.IsValueShownAsLabel = true;
                serie.SmartLabelStyle.Enabled = false;
                serie.CustomProperties = "DrawingStyle = Cylinder,PixelPointWidth = 40";



                this.chart1.Series.Add(serie);

                //Series serieValor = new Series("totalventa");
                //serieValor.ChartType = SeriesChartType.Column;

                //serieValor.XValueMember = "mes";
                //serieValor.XValueMember = "totalventa";
                //serieValor.IsValueShownAsLabel = true;
                //serieValor.SmartLabelStyle.Enabled = false;
                //this.chart1.Series.Add(serieValor);

                this.chart1.DataSource = dtventa;
                this.chart1.Height = 350;
                //dgdataventa.DataSource = dtventa;
                //double sumaVentas = dgdataventa.Rows.OfType<DataGridViewRow>().
                //        Sum(x => Convert.ToDouble(x.Cells["Total Pagar"].Value));

                //this.textBox4.Text = sumaVentas.ToString("0,00");
            }
        }
    }
}
