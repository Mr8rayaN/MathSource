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
        public OpcionUno()
        {
            InitializeComponent();
            LlenarOperaciones();
            LlenarEstados();
        }

        public OpcionUno(Form Padre, Panel Contenedor)
        {
            InitializeComponent();
            this.BackColor = Contenedor.BackColor;
            this.Size = Contenedor.Size;

            LlenarOperaciones();
            LlenarEstados();
        }

        private void LlenarOperaciones()
        {
            comboBox1.Items.Add("Sumar");
            comboBox1.Items.Add("Multiplicar");
            comboBox1.Items.Add("Simplificar Cocientes");
            comboBox1.Items.Add("Simplificar Potencias");
        }

        private void LlenarEstados()
        {
            comboBox2.Items.Add("Correcto");
            comboBox2.Items.Add("Incompleto");
            comboBox2.Items.Add("incorrecto");
        }

        private void Operar_Click(object sender, EventArgs e)
        {
            List<string> entrada = new List<string>();
            List<string> Salida = new List<string>();
            List<string> nombre = new List<string>();
            Pasos Paso;

            if (comboBox1.SelectedItem.ToString().Contains("Cociente"))
            {
                CocienteEntero C = new CocienteEntero(textBox1.Text);
                nombre.Add(C.Nombre);
                entrada.Add(C.Contenido);
                Salida.Add(C.Result);
                //crear funcion, ingresar valores y obtener funcion_id;
                //crear resultado, ingresar valores y obtener Resultado_id;
                Paso = new Pasos(entrada, Salida, nombre);
                Paso.SetFuncion("F002");
                Paso.SetResultado("R002");
                textBox2.Text = C.Result;

            }
            else if (comboBox1.SelectedItem.ToString().Contains("Potencia"))
            {
                PotenciaEntera P = new PotenciaEntera(textBox1.Text);
                nombre.Add(P.Nombre);
                entrada.Add(P.Contenido);
                Salida.Add(P.Result);
                //crear funcion, ingresar valores y obtener funcion_id;
                //crear resultado, ingresar valores y obtener Resultado_id;
                Paso = new Pasos(entrada, Salida, nombre);
                Paso.SetFuncion("F003");
                Paso.SetResultado("R003");
                textBox2.Text = P.Result;
            }
            else if (comboBox1.SelectedItem.ToString().Contains("Suma"))
            {

            }
            else if (comboBox1.SelectedItem.ToString().Contains("Multiplica"))
            {

            }
        }
    }
}
