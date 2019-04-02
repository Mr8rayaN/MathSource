using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;
using System.Windows.Forms;

namespace UI
{
    public partial class VentanaPpal : Form
    {

        public int X_Click { get; set; }
        public int Y_Click { get; set; }
        private ToolTip ToolTipText = new ToolTip();
        private PictureBox PBox;
        private Panel Pnl;
        private Panel PMenu;
        private Control Ctl;
        private Service BLL = new Service();
        private Form Ventana;

        public VentanaPpal()
        {
            InitializeComponent();
            ControlsHide();
            PMenu = new Panel();
        }

        private void ControlsHide()
        {
            PnSubMaxRegistros.Hide();
            PnVisibilidadMax.Hide();
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
                    Lbl.Font = new Font(Lbl.Font,FontStyle.Italic);
                    break;
                }
            }

            if (Sender.Name.Contains("Entrada"))
                PBoxEntrada.BackColor = Sender.BackColor;

            else if (Sender.Name.Contains("Paso"))
                PBoxPaso.BackColor = Sender.BackColor;

            else if (Sender.Name.Contains("Registro"))
                PBoxRegistro.BackColor = Sender.BackColor;

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
                    Lbl.Font = new Font(Lbl.Font, FontStyle.Italic);
                    break;
                }
            }

            if (Sender.Name.Contains("Entrada"))
                PBoxEntrada.BackColor = PanelGeneral.BackColor;

            else if (Sender.Name.Contains("Paso"))
                PBoxPaso.BackColor = PanelGeneral.BackColor;

            else if (Sender.Name.Contains("Registro"))
                PBoxRegistro.BackColor = PanelGeneral.BackColor;
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
            //Pintar el contenedor
            Ctl = (Control)sender;
            string Text = Ctl.Name.Replace("PBox", "");
            if (Ctl.Parent.Parent.Name.Contains("Max"))
                Preseleccion(Ctl.Parent, EventArgs.Empty);

            else
            {
                Ctl.BackColor = PanelGeneral.BackColor;
                ToolTipText.SetToolTip(Ctl, Text);
            }

        }

        private void ControlsOpcionesLeave(object sender, EventArgs e)
        {
            //Pintar el contenedor
            Ctl = (Control)sender;
            if (Ctl.Parent.Parent.Name.Contains("Max"))
                NoSeleccion(Ctl.Parent, EventArgs.Empty);

            else
                Ctl.BackColor = Color.FromArgb(24, 24, 24);
        }

        private void ControlOpcionesClick(object sender, EventArgs e)
        {
            //Pintar el contenedor
            Ctl = (Control)sender;
            if(Ctl.Parent.Parent.Name.Contains("Max"))
                OpcionesClick(Ctl.Parent, EventArgs.Empty);

            else if(Ctl.Name.Contains("Entrada"))
            {
                OpcionesClick(PnEntradas, EventArgs.Empty);
            }
            else if (Ctl.Name.Contains("Paso"))
            {
                OpcionesClick(PnPasos, EventArgs.Empty);
            }
            else if (Ctl.Name.Contains("Registro"))
            {
                PnSubMaxRegistros.Show();
                AlterVisibilidad(Ctl, EventArgs.Empty);
                OpcionesClick(PnRegistros, EventArgs.Empty);
            }
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
                if (Pnl.Name.Contains("SubEntrada"))
                {
                    Ventana = new OpcionCuatro(this, PanelGeneral, BLL);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("SubPaso"))
                {
                    Ventana = new OpcionCinco(this, PanelGeneral);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("SubSalida"))
                {
                    Ventana = new OpcionSeis(this, PanelGeneral);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Entrada"))
                {
                    PnSubMaxRegistros.Hide();
                    Ventana = new OpcionUno(this, PanelGeneral, BLL);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Paso"))
                {
                    PnSubMaxRegistros.Hide();
                    Ventana = new OpcionDos(this, PanelGeneral, BLL);
                    Abrir(Ventana);
                }
                else if (Pnl.Name.Contains("Registro"))
                {
                    PnSubMaxRegistros.Show();
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

        private void PanelOpcionDos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PnSubRegistros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelOpcionCuatro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelOpcionCinco_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelOpcionSeis_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PintarBoxMinimizados(Color color)
        {
            PBoxEntrada.BackColor = color;
            PBoxPaso.BackColor = color;
            PBoxRegistro.BackColor = color;
        }

        private void AlterVisibilidad(object sender, EventArgs e)
        {
            if(PnVisibilidadMax.Visible == true)
            {
                PintarBoxMinimizados(Color.FromArgb(24, 24, 24));
                PnVisibilidadMax.Hide();
            }
            else
            {
                PintarBoxMinimizados(PanelGeneral.BackColor);
                PnVisibilidadMax.Show();
            }
        }
    }
}
