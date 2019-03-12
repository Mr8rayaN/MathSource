using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class SumaEntera : AMathOps
    {
        public override string Nombre => "SUMA";
        public override int Modulo => 0;
        public override char Simbolo => '+';
        public override char Op => '(';
        public override char Cl => ')';
        public string SumandoUno { get; private set; }
        public string SumandoDos { get; private set; }
        public List<Variables> ListaVariables = new List<Variables>();
        private Variables variable = new Variables();
        double number;

        public SumaEntera() { }

        public SumaEntera(string SumandoUno, string SumandoDos)
        {
            //VALIDAR SI SE NECESITA DESCORCHAR PARAMETROS
            Contenido = SumandoUno + Simbolo + SumandoDos;
            Contenido = Reconstruir(Contenido).Trim(Simbolo);

            bool A = IsRecursiva( Reconstruir(SumandoUno).Trim(Simbolo) );
            bool B = IsRecursiva( Reconstruir(SumandoDos).Trim(Simbolo) );

            if (A || B)
            {
                ObtenerElementos(Contenido);
                Operar();
            }

            else
            {
                this.SumandoUno = SumandoUno;
                this.SumandoDos = SumandoDos;
                Operar();
            }
        }

        public SumaEntera(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
            {
                Contenido = Proceso.DescorcharA(Expresion);
            }
            else
                Contenido = Expresion;

            Contenido = Reconstruir(Contenido);

            ObtenerElementos(Contenido);
            Operar();
        }

        private string Reconstruir(string Expresion)
        {
            Expresion = MaximizarSignos(Expresion);
            Expresion = Expresion.Trim(Simbolo);
            return Expresion;
        }

        //CREAR FUNCION ISRESCONSTRUIDO Y VALIDAR ANTES DE RECONSTRUIR CADA EXPRESION, YA QUE GENERA RECONSTRUCCIONES SOBRE RECOSTRUCCIONES

        public override void Operar()
        {
            bool A, B, C, D, E;

            A = double.TryParse(SumandoUno, out number);
            B = double.TryParse(SumandoDos, out number);
            C = ExtraerPrimerSigno(SumandoUno).Equals($"{Modulo}");
            D = ExtraerPrimerSigno(SumandoDos).Equals($"{Modulo}");
            E = IsOpposite(SumandoUno, SumandoDos);

            SumandoUno = Proceso.DescorcharParentesis(SumandoUno);
            SumandoDos = Proceso.DescorcharParentesis(SumandoDos);

            if (E)
                Result = $"{Modulo}";
            else if (D)
                Result = SumandoUno;
            else if (C)
                Result = SumandoDos;
            else if (A & B)
                Result = $"{double.Parse(SumandoUno) + double.Parse(SumandoDos)}";
            else
            {
                string SUno = SumandoUno.Replace($"{variable.Simbolo}", "");
                //SUno = ExtraerPrimerSigno(SUno);
                string SDos = SumandoDos.Replace($"{variable.Simbolo}", "");
                //SDos = ExtraerPrimerSigno(SDos);

                A = (SUno.Length > 2);
                B = (SDos.Length > 2);

                if (A & B)
                {
                    Result = $"{Op}{Op}{SumandoUno}{Cl}{Simbolo}{Op}{SumandoDos}{Cl}{Cl}";
                }
                else if (A)
                {
                    //Result = $"{Op}{Op}{Base}{Cl}{Simbolo}{Exponente}{Cl}";
                    Result = $"{Op}{SumandoUno}{Cl}{Simbolo}{SumandoDos}";
                }
                else if (B)
                {
                    //Result = $"{Op}{Base}{Simbolo}{Op}{Exponente}{Cl}{Cl}";
                    Result = $"{SumandoUno}{Simbolo}{Op}{SumandoDos}{Cl}";
                }
                else
                    Result = $"{SumandoUno}{Simbolo}{SumandoDos}";
            }

        }

        public override void ObtenerElementos(string LElementos)
        {
            int i = 0, NumeroImplicitoDeOps = 0;

            foreach (var elemento in LElementos)
            {
                if (elemento.Equals(Simbolo))
                    ++NumeroImplicitoDeOps;
            }

            if (NumeroImplicitoDeOps == 0)
            {
                SumandoUno = LElementos;
                SumandoDos = $"{Modulo}";
            }
            else if (NumeroImplicitoDeOps == 1)
            {
                i = 0;
                foreach (var elemento in LElementos.Split(Simbolo))
                {
                    if (i == 0)
                        SumandoUno = elemento;
                    else if (i == 1)
                        SumandoDos = elemento;
                    ++i;
                }
            }
            else
            {
                ResolverNiveles();
            }
        }

        public override void ResolverNiveles()
        {
            string Temporal = Contenido;

            string Niveles = ObtenerNiveles(Temporal);
            string NivelesCop = Niveles;

            string Orden = ObtenerOrden(Niveles);
            string OrdenCop = Orden;

            int i, j, k, q = 0, Izq, Der, Uno, Dos;
            bool A = true, B = true, WUno = true, WDos = true;

            //RECURSIVIDAD INFINITA SI LOS NIVELES SON TODOS IGUALES, CORREGIR ESE PROBLEMA

            Uno = 0;
            while (WUno)
            {
                var orden = Orden.ElementAt(Uno);
                k = 0; Dos = 0;

                while (WDos)
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
                                //NUEVA CONDICION EN MARCHA
                                if (i > 0)
                                {
                                    if (Temporal.ElementAt(i - 1).Equals(Simbolo))
                                        Izq += 1;
                                }
                                //FIN NUEVA CONDICION
                                //FINCUERPO
                                //if (Izq == 1 || i <= 0)
                                if (Izq >= 1 || i <= 0)
                                    A = false;
                                else
                                    --i;
                            }
                            if (B)
                            {
                                //CUERPO
                                Der += Proceso.IsLlave(Temporal.ElementAt(j));
                                //NUEVA CONDICION EN MARCHA
                                //if(j < (Temporal.Length - 1)) MOD POR LA ESTIMACION DE NO PODER SER EL ULTIMO ELEMENTO UN SIMBOLO
                                if (j < (Temporal.Length - 2))
                                {
                                    if (Temporal.ElementAt(j + 1).Equals(Simbolo))
                                        Der += -1;
                                }
                                //FIN NUEVA CONDICION
                                //FINCUERPO
                                //if (Der == -1 || j >= Temporal.Length - 1)
                                if (Der <= -1 || j >= Temporal.Length - 1)
                                    B = false;
                                else
                                    ++j;
                            }
                        }


                        ++q;
                        //OBTENIDOS LOS INDICES DE INICIO (i) Y FIN (j) DE LA OP INTERNA
                        string Nom = $"U{q}";
                        //PROBLEMA DE RECURSIVIDAD INFINITA SI LA ETIQUETA ES IGUAL A LA FUNCION
                        //DEBE SER UN DERIVADO DE LA FUNCION A RESOLVER
                        //HACER QUE LA ETIQUETA QUEDE LIBRE DE AGRUPACIONES INNECESARIAS
                        string Etiqueta = $"{Temporal.Substring(i, (j - i) + 1)}";
                        Temporal = Temporal.Replace(Etiqueta, $"{variable.Simbolo}{Nom}");
                        Etiqueta = Proceso.DescorcharA(Etiqueta);

                        SumaEntera Interino = new SumaEntera(Etiqueta);
                        string Res = Proceso.DescorcharA(Interino.Result);
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
                while (Acomulador.Contains(variable.Simbolo))
                {

                    Nomb = $"{variable.Simbolo}{LVariables.ElementAt(i).Nombre}";
                    Conten = (string)LVariables.ElementAt(i).Contenido;
                    //ENCORCHAR EL CONTENIDO SI ES NECESARIO;

                    A = (Conten.Length > 2);
                    B = Proceso.IsAgrupate(Conten);

                    if (A & !B)
                    {
                        Conten = Proceso.EncorcharParentesis(Conten);
                    }

                    Acomulador = Acomulador.Replace(Nomb, Conten);
                    ++i;
                }
            }

            //APLICA PROPIEDADES INTERNAS
            Acomulador = AplicarPropiedadPorSectores(Acomulador);
            //FIN APLICACION DE PROPS
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
                            Acomulador = Proceso.DescorcharA(Contenido);

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
                            SumandoUno = Proceso.DescorcharA(Acomulador.Substring(0, i));
                            SumandoDos = Proceso.DescorcharA(Acomulador.Substring(i + 1));
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

            int i, j, k, Izq, Der, Uno, Dos;
            bool A = true, B = true, WUno = true, WDos = true, Distribuyo = false;

            Uno = 0;
            while (WUno)
            {
                var orden = Orden.ElementAt(Uno);
                k = 0; Dos = 0; WDos = true;

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

                        //SI SE DISTRIBUYE ALGO INDISTRIBUIBLE SE PRODUCE UN BUCLE INFINITO

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
            //CocienteEntero dividendo = new CocienteEntero();
            //CocienteEntero divisor = new CocienteEntero();
            SumaEntera FactorUno = new SumaEntera();
            SumaEntera FactorDos = new SumaEntera();

            int i = 0, j = 0; bool seguir = true;
            i = Contenedor.IndexOf(Contenido);
            j = (i) + (Contenido.Length - 1);

            string Resuelto = "";
            string Operador = "";
            string Operacion = "";

            if (Contenedor.StartsWith(Contenido))
            {
                //dividendo = new CocienteEntero(Contenido);
                FactorUno = new SumaEntera(Contenido);
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

                //COLOCADO PARA EVITAR EL DESBORDAMIENTO
                if( (inicio + (j - inicio)) < Contenedor.Length )
                    Operador = Contenedor.Substring(inicio, (j - inicio) + 1); //HABILITADO POR EL ERROR DE ABAJO
                else
                    Operador = Contenedor.Substring(inicio, (j - inicio)); //OMITIA EL ULTIMO PARENTESIS SI HA DE LLEVARLO

                Operacion = Contenido + Simbolo + Operador;
                //divisor = new CocienteEntero(Operador);
                FactorDos = new SumaEntera(Operador);

                //Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                Resuelto = PropiedadDistributiva(FactorUno, FactorDos);
                return Contenedor.Replace(Operacion, Resuelto);
            }

            else if (Contenedor.EndsWith(Contenido))
            {
                //divisor = new CocienteEntero(Contenido);
                FactorDos = new SumaEntera(Contenido);
                i = i - 2;
                int final = i;
                while (i >= 0 & seguir)
                {
                    if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1)
                    {
                        seguir = false;
                    }

                    if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                        --i;
                    else //ACABADO DE COLOCAR PARA PRUEBAS
                        break;
                }

                //AGREGADO EL NO SEGUIR
                if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                    ++i;

                //Operador = Contenedor.Substring(i, final + 1);
                Operador = Contenedor.Substring(i, (final - i) + 1);
                Operacion = Operador + Simbolo + Contenido;
                //dividendo = new CocienteEntero(Operador);
                FactorUno = new SumaEntera(Operador);

                //Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                Resuelto = PropiedadDistributiva(FactorUno, FactorDos);
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
                    //dividendo = new CocienteEntero(Contenido);
                    FactorUno = new SumaEntera(Contenido);

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

                    //COLOCADO PARA EVITAR EL DESBORDAMIENTO
                    if ((inicio + (j - inicio)) < Contenedor.Length)
                        Operador = Contenedor.Substring(inicio, (j - inicio) + 1); //HABILITADO POR EL ERROR DE ABAJO
                    else
                        Operador = Contenedor.Substring(inicio, (j - inicio)); //OMITIA EL ULTIMO PARENTESIS SI HA DE LLEVARLO

                    Operacion = Contenido + Simbolo + Operador;
                    //divisor = new CocienteEntero(Operador);
                    FactorDos = new SumaEntera(Operador);

                }
                else if (B)
                {
                    --i;
                    //divisor = new CocienteEntero(Contenido);
                    FactorDos = new SumaEntera(Contenido);

                    int final = i;
                    while (i >= 0 & seguir)
                    {
                        if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1)
                        {
                            seguir = false;
                        }
                        if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                            --i;
                        else //ACABADO DE COLOCAR PARA PRUEBAS
                            break;
                    }

                    //AGREGADO EL NO SEGUIR
                    if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                        ++i;

                    //Operador = Contenedor.Substring(i, final + 1);
                    Operador = Contenedor.Substring(i, (final - i) + 1);
                    Operacion = Operador + Simbolo + Contenido;
                    //dividendo = new CocienteEntero(Operador);
                    FactorUno = new SumaEntera(Operador);

                }

                //Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                Resuelto = PropiedadDistributiva(FactorUno, FactorDos);
                Resuelto = Proceso.DescorcharA(Resuelto);//ACABADO DE COLOCAR PARA INICIAR PRUEBAS
                return Contenedor.Replace(Operacion, Resuelto);
            }
        }

        public string PropiedadDistributiva(SumaEntera Mdo, SumaEntera Mor)
        {
            int i = 0; double Acomulador = Modulo; string elemento, Res;
            List<string> LElementos = new List<string>();
            LElementos.Add(Mdo.SumandoUno);
            LElementos.Add(Mdo.SumandoDos);
            LElementos.Add(Mor.SumandoUno);
            LElementos.Add(Mor.SumandoDos);

            while (i < LElementos.Count)
            {
                elemento = LElementos.ElementAt(i);
                if (double.TryParse(elemento, out number))
                {
                    Acomulador += double.Parse(elemento);
                    LElementos.RemoveAt(i);
                    i = 0;
                }
                else
                    ++i;
            }

            if (LElementos.Count < 1)
                return $"{Acomulador}";
            else
            {
                Res = "";

                foreach (var item in LElementos)
                {
                    Res += item + Simbolo;
                }

                if (Acomulador != Modulo)
                    Res += $"{Acomulador}";

                Res = Res.Trim(Simbolo);

                return Res;
            }
        }

    } //FUNCIONANDO AL 100%

    public class ProductoEntero : AMathOps
    {
        public override string Nombre => "PRODUCTO";
        public override int Modulo => 1;
        public int ModuloCancelativo => 0;
        public override char Simbolo => '*';
        public override char Op => '(';
        public override char Cl => ')';
        private string Multiplicando = "";
        private string Multiplicador = "";
        public List<Variables> ListaVariables = new List<Variables>();
        private Variables variable = new Variables();
        private char EspSimbolo => '~';
        double number;

        public ProductoEntero() { }

        public ProductoEntero(string Multiplicando, string Multiplicador)
        {
            //VALIDAR SI SE NECESITA DESCORCHAR PARAMETROS
            Contenido = Multiplicando + Simbolo + Multiplicador;
            bool A = IsRecursiva(Multiplicando);
            bool B = IsRecursiva(Multiplicador);

            if( A || B)
            {
                ObtenerElementos(Contenido);
                Operar();
            }

            else
            {
                this.Multiplicador = Multiplicador;
                this.Multiplicando = Multiplicando;
                Operar();
            }

        }

        public ProductoEntero(string Expresion)
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

            if (NumeroImplicitoDeOps == 0)
            {
                Multiplicando = LElementos;
                Multiplicador = $"{Modulo}";
            }
            else if (NumeroImplicitoDeOps == 1)
            {
                i = 0;
                foreach (var elemento in LElementos.Split(Simbolo))
                {
                    if (i == 0)
                        Multiplicando = elemento;
                    else if (i == 1)
                        Multiplicador = elemento;
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
            bool A, B, C, D, E;

            A = double.TryParse(Multiplicando, out number);
            B = double.TryParse(Multiplicador, out number);
            C = Multiplicando.Equals($"{Modulo}");
            D = Multiplicador.Equals($"{Modulo}");
            E = Multiplicando.Equals($"{ModuloCancelativo}") || Multiplicador.Equals($"{ModuloCancelativo}");

            Multiplicando = Proceso.DescorcharA(Multiplicando);
            Multiplicador = Proceso.DescorcharA(Multiplicador);

            if (E)
                Result = $"{ModuloCancelativo}";
            else if (D)
                Result = Multiplicando;
            else if (C)
                Result = Multiplicador;
            else if(A & B)
            {
                double multiplicando = double.Parse(Multiplicando);
                double multiplicador = double.Parse(Multiplicador);

                Result = $"{multiplicador * multiplicando}";
            }
            else
            {
                string Mdo = Multiplicando.Replace($"{variable.Simbolo}", "");
                string Mor = Multiplicador.Replace($"{variable.Simbolo}", "");

                A = (Mdo.Length > 2);
                B = (Mor.Length > 2);

                //SOLUCIONA MOMENTANEAMENTE PROBLEMAS
                A = false; B = false; //COLOCADO DE PRUEBA PARA VERIFICAR ERRORES. PROBANDO

                if (A & B)
                {
                    Result = $"{Op}{Op}{Multiplicando}{Cl}{Simbolo}{Op}{Multiplicador}{Cl}{Cl}";
                }
                else if (A)
                {
                    //Result = $"{Op}{Op}{Base}{Cl}{Simbolo}{Exponente}{Cl}";
                    Result = $"{Op}{Multiplicando}{Cl}{Simbolo}{Multiplicador}";
                }
                else if (B)
                {
                    //Result = $"{Op}{Base}{Simbolo}{Op}{Exponente}{Cl}{Cl}";
                    Result = $"{Multiplicando}{Simbolo}{Op}{Multiplicador}{Cl}";
                }
                else
                    Result = $"{Multiplicando}{Simbolo}{Multiplicador}";
            }
        }

        public override void ResolverNiveles()
        {
            string Temporal = Contenido;

            string Niveles = ObtenerNiveles(Temporal);
            string NivelesCop = Niveles;

            string Orden = ObtenerOrden(Niveles);
            string OrdenCop = Orden;

            int i, j, k, q = 0, Izq, Der, Uno, Dos;
            bool A = true, B = true, WUno = true, WDos = true;

            //RECURSIVIDAD INFINITA SI LOS NIVELES SON TODOS IGUALES, CORREGIR ESE PROBLEMA

            Uno = 0;
            while (WUno)
            {
                var orden = Orden.ElementAt(Uno);
                k = 0; Dos = 0;

                while (WDos)
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
                                //NUEVA CONDICION EN MARCHA
                                if (i > 0)
                                {
                                    if (Temporal.ElementAt(i - 1).Equals(Simbolo))
                                        Izq += 1;
                                }
                                //FIN NUEVA CONDICION
                                //FINCUERPO
                                //if (Izq == 1 || i <= 0)
                                if (Izq >= 1 || i <= 0)
                                    A = false;
                                else
                                    --i;
                            }
                            if (B)
                            {
                                //CUERPO
                                Der += Proceso.IsLlave(Temporal.ElementAt(j));
                                //NUEVA CONDICION EN MARCHA
                                //if(j < (Temporal.Length - 1)) MOD POR LA ESTIMACION DE NO PODER SER EL ULTIMO ELEMENTO UN SIMBOLO
                                if (j < (Temporal.Length - 2))
                                {
                                    if (Temporal.ElementAt(j + 1).Equals(Simbolo))
                                        Der += -1;
                                }
                                //FIN NUEVA CONDICION
                                //FINCUERPO
                                //if (Der == -1 || j >= Temporal.Length - 1)
                                if (Der <= -1 || j >= Temporal.Length - 1)
                                    B = false;
                                else
                                    ++j;
                            }
                        }


                        ++q;
                        //OBTENIDOS LOS INDICES DE INICIO (i) Y FIN (j) DE LA OP INTERNA
                        string Nom = $"U{q}";
                        //PROBLEMA DE RECURSIVIDAD INFINITA SI LA ETIQUETA ES IGUAL A LA FUNCION
                        //DEBE SER UN DERIVADO DE LA FUNCION A RESOLVER
                        //HACER QUE LA ETIQUETA QUEDE LIBRE DE AGRUPACIONES INNECESARIAS
                        string Etiqueta = $"{Temporal.Substring(i, (j - i) + 1)}";
                        Temporal = Temporal.Replace(Etiqueta, $"{variable.Simbolo}{Nom}");
                        Etiqueta = Proceso.DescorcharA(Etiqueta);

                        ProductoEntero Interino = new ProductoEntero(Etiqueta);
                        string Res = Proceso.DescorcharA(Interino.Result);
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
        
        public override void ResolverVariables(List<Variables> LVariables, string Niveles, string Orden)
        {
            LVariables.Reverse();
            string Nomb = "", Conten = "", Acomulador;
            int k, i, j; bool A = false, B = false, C = false, D=false;

            i = 0;
            variable = LVariables.ElementAt(i);
            Acomulador = (string)variable.Contenido;

            if (Acomulador.Contains(variable.Simbolo))
            {
                while (Acomulador.Contains(variable.Simbolo))
                {

                    Nomb = $"{variable.Simbolo}{LVariables.ElementAt(i).Nombre}";
                    Conten = (string)LVariables.ElementAt(i).Contenido;
                    //ENCORCHAR EL CONTENIDO SI ES NECESARIO;

                    int AntIndex = 0;
                    if (Acomulador.IndexOf(Nomb) > 0)
                    {
                        AntIndex = Acomulador.IndexOf(Nomb) - 1;
                    }

                    A = (Conten.Length > 2);
                    B = Proceso.IsAgrupate(Conten);
                    D = Acomulador.ElementAt(AntIndex).Equals('^');

                    if (D)
                    {
                        Conten = Proceso.EncorcharFuncion(Conten);
                    }

                    C = Conten.StartsWith("<") || Conten.StartsWith("{");

                    //AGREGADO PARA PRUEBAS EXPERIMENTALES CON FUNCIONES
                    if (C)
                    {
                        Conten = Conten.Replace(Simbolo, EspSimbolo);
                    }
                    //FIN PRUEBA
                    else if (A & !B) //AÑADIR !C SI SE ELIMINA LOD E ARRIBA
                    {
                        Conten = Proceso.EncorcharParentesis(Conten);
                    }

                    Acomulador = Acomulador.Replace(Nomb, Conten);
                    ++i;
                }
            }

            //APLICA PROPIEDADES INTERNAS
            Acomulador = AplicarPropiedadPorSectores(Acomulador);
            //FIN APLICACION DE PROPS
            Contenido = Acomulador;

            Niveles = ObtenerNiveles(Contenido);
            Orden = ObtenerOrden(Niveles);

            if (Contenido.Contains(EspSimbolo))
                Contenido = Contenido.Replace(EspSimbolo, Simbolo);

            if (Niveles.Equals(""))
            {
                Multiplicando = Contenido;
                Multiplicador = $"{Modulo}";
            }
            else
            {
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
                                Acomulador = Proceso.DescorcharA(Contenido);

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
                                Multiplicando = Proceso.DescorcharA(Acomulador.Substring(0, i));
                                Multiplicador = Proceso.DescorcharA(Acomulador.Substring(i + 1));
                                A = true;
                                break;
                            }
                        }
                    }

                    if (A)
                        break;
                }
            }
            
        }

        private string AplicarPropiedadPorSectores(string Expresion)
        {
            if (!Expresion.Contains(Simbolo))
                return Expresion;

            string Temporal = Expresion;

            string Niveles = ObtenerNiveles(Temporal);
            string NivelesCop = Niveles;

            string Orden = ObtenerOrden(Niveles);
            string OrdenCop = Orden;

            int i, j, k, Izq, Der, Uno, Dos;
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

        public string PropiedadDistributiva(ProductoEntero Mdo, ProductoEntero Mor)
        {
            int i = 0; double Acomulador = 1; string elemento, Res; bool Cancelado = false;
            List<string> LElementos = new List<string>();
            LElementos.Add(Mdo.Multiplicando);
            LElementos.Add(Mdo.Multiplicador);
            LElementos.Add(Mor.Multiplicando);
            LElementos.Add(Mor.Multiplicador);

            while (i < LElementos.Count)
            {
                elemento = LElementos.ElementAt(i);
                if (elemento.Equals($"{ModuloCancelativo}"))
                {
                    LElementos.Clear();
                    Cancelado = true;
                    break;
                }
                else
                {
                    if (double.TryParse(elemento, out number))
                    {
                        Acomulador *= double.Parse(elemento);
                        LElementos.RemoveAt(i);
                        i = 0;
                    }
                    else
                        ++i;
                }
            }

            if (Cancelado)
                return $"{ModuloCancelativo}";
            else if (LElementos.Count < 1)
                return $"{Acomulador}";
            else
            {
                Res = "";
                if (Acomulador != 1)
                    Res = $"{Acomulador}";

                foreach (var item in LElementos)
                {
                    Res += Simbolo + item;
                }

                Res = Res.Trim(Simbolo);

                return Res;
            }
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
            //CocienteEntero dividendo = new CocienteEntero();
            //CocienteEntero divisor = new CocienteEntero();
            ProductoEntero FactorUno = new ProductoEntero();
            ProductoEntero FactorDos = new ProductoEntero();

            int i = 0, j = 0; bool seguir = true;
            i = Contenedor.IndexOf(Contenido);
            j = (i) + (Contenido.Length - 1);

            string Resuelto = "";
            string Operador = "";
            string Operacion = "";

            if (Contenedor.StartsWith(Contenido))
            {
                //dividendo = new CocienteEntero(Contenido);
                FactorUno = new ProductoEntero(Contenido);
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
                //Operador = Contenedor.Substring(inicio, (j - inicio)); ANTIGUAS SENTENCIAS, TAL VEZ PRODUCIAN DESBORDAMIENTOS

                //COLOCADO PARA EVITAR EL DESBORDAMIENTO
                if ((inicio + (j - inicio)) < Contenedor.Length)
                    Operador = Contenedor.Substring(inicio, (j - inicio) + 1); //HABILITADO POR EL ERROR DE ABAJO
                else
                    Operador = Contenedor.Substring(inicio, (j - inicio)); //OMITIA EL ULTIMO PARENTESIS SI HA DE LLEVARLO

                Operacion = Contenido + Simbolo + Operador;
                //divisor = new CocienteEntero(Operador);
                FactorDos = new ProductoEntero(Operador);

                //Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                Resuelto = PropiedadDistributiva(FactorUno, FactorDos);
                return Contenedor.Replace(Operacion, Resuelto);
            }

            else if (Contenedor.EndsWith(Contenido))
            {
                //divisor = new CocienteEntero(Contenido);
                FactorDos = new ProductoEntero(Contenido);
                i = i - 2;
                int final = i;
                while (i >= 0 & seguir)
                {
                    if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1)
                    {
                        seguir = false;
                    }

                    if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                        --i;
                    else //ACABADO DE COLOCAR PARA PRUEBAS
                        break;
                }

                //AGREGADO EL NO SEGUIR
                if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                    ++i;

                //Operador = Contenedor.Substring(i, final + 1);
                Operador = Contenedor.Substring(i, (final - i) + 1);
                Operacion = Operador + Simbolo + Contenido;
                //dividendo = new CocienteEntero(Operador);
                FactorUno = new ProductoEntero(Operador);

                //Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                Resuelto = PropiedadDistributiva(FactorUno, FactorDos);
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
                    //dividendo = new CocienteEntero(Contenido);
                    FactorUno = new ProductoEntero(Contenido);

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

                    //Operador = Contenedor.Substring(inicio, (j - inicio)); ANTIGUA SENTENCIA TAL VEZ PODRIA OCASIONAR DESBORDAMIENTOS

                    //COLOCADO PARA EVITAR EL DESBORDAMIENTO
                    if ((inicio + (j - inicio)) < Contenedor.Length)
                        Operador = Contenedor.Substring(inicio, (j - inicio) + 1); //HABILITADO POR EL ERROR DE ABAJO
                    else
                        Operador = Contenedor.Substring(inicio, (j - inicio)); //OMITIA EL ULTIMO PARENTESIS SI HA DE LLEVARLO

                    Operacion = Contenido + Simbolo + Operador;
                    //divisor = new CocienteEntero(Operador);
                    FactorDos = new ProductoEntero(Operador);

                }
                else if (B)
                {
                    --i;
                    //divisor = new CocienteEntero(Contenido);
                    FactorDos = new ProductoEntero(Contenido);

                    int final = i;
                    while (i >= 0 & seguir)
                    {
                        if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1)
                        {
                            seguir = false;
                        }
                        if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                            --i;
                        else //ACABADO DE COLOCAR PARA PRUEBAS
                            break;
                    }

                    //AGREGADO EL NO SEGUIR
                    if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                        ++i;

                    //Operador = Contenedor.Substring(i, final + 1);
                    Operador = Contenedor.Substring(i, (final - i) + 1);
                    Operacion = Operador + Simbolo + Contenido;
                    //dividendo = new CocienteEntero(Operador);
                    FactorUno = new ProductoEntero(Operador);

                }

                //Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                Resuelto = PropiedadDistributiva(FactorUno, FactorDos);
                Resuelto = Proceso.DescorcharA(Resuelto);//ACABADO DE COLOCAR PARA INICIAR PRUEBAS
                return Contenedor.Replace(Operacion, Resuelto);
            }
        }


    } //FUNCIONANDO AL 100%

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
        public ProductoEntero Producto = new ProductoEntero();
        public List<Variables> ListaVariables = new List<Variables>();
        private Variables variable = new Variables();
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
            Contenido = Dividendo + Simbolo + Divisor;
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

            Dividendo = Proceso.DescorcharA(Dividendo);
            Divisor = Proceso.DescorcharA(Divisor);

            if (B)
            {
                Result = ($"Math ERROR in {Nombre} with {Contenido}");
            }

            else if (A & !B)
            {
                Result = (ModuloCancelativo.ToString());
            }

            else if (C & D)
            {
                Result = (Modulo.ToString());
            }

            else if (D)
            {
                Result = (Dividendo);
            }

            else if (E)
            {
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
                    //Result = $"{Op}{Op}{Dividendo}{Cl}{Simbolo}{Divisor}{Cl}";
                    Result = $"{Op}{Dividendo}{Cl}{Simbolo}{Divisor}";
                }
                else if (B)
                {
                    //Result = $"{Op}{Dividendo}{Simbolo}{Op}{Divisor}{Cl}{Cl}";
                    Result = $"{Dividendo}{Simbolo}{Op}{Divisor}{Cl}";
                }
                else
                    Result = $"{Dividendo}{Simbolo}{Divisor}";
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

                Result = (dividendo / divisor).ToString();
            }
            else if (dividendo == Modulo)
            {
                dividendo *= signo;
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
                        Etiqueta = Proceso.DescorcharA(Etiqueta);

                        CocienteEntero Interino = new CocienteEntero(Etiqueta);
                        string Res = Proceso.DescorcharA(Interino.Result);
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
                            Acomulador = Proceso.DescorcharA(Contenido);

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
                            Dividendo = Proceso.DescorcharA(Acomulador.Substring(0, i));
                            Divisor = Proceso.DescorcharA(Acomulador.Substring(i + 1));
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

            int i, j, k, Izq, Der, Uno, Dos;
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
                //Operador = Contenedor.Substring(inicio, (j - inicio)); ANTIGUAS SENTENCIAS TAL VEZ OCASIONABAN DESBORDAMIENTOS

                //COLOCADO PARA EVITAR EL DESBORDAMIENTO
                if ((inicio + (j - inicio)) < Contenedor.Length)
                    Operador = Contenedor.Substring(inicio, (j - inicio) + 1); //HABILITADO POR EL ERROR DE ABAJO
                else
                    Operador = Contenedor.Substring(inicio, (j - inicio)); //OMITIA EL ULTIMO PARENTESIS SI HA DE LLEVARLO

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

                    if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                        --i;
                    else //ACABADO DE COLOCAR PARA PRUEBAS
                        break;
                }

                //AGREGADO EL NO SEGUIR
                if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                    ++i;

                //Operador = Contenedor.Substring(i, final + 1);
                Operador = Contenedor.Substring(i, (final - i) + 1);
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

                    //Operador = Contenedor.Substring(inicio, (j - inicio)); ANTIGUA SENTENCIA TAL VEZ PODRIA OCASIONAR DESBORDAMIENTOS

                    //COLOCADO PARA EVITAR EL DESBORDAMIENTO
                    if ((inicio + (j - inicio)) < Contenedor.Length)
                        Operador = Contenedor.Substring(inicio, (j - inicio) + 1); //HABILITADO POR EL ERROR DE ABAJO
                    else
                        Operador = Contenedor.Substring(inicio, (j - inicio)); //OMITIA EL ULTIMO PARENTESIS SI HA DE LLEVARLO

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
                        if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                            --i;
                        else //ACABADO DE COLOCAR PARA PRUEBAS
                            break;
                    }

                    //AGREGADO EL NO SEGUIR
                    if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                        ++i;

                    //Operador = Contenedor.Substring(i, final + 1);
                    Operador = Contenedor.Substring(i, (final - i) + 1);
                    Operacion = Operador + Simbolo + Contenido;
                    dividendo = new CocienteEntero(Operador);

                }

                Resuelto = PropiedadDistributiva(dividendo, divisor).Result;
                Resuelto = Proceso.DescorcharA(Resuelto);//ACABADO DE COLOCAR PARA INICIAR PRUEBAS
                return Contenedor.Replace(Operacion, Resuelto);
            }
        }
    } //FUNCIONANDO 100%

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
        public List<Variables> ListaVariables = new List<Variables>();
        private Variables variable = new Variables();
        double number;

        private ProductoEntero Producto = new ProductoEntero();

        public PotenciaEntera() { }

        //CREAR FUNCION ISENCORCHABLE EN EPROCESOS Y APLICAR AQUI A CONTENIDOS
        public PotenciaEntera(string Base, string Exponente)
        {
            this.Base = Base;
            this.Exponente = Exponente;
            Contenido = Base + Simbolo + Exponente;
            Operar();
        }

        public PotenciaEntera(string Expresion)
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

        public override void Operar()
        {
            bool A, B, C, D, E, F;

            A = double.TryParse(Base, out number);
            B = double.TryParse(Exponente, out number);
            C = Base.Equals($"{Modulo}");
            D = Base.Equals($"{ModuloCancelativo}");
            E = Exponente.Equals($"{Modulo}");
            F = Exponente.Equals($"{ModuloCancelativo}");

            Base = Proceso.DescorcharA(Base);
            Exponente = Proceso.DescorcharA(Exponente);

            if (F & D)
                Result = $"Math ERROR in {Nombre} with {Contenido}";
            else if (F)
                Result = $"{Modulo}";
            else if (D)
                Result = $"{ModuloCancelativo}";
            else if (C)
                Result = $"{Modulo}";
            else if (E)
                Result = Base;
            else if (A & B)
                Result = $"{ Math.Pow(double.Parse(Base), double.Parse(Exponente)) }";
            else
            {
                string Bas = Base.Replace($"{variable.Simbolo}", "");
                string Exp = Exponente.Replace($"{variable.Simbolo}", "");

                A = (Bas.Length > 2);
                B = (Exp.Length > 2);

                if (A & B)
                {
                    Result = $"{Op}{Op}{Base}{Cl}{Simbolo}{Op}{Exponente}{Cl}{Cl}";
                }
                else if (A)
                {
                    //Result = $"{Op}{Op}{Base}{Cl}{Simbolo}{Exponente}{Cl}";
                    Result = $"{Op}{Base}{Cl}{Simbolo}{Exponente}";
                }
                else if (B)
                {
                    //Result = $"{Op}{Base}{Simbolo}{Op}{Exponente}{Cl}{Cl}";
                    Result = $"{Base}{Simbolo}{Op}{Exponente}{Cl}";
                }
                else
                    Result = $"{Base}{Simbolo}{Exponente}";
            }
        }

        public override void ObtenerElementos(string LElementos)
        {
            int i = 0, NumeroImplicitoDeOps = 0;

            foreach (var elemento in LElementos)
            {
                if (elemento.Equals(Simbolo))
                    ++NumeroImplicitoDeOps;
            }

            if (NumeroImplicitoDeOps == 0)
            {
                Base = LElementos;
                Exponente = $"{Modulo}";
            }
            else if (NumeroImplicitoDeOps == 1)
            {
                i = 0;
                foreach (var elemento in LElementos.Split(Simbolo))
                {
                    if (i == 0)
                        Base = elemento;
                    else if (i == 1)
                        Exponente = elemento;
                    ++i;
                }
            }
            else
            {
                ResolverNiveles();
            }
        }

        public override void ResolverNiveles()
        {
            string Temporal = Contenido;

            string Niveles = ObtenerNiveles(Temporal);
            string NivelesCop = Niveles;

            string Orden = ObtenerOrden(Niveles);
            string OrdenCop = Orden;

            int i, j, k, q = 0, Izq, Der, Uno, Dos;
            bool A = true, B = true, WUno = true, WDos = true;

            Uno = 0;
            while (WUno)
            {
                var orden = Orden.ElementAt(Uno);
                k = 0; Dos = 0;

                while (WDos)
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
                        string Nom = $"U{q}";
                        //PROBLEMA DE RECURSIVIDAD INFINITA SI LA ETIQUETA ES IGUAL A LA FUNCION
                        //DEBE SER UN DERIVADO DE LA FUNCION A RESOLVER
                        //HACER QUE LA ETIQUETA QUEDE LIBRE DE AGRUPACIONES INNECESARIAS
                        string Etiqueta = $"{Temporal.Substring(i, (j - i) + 1)}";
                        Temporal = Temporal.Replace(Etiqueta, $"{variable.Simbolo}{Nom}");
                        Etiqueta = Proceso.DescorcharA(Etiqueta);

                        PotenciaEntera Interino = new PotenciaEntera(Etiqueta);
                        string Res = Proceso.DescorcharA(Interino.Result);
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
                while (Acomulador.Contains(variable.Simbolo))
                {

                    Nomb = $"{variable.Simbolo}{LVariables.ElementAt(i).Nombre}";
                    Conten = (string)LVariables.ElementAt(i).Contenido;
                    //ENCORCHAR EL CONTENIDO SI ES NECESARIO;

                    A = (Conten.Length > 2);
                    B = Proceso.IsAgrupate(Conten);

                    if (A & !B)
                    {
                        Conten = Proceso.EncorcharFuncion(Conten);
                    }

                    Acomulador = Acomulador.Replace(Nomb, Conten);
                    ++i;
                }
            }

            //APLICA PRODUCTO ENTRE EXONENTES ANIDADOS
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
                            Acomulador = Proceso.DescorcharA(Contenido);

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
                            Base = Proceso.DescorcharA(Acomulador.Substring(0, i));
                            Exponente = Proceso.DescorcharA(Acomulador.Substring(i + 1));
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

            int i, j, k, Izq, Der, Uno, Dos;
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

        public PotenciaEntera PropiedadDistributiva(PotenciaEntera Base, string ExponenteSuperior)
        {
            Producto = new ProductoEntero(Base.Exponente, ExponenteSuperior);
            string ProductoExponente = Producto.Result;

            Producto = new ProductoEntero();

            return new PotenciaEntera(Base.Base, ProductoExponente);

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
            PotenciaEntera thisBase = new PotenciaEntera();
            string thisExponente = "";
            int i = 0, j = 0; bool seguir = true;
            i = Contenedor.IndexOf(Contenido);
            j = (i) + (Contenido.Length - 1);

            string Resuelto = "";
            string Operador = "";
            string Operacion = "";

            if (Contenedor.StartsWith(Contenido))
            {
                thisBase = new PotenciaEntera(Contenido);
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
                Operador = Proceso.DescorcharA(Operador);
                thisExponente = Operador;

                Resuelto = PropiedadDistributiva(thisBase, thisExponente).Result;
                return Contenedor.Replace(Operacion, Resuelto);
            }

            else if (Contenedor.EndsWith(Contenido))
            {
                thisExponente = Contenido;
                i = i - 2;
                int final = i;
                while (i >= 0 & seguir)
                {
                    if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1)
                    {
                        seguir = false;
                    }
                    if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                        --i;
                    else //ACABADO DE COLOCAR PARA PRUEBAS
                        break;
                }

                //AGREGADO EL NO SEGUIR
                if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                    ++i;

                //Operador = Contenedor.Substring(i, final + 1);
                Operador = Contenedor.Substring(i, (final - i) + 1);
                Operacion = Operador + Simbolo + Contenido;
                thisBase = new PotenciaEntera(Operador);

                Resuelto = PropiedadDistributiva(thisBase, thisExponente).Result;
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
                    thisBase = new PotenciaEntera(Contenido);
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
                    Operador = Proceso.DescorcharA(Operador);
                    thisExponente = Operador;

                }
                else if (B)
                {
                    --i;
                    thisExponente = Contenido;
                    int final = i;
                    while (i >= 0 & seguir)
                    {
                        if (Proceso.IsLlave(Contenedor.ElementAt(i)) == 1)
                        {
                            seguir = false;
                        }
                        if (i > 0) //ACABADOD DE COLOCAR PARA PRUEBAS
                            --i;
                        else //ACABADO DE COLOCAR PARA PRUEBAS
                            break;
                    }

                    //AGREGADO EL NO SEGUIR
                    if (Proceso.IsLlave(Contenedor.ElementAt(final)) == 0 & !seguir)
                        ++i;

                    //Operador = Contenedor.Substring(i, final + 1);
                    Operador = Contenedor.Substring(i, (final - i) + 1);
                    Operacion = Operador + Simbolo + Contenido;
                    thisBase = new PotenciaEntera(Operador);

                }

                Resuelto = PropiedadDistributiva(thisBase, thisExponente).Result;
                return Contenedor.Replace(Operacion, Resuelto);
            }
        }
    } //FUNCIONANDO 100%
}
