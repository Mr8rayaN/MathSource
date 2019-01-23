using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DERIVADAS
{
    public class DerivadaParcial 
    {

        Derivada derivada = new Derivada();

        public List<string> Variables;

        public List<string> Derivar(string funcion)
        {

            List<string> Funciones = new List<string>();
            Variables = derivada.proceso.ExtraerVariables(funcion);

            if (Variables.Count == 0 || Variables == null) return null;

            foreach (var variable in Variables)
            {
                Funciones.Add(variable + ";" + derivada.Derivar(funcion, variable));
            }

            return Funciones;
        }

        public bool IsParcial(string funcion)
        {
            if (funcion == null || funcion.Equals("")) return false;

            funcion = derivada.proceso.Limpiar(funcion);

            int i = 0, j = 0;
            char[] caracter = funcion.ToCharArray();

            while (i < caracter.LongLength)
            {
                if (double.TryParse(caracter[i].ToString(), out double number))
                    funcion = funcion.Replace(caracter[i].ToString(), "");
                else
                {
                    j++;
                }
                i++;
            }

            if (j > 1) return true;
            return false;
        }

    }
}
