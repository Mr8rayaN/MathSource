using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Monomio
    {
        public string Nombre { get; set; }
        public string Expresion { get; private set; }
        public string Coeficiente { get; private set; }
        public string ParteLiteral { get; private set; }
        public string Grado { get; private set; }

        public Monomio(string Coeficiente, string ParteLiteral, string Grado)
        {
            this.Coeficiente = Coeficiente;
            this.ParteLiteral = ParteLiteral;
            this.Grado = Grado;
            Expresion = Coeficiente + ParteLiteral;
            Nombre = $"Monomio {this.Coeficiente}{this.ParteLiteral}";
        }
    }
}
