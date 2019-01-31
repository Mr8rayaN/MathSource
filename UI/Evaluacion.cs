using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Evaluacion : Form
    {
        public Evaluacion()
        {
            InitializeComponent();
        }

        public Evaluacion(Form Anterior)
        {
            InitializeComponent();
            this.MdiParent = Anterior;
            this.Dock = DockStyle.Fill;
            this.Size = Anterior.Size;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Abro ventana Graficar
            this.Dispose();
            Graficas GRAFICA = new Graficas();
            GRAFICA.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
