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
using ClosedXML.Excel;

namespace ProyectoPuntoVenta
{
    public partial class frmGestion : Form
    {
        DataTable dtProd=new DataTable();
        public frmGestion()
        {
            InitializeComponent();
        }

        private void frmGestion_Load(object sender, EventArgs e)
        {
            #region CATEGORIA
            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn Boton = new DataGridViewButtonColumn();

            Boton.HeaderText = "Seleccionar";
            Boton.Width = 80;
            Boton.Text = "";
            Boton.Name = "btnSeleccionar";
            Boton.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdatacategoria.Columns.Add(Boton);
            dgdatacategoria.Columns.Add("Id", "Id");
            dgdatacategoria.Columns.Add("Descripcion", "Descripción");
                  
            dgdatacategoria.Columns["btnSeleccionar"].Width = 100;
            dgdatacategoria.Columns["Descripcion"].Width = 600;
            dgdatacategoria.Columns["Id"].Visible = false;

  
            foreach (Categoria p in CategoriaLogica.Instancia.Listar())
            {
                int rowId = dgdatacategoria.Rows.Add();
                DataGridViewRow row = dgdatacategoria.Rows[rowId];
                row.Cells["Id"].Value = p.IdCategoria.ToString();
                row.Cells["Descripcion"].Value = p.Descripcion;
            }
            #endregion

            #region PRODUCTO
            List<Categoria> lstc = CategoriaLogica.Instancia.Listar();
            if (lstc.Count > 0) {
                foreach (Categoria c in lstc)
                {
                    cbocategoria.Items.Add(new ComboBoxItem() { Value = c.IdCategoria, Text = c.Descripcion });
                }
                cbocategoria.DisplayMember = "Text";
                cbocategoria.ValueMember = "Value";
                cbocategoria.SelectedIndex = 0;
            }
            this.comboBox1.Items.Add("No");
            this.comboBox1.Items.Add("Si");
            this.comboBox1.SelectedIndex = 0;


            this.comboBox2.Items.Add("No");
            this.comboBox2.Items.Add("Si");
            this.comboBox2.SelectedIndex = 0;
            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn BotonProducto = new DataGridViewButtonColumn();
            BotonProducto.HeaderText = "Seleccionar";
            BotonProducto.Width = 80;
            BotonProducto.Text = "";
            BotonProducto.Name = "btnSeleccionar";
            BotonProducto.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdataproducto.Columns.Add(BotonProducto);
            dgdataproducto.Columns.Add("Id", "Id");
            dgdataproducto.Columns.Add("Codigo", "Código");
            dgdataproducto.Columns.Add("Nombre", "Nombre");
            dgdataproducto.Columns.Add("Descripcion", "Descripción");
            dgdataproducto.Columns.Add("Categoria", "Categoria");
            dgdataproducto.Columns.Add("Stock", "Stock");
            dgdataproducto.Columns.Add("PrecioVenta", "PrecioVenta");
            dgdataproducto.Columns.Add("Pesado", "Pesado");
            dgdataproducto.Columns.Add("Promocion", "Promocion");
            dgdataproducto.Columns.Add("Iva", "Iva");


            dgdataproducto.Columns["btnSeleccionar"].Width = 90;
            dgdataproducto.Columns["Codigo"].Width = 90;
            dgdataproducto.Columns["Nombre"].Width = 190;
            dgdataproducto.Columns["Descripcion"].Width = 200;
            dgdataproducto.Columns["Categoria"].Width = 140;
            dgdataproducto.Columns["PrecioVenta"].Width=100;
            dgdataproducto.Columns["Stock"].Width = 100;
            dgdataproducto.Columns["Pesado"].Width = 50;
            dgdataproducto.Columns["Promocion"].Width = 50;
            dgdataproducto.Columns["Iva"].Width = 50;

            dgdataproducto.Columns["Id"].Visible = false;

            foreach (DataGridViewColumn cl in dgdataproducto.Columns)
            {
                if (cl.Visible == true && cl.Name != "btnSeleccionar")
                {
                    cbobuscarproducto.Items.Add(new ComboBoxItem() { Value = cl.Name, Text = cl.HeaderText });
                }
            }
            cbobuscarproducto.DisplayMember = "Text";
            cbobuscarproducto.ValueMember = "Value";
            cbobuscarproducto.SelectedIndex = 0;

            verProductos();

            

            #endregion

            #region TIENDA

            Tienda objeto = TiendaLogica.Instancia.Obtener();
            txtdocumentotienda.Text = objeto.Documento;
            txtrazonsocialtienda.Text = objeto.RazonSocial;
            txtcorreotienda.Text = objeto.Correo;
            txttelefonotienda.Text = objeto.Telefono;
          
            #endregion

        }
        public void verProductos()
        {
            dgdataproducto.Rows.Clear();
            //if (dtProd.Rows.Count>0)
              //   dtProd.Clear();
            foreach (Producto p in ProductoLogica.Instancia.Listar())
            {
                
                int rowId = dgdataproducto.Rows.Add();
                DataGridViewRow row = dgdataproducto.Rows[rowId];
                row.Cells["Id"].Value = p.IdProducto.ToString();
                row.Cells["Codigo"].Value = p.Codigo;
                row.Cells["Nombre"].Value = p.Nombre;
                row.Cells["Descripcion"].Value = p.Descripcion;
                row.Cells["Categoria"].Value = p.oCategoria.Descripcion;
                row.Cells["PrecioVenta"].Value = p.PrecioVenta;
                row.Cells["Stock"].Value = p.Stock;
                row.Cells["Pesado"].Value = p.Pesado;
                row.Cells["promocion"].Value = p.Promocion;
                row.Cells["Iva"].Value = p.iva;
            }
            
             dtProd = dgdataproducto.DataSource as DataTable;
        }

        private void btnguardarcategoria_Click(object sender, EventArgs e)
        {

            Categoria objeto = new Categoria()
            {
                IdCategoria = int.Parse(txtidcategoria.Text),
                Descripcion = txtdescripcioncategoria.Text.Trim(),
            };

            var resultado = false;
            if (int.Parse(txtidcategoria.Text) == 0)
            {
                int id = CategoriaLogica.Instancia.Registrar(objeto);
                resultado = id != 0 ? true : false;
                if (resultado)
                {
                    int rowId = dgdatacategoria.Rows.Add();
                    DataGridViewRow row = dgdatacategoria.Rows[rowId];
                    row.Cells["Id"].Value = id.ToString();
                    row.Cells["Descripcion"].Value = txtdescripcioncategoria.Text.Trim();
                }
            }
            else
            {
                resultado = CategoriaLogica.Instancia.Modificar(objeto);
                if (resultado)
                {
                    DataGridViewRow row = dgdatacategoria.Rows[int.Parse(txtindexcategoria.Text) - 1];
                    row.Cells["Id"].Value = txtidcategoria.Text;
                    row.Cells["Descripcion"].Value = txtdescripcioncategoria.Text.Trim();

                }
            }

            if (resultado) {
                cbocategoria.Items.Clear();
                List<Categoria> lstc = CategoriaLogica.Instancia.Listar();
                if (lstc.Count > 0)
                {
                    foreach (Categoria c in lstc)
                    {
                        cbocategoria.Items.Add(new ComboBoxItem() { Value = c.IdCategoria, Text = c.Descripcion });
                    }
                    cbocategoria.DisplayMember = "Text";
                    cbocategoria.ValueMember = "Value";
                    cbocategoria.SelectedIndex = 0;
                }
                LimpiarCategoria();
            }
            else
                MessageBox.Show("No se pudo guardar los cambios\nRevise los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgdatacategoria_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dgdatacategoria.Columns[e.ColumnIndex].Name;
                if (colname != "btnSeleccionar")
                {
                    dgdatacategoria.Cursor = Cursors.Default;
                }
                else
                {
                    dgdatacategoria.Cursor = Cursors.Hand;
                }
            }

        }

        private void dgdatacategoria_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnlimpiarcategoria_Click(object sender, EventArgs e)
        {
            LimpiarCategoria();
        }

        private void LimpiarCategoria()
        {

            txtindexcategoria.Text = "0";
            txtidcategoria.Text = "0";
            txtdescripcioncategoria.Text = "";
        }

        private void dgdatacategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgdatacategoria.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    txtindexcategoria.Text = (index + 1).ToString();
                    txtidcategoria.Text = dgdatacategoria.Rows[index].Cells["Id"].Value.ToString();
                    txtdescripcioncategoria.Text = dgdatacategoria.Rows[index].Cells["Descripcion"].Value.ToString();
                }
            }
        }

        private void btneliminarcategoria_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtindexcategoria.Text) > 0)
            {
                if (MessageBox.Show("¿Desea eliminar la categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                    bool respuesta = CategoriaLogica.Instancia.Eliminar(int.Parse(txtidcategoria.Text));
                    if (respuesta)
                    {
                        cbocategoria.Items.Clear();
                        List<Categoria> lstc = CategoriaLogica.Instancia.Listar();
                        if (lstc.Count > 0)
                        {
                            foreach (Categoria c in lstc)
                            {
                                cbocategoria.Items.Add(new ComboBoxItem() { Value = c.IdCategoria, Text = c.Descripcion });
                            }
                            cbocategoria.DisplayMember = "Text";
                            cbocategoria.ValueMember = "Value";
                            cbocategoria.SelectedIndex = 0;
                        }
                        dgdatacategoria.Rows.RemoveAt(int.Parse(txtindexcategoria.Text) - 1);
                        LimpiarCategoria();
                    }
                    else
                        MessageBox.Show("No se pudo eliminar el registro\nRevise los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void btnguardarproducto_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtcodigoproducto.Text))
            {
                txtcodigoproducto.Select();
                return;
            }
            if (string.IsNullOrEmpty(this.TxtIva.Text))
            {
                TxtIva.Select();
                return;
            }
            Producto objeto = new Producto()
            {
                IdProducto = int.Parse(txtidproducto.Text),
                Codigo = txtcodigoproducto.Text.Trim(),
                Nombre = txtnombreproducto.Text.Trim(),
                Descripcion = txtdescripcionproducto.Text.Trim(),
                PrecioVenta = decimal.Parse(TxtPrecioVenta.Text),
                Pesado = this.comboBox1.Text,
                Promocion = this.comboBox2.Text,
                Stock = int.Parse(this.TxtUnidades.Text),
                iva = int.Parse(this.TxtIva.Text),
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((ComboBoxItem)cbocategoria.SelectedItem).Value.ToString()) }
            };

            var resultado = false;
            if (int.Parse(txtidproducto.Text) == 0)
            {
                int id = ProductoLogica.Instancia.Registrar(objeto);
                resultado = id != 0 ? true : false;
                if (resultado)
                {
                    int rowId = dgdataproducto.Rows.Add();
                    DataGridViewRow row = dgdataproducto.Rows[rowId];
                    row.Cells["Id"].Value = id.ToString();
                    row.Cells["Codigo"].Value = txtcodigoproducto.Text.Trim();
                    row.Cells["Nombre"].Value = txtnombreproducto.Text.Trim();
                    row.Cells["Descripcion"].Value = txtdescripcionproducto.Text.Trim();
                    row.Cells["PrecioVenta"].Value = TxtPrecioVenta.Text.Trim();
                    row.Cells["Categoria"].Value = ((ComboBoxItem)cbocategoria.SelectedItem).Text;
                    row.Cells["Stock"].Value = "0";
                    row.Cells["Pesado"].Value = this.comboBox1.Text.Trim() ;
                    row.Cells["Promocion"].Value = this.comboBox2.Text.Trim();
                    row.Cells["Iva"].Value = this.TxtIva.Text.Trim();
                }

            }
            else
            {
                resultado = ProductoLogica.Instancia.Modificar(objeto);
                if (resultado)
                {
                    DataGridViewRow row = dgdataproducto.Rows[int.Parse(txtindexproducto.Text) - 1];
                    row.Cells["Id"].Value = txtidproducto.Text;
                    row.Cells["Codigo"].Value = txtcodigoproducto.Text.Trim();
                    row.Cells["Nombre"].Value = txtnombreproducto.Text.Trim();
                    row.Cells["Descripcion"].Value = txtdescripcionproducto.Text.Trim();
                    row.Cells["PrecioVenta"].Value = TxtPrecioVenta.Text.Trim();
                    row.Cells["Categoria"].Value = ((ComboBoxItem)cbocategoria.SelectedItem).Text;
                    row.Cells["Pesado"].Value=this.comboBox1.Text.Trim();
                    row.Cells["Promocion"].Value = this.comboBox2.Text.Trim();
                }

            }

            if (resultado)
                LimpiarProducto();
            else
                MessageBox.Show("No se pudo guardar los cambios\nRevise los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            verProductos();
            txtcodigoproducto.Select();
        }

        private void dgdataproducto_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dgdataproducto.Columns[e.ColumnIndex].Name;
                if (colname != "btnSeleccionar")
                {
                    dgdataproducto.Cursor = Cursors.Default;
                }
                else
                {
                    dgdataproducto.Cursor = Cursors.Hand;
                }
            }
        }

        private void dgdataproducto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnlimpiarproducto_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
        }


        private void LimpiarProducto()
        {
            txtindexproducto.Text = "0";
            txtidproducto.Text = "0";
            txtcodigoproducto.Text = "";
            txtnombreproducto.Text = "";
            txtdescripcionproducto.Text = "";
            cbocategoria.SelectedIndex = 0;
            TxtPrecioVenta.Text = "";
            this.TxtUnidades.Text = "0";
        }

        private void dgdataproducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdataproducto.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    txtindexproducto.Text = (index + 1).ToString();
                    txtidproducto.Text = dgdataproducto.Rows[index].Cells["Id"].Value.ToString();
                    txtcodigoproducto.Text = dgdataproducto.Rows[index].Cells["Codigo"].Value.ToString();
                    txtnombreproducto.Text = dgdataproducto.Rows[index].Cells["Nombre"].Value.ToString();
                    txtdescripcionproducto.Text = dgdataproducto.Rows[index].Cells["Descripcion"].Value.ToString();
                    TxtPrecioVenta.Text = dgdataproducto.Rows[index].Cells["PrecioVenta"].Value.ToString();
                    this.TxtUnidades.Text = dgdataproducto.Rows[index].Cells["Stock"].Value.ToString();
                    this.TxtIva.Text= dgdataproducto.Rows[index].Cells["Iva"].Value.ToString();

                    this.comboBox2.Text= dgdataproducto.Rows[index].Cells["Promocion"].Value.ToString();
                    this.comboBox1.Text = dgdataproducto.Rows[index].Cells["Pesado"].Value.ToString();

                    foreach (ComboBoxItem item in cbocategoria.Items)
                    {
                        if (item.Text == dgdataproducto.Rows[index].Cells["Categoria"].Value.ToString())
                        {
                            int item_index = cbocategoria.Items.IndexOf(item);
                            cbocategoria.SelectedIndex = item_index;
                            break;
                        }
                    }


                }
            }
        }

        private void btneliminarproducto_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtindexproducto.Text) > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                    bool respuesta = ProductoLogica.Instancia.Eliminar(int.Parse(txtidproducto.Text));
                    if (respuesta)
                    {
                        dgdataproducto.Rows.RemoveAt(int.Parse(txtindexproducto.Text) - 1);
                        LimpiarProducto();
                    }
                    else
                        MessageBox.Show("No se pudo eliminar el registro\nRevise los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                verProductos();


            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ComboBoxItem)cbobuscarproducto.SelectedItem).Value.ToString();

            if (dgdataproducto.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdataproducto.Rows)
                {
                    string valor = row.Cells[columnaFiltro].Value.ToString().Trim();

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().Contains(txtbuscarproducto.Text.Trim()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtbuscarproducto.Text = "";
            foreach (DataGridViewRow row in dgdataproducto.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnguardartienda_Click(object sender, EventArgs e)
        {
            if (TiendaLogica.Instancia.Modificar(new Tienda()
            {
                Documento = txtdocumentotienda.Text,
                RazonSocial = txtrazonsocialtienda.Text,
                Correo = txtcorreotienda.Text,
                Telefono = txttelefonotienda.Text
            })) {
                MessageBox.Show("Se guardaron los datos ingresados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
                MessageBox.Show("No se pudo guardar los datos ingresados\nRevise los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int respuesta = ProductoLogica.Instancia.copySeguriddad();
            if (respuesta==-1)
            {
                MessageBox.Show("Copia de seguridad realizada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("No se pudo realizar la copia de seguridad, contactar a soporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnexportarventa_Click(object sender, EventArgs e)
        {
            
            if (dgdataproducto.Rows.Count > 0)
            {
                //ProductoLogica.Instancia.Listar()
                dtProd = ProductoLogica.Instancia.ListarExport();
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Inventario_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string informe = "Informe";
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtProd, informe);
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Inventario Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string opPantalla = "1";
            if (radioButton1.Checked == true)
            {
                opPantalla = "1";
            }
            if (radioButton2.Checked == true)
            {
                opPantalla = "2";
            }

            if (radioButton3.Checked == true)
            {
                opPantalla = "3";
            }
            int respuesta = ProductoLogica.Instancia.configPantalla(opPantalla);
            if (respuesta == -1)
            {
                MessageBox.Show("Configuración exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error  en Configuración exitosamente, contactar a soporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
    }

