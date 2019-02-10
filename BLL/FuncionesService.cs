using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DERIVADAS;
using DAL;
using ALGEBRA;
using ENTITY;

namespace BLL
{
    public class FuncionesService
    {
        Derivada derivada = new Derivada();
        DerivadaParcial derivadaParcial = new DerivadaParcial();
        public ProcesosOld proceso = new ProcesosOld();
        PropsMatematicas propiedad = new PropsMatematicas();

        FuncionesRepository gestion = new FuncionesRepository();

        public string Derivar (string laFuncion, string laVariable)
        {
            laFuncion = laFuncion.ToLower();
            laVariable = laVariable.ToLower();

            if (laFuncion == null || laFuncion.Equals("")) return "La derivada de nada es nada ;)";
            if (laVariable == null || laVariable.Equals("")) laVariable = "x";
            if (!laFuncion.Contains(laVariable)) return "0";

            return derivada.Derivar( laFuncion , laVariable );
        }

        public List<string> DerivadaParcial (string funcion)
        {
            return derivadaParcial.Derivar(funcion);
        }

        public bool IsParcial(string funcion)
        {
            return derivadaParcial.IsParcial(funcion);
        }
    }
}
