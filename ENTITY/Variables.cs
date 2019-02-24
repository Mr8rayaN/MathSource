﻿using System;
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

        public Variables(string Nombre)
        {
            Operable = true;
            this.Nombre = Nombre;
        }

        public Variables(string Nombre, bool Operable)
        {
            this.Nombre = Nombre;
            this.Operable = Operable;
        }
        public override string ToString()
        {
            return $"VARIABLE {Nombre} CONTIENE {Etiqueta} OPERABLE {Operable}";
        }

    }
}
