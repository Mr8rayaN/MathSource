﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace ALGEBRA
{
    public class Polinomios
    {
        public string Nombre => "POLINOMIO";
        public string Contenido { get; private set; }
        public string Result { get; private set; }
        public double GradoAbs { get; private set; }
        public char Simbolo => ObteneSimbolo();
        public List<Monomios> Elementos = new List<Monomios>();
        Monomios Monomio;
        SumaEntera Suma = new SumaEntera();

        EProcesos Proceso = new EProcesos();

        public Polinomios() { }

        public Polinomios(string Expresion)
        {
            if (Proceso.IsAgrupate(Expresion))
                Expresion = Proceso.DescorcharA(Expresion);

            ObtenerElementos(Expresion);

            Operar();
        }

        private void ObtenerElementos(string Expresion)
        {
            GradoAbs = 0;
            Elementos.Clear();
            Contenido = "";
            Suma = new SumaEntera(Expresion);

            Contenido = Suma.Result;
            Contenido = Proceso.ParentesisClear(Contenido);


            foreach (var elemento in Contenido.Split(Suma.Simbolo))
            {
                Monomio = new Monomios(elemento);

                if (!Monomio.Result.Equals($"{0}"))
                {
                    Elementos.Add(Monomio);
                    GradoAbs += Monomio.GradoAbs;
                }

            }

            Contenido = Contenido.Trim(Suma.Simbolo);

        }

        private void Operar()
        {
            Result = "";
            string Temporal;
            bool A;

            A = Elementos.Count < 1;

            if (A)
                Result = $"{Suma.Modulo}";
            else
            {
                foreach (var M in Elementos)
                {
                    Temporal = M.Result;
                    //A = Temporal.Length > 3;

                    /*if (A)
                    {
                        Temporal = Proceso.EncorcharParentesis(Temporal);
                    }*/

                    Result += Suma.Simbolo + Temporal;
                }

                Result = Result.Trim(Suma.Simbolo);
            }
        }

        private char ObteneSimbolo()
        {
            return Suma.Simbolo;
        }

    }

}
