using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using ALGEBRA;

namespace TESTER
{
    public class Lab
    {
        public static void Main (string[] args)
        {
            string[] PRUEBA_OPS_MATHS = { "0", "x", "2*x", "44", "y" };
            string[] PRUEBA_MONOMIO_COE = { "0", "-2", "3", "21.5", "4/5", "2^2" };
            string[] PRUEBA_MONOMIO_LIT = { "{x^2}*y", "x*y*{z^2}", "x*y", "x", "y", "y*z"};

            for(int i=0; i<5; ++i)
            {
                for(int j=0; j<5; ++j)
                {
                    Console.WriteLine($"ENTRADAS {PRUEBA_MONOMIO_COE[i]} | {PRUEBA_MONOMIO_LIT[j]}");

                    //Aplicacion del TEST

                    TEST_ALGEBRA_Monomio(PRUEBA_MONOMIO_COE[i], PRUEBA_MONOMIO_LIT[j]);

                    Console.WriteLine("----------------------------------");
                }
            }

            Console.Read();
        }

        private static void TEST_ENTITY_Cociente(string Uno, string Dos)
        {
            Cocientes COCIENTE = new Cocientes(Uno, Dos);
            Console.WriteLine(COCIENTE.Nombre);
            Console.WriteLine(COCIENTE.Result);
        }//OK

        private static void TEST_ENTITY_Suma(string Uno, string Dos)
        {
            Sumas SUMA = new Sumas(Uno,Dos);
            Console.WriteLine(SUMA.Nombre);
            Console.WriteLine(SUMA.Result);
        }//OK

        private static void TEST_ENTITY_Resta(string Uno, string Dos)
        {
            Sustracciones RESTA = new Sustracciones(Uno,Dos);
            Console.WriteLine(RESTA.Nombre);
            Console.WriteLine(RESTA.Result);

        }

        private static void TEST_ENTITY_Producto(string Uno, string Dos)
        {
            Productos Producto = new Productos(Uno, Dos);
            Console.WriteLine(Producto.Nombre);
            Console.WriteLine(Producto.Result);
        }

        private static void TEST_ENTITY_Potencia(string Uno, string Dos)
        {
            Potencias POTENCIA = new Potencias(Uno, Dos);
            Console.WriteLine(POTENCIA.Nombre);
            Console.WriteLine(POTENCIA.Result);
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
