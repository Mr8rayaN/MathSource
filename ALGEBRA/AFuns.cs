using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public abstract class AFuns
    {
        public virtual string Nombre { get;}
        public virtual string Simbolo { get;}
        public virtual string Coeficiente { get; set; }
        public virtual string Foco { get; set; }
        public virtual string SimboloExtendido { get; }
        public virtual string Contenido { get; protected set; }
        public virtual string Argumento { get; protected set; }
        public virtual char Op { get; }
        public virtual char Cl { get; }
        public string Result { get; protected set; }

        protected EProcesos Proceso = new EProcesos();

        public void SetArgumento(string Argumento)
        {
            if (Proceso.IsAgrupate(Argumento))
                Argumento = Proceso.DescorcharA(Argumento);

            Contenido = Contenido.Replace(this.Argumento, Argumento);
            this.Argumento = Argumento;
            Foco = SimboloExtendido + Argumento + Cl;
            ObtenerCoeficiente();
            Operar();
        }

        public void SetCoeficiente(string Coeficiente)
        {
            if (Proceso.IsAgrupate(Coeficiente))
                Coeficiente = Proceso.DescorcharA(Coeficiente);

            if (Coeficiente.Equals("1"))
            {
                Contenido = new ProductoEntero(Coeficiente, Contenido).Result;
            }
            else
                Contenido = Contenido.Replace(this.Coeficiente, Coeficiente);

            this.Coeficiente = Coeficiente;
            Foco = SimboloExtendido + Argumento + Cl;
            Operar();
        }

        protected virtual void ObtenerCoeficiente() { }

        protected virtual void ObtenerArgumento() { }

        protected virtual void Operar() { }

        public virtual bool ContainsThisFuntion(Monomios Monomio)
        {
            foreach (var elemento in Monomio.Elementos)
            {
                if (elemento.Result.Contains(SimboloExtendido))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $" {Nombre} {Contenido} ";
        }
    }
}
