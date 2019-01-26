using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Signos
    {
        public string SignoPositivo { get { return "+";} }
        public string SignoNegativo { get { return "-";} }
        private string OperadorUno;
        private string OperadorDos;
        public string SignoUno { get; private set; }
        public string SignoDos { get; private set; }

        public Signos () { }
        public Signos (string OperadorUno)
        {
            this.OperadorUno = OperadorUno;
            SignoUno = ExtraerSigno(OperadorUno);
        }
        public Signos (string OperadorUno, string OperadorDos)
        {
            this.OperadorUno = OperadorUno;
            this.OperadorDos = OperadorDos;

            SignoUno = ExtraerSigno(OperadorUno);
            SignoDos = ExtraerSigno(OperadorDos);

        }

        private string ExtraerSigno(string Operador)
        {
            if (Operador.StartsWith("-"))
            {
                return SignoNegativo;
            }
            return SignoPositivo;
        }
    }
}
