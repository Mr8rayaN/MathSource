using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using ALGEBRA;

namespace DERIVADAS
{
    public class DProcesos
    {

        public bool IsFirstFuncion(Monomios MONO, AFuns FuncionIndagada)
        {
            foreach (var item in MONO.Elementos)
            {
                if (item.Result.StartsWith(FuncionIndagada.Simbolo))
                    return true;
            }

            return false;

        }
    }
}
