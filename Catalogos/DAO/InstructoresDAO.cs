using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Socios.Datos.Utilerias;
using System.Data.SqlClient;
namespace Socios.Datos.Catalogos.DAO
{
    class InstructoresDAO
    {
        #region Atributos
        private AccesoBD conexion;
        private Instructores instructor;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public InstructoresDAO()
        {
            conexion = new AccesoBD();
            instructor = new Instructores();
        }
        #endregion

        #region Metodos
        public List<Instructores> mapearObjetos(SqlDataReader dr)
        {
            List<Instructores> Instructores = new List<Instructores>();
            while (dr.Read())
            {

                Instructores instructor = new Instructores();
                instructor.Nombre=dr["nombre"].ToString();
                instructor.InstructorID=dr["Clave"].ToString();
                instructor.Status=dr["Status"].ToString();
                Instructores.Add(instructor);
            }
            return Instructores;
        }
        public List<Instructores> getAll(int SucursalID)
        {
            List<Instructores> Instructores = new List<Instructores>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Instructores";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Instructores = mapearObjetos(dr);
                    dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return Instructores;
        }
        public Instructores mapearObjeto(SqlDataReader dr)
        {
            while (dr.Read())
            {
                    byte[] imagen = null;
                     if (!DBNull.Value.Equals(dr["Foto"]))
                      imagen = (byte[])dr["Foto"];
                      instructor = new Instructores();
                      instructor.InstructorID= (string) dr["InstructorID"];
                      instructor.Nombre=  (string) dr["Nombre"];
                      instructor.Calle=  (string) dr["Calle"];
                      instructor.Colonia=  (string) dr["Colonia"];
                      instructor.Ciudad=  (string) dr["Ciudad"];
                      instructor.Estado=  (string) dr["Estado"];
                      instructor.Cp=  (string) dr["Cp"];
                      instructor.Telefono=  (string) dr["Telefono"];
                      instructor.RFC=  (string) dr["RFC"];
                      instructor.CURP=  (string) dr["CURP"];
                      instructor.IMSS=  (string) dr["IMSS"];
                      instructor.DeporteID= dr["DeporteID"].ToString();
                      instructor.Pais=  (string)dr["Pais"];
                      instructor.LugarNac=  (string)dr["LugarNac"];
                      instructor.FechaNac=  DateTime.Parse(dr["FechaNac"].ToString());
                      instructor.Edad=  int.Parse(dr["Edad"].ToString());
                      instructor.Nacionalidad=  (string)dr["Nacionalidad"];
                      instructor.Foto=imagen;
                      instructor.Status= (string)dr["Status"];
                      instructor.Indicador=  int.Parse(dr["Indicador"].ToString());
                      instructor.Sangre=  (string)dr["Sangre"];
                      instructor.Salario=  double.Parse(dr["Salario"].ToString());
                      instructor.Observaciones=  (string)dr["Observaciones"];
                      instructor.SalarioMH=  double.Parse(dr["SalarioMH"].ToString());
                      instructor.Percepciones= double.Parse(dr["Percepciones"].ToString());
                      instructor.Deduciones= double.Parse(dr["Deduciones"].ToString());
                      instructor.Incentivos= double.Parse(dr["Incentivos"].ToString());
                      instructor.SucursalID = int.Parse(dr["SucursalID"].ToString());
            }
            return instructor;
        }
        public Instructores getById(Instructores a)
        {
            instructor = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_InstructorId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.InstructorID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    instructor = mapearObjeto(dr);
                
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return instructor;
        }
        public void create(Instructores a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_InstructorAdd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("InstructorId", a.InstructorID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nombre",a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Calle",a.Calle));
                conexion.Cmd.Parameters.Add(new SqlParameter("Colonia",a.Colonia));
                conexion.Cmd.Parameters.Add(new SqlParameter("Ciudad",a.Ciudad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Estado",a.Estado));
                conexion.Cmd.Parameters.Add(new SqlParameter("CP",a.Cp));
                conexion.Cmd.Parameters.Add(new SqlParameter("Telefono",a.Telefono));
                conexion.Cmd.Parameters.Add(new SqlParameter("RFC",a.RFC));
                conexion.Cmd.Parameters.Add(new SqlParameter("CURP",a.CURP));
                conexion.Cmd.Parameters.Add(new SqlParameter("IMSS",a.IMSS));
                conexion.Cmd.Parameters.Add(new SqlParameter("DeporteId",a.DeporteID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Pais",a.Pais));
                conexion.Cmd.Parameters.Add(new SqlParameter("LugarNac",a.LugarNac));
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaNac",a.FechaNac));
                conexion.Cmd.Parameters.Add(new SqlParameter("Edad",a.Edad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nacionalidad",a.Nacionalidad));
                //conexion.Cmd.Parameters.Add(new SqlParameter("Foto",a.Foto));
                conexion.Cmd.Parameters.Add(new SqlParameter("Status",a.Status));
                conexion.Cmd.Parameters.Add(new SqlParameter("Indicador",a.Indicador));
                conexion.Cmd.Parameters.Add(new SqlParameter("Sangre",a.Sangre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Salario",a.Salario));
                conexion.Cmd.Parameters.Add(new SqlParameter("Observaciones",a.Observaciones));
                conexion.Cmd.Parameters.Add(new SqlParameter("SalarioMH",a.SalarioMH));
                conexion.Cmd.Parameters.Add(new SqlParameter("Percepciones",a.Percepciones));
                conexion.Cmd.Parameters.Add(new SqlParameter("Deduciones",a.Deduciones));
                conexion.Cmd.Parameters.Add(new SqlParameter("Incentivos",a.Incentivos));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
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

        public void update(Instructores a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_InstructorAct ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("InstructorId", a.InstructorID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Calle", a.Calle));
                conexion.Cmd.Parameters.Add(new SqlParameter("Colonia", a.Colonia));
                conexion.Cmd.Parameters.Add(new SqlParameter("Ciudad", a.Ciudad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Estado", a.Estado));
                conexion.Cmd.Parameters.Add(new SqlParameter("CP", a.Cp));
                conexion.Cmd.Parameters.Add(new SqlParameter("Telefono", a.Telefono));
                conexion.Cmd.Parameters.Add(new SqlParameter("RFC", a.RFC));
                conexion.Cmd.Parameters.Add(new SqlParameter("CURP", a.CURP));
                conexion.Cmd.Parameters.Add(new SqlParameter("IMSS", a.IMSS));
                conexion.Cmd.Parameters.Add(new SqlParameter("DeporteId", a.DeporteID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Pais", a.Pais));
                conexion.Cmd.Parameters.Add(new SqlParameter("LugarNac", a.LugarNac));
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaNac", a.FechaNac));
                conexion.Cmd.Parameters.Add(new SqlParameter("Edad", a.Edad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nacionalidad", a.Nacionalidad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Status", a.Status));
                conexion.Cmd.Parameters.Add(new SqlParameter("Indicador", a.Indicador));
                conexion.Cmd.Parameters.Add(new SqlParameter("Sangre", a.Sangre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Salario", a.Salario));
                conexion.Cmd.Parameters.Add(new SqlParameter("Observaciones", a.Observaciones));
                conexion.Cmd.Parameters.Add(new SqlParameter("SalarioMH", a.SalarioMH));
                conexion.Cmd.Parameters.Add(new SqlParameter("Percepciones", a.Percepciones));
                conexion.Cmd.Parameters.Add(new SqlParameter("Deduciones", a.Deduciones));
                conexion.Cmd.Parameters.Add(new SqlParameter("Incentivos", a.Incentivos));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
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

        public void delete(Instructores a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_InstructorDelete"; 
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("InstructorId", a.InstructorID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
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
