using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pasos
    {
        public string Entrada { get; set; }
        public string Salida { get; set; }
        public string ProcessName { get; set; }

        public Pasos (string Entrada, string Salida, string ProcessName)
        {
            this.Entrada = Entrada;
            this.Salida = Salida;
            this.ProcessName = ProcessName;
        }
    }
}
