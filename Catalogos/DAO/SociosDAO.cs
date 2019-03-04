﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Socios.Datos.Utilerias;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web.Hosting;

namespace Socios.Datos.Catalogos.DAO
{
    class SociosDAO
    {
         #region Atributos
        private AccesoBD conexion;
        private Socio socio;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public SociosDAO()
        {
            conexion = new AccesoBD();
            socio = new Socio();
        }
        #endregion

        #region Metodos
               
        public List<SocioListado> mapearObjetosL(SqlDataReader dr)
        {
            List<SocioListado> socios = new List<SocioListado>();
            while (dr.Read())
            {
                SocioListado socio = new SocioListado();
                socio.NoSocio = dr["SocioID"].ToString();
                socio.Nombre= (string)dr["Nombre"];
                if (dr["Email"] != null)
                    socio.Email = dr["Email"].ToString();
                else
                    socio.Email = "";
                socio.status = (string)dr["Socio_Anterior"];
                socio.sucursalID = int.Parse(dr["SucursalID"].ToString());
                socios.Add(socio);
                
            }
            return socios;
        }
        public List<SocioListado> GetListado(int SucursalID)
        {
            List<SocioListado> Grupos = new List<SocioListado>();
            try
           {
            conexion.Cmd.Connection.Open();
            conexion.Cmd.CommandText = "sp_Socios";
            conexion.Cmd.Parameters.Clear();
            conexion.Cmd.CommandType = CommandType.StoredProcedure;
            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalId", SucursalID));
            SqlDataReader dr = conexion.Cmd.ExecuteReader();
            if (dr.HasRows)
                Grupos = mapearObjetosL(dr);
            dr.Close();
            conexion.Cmd.Connection.Close();
        }
        catch (SqlException ex)
        {
            Logger.Log(ex.Message);
        }
        return Grupos;
          

        }

        public List<SocioListado> GetListadoE(int SucursalID)
        {
            List<SocioListado> Grupos = new List<SocioListado>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_SociosE";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalId", SucursalID));



                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Grupos = mapearObjetosL(dr);
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return Grupos;


        }
     
        public List<SocioListado> GetListadoEC(int SucursalID,int SocioIni, int SocioFin, int SocioLun,int SocioMar,
            int SocioMie,int SocioJue,int SocioVie ,int SocioSab)
        {
            List<SocioListado> Grupos = new List<SocioListado>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_SociosEC";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalId", SucursalID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioIni", SocioIni));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioFin", SocioFin));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioLun", SocioLun));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioMar", SocioMar));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioMie", SocioMie));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioJue", SocioJue));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioVie", SocioVie));
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioSab", SocioSab));

                
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Grupos = mapearObjetosL(dr);
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return Grupos;


        }
     
        public Socio mapearObjeto(SqlDataReader dr)
        {
            socio = new Socio();
                if (dr.HasRows)
                {
                    dr.Read();   
                    socio.SocioID = int.Parse(dr["SocioID"].ToString());
                    socio.Nombre = (string)dr["Nombre"];
                    socio.Nacionalidad = (string)dr["Nacionalidad"];
                    socio.Calle = dr["calle"].ToString();
                    socio.Ciudad = (string)dr["ciudad"];
                    if (dr["FechaNac"].ToString()!="")
                    socio.FechaNac = DateTime.Parse(dr["FechaNac"].ToString());
                    if (dr["FechaRein"].ToString() != "")
                        socio.FechaRein = DateTime.Parse(dr["FechaRein"].ToString());
                    else
                        socio.FechaRein = DateTime.Parse("01/01/1900");
                    if (dr["FechaBaja"].ToString() != "")
                        socio.Fecha_Baja = DateTime.Parse(dr["FechaBaja"].ToString());
                    else
                        socio.Fecha_Baja = DateTime.Parse("01/01/1900");
                    if (dr["FechaAlta"].ToString()!="")
                    socio.Fecha_Alta = DateTime.Parse(dr["FechaAlta"].ToString());
                    socio.Estado = (string)dr["estado"];
                    if (dr["Email"].ToString() != "")
                        socio.Email = (string)dr["Email"];
                    else
                        socio.Email = "";

                    socio.CP = (string)dr["cp"];
                    socio.Colonia = dr["Colonia"].ToString();
                    socio.Edad = int.Parse(dr["Edad"].ToString());
                    socio.ExpDif = bool.Parse(dr["exDif"].ToString());
                    if (dr["expectativas"].ToString() != "")
                        socio.Expectativas = (string)dr["expectativas"];
                    else
                        socio.Expectativas = "";

                    socio.LugarNac = dr["LugarNac"].ToString();

                    socio.Observacion = dr["Observacion"].ToString();
                    socio.Pais = (string)dr["Pais"];
                    socio.Promocion = int.Parse(dr["Promocion"].ToString());
                    socio.Telefono = (string)dr["telefono"].ToString();
                    socio.Status = dr["status"].ToString()[0];
                    socio.Socio_anterior = dr["Socio_anterior"].ToString()[0];
                    socio.SucursalID = int.Parse(dr["SucursalID"].ToString());
                    socio.Razon = (string)dr["Razon"].ToString();
                    socio.ExaUbicacion = false;
                    if (dr["ExaUbicacion"] != null)
                        if (dr["ExaUbicacion"].ToString() != "")
                           socio.ExaUbicacion = bool.Parse(dr["ExaUbicacion"].ToString());

                            if (dr["AreaID"].ToString() != "")
                                socio.Actividad = int.Parse(dr["AreaID"].ToString());
                       
                       
                    //obtenemos los 
                    socio.Horario = obtenHorario(socio.SocioID.ToString(), socio.SucursalID);
                    socio.Horariodet = obtenHorarioDet(socio.SocioID.ToString(), socio.SucursalID);
                    
                }
                
            
            return socio;
            
        }

        public List<SocioAsistencias> obtenAsitencias(int SocioID, int SucursalID,int Mes,int año)
        {
            List<SocioAsistencias> asitencias = new List<SocioAsistencias>();
            AccesoBD conexionlc = new AccesoBD();
            conexionlc.Cmd.Connection.Open();
            conexionlc.Cmd.CommandText = "sp_Asitencias";
            conexionlc.Cmd.Parameters.Clear();
            conexionlc.Cmd.CommandType = CommandType.StoredProcedure;
            conexionlc.Cmd.Parameters.Add(new SqlParameter("Id", SocioID));
            //conexionlc.Cmd.Parameters.Add(new SqlParameter("SucursalId", SucursalID));
            conexionlc.Cmd.Parameters.Add(new SqlParameter("Mes", Mes));
            conexionlc.Cmd.Parameters.Add(new SqlParameter("Año", año));
            SqlDataReader dr = conexionlc.Cmd.ExecuteReader();
            if (dr.HasRows)
                asitencias = mapearAsitencias(dr);
            dr.Close();
            conexionlc.Cmd.Connection.Close();
            return asitencias;
        }

        private List<SocioAsistencias> mapearAsitencias(SqlDataReader dr)
        {
            List<SocioAsistencias> asitencia = new List<SocioAsistencias>();
            
            List<string> dias = new List<string>();
            
            while (dr.Read())
            {
                SocioAsistencias asis = new SocioAsistencias();
                asis.Dia = DateTime.Parse(dr["Dia"].ToString()).Day.ToString();
                asis.Asi = bool.Parse(dr["Presente"].ToString()) ? "*" : "";
                asitencia.Add(asis);
              }
            
            
            return asitencia;
        }

        public List<SociosHorario> obtenHorario(string SocioID, int SucursalID)
        {
            List<SociosHorario> horario = new List<SociosHorario>();
            AccesoBD conexionlc = new AccesoBD();
            conexionlc.Cmd.Connection.Open();
            conexionlc.Cmd.CommandText = "sp_SocioHorario";
            conexionlc.Cmd.Parameters.Clear();
            conexionlc.Cmd.CommandType = CommandType.StoredProcedure;
            conexionlc.Cmd.Parameters.Add(new SqlParameter("Id", SocioID));
            conexionlc.Cmd.Parameters.Add(new SqlParameter("SucursalId", SucursalID));
            SqlDataReader dr = conexionlc.Cmd.ExecuteReader();
            if (dr.HasRows)
                horario = mapearHorario(dr);
            dr.Close();
            conexionlc.Cmd.Connection.Close();
            return horario;
        }
        public List<SociosHorariodet> obtenHorarioDet(string SocioID, int SucursalID)
        {
            List<SociosHorariodet> horario = new List<SociosHorariodet>();
            AccesoBD conexionlc = new AccesoBD();
            conexionlc.Cmd.Connection.Open();
            conexionlc.Cmd.CommandText = "sp_SocioHorario";
            conexionlc.Cmd.Parameters.Clear();
            conexionlc.Cmd.CommandType = CommandType.StoredProcedure;
            conexionlc.Cmd.Parameters.Add(new SqlParameter("Id", SocioID));
            conexionlc.Cmd.Parameters.Add(new SqlParameter("SucursalId", SucursalID));
            SqlDataReader dr = conexionlc.Cmd.ExecuteReader();
            if (dr.HasRows)
                horario = mapearHorariodet(dr);
            dr.Close();
            conexionlc.Cmd.Connection.Close();
            return horario;
        }
        private List<SociosHorariodet> mapearHorariodet(SqlDataReader dr)
        {
            List<SociosHorariodet> horarios = new List<SociosHorariodet>();
            SociosHorariodet horario;
            horario = new SociosHorariodet();

            while (dr.Read())
            {        horario = new SociosHorariodet();
                    if (!DBNull.Value.Equals(dr["Categoria"]))
                        horario.Categoria = (string)dr["Categoria"];
                    horario.Instructor = (string)dr["InstructorID"];
                    horario.Grupo = (string)dr["GrupoID"];
                    horario.Nombre = (string)dr["Grupo"];
                    horario.Horario = (string)dr["Hora_Inicio"] + "-" + dr["Hora_Final"];
                    switch (int.Parse((string)dr["Dia"]))
                    {
                        case 1:
                            horario.Dia = "Domingo";
                            break;
                        case 2:
                            horario.Dia = "Lunes";
                            break;
                        case 3:
                            horario.Dia = "Martes";
                            break;
                        case 4:
                            horario.Dia = "Miercoles";
                            break;
                        case 5:
                            horario.Dia = "Jueves";
                            break;
                        case 6:
                            horario.Dia = "Viernes";
                            break;
                        case 7:
                            horario.Dia = "Sabado";
                            break;
                    }
                    horarios.Add(horario);
            }
            
            return horarios;
        }

        private List<SociosHorario> mapearHorario(SqlDataReader dr)
        {
            List<SociosHorario> horarios = new List<SociosHorario>();
            SociosHorario horario;
            horario = new SociosHorario();
            
            while (dr.Read())
            {
                if (horario.Grupo!= (string)dr["GrupoID"])
                {
                    if (horario.Grupo != null)
                       horarios.Add(horario);

                    horario = new SociosHorario();
                    if (!DBNull.Value.Equals(dr["Categoria"]))
                    horario.Categoria = (string)dr["Categoria"];
                    horario.Instructor = (string)dr["InstructorID"];
                    horario.Grupo = (string)dr["GrupoID"];
                    horario.Nombre = (string)dr["Grupo"];
                    horario.Horario = (string)dr["Hora_Inicio"] + "-" + dr["Hora_Final"]; 
                    switch (int.Parse((string)dr["Dia"]))
                    {
                        case 1:
                            horario.Domingo = true;
                            break;
                        case 2:
                            horario.Lunes = true;
                            break;
                        case 3:
                            horario.Martes = true;
                            break;
                        case 4:
                            horario.Miercoles = true;
                            break;
                        case 5:
                            horario.Jueves = true;
                            break;
                        case 6:
                            horario.Viernes = true;
                            break;
                        case 7:
                            horario.Sabado = true;
                            break;
                    }
                }
                else
                {
                    switch (int.Parse((string)dr["Dia"]))
                    {
                        case 1:
                            horario.Domingo = true;
                            break;
                        case 2:
                            horario.Lunes = true;
                            break;
                        case 3:
                            horario.Martes = true;
                            break;
                        case 4:
                            horario.Miercoles = true;
                            break;
                        case 5:
                            horario.Jueves = true;
                            break;
                        case 6:
                            horario.Viernes = true;
                            break;
                        case 7:
                            horario.Sabado = true;
                            break;
                    }
                }
                
            }
            if (horario != null)
                horarios.Add(horario);
            return horarios;
        }
        public Socio getById(Socio a)
        {
            socio = null;
            try
            {
                if (conexion.Cmd.Connection.State == ConnectionState.Open) conexion.Cmd.Connection.Close();
                    
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_SocioIdnew";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    socio = mapearObjeto(dr);
                
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return socio;
        }
        public int  create(Socio a)
        {
            int SocioID=0;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Socionew ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    if (dr.Read())
                    {
                        SocioID = int.Parse(dr[0].ToString());
                    }

                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return SocioID;
        }

        public void update(Socio a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_SocioAct";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("LugarNac", a.LugarNac));
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaNac", a.FechaNac));
                conexion.Cmd.Parameters.Add(new SqlParameter("Edad", a.Edad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nacionalidad", a.Nacionalidad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Calle", a.Calle));
                conexion.Cmd.Parameters.Add(new SqlParameter("Colonia", a.Colonia));
                conexion.Cmd.Parameters.Add(new SqlParameter("Ciudad", a.Ciudad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Estado", a.Estado));
                conexion.Cmd.Parameters.Add(new SqlParameter("Pais ", a.Pais));
                conexion.Cmd.Parameters.Add(new SqlParameter("CP", a.CP));
                conexion.Cmd.Parameters.Add(new SqlParameter("Telefono", a.Telefono));
                conexion.Cmd.Parameters.Add(new SqlParameter("Promocion", a.Promocion));
                if (a.Socio_anterior == null)
                    a.Socio_anterior = 'N';
                if (a.Socio_anterior=='S')
                conexion.Cmd.Parameters.Add(new SqlParameter("Status", a.Status));
                else
                conexion.Cmd.Parameters.Add(new SqlParameter("Status", a.Socio_anterior));

                conexion.Cmd.Parameters.Add(new SqlParameter("Socio_Anterior", a.Socio_anterior));
                conexion.Cmd.Parameters.Add(new SqlParameter("Razon ", a.Razon));
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaAlta", a.Fecha_Alta));
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaBaja", a.Fecha_Baja));
                conexion.Cmd.Parameters.Add(new SqlParameter("Observacion", a.Observacion));
                conexion.Cmd.Parameters.Add(new SqlParameter("FechaRein", a.FechaRein));
                conexion.Cmd.Parameters.Add(new SqlParameter("ExDif", a.ExpDif));
                conexion.Cmd.Parameters.Add(new SqlParameter("Expectativas", a.Expectativas));
                conexion.Cmd.Parameters.Add(new SqlParameter("Email", a.Email));
                conexion.Cmd.Parameters.Add(new SqlParameter("AreaID", a.Actividad));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();
                // guardamos horario
                // eliminamos anteriores
                conexion.Cmd.CommandText = "sp_SocioHorarioDel";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();
                if (a.Socio_anterior == 'S')
                {
                    //guardamos sus grupos en el historial de eliminados
                    foreach (SociosHorario x in a.Horario)
                    {
                        //inserccion categorias

                        conexion.Cmd.CommandText = "sp_SocioinsAreasbaja";
                        conexion.Cmd.Parameters.Clear();
                        conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                        conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                        conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                        conexion.Cmd.Parameters.Add(new SqlParameter("fecha", DateTime.Now));
                        conexion.Cmd.Parameters.Add(new SqlParameter("Categoria", a.Horario[0].Categoria));
                        conexion.Cmd.Parameters.Add(new SqlParameter("TipoPago", 1));
                        conexion.Cmd.Parameters.Add(new SqlParameter("Area", x.Grupo.Substring(0, 3)));
                        conexion.Cmd.Parameters.Add(new SqlParameter("status", "S"));
                        conexion.Cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Cmd.ExecuteNonQuery();
                    }

                }
                else
                {
                  /*  
                    if (a.Horario.Count > 0)
                    {
                        conexion.Cmd.CommandText = "sp_SociosinsCatego";
                        conexion.Cmd.Parameters.Clear();
                        conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                        conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                        conexion.Cmd.Parameters.Add(new SqlParameter("Categoria", a.Horario[0].Categoria));
                        conexion.Cmd.Parameters.Add(new SqlParameter("fecha", DateTime.Now));
                        conexion.Cmd.Parameters.Add(new SqlParameter("Entrego", false));
                        conexion.Cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Cmd.ExecuteNonQuery();
                    }*/
                    foreach (SociosHorario x in a.Horario)
                    {
                        //inserccion categorias


                        CategoriasDAO CatDao = new CategoriasDAO();

                        conexion.Cmd.CommandText = "sp_SocioinsAreas";
                        conexion.Cmd.Parameters.Clear();
                        conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                        conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                        conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                        conexion.Cmd.Parameters.Add(new SqlParameter("fecha", DateTime.Now));
                        conexion.Cmd.Parameters.Add(new SqlParameter("TipoPago", 1));
                        conexion.Cmd.Parameters.Add(new SqlParameter("Categoria", a.Horario[0].Categoria));
                        conexion.Cmd.Parameters.Add(new SqlParameter("Area", x.Grupo.Substring(0, 3)));
                        conexion.Cmd.Parameters.Add(new SqlParameter("status", "S"));
                        conexion.Cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Cmd.ExecuteNonQuery();

                        if (x.Lunes)
                        {
                            conexion.Cmd.CommandText = "sp_SocioinsHorario";
                            conexion.Cmd.Parameters.Clear();
                            conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                            conexion.Cmd.Parameters.Add(new SqlParameter("Dia", 2));
                            conexion.Cmd.CommandType = CommandType.StoredProcedure;
                            conexion.Cmd.ExecuteNonQuery();
                        }

                        if (x.Martes)
                        {
                            conexion.Cmd.CommandText = "sp_SocioinsHorario";
                            conexion.Cmd.Parameters.Clear();
                            conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                            conexion.Cmd.Parameters.Add(new SqlParameter("Dia", 3));
                            conexion.Cmd.CommandType = CommandType.StoredProcedure;
                            conexion.Cmd.ExecuteNonQuery();
                        }

                        if (x.Miercoles)
                        {
                            conexion.Cmd.CommandText = "sp_SocioinsHorario";
                            conexion.Cmd.Parameters.Clear();
                            conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                            conexion.Cmd.Parameters.Add(new SqlParameter("Dia", 4));
                            conexion.Cmd.CommandType = CommandType.StoredProcedure;
                            conexion.Cmd.ExecuteNonQuery();
                        }

                        if (x.Jueves)
                        {
                            conexion.Cmd.CommandText = "sp_SocioinsHorario";
                            conexion.Cmd.Parameters.Clear();
                            conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                            conexion.Cmd.Parameters.Add(new SqlParameter("Dia", 5));
                            conexion.Cmd.CommandType = CommandType.StoredProcedure;
                            conexion.Cmd.ExecuteNonQuery();
                        }
                        if (x.Viernes)
                        {
                            conexion.Cmd.CommandText = "sp_SocioinsHorario";
                            conexion.Cmd.Parameters.Clear();
                            conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                            conexion.Cmd.Parameters.Add(new SqlParameter("Dia", 6));
                            conexion.Cmd.CommandType = CommandType.StoredProcedure;
                            conexion.Cmd.ExecuteNonQuery();
                        }
                        if (x.Sabado)
                        {
                            conexion.Cmd.CommandText = "sp_SocioinsHorario";
                            conexion.Cmd.Parameters.Clear();
                            conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                            conexion.Cmd.Parameters.Add(new SqlParameter("grupoID", x.Grupo));
                            conexion.Cmd.Parameters.Add(new SqlParameter("Dia", 7));
                            conexion.Cmd.CommandType = CommandType.StoredProcedure;
                            conexion.Cmd.ExecuteNonQuery();
                        }
                    }
                }

                //conexion.Cerrar();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public void delete(Socio a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_SociosDel";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("SocioID", a.SocioID));
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


        private ReportDocument rd = new ReportDocument();

        public byte[] printRecibo(uFacturaEDatos.Operaciones.Recibo.Recibos recibo)
        {
            SqlConnection conn;
            SqlCommand cmd;

            try
            {


                conn = conexion.Cmd.Connection;
                cmd = new SqlCommand();
                cmd.Connection = conn;
                DataSet reportes = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter("Select * from Cs_Recibos WHERE RemRecID=" + recibo.recibo.RemRecId.ToString(), conn);
                adaptador.Fill(reportes, "Cs_Recibos");
                SqlDataAdapter adaptador1 = new SqlDataAdapter("Select * from Cs_SociosDias where socioID in (Select socioid from t_RemRecDet  where  RemRecID=" + recibo.recibo.RemRecId.ToString() + ")", conn);

                adaptador1.Fill(reportes, "Cs_SociosDias");

                
                // rd.SummaryInfo.ReportTitle = "(" +
                //Socios.Datos.Utilerias.Conversiones.NumeroALetras(recibo.recibo.Total.ToString(), "PESOS", "") + ")";
                // if (recibo.Comentario != null)
                //     rd.SummaryInfo.ReportComments = recibo.Comentario;

                rd.Load(HostingEnvironment.MapPath("~/Reportes/Recibo.rpt"));
                rd.SetDataSource(reportes);
                 
                conn.Close();


                MemoryStream stream = new MemoryStream();
                    rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat).CopyTo(stream);
                stream.Seek(0, SeekOrigin.Begin);
                
                return stream.ToArray();
            

            }
            catch (SqlException ex)
            {
                //activamos el log de ejecucion.

                //activamos tarea de ejecucion cada 5 min para verificar el servidor.
                return null;

            }

        }

        

    }
}