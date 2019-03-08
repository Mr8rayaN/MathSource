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
    public partial class OpcionTres : Form
    {
        Service BLL;

        public OpcionTres()
        {
            InitializeComponent();
        }

        public OpcionTres(Form Padre, Panel Contenedor, Service BLL)
        {
            InitializeComponent();
            this.BLL = BLL;
            this.BackColor = Contenedor.BackColor;
            this.Size = Contenedor.Size;
            LlenarDataView();
        }

        private void LlenarDataView()
        {
            dataGridView1.DataSource = BLL.ConsultarPasos();
        }
    }
}
