using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Socios.Datos.Utilerias;
using System.Data.SqlClient;

namespace Socios.Datos.Catalogos.DAO
{
    class HorarioGruposDAO
    {
           #region Atributos
        private AccesoBD conexion;
        private HorariosGpo horariogrupo;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public HorarioGruposDAO()
        {
            conexion = new AccesoBD();
            horariogrupo = new HorariosGpo();
        }
        #endregion

        #region Metodos
        public List<HorariosGpo> mapearObjetos(SqlDataReader dr)
        {
            List<HorariosGpo> HorariosGpo = new List<HorariosGpo>();
            while (dr.Read())
            {
                
                HorariosGpo.Add(new HorariosGpo(
                        (string) dr["GrupoID"],
                        (string)dr["Salon"],
                        (string)dr["Dia"],
                        (string)dr["Hora_Inicio"],
                        (string)dr["Hora_Final"]));
            }
            return HorariosGpo;
        }
        public List<HorariosGpo> getAll()
        {
            List<HorariosGpo> HorariosGpo = new List<HorariosGpo>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GruposHorario";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    HorariosGpo = mapearObjetos(dr);
                    dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return HorariosGpo;
        }
        public HorariosGpo mapearObjeto(SqlDataReader dr)
        {
            while (dr.Read())
            {
                horariogrupo = new HorariosGpo(
                      (string)dr["GrupoID"],
                        (string)dr["Salon"],
                        (string)dr["Dia"],
                        (string)dr["Hora_Inicio"],
                        (string)dr["Hora_Final"]);

            }
            return horariogrupo;
        }
        public HorariosGpo getById(HorariosGpo a)
        {
            horariogrupo = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoHorarioId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    horariogrupo = mapearObjeto(dr);
                
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return horariogrupo;
        }
        public void create(HorariosGpo a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoHorarioAdd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Salon", a.Salon));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia", a.Dia));
                conexion.Cmd.Parameters.Add(new SqlParameter("Hora_inicio", a.Hora_Inicio));
                conexion.Cmd.Parameters.Add(new SqlParameter("Hora_final", a.Hora_Final));
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

        public void update(HorariosGpo a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoHorarioAct ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Salon", a.Salon));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia", a.Dia));
                conexion.Cmd.Parameters.Add(new SqlParameter("Hora_inicio", a.Hora_Inicio));
                conexion.Cmd.Parameters.Add(new SqlParameter("Hora_final", a.Hora_Final));
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

        public void delete(HorariosGpo a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "delete from C_HorariosGpo where grupoID='" + a.GrupoID+ "'"; 
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
