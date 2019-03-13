using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public class Polinomios : AMathExp
    {
        public override string Nombre => "POLINOMIO";

        public List<Monomios> Elementos = new List<Monomios>();
        Monomios Monomio;
        
        public Polinomios()
        {
            Operacion = new SumaEntera();
        }

        public Polinomios(string Expresion)
        {
            Operacion = new SumaEntera();

            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            Contenido = Expresion;

            Niveles = ObtenerNiveles(Contenido);
            Orden = ObtenerOrden(Niveles);
            ObtenerElementos(Contenido);

        }

        protected override void ObtenerElementos(string Expresion)
        {
            Elementos.Clear();

            //TENER EN CUENTA CUANDO NIVELES ES VACIO, ESTA SENTENCIA IF PARECE SOLUCIONARLO
            if (!Niveles.Contains("0"))
                Result = Contenido;
            else
            {
                Elementos.Clear();
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

                        Monomio = new Monomios(Foco);
                        Elementos.Add(Monomio);

                    }

                }

                //TOMA EL ULTIMO ELEMENTO
                Foco = Contenido.Substring(Inicio);
                Monomio = new Monomios(Foco);
                Elementos.Add(Monomio);
                //FIN DE TOMA

                ObtenerResultado();
            }
        }

        private void ObtenerResultado()
        {
            string Temp = "";
            foreach (var item in Elementos)
            {
                Temp += $"{item.Result}{Simbolo}";
            }

            Result = Temp.Trim(Simbolo);
        }

    }

}
