using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class AMathOps : Signos
    {
        public virtual int Modulo { get;}
        public virtual string Nombre { get; }
        public virtual string Simbolo { get; }
        public string Result { get; protected set; }
    }
}
