using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class AMathOps : Signos , IOpsMetodos
    {
        public virtual int Modulo { get;}
        public virtual string Nombre { get; }
        public virtual char Simbolo { get; }
        public virtual char Op { get; }
        public virtual char Cl { get; }
        public string Contenido { get; protected set; }
        public string Result { get; protected set; }
        public int NumeroElementos { get; protected set; }
        public List<string> Elementos = new List<string>();
        protected EProcesos Proceso = new EProcesos();
        protected NumerosEnteros NumEntero = new NumerosEnteros();

        public virtual void Operar()
        {

        }

        public virtual void ObtenerElementos(string LElementos)
        {
        }

        public string ObtenerNiveles(string Expresion)
        {
            string Nivel = "";
            int Acomulador, i, j, k, Izq, Der;
            bool A, B;
            A = B = true;
            Acomulador = i = j = k = Izq = Der = 0;

            foreach (var elemento in Expresion)
            {
                if (elemento.Equals(Simbolo))
                {
                    i = j = k;
                    Izq = Der = 0;
                    A = B = true;

                    while (A || B)
                    {
                        if (A)
                        {
                            //CUERPO
                            Izq += Proceso.IsLlave(Expresion.ElementAt(i));
                            //FINCUERPO
                            if (i <= 0)
                                A = false;
                            --i;
                        }
                        if (B)
                        {
                            //CUERPO
                            Der += Proceso.IsLlave(Expresion.ElementAt(j));
                            //FINCUERPO
                            if (j >= Expresion.Length - 1)
                                B = false;
                            ++j;
                        }
                    }

                    //MANIPULAR LA CANTIDAD DE PARENTESIS Y APLICAR RESULTADOS

                    //A = true;
                    //i = 0;
                    Nivel += Izq;

                }

                ++k;
            }

            return Nivel;
        }

        public string ObtenerOrden(string Niveles)
        {
            int i = 0, Acomulador = 0; bool A = false; string NivelOrden = "";
            foreach (var nivel in Niveles)
            {
                i = 0; A = true;

                if (!NivelOrden.Contains(nivel))
                {
                    if (NivelOrden.Equals(""))
                        NivelOrden += nivel;
                    else
                    {
                        while (A)
                        {
                            if (i < NivelOrden.Length)
                                Acomulador = int.Parse($"{NivelOrden.ElementAt(i)}");
                            else
                                Acomulador = -1;

                            if (Acomulador > int.Parse($"{nivel}"))
                                ++i;
                            else
                            {
                                if (i < NivelOrden.Length)
                                    NivelOrden = NivelOrden.Insert(i, $"{nivel}");
                                else
                                    NivelOrden += nivel;

                                A = false;
                            }

                        }
                    }
                }
            }

            return NivelOrden;
        }

        //Sobreescribir en el hijo
        public virtual void ResolverNiveles() { }

        //Sobreescribir en el hijo
        public virtual void ResolverVariables(List<Variables> LVariables, string Niveles, string Orden) { }

        public override string ToString()
        {
            return $"{Nombre} ({Contenido})";
        }
    }
}
