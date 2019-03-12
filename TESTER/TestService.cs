using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using ALGEBRA;
using BLL;

namespace TESTER
{
    public class TestService
    {
        public static void Main(string[] args)
        {
            TEST_BLL();
        }

        private static void TEST_BLL()
        {
            string Entrada = "x^{2}+sen<x>";
            Console.WriteLine($"Entrada {Entrada}");
            Console.WriteLine($"Proceso Derivar");
            Polinomios POL = new Polinomios(Entrada);
            Service BLL = new Service();
            BLL.Procesar(Entrada, BLL.ObtenerVariable(Entrada).ElementAt(0).Nombre, "Derivar");
            Console.WriteLine(BLL.Resultado.Contenido);
            Console.WriteLine("------------------------------------------");
            Console.ReadKey();
        }
    }
}
