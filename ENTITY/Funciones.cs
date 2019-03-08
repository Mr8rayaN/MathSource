using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Funciones
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Contenido { get; set; }

        public Funciones()
        {

        }

        public Funciones(string Id, string Nombre, string Contenido)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Contenido = Contenido;
        }

    }
}
