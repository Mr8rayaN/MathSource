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

        public int X_Click { get; set; }
        public int Y_Click { get; set; }

        public VentanaPpal()
        {
            InitializeComponent();
            SeleccionIniciar();
        }

        private void SeleccionIniciar()
        {
            PBoxSeleccionUno.Hide();
            PBoxSeleccionDos.Hide();
            PBoxSeleccionTres.Hide();
            PBoxSeleccionCuatro.Hide();
            PBoxSeleccionCinco.Hide();
            PBoxSeleccionSeis.Hide();

        }

        private void PBoxCerrar(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PBoxMaximizar(object sender, EventArgs e)
        {
            if (WindowState.Equals(FormWindowState.Maximized))

                WindowState = FormWindowState.Normal;
            else

                this.WindowState = FormWindowState.Maximized;
        }

        private void PBoxMinimizar(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void PreseleccionUno(object sender, EventArgs e)
        {
            PanelOpcionUno.BackColor = Color.FromArgb(24, 24, 24);
            PBoxSeleccionUno.Show();
            LblOpciopnUno.ForeColor = Color.White; 
        }

        private void NoSeleccionUno(object sender, EventArgs e)
        {
            PanelOpcionUno.BackColor = Color.FromArgb(39,39,39);
            PBoxSeleccionUno.Hide();
            LblOpciopnUno.ForeColor = Color.Black;
        }

        private void PreseleccionDos(object sender, EventArgs e)
        {
            PanelOpcionDos.BackColor = Color.FromArgb(24, 24, 24);
            PBoxSeleccionDos.Show();
            LblOpciopnDos.ForeColor = Color.White;
        }

        private void NoSeleccionDos(object sender, EventArgs e)
        {
            PanelOpcionDos.BackColor = Color.FromArgb(39, 39, 39);
            PBoxSeleccionDos.Hide();
            LblOpciopnDos.ForeColor = Color.Black;
        }

        private void PreseleccionTres(object sender, EventArgs e)
        {
            PanelOpcionTres.BackColor = Color.FromArgb(24, 24, 24);
            PBoxSeleccionTres.Show();
            LblOpciopnTres.ForeColor = Color.White;
        }

        private void NoSeleccionTres(object sender, EventArgs e)
        {
            PanelOpcionTres.BackColor = Color.FromArgb(39, 39, 39);
            PBoxSeleccionTres.Hide();
            LblOpciopnTres.ForeColor = Color.Black;
        }

        private void PreseleccionCuatro(object sender, EventArgs e)
        {
            PanelOpcionCuatro.BackColor = Color.FromArgb(24, 24, 24);
            PBoxSeleccionCuatro.Show();
            LblOpciopnCuatro.ForeColor = Color.White;
        }

        private void NoSeleccionCuatro(object sender, EventArgs e)
        {
            PanelOpcionCuatro.BackColor = Color.FromArgb(39, 39, 39);
            PBoxSeleccionCuatro.Hide();
            LblOpciopnCuatro.ForeColor = Color.Black;
        }

        private void PreseleccionCinco(object sender, EventArgs e)
        {
            PanelOpcionCinco.BackColor = Color.FromArgb(24, 24, 24);
            PBoxSeleccionCinco.Show();
            LblOpciopnCinco.ForeColor = Color.White;
        }

        private void NoSeleccionCinco(object sender, EventArgs e)
        {
            PanelOpcionCinco.BackColor = Color.FromArgb(39, 39, 39);
            PBoxSeleccionCinco.Hide();
            LblOpciopnCinco.ForeColor = Color.Black;
        }

        private void PreseleccionSeis(object sender, EventArgs e)
        {
            PanelOpcionSeis.BackColor = Color.FromArgb(24, 24, 24);
            PBoxSeleccionSeis.Show();
            LblOpciopnSeis.ForeColor = Color.White;
        }

        private void NoSeleccionSeis(object sender, EventArgs e)
        {
            PanelOpcionSeis.BackColor = Color.FromArgb(39, 39, 39);
            PBoxSeleccionSeis.Hide();
            LblOpciopnSeis.ForeColor = Color.Black;
        }

        private void PreSeleccionCerrar(object sender, EventArgs e)
        {
            PBoxBCerrar.BackColor = Color.Tomato;
        }

        private void NoSeleccionCerrar(object sender, EventArgs e)
        {
            PBoxBCerrar.BackColor = Color.Transparent;
        }

        private void PreSeleccionMaximizar(object sender, EventArgs e)
        {
            PBoxBMaximizar.BackColor = Color.DimGray;
        }

        private void NoSeleccionMaximizar(object sender, EventArgs e)
        {
            PBoxBMaximizar.BackColor = Color.Transparent;
        }

        private void PreSeleccionMinimizar(object sender, EventArgs e)
        {
            PBoxBMinimizar.BackColor = Color.DimGray;
        }

        private void NoSeleccionMinimizar(object sender, EventArgs e)
        {
            PBoxBMinimizar.BackColor = Color.Transparent;
        }

        private void ArrastrarVentana(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                X_Click = e.X; Y_Click = e.Y;
            }
                
            else
            {
                this.Left += (e.X - X_Click);
                this.Top += (e.Y - Y_Click);
            }
        }
    }
}
