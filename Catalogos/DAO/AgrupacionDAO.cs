using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Socios.Datos.Utilerias;

namespace Socios.Datos.Catalogos.DAO
{
    class AgrupacionDAO
    {
         #region Atributos
        private AccesoBD conexion;
        private Agrupacion agrupacion;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public AgrupacionDAO()
        {
            conexion = new AccesoBD();
            agrupacion = new Agrupacion();
        }
        #endregion

        #region Metodos
        public List<Agrupacion> mapearObjetos(SqlDataReader dr)
        {
            List<Agrupacion> Agrupacion = new List<Agrupacion>();
            while (dr.Read())
            {
                Agrupacion ag = new Agrupacion();
                Agrupacion.Add(ag);
                    
            }
            return Agrupacion;
        }
        public List<Agrupacion> getAll()
        {
            List<Agrupacion> Agrupacion = new List<Agrupacion>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Agrupacion";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Agrupacion = mapearObjetos(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                Logger.Log(ex.Message);
            }
            return Agrupacion;
        }
        public Agrupacion mapearObjeto(SqlDataReader dr)
        {
            while (dr.Read())
            {
                agrupacion = new Agrupacion();

            }
            return agrupacion;
        }
        public Agrupacion getById(Agrupacion a)
        {
            agrupacion = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_AreaId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.AgrupacionID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    agrupacion = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                
                Logger.Log(ex.Message);
            }
            return agrupacion;
        }
        public void create(Agrupacion a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "sp_Areadd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.AgrupacionID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioID", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Factura", a.Factura));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Execute();
                
            }
            catch (SqlException ex)
            {
                throw;
                Logger.Log(ex.Message);
            }
        }

        public void update(Agrupacion a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "sp_Areact";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.AgrupacionID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioID", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("sucursalID", a.SucursalID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Factura", a.Factura));
                
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Execute();
                
            }
            catch (SqlException ex)
            {
               
                Logger.Log(ex.Message);
            }
        }

        public void delete(Agrupacion a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "Delete from C_Areas where AreaID=" + a.AgrupacionID;
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Connection.Open();
                conexion.Cmd.ExecuteNonQuery();
               // conexion.Execute();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                if (conexion.Cmd.Connection.State != ConnectionState.Closed) conexion.Cmd.Connection.Close();
            }
        }
        #endregion

    }
}
