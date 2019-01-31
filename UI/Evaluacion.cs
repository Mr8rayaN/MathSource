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
        bool VentanaAbierta = true;
        Graficas GRAFICA;

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
           GRAFICA = new Graficas();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Abro ventana Graficar
            
            this.Dispose();
            

            foreach (var frm in Application.OpenForms)
            {
                if(frm.GetType() == typeof(Graficas))
                {
                    VentanaAbierta = false;
                    break;
                }
            }

            if (VentanaAbierta)
            {
                GRAFICA.Show();
            }
            else
                GRAFICA.Refresh();
            
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
