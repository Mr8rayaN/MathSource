using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;

namespace Modulos
{
    class Program
    {
        string funcion = "";
        FuncionesService Servicio = new FuncionesService();

        static void Main(string[] args)
        {


            TEST_Propiedades();

            
            
        }

        static void TEST_Propiedades()
        {
            string funcion = "";
            OpsMatematicas propiedad = new OpsMatematicas();
            Procesos proceso = new Procesos();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingrese funcion = ");
                funcion = Console.ReadLine();
                Console.WriteLine($"Encorchado = {funcion = proceso.Encorchar(funcion)}");
                Console.WriteLine($"Agrupado = {funcion = propiedad.Agrupar(funcion)}");
                Console.WriteLine($"Distribuido = {funcion = propiedad.Distribuir(funcion)}");

                Console.ReadKey();
            }
        }

        static void TEST_Derivar()
        {
            string funcion = "";
            FuncionesService Servicio = new FuncionesService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingrese funcion");
                Console.Write("F = ");
                funcion = Console.ReadLine();

                foreach (var derivada in Servicio.DerivadaParcial(funcion))
                {
                    Console.WriteLine($"F'({derivada.Substring(0, derivada.IndexOf(';'))}) = {derivada.Substring(derivada.IndexOf(';') + 1)}");
                }

                Console.ReadKey();
            }
        }
    }
}
