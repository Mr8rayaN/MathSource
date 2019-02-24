using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Variables
    {
        public string Nombre { get; private set; }
        public string Simbolo { get; private set; }
        public bool Operable { get; set; }
        public object Contenido { get; set; }

        public Variables(string Simbolo)
        {
            Operable = true;
            this.Simbolo = Simbolo;
            Nombre = $"Variable {Simbolo}";
        }

        public Variables(string Simbolo, bool Operable)
        {
            this.Simbolo = Simbolo;
            this.Operable = Operable;
            Nombre = $"Variable {Simbolo}";
        }

    }
}
