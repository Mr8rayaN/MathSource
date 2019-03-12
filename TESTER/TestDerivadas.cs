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
            TEST_Console_POLINOMIO_Derivada();
        }

        private static void TEST_Console_COS_Derivada()
        {
            string Entrada = "2*x";
            Cosenos COS = new Cosenos();
            COS.SetArgumento(Entrada);
            Derivadas DER = new Derivadas(COS, new Variables("x"));
            Console.WriteLine($"ENTRADA          {COS.Result}");
            Console.WriteLine($"DERIVADA         {DER.Result}");
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Console_SEN_Derivada()
        {
            string Entrada = "2*x";
            Senos SEN = new Senos();
            SEN.SetArgumento(Entrada);
            Derivadas DER = new Derivadas(SEN, new Variables("x"));
            Console.WriteLine($"ENTRADA          {SEN.Result}");
            Console.WriteLine($"DERIVADA         {DER.Result}");
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Console_TAN_Derivada()
        {
            string Entrada = "2*x";
            Tangentes TAN = new Tangentes();
            TAN.SetArgumento(Entrada);
            Derivadas DER = new Derivadas(TAN, new Variables("x"));
            Console.WriteLine($"ENTRADA          {TAN.Result}");
            Console.WriteLine($"DERIVADA         {DER.Result}");
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Console_EULER_Derivada()
        {
            string Entrada = "2*x";
            Eulers EUL = new Eulers();
            EUL.SetArgumento(Entrada);
            Derivadas DER = new Derivadas(EUL, new Variables("x"));
            Console.WriteLine($"ENTRADA          {EUL.Result}");
            Console.WriteLine($"DERIVADA         {DER.Result}");
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Console_LN_Derivada()
        {
            string Entrada = "2*x";
            LogNaturales LN = new LogNaturales();
            LN.SetArgumento(Entrada);
            Derivadas DER = new Derivadas(LN, new Variables("x"));
            Console.WriteLine($"ENTRADA          {LN.Result}");
            Console.WriteLine($"DERIVADA         {DER.Result}");
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Console_POLINOMIO_Derivada()
        {
            string Entrada = "2*x+x^{3}";
            Polinomios POLI = new Polinomios(Entrada);
            Derivadas DER = new Derivadas(POLI, new Variables("x"));
            Console.WriteLine($"ENTRADA          {POLI.Result}");
            Console.WriteLine($"DERIVADA         {DER.Result}");
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }
    }
}
