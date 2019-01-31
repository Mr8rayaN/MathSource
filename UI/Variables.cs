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
    public partial class Variables : Form
    {
        public Variables()
        {
            InitializeComponent();
        }

        public Variables(Form Anterior)
        {
            InitializeComponent();
            this.MdiParent = Anterior;
            this.Dock = DockStyle.Fill;
            this.Size = Anterior.Size;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Enlazo con la siguiente ventana
            panel1.Show();
            Resultado RESULTADO = new Resultado(this.MdiParent);
            RESULTADO.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Enlazo con la siguiente ventana
            Resultado RESULTADO = new Resultado(this.MdiParent);
            RESULTADO.Show();
        }

        private void AnteriorVentana(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
