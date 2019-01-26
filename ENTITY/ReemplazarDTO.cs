using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ReemplazarDTO
    {
        private string FuncionContenedora;
        public string AReemplazar;
        public string Reemplazador;
        public int StartIndexAReemplazar;
        public string Reemplazado => Reemplazar();

        public ReemplazarDTO(string FuncionContenedora)
        {
            this.FuncionContenedora = FuncionContenedora;
        }

        private string Reemplazar()
        {
            int LengthReemplazar = AReemplazar.Length;
            string Pre;
            string Post;

            Pre = FuncionContenedora.Substring(0, StartIndexAReemplazar);
            Post = FuncionContenedora.Substring(LengthReemplazar);

            FuncionContenedora = Pre + Reemplazador + Post;

            return FuncionContenedora;
        }
    }
}
