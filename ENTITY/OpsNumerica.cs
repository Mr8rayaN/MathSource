using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    //ACTUALIZAR SUMAS PARA OPERAR EN SUMAS ANIDADAS E INDEPENDIENTES DE LAS SUMAS PRINCIPALES
    public class SumaEntera : AMathOps 
    {
        public override string Nombre => "SUMA";
        public override int Modulo => 0;
        public override char Simbolo => '+';
        public override char Op => '(';
        public override char Cl => ')';
        private List<string> Temporal = new List<string>();
        private string SignosTemporal { get; set; }

        public SumaEntera()
        {

        }

        public SumaEntera(string Expresion)
        {
            Expresion = OperarSignos(Expresion);
            Contenido = Expresion;
            ObtenerSignos(Expresion);
            ObtenerElementos(Expresion, NumEntero.Simbolos);
            Proceso.CopyList(Temporal, Elementos);
            SignosTemporal = ListaSignos;
            Operar();
        }
        
        public override void Operar()
        {
            char signo = ' ';
            double Acomulador, Parseo; int index;
            Acomulador = Parseo = index = Modulo;
            
            foreach(var elemento in Elementos)
            {
                try
                {
                    Parseo = double.Parse(elemento);
                    signo = ListaSignos.ElementAt(index);
                    
                    if (signo.Equals(NumEntero.SimboloLocal))
                        Acomulador -= Parseo;
                    else
                        Acomulador += Parseo;

                    SignosTemporal = Proceso.ReplaceCharIn(SignosTemporal, "@", index);
                    Temporal.Remove(elemento);
                }
                catch (Exception) { }

                ++index;
            }

            SignosTemporal = SignosTemporal.Replace("@","");

            NumeroElementos = Temporal.Count;

            if (Acomulador != 0) {
                SignosTemporal += SignoAbsDe($"{Acomulador}");
                Temporal.Add($"{Math.Abs(Acomulador)}");
            }
                
            else if(NumeroElementos == 0)
            {
                Temporal.Add($"{Modulo}");
                SignosTemporal += SignoAbsDe($"{Modulo}");
            }

            index = 0;
            Result = "";

            foreach (var elemento in Temporal)
            {
                signo = SignosTemporal.ElementAtOrDefault(index);
                if(signo.Equals(NumEntero.Naturales.SimboloLocal) & Result.Equals(""))
                    Result += elemento;
                else
                    Result += signo + elemento;

                ++index;
            }

            Result = OperarSignos(Result);

        }

        private void ObtenerElementos(string LElementos, string Simbolos)
        {
            Elementos.Clear();
            
            char simboloComun = '@';

            foreach (var simbolo in Simbolos)
            {
                LElementos = LElementos.Replace(simbolo, simboloComun);
            }

            LElementos = LElementos.Trim(simboloComun);

            foreach (var elemento in LElementos.Split(simboloComun))
            {
                Elementos.Add(elemento);
            }
            
        }

    }

    //ACTUALIZAR PRODUCTOS PARA OPERAR EN PRODUCTOS ANIDADOS E INDEPENDIENTES DE LOS PRODUCTOS PRINCIPALES
    public class ProductoEntero : AMathOps
    {
        public override string Nombre => "PRODUCTO";
        public override int Modulo => 1;
        public int ModuloCancelativo => 0;
        public override char Simbolo => '*';
        public override char Op => '(';
        public override char Cl => ')';
        private List<string> Temporal = new List<string>();
        private string SignosTemporal { get; set; }

        public ProductoEntero()
        {

        }

        public ProductoEntero(string Multiplicando, string Multiplicador)
        {
            Contenido = Multiplicando + Simbolo + Multiplicador;
            Elementos.Add(Multiplicando);
            Elementos.Add(Multiplicador);
            ObtenerSignos(Elementos);
            Proceso.CopyList(Temporal, Elementos);
            Operar();
        }

        public ProductoEntero(string Expresion)
        {
            Contenido = Expresion;
            ObtenerElementos(Expresion);
            ObtenerSignos(Elementos);
            Proceso.CopyList(Temporal,Elementos);
            Operar();
        }

        public override void ObtenerElementos(string LElementos)
        {
            Contenido = "";

            foreach (var item in LElementos.Split(Simbolo))
            {
                Elementos.Add(item);

                if (Contenido.Equals(""))
                    Contenido += item;
                else
                    Contenido += Simbolo + item;
            }
        }

        public override void Operar()
        {
            double Parseo, Acomulador;
            Parseo = Acomulador = Modulo;

            foreach (var elemento in Elementos)
            {
                try
                {
                    Parseo = double.Parse(elemento);
                    if(Parseo == ModuloCancelativo)
                    {
                        Temporal.Clear();
                        Acomulador = ModuloCancelativo;
                        Temporal.Add($"{ModuloCancelativo}");
                        break;
                    }
                    Acomulador *= Parseo;
                    Temporal.Remove(elemento);
                }
                catch (Exception) { }
            }

            if (Acomulador != ModuloCancelativo)
            {
                if (Temporal.Count == 0)
                {
                    Temporal.Add($"{Acomulador}");
                }
                else if(Acomulador != Modulo)
                {
                    Temporal.Add($"{Acomulador}");
                }

            }

            Result = "";

            foreach (var elemento in Temporal)
            {
                if (Result.Equals(""))
                    Result += elemento;
                else
                    Result += Simbolo + elemento;
            }
        }
        
    }

    public class CocienteEntero : AMathOps
    {
        public override string Nombre => "COCIENTE";
        public override int Modulo => 1;
        public int ModuloCancelativo => 0;
        public override char Simbolo => '/';
        public override char Op => '{';
        public override char Cl => '}';
        public string Dividendo { get; private set; }
        public string Divisor { get; private set; }
        public string DividendoOut { get; private set; }
        public string DivisorOut { get; private set; }
        public ProductoEntero Producto = new ProductoEntero();
        public List<Variables> ListaVariables = new List<Variables>();
        private Variables variable = new Variables();
        private List<string> Temporal = new List<string>();
        private string SignosTemporal { get; set; }
        List<int> FactoresPrimosDividendo = new List<int>();
        List<int> FactoresPrimosDivisor = new List<int>();
        double number; int signo = 1;

        public CocienteEntero()
        {

        }

        public CocienteEntero(string Dividendo, string Divisor)
        {
            this.Dividendo = Dividendo;
            this.Divisor = Divisor;
            Operar();
        }

        public CocienteEntero(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
            {
                Contenido = Proceso.DescorcharA(Expresion);
            }
            else
                Contenido = Expresion;

            ObtenerElementos(Contenido);
            Operar();
        }

        public override void ObtenerElementos(string LElementos)
        {
            int i = 0, NumeroImplicitoDeOps = 0;

            foreach (var elemento in LElementos)
            {
                if (elemento.Equals(Simbolo))
                    ++NumeroImplicitoDeOps;
            }

            if(NumeroImplicitoDeOps == 0)
            {
                Dividendo = LElementos;
                Divisor = $"{Modulo}";
            }
            else if (NumeroImplicitoDeOps == 1)
            {
                i = 0;
                foreach (var elemento in LElementos.Split(Simbolo))
                {
                    if (i == 0)
                        Dividendo = elemento;
                    else if (i == 1)
                        Divisor = elemento;
                    ++i;
                }
            }
            else
            {
                ResolverNiveles();
            }
        }

        public override void Operar()
        {
            //Propiedades de cociente
            bool A = false, B = false, C = false, D = false, E = false;
            bool F = false;
            A = Dividendo.Equals(ModuloCancelativo.ToString());
            B = Divisor.Equals(ModuloCancelativo.ToString());
            C = Dividendo.Equals(Modulo.ToString());
            D = Divisor.Equals(Modulo.ToString());
            E = Dividendo.Equals(Divisor);
            F = double.TryParse(Dividendo, out number) & double.TryParse(Divisor, out number);

            Dividendo = Proceso.DescorcharFunciones(Dividendo);
            Divisor = Proceso.DescorcharFunciones(Divisor);

            if (B)
            {
                Result = ("Math ERROR");
            }

            else if (A & !B)
            {
                DividendoOut = Dividendo;
                DivisorOut = Divisor;
                Result = (ModuloCancelativo.ToString());
            }

            else if (C & D)
            {
                DividendoOut = Dividendo;
                DivisorOut = Divisor;
                Result = (Modulo.ToString());
            }

            else if (D)
            {
                DividendoOut = Dividendo;
                DivisorOut = Divisor;
                Result = (Dividendo);
            }

            else if (E)
            {
                DividendoOut = Dividendo;
                DivisorOut = Divisor;
                Result = (Modulo.ToString());
            }

            else if (F)
            {
                double dividendo = double.Parse(Dividendo);
                double divisor = double.Parse(Divisor);
                SimplificarEnteros(dividendo, divisor);
            }
            else
            {
                string Dvo = Dividendo.Replace($"{variable.Simbolo}", "");
                string Dvr = Divisor.Replace($"{variable.Simbolo}", "");

                A = (Dvo.Length > 2);
                B = (Dvr.Length > 2);

                if (A & B)
                {
                    Result = $"{Op}{Op}{Dividendo}{Cl}{Simbolo}{Op}{Divisor}{Cl}{Cl}";
                }
                else if (A)
                {
                    Result = $"{Op}{Op}{Dividendo}{Cl}{Simbolo}{Divisor}{Cl}";
                }
                else if (B)
                {
                    Result = $"{Op}{Dividendo}{Simbolo}{Op}{Divisor}{Cl}{Cl}";
                }
                else
                    Result = $"{Dividendo}{Simbolo}{Divisor}";

                DividendoOut = Dividendo;
                DivisorOut = Divisor;
                //Result = $"{Op}{Dividendo}{Simbolo}{Divisor}{Cl}";
            }

        } //OK

        private void SimplificarEnteros(double dividendo, double divisor)
        {
            //Multiplicacion de signos

            if (dividendo < 0)
            {
                signo = -1;
                dividendo = Math.Abs(dividendo);
            }

            else if (divisor < 0)
            {
                signo *= -1;
                divisor = Math.Abs(divisor);
            }

            //Comienza el proceso

            if (dividendo % divisor == 0)
            {
                dividendo *= signo;

                DividendoOut = $"{dividendo}";
                DivisorOut = $"{divisor}";
                Result = (dividendo / divisor).ToString();
            }
            else if (dividendo == Modulo)
            {
                dividendo *= signo;
                DividendoOut = $"{dividendo}";
                DivisorOut = $"{divisor}";
                Result = $"{dividendo}{Simbolo}{divisor}";
            }
            else
            {
                if (dividendo < divisor)
                {
                    Result = SiDivisorMayorDividendo(dividendo, divisor);
                }

                else
                {
                    Result = SiDividendoMayorDivisor(dividendo, divisor);
                }
            }
        } //OK

        private string SiDividendoMayorDivisor(double dividendo, double divisor)
        {
            int i, indexToRemove;

            //Simplificacion cuando menor es el divisor
            for (i = 2; i <= (dividendo / 2); i++)
            {
                if (dividendo % i == 0)
                {
                    dividendo = dividendo / i;
                    FactoresPrimosDividendo.Add(i);
                    i = 2;
                }
            }
            FactoresPrimosDividendo.Add((int)dividendo);

            for (i = 2; i <= (divisor / 2); i++)
            {
                if (divisor % i == 0)
                {
                    divisor = divisor / i;

                    //Simplificacion en curso
                    if (FactoresPrimosDividendo.Contains(i))
                    {
                        indexToRemove = FactoresPrimosDividendo.IndexOf(i);
                        FactoresPrimosDividendo.RemoveAt(indexToRemove);
                    }

                    else
                    {
                        FactoresPrimosDivisor.Add(i);
                    }

                    i = 2;
                }
            }

            if (FactoresPrimosDividendo.Contains((int)divisor))
            {
                indexToRemove = FactoresPrimosDividendo.IndexOf((int)divisor);
                FactoresPrimosDividendo.RemoveAt(indexToRemove);
            }

            else
            {
                FactoresPrimosDivisor.Add((int)divisor);
            }

            dividendo = 1;
            divisor = 1;

            foreach (var item in FactoresPrimosDividendo)
            {
                dividendo *= item;
            }

            dividendo *= signo;

            foreach (var item in FactoresPrimosDivisor)
            {
                divisor *= item;
            }

            DividendoOut = $"{dividendo}";
            DivisorOut = $"{divisor}";
            Dividendo = dividendo.ToString();
            Divisor = divisor.ToString();

            return $"{Dividendo}{Simbolo}{Divisor}";
        } //OK

        private string SiDivisorMayorDividendo(double dividendo, double divisor)
        {
            int i, indexToRemove;

            for (i = 2; i <= (divisor / 2); i++)
            {
                if (divisor % i == 0)
                {
                    divisor = divisor / i;
                    FactoresPrimosDivisor.Add(i);
                    i = 2;
                }
            }

            FactoresPrimosDivisor.Add((int)divisor);

            for (i = 2; i <= (dividendo / 2); i++)
            {
                if (dividendo % i == 0)
                {
                    dividendo = dividendo / i;

                    //Simplificacion en curso
                    if (FactoresPrimosDivisor.Contains(i))
                    {
                        indexToRemove = FactoresPrimosDivisor.IndexOf(i);
                        FactoresPrimosDivisor.RemoveAt(indexToRemove);
                    }

                    else
                    {
                        FactoresPrimosDividendo.Add(i);
                    }

                    i = 2;
                }
            }

            if (FactoresPrimosDivisor.Contains((int)dividendo))
            {
                indexToRemove = FactoresPrimosDivisor.IndexOf((int)dividendo);
                FactoresPrimosDivisor.RemoveAt(indexToRemove);
            }

            else
            {
                FactoresPrimosDividendo.Add((int)dividendo);
            }

            dividendo = 1;
            divisor = 1;

            foreach (var item in FactoresPrimosDividendo)
            {
                dividendo *= item;
            }

            dividendo *= signo;

            foreach (var item in FactoresPrimosDivisor)
            {
                divisor *= item;
            }

            DividendoOut = $"{dividendo}";
            DivisorOut = $"{divisor}";
            Dividendo = dividendo.ToString();
            Divisor = divisor.ToString();

            return $"{Dividendo}{Simbolo}{Divisor}";
        } //OK

        public override void ResolverNiveles()
        {
            string Temporal = Contenido;

            string Niveles = ObtenerNiveles(Temporal);
            string NivelesCop = Niveles;

            string Orden = ObtenerOrden(Niveles);
            string OrdenCop = Orden;

            int i, j, k, q = 0,  Izq, Der, Uno, Dos;
            bool A = true, B = true, WUno = true, WDos = true;

            Uno = 0;
            while(WUno)
            {
                var orden = Orden.ElementAt(Uno);
                k = 0; Dos = 0;

                while(WDos)
                {
                    var nivel = Niveles.ElementAt(Dos);
                    ++k;

                    if (nivel.Equals(orden))
                    {
                        i = j = 0; B = false;
                        while (i < Temporal.Length)
                        {
                            A = Temporal.ElementAt(i).Equals(Simbolo);
                            //B = Temporal.ElementAt(i).Equals(variable.Simbolo);

                            if (A)
                            {
                                ++j;
                            }
                                
                            if (j == k || i == Temporal.Length - 1)
                                break;
                            ++i;
                        }

                        j = i;
                        Izq = Der = 0;
                        A = B = true;

                        while (A || B)
                        {
                            if (A)
                            {
                                //CUERPO
                                Izq += Proceso.IsLlave(Temporal.ElementAt(i));
                                //FINCUERPO
                                if (Izq == 1 || i <= 0)
                                    A = false;
                                else
                                    --i;
                            }
                            if (B)
                            {
                                //CUERPO
                                Der += Proceso.IsLlave(Temporal.ElementAt(j));
                                //FINCUERPO
                                if (Der == -1 || j >= Temporal.Length - 1)
                                    B = false;
                                else
                                    ++j;
                            }
                        }


                        ++q;
                        //OBTENIDOS LOS INDICES DE INICIO (i) Y FIN (j) DE LA OP INTERNA
                        string Nom= $"U{q}";
                        //PROBLEMA DE RECURSIVIDAD INFINITA SI LA ETIQUETA ES IGUAL A LA FUNCION
                        //DEBE SER UN DERIVADO DE LA FUNCION A RESOLVER
                        //HACER QUE LA ETIQUETA QUEDE LIBRE DE AGRUPACIONES INNECESARIAS
                        string Etiqueta = $"{Temporal.Substring(i, (j - i) + 1)}";
                        Temporal = Temporal.Replace(Etiqueta, $"{variable.Simbolo}{Nom}");
                        Etiqueta = Proceso.DescorcharFunciones(Etiqueta);

                        CocienteEntero Interino = new CocienteEntero(Etiqueta);
                        string Res = Proceso.DescorcharFunciones(Interino.Result);
                        //OBTENER RESULTADO SEGUN LOS TIPOS
                        Variables Var = new Variables(Nom, Etiqueta, Res, true);

                        ListaVariables.Add(Var);
                        
                        if (!Temporal.Equals(Contenido))
                        {
                            Niveles = ObtenerNiveles(Temporal);
                            Orden = ObtenerOrden(Niveles);
                            Uno = -1;
                            break;
                        }

                    }

                    ++Dos;

                    if (Dos == Niveles.Length)
                        WDos = false;

                }

                ++Uno;

                if (Uno == Orden.Length)
                    WUno = false;
            }

            ResolverVariables(ListaVariables, NivelesCop, OrdenCop);

        }

        public CocienteEntero PropiedadDistributiva(CocienteEntero Dividendo, CocienteEntero Divisor)
        {
            Producto = new ProductoEntero(Dividendo.Dividendo, Divisor.Divisor);
            string ProductoDividendo = Producto.Result;

            Producto = new ProductoEntero(Dividendo.Divisor, Divisor.Dividendo);
            string ProductoDivisor = Producto.Result;

            Producto = new ProductoEntero();

            return new CocienteEntero(ProductoDividendo, ProductoDivisor);

        }

        public override void ResolverVariables(List<Variables> LVariables, string Niveles, string Orden)
        {
            LVariables.Reverse();
            string Nomb = "", Conten = "", Acomulador;
            int k, i, j; bool A = false, B = false;

            i = 0;
            variable = LVariables.ElementAt(i);
            Acomulador = (string)variable.Contenido;

            if (Acomulador.Contains(variable.Simbolo))
            {
                while(Acomulador.Contains(variable.Simbolo)){

                    Nomb = $"{variable.Simbolo}{LVariables.ElementAt(i).Nombre}";
                    Conten = (string)LVariables.ElementAt(i).Contenido;
                    //ENCORCHAR EL CONTENIDO SI ES NECESARIO;

                    A = (Conten.Length > 2);
                    B = Proceso.IsAgrupate(Conten);

                    if (A & !B)
                    {
                        Conten = Proceso.EncorcharFuncion(Conten);
                    }

                    Acomulador = Acomulador.Replace( Nomb, Conten);
                    ++i;
                }
            }

            //APLICA OREJITAS
            Acomulador = AplicarPropiedadPorSectores(Acomulador);
            Contenido = Acomulador;

            Niveles = ObtenerNiveles(Contenido);
            Orden = ObtenerOrden(Niveles);

            foreach (var orden in Orden)
            {
                k = 0; A = false;
                foreach (var nivel in Niveles)
                {
                    ++k;
                    if (nivel.Equals(orden))
                    {
                        i = j = 0;
                        if (Orden.EndsWith($"{orden}"))
                        {
                            Acomulador = Proceso.DescorcharFunciones(Contenido);

                            foreach (var elemento in Acomulador)
                            {
                                if (elemento.Equals(Simbolo))
                                {
                                    ++j;
                                }
                                if (j == k)
                                    break;
                                ++i;
                            }
                            Dividendo = Proceso.DescorcharFunciones(Acomulador.Substring(0, i));
                            Divisor = Proceso.DescorcharFunciones(Acomulador.Substring(i + 1));
                            A = true;
                            break;
                        }
                    }
                }

                if (A)
                    break;
            }
        }

        private string AplicarPropiedadPorSectores(string Expresion)
        {
            string Temporal = Expresion;

            string Niveles = ObtenerNiveles(Temporal);
            string NivelesCop = Niveles;

            string Orden = ObtenerOrden(Niveles);
            string OrdenCop = Orden;

            int i, j, k, q = 0, Izq, Der, Uno, Dos;
            bool A = true, B = true, WUno = true, WDos = true, Distribuyo = false;

            Uno = 0;
            while (WUno)
            {
                var orden = Orden.ElementAt(Uno);
                k = 0; Dos = 0;

                while (WDos)
                {
                    Distribuyo = false;
                    var nivel = Niveles.ElementAt(Dos);
                    ++k;

                    if (nivel.Equals(orden))
                    {
                        i = j = 0; B = false;
                        while (i < Temporal.Length)
                        {
                            A = Temporal.ElementAt(i).Equals(Simbolo);

                            if (A)
                            {
                                ++j;
                            }

                            if (j == k || i == Temporal.Length - 1)
                                break;
                            ++i;
                        }

                        j = i;
                        Izq = Der = 0;
                        A = B = true;

                        while (A || B)
                        {
                            if (A)
                            {
                                //CUERPO
                                Izq += Proceso.IsLlave(Temporal.ElementAt(i));
                                //FINCUERPO
                                if (Izq == 1 || i <= 0)
                                    A = false;
                                else
                                    --i;
                            }
                            if (B)
                            {
                                //CUERPO
                                Der += Proceso.IsLlave(Temporal.ElementAt(j));
                                //FINCUERPO
                                if (Der == -1 || j >= Temporal.Length - 1)
                                    B = false;
                                else
                                    ++j;
                            }
                        }

                        //OBTENGO LA OPERACION INTERNA Y VEO SI PUEDO APLICARLE LA PROPIEDAD
                        string OpInterna = $"{Temporal.Substring(i, (j - i) + 1)}";
                        //VALIDO SI PUEDO APLICARLE PROPIEDAD
                        if (IsDistribuible(OpInterna, Temporal))
                        {
                            //PROGRAMANDO DISTRIBUIR
                            Temporal = Distribuir(OpInterna, Temporal);
                            Distribuyo = true;
                        }


                        //FIN VALIDACION

                        if (!Temporal.Equals(Expresion) & Distribuyo)
                        {
                            Niveles = ObtenerNiveles(Temporal);
                            Orden = ObtenerOrden(Niveles);
                            Uno = -1;
                            break;
                        }

                    }

                    ++Dos;

                    if (Dos == Niveles.Length)
                        WDos = false;

                }

                ++Uno;

                if (Uno == Orden.Length)
                    WUno = false;
            }

            //RETORNAR EL OBJETO
            return Temporal;
        }

        private bool IsDistribuible(string Contenido, string Contenedor)
        {
            if (!Contenedor.Contains(Contenido))
                return false;

            int i = 0, j = 0;
            i = Contenedor.IndexOf(Contenido);
            j = (i) + (Contenido.Length - 1);

            if (Contenedor.Equals(Contenido))
                return false;
            else if (Contenedor.StartsWith(Contenido))
            {
                ++j;
                if (Contenedor.ElementAt(j).Equals(Simbolo))
                    return true;
                else
                    return false;
            }
            else if (Contenedor.EndsWith(Contenido))
            {
                --i;
                if (Contenedor.ElementAt(i).Equals(Simbolo))
                    return true;
                else
                    return false;
            }
            else
            {
                --i; ++j;
                bool A = Contenedor.ElementAt(j).Equals(Simbolo);
                bool B = Contenedor.ElementAt(i).Equals(Simbolo);

                if (A || B)
                    return true;
                else
                    return false;
            }
        }

        private string Distribuir(string Contenido, string Contenedor)
        {
            CocienteEntero dividendo = new CocienteEntero();
            CocienteEntero divisor = new CocienteEntero();
            int i = 0, j = 0; bool seguir = true;
            i = Contenedor.IndexOf(Contenido);
            j = (i) + (Contenido.Length - 1);

            string Resuelto = "";
            string Operador = "";
            string Operacion = "";

            if (Contenedor.StartsWith(Contenido))
            {
                dividendo = new CocienteEntero(Contenido);
                j = j + 2;
                int inicio = j;
                while (j < Contenedor.Length & seguir)
                {
                    if (Proceso.IsLlave(Contenedor.ElementAt(j)) == -1)
                    {
                        seguir = false;
                    }
                    ++j;
                }

                if (Proceso.IsLlave(Contenedor.ElementAt(inicio)) == 0 & !seguir)
                    --j;

                //Operador = Contenedor.Substring(inicio, (j - inicio) + 1);
                Operador = Contenedor.Substring(inicio, (j - inicio));
                Operacion = Contenido + Simbolo + Operador;
                divisor = new CocienteEntero(Operador);

                Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                return Contenedor.Replace(Operacion, Resuelto);
            }

            else if (Contenedor.EndsWith(Contenido))
            {
                divisor = new CocienteEntero(Contenido);
                i = i - 2;
                int final = i;
                while(i >= 0 & seguir)
                {
                    if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1 )
                    {
                        seguir = false;
                    }
                    --i;
                }

                //AGREGADO EL NO SEGUIR
                if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                    ++i;

                Operador = Contenedor.Substring(i, final + 1);
                Operacion = Operador + Simbolo + Contenido;
                dividendo = new CocienteEntero(Operador);

                Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                return Contenedor.Replace(Operacion, Resuelto);
            }

            else
            {
                --i; ++j;
                bool A = Contenedor.ElementAt(j).Equals(Simbolo);
                bool B = Contenedor.ElementAt(i).Equals(Simbolo);

                if (A)
                {
                    ++j;
                    dividendo = new CocienteEntero(Contenido);
                    int inicio = j;
                    while (j < Contenedor.Length & seguir)
                    {
                        if (Proceso.IsLlave(Contenedor.ElementAt(j)) == -1)
                        {
                            seguir = false;
                        }
                        ++j;
                    }

                    //AGREGADO EL NO SEGUIR
                    if (Proceso.IsLlave(Contenedor.ElementAt(inicio)) == 0 & !seguir)
                        --j;

                    Operador = Contenedor.Substring(inicio, (j - inicio));
                    Operacion = Contenido + Simbolo + Operador;
                    divisor = new CocienteEntero(Operador);

                }
                else if (B)
                {
                    --i;
                    divisor = new CocienteEntero(Contenido);
                    int final = i;
                    while (i >= 0 & seguir)
                    {
                        if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1)
                        {
                            seguir = false;
                        }
                        --i;
                    }

                    //AGREGADO EL NO SEGUIR
                    if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                        ++i;

                    Operador = Contenedor.Substring(i, final + 1);
                    Operacion = Operador + Simbolo + Contenido;
                    dividendo = new CocienteEntero(Operador);

                }

                Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                return Contenedor.Replace(Operacion, Resuelto);
            }
        }
    }

    
    public class PotenciaEntera : AMathOps
    {
        public override string Nombre => "POTENCIA";
        public override int Modulo => 1;
        public int ModuloCancelativo => 0;
        public override char Simbolo => '^';
        public override char Op => '{';
        public override char Cl => '}';
        public string Base { get; private set; }
        public string Exponente { get; private set; }
        double number;

        private ProductoEntero Producto = new ProductoEntero();
        private CocienteEntero Cociente = new CocienteEntero();
        private SumaEntera Suma = new SumaEntera();

        public PotenciaEntera()
        {

        }

        public PotenciaEntera(string Expresion)
        {
            Contenido = Proceso.DescorcharA(Expresion);
            Console.WriteLine(ObtenerNiveles(Contenido));
            Console.WriteLine(ObtenerOrden(ObtenerNiveles(Contenido)));
        }

        public override void Operar()
        {
            
        }

        public override void ObtenerElementos(string LElementos)
        {
            
        }

        public override void ResolverNiveles()
        {
            
        }
    }
}
