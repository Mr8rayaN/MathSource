using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Monomios 
    {
        public string Nombre { get; set; }
        public string Expresion { get; private set; }
        public string Coeficiente { get; private set; }
        public string ParteLiteral { get; private set; }
        public string Grado { get; private set; }
        

        public Monomios(string Coeficiente, string ParteLiteral)
        {
            this.Coeficiente = Coeficiente;
            this.ParteLiteral = ParteLiteral;
            //Extraer GRADO ABSOLUTO
            Expresion = Coeficiente + ParteLiteral;
            Nombre = $"Monomio {this.Coeficiente}{this.ParteLiteral}";
        }

        public Monomios(string Monomio)
        {
            Expresion = Monomio;
        }

        /* 
         * para obetenr las partes del monomio se debe preparar propiedades
         * Implicitas dentro del monomio como agrupacion (xx => x^2)
         * Simplificacion (2x/x => 2)
         * Multiplicacion y simplificacion de signos
         * Separacion de Coeficiente
         * Separacion de Parte Literal
         * Para poder obtener la expresion mas reducida de cada
         * elemento del monomio
         */

        private void ObtenerElementos()
        {

            for(int i=0; i<Expresion.Length; i++)
            {

            }
        }
    }
}
