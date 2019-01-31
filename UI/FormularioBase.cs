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
    public partial class FormularioBase : Form
    {
        public FormularioBase()
        {
            InitializeComponent();
            IsMdiContainer = true;
            CargarVentanas();
        }

        public static void Main(string[] args)
        {
            
            Application.Run(new FormularioBase());
        }

        public void CargarVentanas()
        {
            Inicio FORM_INICIO = new Inicio(this);
            FORM_INICIO.Show();
        }
    }
}
