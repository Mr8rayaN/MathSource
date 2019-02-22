using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Signos
    {
        private char Pos => '+';
        private char Neg => '-';
        public char SignoAbs { get; private set; }

        public string OperarSignos(string Expresion)
        {
            int i = 0, LastIndex;

            foreach (var elemento in Expresion)
            {
                LastIndex = Expresion.Length - 1;

                if ( i < LastIndex)
                {
                    char siguiente = Expresion[i + 1];

                    if (EsUnSigno(elemento) & EsUnSigno(siguiente))
                    {
                        if(elemento == siguiente)
                        {
                            Expresion = Expresion.Replace($"{elemento}{siguiente}", $"{Pos}");
                        }
                        else
                        {
                            Expresion = Expresion.Replace($"{elemento}{siguiente}", $"{Neg}");
                        }
                    }
                }

                ++i;
            }

            return Expresion;
        }

        private bool EsUnSigno(char elemento)
        {
            if (elemento == Pos)
            {
                return true;
            }
            else if (elemento == Neg)
            {
                return true;
            }

            return false;
        }
        
    }
}
