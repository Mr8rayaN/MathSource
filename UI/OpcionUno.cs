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
    public partial class OpcionUno : Form
    {
        Service BLL;

        public OpcionUno()
        {
            InitializeComponent();
            PnVariables.Hide();
            BLL = new Service();
            LlenarOperaciones();
            LlenarEstados();
        }

        public OpcionUno(Form Padre, Panel Contenedor, Service BLL)
        {
            InitializeComponent();
            PnVariables.Hide();
            this.BackColor = Contenedor.BackColor;
            this.Size = Contenedor.Size;

            this.BLL = BLL;
            LlenarOperaciones();
            LlenarEstados();
        }

        private void LlenarOperaciones()
        {
            CBProcesos.Items.Add("Simplificar");
            CBProcesos.Items.Add("Derivar");
        }

        private void LlenarEstados()
        {
            foreach (var estado in BLL.ConsultarEstados())
            {
                CBEstados.Items.Add($"{estado.Id} {estado.Nombre}");
            }
            
        }

        private void Operar_Click(object sender, EventArgs e)
        {
            TBResultado.Text = BLL.Procesar(TBExpresion.Text, CBVariables.SelectedItem.ToString(), CBProcesos.SelectedItem.ToString());
            MessageBox.Show("Procesado Correctamente");
        }

        private void TBExpresion_Left(object sender, EventArgs e)
        {
            LlenarCBVariables(BLL.ObtenerVariable(TBExpresion.Text));
            PnVariables.Show();
        }

        private void LlenarCBVariables(List<Variables> LVar)
        {
            foreach (var variable in LVar)
            {
                CBVariables.Items.Add(variable.Nombre);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Guardado Correctamente");
        }
    }
}
