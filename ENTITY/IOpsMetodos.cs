using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public interface IOpsMetodos
    {
        void Operar();
        void ObtenerElementos(string LElementos);
        string ObtenerNiveles(string Expresion);
        string ObtenerOrden(string Niveles);
        void ResolverNiveles();
        void ResolverVariables(List<Variables> LVariables, string Niveles, string Orden);
    }
}
