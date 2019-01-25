using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{

    public class Suma : AMathOps
    {
        public override int Modulo { get { return 0; } }
        public string Simbolo { get { return "+"; } }
        public string SumandoUno { get; set; }
        public string SumandoDos { get; set; }
        public string Result { get; set; }

        public string PropiedadComutativa ()
        {
            return null;
        }

        public string PropiedadDistributiva ()
        {
            return null;
        }
        
    }

    public class Sustraccion : AMathOps
    {
        public override int Modulo { get { return 0; } }
        public string Simbolo { get { return "-"; } }
        public string Minuendo { get; set; }
        public string Sustraendo { get; set; }
        public string Result { get; set; }
    }

    public class Cociente : AMathOps
    {
        public override int Modulo { get { return 1;} }
        public string Simbolo { get { return "/"; } }
        public string Dividendo { get; set; }
        public string Divisor { get; set; }
        public string Result { get; set; }
    }

    public class Producto : AMathOps
    {
        public override int Modulo { get { return 1; } }
        public string Simbolo { get { return "*"; } }
        public string FactorUno { get; set; }
        public string FactorDos { get; set; }
        public string Result { get; set; }
    }

    public abstract class Potencia : AMathOps
    {
        public override int Modulo { get { return 1; } }
        public string Simbolo { get { return "^"; } }
        public string Base { get; set; }
        public string Exponente { get; set; }
        public string Result { get; set; }

    }
}
