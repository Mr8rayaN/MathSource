using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class SumaEntera : AMathOps 
    {
        public override string Nombre => "SUMA";
        public override int Modulo => 0;
        public override char Simbolo => '+';
        private List<string> Temporal = new List<string>();

        public SumaEntera(string Expresion)
        {
            Expresion = OperarSignos(Expresion);
            Contenido = Expresion;
            ObtenerSignos(Expresion);
            ObtenerElementos(Expresion, NumEntero.Simbolos);
            Proceso.CopyList(Temporal, Elementos);
            Operar();
        }
        

        public override void Operar()
        {
            double Acomulador, Parseo; int index;
            Acomulador = Parseo = index = 0;
            
            foreach(var elemento in Elementos)
            {
                try
                {
                    Parseo = double.Parse(elemento);
                    char signo = ListaSignos.ElementAt(index);

                    if (signo.Equals(NumEntero.SimboloLocal))
                        Acomulador -= Parseo;
                    else
                        Acomulador += Parseo;

                    Temporal.Remove(elemento);
                }
                catch (Exception) { }

                ++index;
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

        private void ObtenerElementos(string LElementos, string Simbolos)
        {
            Elementos.Clear();
            
            char simboloComun = '@';

            foreach (var simbolo in Simbolos)
            {
                LElementos = LElementos.Replace(simbolo, simboloComun);
            }

            foreach (var elemento in LElementos.Split(simboloComun))
            {
                Elementos.Add(elemento);
            }
            
        }

    }

    public class RestaNatural : AMathOps
    {
        public override string Nombre => "RESTA";
        public override int Modulo => 0;
        public override char Simbolo => '-';
        private List<string> Temporal = new List<string>();

        public RestaNatural(string Expresion)
        {
            ObtenerElementos(Expresion);
            Proceso.CopyList(Temporal, Elementos);
            Operar();
        }

        public override void Operar()
        {
            double Acomulador = 0;

            foreach (var elemento in Elementos)
            {
                try
                {
                    Acomulador -= double.Parse(elemento);
                    Temporal.Remove(elemento);
                }
                catch (Exception) { }
            }

            NumeroElementos = Temporal.Count;

            if (Acomulador != 0)
                Temporal.Add($"{Acomulador}");

            else if (NumeroElementos == 0)
                Temporal.Add($"{Modulo}");

            foreach (var elemento in Temporal)
            {
                Result += elemento + Simbolo;
            }

            Result = Result.TrimEnd(Simbolo);
            Result = OperarSignos(Result);
        }

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
