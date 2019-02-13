using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pasos
    {
        public string Id;
        public string Id_Funcion;
        public string Id_Resultado;
        public List<Funcion> Entrada { get; set; }
        public List<Funcion> Salida { get; set; }
        public string Nombre { get; private set; }

        public Pasos (List<Funcion> Entrada, List<Funcion> Salida, string Nombre)
        {
            this.Entrada = Entrada;
            this.Salida = Salida;
            this.Nombre = Nombre;
        }
    }
}
