using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Socios.Datos.Utilerias;

namespace Socios.Datos.Catalogos.DAO
{
    class AccesoBD
    {
        #region Atributos
        private string strConn;
        private SqlConnection conn;
        private SqlCommand cmd;
        
        #endregion

        #region PropiedadesAcceso
        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        #endregion

        #region Constructores
        public AccesoBD()
        {
            //strConn = uFacturaEDatos.Operaciones.Conexion.Connection();
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

            
            try
            {
                conn = new SqlConnection(strConn);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }


            
        }
        #endregion

        #region Metodos
        public int Execute()
        {
            int result = 0;
            try
            {

                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }

            

            return result;
        }

        public void Cerrar()
        {
            this.conn.Close();
        }
        #endregion
    }
}
