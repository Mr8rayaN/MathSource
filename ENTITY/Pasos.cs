using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pasos
    {
        public Funcion Entrada { get; private set; }
        public Funcion Salida { get; private set; }
        public string Nombre { get; private set; }

        public Pasos (Funcion Entrada, Funcion Salida, string Nombre)
        {
            this.Entrada = Entrada;
            this.Salida = Salida;
            this.Nombre = Nombre;
        }
    }
}
