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

namespace ProyectoPuntoVenta
{
    public partial class ModalPago : Form
    {
        public string valorCompra;
        public string Pagacon;
        public string vueltas;
        public string valIva19;
        public string valIva4;
        public string NumFactura;
        public ModalPago()
        {
            InitializeComponent();
            this.textBox1.Text = valorCompra;
            this.textBox2.Text = Pagacon;
            this.textBox3.Text = vueltas;
            this.textBox4.Text = valIva19;
            this.textBox5.Text = valIva4;
            this.textBox6.Text = NumFactura;
            this.textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void ModalPago_Load(object sender, EventArgs e)
        {

        }
    }
}
