using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;
using Oracle.ManagedDataAccess.Client;

namespace BLL
{
    public class FuncionesService
    {
        string CadenaConexion;
        private OracleConnection Conexion;
        private BDRespository DAL;
        public string Respuesta { get; set; }

        public FuncionesService()
        {
            CadenaConexion = "Data Source=localhost:1521/xe;user Id=brayan;Password=0608";
            Conexion = new OracleConnection(CadenaConexion);
            DAL = new BDRespository(Conexion);
        }

        public void Guardar(Funciones Expresion)
        {
            try
            {
                Conexion.Open();
                DAL.Guardar(Expresion);
                Respuesta = DAL.Respuesta;
                Conexion.Close();
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
        }

    }
}
