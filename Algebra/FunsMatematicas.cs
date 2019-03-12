using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public class Eulers : AFuns
    {
        public override string Nombre => "EULER";
        public override string Simbolo => "e";
        public override string SimboloExtendido => "e^{";
        private string Valor => "2.71828";
        private string ArgDefecto => "1";
        public override char Op => '{';
        public override char Cl => '}';
        PotenciaEntera Potencia;
        double number;

        public Eulers() {

            Argumento = ArgDefecto;
            Potencia = new PotenciaEntera(Simbolo, Argumento);
            Contenido = Simbolo + Potencia.Simbolo + Argumento;
            Operar();

        }

        public Eulers(string Expresion)
        {

            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            Contenido = Expresion;
            ObtenerArgumento();
            Operar();

        }
        

        protected override void ObtenerArgumento()
        {
            Potencia = new PotenciaEntera(Contenido);
            Argumento = Proceso.DescorcharA(Potencia.Exponente);
        }

        protected override void Operar()
        {
            if (double.TryParse(Argumento, out number))
                Result = new PotenciaEntera(Valor, Argumento).Result;
            else
                Result = Potencia.Result;
        }

        public override string ToString()
        {
            return $"{Nombre} {Contenido}";
        }

    }

    public class LogNaturales : AFuns
    {
        public override string Nombre => "LOG NATURAL";
        public override string Simbolo => "ln";
        public override string SimboloExtendido => "ln<";
        public override char Op => '<';
        public override char Cl => '>';
        private string ArgDefecto => "1";
        public double ModuloCancelativo => 0;
        double number;

        public LogNaturales()
        {
            Argumento = ArgDefecto;
            Contenido = SimboloExtendido + Argumento + $"{Cl}";
        }

        public LogNaturales(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            Contenido = Expresion;
            ObtenerArgumento();
            Operar();
        }

        protected override void ObtenerArgumento()
        {
            int Inicial = Contenido.IndexOf(SimboloExtendido) + 3;
            int Final = Contenido.LastIndexOf(Cl) - Inicial;
            Argumento = Contenido.Substring(Inicial, Final);
        }

        protected override void Operar()
        {
            bool A, B, C;
            A = double.TryParse(Argumento, out number);
            B = Argumento.Equals(ArgDefecto);
            C = Argumento.Equals($"{ModuloCancelativo}");

            if (C)
                Result = "Math ERROR";
            else if (A)
            {
                double Arg = double.Parse(Argumento);

                if (Arg < 1)
                    Result = "Math ERROR";
                else
                    Result = $"{Math.Log(Arg)}";
            }
                
            else if (B)
                Result = $"{ModuloCancelativo}";
            else
                Result = Contenido;
        }

        public override string ToString()
        {
            return $"{Nombre} {Contenido}";
        }
    }
}
