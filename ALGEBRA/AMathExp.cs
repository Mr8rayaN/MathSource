using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTITY;
using System.Threading.Tasks;

namespace ALGEBRA
{
    public abstract class AMathExp
    {
        public virtual string Nombre { get; }
        public string Contenido { get; protected set; }
        public double GradoAbs { get; protected set; }
        public string Result { get; protected set; }
        protected string Niveles { get; set; }
        protected string Orden { get; set; }
        public char Simbolo => ObteneSimbolo();

        protected AMathOps Operacion { get; set; }
        protected EProcesos Proceso = new EProcesos();

        protected virtual void ObtenerElementos() { }

        protected string ObtenerNiveles(string Expresion)
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

        protected string ObtenerOrden(string Niveles)
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

        protected virtual char ObteneSimbolo() {
            return Operacion.Simbolo;
        }

        public override string ToString()
        {
            return $"{Nombre} {Contenido}";
        }

    }
}
