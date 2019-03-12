using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class EProcesos
    {
        private Funciones Fun = new Funciones();
        private List<Variables> Variables = new List<Variables>();
        char Open;
        char Close;

        public EProcesos()
        {
            Open = '{';
            Close = '}';
        }

        public void CopyList(List<string> Copia, List<string> Original)
        {
            Copia.Clear();
            foreach (var item in Original)
            {
                Copia.Add(item);
            }
        }

        public string ReplaceCharIn(string Original, string NewChar, int Index)
        {
            if (NewChar == null)
                return Original.Remove(Index, 1);
            if (Index > Original.Length || Index < 0
)
                return null;

            string PreCorte = Original.Substring(0,Index);
            string PostCorte = Original.Substring(Index + 1);

            return $"{PreCorte}{NewChar}{PostCorte}";
        }

        public int IsLlave(char elemento)
        {
            if (elemento == '(' || elemento == '{')
                return 1;
            else if (elemento == ')' || elemento == '}')
                return -1;
            else
                return 0;
        }

        public int CierreParentesis(string Expresion, int startIndex)
        {
            //retorna el indice de cierre;

            string E = Expresion;

            if (startIndex < 0)
            {
                return E.Length;
            }

            int abierto, i;

            abierto = i = 0;

            E = E.Substring(startIndex);

            foreach (var elemento in E)
            {
                if (elemento.Equals('('))
                    ++abierto;

                if (elemento.Equals(')'))
                    --abierto;

                if (abierto == 0)
                    break;

                ++i;
            }

            return i;

        }

        public int CierreFunciones(string Expresion, int startIndex)
        {
            //retorna el indice de cierre;
            

            string E = Expresion;

            if (startIndex < 0)
            {
                return E.Length;
            }

            int abierto, i;

            abierto = i = 0;

            E = E.Substring(startIndex);

            foreach (var elemento in E)
            {
                if (elemento.Equals(Open))
                    ++abierto;

                if (elemento.Equals(Close))
                    --abierto;

                if (abierto == 0)
                    break;

                ++i;
            }

            return i;

        }

        public string DescorcharFunciones(string Expresion)
        {
            string E = Expresion;
            bool A, B, C;
            A = E.StartsWith($"{Open}");
            int i = CierreFunciones(E, E.IndexOf(Open));
            B = E.LastIndexOf(Close).Equals(i);
            C = E.EndsWith($"{Close}");

            if (A & B & C)
            {
                return E.Substring(1, E.LastIndexOf(Close) - 1);
            }

            return E;
        }

        public string DescorcharParentesis(string Expresion)
        {
            string E = Expresion;
            bool A, B, C;
            A = E.StartsWith("(");
            B = E.LastIndexOf(")").Equals(CierreParentesis(E, E.IndexOf("(")));
            C = E.EndsWith(")");

            if (A & B & C)
            {
                return E.Substring(1, E.LastIndexOf(")") - 1);
            }

            return E;
        }

        public string EncorcharFuncion (string Expresion)
        {
            return $"{Open}{Expresion}{Close}";
        }

        public string EncorcharParentesis(string Expresion)
        {
            return $"({Expresion})";
        }

        public string DescorcharA(string Expresion)
        {
            Expresion = DescorcharFunciones(Expresion);
            return DescorcharParentesis(Expresion);
        }

        public bool IsAgrupate(string Expresion)
        {
            string E = Expresion;
            bool A, B, C;
            A = E.StartsWith($"{Open}");
            int i = CierreFunciones(E, E.IndexOf(Open));
            B = E.LastIndexOf(Close).Equals(i);
            C = E.EndsWith($"{Close}");

            if (A & B & C)
            {
                return true;
            }

            A = E.StartsWith("(");
            i = CierreParentesis(E, E.IndexOf("("));
            B = E.LastIndexOf(")").Equals(i);
            C = E.EndsWith(")");

            if (A & B & C)
            {
                return true;
            }

            return false;
        }

        public string ParentesisClear(string Expresion)
        {
            Expresion = Expresion.Replace("(","");
            Expresion = Expresion.Replace(")", "");
            return Expresion;
        }

        public string CorchetesClear(string Expresion)
        {
            Expresion = Expresion.Replace("{", "");
            Expresion = Expresion.Replace("}", "");
            return Expresion;
        }
    }
}
