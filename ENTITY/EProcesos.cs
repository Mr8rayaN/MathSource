using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class EProcesos
    {
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

        public List<Variables> EncapsularOps(string Expresion, char Symbol)
        {
            if (Expresion == null)
                return null;
            else if (!Expresion.Contains(Symbol))
                return null;

            string Temporal = Expresion;
            int Acomulador, i, j, k, Izq, Der;
            bool A, B;
            A = B = true;
            Acomulador = i = j = k = Izq = Der = 0;
            
            foreach (var elemento in Expresion)
            {
                if (elemento.Equals(Symbol))
                {
                    i = j = k;

                    while(A || B)
                    {
                        if (A)
                        {
                            //CUERPO
                            Izq += IsLlave(Expresion.ElementAt(i));
                            //FINCUERPO
                            if (i <= 0)
                                A = false;
                            --i;
                        }
                        if (B)
                        {
                            //CUERPO
                            Der += IsLlave(Expresion.ElementAt(j));
                            //FINCUERPO
                            if (j >= Expresion.Length - 1)
                                B = false;
                            ++j;
                        }
                    }

                    //MANIPULAR LA CANTIDAD DE PARENTESIS Y APLICAR RESULTADOS
                }

                ++k;
            }

        }

        private int IsLlave(char elemento)
        {
            if (elemento == '(' || elemento == '{')
                return 1;
            else if (elemento == ')' || elemento == '}')
                return -1;
            else
                return 0;
        }
    }
}
