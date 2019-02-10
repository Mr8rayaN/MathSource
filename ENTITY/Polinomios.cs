using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Polinomios
    {
        public string Nombre { get; set; }
        public string Expresion { get; private set;}
        public List<Monomios> Monomios { get; private set; }
        private Monomios Monomio;
        private AMathOps Suma = new Suma(null, null);
        private AMathOps Resta = new Sustraccion(null, null);

        public Polinomios(List<Monomios> Monomios)
        {
            this.Monomios = Monomios;
            ObtenerExpresion();
            Nombre = $"Polinomio {Expresion}";
        }

        public Polinomios(string Polinomio)
        {

        }

        private void ObtenerExpresion()
        {
            Expresion = "";
            foreach (var item in Monomios)
            {
                Expresion += item;
            }
        }

        private void ObtenerMonomios(string Polinomio)
        {
            int j = 0;
            string index;
            Monomio = new Monomios();
            Monomios = new List<Monomios>();

            for(int i=0; i<Polinomio.Length; i++)
            {
                index = Polinomio.ElementAt(i).ToString();
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
