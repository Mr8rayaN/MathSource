using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public class FuncionesRepository
    {
        private OracleConnection Conexion;
        public string Respuesta { get; private set; }

        public FuncionesRepository(OracleConnection Oracle)
        {
            this.Conexion = Oracle;
        }

        public void Guardar(Funcion Expresion)
        {
            //SIMULACION USANDO F0003, CREAR PROCESO DE AUTO GENERACION DE LLAVE PRIMARIA (FUNCION_ID)
            using(var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "INSERT INTO FUNCIONES VALUES (@FUNCION_ID,@NOMBRE,@EXPRESION)";
                Comando.Parameters.Add("@FUNCION_ID", OracleDbType.NChar).Value = "F0003";
                Comando.Parameters.Add("@NOMBRE", OracleDbType.NVarchar2).Value = Expresion.Nombre;
                Comando.Parameters.Add("@EXPRESION", OracleDbType.NVarchar2).Value = Expresion.Contenido;
            }
        } 
    }
}
