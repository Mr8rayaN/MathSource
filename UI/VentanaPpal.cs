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
    public partial class VentanaPpal : Form
    {
        public VentanaPpal()
        {
            InitializeComponent();
        }

        private void PBoxCerrar(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PBoxMaximizar(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void PBoxMinimizar(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
