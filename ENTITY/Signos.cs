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
        public char SignoAbs { get { return ObtenerSignoAbs(); } }
        public string ListaSignos { get; private set; }

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

                        --i;
                    }
                }

                ++i;
            }

            return Expresion;
        }

        public void ObtenerSignos (string Expresion)
        {
            Expresion = OperarSignos(Expresion);
            ListaSignos = "";
            int i = 0;

            foreach (var elemento in Expresion)
            {
                if (EsUnSigno(elemento))
                {
                    ListaSignos += elemento;
                }
                else if(i == 0)
                {
                    ListaSignos += Pos;
                }

                ++i;
            }
        }

        private char ObtenerSignoAbs ()
        {
            char Signo = Pos;

            if (ListaSignos.Equals(""))
                return Signo;
            else
            {
                foreach (var elemento in ListaSignos)
                {
                    Signo = ProductoSignos(Signo, elemento);
                }
            }

            return Signo;
        }

        private char ProductoSignos(char SignoUno, char SignoDos)
        {
            if (SignoUno.Equals(SignoDos))
                return Pos;
            else
                return Neg;
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
