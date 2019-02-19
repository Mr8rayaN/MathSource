using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    
    public class Sumas : AMathOps
    {
        public override string Nombre => "SUMA";
        public override int Modulo { get { return 0; } }
        public string Contenido { get; private set; }
        public override string Simbolo { get { return "+"; } }
        public List<string> Sumandos { get; set; }

        bool A = false, B = false, C = false;
        double number, a, b;

        public Sumas()
        {
            
        }

        public Sumas(string Expresion)
        {
            ObtenerElementos(Expresion);

            ProcesoInterno("SUMANDO_UNO","SUMANDO_DOS");
        }

        private void ObtenerElementos(string Expresion)
        {
            foreach (var item in Expresion.Split(Simbolo.ElementAtOrDefault(0)))
            {
                A = false;
                B = false;
                C = false;
                Sumandos.Add(item);
            }        } //OK

        private void ProcesoInterno(string SumandoUno, string SumandoDos)
        {
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
                PolinomialProcess("SUMANDO_UNO","SUMANDO_DOS");
            }
        }

        private void PolinomialProcess (string SumandoUno, string SumandoDos)
        {
            
            string SumandoSinSigno = SumandoUno.TrimStart('-');
            A = SumandoUno.StartsWith("-");

            if (SumandoSinSigno.Equals(SumandoDos) & A)
            {
                Result = Modulo.ToString();
            }

            else
            {
                Result = SumandoUno + Simbolo + SumandoDos;
            } 
        }//OK
        
        public void Conmutar (string SumandoUno, string SumandoDos)
        {
            Result = SumandoDos + Simbolo + SumandoUno;
        }//OK
                
    } //OK
    
    public class Sustracciones : AMathOps
    {
        public override string Nombre => "RESTA";
        public override int Modulo { get { return 0; } }
        public override string Simbolo { get { return "-"; } }
        protected string Minuendo { get; private set; }
        protected string Sustraendo { get; private set; }
        
        bool A = false, B = false;
        double number;

        public Sustracciones()
        {

        }

        public Sustracciones(string Minuendo, string Sustraendo)
        {
            this.Minuendo = Minuendo;
            this.Sustraendo = Sustraendo;

            ProcesoInterno();

        }

        public Sustracciones(string Resta)
        {
            ObtenerElementos(Resta);

            ProcesoInterno();
        }

        private void ObtenerElementos(string Expresion)
        {
            string[] Elementos = Expresion.Split(Simbolo.ElementAtOrDefault(0));
            Sustraendo = Elementos[0];
            Minuendo = Elementos[1];
        } //OK

        private void ProcesoInterno()
        {
            if (Sustraendo.Equals(Modulo.ToString()))
            {
                Result = Minuendo;
            }

            else if (Minuendo.Equals(Sustraendo))
            {
                Result = Modulo.ToString();
            }

            else
            {
                ParseProcess();
            }
        } //OK

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
        } //OK

    } //OK

    public class Cocientes : AMathOps
    {
        public override string Nombre => "COCIENTE";
        public override int Modulo { get { return 1;} }
        public int ModuloCancelativo { get { return 0; } }
        public override string Simbolo { get { return "/"; } }
        public string Dividendo { get; private set; }
        public string Divisor { get; private set; }
        public char Abrir => '{';
        public char Cerrar => '}';
        int signo = 1;

        List<int> FactoresPrimosDividendo = new List<int>();
        List<int> FactoresPrimosDivisor = new List<int>();
        double number;

        public Cocientes ()
        {

        }

        public Cocientes (string Dividendo, string Divisor)
        {
            this.Dividendo = Dividendo;
            this.Divisor = Divisor;

            Resolucion();

        } //OK

        public Cocientes (string Cociente)
        {
            ExtraerPartes(Cociente);
            Resolucion();
        } //OK

        private void ExtraerPartes(string Cociente)
        {
            int indexOperador = Cociente.IndexOf(Simbolo);
            Dividendo = Cociente.Substring(0, indexOperador);
            Divisor = Cociente.Substring(indexOperador + 1);
        } //OK

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
                Result = ("Math ERROR");
            }

            else if(A & !B)
            {
                Result = (ModuloCancelativo.ToString());
            }

            else if (C & D)
            {
                Result = (Modulo.ToString());
            }

            else if (D)
            {
                Result = (Dividendo);
            }

            else if (E)
            {
                Result = (Modulo.ToString());
            }

            else if (F)
            {
                double dividendo = double.Parse(Dividendo);
                double divisor = double.Parse(Divisor);
                SimplificarEnteros(dividendo, divisor);
            }
            else
            {
                Result = $"{Abrir}{Dividendo}{Simbolo}{Divisor}{Cerrar}";
            }

        } //OK

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

            if(dividendo % divisor == 0)
            {
                dividendo *= signo;
                Result = (dividendo / divisor).ToString();
            }
            else if (dividendo == Modulo)
            {
                dividendo *= signo;
                Result = $"{Abrir}{dividendo}{Simbolo}{divisor}{Cerrar}";
            }
            else
            {
                if(dividendo < divisor)
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

            return $"{Abrir}{Dividendo}{Simbolo}{Divisor}{Cerrar}";
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

            return $"{Abrir}{Dividendo}{Simbolo}{Divisor}{Cerrar}";
        } //OK

    } //OK

    public class Productos : AMathOps
    {
        public override string Nombre => "PRODUCTO";
        public override int Modulo { get { return 1; } }
        public int ModuloCancelativo => 0;
        public override string Simbolo { get { return "*"; } }
        public string FactorUno { get; private set; }
        public string FactorDos { get; private set; }

        bool A, B;
        double number, a, b;

        public Productos()
        {

        }

        public Productos(string FactorUno, string FactorDos)
        {
            this.FactorUno = FactorUno;
            this.FactorDos = FactorDos;

            ProcesoInterno();
        }

        public Productos(string Producto)
        {
            ObtenerElementos(Producto);

            ProcesoInterno();
        }

        private void ProcesoInterno()
        {
            A = double.TryParse(FactorUno, out number) & double.TryParse(FactorDos, out number);
            B = FactorUno.Equals(ModuloCancelativo.ToString()) || FactorDos.Equals(ModuloCancelativo.ToString());

            if (B)
            {
                Result = ModuloCancelativo.ToString();
            }
            else if (A)
            {
                a = double.Parse(FactorUno);
                b = double.Parse(FactorDos);

                Result = (a * b).ToString();
            }
            else
            {
                Result = FactorUno + Simbolo + FactorDos;
            }
        } //OK

        private void ObtenerElementos(string Expresion)
        {
            string[] Operadores = Expresion.Split(Simbolo.ElementAtOrDefault(0));
            FactorUno = Operadores[0];
            FactorDos = Operadores[1];
        }//OK

        public void Conmutar()
        {
            Result = FactorDos + Simbolo + FactorUno;
        } //OK


    } //OK

    public class Potencias : AMathOps
    {
        public override string Nombre => "POTENCIA";
        public override int Modulo { get { return 1; } }
        public int ModuloCancelativo { get { return 0; } }
        public override string Simbolo { get { return "^"; } }
        public string Base { get; private set; }
        public string Exponente { get; private set; }
        public char Abrir => '{';
        public char Cerrar => '}';

        bool A, B, C, D, E;
        double number, a, b;

        public Potencias()
        {

        }

        public Potencias(string Base, string Exponente)
        {
            
            this.Base = Base;
            this.Exponente = Exponente;

            Procesointerno();
            
        }

        public Potencias(string Potencia)
        {
            ObtenerElementos(Potencia);

            Procesointerno();
        }

        private void ObtenerElementos(string Expresion)
        {
            string[] Elemento = Expresion.Split(Simbolo.ElementAtOrDefault(0));
            Base = Elemento[0];
            Exponente = Elemento[1]; 
        } //OK

        private void Procesointerno()
        {
            A = B = C = D = E = false;
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
                Result = $"{Modulo}";
            }
            else if (B)
            {
                Result = $"{ModuloCancelativo}";
            }
            else if (D)
            {
                Result = $"{Modulo}";
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
                Result = $"{Abrir}{Base}{Simbolo}{Exponente}{Cerrar}";
            }
        } //OK

    } //OK
}
