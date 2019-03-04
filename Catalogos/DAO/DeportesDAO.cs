using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Socios.Datos.Utilerias;

namespace Socios.Datos.Catalogos.DAO
{
  public  class DeportesDAO
    {
        #region Atributos
        private AccesoBD conexion;
        private Deportes deporte;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public DeportesDAO()
        {
            conexion = new AccesoBD();
            deporte = new Deportes();
        }
        #endregion

        #region Metodos
        public List<Deportes> mapearObjetos(SqlDataReader dr)
        {
            List<Deportes> deportes = new List<Deportes>();
            while (dr.Read())
            {
                byte[] imagen=null;
                if (!DBNull.Value.Equals(dr["imagen"]))
                    imagen = (byte[])dr[3];
                deportes.Add(new Deportes(
                        dr.GetInt16(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        imagen,
                        dr.GetString(4) == "S" ? true : false
                    )
                    );
            }
            return deportes;
        }
        public List<Deportes> getAll()
        {
            List<Deportes> deportes = new List<Deportes>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Deportes";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    deportes = mapearObjetos(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return deportes;
        }
        public Deportes mapearObjeto(SqlDataReader dr)
        {
            while (dr.Read())
            {
                byte[] imagen = null;
                if (!DBNull.Value.Equals(dr["imagen"]))
                    imagen = (byte[])dr[3];
                
                deporte = new Deportes(
                        dr.GetInt16(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        imagen,
                        dr.GetString(4) == "S" ? true : false);

            }
            return deporte;
        }
        public Deportes getById(Deportes a)
        {
            deporte = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_DeporteId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.DeporteID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    deporte = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return deporte;
        }

        public Deportes getByNombre(Deportes a)
        {
            deporte = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_DeporteNombre ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    deporte = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return deporte;
        }
        public void create(Deportes a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_DeporteAdd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.DeporteID));
                conexion.Cmd.Parameters.Add(new SqlParameter("descripcion", a.Descripcion));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("imagen", a.Imagen));
                conexion.Cmd.Parameters.Add(new SqlParameter("Status", a.Status));
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

        public void update(Deportes a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_DeporteAct ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.DeporteID));
                conexion.Cmd.Parameters.Add(new SqlParameter("descripcion", a.Descripcion));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("imagen", a.Imagen));
                conexion.Cmd.Parameters.Add(new SqlParameter("Status", a.Status));
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

        public void delete(Deportes a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_DeporteDel " + a.DeporteID;
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
