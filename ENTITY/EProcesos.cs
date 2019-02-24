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
            if (Index > Original.Length || Index < 0)
                return null;

            string PreCorte = Original.Substring(0,Index);
            string PostCorte = Original.Substring(Index + 1);

            return $"{PreCorte}{NewChar}{PostCorte}";
        }
    }
}
