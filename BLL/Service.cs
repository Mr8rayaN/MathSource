using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;
using ALGEBRA;
using Oracle.ManagedDataAccess.Client;

namespace BLL
{
    public class Service
    {
        string CadenaConexion;
        private OracleConnection Conexion;
        private BDRespository DAL;
        public string Respuesta { get; set; }
        string Entrada { get; set; }
        string Salida { get; set; }
        string Funcion_id { get; set; }
        string Resultado_id { get; set; }
        int Cantidad { get; set; }
        Variables Var { get; set; }
        Pasos Paso { get; set; }
        Polinomios Polinomio { get; set; }
        List<Variables> LVariables { get; set; }
        List<Estados> LEstados { get; set; }
        List<Funciones> LFunciones { get; set; }
        List<Resultados> LResultados { get; set; }
        List<Pasos> LPasos;

        public Service()
        {
            CadenaConexion = "Data Source=localhost:1521/xe;user Id=brayan;Password=0608";
            Conexion = new OracleConnection(CadenaConexion);
            DAL = new BDRespository(Conexion);
        }

        //METODOS DE MANEJO DE BASE DE DATOS

        public string GuardarFuncion(Funciones F)
        {
            try
            {
                Conexion.Open();
                Respuesta = DAL.GuardarFuncion(F);
                Conexion.Close();
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }

            return Respuesta;
        }

        public string GuardarResultado(Resultados R)
        {
            try
            {
                Conexion.Open();
                Respuesta = DAL.GuardarResultado(R);
                Conexion.Close();
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }

            return Respuesta;
        }

        public string GuardarPasos(List<Pasos> LPasos)
        {
            Respuesta = "";
            try
            {
                Conexion.Open();
                foreach (var paso in LPasos)
                {
                    //AQUI SE GENERAN LOS PASO_ID
                    paso.Id = ProximoPaso();
                    Respuesta += DAL.GuardarPaso(paso);
                }
                
                Conexion.Close();
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }

            return Respuesta;
        }

        public string ProximoPaso()
        {
            bool A = false;
            try
            {
                if(Conexion.State != System.Data.ConnectionState.Open)
                {
                    A = true;
                    Conexion.Open();
                }
                    
                //AQUI SE GENERAN LOS PASO_ID
                Cantidad = DAL.CantidadPasos();
                //CREAR PASO_ID
                Respuesta = $"P{Cantidad + 1}";

                if(A)
                    Conexion.Close();

            }
            catch (Exception)
            {
                Respuesta = $"Error al abrir la conexion";
            }

            return Respuesta;
        }

        public string ProximaFuncion()
        {
            try
            {
                Conexion.Open();
                //AQUI SE GENERAN LOS PASO_ID
                Cantidad = DAL.CantidadFunciones();
                //CREAR PASO_ID
                Respuesta = $"F{Cantidad + 1}";
                Conexion.Close();
            }
            catch (Exception)
            {
                Respuesta = $"Error al abrir la conexion";
            }

            return Respuesta;
        }

        public string ProximoResultado()
        {
            try
            {
                Conexion.Open();
                //AQUI SE GENERAN LOS PASO_ID
                Cantidad = DAL.CantidadResultados();
                //CREAR PASO_ID
                Respuesta = $"R{Cantidad + 1}";
                Conexion.Close();
            }
            catch (Exception)
            {
                Respuesta = $"Error al abrir la conexion";
            }

            return Respuesta;
        }

        public List<Estados> ConsultarEstados()
        {
            Conexion.Open();
            LEstados = DAL.ConsultarEstados();
            Conexion.Close();
            return LEstados;
        }

        public List<Funciones> ConsultarFunciones()
        {
            Conexion.Open();
            LFunciones = DAL.ConsultarFunciones();
            Conexion.Close();

            return LFunciones;
        }

        public List<Resultados> ConsultarResultados()
        {
            Conexion.Open();
            LResultados = DAL.ConsultarResultados();
            Conexion.Close();

            return LResultados;
        }

        public List<Pasos> ConsultarPasos()
        {
            Conexion.Open();
            LPasos = DAL.ConsultarPasos();
            Conexion.Close();

            return LPasos;
        }

        //FIN MANEJO DE DATOS

        public string Procesar(string Expresion, string Operacion)
        {
            //IDENTIFICAR OPERACIONES A REALIZAR E IR ALMACENANDO PASOS (CUANDO AL INGRESAR POR UNA FUNCION RETORNE ALGO DIFERENTE AL INCICIAL
            Funcion_id = DAL.SiguienteFuncion();
            LPasos = new List<Pasos>();
            Entrada = Expresion;
            Polinomio = new Polinomios(Entrada);
            RegistrarPaso(Entrada, Polinomio.Result, Polinomio.Nombre);
            return null;
        }

        private void CrearFuncion(string Funcion_id)
        {

        }

        private void CrearResultado(string Resultado_id)
        {

        }

        private void RegistrarPaso(string Pre, string Post, string Nombre)
        {
            //OPTIMIZAR ESTE FILTRO, SEDE DEMASIADO ANTE CUALQUIER CAMBIO PEQUEÑO
            if (!Pre.Equals(Post))
            {
                //CREAR PASO Y AGREGARLO A LA LISTA
                Paso = new Pasos(Pre, Post, Nombre);
                Paso.Id = "ID GENERADO DE SIGUIENTE PASO";
                Paso.Id_Funcion = "ID GENERADO DE LA FUNCION ACTUAL";
                Paso.Id_Resultado = "ID GENERADO QUE RELACION ESTE PASO CON EL RESULTADO";
            }
        }

        private void ObtenerVariable()
        {

        }

        private string CoordenadasResultantes(Polinomios Polinomio, Variables Var)
        {
            return null;
        }

    }
}
