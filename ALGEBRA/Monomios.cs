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
        public string Nombre { get; set; }
        public string Expresion { get; private set; }
        public string Coeficiente { get; private set; }
        public string ParteLiteral { get; private set; }
        public string Grado { get; private set; }
        Productos Producto = new Productos();
        Cocientes Cociente = new Cocientes();
        Potencias Potencia = new Potencias();
        AMathOps Suma = new Sumas();
        double number;
        bool A, B;
        string Desagrupado;

        ProcesosNew Proceso;

        public Monomios(string Coeficiente, string ParteLiteral)
        {
            this.Coeficiente = Coeficiente;
            this.ParteLiteral = ParteLiteral;
            ObtenerGrado();
            Producto = new Productos(Coeficiente, ParteLiteral);
            Expresion = Producto.Result;
            Nombre = $"Monomio {Producto.Result}";
        }

        public Monomios(string Monomio)
        {
            Expresion = Monomio;
            ObtenerElementos();
            Producto = new Productos(Coeficiente, ParteLiteral);
            Expresion = Producto.Result;
            Nombre = $"Monomio {Producto.Result}";
        }

        private void ObtenerElementos()
        {
            if (!Expresion.Contains(Producto.Simbolo))
            {
                //Puede ser Coeficiente o Parte literal
                if (double.TryParse(Expresion, out number))
                {
                    ParteLiteral = "1";
                    Coeficiente = Expresion;
                }

                else
                {
                    //Puede ser un coeficiente fraccionario o parte literal
                    if (Expresion.Contains(Cociente.Simbolo))
                    {
                        ParteLiteral = "1";
                        Coeficiente = Expresion;
                    }

                    else
                    {
                        Coeficiente = "1";
                        ParteLiteral = Expresion;
                    }
                }
            } //OK

            else
            {
                string[] Elementos = Expresion.Split(Producto.Simbolo.ElementAtOrDefault(0));

                Coeficiente = ParteLiteral = Grado = "";
                double grado = 0;

                foreach (var item in Elementos)
                {
                    if (item.Equals(Producto.ModuloCancelativo.ToString()))
                    {
                        Coeficiente = "0";
                        ParteLiteral = "0";
                        Grado = "0";
                        break;
                    }
                    else if (double.TryParse(item, out number))
                    {
                        Coeficiente += item;
                    }
                    else if (item.Contains(Cociente.Simbolo))
                    {
                        Coeficiente += item;
                    }
                    else
                    {
                        //Obtener Grado Absoluto
                        if (item.Contains(Potencia.Simbolo))
                        {
                            Proceso = new ProcesosNew(Potencia.Abrir, Potencia.Cerrar);
                            Desagrupado = Proceso.Descorchar(item);
                            Potencia = new Potencias(Desagrupado);
                            A = double.TryParse(Potencia.Exponente, out number);

                            if (A)
                            {
                                grado += double.Parse(Potencia.Exponente);
                            }
                            else
                            {
                                if (Grado.Equals(""))
                                    Grado += $"{Potencia.Exponente}";
                                else
                                    Grado += $"{Suma.Simbolo}{Potencia.Exponente}";
                            }
                        }
                        else
                        {
                            grado += 1;
                        }

                        //Obtencion de parte Literal
                        if (ParteLiteral.Equals(""))
                            ParteLiteral += $"{item}";
                        else
                            ParteLiteral += $"{Producto.Simbolo}{item}";
                    }
                }

                //Terminando de obtener grado Absoluto
                if (!ParteLiteral.Equals("0"))
                {
                    if (Grado.Equals(""))
                        Grado += $"{grado}";
                    else
                        Grado += $"{Suma.Simbolo}{grado}";
                }


            }


        }

        private void ObtenerGrado()
        {
            if (ParteLiteral.Equals("") || ParteLiteral == null || ParteLiteral.Equals("1") || Producto.Result.Equals(Producto.ModuloCancelativo))
            {
                Grado = "0";
            }
            else if (!ParteLiteral.Contains("^"))
            {
                Grado = "1";
            }
            else
            {
                string[] Elementos = ParteLiteral.Split(Producto.Simbolo.ElementAtOrDefault(0));
                double grado = 0;
                Grado = "";

                foreach (var item in Elementos)
                {
                    A = double.TryParse(item, out number);
                    B = item.Contains(Cociente.Simbolo.ElementAtOrDefault(0));

                    if (!A & !B)
                    {
                        A = item.Contains(Potencia.Simbolo);

                        if (A)
                        {
                            Proceso = new ProcesosNew(Potencia.Abrir, Potencia.Cerrar);
                            Desagrupado = Proceso.Descorchar(item);
                            Potencia = new Potencias(Desagrupado);

                            B = double.TryParse(Potencia.Exponente, out number);

                            if (B)
                            {
                                grado += double.Parse(Potencia.Exponente);
                            }
                            else
                            {
                                if (Grado.Equals(""))
                                    Grado = $"{Potencia.Exponente}";
                                else
                                    Grado = $"{Suma.Simbolo}{Potencia.Exponente}";
                            }

                        }
                        else
                        {
                            grado += 1;
                        }
                    }
                }

                if (Grado.Equals(""))
                    Grado = $"{grado}";
                else
                    Grado += $"{Suma.Simbolo}{grado}";
            }
        }
    }
