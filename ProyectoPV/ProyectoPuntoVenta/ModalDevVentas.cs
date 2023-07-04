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
    public partial class ModalDevVentas : Form
    {
        DataTable dtDevEntas = new DataTable();
        public string idVenta { get; set; }
        public string totalPagar { get; set; }
        public DateTime fechaRegistro { get; set; }
        public ModalDevVentas()
        {
            InitializeComponent();
           




            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn BotonProducto = new DataGridViewButtonColumn();
            BotonProducto.HeaderText = "Seleccionar";
            BotonProducto.Width = 80;
            BotonProducto.Text = "";
            BotonProducto.Name = "btnSeleccionar";
            BotonProducto.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dataGridView1.Columns.Add(BotonProducto);
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("IdDevolucion", "IdDevolucion");
            dataGridView1.Columns.Add("Valor", "Valor");
            dataGridView1.Columns.Add("Fecha", "Fecha");
           

            dataGridView1.Columns["btnSeleccionar"].Width = 90;
            dataGridView1.Columns["Id"].Width = 100;
            dataGridView1.Columns["IdDevolucion"].Width = 50;
            dataGridView1.Columns["Valor"].Width = 100;
            dataGridView1.Columns["Fecha"].Width = 100;
           


            dataGridView1.Columns["Id"].Visible = false;
           


            //foreach (DataGridViewColumn cl in dataGridView1.Columns)
            //{
            //    if (cl.Visible == true && cl.Name != "btnSeleccionar")
            //    {
            //        cbobuscarproducto.Items.Add(new ComboBoxItem() { Value = cl.Name, Text = cl.HeaderText });
            //    }
            //}


            dtDevEntas = VentaLogica.Instancia.ReportreDevActivas();
            //dataGridView1.DataSource = dtDevEntas;
            int i = 0;
            foreach (DataRow rows in dtDevEntas.Rows)
            {
                i = i + 1;
                    int rowId = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowId];
                    row.Cells["Id"].Value = i.ToString();
                    row.Cells["IdDevolucion"].Value = rows[0].ToString();
                    row.Cells["Valor"].Value = rows[1].ToString();
                    row.Cells["Fecha"].Value = rows[2].ToString();

                    //row.Cells["PrecioVenta"].Value = p.PrecioVenta.ToString("0,00");
                }
        }

    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    //Id = int.Parse(dataGridView1.Rows[index].Cells["Id"].Value.ToString());
                    try
                    {
                        idVenta = dataGridView1.Rows[index].Cells["IdDevolucion"].Value.ToString();
                        totalPagar = dataGridView1.Rows[index].Cells["Valor"].Value.ToString();
                        //fechaRegistro = dataGridView1.Rows[index].Cells["PrecioVenta"].Value.ToString();
                    }
                    catch (Exception ex)
                    {

                    } 
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname != "btnSeleccionar")
                {
                    dataGridView1.Cursor = Cursors.Default;
                }
                else
                {
                    dataGridView1.Cursor = Cursors.Hand;
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex < 0)
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
    }
}
