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

namespace ProyectoPuntoVenta
{
    public partial class ModalFactura : Form
    {

        public int idproducto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string precioventa { get; set; }
        public string Cantidad { get; set; }
        public string PrecioCompra { get; set; }
        public int codproducto { get; set; }


        public string pesado { get; set; }
        public ModalFactura(string numFac,string numProd)
        {
            InitializeComponent();
            this.textBox1.Text = numFac;
            this.textBox2.Text = numProd;

        }

        private void ModalFactura_Load(object sender, EventArgs e)
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
            dgdataproducto.Columns.Add("Id", "Id");
            dgdataproducto.Columns.Add("Codigo", "Código");
            dgdataproducto.Columns.Add("IdCompra", "IdCompra");
            dgdataproducto.Columns.Add("idProducto", "idProducto");
            dgdataproducto.Columns.Add("Nombre", "Nombre");
            dgdataproducto.Columns.Add("Cantidad", "Cantidad");
            dgdataproducto.Columns.Add("PrecioCompra", "PrecioCompra");
            dgdataproducto.Columns.Add("PrecioVenta", "PrecioVenta");

            dgdataproducto.Columns["btnSeleccionar"].Width = 90;
            dgdataproducto.Columns["id"].Width = 100;
            dgdataproducto.Columns["Codigo"].Width = 100;
            dgdataproducto.Columns["IdCompra"].Width = 100;
            dgdataproducto.Columns["idProducto"].Width = 50;
            dgdataproducto.Columns["Nombre"].Width = 210;
            dgdataproducto.Columns["Cantidad"].Width = 150;
            dgdataproducto.Columns["PrecioCompra"].Width = 100;
            dgdataproducto.Columns["PrecioVenta"].Width = 100;


            dgdataproducto.Columns["Id"].Visible = false;
            dgdataproducto.Columns["PrecioCompra"].Visible = true;
            dgdataproducto.Columns["PrecioVenta"].Visible = true;

            foreach (DataGridViewColumn cl in dgdataproducto.Columns)
            {
                if (cl.Visible == true && cl.Name != "btnSeleccionar")
                {
                    //cbobuscarproducto.Items.Add(new ComboBoxItem() { Value = cl.Name, Text = cl.HeaderText });
                }
            }
            

            foreach (Devolucion p in ProductoLogica.Instancia.ListarFacturaDev(textBox1.Text,textBox2.Text))
            {
                int rowId = dgdataproducto.Rows.Add();
                DataGridViewRow row = dgdataproducto.Rows[rowId];
                row.Cells["Id"].Value = p.idproveedor;
                row.Cells["Codigo"].Value = p.NumeroDocumento;
                row.Cells["IdCompra"].Value = p.IdCompra;
                row.Cells["idProducto"].Value = p.IdProducto;
                row.Cells["Nombre"].Value = p.Descripcion;
                row.Cells["Cantidad"].Value = p.Cantidad.ToString();
                row.Cells["PrecioCompra"].Value = p.PrecioCompra.ToString();
                row.Cells["PrecioVenta"].Value = p.PrecioVenta.ToString();
            }
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

        private void dgdataproducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgdataproducto.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    idproducto = int.Parse(dgdataproducto.Rows[index].Cells["id"].Value.ToString());
                    codproducto = int.Parse(dgdataproducto.Rows[index].Cells["idProducto"].Value.ToString());
                    nombre = dgdataproducto.Rows[index].Cells["Nombre"].Value.ToString();
                    precioventa = dgdataproducto.Rows[index].Cells["PrecioVenta"].Value.ToString();
                    PrecioCompra = dgdataproducto.Rows[index].Cells["PrecioCompra"].Value.ToString();
                    Cantidad = dgdataproducto.Rows[index].Cells["Cantidad"].Value.ToString();
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
