using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace TESTER
{
    public class TestOpsNumericas
    {
        public static void Main(string[] args)
        {
            TEST_Consola();
        }

        private static void TEST_Consola()
        {
            string[] PRUEBA_OPS_MATHS = { "0", "44", "3", "-2", "x" };

            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    Console.WriteLine($"ENTRADAS {PRUEBA_OPS_MATHS[i]} | {PRUEBA_OPS_MATHS[j]} | {PRUEBA_OPS_MATHS[i]} | {PRUEBA_OPS_MATHS[j]}");

                    //Aplicacion del TEST

                    TEST_ENTITY_Suma(PRUEBA_OPS_MATHS[i], PRUEBA_OPS_MATHS[j]);

                    Console.WriteLine("----------------------------------");
                }
            }

            Console.Read();
        }

        private static void TEST_ENTITY_Cociente(string Uno, string Dos)
        {
            CocienteNatural COCIENTE = new CocienteNatural();
            Console.WriteLine(COCIENTE.Nombre);
            Console.WriteLine(COCIENTE.Result);
        }//OK

        private static void TEST_ENTITY_Suma(string Uno, string Dos)
        {
            SumaNatural SUMA = new SumaNatural(Uno + "+" + Dos + "+" + Uno + "+" + Dos);
            Console.WriteLine(SUMA.Nombre);
            Console.WriteLine(SUMA.Result);
        }//OK

        private static void TEST_ENTITY_Resta(string Uno, string Dos)
        {
            Sustracciones RESTA = new Sustracciones();
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
    }
}
