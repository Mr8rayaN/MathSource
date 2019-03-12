using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public class Senos : AFuns
    {
        public override string Nombre => "SENO";
        public override string Simbolo => "sen";
        public override string SimboloExtendido => "sen<";
        public override char Op => '<';
        public override char Cl => '>';
        private string ArgDefecto => "0";
        public int Modulo => 0;
        double number;

        public Senos()
        {
            Coeficiente = "1";
            Argumento = ArgDefecto;
            Foco = SimboloExtendido + ArgDefecto + Cl;
            Coeficiente = "1";
            Contenido = Foco;
        }

        public Senos(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            Contenido = Expresion;
            ObtenerArgumento();
            ObtenerCoeficiente();
            Operar();
        }

        protected override void ObtenerArgumento()
        {
            int Inicial = Contenido.IndexOf(SimboloExtendido) + 4;
            int Final = Contenido.LastIndexOf(Cl) - Inicial;
            Argumento = Contenido.Substring(Inicial, Final);
        }

        protected override void ObtenerCoeficiente()
        {
            Foco = SimboloExtendido + Argumento + Cl;
            Coeficiente = Contenido.Replace(Foco, "1");
            Coeficiente = Proceso.ParentesisClear(new ProductoEntero(Coeficiente).Result);
            if (Coeficiente.Equals(""))
                Coeficiente = "1";
        }

        protected override void Operar()
        {
            bool A, B;
            A = double.TryParse(Argumento, out number);
            B = Argumento.Equals(ArgDefecto);

            if (A)
            {
                double Arg = double.Parse(Argumento);
                Result = $"{Math.Sin(Arg)}";
            }

            else if (B)
                Result = $"{Modulo}";
            else
                Result = new ProductoEntero(Coeficiente, Foco).Result;
        }

        public override string ToString()
        {
            return $"{Nombre} {Contenido}";
        }
    }

    public class Cosenos : AFuns
    {
        public override string Nombre => "COSENO";
        public override string Simbolo => "cos";
        public override string SimboloExtendido => "cos<";
        public override char Op => '<';
        public override char Cl => '>';
        private string ArgDefecto => "90";
        public int Modulo => 0;
        double number;

        public Cosenos()
        {
            Argumento = ArgDefecto;
            Foco = SimboloExtendido + ArgDefecto + Cl;
            Coeficiente = "1";
            Contenido = Foco;
        }

        public Cosenos(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            Contenido = Expresion;
            ObtenerArgumento();
            ObtenerCoeficiente();
            Operar();
        }

        protected override void ObtenerCoeficiente()
        {
            Foco = SimboloExtendido + Argumento + Cl;
            Coeficiente = Contenido.Replace(Foco, "1");
            Coeficiente = Proceso.ParentesisClear(new ProductoEntero(Coeficiente).Result);
            if (Coeficiente.Equals(""))
                Coeficiente = "1";
        }

        protected override void ObtenerArgumento()
        {
            int Inicial = Contenido.IndexOf(SimboloExtendido) + 4;
            int Final = Contenido.LastIndexOf(Cl) - Inicial;
            Argumento = Contenido.Substring(Inicial, Final);
        }

        protected override void Operar()
        {
            bool A, B;
            A = double.TryParse(Argumento, out number);
            B = Argumento.Equals(ArgDefecto);

            if (A)
            {
                double Arg = double.Parse(Argumento);
                Result = $"{Math.Cos(Arg)}";
            }

            else if (B)
                Result = $"{Modulo}";
            else
                Result = new ProductoEntero(Coeficiente, Foco).Result;
        }

        public override string ToString()
        {
            return $"{Nombre} {Contenido}";
        }
    }

    public class Tangentes : AFuns
    {
        public override string Nombre => "TANGENTE";
        public override string Simbolo => "tan";
        public override string SimboloExtendido => "tan<";
        public override char Op => '<';
        public override char Cl => '>';
        private string ArgDefecto => "0";
        public int Modulo => 0;
        double number;

        public Tangentes()
        {
            Argumento = ArgDefecto;
            Foco = SimboloExtendido + ArgDefecto + Cl;
            Coeficiente = "1";
            Contenido = Foco;
        }

        public Tangentes(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            Contenido = Expresion;
            ObtenerArgumento();
            ObtenerCoeficiente();
            Operar();
        }

        protected override void ObtenerCoeficiente()
        {
            Foco = SimboloExtendido + Argumento + Cl;
            Coeficiente = Contenido.Replace(Foco, "1");
            Coeficiente = Proceso.ParentesisClear(new ProductoEntero(Coeficiente).Result);
            if (Coeficiente.Equals(""))
                Coeficiente = "1";
        }

        protected override void ObtenerArgumento()
        {
            int Inicial = Contenido.IndexOf(SimboloExtendido) + 4;
            int Final = Contenido.LastIndexOf(Cl) - Inicial;
            Argumento = Contenido.Substring(Inicial, Final);
        }

        protected override void Operar()
        {
            bool A, B;
            A = double.TryParse(Argumento, out number);
            B = Argumento.Equals(ArgDefecto);

            if (A)
            {
                double Arg = double.Parse(Argumento);
                Result = $"{Math.Tan(Arg)}";
            }

            else if (B)
                Result = $"{Modulo}";
            else
                Result = new ProductoEntero(Coeficiente, Foco).Result;
        }

        public override string ToString()
        {
            return $"{Nombre} {Contenido}";
        }
    }
}
