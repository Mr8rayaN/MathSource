using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using ALGEBRA;

namespace DERIVADAS
{
    public class Derivada
    {

        public ProcesosOld proceso = new ProcesosOld();

        public string Derivar(string funcion, string variable)
        {
            double number = 0;
            string exponente = "";

            if (funcion.Contains("^"))
            {
                if (!funcion.Contains("^("))
                {
                    funcion = funcion.Substring(0, funcion.IndexOf("^")) + "^(" + funcion.Substring(funcion.IndexOf("^") + 1) + ")";
                }
            }

            funcion = proceso.IdentificarCoeficiente(funcion, variable);
            string coeficiente = proceso.Coeficiente(funcion, variable);
            funcion = proceso.RemoverCoeficiente(funcion, variable);

            Console.WriteLine(variable);
            Console.WriteLine(coeficiente);
            Console.WriteLine(funcion);
            Console.WriteLine("---------------");

            if (funcion.Contains("^"))
            {

                exponente = funcion.Substring(funcion.IndexOf("^") + 1);
                if (exponente.StartsWith("("))
                {
                    exponente = exponente.Substring(0, exponente.IndexOf(')'));
                }

            }

            if (funcion.Contains($"{variable}^0")) return "0";
            else if (double.TryParse(funcion, out number)) return "0";
            else if (funcion.Equals(variable) && !proceso.IsFuncion(funcion, variable))
            {
                if (!coeficiente.Equals("1")) return coeficiente;
                return "1";
            }
            else if (funcion.StartsWith("ln("))
            {
                string ln = NLogaritmo(funcion, variable);

                if (!coeficiente.Equals("1")) return $"{coeficiente}{ln}";
                return $"{ln}";
            }
            else if (funcion.StartsWith("sen("))
            {
                string sen = Seno(funcion, variable);

                if (!coeficiente.Equals("1")) return $"{coeficiente}({sen})";
                return sen;
            }
            else if (funcion.StartsWith("cos("))
            {
                string cos = Coseno(funcion, variable);

                if (!coeficiente.Equals("1")) return $"{coeficiente}({cos})";
                return cos;
            }
            else if (funcion.StartsWith("tan("))
            {
                string tan = Tangente(funcion, variable);

                if (!coeficiente.Equals("1")) return $"{coeficiente}({tan})";
                return tan;
            }
            else if (funcion.Contains($"{variable}^") || funcion.Contains("e^") || exponente.Contains(variable))
            {
                string pow = Potencia(funcion, variable);

                if (!coeficiente.Equals("1")) return $"{coeficiente}({pow})";
                return $"{pow}";
            }
            else return "No se halló solución";
        }

        protected string Potencia(string funcion, string variable)
        {

            if (funcion.StartsWith("e")) return Exponencial(funcion, variable);
            else if (funcion.Substring(funcion.IndexOf("^")).Contains(variable))
            {
                return FuncionPotencia(funcion, variable);
            }

            else
            {
                string stringPostfijo;
                string stringPrefijo;
                double doublePostfijo;
                double doublePrefijo;

                if (funcion.StartsWith(variable)) funcion = "1" + funcion;
                if (funcion.EndsWith(variable)) funcion = funcion + "^1";
                if (funcion.Contains(variable + "^0")) return "0";

                funcion = funcion.Remove(funcion.IndexOf(variable)) + funcion.Substring(funcion.IndexOf(variable) + 1);

                int divisor = funcion.IndexOf("^");

                stringPostfijo = funcion.Substring(divisor + 1);
                stringPrefijo = funcion.Substring(0, divisor);

                if (double.TryParse(stringPostfijo, out double number) && double.TryParse(stringPrefijo, out number))
                {
                    doublePrefijo = double.Parse(stringPrefijo);
                    doublePostfijo = double.Parse(stringPostfijo);

                    doublePrefijo = doublePrefijo * doublePostfijo;
                    doublePostfijo = doublePostfijo - 1;

                    if (doublePostfijo == 1) return $"{doublePrefijo}{variable}";
                    if (doublePostfijo == 0) return $"{doublePrefijo}";
                    if (doublePrefijo == 1) return $"{variable}^{doublePostfijo}";
                    return $"{doublePrefijo}{variable}^{doublePostfijo}";
                }
                else
                {
                    if (stringPrefijo.Equals("1")) return $"{stringPostfijo}({variable}^({stringPostfijo + "-1"}))";
                    return $"{stringPrefijo}({stringPostfijo})({variable}^({stringPostfijo + "-1"}))";
                }
            }
        }

        protected string NLogaritmo(string funcion, string variable)
        {
            string stringPostfijo;
            string stringPrefijo;

            if (funcion.StartsWith("ln")) funcion = "1" + funcion;

            stringPrefijo = funcion.Substring(0, funcion.IndexOf("l"));
            stringPostfijo = funcion.Substring(funcion.IndexOf("(") + 1, funcion.LastIndexOf(")") - funcion.IndexOf("(") - 1);

            if (stringPostfijo.Contains(variable + "^0")) return "0";
            if (double.TryParse(stringPostfijo, out double number)) return "0";

            string derivada = Derivar(stringPostfijo, variable);

            if (stringPrefijo.Equals("1")) return $"({derivada}/{stringPostfijo})";
            return $"{stringPrefijo}({derivada}/{stringPostfijo})";
        }

        protected string Seno(string funcion, string variable)
        {
            string stringPostfijo;
            string stringPrefijo;
            string derivada;

            if (funcion.StartsWith("s")) funcion = "1" + funcion;
            stringPrefijo = funcion.Substring(0, funcion.IndexOf("s"));
            stringPostfijo = funcion.Substring(funcion.IndexOf('(') + 1, funcion.LastIndexOf(')') - funcion.IndexOf('(') - 1);

            if (stringPostfijo.Contains(variable + "^0")) return "0";

            derivada = Derivar(stringPostfijo, variable);

            if (stringPrefijo.Equals("1") && derivada.Equals("1")) return $"cos({stringPostfijo})";
            if (stringPrefijo.Equals("1")) return $"{derivada}(cos({stringPostfijo}))";
            if (derivada.Equals("1")) return $"{stringPrefijo}(cos({stringPostfijo}))";
            return $"{stringPrefijo}({derivada})(cos({stringPostfijo}))";
        }

        protected string Coseno(string funcion, string variable)
        {
            string stringPrefijo;
            string stringPostfijo;
            string derivada;

            if (funcion.StartsWith("c")) funcion = "1" + funcion;

            stringPrefijo = funcion.Substring(0, funcion.IndexOf('c'));
            stringPostfijo = funcion.Substring(funcion.IndexOf('(') + 1, funcion.LastIndexOf(')') - funcion.IndexOf('(') - 1);

            if (stringPostfijo.Contains(variable + "^0")) return "0";

            derivada = Derivar(stringPostfijo, variable);

            if (stringPrefijo.Equals("1") && derivada.Equals("1")) return $"-sen({stringPostfijo})";
            if (stringPrefijo.Equals("1")) return $"{derivada}(-sen({stringPostfijo}))";
            if (derivada.Equals("1")) return $"{stringPrefijo}(-sen({stringPostfijo}))";
            return $"{stringPrefijo}({derivada})(-sen({stringPostfijo}))";
        }

        protected string Tangente(string funcion, string variable)
        {
            string stringPostfijo;
            string stringPrefijo;

            if (funcion.StartsWith("-t")) funcion = funcion.Substring(funcion.IndexOf('t'));
            if (funcion.StartsWith("t")) funcion = 1 + funcion;

            stringPrefijo = funcion.Substring(0, funcion.IndexOf('t'));
            stringPostfijo = funcion.Substring(funcion.IndexOf('(') + 1, funcion.LastIndexOf(')') - funcion.IndexOf('(') - 1);

            if (double.TryParse(stringPostfijo, out double number)) return "0";

            string derivada = Derivar(stringPostfijo, variable);

            if (stringPrefijo.Equals("1") && derivada.Equals("1")) return $"sec^2({stringPostfijo})";
            if (stringPrefijo.Equals("1")) return $"{derivada}(sec^2({stringPostfijo}))";
            if (derivada.Equals("1")) return $"{stringPrefijo}(sec^2({stringPostfijo}))";

            return $"{stringPrefijo}({derivada})(sec^2({stringPostfijo}))";
        }

        protected string Exponencial(string funcion, string variable)
        {
            string stringPrefijo;
            string stringPostfijo;

            if (funcion.StartsWith("e")) funcion = 1 + funcion;
            if (funcion.StartsWith("-e")) funcion = "-1" + funcion.Substring(1);

            funcion = funcion.Remove(funcion.IndexOf("e")) + funcion.Substring(funcion.IndexOf("e") + 1);

            int divisor = funcion.IndexOf("^");

            stringPostfijo = funcion.Substring(divisor + 1);
            stringPrefijo = funcion.Substring(0, divisor);

            string derivada = Derivar(stringPostfijo, variable);

            if (stringPrefijo.Equals("1") && derivada.Equals("1")) return $"e^({stringPostfijo})";
            if (stringPrefijo.Equals("1")) return $"{derivada}(e^({stringPostfijo}))";
            if (derivada.Equals("1")) return $"{stringPrefijo}(e^({stringPostfijo}))";
            return $"{stringPrefijo}({derivada})(e^({stringPostfijo}))";
        }

        protected string FuncionPotencia(string funcion, string variable)
        {
            string stringPrefijo;
            string stringPostfijo;

            stringPrefijo = funcion.Substring(0, funcion.IndexOf("^"));
            stringPostfijo = funcion.Substring(funcion.IndexOf("^") + 1);

            string derivada = Derivar(stringPostfijo, variable);

            if (derivada.Equals("1")) return $"({stringPrefijo}^{stringPostfijo})(ln({stringPrefijo}))";
            return $"({stringPrefijo}^{stringPostfijo})({derivada})(ln({stringPrefijo}))";
        }

    }

    public class CopDerivada : Signos
    {
        public Variables Variable { get; private set; }
        public string Funcion { get; private set; }
        public string Result { get; private set; }
        public object DerivadaInterna { get; private set; }
        public double Modulo => 0;

        
        Polinomios Polinomio;
        AFuns Interino;
        AMathOps Operacion;

        public CopDerivada() { }

        public CopDerivada(Polinomios POL, Variables Var)
        {
            Result = $"g'({Var.Nombre})";
        }

        public CopDerivada(Senos SENO, Variables Var)
        {
            if (SENO.Argumento.Contains(Var.Nombre))
            {
                Interino = new Cosenos();
                Interino.SetArgumento(SENO.Argumento);
                Polinomio = new Polinomios(SENO.Argumento);
                DerivadaInterna = new CopDerivada(Polinomio, Var).Result;
                Result = DerivadaInterna.ToString() + Interino.Result;
            }
            else
            {
                Result = $"{Modulo}";
            }
        }

        public CopDerivada(Cosenos COS, Variables Var)
        {
            if (COS.Argumento.Contains(Var.Nombre))
            {
                Interino = new Senos();
                Interino.SetArgumento(COS.Argumento);
                Polinomio = new Polinomios(COS.Argumento);
                DerivadaInterna = new CopDerivada(Polinomio, Var).Result;
                Result = $"{Neg}" + DerivadaInterna.ToString() + Interino.Result;
            }
            else
                Result = $"{Modulo}";
        }

        public CopDerivada(Tangentes TAN, Variables Var)
        {
            string Res;
            if (TAN.Argumento.Contains(Var.Nombre))
            {
                Polinomio = new Polinomios(TAN.Argumento);
                DerivadaInterna = new CopDerivada(Polinomio, Var).Result;
                Operacion = new PotenciaEntera(TAN.Simbolo, "2");
                //REVISAR SI TOCA DESCORCHAR CORCHETES DE LA BASE DE LA POTENCIA
                Res = Operacion.Result + TAN.Op + TAN.Argumento + TAN.Cl;
                Operacion = new CocienteEntero("1", Res);
                Res = Operacion.Result;
                Operacion = new ProductoEntero(DerivadaInterna.ToString(), Res);
                Result = Operacion.Result;
            }
            else
                Result = $"{Modulo}";
        }

        public CopDerivada(Eulers EUL, Variables Var)
        {
            if (EUL.Argumento.Contains(Var.Nombre))
            {
                Polinomio = new Polinomios(EUL.Argumento);
                DerivadaInterna = new CopDerivada(Polinomio, Var).Result;
                Result = DerivadaInterna.ToString() + EUL.Result;
            }
            else
                Result = $"{Modulo}";
        }

        public CopDerivada(LogNaturales LN, Variables Var)
        {
            if (LN.Argumento.Contains(Var.Nombre))
            {
                Polinomio = new Polinomios(LN.Argumento);
                DerivadaInterna = new CopDerivada(Polinomio, Var).Result;
                Operacion = new CocienteEntero(DerivadaInterna.ToString(), LN.Argumento);
                Result = Operacion.Result;
            }
            else
                Result = $"{Modulo}";
        }

    }
}
