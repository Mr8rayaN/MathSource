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
            PnSalida.Hide();
            BLL = new Service();
            LlenarOperaciones();
            LlenarEstados();
        }

        public OpcionUno(Form Padre, Panel Contenedor, Service BLL)
        {
            InitializeComponent();
            PnSalida.Hide();
            this.BackColor = Contenedor.BackColor;
            PintarComponentes();
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
            if (ValidarExpresion())
            {
                if (!ValidarVariables())
                {
                    CBVariables.Items.Add(BLL.VariablePorDefecto);
                    CBVariables.SelectedItem = BLL.VariablePorDefecto;
                }
            }

            if (ValidarOperar())
            {
                TBResultado.Text = BLL.Procesar(TBExpresion.Text, CBVariables.SelectedItem.ToString(), CBProcesos.SelectedItem.ToString());
                PnSalida.Show();
            }
            else
                MostrarCompletar();
        }

        private void TBExpresion_Left(object sender, EventArgs e)
        {
            CBVariables.Items.Clear();
            CBVariables.SelectedItem = null;
            CBVariables.Text = "Variables";

            if(ValidarExpresion())
                LlenarCBVariables(BLL.ObtenerVariable(TBExpresion.Text));
            
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
            if (ValidarSave())
            {

            }
            else
                MostrarCompletar();
        }

        private bool ValidarExpresion()
        {
            if (TBExpresion == null)
                return false;

            if (TBExpresion.Text.Equals(""))
                return false;

            return
                true;
        }

        private bool ValidarVariables()
        {
            if (CBVariables == null)
                return false;

            if (CBVariables.SelectedItem == null)
                return false;

            return
                true;
        }

        private void MostrarCompletar()
        {
            MessageBox.Show("Complete todos los campos\nTodos son Obligatorios");
        }

        private bool ValidarOperar()
        {
            bool A = true;

            if (TBExpresion.Text.Equals("") || TBExpresion == null)
                A = false;

            if (CBVariables.SelectedItem == null)
                A = false;
                

            if (CBProcesos.SelectedItem == null)
                A = false;

            if (A)
                return true;

            return false;
        }

        private bool ValidarSave()
        {
            bool A = true;

            if (TBResultado.Text.Equals("") || TBResultado == null)
                A = false;

            if (CBEstados == null)
                A = false;

            if (A)
                return true;

            return false;
        }

        private void PintarComponentes()
        {
            TBExpresion.BackColor = this.BackColor;
            TBResultado.BackColor = this.BackColor;
            CBProcesos.BackColor = this.BackColor;
            CBVariables.BackColor = this.BackColor;
            CBEstados.BackColor = this.BackColor;
            PnGuiaTBExpresion.BackColor = TBExpresion.ForeColor;
            PnGuiaTBResultado.BackColor = TBResultado.ForeColor;
        }
    }
}
