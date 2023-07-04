using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Net;


namespace ProyectoPuntoVenta
{
    public partial class Form1 : Form
    {
        public static Persona oPersona;
        private PrintDocument printDocument1;

        public Form1(Persona objeto= null)
        {
            InitializeComponent();
            oPersona = objeto;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblusuario.Text = oPersona.Nombre;
            lblrol.Text = oPersona.oTipoPersona.Descripcion;

            if (oPersona.oTipoPersona.IdTipoPersona == 2) {
                usuariosToolStripMenuItem.Visible = false;
                gestionToolStripMenuItem.Visible = false;
                proveedoresToolStripMenuItem.Visible = true;
                reporteriaToolStripMenuItem.Visible = true;
                comprasToolStripMenuItem.Visible = true;
            }


            frmVenta frmhijo = new frmVenta(oPersona.IdPersona);
            mostrarformulario(frmhijo, ventasToolStripMenuItem);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmhijo = new frmCliente();

            mostrarformulario(frmhijo,sender);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frmhijo = new frmProveedor();

            mostrarformulario(frmhijo,sender);
        }


        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestion frmhijo = new frmGestion();

            mostrarformulario(frmhijo,sender);
        }


        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompra frmhijo = new frmCompra(oPersona.IdPersona);

            mostrarformulario(frmhijo,sender);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tipoVentana = 2;
            if (tipoVentana == 1)
            {
                frmVenta frmhijo = new frmVenta(oPersona.IdPersona);
                mostrarformulario(frmhijo, sender);
                // frmhijo.ControlBox = true; 
                // frmhijo.Show();
            }
            if (tipoVentana == 2)
            {
                Ventasformato frmhijo2 = new Ventasformato(oPersona.IdPersona);
                mostrarformulario(frmhijo2, sender);
            }
            if (tipoVentana == 3)
            {
                frmMultiventa frmhijo2 = new frmMultiventa(oPersona.IdPersona);
                mostrarformulario(frmhijo2, sender);
            }

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frmhijo = new frmUsuario();

            mostrarformulario(frmhijo,sender);
        }


        private void reporteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oPersona.oTipoPersona.IdTipoPersona == 2)
            {
                fmVentaVen ventas = new fmVentaVen(oPersona.IdPersona);
                mostrarformulario(ventas, sender);
            }
            else
            {
                frmReporte frmhijo = new frmReporte();

                mostrarformulario(frmhijo, sender);
            }
        }

        private void mostrarformulario(Form formulario, object senderitem)
        {

            
            foreach (Form frm in this.MdiChildren)
            {
                if (formulario.Name != "frmVenta")
                {
                    if (formulario.Name != "Ventasformato")
                    {
                        frm.Close();
                    }
                   
                }
            }

            foreach (ToolStripMenuItem menu in msMenu.Items)
            {
                menu.BackColor = Color.White;
            }
            ((ToolStripMenuItem)senderitem).BackColor = Color.SkyBlue;

            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
           
        }
        private void mostrarformularioVenta(Form formulario, object senderitem)
        {


            foreach (ToolStripMenuItem menu in msMenu.Items)
            {
                menu.BackColor = Color.White;
            }
            ((ToolStripMenuItem)senderitem).BackColor = Color.SkyBlue;

            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();

        }

        private void AcercadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModalAcercade frm = new ModalAcercade();
            frm.ShowDialog();
        }

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                this.Close();
            }
        }

        private void DevToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDevCompras frmhijo = new frmDevCompras(oPersona.IdPersona);

            mostrarformulario(frmhijo, sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += abrircaja;
            printDocument1.Print();
            
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

        private void GyptoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConta frmhijo = new  frmConta(oPersona.IdPersona);

            mostrarformulario(frmhijo, sender);
        }
    }
    }

