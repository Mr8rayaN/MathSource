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
        public override int Modulo { get { return 0; } }
        public string Simbolo { get { return "+"; } }
        protected string SumandoUno { get; set; }
        protected string SumandoDos { get; set; }
        public string Result { get; protected set; }
        bool A = false, B = false;
        double number, a, b;

        public Suma() { }
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
            ReemplazarDTO DTO;

            if (Signo.SignoUno.Equals(Signo.SignoNegativo))
            {

                string SumandoSinSigno = SumandoUno.TrimStart('-');

                if (SumandoSinSigno.Equals(SumandoDos))
                {
                    Result = Modulo.ToString();
                }
            }

            else if (SumandoUno.Equals(SumandoDos))
            {
                Result = $"2*{SumandoUno}";
            }

            else if (SumandoUno.Contains(SumandoDos))
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
                        SumandoUno = DTO.Reemplazado;

                        Result = SumandoUno;
                    }

                    else
                    {
                        Result = SumandoUno + Simbolo + SumandoDos;
                    }
                }
            }

            else if (SumandoDos.Contains(SumandoUno))
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
                        SumandoUno = DTO.Reemplazado;

                        Result = SumandoDos;
                    }

                    else
                    {
                        Result = SumandoUno + Simbolo + SumandoDos;
                    }
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
        public string Simbolo { get { return "/"; } }
        public string Dividendo { get; set; }
        public string Divisor { get; set; }
        public string Result { get; set; }
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
