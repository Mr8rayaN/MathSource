using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGEBRA
{
    public class PropsMatematicas
    {
        Procesos proceso = new Procesos();

        public string POTENCIA_Distribuir(string funcion)
        {
            if (funcion.Contains("^"))
            {
                string stringPrefijo = funcion.Substring(0, funcion.IndexOf("^"));
                string stringPostfijo = funcion.Substring(funcion.IndexOf("^") + 1);
                string exponente = stringPostfijo, sobras = "";
                int inicio = 0, final = 0;

                if (stringPostfijo.Contains("(") && stringPostfijo.Contains(")"))
                {
                    inicio = stringPostfijo.IndexOf("(");
                    final = stringPostfijo.LastIndexOf(")") - stringPostfijo.IndexOf("(");
                    exponente = stringPostfijo.Substring(inicio + 1, final - 1);
                    sobras = sobras + stringPostfijo.Remove(inicio, final + 1);
                }

                if (stringPrefijo.Contains(")") && stringPrefijo.Contains("("))
                {
                    inicio = stringPrefijo.IndexOf("(");
                    final = stringPrefijo.LastIndexOf(")") - stringPrefijo.IndexOf("(");

                    string baseFuncion = stringPrefijo.Substring(inicio + 1, final - 1);
                    sobras = sobras + stringPrefijo.Remove(inicio, final + 1);

                    if (baseFuncion.Contains("^"))
                        return "Es una potencia anidada";
                    else if (baseFuncion.Contains("(") && baseFuncion.Contains(")"))
                    {
                        return "Es una distribucion anidada";
                    }
                    else
                    {
                        int length = baseFuncion.Length;
                        char[] variables = baseFuncion.ToCharArray();
                        string distribucion = "";

                        foreach (var caracter in variables)
                        {
                            distribucion = distribucion + caracter + "^" + $"({exponente})";
                        }

                        return $"({sobras}){distribucion}";

                    }


                }

            }

            return funcion;
        }
            
        public string PRODUCTO_Distribuir(string funcion)
        {
            return null;
        }
            
        public string COCIENTE_Distribuir(string funcion)
        {
            return null;
        }

        public string Agrupar(string funcion)
        {
            if (funcion == null || funcion.Equals("")) return "Funcion vacia (Inagrupable)";

            return Asociar(Fragmentar(funcion));

        }
        List<string> Fragmentar(string funcion)
        {

            if (funcion == null) return null;

            List<string> variables = proceso.ExtraerVariables(funcion), fragmentos = new List<string>();

            if (variables == null) return null;

            List<int> indices;
            string foco = "", argumento = "", baseFuncion = "", exponente = "", expo = "", bas = "";
            string laFuncion = funcion;
            int j = 0, indice = 0, inicio = 0;



            if (variables.Count > 0)
            {
                foreach (var variable in variables)
                {
                    indices = proceso.VariableIndices(laFuncion, variable);

                    for (j = 0; j < indices.Count; ++j)
                    {

                        indice = laFuncion.IndexOf(variable);
                        if (indice < 0)
                            break;
                        foco = proceso.EnfocarVariable(laFuncion, indice);
                        if (proceso.IsFuncion(foco, variable))
                        {
                            inicio = foco.IndexOf("(");
                            argumento = foco.Substring(inicio, proceso.CierreFuncion(foco, inicio));
                            if (foco.Contains(argumento + "^"))
                            {

                                baseFuncion = argumento;
                                inicio = baseFuncion.Length + 1;
                                exponente = foco.Substring(inicio, proceso.CierreFuncion(foco, inicio));

                                bas = Asociar(Fragmentar(proceso.Descorchar(baseFuncion)));
                                expo = Asociar(Fragmentar(proceso.Descorchar(exponente)));

                                if (baseFuncion.Length < bas.Length + 2)
                                {
                                    baseFuncion = $"({bas})";
                                }
                                if (exponente.Length < expo.Length + 2)
                                {
                                    exponente = $"({expo})";
                                }

                                laFuncion = laFuncion.Replace(foco, "@");
                                foco = $"{baseFuncion}^{exponente}";
                                laFuncion = laFuncion.Replace("@", foco);
                            }
                            else
                            {
                                baseFuncion = argumento;
                                foreach (var segmentoBase in Asociar(Fragmentar(proceso.Descorchar(baseFuncion))))
                                {
                                    bas = bas + segmentoBase;
                                }

                                if (baseFuncion.Length < bas.Length + 2)
                                {
                                    baseFuncion = $"({bas})";

                                    laFuncion = laFuncion.Replace(foco, "@");
                                    foco = foco.Replace(argumento, baseFuncion);
                                    laFuncion = laFuncion.Replace("@", foco);
                                }


                            }
                        }
                        fragmentos.Add(foco);
                        indice = laFuncion.IndexOf(foco);
                        laFuncion = laFuncion.Remove(indice, foco.Length);
                        laFuncion = laFuncion.Substring(0, indice) + ";" + laFuncion.Substring(indice);

                    }

                }

                string[] coeficientes = laFuncion.Split(';');

                for (j = 0; j < coeficientes.Length; j++)
                {
                    if (!coeficientes[j].Equals(""))
                        fragmentos.Add(coeficientes[j]);
                }

                return fragmentos;

            }

            fragmentos.Add(funcion);
            return fragmentos;

        }
        string Asociar(List<string> lista)
            {
                if (lista == null) return null;

                int inicio = 0, cierre = 0;
                int i = 0, j = 0;
                string baseFuncionI = "", baseFuncionJ = "", baseDescorchada = "", asociado = "";
                string exponenteI = "", exponenteJ = "";
                bool cambios = false;


                for (i = 0; i < lista.Count; ++i)
                {
                    string stringI = lista[i];
                    cambios = false;

                    if (lista[i].Contains("^"))
                    {
                        inicio = proceso.InicioFuncion(lista[i], lista[i].IndexOf("^") - 1);
                        cierre = proceso.CierreFuncion(lista[i], inicio);
                        baseFuncionI = lista[i].Substring(inicio, cierre);
                        baseDescorchada = proceso.Descorchar(baseFuncionI);

                        cierre = proceso.CierreFuncion(lista[i], lista[i].IndexOf("^") + 1);
                        inicio = lista[i].IndexOf("^") + 1;
                        exponenteI = lista[i].Substring(inicio, cierre);
                    }

                    for (j = i + 1; j < lista.Count; ++j)
                    {

                        string stringJ = lista[j];

                        if (lista[i].Contains("^") && cambios)
                        {
                            inicio = proceso.InicioFuncion(lista[i], lista[i].IndexOf("^") - 1);
                            cierre = proceso.CierreFuncion(lista[i], inicio);
                            baseFuncionI = lista[i].Substring(inicio, cierre);
                            baseDescorchada = proceso.Descorchar(baseFuncionI);

                            cierre = proceso.CierreFuncion(lista[i], lista[i].IndexOf("^") + 1);
                            inicio = lista[i].IndexOf("^") + 1;
                            exponenteI = lista[i].Substring(inicio, cierre);

                            cambios = false;
                        }

                        if (lista[j].Contains("^"))
                        {
                            inicio = proceso.InicioFuncion(lista[j], lista[j].IndexOf("^") - 1);
                            cierre = proceso.CierreFuncion(lista[j], inicio);
                            baseFuncionJ = lista[j].Substring(inicio, cierre);

                            cierre = proceso.CierreFuncion(lista[j], lista[j].IndexOf("^") + 1);
                            inicio = lista[j].IndexOf("^") + 1;
                            exponenteJ = lista[j].Substring(inicio, cierre);
                        }

                        if (double.TryParse(lista[i], out double number) && double.TryParse(lista[j], out number))
                        {
                            lista[i] = double.Parse(lista[i]) * double.Parse(lista[j]) + "";
                            lista.RemoveAt(j);

                            cambios = true;

                        }

                        else if (lista[j].Equals(baseDescorchada) || lista[j].Equals(baseFuncionI))
                        {
                            lista.RemoveAt(j);
                            if (double.TryParse(proceso.Descorchar(exponenteI), out number))
                            {
                                double exp = double.Parse(proceso.Descorchar(exponenteI));
                                lista[i] = $"{baseFuncionI}^({exp + 1})";
                            }
                            else
                                lista[i] = $"{baseFuncionI}^({proceso.Descorchar(exponenteI)}+1)";
                            cambios = true;
                        }

                        else if (lista[j].Contains("^"))
                        {
                            inicio = proceso.InicioFuncion(lista[j], lista[j].IndexOf("^") - 1);
                            cierre = proceso.CierreFuncion(lista[j], inicio);
                            baseFuncionJ = lista[j].Substring(inicio, cierre);

                            cierre = proceso.CierreFuncion(lista[j], lista[j].IndexOf("^") + 1);
                            inicio = lista[j].IndexOf("^") + 1;
                            exponenteJ = lista[j].Substring(inicio, cierre);

                            if (baseFuncionI.Equals(baseFuncionJ) || baseDescorchada.Equals(baseFuncionJ))
                            {
                                lista.RemoveAt(j);
                                if (exponenteI.Equals(exponenteJ))
                                {
                                    if (exponenteI.StartsWith("("))
                                    {
                                        lista[i] = $"{baseFuncionI}^(2{proceso.Descorchar(exponenteI)})";
                                    }
                                    else
                                        lista[i] = $"{baseFuncionI}^(2{exponenteI})";
                                }
                                lista[i] = $"{baseFuncionI}^({proceso.Descorchar(exponenteI)}+{proceso.Descorchar(exponenteJ)})";
                                string prueba = lista[i];
                                cambios = true;

                            }
                        }

                        else if (lista[i].Equals(lista[j]))
                        {
                            lista.RemoveAt(j);
                            lista[i] = $"({lista[i]})^(2)";
                            cambios = true;
                        }


                    }

                    if (cambios == true)
                        --i;
                }

                foreach (var segmento in lista)
                {
                    asociado = asociado + segmento;
                }

                return asociado;
            }


    }
}

