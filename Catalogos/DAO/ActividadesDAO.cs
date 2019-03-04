using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Socios.Datos.Utilerias;

namespace Socios.Datos.Catalogos.DAO
{
    class ActividadesDAO
    {
         #region Atributos
        private AccesoBD conexion;
        private Actividades actividad;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public ActividadesDAO()
        {
            conexion = new AccesoBD();
            actividad = new Actividades();
        }
        #endregion

        #region Metodos
        public List<Actividades> mapearObjetos(SqlDataReader dr)
        {
            List<Actividades> Actividades = new List<Actividades>();
            while (dr.Read())
            {
                
                Actividades.Add(new Actividades(
                        int.Parse (dr["AreaID"].ToString()),
                        dr["Nombre"].ToString(),
                        dr["DeporteID"].ToString(),
                        dr["Status"].ToString(),
                        dr["Areap"].ToString(),
                        int.Parse(dr["NoDias"].ToString() == "" ? "0" : dr["NoDias"].ToString())
                    )
                    );
            }
            return Actividades;
        }
        public List<Actividades> getAll()
        {
            List<Actividades> Actividades = new List<Actividades>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Areas";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Actividades = mapearObjetos(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                Logger.Log(ex.Message);
            }
            return Actividades;
        }
        public Actividades mapearObjeto(SqlDataReader dr)
        {
            while (dr.Read())
            {
                  actividad = new Actividades(
                        int.Parse(dr["AreaId"].ToString()),
                        dr["Nombre"].ToString(),
                        dr["DeporteID"].ToString(),
                        dr["Status"].ToString(),
                        dr["Areap"].ToString(),
                        int.Parse(dr["NoDias"].ToString() == "" ? "0" : dr["NoDias"].ToString()));

            }
            return actividad;
        }
        public Actividades getById(Actividades a)
        {
            actividad = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_AreaId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.AreaID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    actividad = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                
                Logger.Log(ex.Message);
            }
            return actividad;
        }
        public void create(Actividades a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "sp_Areadd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.AreaID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("DeporteID", a.DeporteID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Status", a.Status));
                conexion.Cmd.Parameters.Add(new SqlParameter("Areap", a.Areap));
                conexion.Cmd.Parameters.Add(new SqlParameter("NoDias", a.NoDias));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Execute();
                
                
            }
            catch (SqlException ex)
            {
                throw;
                Logger.Log(ex.Message);
            }
            
        }

        public void update(Actividades a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "sp_Areact";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.AreaID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("DeporteID", a.DeporteID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Status", a.Status));
                conexion.Cmd.Parameters.Add(new SqlParameter("Areap", a.Areap));
                conexion.Cmd.Parameters.Add(new SqlParameter("NoDias", a.NoDias)); 
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Execute();
                
            }
            catch (SqlException ex)
            {
               
                Logger.Log(ex.Message);
            }
        }

        public void delete(Actividades a)
        {
            try
            {
                ///Se comento la siguiente intruccion ya que creemos que el where esta mal relacionado
                //conexion.Cmd.CommandText = "Delete from C_Areas where AreaID=" + a.DeporteID;
                conexion.Cmd.CommandText = "Delete from C_Areas where AreaID=" + a.AreaID;
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Connection.Open();
                conexion.Cmd.ExecuteNonQuery();
                //conexion.Execute();
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
