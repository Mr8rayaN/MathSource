using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using ALGEBRA;

namespace DERIVADAS
{
    public class Derivadas : Signos
    {
        public string Nombre => "DERIVADA";
        public Variables Variable { get; private set; }
        public string Funcion { get; private set; }
        public string Result { get; private set; }
        public object DerivadaInterna { get; private set; }
        public double Modulo => 0;

        EProcesos Proceso = new EProcesos();
        Polinomios Polinomio;
        AFuns Interino;
        AMathOps Operacion;

        public Derivadas() { }

        //HACER QUE ESTA DERIVADA AUTO DETECTE DERIVADAS INTERNAS DIFERENETS DE POLINOMICAS Y LAS EJECUTE
        public Derivadas(Polinomios POL, Variables Var)
        {
            string Derivada = ""; char SumSymbol = new SumaEntera().Simbolo;
            foreach (var monomio in POL.Elementos)
            {
                Derivada += Enrutar(monomio, Var) + SumSymbol;
            }

            Derivada = Derivada.Trim(SumSymbol);
            Result = Derivada;
        }

        public Derivadas(Senos SENO, Variables Var)
        {
            if (SENO.Argumento.Contains(Var.Nombre))
            {
                Interino = new Cosenos();
                Interino.SetArgumento(SENO.Argumento);
                Polinomio = new Polinomios(SENO.Argumento);
                DerivadaInterna = new Derivadas(Polinomio, Var).Result;
                Operacion = new ProductoEntero(DerivadaInterna.ToString(), Interino.Result);
                Result = Operacion.Result;
            }
            else
            {
                Result = $"{Modulo}";
            }
        }

        public Derivadas(Cosenos COS, Variables Var)
        {
            if (COS.Argumento.Contains(Var.Nombre))
            {
                Interino = new Senos();
                Interino.SetArgumento(COS.Argumento);
                Polinomio = new Polinomios(COS.Argumento);
                DerivadaInterna = new Derivadas(Polinomio, Var).Result;
                Operacion = new ProductoEntero(DerivadaInterna.ToString(), Interino.Result);
                Result = $"{Neg}" + Operacion.Result;
            }
            else
                Result = $"{Modulo}";
        }

        public Derivadas(Tangentes TAN, Variables Var)
        {
            string Res;
            if (TAN.Argumento.Contains(Var.Nombre))
            {
                Polinomio = new Polinomios(TAN.Argumento);
                DerivadaInterna = new Derivadas(Polinomio, Var).Result;
                Operacion = new PotenciaEntera(TAN.Simbolo, "2");
                //REVISAR SI TOCA DESCORCHAR CORCHETES DE LA BASE DE LA POTENCIA
                string Temporal = Proceso.CorchetesClear(Operacion.Result);
                Res = Temporal + TAN.Op + TAN.Argumento + TAN.Cl;
                Operacion = new CocienteEntero("1", Res);
                Res = Operacion.Result;
                //Operacion = new ProductoEntero(DerivadaInterna.ToString(), Res); PAUSADO MOMENTANEAMENTE DEBE ACTUALIZAR PRODUCTO PARA IDENTIFICAR <> COMO LLAVES
                //Result = Operacion.Result;
                Result = $"{DerivadaInterna.ToString()}{new ProductoEntero().Simbolo}{Res}";
            }
            else
                Result = $"{Modulo}";
        }

        public Derivadas(Eulers EUL, Variables Var)
        {
            if (EUL.Argumento.Contains(Var.Nombre))
            {
                Polinomio = new Polinomios(EUL.Argumento);
                DerivadaInterna = new Derivadas(Polinomio, Var).Result;
                Operacion = new ProductoEntero(DerivadaInterna.ToString(), EUL.Result);
                Result = Operacion.Result;
            }
            else
                Result = $"{Modulo}";
        }

        public Derivadas(LogNaturales LN, Variables Var)
        {
            if (LN.Argumento.Contains(Var.Nombre))
            {
                Polinomio = new Polinomios(LN.Argumento);
                DerivadaInterna = new Derivadas(Polinomio, Var).Result;
                Operacion = new CocienteEntero(DerivadaInterna.ToString(), LN.Argumento);
                Result = Operacion.Result;
            }
            else
                Result = $"{Modulo}";
        }

        //IMPLEMENTAR PROCESOD DE ENFOCAR FUNCION DONDE LA VARIABLE ESTÉ ENFOCADA
        private string Enrutar(Monomios MONO, Variables Var)
        {
            string Coeficiente = "", Literal = "";
            if (MONO.Result.Contains(Var.Nombre))
            {
                foreach (var elemento in MONO.Elementos)
                {
                    if (elemento.Base.Equals(Var.Nombre))
                    {
                        Operacion = new ProductoEntero(MONO.Coeficiente, elemento.Exponente);
                        Coeficiente = Operacion.Result;
                        Operacion = new SumaEntera(elemento.Exponente, "-1");
                        Literal += MONO.ParteLiteral.Replace(elemento.Result, new PotenciaEntera(elemento.Base, Operacion.Result).Result);
                    }
                }
                Operacion = new ProductoEntero(Coeficiente, Literal);
                return $"{Operacion.Result}";
            }
            else
                return $"{Modulo}";
        }

    }
}
