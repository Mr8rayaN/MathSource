using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;
using ALGEBRA;
using DERIVADAS;
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
        string Estado = "EST01";
        int Cantidad { get; set; }
        public string VariablePorDefecto => "x";

        AMathOps Op { get; set;  }
        Derivadas Derivada { get; set; }
        Variables Var { get; set; }
        Pasos Paso { get; set; }
        Funciones Funcion { get; set; }
        public Resultados Resultado { get; set; }
        Polinomios Polinomio { get; set; }
        List<Variables> LVariables { get; set; }
        List<Estados> LEstados { get; set; }
        List<Funciones> LFunciones { get; set; }
        List<Resultados> LResultados { get; set; }
        public List<Pasos> LPasos = new List<Pasos>();

        EProcesos Proceso = new EProcesos();

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
                    paso.SetId(ProximoPaso());
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

        public string Procesar(string Expresion, string NombreVariable,string Operacion)
        {
            //IDENTIFICAR OPERACIONES A REALIZAR E IR ALMACENANDO PASOS (CUANDO AL INGRESAR POR UNA FUNCION RETORNE ALGO DIFERENTE AL INCICIAL
            Variables Var = new Variables(NombreVariable);
            Conexion.Open();
            Funcion_id = DAL.SiguienteFuncion();
            Resultado_id = DAL.SiguienteResultado();
            Conexion.Close();

            LPasos = new List<Pasos>();
            Entrada = Expresion;
            Polinomio = new Polinomios(Entrada);
            CrearFuncion(Funcion_id, Polinomio.Nombre, Expresion);

            RegistrarPaso(Entrada, Polinomio.Result, Polinomio.Nombre);

            if (Operacion.Contains("Der"))
            {
                Derivada = new Derivadas(Polinomio, Var);

                RegistrarPaso(Polinomio.Result, Derivada.Result, Derivada.Nombre);

                Salida = Derivada.Result;
                CrearResultado(Resultado_id, Derivada.Nombre, Derivada.Result, Estado);
                //SE DEFINE EL RESULTADO
            }
            else if (Operacion.Contains("Simp"))
            {
                string Temp = "";
                foreach (var mono in Polinomio.Elementos)
                {
                    Op = new ProductoEntero(mono.Result);
                    if (!Op.Result.Equals(mono.Result))
                    {
                        CrearResultado(Resultado_id, Op.Nombre, Op.Result, Estado);

                        RegistrarPaso(mono.Result, Op.Result, Op.Nombre);
                    }
                    Temp = Op.Result;

                    Op = new PotenciaEntera(Op.Result);
                    if (!Op.Equals(Temp))
                    {
                        CrearResultado(Resultado_id, Op.Nombre, Op.Result, Estado);

                        RegistrarPaso(mono.Result, Op.Result, Op.Nombre);
                    }
                    Temp = Op.Result;

                    Op = new CocienteEntero(Op.Result);
                    if (!Op.Equals(Temp))
                    {
                        CrearResultado(Resultado_id, Op.Nombre, Op.Result, Estado);

                        RegistrarPaso(mono.Result, Op.Result, Op.Nombre);
                    }
                    Temp = "";
                }
                //SE DEFINE EL RESULTADO
            }

            //LISTOS ELEMENTOS NECESARIOS PARA GUARDAR REGISTROS
            return Resultado.Contenido;
        }

        private void CrearFuncion(string Funcion_id, string Nombre, string Contenido)
        {
            Funcion = new Funciones(Funcion_id, Nombre, Contenido);
        }

        private void CrearResultado(string Resultado_id, string Nombre, string Contenido, string Estado)
        {
            Resultado = new Resultados(Resultado_id, Nombre, Contenido);
            Resultado.SetEstado(Estado);
        }

        private void RegistrarPaso(string Pre, string Post, string Nombre)
        {
            //OPTIMIZAR ESTE FILTRO, SEDE DEMASIADO ANTE CUALQUIER CAMBIO PEQUEÑO
            if (!Pre.Equals(Post))
            {
                //CREAR PASO Y AGREGARLO A LA LISTA
                Paso = new Pasos(Pre, Post, Nombre);
                
                Conexion.Open();
                Paso.SetId( DAL.SiguientePaso() );
                Conexion.Close();

                Paso.SetFuncion( Funcion_id );
                Paso.SetId( Resultado_id );
                LPasos.Add(Paso);
            }
        }

        public List<Variables> ObtenerVariable(string Expresion)
        {
            LVariables = new List<Variables>();
            Expresion = Proceso.ExtraerVariables(Expresion);
            foreach (var elemento in Expresion)
            {
                Var = new Variables($"{elemento}");
                LVariables.Add(Var);
            }

            return LVariables;
        }

        private string CoordenadasResultantes(Polinomios Polinomio, Variables Var)
        {
            return null;
        }

        public void SetEstado(string Estado)
        {
            this.Estado = Estado;
            Resultado.SetEstado(Estado);
        }

        public string Guardar()
        {
            try
            {
                GuardarFuncion(Funcion);
                GuardarResultado(Resultado);
                GuardarPasos(LPasos);
                return "Almacenado satisfactoriamente";
            }
            catch (Exception e)
            {
                return $"Hubo un error desconocido al Guardar \n{e.Message}";
            }
        }

    }
}
