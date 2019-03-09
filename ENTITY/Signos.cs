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

        public void ObtenerSignos (string SumaEnteros)
        {
            ListaSignos = "";
            int i = 0;

            foreach (var elemento in SumaEnteros)
            {
                if (EsUnSigno(elemento))
                {
                    ListaSignos += elemento;
                }
                else if (i == 0)
                {
                    ListaSignos += Pos;
                    ++i;
                }
            }
        }

        public void ObtenerSignos (List<string> Elementos)
        {
            ListaSignos = "";

            foreach (var elemento in Elementos)
            {
                ListaSignos += SignoAbsDe(elemento);
            }
        }

        public char SignoAbsDe(string Expresion)
        {
            char signo = Pos;
            foreach (var elemento in Expresion)
            {
                if (EsUnSigno(elemento))
                {
                    signo = ProductoSignos(signo,elemento);
                }
            }

            return signo;
        }

        private char ObtenerSignoAbs()
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

        public string MaximizarSignos(string Expresion)
        {
            string Maximizado = "";
            int i = 0;
            foreach (var elemento in Expresion.Split(Neg))
            {
                if (i == 0 & Expresion.StartsWith(elemento))
                {
                    Maximizado = elemento;
                    ++i;
                }
                else if (!elemento.Equals(""))
                {
                    Maximizado += $"{Pos}{Neg}{elemento}";
                }
            }

            return Maximizado;
        }
        
        public bool IsOpposite(string ExpresionUno, string ExpresionDos)
        {
            if (PrimerSigno(ExpresionUno).Equals(PrimerSigno(ExpresionDos)))
                return false;
            else
            {
                ExpresionUno = ExtraerPrimerSigno(ExpresionUno);
                ExpresionDos = ExtraerPrimerSigno(ExpresionDos);

                if (ExpresionUno.Equals(ExpresionDos))
                    return true;

                return false;
            }
        }

        private string ExtraerPrimerSigno(string Expresion)
        {
            if (EsUnSigno(Expresion.ElementAt(0)))
                return Expresion.Substring(1, Expresion.Length - 1);

            return Expresion;
        }

        private char PrimerSigno(string Expresion)
        {
            if (EsUnSigno(Expresion.ElementAt(0)))
                return Expresion.ElementAt(0);

            return Pos;
        }

    }
}
