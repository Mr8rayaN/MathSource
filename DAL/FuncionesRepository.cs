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
                //Comando.CommandText = $"INSERT INTO FUNCIONES VALUES ('{Expresion.Id}','{Expresion.Nombre}','{Expresion.Contenido}')";
                Comando.CommandText = "INSERT INTO FUNCIONES VALUES (@Id,@Name,@Contenido);";
                //Comando.Parameters.AddWithValue("@Id", Expresion.Id);
                Comando.Parameters.Add("@Id", OracleDbType.NChar).Value = Expresion.Id;
                Comando.Parameters.Add("@Name", OracleDbType.Varchar2).Value = Expresion.Nombre;
                Comando.Parameters.Add("@Contenido", OracleDbType.Varchar2).Value = Expresion.Contenido;
                Comando.ExecuteNonQuery(); //Error al ejecutar Query
            }
        } 
    }
}
