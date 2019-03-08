using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;

namespace TESTER
{
    class Test_BD
    {
        public static void Main(string[] Args)
        {
            Service BLL = new Service();
            Funciones F = new Funciones("F0004", "TANGENTE", "Tan(x^2)");
            Console.WriteLine(BLL.ProximoPaso());
            Console.WriteLine("---------------------------------");
            Console.ReadKey();
        }
    }
}
