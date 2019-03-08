using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pasos
    {
        public string Id { get; set; }
        public string Id_Funcion { get; set; }
        public string Id_Resultado { get; set; }
        public string Entrada { get; set; }
        public string Salida { get; set; }
        public string Nombre { get; set; }

        public Pasos() { }

        public Pasos (string Entrada, string Salida, string Nombre)
        {
            this.Entrada = Entrada;
            this.Salida = Salida;
            this.Nombre = Nombre;
        }

        public void SetId (string Paso_id)
        {
            this.Id = Paso_id;
        }

        public void SetFuncion (string Funcion_id)
        {
            Id_Funcion = Funcion_id;
        }

        public void SetResultado (string Resultado_id)
        {
            Id_Resultado = Resultado_id;
        }
    }
}
