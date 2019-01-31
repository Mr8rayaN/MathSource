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
    public partial class IngresoFuncion : Form
    {
        public IngresoFuncion()
        {
            InitializeComponent();
        }

        public IngresoFuncion (Form Anterior)
        {
            InitializeComponent();
            this.MdiParent = Anterior;
            this.Dock = DockStyle.Fill;
            this.Size = Anterior.Size;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Enlazo con la siguiente ventana
            Variables VARIABLES = new Variables(this.MdiParent);
            VARIABLES.Show();
        }
    }
}
