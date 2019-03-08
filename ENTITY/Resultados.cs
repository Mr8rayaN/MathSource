using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Resultados : Funciones
    {
        public string Estado { get; set; }

        public Resultados() { }

        public Resultados(string Id, string Nombre, string Contenido)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Contenido = Contenido;
            Estado = "Correcto";
        }

        public void SetEstado(string Estado)
        {
            this.Estado = Estado;
        }
    }
}
