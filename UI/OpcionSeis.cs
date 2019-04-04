using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace UI
{
    public partial class OpcionSeis : Form
    {
        Service BLL = new Service();

        public OpcionSeis()
        {
            InitializeComponent();
            LLlenarGrafica();
        }

        public OpcionSeis(Form Padre, Panel Contenedor, Service BLL)
        {
            InitializeComponent();
            this.BLL = BLL;
            this.BackColor = Contenedor.BackColor;
            PintarControles();
            this.Size = Contenedor.Size;
            LLlenarGrafica();

        }

        private void LLlenarGrafica()
        {

        }

        private void PintarControles()
        {
            Grafica.BackColor = this.BackColor;
        }
    }
}
