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
            TEST_Consola_Potencia();
        }

        private static void TEST_Consola_Suma()
        {
            string Entrada = "((x+2)+2+{x^2})";
            //Entrada = "((x*2)*4)*y";
            //Entrada = "x*2*2*y";
            Console.WriteLine($"ENTRADA = {Entrada}");
            SumaEntera SUMA = new SumaEntera(Entrada);
            Console.WriteLine(SUMA.Nombre);
            Console.WriteLine(SUMA.Result);
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Producto()
        {
            string Entrada = "(((x*2)*2)*({x}^{2}))";
            //Entrada = "((x*2)*4)*y";
            //Entrada = "x*2*2*y";
            Console.WriteLine($"ENTRADA = {Entrada}");
            ProductoEntero PRODUCTO = new ProductoEntero(Entrada);
            Console.WriteLine(PRODUCTO.Nombre);
            Console.WriteLine(PRODUCTO.Result);
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Cociente()
        {
            string Entrada = "{2/{{2/x}/{4/2}}}";
            Console.WriteLine($"ENTRADA = {Entrada}");
            CocienteEntero  COCIENTE = new CocienteEntero(Entrada);
            Console.WriteLine(COCIENTE.Nombre);
            Console.WriteLine(COCIENTE.Result);
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Potencia()
        {
            string Entrada = "{{{{x}^{2x}}^{2}}^{3x}}";
            Entrada = "sen<e^{x+2}>";
            Entrada = "2^{sen<e^{x+2}>}";
            Console.WriteLine($"ENTRADA = {Entrada}");
            PotenciaEntera POTENCIA = new PotenciaEntera(Entrada);
            Console.WriteLine(POTENCIA.Nombre);
            Console.WriteLine(POTENCIA.Result);
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }

        private static void TEST_Consola_Signos()
        {
            SumaEntera SUMA = new SumaEntera();
            string Entrada = "-x+2-3-2+(-x+3)";
            Console.WriteLine(Entrada);
            Console.WriteLine("Maximizando Signos "+SUMA.MaximizarSignos(Entrada));
            Console.WriteLine("Maximizando Signos " + SUMA.MaximizarSignos(SUMA.MaximizarSignos(Entrada)));
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
            CocienteEntero COCIENTE = new CocienteEntero("{x/2}/3");
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
    }
}
