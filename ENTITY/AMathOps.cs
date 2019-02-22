using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class AMathOps : Signos , IOpsMetodos
    {
        public virtual int Modulo { get;}
        public virtual string Nombre { get; }
        public virtual char Simbolo { get; }
        public string Contenido { get; protected set; }
        public string Result { get; protected set; }
        public int NumeroElementos { get; protected set; }
        public List<string> Elementos = new List<string>();

        public virtual void Operar()
        {

        }

        public void ObtenerElementos(string LElementos)
        {
            Contenido = "";
            foreach (var item in LElementos.Split(Simbolo))
            {
                Elementos.Add(item);
                Contenido += item + Simbolo;
            }
        }

        public override string ToString()
        {
            return $"{Nombre} ({Contenido})";
        }
    }
}
