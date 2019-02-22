using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class SumaNatural : AMathOps
    {
        public override string Nombre => "SUMA";
        public override int Modulo { get { return 0; } }
        public override char Simbolo => '+';
        private List<string> Temporal = new List<string>();
        private List<string> ElementosParciales { get; set; }

        public SumaNatural(string Expresion)
        {
            Contenido = Expresion;
            ObtenerElementos(Expresion);
            CopyList(Temporal, Elementos);
            Operar();
        }

        private void CopyList(List<string> Copia, List<string> Original)
        {
            Copia.Clear();
            foreach (var item in Original)
            {
                Copia.Add(item);
            }
        }

        public override void Operar()
        {
            double Acomulador = 0;

            foreach(var elemento in Elementos)
            {
                try
                {
                    Acomulador += double.Parse(elemento);
                    Temporal.Remove(elemento);
                }
                catch (Exception) { }
            }

            NumeroElementos = Temporal.Count;

            if(Acomulador != 0)
                Temporal.Add($"{Acomulador}");

            else if(NumeroElementos == 0)
                Temporal.Add($"{Modulo}");

            foreach (var elemento in Temporal)
            {
                Result += elemento + Simbolo;
            }

            Result = Result.TrimEnd(Simbolo);
            Result = OperarSignos(Result);

        }
    }

    public class RestaNatural : AMathOps
    {

    }

    public class Productonatural : AMathOps
    {

    }

    public class CocienteNatural : AMathOps
    {

    }
    
    public class PotenciaNatural : AMathOps
    {

    }
}
