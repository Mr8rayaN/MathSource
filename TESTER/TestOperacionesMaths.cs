using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using ENTITY;

namespace TESTER
{
    public class TestOperacionesMaths
    {
        public static void Main(string[] args)
        {
            FuncionesService BLL = new FuncionesService();
            Funcion F = new Funcion("F0003","TANGENTE","Tan(x^2)");

            BLL.Guardar(F);
            Console.WriteLine(BLL.Respuesta);
            Console.ReadKey();
        }
    }
}
