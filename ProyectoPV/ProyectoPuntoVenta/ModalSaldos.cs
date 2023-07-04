using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPuntoVenta.Logica;
using ProyectoPuntoVenta.Modelo;
using ClosedXML.Excel;
using System.Globalization;

namespace ProyectoPuntoVenta
{
    public partial class ModalSaldos : Form
    {
        public string idVenta  { get; set; }
        public string NumeroDocumento  { get; set; }
        public string PagoCon  { get; set; }
        public string TotalPagar  { get; set; }
        public string Cambio { get; set; }

        public string TipoVenta { get; set; }

        public string VarNombre { get; set; }

        public string NumDoc;
        DataTable dtventa = new DataTable();
        public ModalSaldos()
        {
            InitializeComponent();
            this.textBox1.Text = NumDoc;
        }

        private void ModalSaldos_Load(object sender, EventArgs e)
        {
            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn BotonProducto = new DataGridViewButtonColumn();
            BotonProducto.HeaderText = "Seleccionar";
            BotonProducto.Width = 80;
            BotonProducto.Text = "";
            BotonProducto.Name = "btnSeleccionar";
            BotonProducto.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdataproducto.Columns.Add(BotonProducto);
            dgdataproducto.Columns.Add("FechaRegistro", "FechaRegistro");
            dgdataproducto.Columns.Add("idVenta", "idVenta");
            dgdataproducto.Columns.Add("NumeroDocumento", "NumeroDocumento");
            dgdataproducto.Columns.Add("PagoCon", "PagoCon");
            dgdataproducto.Columns.Add("TotalPagar", "TotalPagar");
            dgdataproducto.Columns.Add("TipoVenta", "TipoVenta");
            dgdataproducto.Columns.Add("Cambio", "Cambio");


            dgdataproducto.Columns["btnSeleccionar"].Width = 4;
            dgdataproducto.Columns["FechaRegistro"].Width = 100;
            dgdataproducto.Columns["idVenta"].Width = 100;
            dgdataproducto.Columns["NumeroDocumento"].Width = 200;
            dgdataproducto.Columns["PagoCon"].Width = 210;
            dgdataproducto.Columns["TotalPagar"].Width = 150;
            dgdataproducto.Columns["TipoVenta"].Width = 100;
            dgdataproducto.Columns["Cambio"].Width = 100;
            decimal debito=0, credito=0, saldo=0;

            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String"); 
            column.ColumnName = "FechaRegistro";
            dtventa.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "idVenta";
            dtventa.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "NumeroDocumento";
            dtventa.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "PagoCon";
            dtventa.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "TotalPagar";
            dtventa.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TipoVenta";
            dtventa.Columns.Add(column);


            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Cambio";
            dtventa.Columns.Add(column);


            //dtventa.Columns.Add("FechaRegistro");
            //dtventa.Columns.Add("idVenta");
            //dtventa.Columns.Add("NumeroDocumento");
            //dtventa.Columns.Add("PagoCon");
            //dtventa.Columns.Add("TotalPagar");
            //dtventa.Columns.Add("TipoVenta");


            foreach (Venta p in ProductoLogica.Instancia.ListarVentas(NumDoc.ToString()))
            {
                int rowId = dgdataproducto.Rows.Add();
                DataGridViewRow row = dgdataproducto.Rows[rowId];
                row.Cells["FechaRegistro"].Value = p.FechaRegistro;
                row.Cells["idVenta"].Value = p.IdVenta;
                row.Cells["NumeroDocumento"].Value = p.NumeroDocumento;
                row.Cells["PagoCon"].Value = p.PagoCon;
                row.Cells["TotalPagar"].Value = p.TotalPagar;
                row.Cells["TipoVenta"].Value = p.TipoVenta;
                row.Cells["Cambio"].Value = p.Cambio;
                if (p.TipoVenta == "Pago")
                {
                    debito = debito + p.TotalPagar;
                }
                if (p.TipoVenta== "Compra")
                {
                    credito = credito + p.TotalPagar;
                }
                DataRow newRow = dtventa.NewRow();
                newRow["FechaRegistro"] = p.FechaRegistro;
                newRow["idVenta"] = p.IdVenta;
                newRow["NumeroDocumento"] = p.NumeroDocumento;
                newRow["PagoCon"] = (double)p.PagoCon;
                newRow["TotalPagar"] =(double) p.TotalPagar;
                newRow["TipoVenta"] =p.TipoVenta.ToString();
                newRow["Cambio"] = (double)p.Cambio;
                dtventa.Rows.Add(newRow);
                dtventa.AcceptChanges();
            }
            saldo = credito - debito;
            this.textBox1.Text = credito.ToString("N0");
            this.textBox2.Text = debito.ToString("N0");
            this.textBox3.Text = saldo.ToString("N0");
            this.textBox4.Text = NumDoc.ToString();
            this.label5.Text = "Estado de cuenta para:"+ VarNombre.ToString();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgdataproducto.Rows.Count > 0)
            {
               
                
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Estado de cuenta_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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

        private void button2_Click(object sender, EventArgs e)
        {
            //ImprimirVenta imp = new ImprimirVenta(idventa);
            //imp.ShowDialog();
            //this.textBox3.Text = "0";
            //this.textBox4.Text = "0";
            //this.textBox5.Text = "0";
        }

        private void dgdataproducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == this.dgdataproducto.Columns["IdVenta"].Index)
            //{
                //  public ImprimirVenta(int idventa = 0 ,string pagos="",string recibio="",string cambio="",string fechai="", string fechaf ="")
                string idFactura = dgdataproducto.Rows[e.RowIndex].Cells["idVenta"].Value.ToString();
                 //Decimal cambio =Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString(), new CultureInfo("es-Co")),
                 Decimal cambio = Convert.ToDecimal(dgdataproducto.Rows[e.RowIndex].Cells["Cambio"].Value.ToString(), new CultureInfo("es-Co"));
                //string recibio = dgdataproducto.Rows[e.RowIndex].Cells[4].Value.ToString();
                Decimal recibio = Convert.ToDecimal(dgdataproducto.Rows[e.RowIndex].Cells["PagoCon"].Value.ToString(), new CultureInfo("es-Co"));
                // string pagos = dgdataproducto.Rows[e.RowIndex].Cells[5].Value.ToString();
                 Decimal pagos = Convert.ToDecimal(dgdataproducto.Rows[e.RowIndex].Cells["TotalPagar"].Value.ToString(), new CultureInfo("es-Co"));
            string fechai = dgdataproducto.Rows[e.RowIndex].Cells[1].Value.ToString();  //FechaRegistro
                ImprimirVenta imp = new ImprimirVenta(System.Int32.Parse(idFactura), pagos.ToString(), recibio.ToString(), cambio.ToString(), fechai, fechai);
                imp.ShowDialog();
           // }


        }
    }
}
