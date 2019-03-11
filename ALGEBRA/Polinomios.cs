using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public class Polinomios
    {
        public string Nombre { get; set; }
        public string Expresion { get; private set;}
        public List<Monomios> Polinomio { get; private set; }
        private Monomios Monomio;
        Sumas Suma = new Sumas();
        Sustracciones Resta = new Sustracciones();

        public Polinomios(List<Monomios> Polinomio)
        {
            this.Polinomio = Polinomio;
            ObtenerExpresion();
            Nombre = $"Polinomio {Expresion}";
        }

        public Polinomios(string Polinomio)
        {

        }

        private void ObtenerExpresion()
        {
            Expresion = "";
            foreach (var item in Polinomio)
            {
                Expresion += item;
            }
        }

        private void ObtenerMonomios(string Expresion)
        {
            string index;
            //Monomio = new Monomios(nul);
            Polinomio = new List<Monomios>();

            for(int i=0; i<Expresion.Length; i++)
            {
                index = Expresion.ElementAt(i).ToString();
                if (index.Equals(Suma.Simbolo))
                {
                    
                }
                else if (index.Equals(Resta.Simbolo))
                {

                }
            }
        }
    }

    public class CopPolinomios
    {
        public string Nombre => "POLINOMIO";
        public string Contenido { get; private set; }
        public string Result { get; private set; }
        public double GradoAbs { get; private set; }
        public List<Monomios> Elementos = new List<Monomios>();
        Monomios Monomio;
        SumaEntera Suma = new SumaEntera();

        EProcesos Proceso = new EProcesos();

        public CopPolinomios() { }

        public CopPolinomios(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            ObtenerElementos(Expresion);

            Operar();
        }

        private void ObtenerElementos(string Expresion)
        {
            GradoAbs = 0;
            Elementos.Clear();
            Contenido = "";
            Suma = new SumaEntera(Expresion);

            Contenido = Suma.Result;

            foreach (var elemento in Contenido.Split(Suma.Simbolo))
            {
                Monomio = new Monomios(elemento);

                if (!Monomio.Result.Equals(Suma.Modulo))
                {
                    Elementos.Add(Monomio);
                    GradoAbs += Monomio.GradoAbs;
                }

            }

            Contenido = Contenido.Trim(Suma.Simbolo);

        }

        private void Operar()
        {
            Result = "";
            string Temporal;
            bool A;

            A = Elementos.Count < 1;

            if (A)
                Result = $"{Suma.Modulo}";
            else
            {
                foreach (var M in Elementos)
                {
                    Temporal = M.Result;
                    A = Temporal.Length > 3;

                    if (A)
                    {
                        Temporal = Proceso.EncorcharParentesis(Temporal);
                    }

                    Result += Suma.Simbolo + Temporal;
                }

                Result = Result.Trim(Suma.Simbolo);
            }
        }

    }

}
