using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    
    public class Suma : AMathOps
    {
        public string Nombre => "SUMA";
        public override int Modulo { get { return 0; } }
        public string Simbolo { get { return "+"; } }
        protected string SumandoUno { get; set; }
        protected string SumandoDos { get; set; }
        public string Result { get; protected set; }
        bool A = false, B = false, C = false;
        double number, a, b;

        public Suma(string SumandoUno, string SumandoDos)
        {
            this.SumandoUno = SumandoUno;
            this.SumandoDos = SumandoDos;

            AgregarOperadores(SumandoUno, SumandoDos);

            A = double.TryParse(SumandoUno, out number);
            B = double.TryParse(SumandoDos, out number);

            if (A & B)
            {
                a = double.Parse(SumandoUno);
                b = double.Parse(SumandoDos);

                Result = (a + b).ToString();
            }

            else
            {
                PolinomialProcess();                
            }
                
        }

        private void PolinomialProcess ()
        {
            
            string SumandoSinSigno = SumandoUno.TrimStart('-');
            A = SignoUno.Equals(SignoNegativo);

            if (SumandoSinSigno.Equals(SumandoDos) & A)
            {
                Result = Modulo.ToString();
            }

            else if (SumandoUno.Equals(SumandoDos))
            {
                Result = $"2*{SumandoUno}";
            }

            else
            {
                Result = SumandoUno + Simbolo + SumandoDos;
            } 
        }//OK
        
        public string PropiedadConmutativa ()
        {
            Result = SumandoDos + Simbolo + SumandoUno;
            return Result;
        }//OK
                
    } //OK
    

    public class Sustraccion : AMathOps
    {
        public string Nombre => "RESTA";
        public override int Modulo { get { return 0; } }
        public string Simbolo { get { return "-"; } }
        protected string Minuendo { get; set; }
        protected string Sustraendo { get; set; }
        public string Result { get; private set; }
        bool A = false, B = false, C = false, D = false, E = false;
        double number;

        public Sustraccion(string Minuendo, string Sustraendo)
        {
            this.Minuendo = Minuendo;
            this.Sustraendo = Sustraendo;

            AgregarOperadores(Minuendo, Sustraendo);

            A = SignoUno.Equals(SignoNegativo) ;

            if (Sustraendo.Equals(Modulo.ToString()))
            {
                Result = Minuendo;
            }

            else if (Minuendo.Equals(Sustraendo) & A)
            {
                Result = $"-2*{Minuendo}";
            }

            else if (Minuendo.Equals(Sustraendo))
            {
                Result = Modulo.ToString();
            }

            else
            {
                ParseProcess();                
            }

        }

        private void ParseProcess ()
        {
            A = double.TryParse(Minuendo, out number);
            B = double.TryParse(Sustraendo, out number);

            if (A & B)
            {
                double a = double.Parse(Minuendo);
                double b = double.Parse(Sustraendo);

                Result = (a - b).ToString();
            }

            else
            {
                Result = Minuendo + Simbolo + Sustraendo;
            }
        }

    }

    public class Cociente : AMathOps
    {
        public string Nombre => "COCIENTE";
        public override int Modulo { get { return 1;} }
        public int ModuloCancelativo { get { return 0; } }
        public string Simbolo { get { return "/"; } }
        public string Dividendo { get; set; }
        public string Divisor { get; set; }
        public string Signo { get; private set; }
        public string Result { get; set; }
        List<int> FactoresPrimosDividendo = new List<int>();
        List<int> FactoresPrimosDivisor = new List<int>();
        double number;

        public Cociente (string Dividendo, string Divisor)
        {
            this.Dividendo = Dividendo;
            this.Divisor = Divisor;

            Resolucion();

        }
        public Cociente (string Cociente)
        {
            ExtraerPartes(Cociente);
            Resolucion();
        }

        private void ExtraerPartes(string Cociente)
        {
            int indexOperador = Cociente.IndexOf(Simbolo);
            Dividendo = Cociente.Substring(0, indexOperador);
            Divisor = Cociente.Substring(indexOperador + 1);
        }

        private void Resolucion()
        {
            //Propiedades de cociente
            bool A = false, B = false, C = false, D = false, E = false;
            bool F = false;
            A = Dividendo.Equals(ModuloCancelativo.ToString());
            B = Divisor.Equals(ModuloCancelativo.ToString());
            C = Dividendo.Equals(Modulo.ToString());
            D = Divisor.Equals(Modulo.ToString());
            E = Dividendo.Equals(Divisor);
            F = double.TryParse(Dividendo, out number) & double.TryParse(Divisor, out number);

            if(B)
            {
                Result = "Math ERROR";
            }

            else if(A & !B)
            {
                Result = ModuloCancelativo.ToString();
            }

            else if (C & D)
            {
                Result = Modulo.ToString();
            }

            else if (D)
            {
                Result = Dividendo;
            }

            else if (E)
            {
                Result = Modulo.ToString();
            }

            else if (F)
            {
                double dividendo = double.Parse(Dividendo);
                double divisor = double.Parse(Divisor);
                SimplificarEnteros(dividendo, divisor);
            }
            else
            {
                Result = Dividendo + Simbolo + Divisor;
            }

        }

        private void SimplificarEnteros(double dividendo, double divisor)
        {
            //Siempre y cuando sean dos numeros enteros positivos

            if(dividendo % divisor == 0)
            {
                Result = (dividendo / divisor).ToString();
            }
            else if (dividendo == Modulo)
            {
                Result = $"{dividendo}/{divisor}";
            }
            else
            {
                if(dividendo<divisor)
                {
                    Result = SiDivisorMayorDividendo(dividendo, divisor);
                }

                else
                {
                    Result = SiDividendoMayorDivisor(dividendo, divisor);
                }
            }
        }

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

            foreach (var item in FactoresPrimosDivisor)
            {
                divisor *= item;
            }

            Dividendo = dividendo.ToString();
            Divisor = divisor.ToString();

            return Dividendo + Simbolo + Divisor;
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

            foreach (var item in FactoresPrimosDivisor)
            {
                divisor *= item;
            }

            Dividendo = dividendo.ToString();
            Divisor = divisor.ToString();

            return Dividendo + Simbolo + Divisor;
        } //OK
    }

    public class Producto : AMathOps
    {
        public string Nombre => "PRODUCTO";
        public override int Modulo { get { return 1; } }
        public string Simbolo { get { return "*"; } }
        public string FactorUno { get; set; }
        public string FactorDos { get; set; }
        public string Result { get; set; }
    }

    public abstract class Potencia : AMathOps
    {
        public string Nombre => "POTENCIA";
        public override int Modulo { get { return 1; } }
        public string Simbolo { get { return "^"; } }
        public string Base { get; set; }
        public string Exponente { get; set; }
        public string Result { get; set; }

    }
}
