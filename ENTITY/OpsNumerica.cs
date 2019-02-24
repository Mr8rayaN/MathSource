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
        private string SignosTemporal { get; set; }

        public SumaEntera()
        {

        }

        public SumaEntera(string Expresion)
        {
            Expresion = OperarSignos(Expresion);
            Contenido = Expresion;
            ObtenerSignos(Expresion);
            ObtenerElementos(Expresion, NumEntero.Simbolos);
            Proceso.CopyList(Temporal, Elementos);
            SignosTemporal = ListaSignos;
            Operar();
        }
        
        public override void Operar()
        {
            char signo = ' ';
            double Acomulador, Parseo; int index;
            Acomulador = Parseo = index = Modulo;
            
            foreach(var elemento in Elementos)
            {
                try
                {
                    Parseo = double.Parse(elemento);
                    signo = ListaSignos.ElementAt(index);
                    
                    if (signo.Equals(NumEntero.SimboloLocal))
                        Acomulador -= Parseo;
                    else
                        Acomulador += Parseo;

                    SignosTemporal = Proceso.ReplaceCharIn(SignosTemporal, "@", index);
                    Temporal.Remove(elemento);
                }
                catch (Exception) { }

                ++index;
            }

            SignosTemporal = SignosTemporal.Replace("@","");

            NumeroElementos = Temporal.Count;

            if (Acomulador != 0) {
                SignosTemporal += SignoAbsDe($"{Acomulador}");
                Temporal.Add($"{Math.Abs(Acomulador)}");
            }
                
            else if(NumeroElementos == 0)
            {
                Temporal.Add($"{Modulo}");
                SignosTemporal += SignoAbsDe($"{Modulo}");
            }

            index = 0;
            Result = "";

            foreach (var elemento in Temporal)
            {
                signo = SignosTemporal.ElementAtOrDefault(index);
                if(signo.Equals(NumEntero.Naturales.SimboloLocal) & Result.Equals(""))
                    Result += elemento;
                else
                    Result += signo + elemento;

                ++index;
            }

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

            LElementos = LElementos.Trim(simboloComun);

            foreach (var elemento in LElementos.Split(simboloComun))
            {
                Elementos.Add(elemento);
            }
            
        }

    }

    public class ProductoEntero : AMathOps
    {
        public override string Nombre => "PRODUCTO";
        public override int Modulo => 1;
        public int ModuloCancelativo => 0;
        public override char Simbolo => '*';
        private List<string> Temporal = new List<string>();
        private string SignosTemporal { get; set; }

        public ProductoEntero()
        {

        }

        public ProductoEntero(string Expresion)
        {
            Contenido = Expresion;
            ObtenerElementos(Expresion);
            ObtenerSignos(Elementos);
            Proceso.CopyList(Temporal,Elementos);
            Operar();
        }

        public override void Operar()
        {
            double Parseo, Acomulador;
            Parseo = Acomulador = Modulo;

            foreach (var elemento in Elementos)
            {
                try
                {
                    Parseo = double.Parse(elemento);
                    if(Parseo == ModuloCancelativo)
                    {
                        Temporal.Clear();
                        Acomulador = ModuloCancelativo;
                        Temporal.Add($"{ModuloCancelativo}");
                        break;
                    }
                    Acomulador *= Parseo;
                    Temporal.Remove(elemento);
                }
                catch (Exception) { }
            }

            if (Acomulador != ModuloCancelativo)
            {
                if (Temporal.Count == 0)
                {
                    Temporal.Add($"{Acomulador}");
                }
                else if(Acomulador != Modulo)
                {
                    Temporal.Add($"{Acomulador}");
                }

            }

            Result = "";

            foreach (var elemento in Temporal)
            {
                if (Result.Equals(""))
                    Result += elemento;
                else
                    Result += Simbolo + elemento;
            }
        }
        
    }

    public class CocienteEntero : AMathOps
    {
        public override string Nombre => "COCIENTE";
        public override int Modulo => 1;
        public int ModuloCancelativo => 0;
        public override char Simbolo => '/';
        public string Dividendo { get; private set; }
        public string Divisor { get; private set; }
        private List<string> Temporal = new List<string>();
        private string SignosTemporal { get; set; }
        List<int> FactoresPrimosDividendo = new List<int>();
        List<int> FactoresPrimosDivisor = new List<int>();
        double number; int signo = 1;

        public CocienteEntero()
        {

        }

        public CocienteEntero(string Expresion)
        {

        }

        public override void Operar()
        {

        }

        private void SimplificarEnteros(double dividendo, double divisor)
        {
            //Multiplicacion de signos

            if (dividendo < 0)
            {
                signo = -1;
                dividendo = Math.Abs(dividendo);
            }

            else if (divisor < 0)
            {
                signo *= -1;
                divisor = Math.Abs(divisor);
            }

            //Comienza el proceso

            if (dividendo % divisor == 0)
            {
                dividendo *= signo;
                Result = (dividendo / divisor).ToString();
            }
            else if (dividendo == Modulo)
            {
                dividendo *= signo;
                Result = $"{dividendo}{Simbolo}{divisor}";
            }
            else
            {
                if (dividendo < divisor)
                {
                    Result = SiDivisorMayorDividendo(dividendo, divisor);
                }

                else
                {
                    Result = SiDividendoMayorDivisor(dividendo, divisor);
                }
            }
        } //OK

        private string SiDividendoMayorDivisor(double dividendo, double divisor)
        {
            int i, indexToRemove;

            //Simplificacion cuando menor es el divisor
            for (i = 2; i <= (dividendo / 2); i++)
            {
                if (dividendo % i == 0)
                {
                    dividendo = dividendo / i;
                    FactoresPrimosDividendo.Add(i);
                    i = 2;
                }
            }
            FactoresPrimosDividendo.Add((int)dividendo);

            for (i = 2; i <= (divisor / 2); i++)
            {
                if (divisor % i == 0)
                {
                    divisor = divisor / i;

                    //Simplificacion en curso
                    if (FactoresPrimosDividendo.Contains(i))
                    {
                        indexToRemove = FactoresPrimosDividendo.IndexOf(i);
                        FactoresPrimosDividendo.RemoveAt(indexToRemove);
                    }

                    else
                    {
                        FactoresPrimosDivisor.Add(i);
                    }

                    i = 2;
                }
            }

            if (FactoresPrimosDividendo.Contains((int)divisor))
            {
                indexToRemove = FactoresPrimosDividendo.IndexOf((int)divisor);
                FactoresPrimosDividendo.RemoveAt(indexToRemove);
            }

            else
            {
                FactoresPrimosDivisor.Add((int)divisor);
            }

            dividendo = 1;
            divisor = 1;

            foreach (var item in FactoresPrimosDividendo)
            {
                dividendo *= item;
            }

            dividendo *= signo;

            foreach (var item in FactoresPrimosDivisor)
            {
                divisor *= item;
            }

            Dividendo = dividendo.ToString();
            Divisor = divisor.ToString();

            return $"{Dividendo}{Simbolo}{Divisor}";
        } //OK

        private string SiDivisorMayorDividendo(double dividendo, double divisor)
        {
            int i, indexToRemove;

            for (i = 2; i <= (divisor / 2); i++)
            {
                if (divisor % i == 0)
                {
                    divisor = divisor / i;
                    FactoresPrimosDivisor.Add(i);
                    i = 2;
                }
            }

            FactoresPrimosDivisor.Add((int)divisor);

            for (i = 2; i <= (dividendo / 2); i++)
            {
                if (dividendo % i == 0)
                {
                    dividendo = dividendo / i;

                    //Simplificacion en curso
                    if (FactoresPrimosDivisor.Contains(i))
                    {
                        indexToRemove = FactoresPrimosDivisor.IndexOf(i);
                        FactoresPrimosDivisor.RemoveAt(indexToRemove);
                    }

                    else
                    {
                        FactoresPrimosDividendo.Add(i);
                    }

                    i = 2;
                }
            }

            if (FactoresPrimosDivisor.Contains((int)dividendo))
            {
                indexToRemove = FactoresPrimosDivisor.IndexOf((int)dividendo);
                FactoresPrimosDivisor.RemoveAt(indexToRemove);
            }

            else
            {
                FactoresPrimosDividendo.Add((int)dividendo);
            }

            dividendo = 1;
            divisor = 1;

            foreach (var item in FactoresPrimosDividendo)
            {
                dividendo *= item;
            }

            dividendo *= signo;

            foreach (var item in FactoresPrimosDivisor)
            {
                divisor *= item;
            }

            Dividendo = dividendo.ToString();
            Divisor = divisor.ToString();

            return $"{Dividendo}{Simbolo}{Divisor}";
        } //OK
    }
    
    public class PotenciaNatural : AMathOps
    {

    }
}
