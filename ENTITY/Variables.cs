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
        public bool Operable { get; set; }
        public string Etiqueta { get; set; }
        public object Contenido { get; set; }
        public char Simbolo => '@';

        public Variables()
        {

        }

        public Variables(string Nombre)
        {
            Operable = true;
            this.Nombre = Nombre;
        }

        public Variables(string Nombre, string Etiqueta, object Contenido, bool Operable)
        {
            this.Nombre = Nombre;
            this.Etiqueta = Etiqueta;
            this.Contenido = Contenido;
            this.Operable = Operable;
        }
        public override string ToString()
        {
            return $"  VARIABLE {Nombre}; ETIQUETA {Etiqueta}; CONTENIDO {Contenido.ToString()}  ";
        }

    }
}
