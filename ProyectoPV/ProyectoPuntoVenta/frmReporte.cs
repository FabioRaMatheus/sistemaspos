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

namespace ProyectoPuntoVenta
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }
        DataTable dtventa = new DataTable();
        DataTable dtcompra = new DataTable();
        DataTable dtproducto = new DataTable();

        private void frmReporte_Load(object sender, EventArgs e)
        {
            cboproveedor.Items.Add(new ComboBoxItem() { Value = "0", Text = "Todos" });
            foreach (Proveedor pr in ProveedorLogica.Instancia.Listar()) {
                cboproveedor.Items.Add(new ComboBoxItem() { Value = pr.IdProveedor, Text = pr.RazonSocial });
            }
            cboproveedor.DisplayMember = "Text";
            cboproveedor.ValueMember = "Value";
            cboproveedor.SelectedIndex = 0;



            comboBox1.Items.Add(new ComboBoxItem() { Value = "0", Text = "Todos" });
            foreach (Proveedor pr in ProveedorLogica.Instancia.Listar())
            {
                comboBox1.Items.Add(new ComboBoxItem() { Value = pr.IdProveedor, Text = pr.RazonSocial });
            }
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            comboBox1.SelectedIndex = 0;
            

            cbocategoria.Items.Add(new ComboBoxItem() { Value = "0", Text = "Todos" });
            foreach (Categoria c in CategoriaLogica.Instancia.Listar())
            {
                cbocategoria.Items.Add(new ComboBoxItem() { Value = c.IdCategoria, Text = c.Descripcion });
            }
            cbocategoria.DisplayMember = "Text";
            cbocategoria.ValueMember = "Value";
            cbocategoria.SelectedIndex = 0;

            vercartera();

        }

        public void vercartera()
        {
            DateTime fechaFinal = DateTime.Today;
            DateTime FechaInicial = fechaFinal.AddMonths(-6);
            double suma,abonos,saldos;
            dtcompra = CompraLogica.Instancia.ReporteCartera(((ComboBoxItem)cboproveedor.SelectedItem).Value.ToString(), FechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"));
            if (dtcompra != null)
            {
                dgdatacartera.DataSource = dtcompra;
                suma = dgdatacartera.Rows.OfType<DataGridViewRow>().
                         Sum(x => Convert.ToDouble(x.Cells["Monto total"].Value));
                abonos = dgdatacartera.Rows.OfType<DataGridViewRow>().
                       Sum(x => Convert.ToDouble(x.Cells["pagos"].Value));

                //this.textBox1.Text = string.Format("{0:N2}", suma/2);
                //this.textBox2.Text = string.Format("{0:N2}", abonos/2);
                //this.textBox3.Text = string.Format("{0:N2}", (suma- abonos)/2);
            }
        }
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
            dtventa = VentaLogica.Instancia.Reporte(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"),Form1.oPersona.IdPersona.ToString()  );
            if (dtventa != null)
            {
                dgdataventa.DataSource = dtventa;
                double sumaVentas = dgdataventa.Rows.OfType<DataGridViewRow>().
                        Sum(x => Convert.ToDouble(x.Cells["Total Pagar"].Value));

                this.textBox4.Text = sumaVentas.ToString("0,00");
            }
        }

        private void btnconsultarcompras_Click(object sender, EventArgs e)
        {
            dtcompra = CompraLogica.Instancia.Reporte(((ComboBoxItem)cboproveedor.SelectedItem).Value.ToString(), txtfechainiciocompra.Value.ToString("dd/MM/yyyy"), txtfechafincompra.Value.ToString("dd/MM/yyyy"));
            if (dtcompra != null)
            {
                dgdatacompra.DataSource = dtcompra;
                double sumaVentas = dgdatacompra.Rows.OfType<DataGridViewRow>().
                       Sum(x => Convert.ToDouble(x.Cells["Monto Total"].Value)/2);

                this.textBox5.Text = sumaVentas.ToString("0,00");
            }
        }

        private void btnexportarcompras_Click(object sender, EventArgs e)
        {
            if (dgdatacompra.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Compra_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtcompra, "Informe");
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

        private void btnconsultarproducto_Click(object sender, EventArgs e)
        {
            dtproducto = ProductoLogica.Instancia.Reporte(((ComboBoxItem)cbocategoria.SelectedItem).Value.ToString());
            if (dtproducto != null)
            {
                dgdataproducto.DataSource = dtproducto;
            }
            
        }

        private void btnexportarproducto_Click(object sender, EventArgs e)
        {
            if (dgdataproducto.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Producto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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
        private void dgdatacompra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (this.dgdatacompra.Columns[e.ColumnIndex].Name == "pagos")
            //{
            //    if (e.Value != null)
            //    {
            //        if (e.Value.GetType() != typeof(System.DBNull))
            //        {
            //            //Stock menor a 20
            //            if (Convert.ToInt32(e.Value) <= 200)
            //            {
            //                e.CellStyle.BackColor = Color.LightSalmon;
            //                e.CellStyle.ForeColor = Color.Red;
            //            }
            //            //Stock menor a 10
            //            if (Convert.ToInt32(e.Value) <= 6000)
            //            {
            //                e.CellStyle.BackColor = Color.Salmon;
            //                e.CellStyle.ForeColor = Color.Red;
            //            }
            //        }
            //    }
            //}
        }

        private void dgdatacompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idFactura = "";
            string fecha = "";
            string idValor = "";
            string idFac = "";
            string idValdev = "";

            idFactura = dgdatacompra.Rows[dgdatacompra.CurrentRow.Index].Cells[4].Value.ToString();
            fecha = dgdatacompra.Rows[dgdatacompra.CurrentRow.Index].Cells[1].Value.ToString();
            idValor = dgdatacompra.Rows[dgdatacompra.CurrentRow.Index].Cells[5].Value.ToString();
            idFac = dgdatacompra.Rows[dgdatacompra.CurrentRow.Index].Cells[11].Value.ToString();
            idValdev = dgdatacompra.Rows[dgdatacompra.CurrentRow.Index].Cells[13].Value.ToString();
            using (var form = new FpagoFacturas(idFactura, fecha, idValor, idFac, idValdev))
            {
                form.ShowDialog(this);
            }
           
            
        }

        private void dgdatacompra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int vPagos;
            int vDeuda;
            foreach(DataGridViewRow Myrow in dgdatacompra.Rows)
        {
                vPagos = Convert.ToInt32(Myrow.Cells["pagos"].Value);
                vDeuda = Convert.ToInt32(Myrow.Cells[5].Value);
                vDeuda = vDeuda - vPagos;
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

        private void dgdataventa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                if   (String.IsNullOrEmpty(Myrow.Cells[13].Value.ToString()))
                {
                    vDev = 0;
                }
                else
                {
                    vDev = Convert.ToInt32(Myrow.Cells[13].Value);
                }
                
                vDeuda = vDeuda - (vPagos+ vDev);
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

        private void button1_Click(object sender, EventArgs e)
        {
            dtcompra = CompraLogica.Instancia.ReporteDev(((ComboBoxItem)cboproveedor.SelectedItem).Value.ToString(), dateTimePicker2.Value.ToString("dd/MM/yyyy"), dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            if (dtcompra != null)
            {
                dataGridView1.DataSource = dtcompra;
                double sumaVentas = dataGridView1.Rows.OfType<DataGridViewRow>().
                       Sum(x => Convert.ToDouble(x.Cells["Cantidad"].Value));

                this.textBox6.Text = sumaVentas.ToString("0,00");
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Devoluciones_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtcompra, "Informe");
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

        private void txtfechainicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtfechafin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
