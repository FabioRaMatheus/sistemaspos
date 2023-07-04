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
using System.IO;
using System.Threading;
using System.Drawing.Printing;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ProyectoPuntoVenta
{
    public partial class frmMultiventa : Form
    {
        private static int _IdPersona;
        private delegate void DelegadoAcceso(string accion);
        public int idventaImpre;
        public frmMultiventa()
        {
            InitializeComponent();
        }
        
        public frmMultiventa(int idpersona = 0)
        {
            InitializeComponent();
            _IdPersona = idpersona;
            //txtidproveedor.Text = "1";
            //this.textBox4.Text = "0";
            //this.textBox5.Text = "0";
            //btnbuscarcliente.PerformClick();
          
            this.Tabprimario.SelectedTab = tabPage1;
            this.txtidproveedor.Select();
            this.txtidproveedor.Focus();
            txtidproveedor.Text = "Documento del cliente";
            txtidproveedor.BackColor = Color.Aqua;
            //txtcodigoproducto.Focus();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            double p_Saldo;

            using (var form = new ModalPersona())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproveedor3.Text = form.documento;
                    txtnombrecliente3.Text = form.nombre;
                    txtidcliente3.Text = form.idcliente;
                    txtcodigoproducto3.Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double p_Saldo;

            using (var form = new ModalPersona())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproveedor2.Text = form.documento;
                    txtnombrecliente2.Text = form.nombre;
                    txtidcliente2.Text = form.idcliente;
                    txtcodigoproducto2.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    txtcodigoproducto.Focus();
                }
            }
        }

        private void frmMultiventa_Load(object sender, EventArgs e)
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
            dgdata.Columns.Add("Iva", "Iva");

            dgdata.Columns["btnEliminar"].Width = 50;
            dgdata.Columns["NombreProducto"].Width = 280;
            dgdata.Columns["Cantidad"].Width = 140;
            dgdata.Columns["PrecioVenta"].Width = 140;
            dgdata.Columns["SubTotal"].Width = 140;
            dgdata.Columns["Iva"].Width = 140;

            dgdata.Columns["IdProducto"].Visible = false;
            txtcodigoproducto.Select();







            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn Boton2 = new DataGridViewButtonColumn();

            Boton2.HeaderText = "Eliminar";
            Boton2.Width = 100;
            Boton2.Text = "";
            Boton2.Name = "btnEliminar";
            Boton2.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdata2.Columns.Add(Boton2);
            dgdata2.Columns.Add("IdProducto", "IdProducto");
            dgdata2.Columns.Add("NombreProducto", "Nombre Producto");
            dgdata2.Columns.Add("Cantidad", "Cantidad");
            dgdata2.Columns.Add("PrecioVenta", "Precio Venta");
            dgdata2.Columns.Add("SubTotal", "SubTotal");
            dgdata2.Columns.Add("Iva", "Iva");

            dgdata2.Columns["btnEliminar"].Width = 50;
            dgdata2.Columns["NombreProducto"].Width = 280;
            dgdata2.Columns["Cantidad"].Width = 140;
            dgdata2.Columns["PrecioVenta"].Width = 140;
            dgdata2.Columns["SubTotal"].Width = 140;
            dgdata2.Columns["Iva"].Width = 140;

            dgdata2.Columns["IdProducto"].Visible = false;



            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn Boton3 = new DataGridViewButtonColumn();

            Boton3.HeaderText = "Eliminar";
            Boton3.Width = 100;
            Boton3.Text = "";
            Boton3.Name = "btnEliminar";
            Boton3.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdata3.Columns.Add(Boton3);
            dgdata3.Columns.Add("IdProducto", "IdProducto");
            dgdata3.Columns.Add("NombreProducto", "Nombre Producto");
            dgdata3.Columns.Add("Cantidad", "Cantidad");
            dgdata3.Columns.Add("PrecioVenta", "Precio Venta");
            dgdata3.Columns.Add("SubTotal", "SubTotal");
            dgdata3.Columns.Add("Iva", "Iva");

            dgdata3.Columns["btnEliminar"].Width = 50;
            dgdata3.Columns["NombreProducto"].Width = 280;
            dgdata3.Columns["Cantidad"].Width = 140;
            dgdata3.Columns["PrecioVenta"].Width = 140;
            dgdata3.Columns["SubTotal"].Width = 140;
            dgdata3.Columns["Iva"].Width = 140;

            dgdata3.Columns["IdProducto"].Visible = false;






            cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Factura", Text = "Factura" });
            //cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Devolucion", Text = "Devolucion" });
            cbotipodocumento.DisplayMember = "Text";
            cbotipodocumento.ValueMember = "Value";
            cbotipodocumento.SelectedIndex = 0;

            cbotipodocumento2.Items.Add(new ComboBoxItem() { Value = "Factura", Text = "Factura" });
            //cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Devolucion", Text = "Devolucion" });
            cbotipodocumento2.DisplayMember = "Text";
            cbotipodocumento2.ValueMember = "Value";
            cbotipodocumento2.SelectedIndex = 0;


            cbotipodocumento3.Items.Add(new ComboBoxItem() { Value = "Factura", Text = "Factura" });
            //cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Devolucion", Text = "Devolucion" });
            cbotipodocumento3.DisplayMember = "Text";
            cbotipodocumento3.ValueMember = "Value";
            cbotipodocumento3.SelectedIndex = 0;

            this.Tabprimario.SelectedTab = tabPage1;
            this.txtidproveedor.Select();
            this.txtidproveedor.Focus();
            txtidproveedor.Text = "Documento del cliente";
            txtidproveedor.BackColor = Color.Aqua;

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
                    txtprecioventa.Text = Convert.ToString(Convert.ToDouble(form.precioventa).ToString("N2"));
                    // this.textBox6.Text = form.promocion.ToString();
                    txtIva.Text = form.Iva;

                    //if (form.codigo == "1")
                    //{
                    //    this.label18.Visible = false;
                    //    this.txtcantidad.ReadOnly = true;
                    //    this.txtcantidad.Enabled = true;
                    //    this.txtprecioventa.Enabled = true;
                    //    this.txtprecioventa.ReadOnly = false;
                    //    this.txtnombreproducto.Text = "1";
                    //}
                    //else
                    //{


                    //this.txtnombreproducto.Text = "0";
                    ////form.precioventa.ToLower();
                    //if (form.pesado == "Si")
                    //{
                    //    this.label18.Visible = true;
                    //    this.txtcantidad.ReadOnly = false;
                    //    this.txtcantidad.Enabled = false;

                    //}
                    //else
                    //{
                    //if (form.promocion == "Si")
                    //{
                    //    this.label18.Visible = true;
                    //    this.txtcantidad.ReadOnly = false;
                    //    this.txtcantidad.Enabled = true;
                    //    this.txtprecioventa.Enabled = true;
                    //    this.txtprecioventa.ReadOnly = false;
                    //}
                    //else
                    //{
                    //this.label18.Visible = false;
                    this.txtcantidad.ReadOnly = true;
                    this.txtcantidad.Enabled = true;
                    this.txtprecioventa.Enabled = false;
                    this.txtprecioventa.ReadOnly = true;
                    //    }
                    //}
                    //if (form.promocion != "Si")
                    //{
                    this.btnagregarproducto.PerformClick();
                    //}
                    //else
                    //{
                    this.txtprecioventa.Select();

                    //}
                }
            }
            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var form = new ModalProducto())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtcodigoproducto2.Text = form.codigo;
                    txtstock2.Text = form.stock;
                    txtnombreproducto2.Text = form.nombre;
                    txtidproducto2.Text = form.idproducto.ToString();
                    txtprecioventa2.Text = Convert.ToString(Convert.ToDouble(form.precioventa).ToString("N2"));
                    // this.textBox6.Text = form.promocion.ToString();
                    txtIva2.Text = form.Iva;

                    //if (form.codigo == "1")
                    //{
                    //    this.label18.Visible = false;
                    //    this.txtcantidad.ReadOnly = true;
                    //    this.txtcantidad.Enabled = true;
                    //    this.txtprecioventa.Enabled = true;
                    //    this.txtprecioventa.ReadOnly = false;
                    //    this.txtnombreproducto.Text = "1";
                    //}
                    //else
                    //{


                    //this.txtnombreproducto.Text = "0";
                    ////form.precioventa.ToLower();
                    //if (form.pesado == "Si")
                    //{
                    //    this.label18.Visible = true;
                    //    this.txtcantidad.ReadOnly = false;
                    //    this.txtcantidad.Enabled = false;

                    //}
                    //else
                    //{
                    //if (form.promocion == "Si")
                    //{
                    //    this.label18.Visible = true;
                    //    this.txtcantidad.ReadOnly = false;
                    //    this.txtcantidad.Enabled = true;
                    //    this.txtprecioventa.Enabled = true;
                    //    this.txtprecioventa.ReadOnly = false;
                    //}
                    //else
                    //{
                    //this.label18.Visible = false;
                    this.txtcantidad2.ReadOnly = true;
                    this.txtcantidad2.Enabled = true;
                    this.txtprecioventa2.Enabled = false;
                    this.txtprecioventa2.ReadOnly = true;
                    //    }
                    //}
                    //if (form.promocion != "Si")
                    //{
                    this.btnagregarproducto2.PerformClick();
                    //}
                    //else
                    //{
                    this.txtprecioventa2.Select();

                    //}
                }
            }
            //}
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (var form = new ModalProducto())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtcodigoproducto3.Text = form.codigo;
                    txtstock3.Text = form.stock;
                    txtnombreproducto3.Text = form.nombre;
                    txtidproducto3.Text = form.idproducto.ToString();
                    txtprecioventa3.Text = Convert.ToString(Convert.ToDouble(form.precioventa).ToString("N2"));
                    // this.textBox6.Text = form.promocion.ToString();
                    Tabprimario.Text = form.Iva;

                    //if (form.codigo == "1")
                    //{
                    //    this.label18.Visible = false;
                    //    this.txtcantidad.ReadOnly = true;
                    //    this.txtcantidad.Enabled = true;
                    //    this.txtprecioventa.Enabled = true;
                    //    this.txtprecioventa.ReadOnly = false;
                    //    this.txtnombreproducto.Text = "1";
                    //}
                    //else
                    //{


                    //this.txtnombreproducto.Text = "0";
                    ////form.precioventa.ToLower();
                    //if (form.pesado == "Si")
                    //{
                    //    this.label18.Visible = true;
                    //    this.txtcantidad.ReadOnly = false;
                    //    this.txtcantidad.Enabled = false;

                    //}
                    //else
                    //{
                    //if (form.promocion == "Si")
                    //{
                    //    this.label18.Visible = true;
                    //    this.txtcantidad.ReadOnly = false;
                    //    this.txtcantidad.Enabled = true;
                    //    this.txtprecioventa.Enabled = true;
                    //    this.txtprecioventa.ReadOnly = false;
                    //}
                    //else
                    //{
                    //this.label18.Visible = false;
                    this.txtcantidad3.ReadOnly = true;
                    this.txtcantidad3.Enabled = true;
                    this.txtprecioventa3.Enabled = false;
                    this.txtprecioventa3.ReadOnly = true;
                    //    }
                    //}
                    //if (form.promocion != "Si")
                    //{
                    this.btnagregarproducto3.PerformClick();
                    //}
                    //else
                    //{
                    this.txtprecioventa3.Select();

                    //}
                }
            }
            //}
        }
        public void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtstock.Text = "0";
            txtcodigoproducto.Text = "";
            txtnombreproducto.Text = "";
            txtcantidad.Text = "1";
            txtprecioventa.Text = "";
        }
        public void limpiarProducto2()
        {
            txtidproducto2.Text = "0";
            txtstock2.Text = "0";
            txtcodigoproducto2.Text = "";
            txtnombreproducto2.Text = "";
            txtcantidad2.Text = "1";
            txtprecioventa2.Text = "";
        }
        public void limpiarProducto3()
        {
            txtidproducto3.Text = "0";
            txtstock3.Text = "0";
            txtcodigoproducto3.Text = "";
            txtnombreproducto3.Text = "";
            txtcantidad3.Text = "1";
            txtprecioventa3.Text = "";
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
            txttotalpagar.Text = total.ToString("0,0");

        }
        private void calcularTotal2()
        {

            decimal total2 = 0;
            decimal totalIva2 = 0;
            if (dgdata2.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata2.Rows)
                {
                    total2 += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-CO"));
                    totalIva2 += Convert.ToDecimal(row.Cells["Iva"].Value.ToString(), new CultureInfo("es-CO"));
                }
            }

            //txttotalpagar.Text = Convert.ToString(total.ToString("N2"));
            txttotalpagar2.Text = total2.ToString("0,0");

        }
        private void calcularTotal3()
        {

            decimal total3 = 0;
            decimal totalIva3 = 0;
            if (dgdata3.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata3.Rows)
                {
                    total3 += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-CO"));
                    totalIva3 += Convert.ToDecimal(row.Cells["Iva"].Value.ToString(), new CultureInfo("es-CO"));
                }
            }

            //txttotalpagar.Text = Convert.ToString(total.ToString("N2"));
            txttotalpagar3.Text = total3.ToString("0,0");

        }
        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            decimal precioventa = 0;
            decimal subtotal;
            decimal iva19 = 0;
            decimal iva5 = 0;
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
                int can = dgdata.Rows.Count;

                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }

            }

            // if (!producto_existe) {

            //bool resultado = VentaLogica.Instancia.ControlStock(int.Parse(txtidproducto.Text), int.Parse(txtcantidad.Text.Trim()), true);

            //if (resultado)
            //{
            int rowId = dgdata.Rows.Add();
            DataGridViewRow row = dgdata.Rows[rowId];

            //if (this.label18.Visible == true)
            //{
            //    if (this.textBox6.Text == "No")
            //    {
            row.Cells["Cantidad"].Value = 1;
            txtcantidad.Text = "1";
            //}
            //else
            //{
            //    row.Cells["Cantidad"].Value = txtcantidad.Text;

            //}

            //}
            //else
            //{
            //    row.Cells["Cantidad"].Value = txtcantidad.Text.Trim();
            //}
            subtotal = Convert.ToDecimal(txtcantidad.Text.Trim()) * precioventa;
            if (iva19 == 19)
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
            //}
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

        private void dgdata_MouseEnter(object sender, EventArgs e)
        {
           
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
        private bool calcularcambio()
        {

            bool respuesta = true;
            decimal pagacon;

            decimal total = Convert.ToDecimal(txttotalpagar.Text, new CultureInfo("es-CO"));

            if (!decimal.TryParse(RemoverCAracteresNoValidos(txtpagocon.Text.Trim()), NumberStyles.AllowDecimalPoint, new CultureInfo("es-CO"), out pagacon))
            {
                respuesta = false;
            }
            else
            {
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
        private bool calcularcambio2()
        {

            bool respuesta2 = true;
            decimal pagacon2;

            decimal total2 = Convert.ToDecimal(txttotalpagar2.Text, new CultureInfo("es-CO"));

            if (!decimal.TryParse(RemoverCAracteresNoValidos(txtpagocon2.Text.Trim()), NumberStyles.AllowDecimalPoint, new CultureInfo("es-CO"), out pagacon2))
            {
                respuesta2 = false;
            }
            else
            {
                if (pagacon2 < total2)
                {
                    txtcambio2.Text = "0";
                }
                else
                {
                    decimal cambio2 = pagacon2 - total2;
                    txtcambio2.Text = cambio2.ToString("0,0");
                }
            }
            return respuesta2;
        }
        private bool calcularcambio3()
        {

            bool respuesta3 = true;
            decimal pagacon3;

            decimal total3 = Convert.ToDecimal(txttotalpagar3.Text, new CultureInfo("es-CO"));

            if (!decimal.TryParse(RemoverCAracteresNoValidos(txtpagocon3.Text.Trim()), NumberStyles.AllowDecimalPoint, new CultureInfo("es-CO"), out pagacon3))
            {
                respuesta3 = false;
            }
            else
            {
                if (pagacon3 < total3)
                {
                    txtcambio3.Text = "0";
                }
                else
                {
                    decimal cambio3 = pagacon3 - total3;
                    txtcambio3.Text = cambio3.ToString("0,0");
                }
            }
            return respuesta3;
        }
        private string RemoverCAracteresNoValidos(string palabras)
        {
            return Regex.Replace(palabras, "[.]+", "", RegexOptions.Compiled);
        }
        private void btncalcular_Click(object sender, EventArgs e)
        {
            if (txtpagocon.Text.Length > 0)
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
            txtpagocon.Select();
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
        private void limpiar()
        {
            //txtdocumentocliente.Text = "";
            //txtnombrecliente.Text = "";
            txttotalpagar.Text = "0";
            txtpagocon.Text = "0";
            txtcambio.Text = "0";
            dgdata.Rows.Clear();

        }
        private void limpiar2()
        {
            //txtdocumentocliente.Text = "";
            //txtnombrecliente.Text = "";
            txttotalpagar2.Text = "0";
            txtpagocon2.Text = "0";
            txtcambio2.Text = "0";
            dgdata2.Rows.Clear();

        }
        private void limpiar3()
        {
            //txtdocumentocliente.Text = "";
            //txtnombrecliente.Text = "";
            txttotalpagar3.Text = "0";
            txtpagocon3.Text = "0";
            txtcambio3.Text = "0";
            dgdata3.Rows.Clear();

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
            e.Graphics.DrawString("Caja:" + ipCaja.Substring(vtaIp, 1).ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cajero:" + Form1.oPersona.Nombre.ToString(), font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Nit/CC:" + txtidproveedor.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Cliente:" + txtnombrecliente.Text, font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Tel:" + " ", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));
            e.Graphics.DrawString("Dir:" + " ", font, Brushes.Black, new Rectangle(0, y += 20, width, 35));

            Font fontDet = new Font("Arial", 5, FontStyle.Regular, GraphicsUnit.Point);

            e.Graphics.DrawString("================================", fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);
            y = y + 40;
            //e.Graphics.DrawString("Detalle de la compra", fontDet, Brushes.Black, new Rectangle(0, y, width, 35), stringFormat);

            e.Graphics.DrawString("CANT", fontDet, Brushes.Black, new Rectangle(5, y, widthDet, 30));
            e.Graphics.DrawString("PRODUCTO", fontDet, Brushes.Black, new Rectangle(30, y, widthDet, 30));
            e.Graphics.DrawString("VL/UN", fontDet, Brushes.Black, new Rectangle(170, y, widthDet, 30));
            e.Graphics.DrawString("V/TOTA", fontDet, Brushes.Black, new Rectangle(210, y, widthDet, 30));


            StringBuilder tr = new StringBuilder();
            foreach (DetalleVenta dv in oDetalleVenta)
            {
                y = y + 15;
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
            e.Graphics.DrawString(" ", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Total a pagar:" + oVenta.TotalPagar.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Pagado con:" + oVenta.PagoCon.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("Cambio:" + oVenta.Cambio.ToString("0,0", new CultureInfo("es-Co")), fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("================================", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);
            e.Graphics.DrawString("REGIMEN SIMPLIFICADO:", fontDetPie, Brushes.Black, new Rectangle(0, y += 20, width, 35), stringFormat);




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
            //if (this.textBox4.Text != "0")
            //{

            //    int pagacon = int.Parse(RemoverCAracteresNoValidos(txtpagocon.Text)) + int.Parse(this.textBox5.Text.ToString());
            //    pagocliente = pagacon;

            //}
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
                //this.textBox3.Text = "0";
                //this.textBox4.Text = "0";
                //this.textBox5.Text = "0";
                return;

            }


            string v_TipoVenta = "";
            //if (textBox1.Text != "0")
            //{

            //    if (dgdata.Rows.Count > 0)
            //    {
            //        foreach (DataGridViewRow row in dgdata.Rows)
            //        {
            //            string codProd = this.textBox2.Text;
            //            if (codProd == "1")
            //            {
            //                v_TipoVenta = "P";
            //            }
            //            else
            //            {
            //v_TipoVenta = "C";
            //            }

            //        }
            //    }

            //}
            //else
            //{
            v_TipoVenta = "V";



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

                    //}
                    //descargo el inventario

                    bool resultado = VentaLogica.Instancia.ControlStock(int.Parse(row.Cells["IdProducto"].Value.ToString()), int.Parse(row.Cells["Cantidad"].Value.ToString()), true);

                    //if (resultado)
                    //{


                    //}


                    ////
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



                //if (this.textBox5.Text != "0")
                //{
                //    cruzarDev(int.Parse(this.textBox3.Text), idventa);
                //}
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
                        //this.textBox3.Text = "0";
                        //this.textBox4.Text = "0";
                        //this.textBox5.Text = "0";

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




                        //this.textBox3.Text = "0";
                        //this.textBox4.Text = "0";
                        //this.textBox5.Text = "0";

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

        private void btnagregarproducto2_Click(object sender, EventArgs e)
        {
            decimal precioventa2 = 0;
            decimal subtotal2;
            decimal iva192 = 0;
            decimal iva52 = 0;
            bool producto_existe2 = false;




            if (int.Parse(txtidproducto2.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto primero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (int.Parse(txtstock2.Text) < int.Parse(txtcantidad2.Text))
            {
                MessageBox.Show("No hay suficiente stock del producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarProducto2();
                txtcodigoproducto2.Focus();
                return;
            }

            bool errorVenta = false;
            try
            {
                precioventa2 = Convert.ToDecimal(txtprecioventa2.Text.Trim(), new CultureInfo("es-CO"));
                iva192 = Convert.ToDecimal(txtIva2.Text.Trim(), new CultureInfo("es-CO"));
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

            foreach (DataGridViewRow fila in dgdata2.Rows)
            {
                int can = dgdata2.Rows.Count;

                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto2.Text)
                {
                    producto_existe2 = true;
                    break;
                }

            }

            // if (!producto_existe) {

            //bool resultado = VentaLogica.Instancia.ControlStock(int.Parse(txtidproducto.Text), int.Parse(txtcantidad.Text.Trim()), true);

            //if (resultado)
            //{
            int rowId = dgdata2.Rows.Add();
            DataGridViewRow row = dgdata2.Rows[rowId];

            //if (this.label18.Visible == true)
            //{
            //    if (this.textBox6.Text == "No")
            //    {
            row.Cells["Cantidad"].Value = 1;
            txtcantidad2.Text = "1";
            //}
            //else
            //{
            //    row.Cells["Cantidad"].Value = txtcantidad.Text;

            //}

            //}
            //else
            //{
            //    row.Cells["Cantidad"].Value = txtcantidad.Text.Trim();
            //}
            subtotal2 = Convert.ToDecimal(txtcantidad2.Text.Trim()) * precioventa2;
            if (iva192 == 19)
            {
                iva192 = Convert.ToDecimal(txtcantidad2.Text.Trim()) * (iva192 / 100) * precioventa2;
            }
            if (iva192 == 5)
            {
                iva192 = Convert.ToDecimal(txtcantidad2.Text.Trim()) * (iva192 / 100) * precioventa2;
            }
            if (iva192 == 1)
            {
                iva192 = 0;
            }


            row.Cells["IdProducto"].Value = txtidproducto2.Text;
            row.Cells["NombreProducto"].Value = txtnombreproducto2.Text.Trim();
            row.Cells["PrecioVenta"].Value = precioventa2.ToString("0,0");
            row.Cells["SubTotal"].Value = subtotal2.ToString("0,0");
            row.Cells["iva"].Value = iva192.ToString("0,0");

            calcularTotal2();
            limpiarProducto2();
            txtcodigoproducto2.Focus();
            //}
            //}
        }

        private void dgdata2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata2.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    int _idproducto = int.Parse(dgdata2.Rows[index].Cells["IdProducto"].Value.ToString());
                    int _cantidad = int.Parse(dgdata2.Rows[index].Cells["Cantidad"].Value.ToString());
                    bool resultado = VentaLogica.Instancia.ControlStock(_idproducto, _cantidad, false);

                    if (resultado)
                    {
                        dgdata2.Rows.RemoveAt(index);
                        calcularTotal();
                    }
                }
            }
        }

        private void dgdata3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata3.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    int _idproducto = int.Parse(dgdata3.Rows[index].Cells["IdProducto"].Value.ToString());
                    int _cantidad = int.Parse(dgdata3.Rows[index].Cells["Cantidad"].Value.ToString());
                    bool resultado = VentaLogica.Instancia.ControlStock(_idproducto, _cantidad, false);

                    if (resultado)
                    {
                        dgdata3.Rows.RemoveAt(index);
                        calcularTotal();
                    }
                }
            }
        }

        private void dgdata2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dgdata2.Columns[e.ColumnIndex].Name;
                if (colname != "btnEliminar")
                {
                    dgdata2.Cursor = Cursors.Default;
                }
                else
                {
                    dgdata2.Cursor = Cursors.Hand;
                }
            }
        }

        private void dgdata3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dgdata3.Columns[e.ColumnIndex].Name;
                if (colname != "btnEliminar")
                {
                    dgdata3.Cursor = Cursors.Default;
                }
                else
                {
                    dgdata3.Cursor = Cursors.Hand;
                }
            }
        }

        private void dgdata2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgdata3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btnagregarproducto3_Click(object sender, EventArgs e)
        {
            decimal precioventa3 = 0;
            decimal subtotal3;
            decimal iva193 = 0;
            decimal iva532 = 0;
            bool producto_existe3= false;




            if (int.Parse(txtidproducto3.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto primero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (int.Parse(txtstock3.Text) < int.Parse(txtcantidad3.Text))
            {
                MessageBox.Show("No hay suficiente stock del producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarProducto3();
                txtcodigoproducto3.Focus();
                return;
            }

            bool errorVenta = false;
            try
            {
                precioventa3 = Convert.ToDecimal(txtprecioventa3.Text.Trim(), new CultureInfo("es-CO"));
                iva193 = Convert.ToDecimal(Tabprimario.Text.Trim(), new CultureInfo("es-CO"));
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

            foreach (DataGridViewRow fila in dgdata3.Rows)
            {
                int can = dgdata2.Rows.Count;

                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto3.Text)
                {
                    producto_existe3 = true;
                    break;
                }

            }

            // if (!producto_existe) {

            //bool resultado = VentaLogica.Instancia.ControlStock(int.Parse(txtidproducto.Text), int.Parse(txtcantidad.Text.Trim()), true);

            //if (resultado)
            //{
            int rowId = dgdata3.Rows.Add();
            DataGridViewRow row = dgdata3.Rows[rowId];

            //if (this.label18.Visible == true)
            //{
            //    if (this.textBox6.Text == "No")
            //    {
            row.Cells["Cantidad"].Value = 1;
            txtcantidad3.Text = "1";
            //}
            //else
            //{
            //    row.Cells["Cantidad"].Value = txtcantidad.Text;

            //}

            //}
            //else
            //{
            //    row.Cells["Cantidad"].Value = txtcantidad.Text.Trim();
            //}
            subtotal3 = Convert.ToDecimal(txtcantidad2.Text.Trim()) * precioventa3;
            if (iva193 == 19)
            {
                iva193 = Convert.ToDecimal(txtcantidad2.Text.Trim()) * (iva193 / 100) * precioventa3;
            }
            if (iva193 == 5)
            {
                iva193 = Convert.ToDecimal(txtcantidad2.Text.Trim()) * (iva193 / 100) * precioventa3;
            }
            if (iva193 == 1)
            {
                iva193 = 0;
            }


            row.Cells["IdProducto"].Value = txtidproducto3.Text;
            row.Cells["NombreProducto"].Value = txtnombreproducto3.Text.Trim();
            row.Cells["PrecioVenta"].Value = precioventa3.ToString("0,0");
            row.Cells["SubTotal"].Value = subtotal3.ToString("0,0");
            row.Cells["iva"].Value = iva193.ToString("0,0");

            calcularTotal3();
            limpiarProducto3();
            txtcodigoproducto3.Focus();
            //}
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtpagocon3.Text.Length > 0)
            {
                double numero3 = Convert.ToDouble(txtpagocon3.Text);
                // puedes probas estas dos maneras de aplicar formato
                // primera:
                txtpagocon3.Text = numero3.ToString("N0");
                // segunda:
                //txtpagocon.Text = string.Format("###,###,###,00", numero);
                txtpagocon3.Text = string.Format("{0:c0}", txtpagocon3.Text);

                if (!calcularcambio3())
                {
                    MessageBox.Show("Error al convertir el tipo de moneda - Paga con\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            txtpagocon3.Select(txtpagocon3.Text.Length, 0);
            txtpagocon3.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtpagocon2.Text.Length > 0)
            {
                double numero2 = Convert.ToDouble(txtpagocon2.Text);
                // puedes probas estas dos maneras de aplicar formato
                // primera:
                txtpagocon2.Text = numero2.ToString("N0");
                // segunda:
                //txtpagocon.Text = string.Format("###,###,###,00", numero);
                txtpagocon2.Text = string.Format("{0:c0}", txtpagocon2.Text);

                if (!calcularcambio2())
                {
                    MessageBox.Show("Error al convertir el tipo de moneda - Paga con\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            txtpagocon2.Select(txtpagocon2.Text.Length, 0);
            txtpagocon2.Select();
        }

        private void btnterminarventa2_Click(object sender, EventArgs e)
        {
            string iva192 = "0";
            string iva52 = "0";


            if (txtidproveedor2.Text.Trim() == "" || txtnombrecliente2.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar todos los datos del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidproveedor2.Select();
                return;
            }

            if (dgdata2.Rows.Count < 1)
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



            if (txtpagocon2.Text.Trim() == "0")
            {
                MessageBox.Show("Debe ingresar con cuanto paga el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagocon2.Focus();
                return;
            }

            if (!calcularcambio2())
            {
                MessageBox.Show("Error al convertir el tipo de moneda - Paga con\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal totalVaidar2 = Convert.ToDecimal(txttotalpagar2.Text, new CultureInfo("es-CO"));
            int pagocliente2 = int.Parse(RemoverCAracteresNoValidos(txtpagocon2.Text));
            //caso si hay una devolucion autoriada
            //_____________________________________________
            //if (this.textBox4.Text != "0")
            //{

            //    int pagacon = int.Parse(RemoverCAracteresNoValidos(txtpagocon.Text)) + int.Parse(this.textBox5.Text.ToString());
            //    pagocliente = pagacon;

            //}
            //________________________________________
            if (pagocliente2 < totalVaidar2)
            {
                MessageBox.Show("Debe ingresar un valor mayor o igual a valor de la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagocon2.Text = "0";
                txtpagocon2.Focus();
                return;
            }

            if (MessageBox.Show("¿Desea realizar el pago ?", "Pagar factura", MessageBoxButtons.YesNo) == DialogResult.No)
            {

                MessageBox.Show("Pago cancelado");
                limpiar2();
                txtcodigoproducto2.Focus();
                //this.textBox3.Text = "0";
                //this.textBox4.Text = "0";
                //this.textBox5.Text = "0";
                return;

            }


            string v_TipoVenta2 = "";
            //if (textBox1.Text != "0")
            //{

            //    if (dgdata.Rows.Count > 0)
            //    {
            //        foreach (DataGridViewRow row in dgdata.Rows)
            //        {
            //            string codProd = this.textBox2.Text;
            //            if (codProd == "1")
            //            {
            //                v_TipoVenta = "P";
            //            }
            //            else
            //            {
            //v_TipoVenta = "C";
            //            }

            //        }
            //    }

            //}
            //else
            //{
            v_TipoVenta2 = "V";



            Venta oVenta2 = new Venta()
            {
                TipoDocumento = ((ComboBoxItem)cbotipodocumento.SelectedItem).Value.ToString(),
                oPersona = new Persona() { IdPersona = _IdPersona },
                DocumentoCliente = txtidproveedor2.Text.Trim(),
                NombreCliente = txtnombrecliente2.Text.Trim(),
                TotalPagar = Convert.ToDecimal(txttotalpagar2.Text, new CultureInfo("es-Co")),
                PagoCon = Convert.ToDecimal(RemoverCAracteresNoValidos(txtpagocon2.Text), new CultureInfo("es-Co")),
                Cambio = Convert.ToDecimal(txtcambio2.Text, new CultureInfo("es-Co")),
                TipoVenta = v_TipoVenta2.ToString()

            };

            List<DetalleVenta> olista2 = new List<DetalleVenta>();
            if (dgdata2.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata2.Rows)
                {
                    olista2.Add(new DetalleVenta()
                    {
                        oProducto = new Producto() { IdProducto = int.Parse(row.Cells["IdProducto"].Value.ToString()) },
                        Cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString()),
                        PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString(), new CultureInfo("es-Co")),
                        SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-Co"))

                    });

                    //}
                    //descargo el inventario

                    bool resultado2 = VentaLogica.Instancia.ControlStock(int.Parse(row.Cells["IdProducto"].Value.ToString()), int.Parse(row.Cells["Cantidad"].Value.ToString()), true);

                    //if (resultado)
                    //{


                    //}


                    ////
                }
            }
            oVenta2.oDetalleVenta = olista2;



            int idventa2 = VentaLogica.Instancia.Registrar(oVenta2);
            if (idventa2 != 0)
            {
                DataTable dtIva2= VentaLogica.Instancia.reporteIva(idventa2.ToString());
                if (dtIva2.Rows.Count > 0)
                {

                    foreach (DataRow row in dtIva2.Rows)
                    {
                        if (row["iva"].ToString() == "5")
                        {
                            iva52 = row["valor"].ToString();
                        }
                        if (row["iva"].ToString() == "19")
                        {
                            iva192 = row["valor"].ToString();
                        }
                    }
                }



                //if (this.textBox5.Text != "0")
                //{
                //    cruzarDev(int.Parse(this.textBox3.Text), idventa);
                //}
                if (MessageBox.Show("La venta fue registrada\n¿Desea imprimir el ticket ahora?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ImprimirVenta imp = new ImprimirVenta(idventa);
                    //imp.ShowDialog();
                    //this.textBox3.Text = "0";
                    //this.textBox4.Text = "0";
                    //this.textBox5.Text = "0";



                    imprimir(idventa2);

                    using (var form = new ModalVenta())
                    {
                        //var p = this.Parent.PointToScreen(this.Location);
                        //p.Offset((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
                        //form.StartPosition = FormStartPosition.Manual;
                        form.valorFactura = this.txttotalpagar2.Text;
                        form.valorPagado = this.txtpagocon2.Text;
                        form.valorVuelas = txtcambio2.Text;
                        form.numfac = idventa2.ToString();
                        form.valor19 = iva192.ToString();
                        form.valor5 = iva52.ToString();
                        var result = form.ShowDialog();
                        //this.textBox3.Text = "0";
                        //this.textBox4.Text = "0";
                        //this.textBox5.Text = "0";

                    }


                }
                else
                {
                    printDocument1 = new System.Drawing.Printing.PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += abrircaja;
                    printDocument1.Print();




                    using (var form2 = new ModalVenta())
                    {

                        //var p = this.Parent.PointToScreen(this.Location);
                        //p.Offset((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
                        //form.StartPosition = FormStartPosition.Manual;

                        //form.StartPosition=FormStartPosition.CenterScreen;




                        form2.valorFactura = this.txttotalpagar2.Text;
                        form2.valorPagado = this.txtpagocon2.Text;
                        form2.valorVuelas = txtcambio2.Text;
                        form2.numfac = idventa2.ToString();
                        form2.valor19 = iva192.ToString();
                        form2.valor5 = iva52.ToString();
                        var result = form2.ShowDialog();




                        //this.textBox3.Text = "0";
                        //this.textBox4.Text = "0";
                        //this.textBox5.Text = "0";

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
            limpiar2();
            this.txtcodigoproducto2.Focus();

        }

        private void btnterminarventa3_Click(object sender, EventArgs e)
        {
            string iva193 = "0";
            string iva53= "0";


            if (txtidproveedor3.Text.Trim() == "" || txtnombrecliente3.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar todos los datos del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidproveedor3.Select();
                return;
            }

            if (dgdata3.Rows.Count < 1)
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



            if (txtpagocon3.Text.Trim() == "0")
            {
                MessageBox.Show("Debe ingresar con cuanto paga el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagocon3.Focus();
                return;
            }

            if (!calcularcambio3())
            {
                MessageBox.Show("Error al convertir el tipo de moneda - Paga con\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal totalVaidar3 = Convert.ToDecimal(txttotalpagar3.Text, new CultureInfo("es-CO"));
            int pagocliente3 = int.Parse(RemoverCAracteresNoValidos(txtpagocon2.Text));
            //caso si hay una devolucion autoriada
            //_____________________________________________
            //if (this.textBox4.Text != "0")
            //{

            //    int pagacon = int.Parse(RemoverCAracteresNoValidos(txtpagocon.Text)) + int.Parse(this.textBox5.Text.ToString());
            //    pagocliente = pagacon;

            //}
            //________________________________________
            if (pagocliente3 < totalVaidar3)
            {
                MessageBox.Show("Debe ingresar un valor mayor o igual a valor de la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagocon3.Text = "0";
                txtpagocon3.Focus();
                return;
            }

            if (MessageBox.Show("¿Desea realizar el pago ?", "Pagar factura", MessageBoxButtons.YesNo) == DialogResult.No)
            {

                MessageBox.Show("Pago cancelado");
                limpiar3();
                txtcodigoproducto3.Focus();
                //this.textBox3.Text = "0";
                //this.textBox4.Text = "0";
                //this.textBox5.Text = "0";
                return;

            }


            string v_TipoVenta3 = "";
            //if (textBox1.Text != "0")
            //{

            //    if (dgdata.Rows.Count > 0)
            //    {
            //        foreach (DataGridViewRow row in dgdata.Rows)
            //        {
            //            string codProd = this.textBox2.Text;
            //            if (codProd == "1")
            //            {
            //                v_TipoVenta = "P";
            //            }
            //            else
            //            {
            //v_TipoVenta = "C";
            //            }

            //        }
            //    }

            //}
            //else
            //{
            v_TipoVenta3 = "V";



            Venta oVenta3 = new Venta()
            {
                TipoDocumento = ((ComboBoxItem)cbotipodocumento.SelectedItem).Value.ToString(),
                oPersona = new Persona() { IdPersona = _IdPersona },
                DocumentoCliente = txtidproveedor3.Text.Trim(),
                NombreCliente = txtnombrecliente3.Text.Trim(),
                TotalPagar = Convert.ToDecimal(txttotalpagar3.Text, new CultureInfo("es-Co")),
                PagoCon = Convert.ToDecimal(RemoverCAracteresNoValidos(txtpagocon3.Text), new CultureInfo("es-Co")),
                Cambio = Convert.ToDecimal(txtcambio3.Text, new CultureInfo("es-Co")),
                TipoVenta = v_TipoVenta3.ToString()

            };

            List<DetalleVenta> olista3 = new List<DetalleVenta>();
            if (dgdata3.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata3.Rows)
                {
                    olista3.Add(new DetalleVenta()
                    {
                        oProducto = new Producto() { IdProducto = int.Parse(row.Cells["IdProducto"].Value.ToString()) },
                        Cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString()),
                        PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString(), new CultureInfo("es-Co")),
                        SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-Co"))

                    });

                    //}
                    //descargo el inventario

                    bool resultado3 = VentaLogica.Instancia.ControlStock(int.Parse(row.Cells["IdProducto"].Value.ToString()), int.Parse(row.Cells["Cantidad"].Value.ToString()), true);

                    //if (resultado)
                    //{


                    //}


                    ////
                }
            }
            oVenta3.oDetalleVenta = olista3;



            int idventa3 = VentaLogica.Instancia.Registrar(oVenta3);
            if (idventa3 != 0)
            {
                DataTable dtIva3 = VentaLogica.Instancia.reporteIva(idventa3.ToString());
                if (dtIva3.Rows.Count > 0)
                {

                    foreach (DataRow row in dtIva3.Rows)
                    {
                        if (row["iva"].ToString() == "5")
                        {
                            iva53 = row["valor"].ToString();
                        }
                        if (row["iva"].ToString() == "19")
                        {
                            iva193= row["valor"].ToString();
                        }
                    }
                }



                //if (this.textBox5.Text != "0")
                //{
                //    cruzarDev(int.Parse(this.textBox3.Text), idventa);
                //}
                if (MessageBox.Show("La venta fue registrada\n¿Desea imprimir el ticket ahora?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ImprimirVenta imp = new ImprimirVenta(idventa);
                    //imp.ShowDialog();
                    //this.textBox3.Text = "0";
                    //this.textBox4.Text = "0";
                    //this.textBox5.Text = "0";



                    imprimir(idventa3);

                    using (var form = new ModalVenta())
                    {
                        //var p = this.Parent.PointToScreen(this.Location);
                        //p.Offset((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
                        //form.StartPosition = FormStartPosition.Manual;
                        form.valorFactura = this.txttotalpagar2.Text;
                        form.valorPagado = this.txtpagocon2.Text;
                        form.valorVuelas = txtcambio2.Text;
                        form.numfac = idventa3.ToString();
                        form.valor19 = iva193.ToString();
                        form.valor5 = iva53.ToString();
                        var result = form.ShowDialog();
                        //this.textBox3.Text = "0";
                        //this.textBox4.Text = "0";
                        //this.textBox5.Text = "0";

                    }


                }
                else
                {
                    printDocument1 = new System.Drawing.Printing.PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += abrircaja;
                    printDocument1.Print();




                    using (var form3 = new ModalVenta())
                    {

                        //var p = this.Parent.PointToScreen(this.Location);
                        //p.Offset((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
                        //form.StartPosition = FormStartPosition.Manual;

                        //form.StartPosition=FormStartPosition.CenterScreen;




                        form3.valorFactura = this.txttotalpagar2.Text;
                        form3.valorPagado = this.txtpagocon2.Text;
                        form3.valorVuelas = txtcambio2.Text;
                        form3.numfac = idventa3.ToString();
                        form3.valor19 = iva193.ToString();
                        form3.valor5 = iva53.ToString();
                        var result = form3.ShowDialog();




                        //this.textBox3.Text = "0";
                        //this.textBox4.Text = "0";
                        //this.textBox5.Text = "0";

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
            limpiar3();
            this.txtcodigoproducto3.Focus();
        }

        private void frmMultiventa_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == (Keys.E) )
                {
                this.Tabprimario.SelectedTab = tabPage1;
                this.txtidproveedor.Select();
                this.txtidproveedor.Focus();
                txtidproveedor.Text = "Documento del cliente";
                txtidproveedor.BackColor = Color.Aqua;
                //TabControl tb = new TabControl();
                //tb.SelectedTab = tabPage1;
                //tb.Enabled = false;
                //tb.SelectedIndex = 0;
                //e.Handled = true;
            }
                else if (e.KeyCode == Keys.S)
                {
                this.Tabprimario.SelectedTab = tabPage2;
                txtidproveedor2.Text = "Documento del cliente";
                this.txtidproveedor2.Select();
                this.txtidproveedor2.Focus();
                txtidproveedor2.BackColor = Color.Aqua;
                //TabControl tb = new TabControl();
                //tb.SelectedTab = tabPage2;
                //tb.Enabled = false;
                //tb.SelectedIndex = 1;
                //e.Handled = true;
            }
                else if (e.KeyCode == Keys.C)
                {
                this.Tabprimario.SelectedTab = tabPage3;
                txtidproveedor3.Text = "Documento del cliente";
                this.txtidproveedor3.Select();
                this.txtidproveedor3.Focus();
                txtidproveedor3.BackColor = Color.Aqua;
                //TabControl tb = new TabControl();
                //tb.SelectedTab = tabPage3;
                //tb.Enabled = true;
                //tb.SelectedIndex = 2;
                //e.Handled = true;
            }

          
        }

        private void frmMultiventa_KeyPress(object sender, KeyPressEventArgs e)
        {
        //    TabControl tb1 = new TabControl();
        //    tb1.SelectedTab = tabPage1;
        //    tb1.SelectedIndex = 0;

        //    TabControl tb2 = new TabControl();
        //    tb2.SelectedTab = tabPage1;
        //    tb2.SelectedIndex = 1;


        //    TabControl tb3 = new TabControl();
        //    tb3.SelectedTab = tabPage1;
        //    tb3.SelectedIndex = 2;


            //TabPage t = new TabPage();
            ////tabControl1.TabPages[2];
            //tabControl1.SelectTab(t); //go to tab


            if (e.KeyChar == (char)Keys.E)
            {
                this.Tabprimario.SelectedTab = tabPage1;
                
                ////TabControl tb = new TabControl();
                //tb1.SelectedTab = tabPage1;
                ////tb1.Enabled = false;
                ////this.tabPage1.Select();
                ////this.tabPage1.Focus();
                //tb1.SelectedIndex = 0;
                //tb2.SelectedIndex = 1;
                //tb3.SelectedIndex = 2;

                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.T)
            {
                this.Tabprimario.SelectedTab = tabPage2;
              

                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.C)
            {
                this.Tabprimario.SelectedTab = tabPage3;
                

                e.Handled = true;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            this.txtidproveedor.Select();
            this.txtidproveedor.Focus();
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            this.txtidproveedor2.Select();
            this.txtidproveedor2.Focus();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            this.txtidproveedor3.Select();
            this.txtidproveedor3.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
             if  (this.Tabprimario.SelectedTab==this.tabPage1)
                {
                txtidproveedor.Text = "On tab 1";
                txtidproveedor.Focus();
                  }
             else
                if (this.Tabprimario.SelectedTab == this.tabPage2)
                {
                txtidproveedor2.Text = "On tab 2";
                txtidproveedor2.Focus();
                }
        }
    }
}
