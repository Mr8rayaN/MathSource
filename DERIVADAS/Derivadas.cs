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
        public string DerivadaInterna { get; private set; }
        public double Modulo => 0;

        DProcesos DProceso = new DProcesos();
        EProcesos EProceso = new EProcesos();
        Polinomios Polinomio;
        AFuns Interino;
        AMathOps Operacion;

        public Derivadas() { }

        //HACER QUE ESTA DERIVADA AUTO DETECTE DERIVADAS INTERNAS DIFERENETS DE POLINOMICAS Y LAS EJECUTE
        public Derivadas(Polinomios POL, Variables Var)
        {
            Result = "0";

            foreach (var MONO in POL.Elementos)
            {
                DerivadaInterna = Enruta(MONO, Var);
                
                //PULIR BIEN CLASE SUMAS PARA QUE DEVUELVA LO REQUERIDO POR ESTA CLASE
                if(!DerivadaInterna.Equals("0"))
                    Result =  new SumaEntera(Result, DerivadaInterna).Result;
            }

            Result = Result.Trim(POL.Simbolo);
            Result = OperarSignos(Result);
        }

        public Derivadas(Monomios MONO, Variables Var)
        {
            if (!MONO.Result.Contains(Var.Nombre))
                Result = "0";
            else
            {
                List<string> DerivadasIndividuales = new List<string>();

                foreach (var item in MONO.Elementos)
                {
                    if (!item.Result.Contains(Var.Nombre))
                        DerivadasIndividuales.Add(item.Result);
                    else
                    {
                        //PULIR BIEN SUMAS PARA QUE RETORNE LO NECESARIO POR ESTA CLASE
                        string NewExponente = new SumaEntera(item.Exponente, "-1").Result;
                        string NewCoeficiente = item.Exponente;
                        string NewPotencia = new PotenciaEntera(item.Base, NewExponente).Result;
                        
                        DerivadaInterna =  new ProductoEntero(NewCoeficiente, NewPotencia).Result;
                        DerivadasIndividuales.Add(DerivadaInterna);
                    }
                }

                Result = "1";
                foreach (var item in DerivadasIndividuales)
                {
                    Result = new ProductoEntero(Result, item).Result;
                }

                //Result = OperarSignos(Result);
            }
            
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
                string Temporal = EProceso.CorchetesClear(Operacion.Result);
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

                if (!EProceso.IsAgrupate(Result))
                    Result = EProceso.EncorcharFuncion(Result);
            }
            else
                Result = $"{Modulo}";
        }

        //IMPLEMENTAR PROCESOD DE ENFOCAR FUNCION DONDE LA VARIABLE ESTÉ ENFOCADA
        private string Enruta(Monomios MONO, Variables Var)
        {
            //TENGO QUE SABER CUAL FUNCION ES LA MAS EXTERIOR Y PREGUNTAR POR ESA
            //SI ANIDO CS<SEN<X>> POR ORDEN LO TOMA COMO SI LA FUNCION FUERA UN SENO CUANDO EN REALIZAD ES UN COSENO

            Interino = new Senos();

            if (Interino.ContainsThisFuntion(MONO) & DProceso.IsFirstFuncion(MONO, Interino))
            {
                return new Derivadas(new Senos(MONO.Result), Var).Result;
            }


            Interino = new Cosenos();
            if (Interino.ContainsThisFuntion(MONO) & DProceso.IsFirstFuncion(MONO, Interino))
            {
                return new Derivadas(new Cosenos(MONO.Result), Var).Result;
            }


            Interino = new Tangentes();
            if (Interino.ContainsThisFuntion(MONO) & DProceso.IsFirstFuncion(MONO, Interino))
            {
                return new Derivadas(new Tangentes(MONO.Result), Var).Result;
            }


            Interino = new Eulers();
            if (Interino.ContainsThisFuntion(MONO) & DProceso.IsFirstFuncion(MONO, Interino))
            {
                return new Derivadas(new Eulers(MONO.Result), Var).Result;
            }


            Interino = new LogNaturales();
            if (Interino.ContainsThisFuntion(MONO) & DProceso.IsFirstFuncion(MONO, Interino))
            {
                return new Derivadas(new LogNaturales(MONO.Result), Var).Result;
            }


             return new Derivadas(MONO, Var).Result;
        }

        public override string ToString()
        {
            return $" {Nombre} {Result} ";
        }

    }
}
