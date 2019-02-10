using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace TESTER
{
    public class Lab
    {
        public static void Main (string[] args)
        {
            string[] PRUEBA = { "2", "x", "2*x", "45", "y" };

            for(int i=0; i<5; ++i)
            {
                for(int j=0; j<5; ++j)
                {
                    Console.WriteLine($"ENTRADAS {PRUEBA[i]} | {PRUEBA[j]}");

                    //Aplicacion del TEST

                    TEST_ENTITY_Potencia_Monomial(PRUEBA[i], PRUEBA[j]);

                    Console.WriteLine("----------------------------------");
                }
            }

            Console.Read();
        }

        private static void TEST_ENTITY_Cociente_Monomial(string Uno, string Dos)
        {
            Cociente COCIENTE = new Cociente(Uno, Dos);
            Console.WriteLine(COCIENTE.Nombre);
            Console.WriteLine(COCIENTE.Result);
        }//OK

        private static void TEST_ENTITY_Suma_Monomial(string Uno, string Dos)
        {
            Suma SUMA = new Suma(Uno,Dos);
            Console.WriteLine(SUMA.Nombre);
            Console.WriteLine(SUMA.Result);
        }//OK

        private static void TEST_ENTITY_Sustraccion_Monomial(string Uno, string Dos)
        {
            Sustraccion RESTA = new Sustraccion(Uno,Dos);
            Console.WriteLine(RESTA.Nombre);
            Console.WriteLine(RESTA.Result);

        }

        private static void TEST_ENTITY_Producto_Monomial()
        {

        }

        private static void TEST_ENTITY_Potencia_Monomial(string Uno, string Dos)
        {
            Potencia POTENCIA = new Potencia(Uno, Dos);
            Console.WriteLine(POTENCIA.Nombre);
            Console.WriteLine(POTENCIA.Result);
        }



    }
}
