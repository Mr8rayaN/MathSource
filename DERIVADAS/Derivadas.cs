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
            Result = "";

            foreach (var MONO in POL.Elementos)
            {
                Result += Enruta(MONO, Var) + POL.Simbolo;
            }

            Result = Result.Trim(POL.Simbolo);
       }

        public Derivadas(Monomios MONO, Variables Var)
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
                Result = $"{Operacion.Result}";
            }
            else
                Result = $"{Modulo}";
        }

        public Derivadas(Senos SENO, Variables Var)
        {
            if (SENO.Argumento.Contains(Var.Nombre))
            {
                Interino = new Cosenos();
                Interino.SetArgumento(SENO.Argumento);
                Polinomio = new Polinomios(SENO.Argumento);
                DerivadaInterna = new Derivadas(Polinomio, Var).Result;

                Operacion = new ProductoEntero(SENO.Coeficiente, DerivadaInterna.ToString());
                Operacion = new ProductoEntero(Operacion.Result, Interino.Result);

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

                Operacion = new ProductoEntero(COS.Coeficiente, DerivadaInterna.ToString());
                Operacion = new ProductoEntero(Operacion.Result, Interino.Result);

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

                Operacion = new ProductoEntero(TAN.Coeficiente, DerivadaInterna.ToString());
                Operacion = new ProductoEntero(Operacion.Result, Res);
                Result = Operacion.Result;
                //Result = $"{DerivadaInterna.ToString()}{new ProductoEntero().Simbolo}{Res}"; PAUSADO PARA EXPERIMENTAR SI SE CORRIGIO EL BUG
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

                Operacion = new ProductoEntero(EUL.Coeficiente, DerivadaInterna.ToString());
                Operacion = new ProductoEntero(Operacion.Result, EUL.Result);
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

                Operacion = new ProductoEntero(LN.Coeficiente, DerivadaInterna.ToString());
                Operacion = new CocienteEntero(Operacion.Result, LN.Argumento);
                Result = Operacion.Result;
            }
            else
                Result = $"{Modulo}";
        }

        //IMPLEMENTAR PROCESOD DE ENFOCAR FUNCION DONDE LA VARIABLE ESTÉ ENFOCADA
        private string Enruta(Monomios MONO, Variables Var)
        {
            Interino = new Senos();
            if (Interino.ContainsThisFuntion(MONO))
            {
                return new Derivadas(new Senos(MONO.Result), Var).Result;
            }


            Interino = new Cosenos();
            if (Interino.ContainsThisFuntion(MONO))
            {
                return new Derivadas(new Cosenos(MONO.Result), Var).Result;
            }


            Interino = new Tangentes();
            if (Interino.ContainsThisFuntion(MONO))
            {
                return new Derivadas(new Tangentes(MONO.Result), Var).Result;
            }


            Interino = new Eulers();
            if (Interino.ContainsThisFuntion(MONO))
            {
                return new Derivadas(new Eulers(MONO.Result), Var).Result;
            }


            Interino = new LogNaturales();
            if (Interino.ContainsThisFuntion(MONO))
            {
                return new Derivadas(new LogNaturales(MONO.Result), Var).Result;
            }


            return new Derivadas(MONO, Var).Result;
        }

    }
}
