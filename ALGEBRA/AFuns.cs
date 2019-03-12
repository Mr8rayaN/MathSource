using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public abstract class AFuns
    {
        public virtual string Nombre { get;}
        public virtual string Simbolo { get;}
        public virtual string Contenido { get; protected set; }
        public virtual string Argumento { get; protected set; }
        public virtual char Op { get; }
        public virtual char Cl { get; }
        public string Result { get; protected set; }

        public EProcesos Proceso = new EProcesos();

        protected virtual void ObtenerArgumento() { }

        protected virtual void Operar() { }

    }
}
