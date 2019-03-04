using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Socios.Datos.Utilerias;
using System.Data.SqlClient;
namespace Socios.Datos.Catalogos.DAO
{
    class sucursalDAO
    {
         #region Atributos
        private AccesoBD conexion;
        private Sucursal sucursal;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public sucursalDAO()
        {
            conexion = new AccesoBD();
            sucursal = new Sucursal();
        }
        #endregion

        #region Metodos

        public List<Sucursal> mapearObjetos(SqlDataReader dr)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            while (dr.Read())
            {
                Sucursal suc = new Sucursal();
                suc.Idsucursal = int.Parse(dr["idsucursal"].ToString());
                suc.Idempresa = int.Parse(dr["idempresa"].ToString());
                suc.Nombresucursal = (string)dr["Nombresucursal"];
                suc.Calle = (string)dr["calle"];
                suc.Localidad = (string)dr["localidad"];
                suc.Municipio = (string)dr["Municipio"];
                suc.Sello_VigenciaDesde = DateTime.Parse(dr["Sello_VigenciaDesde"].ToString());
                suc.Sello_VigenciaHasta = DateTime.Parse(dr["Sello_VigenciaHasta"].ToString());
                suc.Estado = (string)dr["estado"];
                suc.Cp = dr["CP"].ToString();
                suc.Colonia = (string)dr["Colonia"];
                suc.Pais = (string)dr["Pais"];

                sucursales.Add(suc);
            }
            return sucursales;
        }
        public List<Sucursal> getAll()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_sucursales";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    sucursales = mapearObjetos(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
           
                Logger.Log(ex.Message);
            }
            return sucursales;
        }


        public Sucursal mapearObjeto(SqlDataReader dr)
        {
            
            while (dr.Read())
            {
                sucursal = new Sucursal();
                sucursal.Idsucursal = int.Parse(dr["idsucursal"].ToString());
                sucursal.Idempresa = int.Parse(dr["idempresa"].ToString());
                sucursal.Nombresucursal = (string)dr["Nombresucursal"];
                sucursal.Calle = (string)dr["calle"];
                sucursal.Localidad = (string)dr["localidad"];
                sucursal.Municipio = (string)dr["municipo"];
                sucursal.Sello_VigenciaDesde = DateTime.Parse(dr["Sello_VigenciaDesde"].ToString());
                sucursal.Sello_VigenciaHasta = DateTime.Parse(dr["Sello_VigenciaHasta"].ToString());
                sucursal.Estado = (string)dr["estado"];
                sucursal.Cp = (string)dr["cp"];
                sucursal.Colonia = (string)dr["Colonia"];
                                
                sucursal.Pais = (string)dr["Pais"];
                
                
                       
                
                
            }
            return sucursal;
        }

        
        
        public Sucursal getById(Sucursal a)
        {
            sucursal = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_SucursalID";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.Idsucursal));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    sucursal = mapearObjeto(dr);
                
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return sucursal;
        }
        public void create(Socio a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoAdd ";
                conexion.Cmd.Parameters.Clear();
                
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

        public void update(Socio a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoAct ";
                conexion.Cmd.Parameters.Clear();
               
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

        public void delete(Grupos a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "delete from C_Grupos where grupoID=" + a.GrupoID;
                conexion.Cmd.Parameters.Clear();
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
