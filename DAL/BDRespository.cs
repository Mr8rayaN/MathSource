using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public class BDRespository
    {
        private OracleConnection Conexion;
        private string Sentencia = "";
        private string Respuesta { get; set; }
        private OracleDataReader Obtenido { get; set; }
        List<Funciones> LFunciones;
        List<Resultados> LResultados;
        List<Pasos> LPasos;
        List<Estados> LEstados;

        public BDRespository(OracleConnection Oracle)
        {
            this.Conexion = Oracle;
        }

        public string GuardarFuncion(Funciones F)
        {
            Sentencia = "INSERTAR_FUNCION";
            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                Comando.Parameters.Add("FUNCION_ID", OracleDbType.Char).Value = F.Id;
                Comando.Parameters.Add("NOMBRE", OracleDbType.NVarchar2).Value = F.Nombre;
                Comando.Parameters.Add("EXPRESION", OracleDbType.NVarchar2).Value = F.Contenido;
                Comando.ExecuteNonQuery();
                return $"Funcion {F.ToString()} Guardada Satisfactoriamente";
            }

        } 

        public string GuardarResultado(Resultados R)
        {
            Sentencia = "INSERTAR_RESULTADO";
            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                Comando.Parameters.Add("RESULTADO_ID", OracleDbType.Char).Value = R.Id;
                Comando.Parameters.Add("NOMBRE", OracleDbType.NVarchar2).Value = R.Nombre;
                Comando.Parameters.Add("EXPRESION", OracleDbType.NVarchar2).Value = R.Contenido;
                Comando.Parameters.Add("ESTADO_ID", OracleDbType.Char).Value = R.Estado;
                Comando.ExecuteNonQuery();
                return $"Resultado {R.ToString()} Guardado Satisfactoriamente";
            }
        }

        public string GuardarPaso(Pasos P)
        {
            Sentencia = "INSERTAR_PASO";
            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                Comando.Parameters.Add("PASO_ID", OracleDbType.Char).Value = P.Id;
                Comando.Parameters.Add("FUNCION_ID", OracleDbType.Char).Value = P.Id_Funcion;
                Comando.Parameters.Add("RESULTADO_ID", OracleDbType.Char).Value = P.Id_Resultado;
                Comando.Parameters.Add("NOMBRE", OracleDbType.NVarchar2).Value = P.Nombre;
                Comando.Parameters.Add("ENTRADA", OracleDbType.NVarchar2).Value = P.Entrada;
                Comando.Parameters.Add("SALIDA", OracleDbType.NVarchar2).Value = P.Salida;
                Comando.ExecuteNonQuery();
                return $"Paso {P.ToString()} Guardado Satisfactoriamente";
            }
        }

        public List<Funciones> ConsultarFunciones()
        {
            Obtenido = null;
            Funciones Funcion;
            LFunciones = new List<Funciones>();
            Sentencia = "SELECT * FROM FUNCIONES";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            while (Obtenido.Read()) {
                //id nombre contenido
                Funcion = new Funciones(Obtenido["FUNCION_ID"].ToString(), Obtenido["NOMBRE"].ToString(), Obtenido["EXPRESION"].ToString());
                LFunciones.Add(Funcion);
            }

            return LFunciones;
        }

        public List<Pasos> ConsultarPasosEspecificos(string FUNCION_ID)
        {
            Obtenido = null;
            Pasos Paso;
            LPasos = new List<Pasos>();
            Sentencia = $"SELECT * FROM PASOS WHERE (FUNCION_ID = '{FUNCION_ID}')";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            while (Obtenido.Read())
            {
                //Entrada salida nombre
                Paso = new Pasos(Obtenido["ENTRADA"].ToString(), Obtenido["SALIDA"].ToString(), Obtenido["NOMBRE"].ToString());
                Paso.SetId(Obtenido["PASO_ID"].ToString());
                Paso.SetFuncion(Obtenido["FUNCION_ID"].ToString());
                Paso.SetResultado(Obtenido["RESULTADO_ID"].ToString());
                LPasos.Add(Paso);
            }

            return LPasos;
        }

        public List<Pasos> ConsultarPasos()
        {
            Obtenido = null;
            Pasos Paso;
            LPasos = new List<Pasos>();
            Sentencia = $"SELECT * FROM PASOS";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            while (Obtenido.Read())
            {
                //Entrada salida nombre
                Paso = new Pasos(Obtenido["ENTRADA"].ToString(), Obtenido["SALIDA"].ToString(), Obtenido["NOMBRE"].ToString());
                Paso.SetId(Obtenido["PASO_ID"].ToString());
                Paso.SetFuncion(Obtenido["FUNCION_ID"].ToString());
                Paso.SetResultado(Obtenido["RESULTADO_ID"].ToString());
                LPasos.Add(Paso);
            }

            return LPasos;
        }

        public List<Resultados> ConsultarResultados()
        {
            Obtenido = null;
            Resultados Resultado;
            LResultados = new List<Resultados>();
            Sentencia = "SELECT * FROM RESULTADOS";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            while (Obtenido.Read())
            {
                //id nombre contenido
                Resultado = new Resultados(Obtenido["RESULTADO_ID"].ToString(), Obtenido["NOMBRE"].ToString(), Obtenido["EXPRESION"].ToString());
                Resultado.SetEstado(Obtenido["ESTADO_ID"].ToString());
                LResultados.Add(Resultado);
            }

            return LResultados;
        }

        public int CantidadPasos()
        {
            Obtenido = null;
            Sentencia = "SELECT COUNT(*) FROM PASOS";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            Obtenido.Read();
            return int.Parse((Obtenido["COUNT(*)"].ToString()));
        }

        public int CantidadFunciones()
        {
            Obtenido = null;
            Sentencia = "SELECT COUNT(*) FROM FUNCIONES";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            Obtenido.Read();
            return int.Parse((Obtenido["COUNT(*)"].ToString()));
        }

        public int CantidadResultados()
        {
            Obtenido = null;
            Sentencia = "SELECT COUNT(*) FROM RESULTADOS";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {

                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            Obtenido.Read();
            return int.Parse((Obtenido["COUNT(*)"].ToString()));
        }

        public List<Estados> ConsultarEstados()
        {
            Obtenido = null;
            Estados Estado;
            LEstados = new List<Estados>();
            Sentencia = "SELECT * FROM ESTADOS";

            using (var Comando = new OracleCommand(Sentencia, Conexion))
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Obtenido = Comando.ExecuteReader();
            }

            while (Obtenido.Read())
            {
                //id nombre contenido
                Estado = new Estados(Obtenido["ESTADO_ID"].ToString(), Obtenido["NOMBRE"].ToString());
                LEstados.Add(Estado);
            }

            return LEstados;
        }

        public string SiguienteFuncion()
        {
            return $"F{CantidadFunciones() + 1}";
        }

        public string SiguienteResultado()
        {
            return $"R{CantidadResultados() + 1}";
        }

        public string SiguientePaso()
        {
            return $"P{CantidadPasos() + 1}";
        }

        //HACER BUSQUEDAS ESPECIFICAS EN FUNCIONES Y EMPELADOS Y ELIMINACIONES
    }
}
