using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    
    public class Suma : AMathOps
    {
        private Signos Signo;
        ReemplazarDTO DTO;
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

            Signo = new Signos(SumandoUno, SumandoDos);

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
            A = Signo.SignoUno.Equals(Signo.SignoNegativo);
            B = SumandoUno.Contains("*") & SumandoDos.Contains("*");
            C = SumandoUno.Contains("/") & SumandoDos.Contains("/");

            if (SumandoSinSigno.Equals(SumandoDos) & A)
            {
                Result = Modulo.ToString();
            }

            else if (C)
            {
                SiAmbosSonCocientes();
            }

            else if (B)
            {
                SiAmbosSonProductos();
            }


            else if (SumandoUno.Equals(SumandoDos))
            {
                Result = $"2*{SumandoUno}";
            }

            else if (SumandoUno.Contains(SumandoDos))
            {
                SiUnoContieneADos();
            }

            else if (SumandoDos.Contains(SumandoUno))
            {
                SiDosContieneAUno();                
            }

            else
            {
                Result = SumandoUno + Simbolo + SumandoDos;
            }
        }

        private void SiAmbosSonCocientes()
        {
            
        }

        private void SiAmbosSonProductos()
        {
            int indexSumandoUno = SumandoUno.LastIndexOf("*");
            int indexSumandoDos = SumandoDos.LastIndexOf("*");
            string AparenteComunUno = SumandoUno.Substring(indexSumandoUno + 1);
            string AparenteComunDos = SumandoDos.Substring(indexSumandoDos + 1);
            bool C = AparenteComunUno.Equals(AparenteComunDos);

            if (C)
            {
                string SubSumandoUno = SumandoUno.Substring(0, indexSumandoUno);
                string SubSumandoDos = SumandoDos.Substring(0, indexSumandoDos);

                A = double.TryParse(SubSumandoUno, out number);
                B = double.TryParse(SubSumandoDos, out number);

                if(A & B)
                {
                    a = double.Parse(SubSumandoUno);
                    b = double.Parse(SubSumandoDos);
                    double c = a + b;

                    DTO = new ReemplazarDTO(SumandoUno);
                    DTO.AReemplazar = a.ToString();
                    DTO.Reemplazador = c.ToString();
                    DTO.StartIndexAReemplazar = 0;

                    Result = DTO.Reemplazado;
                }

                else
                {
                    Result = SumandoUno + Simbolo + SumandoDos;
                }
            }

            else
            {
                Result = SumandoUno + Simbolo + SumandoDos;
            }
        }
        
        private void SiUnoContieneADos()
        {
            int indexSumandoDos = SumandoUno.IndexOf(SumandoDos);
            string SubSumandoUno = SumandoUno.Substring(0, indexSumandoDos);

            if (SubSumandoUno.Contains("*"))
            {
                int indexProductoSimbol = SubSumandoUno.IndexOf("*");
                string Multiplo = SubSumandoUno.Substring(0, indexProductoSimbol);

                A = double.TryParse(Multiplo, out number);

                if (A)
                {
                    a = double.Parse(Multiplo);

                    a = a + 1;

                    DTO = new ReemplazarDTO(SumandoUno);
                    DTO.AReemplazar = Multiplo;
                    DTO.Reemplazador = a.ToString();
                    DTO.StartIndexAReemplazar = 0;

                    Result = DTO.Reemplazado;
                    
                }

                else
                {
                    Result = SumandoUno + Simbolo + SumandoDos;
                }
            }

            else
            {
                Result = SumandoUno + Simbolo + SumandoDos;
            }
        }

        private void SiDosContieneAUno()
        {
            int indexSumandoUno = SumandoDos.IndexOf(SumandoUno);
            string SubSumandoDos = SumandoDos.Substring(0, indexSumandoUno);

            if (SubSumandoDos.Contains("*"))
            {
                int indexProductoSimbol = SubSumandoDos.IndexOf("*");
                string Multiplo = SubSumandoDos.Substring(0, indexProductoSimbol);

                A = double.TryParse(Multiplo, out number);

                if (A)
                {
                    a = double.Parse(Multiplo);

                    a = a + 1;

                    DTO = new ReemplazarDTO(SumandoDos);
                    DTO.AReemplazar = Multiplo;
                    DTO.Reemplazador = a.ToString();
                    DTO.StartIndexAReemplazar = 0;

                    Result = DTO.Reemplazado;
                }

                else
                {
                    Result = SumandoUno + Simbolo + SumandoDos;
                }
            }

            else
            {
                Result = SumandoUno + Simbolo + SumandoDos;
            }
        }

        public string PropiedadConmutativa ()
        {
            Result = SumandoDos + Simbolo + SumandoUno;
            return Result;
        }
                
    }

    //ACTUAL PROGRESS

    public class Sustraccion : AMathOps
    {
        public override int Modulo { get { return 0; } }
        public string Simbolo { get { return "-"; } }
        protected string Minuendo { get; set; }
        protected string Sustraendo { get; set; }
        public string Result { get; private set; }
        bool A = false, B = false;
        double number;

        public Sustraccion() { }
        public Sustraccion(string Minuendo, string Sustraendo)
        {
            this.Minuendo = Minuendo;
            this.Sustraendo = Sustraendo;

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
        public override int Modulo { get { return 1;} }
        public int ModuloCancelativo { get { return 0; } }
        public string Simbolo { get { return "/"; } }
        public string Dividendo { get; set; }
        public string Divisor { get; set; }
        public string Signo { get; private set; }
        public string Result { get; set; }
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

        }

        private void SimplificarEnteros(double dividendo, double divisor)
        {
            //Siempre y cuando sean dos numeros enteros positivos

            bool A = false, B = false;
            int i = 0, j = 0, sobra = 0;
            double menor = Math.Min(dividendo, divisor);
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
                List<int> FactoresPrimosDividendo = new List<int>();
                List<int> FactoresPrimosDivisor = new List<int>();
                if(menor == dividendo)
                {
                    
                    for (i = 2; i <= (divisor/2); i++)
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
                                int indexToRemove = FactoresPrimosDivisor.IndexOf(i);
                                FactoresPrimosDivisor.RemoveAt(indexToRemove);
                            }

                            else
                            {
                                FactoresPrimosDividendo.Add(i);
                            }
                            
                            i = 2;
                        }
                    }
                    FactoresPrimosDividendo.Add((int)dividendo);


                    dividendo = 0;
                    divisor = 0;

                    foreach(var item in FactoresPrimosDividendo)
                    {
                        dividendo *= item;
                    }
                
                    foreach(var item in FactoresPrimosDivisor)
                    {
                        divisor *= item;
                    }

                    Dividendo = dividendo.ToString();
                    Divisor = divisor.ToString();

                    Result = Dividendo + Simbolo + Divisor;

                }

                else
                {
                    //Simplificacion cuando menor es el divisor
                }
            }
        }
    }

    public class Producto : AMathOps
    {
        public override int Modulo { get { return 1; } }
        public string Simbolo { get { return "*"; } }
        public string FactorUno { get; set; }
        public string FactorDos { get; set; }
        public string Result { get; set; }
    }

    public abstract class Potencia : AMathOps
    {
        public override int Modulo { get { return 1; } }
        public string Simbolo { get { return "^"; } }
        public string Base { get; set; }
        public string Exponente { get; set; }
        public string Result { get; set; }

    }
}
