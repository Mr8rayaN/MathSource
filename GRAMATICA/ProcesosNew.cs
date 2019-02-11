using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace GRAMATICA
{
    public class ProcesosNew
    {
        private bool A, B;
        public string Result { get; set; }
        int IndiceUno, IndiceDos;
        private char Abrir { get; set; }
        private char Cerrar { get; set; }

        public ProcesosNew()
        {
            Abrir = '(';
            Cerrar = ')';
        }

        public ProcesosNew(char SignoAbrir, char SignoCerrar)
        {
            Abrir = SignoAbrir;
            Cerrar = SignoCerrar;
        }

        //Retorna el tamaño desde el origen hasta el fin de la expresion o argumento
        public int FinAgrupacion(string Expresion, int startIndex)
        {

            if (startIndex < 0)
            {
                return Expresion.Length;
            }

            bool seguir = true;
            int final, abierto, cerrado, i;

            final = abierto = cerrado = i = 0;

            Expresion = Expresion.Substring(startIndex);
            char[] caracter = Expresion.ToCharArray();

            while (seguir)
            {
                if (caracter[i] == Abrir)
                    ++abierto;

                if (caracter[i] == Cerrar)
                    --abierto;

                if (abierto == 0)
                    seguir = false;

                ++i;
            }

            return i;

        }

        //Retorna el indice desde donde comienza el argumento o agrupacion
        public int InicioAgrupacion(string Expresion, int EndIndex)
        {
            bool seguir = true;
            int final, abierto, cerrado, i;

            final = abierto = cerrado = i = 0;

            Expresion = Expresion.Substring(0, EndIndex + 1);
            char[] caracter = Expresion.ToCharArray();
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

        //Elimina el simbolo que esté agrupando una expresión
        public string Descorchar(string Expresion)
        {
            IndiceUno = Expresion.LastIndexOf(Cerrar);
            IndiceDos = FinAgrupacion(Expresion, Expresion.IndexOf(Abrir)) - 1;

            A = Expresion.StartsWith(Abrir.ToString());
            B = IndiceUno.Equals(IndiceDos);

            if (A & B)
            {
                Result = Expresion.Substring(1, Expresion.LastIndexOf(Cerrar) - 1);
                return Result;
            }

            return Expresion;
        }
    }
}
