using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Socios.Datos.Utilerias;

namespace Socios.Datos.Catalogos.DAO
{
  public  class UsuariosDAO
    {
        #region Atributos
        private AccesoBD conexion;
        private Usuarios usuario;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public UsuariosDAO()
        {
            conexion = new AccesoBD();
            usuario = new Usuarios();
        }
        #endregion

        #region Metodos
        public List<Usuarios> mapearObjetos(SqlDataReader dr)
        {
            List<Usuarios> Usuarios = new List<Usuarios>();
            while (dr.Read())
            {
                Usuarios usr = new Usuarios();
                usr.User_Nip= dr.GetInt32(0);
                usr.User_ID=dr.GetString(1);
                usr.User_Name=dr.GetString(2);
                usr.User_Pwd = dr.GetString(3);
                usr.User_Type = dr.GetString(4);
                usr.User_Depto = dr.GetString(5);
                usr.User_Pusto = dr.GetString(6);
                usr.User_Sts = dr.GetString(7);
                Usuarios.Add(usr);
            }
            return Usuarios;
        }
        public List<Usuarios> getAll()
        {
            List<Usuarios> Usuarios = new List<Usuarios>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Usuarios";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Usuarios = mapearObjetos(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return Usuarios;
        }
        public Usuarios mapearObjeto(SqlDataReader dr)
        {
            Usuarios usr = new Usuarios();
            while (dr.Read())
            {

               
                usr.User_Nip = int.Parse(dr[0].ToString());
                usr.User_ID = dr.GetString(1);
                usr.User_Name = dr.GetString(2);
                usr.User_Pwd = dr.GetString(3);
                usr.User_Type = dr.GetString(4);
                usr.User_Depto = dr[5].ToString();
                usr.User_Pusto = dr[6].ToString();
                usr.User_Sts = dr.GetString(7);

            }
            return usr;
        }
        public Usuarios getById(Usuarios a)
        {
            usuario = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_UsuarioId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.User_Nip));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    usuario = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return usuario;
        }

        public Usuarios getByNombre(Usuarios a)
        {
            usuario = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "dbo.sp_Users02";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.User_ID));
                
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    usuario = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return usuario;
        }
        public void create(Usuarios a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_UsuarioAdd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.User_Nip));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_ID", a.User_ID));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Name", a.User_Name));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_pwd", a.User_Pwd));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Type", a.User_Type));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Depto", a.User_Depto));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Pusto", a.User_Pusto));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Sts", a.User_Sts));
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

        public void update(Usuarios a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_UsusarioAct ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.User_Nip));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_ID", a.User_ID));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Name", a.User_Name));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_pwd", a.User_Pwd));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Type", a.User_Type));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Depto", a.User_Depto));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Pusto", a.User_Pusto));
                conexion.Cmd.Parameters.Add(new SqlParameter("User_Sts", a.User_Sts));
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

        public void delete(Usuarios a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_USuarioDel ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.User_Nip));
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
