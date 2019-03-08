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
        List<Pasos> LPasos = new List<Pasos>();
        Funciones F = new Funciones();
        Resultados R = new Resultados();
        Pasos Paso = new Pasos();

        Service BLL;

        public OpcionUno()
        {
            InitializeComponent();
            BLL = new Service();
            LlenarOperaciones();
            LlenarEstados();
        }

        public OpcionUno(Form Padre, Panel Contenedor, Service BLL)
        {
            InitializeComponent();
            this.BackColor = Contenedor.BackColor;
            this.Size = Contenedor.Size;

            this.BLL = BLL;
            LlenarOperaciones();
            LlenarEstados();
        }

        private void LlenarOperaciones()
        {
            comboBox1.Items.Add("Simplificar Cocientes");
            comboBox1.Items.Add("Simplificar Potencias");
        }

        private void LlenarEstados()
        {
            foreach (var estado in BLL.ConsultarEstados())
            {
                comboBox2.Items.Add($"{estado.Id} {estado.Nombre}");
            }
            
        }

        private void Operar_Click(object sender, EventArgs e)
        {
            LPasos.Clear();

            string entrada ="";
            string Salida = "";
            string nombre ="";

            if (comboBox1.SelectedItem.ToString().Contains("Cociente"))
            {
                CocienteEntero C = new CocienteEntero(textBox1.Text);
                nombre = C.Nombre;
                entrada = C.Contenido;
                Salida = C.Result;
                F = new Funciones(BLL.ProximaFuncion(),C.Nombre,C.Contenido);
                R = new Resultados(BLL.ProximoResultado(), C.Nombre, C.Result);
                Paso = new Pasos(entrada, Salida, nombre);
                Paso.SetFuncion(F.Id);
                Paso.SetResultado(R.Id);
                textBox2.Text = C.Result;

            }
            else if (comboBox1.SelectedItem.ToString().Contains("Potencia"))
            {
                PotenciaEntera P = new PotenciaEntera(textBox1.Text);
                nombre = P.Nombre;
                entrada = P.Contenido;
                Salida = P.Result;
                F = new Funciones(BLL.ProximaFuncion(), P.Nombre, P.Contenido);
                R = new Resultados(BLL.ProximoResultado(), P.Nombre, P.Result);
                Paso = new Pasos(entrada, Salida, nombre);
                Paso.SetFuncion(F.Id);
                Paso.SetResultado(R.Id);
                textBox2.Text = P.Result;
            }

            LPasos.Add(Paso);

            

            MessageBox.Show("Procesado Correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EST = "EST1";
            BLL.GuardarFuncion(F);
            EST = comboBox2.SelectedItem.ToString();
            EST = EST.Substring(0, EST.IndexOf(" "));
            R.SetEstado(EST);
            BLL.GuardarResultado(R);
            BLL.GuardarPasos(LPasos);

            MessageBox.Show("Guardado Correctamente");
        }
    }
}
