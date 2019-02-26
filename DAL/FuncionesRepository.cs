using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
//using System.Data.OracleClient;
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

        //GUARDAR FUNCIONANDO
        public void Guardar(Funcion Expresion)
        {
            using(var Comando = new OracleCommand("INSERTAR_FUNCIONES", Conexion))
            {
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                //Comando.CommandText = $"INSERT INTO FUNCIONES VALUES ('{Expresion.Id}','{Expresion.Nombre}','{Expresion.Contenido}')";
                //Comando.CommandText = "INSERT INTO FUNCIONES VALUES (&Id,&Name,&Contenido);";
                //Comando.Parameters.AddWithValue("@Id", Expresion.Id);
                Comando.Parameters.Add("FUNCION_ID", OracleDbType.NChar).Value = Expresion.Id;
                Comando.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = Expresion.Nombre;
                Comando.Parameters.Add("EXPRESION", OracleDbType.Varchar2).Value = Expresion.Contenido;
                Comando.ExecuteNonQuery(); //Error al ejecutar Query
            }
        } 
    }
}
