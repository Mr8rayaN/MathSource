using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DERIVADAS;
using ALGEBRA;

namespace TESTER
{
    public class TestDerivadas
    {
        private static void Main(string[] args)
        {
            TEST_Console_Derivada();
        }

        private static void TEST_Console_Derivada()
        {
            string Entrada = "2*x";
            Cosenos COS = new Cosenos();
            COS.SetArgumento(Entrada);
            CopDerivada DER = new CopDerivada(COS, new Variables("x"));
            Console.WriteLine($"ENTRADA          {COS.Result}");
            Console.WriteLine($"DERIVADA         {DER.Result}");
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }
    }
}
