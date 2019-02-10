using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    
    public class Suma : AMathOps
    {
        public override string Nombre => "SUMA";
        public override int Modulo { get { return 0; } }
        public override string Simbolo { get { return "+"; } }
        protected string SumandoUno { get; private set; }
        protected string SumandoDos { get; private set; }

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

            else
            {
                Result = SumandoUno + Simbolo + SumandoDos;
            } 
        }//OK
        
        public void Conmutar ()
        {
            Result = SumandoDos + Simbolo + SumandoUno;
        }//OK
                
    } //OK
    
    public class Sustraccion : AMathOps
    {
        public override string Nombre => "RESTA";
        public override int Modulo { get { return 0; } }
        public override string Simbolo { get { return "-"; } }
        protected string Minuendo { get; private set; }
        protected string Sustraendo { get; private set; }
        
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

            else if (Minuendo.Equals(Sustraendo) && !A)
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

    } //OK

    public class Cociente : AMathOps
    {
        public override string Nombre => "COCIENTE";
        public override int Modulo { get { return 1;} }
        public int ModuloCancelativo { get { return 0; } }
        public override string Simbolo { get { return "/"; } }
        public string Dividendo { get; private set; }
        public string Divisor { get; private set; }
        
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
    } //OK

    public class Producto : AMathOps
    {
        public override string Nombre => "PRODUCTO";
        public override int Modulo { get { return 1; } }
        public override string Simbolo { get { return "*"; } }
        public string FactorUno { get; private set; }
        public string FactorDos { get; private set; }

        bool A;
        double number, a, b;

        public Producto(string FactorUno, string FactorDos)
        {
            A = false;

            this.FactorUno = FactorUno;
            this.FactorDos = FactorDos;

            AgregarOperadores(FactorUno, FactorDos);

            A = double.TryParse(FactorUno, out number) & double.TryParse(FactorDos, out number);

            if (A)
            {
                a = double.Parse(FactorUno);
                b = double.Parse(FactorDos);

                Result = (a * b).ToString();
            }
            else
            {
                Result = FactorUno + Simbolo + FactorDos;
            }
            
        }

        public void Conmutar()
        {
            Result = FactorDos + Simbolo + FactorUno;
        }


    } //OK

    public class Potencia : AMathOps
    {
        public override string Nombre => "POTENCIA";
        public override int Modulo { get { return 1; } }
        public int ModuloCancelativo { get { return 0; } }
        public override string Simbolo { get { return "^"; } }
        public string Base { get; set; }
        public string Exponente { get; set; }

        bool A, B, C, D, E;
        double number, a, b;

        public Potencia(string Base, string Exponente)
        {
            A = B = C = false;
            this.Base = Base;
            this.Exponente = Exponente;

            Procesointerno();
            
        }

        private void Procesointerno()
        {
            A = double.TryParse(Base, out number) & double.TryParse(Exponente, out number);
            B = Base.Equals(ModuloCancelativo);
            C = Exponente.Equals(ModuloCancelativo);
            D = Base.Equals(Modulo);
            E = Exponente.Equals(Modulo);

            if (B & C)
            {
                Result = "Math ERROR";
            }
            else if (C)
            {
                Result = Modulo.ToString();
            }
            else if (B)
            {
                Result = ModuloCancelativo.ToString();
            }
            else if (D)
            {
                Result = Modulo.ToString();
            }
            else if (E)
            {
                Result = Base;
            }
            else if (A)
            {
                a = double.Parse(Base);
                b = double.Parse(Exponente);

                Result = Math.Pow(a, b).ToString();
            }
            else
            {
                Result = "{"+ Base + "}" + Simbolo + "{" + Exponente + "}";
            }
        }

    }
}
