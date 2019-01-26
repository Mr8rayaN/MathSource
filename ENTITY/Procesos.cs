using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Procesos
    {

        public bool IsFuncion(string funcion, string variable)
        {
            if (funcion.Contains("ln(") && IsFirst(funcion, variable, funcion.IndexOf("ln(")) )
            {
                funcion = funcion.Substring(funcion.IndexOf("(") + 1, funcion.LastIndexOf(")") - funcion.IndexOf("(") - 1);
                if (funcion.Contains(variable)) return true;
                else return false;
            }
            if (funcion.Contains("sen(") && IsFirst(funcion, variable, funcion.IndexOf("sen(")) )
            {
                funcion = funcion.Substring(funcion.IndexOf("(") + 1, funcion.LastIndexOf(")") - funcion.IndexOf("(") - 1);
                if (funcion.Contains(variable)) return true;
                else return false;
            }
            if (funcion.Contains("cos(") && IsFirst(funcion, variable, funcion.IndexOf("cos(")))
            {
                funcion = funcion.Substring(funcion.IndexOf("(") + 1, funcion.LastIndexOf(")") - funcion.IndexOf("(") - 1);
                if (funcion.Contains(variable)) return true;
                else return false;
            }
            if (funcion.Contains("tan(") && IsFirst(funcion, variable, funcion.IndexOf("tan(")))
            {
                funcion = funcion.Substring(funcion.IndexOf("(") + 1, funcion.LastIndexOf(")") - funcion.IndexOf("(") - 1);
                if (funcion.Contains(variable)) return true;
                else return false;
            }
            if (funcion.Contains("e") && IsFirst(funcion, variable, funcion.IndexOf("e")))
            {
                if (funcion.Substring(funcion.IndexOf("e^")).Contains("(") && funcion.Substring(funcion.IndexOf("e^")).Contains(")"))
                {
                    string exponente = funcion.Substring(funcion.IndexOf("(") + 1, funcion.LastIndexOf(")") - funcion.IndexOf("(") - 1);
                    if (exponente.Contains(variable)) return true;
                    else return false;
                }

                funcion = funcion.Substring(funcion.IndexOf("e^") + 2);
                if (funcion.Contains(variable)) return true;
                else return false;
            }
            if (funcion.Contains("^"))
            {
                string exponente = funcion.Substring(funcion.IndexOf("^"));
                string baseFuncion = funcion.Substring(0, funcion.IndexOf("^"));

                if (!exponente.Contains("^("))
                {
                    if (exponente.Contains(variable))
                        return true;
                }
                if (exponente.StartsWith("^("))
                {
                    exponente = exponente.Substring(exponente.IndexOf("(") + 1, exponente.IndexOf(")") - exponente.IndexOf("(") - 1);
                    if (exponente.Contains(variable))
                        return true;
                }
                if (baseFuncion.Contains("(") && baseFuncion.Contains(")"))
                {
                    baseFuncion = baseFuncion.Substring(baseFuncion.IndexOf("(") + 1, baseFuncion.LastIndexOf(")") - baseFuncion.IndexOf("(") - 1);
                    if (baseFuncion.Contains(variable))
                        return true;
                }
                if (baseFuncion.Contains(variable))
                {
                    baseFuncion = baseFuncion.Substring(baseFuncion.Length - 1, 1);
                    if (baseFuncion.Equals(variable))
                        return true;
                }

                return false;
            }

            return false;
        }

        public int CierreFuncion (string funcion , int startIndex)
        {

            if (startIndex < 0)
            {
                return funcion.Length;
            }
            
            bool seguir = true;
            int final, abierto, cerrado, i;

            final = abierto = cerrado = i = 0;

            funcion = funcion.Substring(startIndex);
            char[] caracter = funcion.ToCharArray();

            while(seguir)
            {
                if (caracter[i] == '(')
                    abierto = abierto + 1;

                if (caracter[i] == ')')
                    -- abierto;

                if (abierto == 0)
                    seguir = false;

                ++i;
            }

            return i;

        }

        public int InicioFuncion (string funcion, int EndIndex)
        {
            bool seguir = true;
            int final, abierto, cerrado, i;

            final = abierto = cerrado = i = 0;

            funcion = funcion.Substring(0, EndIndex + 1);
            char[] caracter = funcion.ToCharArray();
            i = caracter.Length - 1;

            while (seguir)
            {
                if (caracter[i] == ')')
                    cerrado = cerrado + 1;

                if (caracter[i] == '(')
                    --cerrado;

                if (cerrado == 0)
                    seguir = false;
                else
                    --i;
            }

            return i;
        }

        public bool IsFirst(string funcion, string variable, int posicion)
        {
            int menor = 10000;
            int[] funciones = new int[5];
            string enfoque = "";

            if (funcion.Contains("sen("))
            {
                enfoque = funcion.Substring(funcion.IndexOf("sen(") + 3, CierreFuncion(funcion, funcion.IndexOf("sen(") + 3));
                if (enfoque.Contains(variable))
                    funciones[0] = funcion.IndexOf("sen(");
                else
                    funciones[0] = -1;
            }
            else
                funciones[0] = -1;

            if (funcion.Contains("sen("))
            {
                enfoque = funcion.Substring(funcion.IndexOf("cos(") + 3, CierreFuncion(funcion, funcion.IndexOf("cos(") + 3));
                if (enfoque.Contains(variable))
                    funciones[1] = funcion.IndexOf("cos(");
                else
                    funciones[1] = -1;
            }
            else
                funciones[1] = -1;


            if (funcion.Contains("tan("))
            {
                enfoque = funcion.Substring(funcion.IndexOf("tan(") + 3, CierreFuncion(funcion, funcion.IndexOf("tan(") + 3));
                if (enfoque.Contains(variable))
                    funciones[2] = funcion.IndexOf("tan(");
                else
                    funciones[2] = -1;
            }
            else
                funciones[2] = -1;


            if (funcion.Contains("ln("))
            {
                enfoque = funcion.Substring(funcion.IndexOf("ln(") + 2, CierreFuncion(funcion, funcion.IndexOf("ln(") + 2));
                if (enfoque.Contains(variable))
                    funciones[3] = funcion.IndexOf("ln(");
                else
                    funciones[3] = -1;
            }
            else
                funciones[3] = -1;


            if (funcion.Contains("^"))
            {
                string baseFuncion = funcion.Substring(0, funcion.IndexOf("^"));
                if (baseFuncion.EndsWith(")") && baseFuncion.Contains("("))
                {
                    baseFuncion = baseFuncion.Substring(baseFuncion.IndexOf("("), CierreFuncion(baseFuncion, baseFuncion.IndexOf("(")));
                }
                
                string exponente = funcion.Substring(funcion.IndexOf("^") + 1);
                if (exponente.StartsWith("(") && exponente.Contains(")"))
                {
                    exponente = exponente.Substring(exponente.IndexOf("("), CierreFuncion(exponente, exponente.IndexOf("(")));
                }


                if (baseFuncion.Contains(variable) || exponente.Contains(variable))
                    funciones[4] = funcion.IndexOf(baseFuncion);
                else
                    funciones[4] = -1;
            }
            else
                funciones[4] = -1;



            foreach (var numero in funciones)
            {
                if (numero < menor && numero>=0)
                    menor = numero;
            }

            if (posicion <= menor)
                return true;

            return false;

        }

        public string QueFuncion(string funcion, string variable)
        {
            string enfoque = "";

            if (funcion.Contains("ln(") && IsFirst(funcion, variable, funcion.IndexOf("ln(")))
            {
                enfoque = funcion.Substring( funcion.IndexOf("ln(") , 2 + CierreFuncion( funcion, funcion.IndexOf("ln(") + 2 ) );
                if(enfoque.Contains(variable))
                    return enfoque;
            }
            if (funcion.Contains("sen(") && IsFirst(funcion, variable, funcion.IndexOf("sen(")))
            {
                enfoque = funcion.Substring(funcion.IndexOf("sen("), 3 + CierreFuncion(funcion, funcion.IndexOf("sen(") + 3));
                if (enfoque.Contains(variable))
                    return enfoque;
            }
            if (funcion.Contains("cos(") && IsFirst(funcion, variable, funcion.IndexOf("cos(")))
            {
                enfoque = funcion.Substring(funcion.IndexOf("cos("), 3 + CierreFuncion(funcion, funcion.IndexOf("cos(") + 3));
                if (enfoque.Contains(variable))
                    return enfoque;
            }
            if (funcion.Contains("tan(") && IsFirst(funcion, variable, funcion.IndexOf("tan(")))
            {
                enfoque = funcion.Substring(funcion.IndexOf("tan("), 3 + CierreFuncion(funcion, funcion.IndexOf("tan(") + 3));
                if (enfoque.Contains(variable))
                    return enfoque;
            }
            if (funcion.Contains("e^"))
            {
                string exponente = funcion.Substring(funcion.IndexOf("e^") + 2);
                if (exponente.Contains(variable))
                {
                    if(exponente.StartsWith("(") && exponente.Contains(")"))
                    {
                        exponente = exponente.Substring(exponente.IndexOf("("), exponente.LastIndexOf(")") - exponente.IndexOf("(") + 1);
                        if (exponente.Contains(variable))
                        {
                            return $"e^{exponente}";
                        }
                        else
                            return funcion;
                    }
                    if (exponente.Contains(variable))
                    {
                        return $"e^{exponente}";
                    }
                }
                return funcion;
            }
            if (funcion.Contains("^"))
            {
                string exponente = "";
                string stringPrefijo = "";
                string stringPostfijo = "";

                if (funcion.Contains($"{variable}^"))
                {
                    
                    stringPrefijo = funcion.Substring(0, funcion.IndexOf($"{variable}^"));
                    stringPostfijo = funcion.Substring(funcion.IndexOf($"{variable}^") + 2);
                    exponente = stringPostfijo;

                    if (stringPostfijo.StartsWith("(") && stringPostfijo.Contains(")"))
                        exponente = stringPostfijo.Substring(stringPostfijo.IndexOf("("), CierreFuncion(stringPostfijo, stringPostfijo.IndexOf("(")));

                    return $"{variable}^{exponente}";
                }
                else
                {
                    stringPrefijo = funcion.Substring(0, funcion.IndexOf("^"));
                    stringPostfijo = funcion.Substring(funcion.IndexOf("^") + 1);
                }

                string baseFuncion = stringPrefijo;
                exponente = stringPostfijo;

                
                if (stringPostfijo.StartsWith("(") && stringPostfijo.Contains(")"))
                    exponente = stringPostfijo.Substring(stringPostfijo.IndexOf("("), CierreFuncion(stringPostfijo, stringPostfijo.IndexOf("(")) );


                if (baseFuncion.Contains(variable))
                {
                    if (stringPrefijo.EndsWith(")") && stringPrefijo.Contains("("))
                    {
                        baseFuncion = stringPrefijo.Substring(stringPrefijo.IndexOf("("), stringPrefijo.LastIndexOf(")") - stringPrefijo.IndexOf("(") + 1);
                        if (baseFuncion.Contains(variable))
                            return $"{baseFuncion}^{exponente}";
                    }

                    return $"{baseFuncion.Substring(baseFuncion.Length - 1, 1)}^{exponente}";
                    
                }

                if (baseFuncion.StartsWith("(") && baseFuncion.EndsWith(")"))
                    return $"{baseFuncion}^{exponente}";

                if (exponente.Contains(variable))
                {
                    if (stringPostfijo.StartsWith("(") && stringPostfijo.Contains(")"))
                    {
                        exponente = stringPostfijo.Substring(stringPostfijo.IndexOf("("), stringPostfijo.LastIndexOf(")") - stringPostfijo.IndexOf("(") + 1);
                        if (exponente.Contains(variable))
                            return $"{baseFuncion.Substring(baseFuncion.Length - 1, 1)}^{exponente}";
                    }

                    return $"{baseFuncion.Substring(baseFuncion.Length - 1, 1)}^{exponente}";
                }
            }

            return null;
        }

        public string Limpiar (string funcion)
        {

            funcion = funcion.Replace(")", "");
            funcion = funcion.Replace("(", "");
            funcion = funcion.Replace("ln", "");
            funcion = funcion.Replace("sen", "");
            funcion = funcion.Replace("cos", "");
            funcion = funcion.Replace("tan", "");
            funcion = funcion.Replace("e", "");
            funcion = funcion.Replace("/", "");
            funcion = funcion.Replace("^", "");
            funcion = funcion.Replace("+", "");
            funcion = funcion.Replace("-", "");
            funcion = funcion.Replace("*", "");

            return funcion;
        }

        public List<string> ExtraerVariables(string funcion)
        {
            List<string> Variables = new List<string>();
            if (funcion == null || funcion.Equals("")) return null;

            funcion = Limpiar(funcion);
            
            int i = 0;
            char[] caracter = funcion.ToCharArray();

            while (i < caracter.LongLength)
            {
                if (double.TryParse(caracter[i].ToString(), out double number))
                    funcion = funcion.Replace(caracter[i].ToString(), "");
                else
                {
                    if (!Variables.Contains(caracter[i].ToString()))
                        Variables.Add(caracter[i].ToString());
                }
                i++;
            }

            return Variables;
        }

        public string Coeficiente(string funcion, string variable)
        {

            string filtro = "1";

            if (IsFuncion(funcion, variable))
            {
                filtro = funcion;
                
                while(IsFuncion(filtro, variable))
                {
                    if(IsFuncion(filtro.Replace(QueFuncion(filtro, variable), variable), variable))
                        filtro = filtro.Replace(QueFuncion(filtro, variable), variable);
                    else
                        filtro = filtro.Replace(QueFuncion(filtro, variable), "");                    
                }

                if (filtro.Equals("")) return "1";
                return filtro;
            }

            if (filtro.Contains("^"))
            {
                string baseFuncion = filtro.Substring(0, filtro.IndexOf("^"));
                string exponente = filtro.Substring(filtro.IndexOf("^") + 1);
            }

            filtro = funcion.Substring(0, funcion.IndexOf(variable));

            if (filtro.Equals("-")) return "-1";
            if (filtro.Equals("")) return "1";
            return filtro;

        }

        public string RemoverCoeficiente(string funcion, string variable)
        {
            int index = funcion.IndexOf(Coeficiente(funcion, variable));
            if (index == -1)
            {
                return funcion;
            }
            funcion = funcion.Remove(index, Coeficiente(funcion, variable).Length);

            return funcion;
        }

        public string IdentificarCoeficiente(string funcion, string variable)
        {

            if (IsFuncion(funcion, variable))
            {
                string coeficiente = Coeficiente(funcion, variable);
                if(!coeficiente.Equals("1"))
                    return $"{coeficiente}{QueFuncion(funcion, variable)}";
                return QueFuncion(funcion, variable);
            }

            string stringPrefijo;
            string stringPostfijo;
            string exponente;

            stringPrefijo = funcion.Substring(0, funcion.IndexOf(variable));
            stringPostfijo = funcion.Substring(funcion.IndexOf(variable) + 1);

            if (stringPrefijo.Equals("")) stringPrefijo = "1";
            if (stringPostfijo.Equals("")) stringPostfijo = "1";

            if (funcion.Contains(variable + "^"))
            {
                if (funcion.Contains($"{variable}^("))
                {
                    exponente = funcion.Substring(funcion.IndexOf($"{variable}^(") + 2, CierreFuncion(funcion, funcion.IndexOf($"{variable}^(") + 2));
                    exponente = "^(" + exponente + ")";
                }
                else
                {
                    exponente = funcion.Substring(funcion.IndexOf($"{variable}^") + 1);
                }

                variable = variable + exponente;

                if (!funcion.EndsWith(variable) && funcion.Contains(variable))
                {

                    funcion = funcion.Replace(variable, "") + variable;

                }
                return funcion;
            }

            if (!funcion.EndsWith(variable) && funcion.Contains(variable))
            {
                if (funcion.Contains("^"))
                {
                    if (!funcion.Contains("^("))
                    {
                        funcion = funcion.Substring(0, funcion.IndexOf("^")) + "^(" + funcion.Substring(funcion.IndexOf("^") + 1) + ")";
                    }
                }
                funcion = funcion.Replace(variable, "") + variable;

            }
            return funcion;
        }

        public string Encorchar (string funcion)
        {
            string stringPrefijo = "", stringPostfijo = "";
            int index = funcion.IndexOf("^");
            while (index >= 0)
            {
                
                stringPrefijo = funcion.Substring(0, index + 1);
                stringPostfijo = funcion.Substring(index + 1);


                if (!stringPostfijo.StartsWith("("))
                {
                    funcion = stringPrefijo + "(" + stringPostfijo + ")";
                }

                index = funcion.IndexOf("^", index + 1);
            }

            return funcion;
            
        }

        public string Descorchar (string funcion)
        {
            if (funcion.StartsWith("(") && funcion.LastIndexOf(")") == CierreFuncion(funcion, funcion.IndexOf("(")) - 1)
            {
                return funcion.Substring(1, funcion.LastIndexOf(")") - 1);
            }

            return funcion;
        }

        public List<int> VariableIndices (string funcion, string variable)
        {
            List<int> indices = new List<int>();
            int index = 0;
            char[] variables = funcion.ToCharArray();

            foreach (var caracter in variables)
            {
                if (caracter.ToString().Equals(variable))
                {
                    indices.Add(index);
                }

                ++index;
            }

            return indices;
        }

        public string EnfocarVariable (string funcion, int IndexOfVariable)
        {
            if (funcion == null || funcion.Equals("") || IndexOfVariable < 0)
                return "Argumentos invalidos (No enfocable)";

            string variable = funcion.Substring(IndexOfVariable, 1);
            if (!funcion.Contains(variable)) return null;

            int abierto = 0, cerrado = 0, foco = 0, inicioComposicion = 0, cierreComposicion = 0 , i = 0;

            if (IsFuncion(funcion, variable))
            {
                return QueFuncion(funcion, variable);
            }
            else if ( IsCompuesto(funcion, variable, funcion.IndexOf(variable)) ){

                
                foco = funcion.IndexOf(variable);
                i = foco;

                char[] caracter = funcion.ToCharArray();

                if (variable.Length < 1)
                    funcion.Replace(variable, "u");

                while (i >= 0)
                {
                    if (caracter[i] == ')')
                        ++cerrado;

                    if (caracter[i] == '(')
                        ++abierto;

                    if (abierto > cerrado)
                    {
                        inicioComposicion = i;
                        break;
                    }

                    --i;
                }

                cierreComposicion = CierreFuncion(funcion, inicioComposicion);

                string enfoque = funcion.Substring(inicioComposicion, cierreComposicion);

                if (funcion.Contains(enfoque + "^("))
                {
                    enfoque = funcion.Substring(inicioComposicion, CierreFuncion(funcion, inicioComposicion + cierreComposicion));
                } 
                else if(funcion.Contains(enfoque + "^"))
                {
                    enfoque = funcion.Substring(inicioComposicion);
                }
                else if (funcion.Contains($"^{enfoque}"))
                {
                    string baseFuncion = "";
                    if (funcion.Contains($")^{enfoque}"))
                    {
                        int EndIndex = funcion.IndexOf($")^{enfoque}");
                        int StartIndexBase = InicioFuncion(funcion, funcion.IndexOf($")^{enfoque}"));
                        baseFuncion = funcion.Substring(StartIndexBase, CierreFuncion(funcion, StartIndexBase));
                        enfoque = $"{baseFuncion}^{enfoque}";
                    }
                    else
                    {
                        baseFuncion = funcion.Substring(funcion.IndexOf($"^{enfoque}") - 1 , 1);
                        enfoque = $"{baseFuncion}^{enfoque}";
                    }
                }

                if (IsFuncion(funcion, enfoque))
                {
                    return QueFuncion(funcion, enfoque.Substring(1, enfoque.Length - 1));
                }

                return enfoque;
            }
            else
            {
                return variable;
            }

        }

        public bool IsCompuesto (string funcion, string variable, int indexOfVariable)
        {
            int abierto = 0, cerrado = 0, foco = 0, i;
            bool composicion = false;

            foco = indexOfVariable;
            i = foco;

            char[] caracter = funcion.ToCharArray();

            if (variable.Length < 1)
                funcion.Replace(variable, "u");

            while (i >= 0)
            {
                if (caracter[i] == ')')
                    ++cerrado;

                if (caracter[i] == '(')
                    ++abierto;

                if (abierto > cerrado)
                {
                    composicion = true;
                    break;
                }                  

                --i;
            }

            return composicion;
        }
        
    }
}
