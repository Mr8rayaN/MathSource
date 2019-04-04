using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY;
using BLL;

namespace UI
{
    public partial class OpcionCuatro : Form
    {
        Service BLL;

        public OpcionCuatro()
        {
            InitializeComponent();
        }

        public OpcionCuatro(Form Padre, Panel Contenedor, Service BLL)
        {
            InitializeComponent();
            this.BLL = BLL;
            this.BackColor = Contenedor.BackColor;
            PintarControles();
            this.Size = Contenedor.Size;
            LlenarDataGriew();
        }

        private void LlenarDataGriew()
        {
            DGVPasos.DataSource = BLL.ConsultarPasos();
        }

        private void PintarControles()
        {
            DGVPasos.BackgroundColor = this.BackColor;
        }

    }
}
