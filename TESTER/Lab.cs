using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI;
using ENTITY;
using ALGEBRA;

namespace TESTER
{
    public class Lab
    {
        public static void main (string[] args)
        {
            
        }

        

        

        private static void TEST_ALGEBRA_Monomio(string Coeficiente, string ParteLiteral)
        {
            string Expresion = Coeficiente + "*"+ ParteLiteral;
            Monomios Monomio = new Monomios(Expresion);
            Console.WriteLine(Monomio.Nombre);
            Console.WriteLine("CONTENIDO     " + Monomio.Expresion);
            Console.WriteLine("COEFICIENTE   "+Monomio.Coeficiente);
            Console.WriteLine("PARTE LITERAL "+Monomio.ParteLiteral);
            Console.WriteLine("GRADO         "+Monomio.Grado);

        }

    }
}
