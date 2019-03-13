using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using GRAMATICA;

namespace ALGEBRA
{
    public class Monomios : AMathExp
    {
        public override string Nombre => "MONOMIO";
        public string Coeficiente { get; private set; }
        public string ParteLiteral { get; private set; }

        public List<PotenciaEntera> Elementos = new List<PotenciaEntera>();
        PotenciaEntera Potencia;
        double number;


        public Monomios()
        {
            Operacion = new ProductoEntero();
        }

        public Monomios(string Coeficiente, string Literal)
        {
            if (Proceso.IsAgrupate(Coeficiente))
                Coeficiente = Proceso.DescorcharA(Coeficiente);

            if (Proceso.IsAgrupate(Literal))
                Literal = Proceso.DescorcharA(Literal);

            Operacion = new ProductoEntero();
            Contenido = new ProductoEntero(Coeficiente, Literal).Result;

            ObtenerElementos(Contenido);
        }

        public Monomios(string Expresion)
        {
            Operacion = new ProductoEntero();

            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            Contenido = Expresion;

            Niveles = ObtenerNiveles(Contenido);
            Orden = ObtenerOrden(Niveles);
            ObtenerElementos(Contenido);
        }

        protected override void ObtenerElementos (string Expresion)
        {
            Elementos.Clear();

            //TENER EN CUENTA CUANDO NIVELES ES VACIO, ESTA SENTENCIA IF PARECE SOLUCIONARLO
            if (!Niveles.Contains("0"))
                Result = Contenido;
            else
            {
                char FirstNivel = Orden.ElementAt(Orden.Length - 1);
                string Foco;
                int Inicio, i, j, k;
                i = 0; Inicio = 0;
                bool Seguir;

                foreach (var nivel in Niveles)
                {
                    ++i;
                    Seguir = true;
                    if (nivel.Equals(FirstNivel))
                    {
                        j = 0; k = 0;
                        while (Seguir)
                        {
                            if (Contenido.ElementAt(k).Equals(Simbolo))
                                ++j;

                            if (j == i)
                                Seguir = false;
                            else
                                ++k;
                        }

                        Foco = Contenido.Substring(Inicio, (k - Inicio));
                        Inicio = k + 1;

                        Potencia = new PotenciaEntera(Foco);
                        Elementos.Add(Potencia);

                    }

                }

                //TOMA EL ULTIMO ELEMENTO
                Foco = Contenido.Substring(Inicio);
                Potencia = new PotenciaEntera(Foco);
                Elementos.Add(Potencia);
                //FIN DE TOMA

                ObtenerPartes();
                //PULIR PRODUCTO PARA RESPONDER CORRECTAMENTE A ESTE PROBLEMA
                Operacion = new ProductoEntero(Coeficiente, ParteLiteral);
                Result = Operacion.Result;
            }
        }

        private void ObtenerPartes()
        {
            bool A; Coeficiente = $"{Operacion.Modulo}"; ParteLiteral = "";
            List<PotenciaEntera> Temporal = new List<PotenciaEntera>();
            Proceso.CopyList(Temporal, Elementos);

            foreach (var elemento in Temporal)
            {
                A = double.TryParse(elemento.Result, out number);

                //PULIR BIEN PRODUCTO PARAR RESPONDER CORRECTAMENTE
                if (A)
                {
                    Coeficiente = new ProductoEntero(Coeficiente, elemento.Result).Result;
                    Elementos.Remove(elemento);
                }
                else
                {
                    ParteLiteral += $"{elemento.Result}{Simbolo}";
                }

            }

            Elementos.Add(new PotenciaEntera(Coeficiente));
            ParteLiteral = new ProductoEntero(ParteLiteral.Trim(Simbolo)).Result;
        }

    } //FUNCIONANDO 100%

}
