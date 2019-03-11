using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using GRAMATICA;

namespace ALGEBRA
{
    public class Monomios
    {
        public string Nombre => "MONOMIO";
        public string Contenido { get; private set; }
        public string Coeficiente { get; private set; }
        public string ParteLiteral { get; private set; }
        public double GradoAbs { get; private set; }
        public string Result { get; private set; }
        public List<PotenciaEntera> Elementos = new List<PotenciaEntera>();
        ProductoEntero Producto = new ProductoEntero();
        PotenciaEntera Potencia = new PotenciaEntera();
        double number;

        EProcesos Proceso = new EProcesos();

        public Monomios() { }

        public Monomios(string Coeficiente, string Literal)
        {

        }

        public Monomios(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            ObtenerElementos(Expresion);

            Operar();

        }

        private void ObtenerElementos (string Expresion)
        {
            ParteLiteral = "";
            GradoAbs = Producto.ModuloCancelativo;
            Coeficiente = $"{Producto.Modulo}";
            Producto = new ProductoEntero(Expresion);

            Contenido = Producto.Result;

            foreach (var elemento in Contenido.Split(Producto.Simbolo))
            {
                Potencia = new PotenciaEntera(elemento);

                Elementos.Add(Potencia);

                Organizar(Potencia);

                if (Potencia.Result.Equals(Potencia.ModuloCancelativo))
                {
                    Elementos.Clear();
                    Coeficiente = $"{Potencia.ModuloCancelativo}";
                    ParteLiteral = "";
                    break;
                }
                
            }

        }

        private void Organizar(PotenciaEntera P)
        {
            bool A = double.TryParse(P.Result, out number);

            if (A)
            {
                GradoAbs += double.Parse(P.Exponente);
                Coeficiente = new ProductoEntero(Coeficiente, P.Result).Result;
            }
            else
            {
                GradoAbs += double.Parse(P.Exponente);
                ParteLiteral += Producto.Simbolo + P.Result;
                ParteLiteral = ParteLiteral.Trim(Producto.Simbolo);
            }
        }

        private void Operar()
        {
            bool A, B, C;

            A = Coeficiente.Equals(Potencia.ModuloCancelativo);
            B = ParteLiteral.Equals("");
            C = Coeficiente.Equals(Potencia.Modulo);

            if (A)
                Result = $"{Potencia.ModuloCancelativo}";

            else if (B)
                Result = Coeficiente;

            else if (C)
                Result = ParteLiteral;

            else
            {
                Result = $"{Coeficiente}{Producto.Simbolo}{ParteLiteral}";
            }
        }

        public override string ToString()
        {
            return $"MONOMIO {Contenido}; COEFICIENTE {Coeficiente}; LITERAL {ParteLiteral}";
        }

    }

}
