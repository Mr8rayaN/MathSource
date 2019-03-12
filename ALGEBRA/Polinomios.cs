using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public class Polinomios : AMathExp
    {
        public override string Nombre => "POLINOMIO";

        public List<Monomios> Elementos = new List<Monomios>();
        Monomios Monomio;
        
        public Polinomios()
        {
            Operacion = new SumaEntera();
        }

        public Polinomios(string Expresion)
        {
            Operacion = new SumaEntera();

        }

        protected override void ObtenerElementos()
        {
            

        }        

    }

}
