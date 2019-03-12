using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using GRAMATICA;

namespace ALGEBRA
{
    public class Monomios : AMathExp
    {
        public override string Nombre => "MONOMIO";
        public string Coeficiente { get; private set; }
        public string ParteLiteral { get; private set; }

        public List<PotenciaEntera> Elementos = new List<PotenciaEntera>();
        PotenciaEntera Potencia = new PotenciaEntera();
        double number;


        public Monomios()
        {
            Operacion = new ProductoEntero();
        }

        public Monomios(string Coeficiente, string Literal)
        {
            Operacion = new ProductoEntero();
        }

        public Monomios(string Expresion)
        {
            Operacion = new ProductoEntero();
        }

        private void ObtenerElementos (string Expresion)
        {
            

        }

    }

}
