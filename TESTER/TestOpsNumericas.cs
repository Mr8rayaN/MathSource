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
            TEST_Consola_Multiple();
        }

        private static void TEST_Consola_Especifico()
        {
            TEST_ENTITY_Producto("-2","1");

            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Multiple()
        {
            string[] PRUEBA_OPS_MATHS = { "0", "-44", "3", "-2", "x" };

            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    Console.WriteLine($"ENTRADAS {PRUEBA_OPS_MATHS[i]} | {PRUEBA_OPS_MATHS[j]} | {PRUEBA_OPS_MATHS[i]} | {PRUEBA_OPS_MATHS[j]}");

                    //Aplicacion del TEST

                    TEST_ENTITY_Producto(PRUEBA_OPS_MATHS[i], PRUEBA_OPS_MATHS[j]);

                    Console.WriteLine("----------------------------------");
                }
            }

            Console.Read();
        }

        private static void TEST_ENTITY_Cociente(string Uno, string Dos)
        {
            CocienteEntero COCIENTE = new CocienteEntero();
            Console.WriteLine(COCIENTE.Nombre);
            Console.WriteLine(COCIENTE.Result);
        }//OK

        private static void TEST_ENTITY_Suma(string Uno, string Dos)
        {
            SumaEntera SUMA = new SumaEntera(Uno + "+" + Dos + "+" + Uno + "+" + Dos);
            Console.WriteLine(SUMA.ToString());
            Console.WriteLine(SUMA.Result);
        }//OK

        

        private static void TEST_ENTITY_Producto(string Uno, string Dos)
        {
            ProductoEntero Producto = new ProductoEntero(Uno + "*" + Dos + "*" + Dos + "*" + Dos);
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
