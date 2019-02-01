using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Signos
    {
        public string SignoPositivo { get { return "+";} }
        public string SignoNegativo { get { return "-";} }
        private string OperadorUno;
        private string OperadorDos;
        public string SignoUno { get; private set; }
        public string SignoDos { get; private set; }

        

        public void AgregarOperador(string Monomio)
        {
            OperadorUno = Monomio;
            SignoUno = ExtraerSigno(OperadorUno);
        }

        public void AgregarOperadores(string MonomioUno, string MonomioDos)
        {
            OperadorUno = MonomioUno;
            OperadorDos = MonomioDos;
            SignoUno = ExtraerSigno(MonomioUno);
            SignoDos = ExtraerSigno(MonomioDos);

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
