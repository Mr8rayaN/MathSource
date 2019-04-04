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
    public partial class OpcionCinco : Form
    {
        public OpcionCinco()
        {
            InitializeComponent();
        }

        public OpcionCinco(Form Padre, Panel Contenedor, Service BLL)
        {
            InitializeComponent();
            this.BackColor = Contenedor.BackColor;
            this.Size = Contenedor.Size;
        }
    }
}
