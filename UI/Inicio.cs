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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        public static void Main(string[] args)
        {
            Application.Run(new Inicio());
        }

        private void ListaOperacionesMouseHover(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void FlechaSiguienteClick(object sender, EventArgs e)
        {
            //Enlazo con el siguiente formulario
        }
    }
}
