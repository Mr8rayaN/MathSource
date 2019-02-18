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
        private PictureBox PBox;
        private Panel Pnl;
        private Panel PMenu;
        private Control Ctl;
        private Form Ventana;

        public VentanaPpal()
        {
            InitializeComponent();
            PMenu = new Panel();
        }

        
        private void PBoxDimensionSize (object sender, EventArgs e)
        {
            PBox = (PictureBox)sender;

            if (PBox.Name.Contains("Cerrar"))
            {
                this.Dispose();
            }
            else if (PBox.Name.Contains("Maximizar"))
            {
                if (WindowState.Equals(FormWindowState.Maximized))

                    WindowState = FormWindowState.Normal;
                else
                    this.WindowState = FormWindowState.Maximized;
                 
            }
            else if (PBox.Name.Contains("Minimizar"))
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void DimensionPreseleccion (object sender, EventArgs e)
        {
            PBox = (PictureBox)sender;

            if (PBox.Name.Contains("Cerrar"))
            {
                PBoxBCerrar.BackColor = Color.Tomato;
            }
            else if (PBox.Name.Contains("Maximizar"))
            {
                PBoxBMaximizar.BackColor = Color.DimGray;
            }
            else if (PBox.Name.Contains("Minimizar"))
            {
                PBoxBMinimizar.BackColor = Color.DimGray;
            }
        }

        private void DimensionNoSeleccion (object sender, EventArgs e)
        {
            PBox = (PictureBox)sender;

            if (PBox.Name.Contains("Cerrar"))
            {
                PBoxBCerrar.BackColor = Color.Transparent;
            }
            else if (PBox.Name.Contains("Maximizar"))
            {
                PBoxBMaximizar.BackColor = Color.Transparent;
            }
            else if (PBox.Name.Contains("Minimizar"))
            {
                PBoxBMinimizar.BackColor = Color.Transparent;
            }
        }

        private void Preseleccion (object sender, EventArgs e)
        {
            Panel Sender = ((Panel)sender);

            Sender.BackColor = PanelGeneral.BackColor;

            foreach (var item in Sender.Controls)
            {
                if (item.GetType().ToString().Contains("Label"))
                {
                    Label Lbl = (Label)item;
                    Lbl.ForeColor = Color.Black;
                    Lbl.Font = new Font(Lbl.Font,FontStyle.Bold);
                    break;
                }
            }

            foreach (var item in Sender.Controls)
            {
                if (item.GetType().ToString().Contains("PictureBox"))
                {
                    PictureBox PB = (PictureBox)item;
                    PB.Show();
                    break;
                }
            }
        }

        private void NoSeleccion(object sender, EventArgs e)
        {
            Panel Sender = (Panel)sender;

            Sender.BackColor = Color.FromArgb(24,24,24);

            foreach (var item in Sender.Controls)
            {
                if (item.GetType().ToString().Contains("Label"))
                {
                    Label Lbl = (Label)item;
                    Lbl.ForeColor = Color.White;
                    Lbl.Font = new Font(Lbl.Font, FontStyle.Regular);
                    break;
                }
            }

            foreach (var item in Sender.Controls)
            {
                if (item.GetType().ToString().Contains("PictureBox"))
                {
                    PictureBox PB = (PictureBox)item;
                    PB.Hide();
                    break;
                }
            }

            
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

        private void ControlsOpcionesHover(object sender, EventArgs e)
        {
            Ctl = (Control)sender;
            Preseleccion(Ctl.Parent, EventArgs.Empty);
        }

        private void ControlsOpcionesLeave(object sender, EventArgs e)
        {
            Ctl = (Control)sender;
            NoSeleccion(Ctl.Parent, EventArgs.Empty);
        }

        private void ControlOpcionesClick(object sender, EventArgs e)
        {
            Ctl = (Control)sender;
            OpcionesClick(Ctl.Parent, EventArgs.Empty);
        }

        private void OpcionesClick(object sender, EventArgs e)
        {
            Pnl = (Panel)sender;
            bool Cambiar = false;

            if (PMenu.Name.Equals(""))
            {
                Preseleccion(Pnl, EventArgs.Empty);
                PMenu = Pnl;
            }
            else if (PMenu.Name.Equals(Pnl.Name))
            {
                Cambiar = true;
            }
            else
            {
                NoSeleccion(PMenu, EventArgs.Empty);
                Preseleccion(Pnl, EventArgs.Empty);
                PMenu = Pnl;

            }

            
            if (!Cambiar)
            {
                if (Pnl.Name.Contains("Uno"))
                {
                    Ventana = new OpcionUno(this, PanelGeneral);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Dos"))
                {
                    Ventana = new OpcionDos(this, PanelGeneral);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Tres"))
                {
                    Ventana = new OpcionTres(this, PanelGeneral);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Cuatro"))
                {
                    Ventana = new OpcionCuatro(this, PanelGeneral);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Cinco"))
                {
                    Ventana = new OpcionCinco(this, PanelGeneral);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Seis"))
                {
                    Ventana = new OpcionSeis(this, PanelGeneral);
                    Abrir(Ventana);
                }
            }

            
        }

        private void Abrir(Form ventana)
        {
            //Limpiar Controles del Panel
            PanelGeneral.Controls.Clear();

            ventana.TopLevel = false;
            this.PanelGeneral.Controls.Add(ventana);
            this.PanelGeneral.Tag = true;
            ventana.Dock = DockStyle.Fill;
            ventana.Show();
        }

        private void ResizePrincipal(object sender, EventArgs e)
        {
            foreach (Control item in PanelGeneral.Controls)
            {
                try
                {
                    Ventana = (Form)item;
                    Ventana.Size = this.PanelGeneral.Size;
                    break;
                }
                catch (Exception)
                {

                }
            }
        }

        private void Deseleccionar(object Obj)
        {
            NoSeleccion(Obj, EventArgs.Empty);
        }

        private void OpcionLeave(object sender, EventArgs e)
        {
            Pnl = (Panel)sender;
            if(!Pnl.Name.Equals(PMenu.Name))
                NoSeleccion(Pnl, EventArgs.Empty);
        }
            
    }
}
