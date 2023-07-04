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
    public partial class ModalVenta : Form
    {
        public string valorFactura { get; set; }
        public string valorPagado { get; set; }
        public string valorVuelas { get; set; }

        public string valor19 { get; set; }

        public string valor5 { get; set; }


        public string numfac { get; set; }

        public ModalVenta()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModalVenta_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = valorFactura.ToString();
            this.textBox2.Text = valorPagado.ToString();
            this.textBox3.Text = valorVuelas.ToString();
            this.textBox4.Text = valor19.ToString();
            this.textBox5.Text = valor5.ToString();
            this.textBox6.Text = numfac.ToString();
        }
    }
}
