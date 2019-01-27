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
        FuncionesService BLL = new FuncionesService();
        
        static void Main(string[] args)
        {
            Suma sum;
            Cociente cociente;
            while (true)
            {
                //sum = new Suma(Console.ReadLine(), Console.ReadLine());
                cociente = new Cociente(Console.ReadLine());
                //Console.WriteLine(sum.Result);
                Console.WriteLine(cociente.Result);
            }
        }
        
    }
}
