using ProyectoPuntoVenta.Modelo;
using ProyectoPuntoVenta.Logica;
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
    public partial class FpagoFacturas : Form
    {
        public string IdPago { get; set; }
        public string FechaRegistro { get; set; }
        public string IdCompra { get; set; }
        public string MontoTotal { get; set; }
        public string IdPersona { get; set; }
        public string idFactura { get; set; }

        public string Note;
        DataTable dtproducto = new DataTable();
        public FpagoFacturas(string IdCompra, string FechaRegistro, string MontoTotal, string idFactura, string dev)
        {
            InitializeComponent();
            this.TxtFactura.Text = IdCompra.ToString();
            this.TxtFecha.Text = FechaRegistro.ToString();
            this.txtValor.Text = MontoTotal.ToString();
            this.Txtsec.Text = idFactura.ToString();
            this.textBox3.Text = dev.ToString();

            VerFacturas();
            calcularDif();
            if (String.IsNullOrEmpty(this.textBox3.Text))
            {
                this.textBox3.Text = "0";
            }
            int difPago = int.Parse(this.txtValor.Text) - (int.Parse(this.textBox2.Text)+ int.Parse(this.textBox3.Text));
            this.textBox4.Text = difPago.ToString("0,00");
            Txtsec.ReadOnly = true;
            Txtsec.Visible = false;
            this.textBox1.Focus();
            this.textBox1.Select();
        }
        public void VerFacturas()
        {

            dtproducto = ProductoLogica.Instancia.ReportePagosFact(this.TxtFactura.Text);
            if (dtproducto != null)
            {
                dgdataproducto.DataSource = dtproducto;
                //int suma = dgdataproducto.Rows.Cast<GridViewRow>().Sum(x => Convert.ToInt32(x.Cells[5].Text));
            }

        }
        public void calcularDif()
        {

            int total = dgdataproducto.Rows.Cast<DataGridViewRow>()
                .Sum(x => (int?)x.Cells[2].Value ?? 0);
            textBox2.Text = total.ToString();
            textBox2.ReadOnly = true;



            textBox1.Focus();
        }



        private void dgdataproducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgdataproducto.Columns[e.ColumnIndex].Name == "MontoTotal")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        //Stock menor a 20
                        if (Convert.ToInt32(e.Value) <= 200)
                        {
                            e.CellStyle.BackColor = Color.LightSalmon;
                            e.CellStyle.ForeColor = Color.Red;
                        }
                        //Stock menor a 10
                        if (Convert.ToInt32(e.Value) <= 6000)
                        {
                            e.CellStyle.BackColor = Color.Salmon;
                            e.CellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }
        private void btbPagar_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Indique valor  abono a registrar de la factura ", "Sistema POS");
                return;
            }
            if (string.IsNullOrEmpty(txtNote.Text))
            {
                MessageBox.Show("Indique Observaciones  abono a registrar de la factura ", "Sistema POS");
                return;
            }
            int difPago =( int.Parse(this.txtValor.Text)- int.Parse(this.textBox3.Text) ) - (int.Parse(this.textBox2.Text));
            if (difPago < int.Parse(textBox1.Text))
            {
                MessageBox.Show("Pago registrado es mayor a los abonos efectuados a la factura", "Sistema POS");
                textBox1.Focus();
                return;
            }
            if (MessageBox.Show("¿Desea realizar el pago ?", "Pagar factura", MessageBoxButtons.YesNo) == DialogResult.No)
            {

                MessageBox.Show("Pago factura cancelado");
                return;

            }
            

            pago objeto = new pago()
            {
                IdPersona = Form1.oPersona.IdPersona.ToString(),
                IdCompra = this.TxtFactura.Text,
                MontoTotal = this.textBox1.Text.Trim(),
                Note = this.txtNote.Text.Trim(),
                idFactura = this.Txtsec.Text.Trim(),
            };

            var resultado = false;
            if (int.Parse(this.textBox1.Text) != 0)
            {
                int id = PersonaLogica.Instancia.RegistrarPago(objeto);

                resultado = id != 0 ? true : false;

                //if (resultado)
                //{
                //    int rowId = dgdata.Rows.Add();
                //    DataGridViewRow row = dgdata.Rows[rowId];
                //    row.Cells["Id"].Value = id.ToString();
                //    row.Cells["NumeroDocumento"].Value = txtdocumento.Text.Trim();
                //    row.Cells["NombreCompleto"].Value = txtnombre.Text.Trim();
                //    row.Cells["Direccion"].Value = txtdireccion.Text.Trim();
                //    row.Cells["Telefono"].Value = txttelefono.Text.Trim();
                //    row.Cells["Cupo"].Value = textBox1.Text.Trim();
                //}


            }
            VerFacturas();
            calcularDif();

        }

       
    }
}
