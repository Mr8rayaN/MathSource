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
            TEST_Consola_Monomio();
        }

        private static void TEST_Consola_Monomio()
        {
            string Entrada = "y^{2*4}*x*2*z*5";
            Entrada = "x*sen<x>";
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
            Polinomios POLI = new Polinomios(Entrada);
            Console.WriteLine(POLI.Nombre);
            Console.WriteLine($"ENTRADA = {Entrada}");
            Console.WriteLine("CONTENIDO   " + POLI.Contenido);
            Console.WriteLine("GRADO ABS   " + POLI.GradoAbs);
            Console.WriteLine(POLI.Result);
            Console.WriteLine("-----------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Euler()
        {
            string Entrada = "e^{e^{2}}";
            Eulers EULER = new Eulers(Entrada);
            Console.WriteLine($"{EULER.Nombre}");
            Console.WriteLine($"CONTENIDO     {EULER.Contenido}");
            Console.WriteLine($"ARGUMENTO     {EULER.Argumento}");
            Console.WriteLine($"RESULTADO     {EULER.Result}");
            Console.WriteLine("-------------------------------");
            Console.ReadKey();

        }

        private static void TEST_Consola_NLogaritmo()
        {
            string Entrada = "ln<-2>";
            //Entrada = "ln<ln<2>>";
            LogNaturales LN = new LogNaturales(Entrada);
            Console.WriteLine($"{LN.Nombre}");
            Console.WriteLine($"CONTENIDO     {LN.Contenido}");
            Console.WriteLine($"ARGUMENTO     {LN.Argumento}");
            Console.WriteLine($"RESULTADO     {LN.Result}");
            Console.WriteLine("-------------------------------");
            Console.ReadKey();

        }

        private static void TEST_Consola_Seno()
        {
            string Entrada = "sen<-2>";
            //Entrada = "ln<ln<2>>";
            Senos SENO = new Senos(Entrada);
            Console.WriteLine($"{SENO.Nombre}");
            Console.WriteLine($"CONTENIDO     {SENO.Contenido}");
            Console.WriteLine($"ARGUMENTO     {SENO.Argumento}");
            Console.WriteLine($"RESULTADO     {SENO.Result}");
            Console.WriteLine("-------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Coseno()
        {
            string Entrada = "cos<-2>";
            Entrada = "cos<ln<2>>";
            Cosenos COS = new Cosenos(Entrada);
            Console.WriteLine($"{COS.Nombre}");
            Console.WriteLine($"CONTENIDO     {COS.Contenido}");
            Console.WriteLine($"ARGUMENTO     {COS.Argumento}");
            Console.WriteLine($"RESULTADO     {COS.Result}");
            Console.WriteLine("-------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Tangente()
        {
            string Entrada = "tan<-2>";
            Entrada = "tan<ln<2>>";
            Tangentes TAN = new Tangentes(Entrada);
            Console.WriteLine($"{TAN.Nombre}");
            Console.WriteLine($"CONTENIDO     {TAN.Contenido}");
            Console.WriteLine($"ARGUMENTO     {TAN.Argumento}");
            Console.WriteLine($"RESULTADO     {TAN.Result}");
            Console.WriteLine("-------------------------------");
            Console.ReadKey();
        }
    }
}
