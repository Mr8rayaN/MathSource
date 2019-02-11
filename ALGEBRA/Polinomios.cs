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
        private AMathOps Suma = new Sumas(null, null);
        private AMathOps Resta = new Sustracciones(null, null);

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
            int j = 0;
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
}
