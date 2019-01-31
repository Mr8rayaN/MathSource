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
    public partial class Resultado : Form
    {
        public Resultado()
        {
            InitializeComponent();
        }
        public Resultado(Form Anterior)
        {
            InitializeComponent();
            this.MdiParent = Anterior;
            this.Dock = DockStyle.Fill;
            this.Size = Anterior.Size;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Enlazo con ventana siguiente
            Evaluacion EVALUACION = new Evaluacion(this.MdiParent);
            EVALUACION.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
