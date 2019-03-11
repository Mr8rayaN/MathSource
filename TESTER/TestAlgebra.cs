using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using ALGEBRA;

namespace TESTER
{
    public class TestAlgebra
    {
        public static void Main(string[] args)
        {
            TEST_Consola_Polinomio();
        }

        private static void TEST_Consola_Moniomio()
        {
            string Entrada = "y^{2*4}*x*2*z*5";
            Monomios MONO = new Monomios(Entrada);
            Console.WriteLine(MONO.Nombre);
            Console.WriteLine($"ENTRADA = {Entrada}");
            Console.WriteLine("CONTENIDO   " + MONO.Contenido);
            Console.WriteLine("COEFICIENTE " + MONO.Coeficiente);
            Console.WriteLine("LITERAL     " + MONO.ParteLiteral);
            Console.WriteLine("GRADO ABS   " + MONO.GradoAbs);
            Console.WriteLine(MONO.Result);
            Console.WriteLine("-----------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Polinomio()
        {
            string Entrada = "x*2+(2)+(y^{2*4}*x*2*z*5)";
            CopPolinomios POLI = new CopPolinomios(Entrada);
            Console.WriteLine(POLI.Nombre);
            Console.WriteLine($"ENTRADA = {Entrada}");
            Console.WriteLine("CONTENIDO   " + POLI.Contenido);
            Console.WriteLine("GRADO ABS   " + POLI.GradoAbs);
            Console.WriteLine(POLI.Result);
            Console.WriteLine("-----------------------------------");
            Console.ReadKey();
        }
    }
}
