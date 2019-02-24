using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class NumerosNaturales
    {
        public string Nombre => "NUMERO NATURAL";
        public char SimboloLocal => '+';
        public double Contenido { get; private set; }
        public string Simbolos => $"{SimboloLocal}";
    }

    public class NumerosEnteros
    {
        public string Nombre => "NUMERO ENTERO";
        public NumerosNaturales Naturales = new NumerosNaturales();
        public char SimboloLocal => '-';
        public string Simbolos => $"{SimboloLocal}{Naturales.Simbolos}";
        
    }
}
