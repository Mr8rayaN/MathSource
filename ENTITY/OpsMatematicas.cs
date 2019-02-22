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
        public override char Simbolo => '+';
        public List<string> Sumandos { get; set; }
        private List<string> Temporal { get; set; }
        private List<string> SumandosParciales { get; set; }

        bool A = false, B = false, C = false;
        double number, a, b;

        public Sumas()
        {
            
        }

        public Sumas(string Expresion)
        {
            Sumandos = new List<string>();
            ObtenerElementos(Expresion);
            PropiedadesInternas();
            Operar();
        }

        private void PropiedadesInternas()
        {
            Temporal = new List<string>();
            if (Sumandos.Count == 1)
            {
                if (Sumandos.ElementAtOrDefault(0).Equals(Modulo))
                {
                    Result = $"{Modulo}";
                }
                else
                {
                    Result = $"{Sumandos.ElementAtOrDefault(0)}";
                }
            }

            foreach (var sumando in Sumandos)
            {
                if (!sumando.Equals($"{Modulo}")) {
                    Temporal.Add(sumando);
                }
            }

            if (Temporal.Count == 0)
            {
                Temporal.Add($"{Modulo}");
                Result = $"{Modulo}";
            }
            else if(Temporal.Count == 1)
            {
                Result = Temporal.ElementAtOrDefault(0);
            }
                
        }

        public override void Operar()
        {
            int i = 0, j = 0;
            if (Temporal.Count > 1)
            {
                Result = "";
                SumandosParciales = Temporal;
                string Uno, Dos;
                double SumaUno, SumaDos = 0;
                bool Sumado = false, Agrupado = false; ;

                i = j = 0;
                while (i < SumandosParciales.Count)
                {
                    if (Sumado)
                    {
                        Sumado = false;
                        --i;
                    }                        

                    j = 0;

                    Uno = SumandosParciales[i];
                    A = double.TryParse(SumandosParciales[i], out number);

                    if (Agrupado == true)
                    {
                        Agrupado = false;
                        i++;
                    }
                    else
                    {
                        Sumado = false;
                        
                        if (i < Sumandos.Count - 1)
                        {
                            j = i + 1;

                            while (j < SumandosParciales.Count)
                            {
                                B = double.TryParse(SumandosParciales[j], out number);
                                Dos = SumandosParciales[j];

                                if (A & B)
                                {
                                    SumaUno = double.Parse(Uno);
                                    SumaDos = double.Parse(Dos);

                                    SumaUno += SumaDos;

                                    SumandosParciales[i] = Uno = $"{SumaUno}";
                                    SumandosParciales.RemoveAt(j);
                                    Sumado = true;
                                }
                                else if (Uno.Equals(Dos))
                                {
                                    if (i < j - 1)
                                    {
                                        SumandosParciales.Insert(i, Dos);
                                        SumandosParciales.RemoveAt(j + 1);
                                        Agrupado = true;
                                    }
                                }

                                ++j;
                            }
                        }

                        
                        ++i;
                    }
                    

                }


                i = 0;
                foreach (var item in SumandosParciales)
                {
                    if (i > 0)
                        Result += Simbolo + SumandosParciales[i];
                    else
                        Result += SumandosParciales[i];

                    ++i;
                }
            }
            

        }
        
    }
    
    public class Sustracciones : AMathOps
    {
        public override string Nombre => "RESTA";
        public override int Modulo { get { return 0; } }
        public override char Simbolo => '-';
        protected string Minuendo { get; private set; }
        protected string Sustraendo { get; private set; }

        private List<string> Temporal { get; set; }
        private List<string> PartesParciales { get; set; }
        
        bool A = false, B = false;
        double number;

        public Sustracciones()
        {

        }

        public Sustracciones(string Resta)
        {
            ObtenerElementos(Resta);

            Operar();
        }



        public override void Operar()
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
        public override char Simbolo => '/';
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

            Operar();

        } //OK

        public Cocientes (string Cociente)
        {
            ExtraerPartes(Cociente);
            Operar();
        } //OK

        private void ExtraerPartes(string Cociente)
        {
            int indexOperador = Cociente.IndexOf(Simbolo);
            Dividendo = Cociente.Substring(0, indexOperador);
            Divisor = Cociente.Substring(indexOperador + 1);
        } //OK

        public override void Operar()
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
        public override char Simbolo => '*';
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

            Operar();
        }

        public Productos(string Producto)
        {
            ObtenerElementos(Producto);

            Operar();
        }

        public override void Operar()
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
        public override char Simbolo => '^';
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

            Operar();
            
        }

        public Potencias(string Potencia)
        {
            ObtenerElementos(Potencia);

            Operar();
        }

        public override void Operar()
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
