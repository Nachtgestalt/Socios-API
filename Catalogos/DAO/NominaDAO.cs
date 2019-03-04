using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Socios.Datos.Utilerias;
using System.Data.SqlClient;
namespace Socios.Datos.Catalogos.DAO
{
    class NominaDAO
    {
         #region Atributos
        private AccesoBD conexion;
        private Nomina nomina;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public NominaDAO()
        {
            conexion = new AccesoBD();
            nomina = new Nomina();
        }
        #endregion

        #region Metodos


        public void create(Nomina a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "Nomina";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaIni", a.FechaIni));
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaFin", a.FechaFin));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();
                //conexion.Cerrar();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
        }

      
        #endregion
    }
}
