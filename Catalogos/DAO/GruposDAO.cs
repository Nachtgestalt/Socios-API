using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Socios.Datos.Utilerias;
using System.Data.SqlClient;
namespace Socios.Datos.Catalogos.DAO
{
    class GruposDAO
    {
         #region Atributos
        private AccesoBD conexion;
        private Grupos grupo;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public GruposDAO()
        {
            conexion = new AccesoBD();
            grupo = new Grupos();
        }
        #endregion

        #region Metodos
        public List<GruposListado> mapearObjetos(SqlDataReader dr)
        {
            List<GruposListado> Grupos = new List<GruposListado>();
            while (dr.Read())
            {
                GruposListado gpo = new GruposListado();
                gpo.Categoria = (string)dr["Categoria"];
                gpo.Cupo = int.Parse(dr["Cupo"].ToString());
                if (dr["PrimerDia"].ToString().Length > 0 & dr["SegDia"].ToString().Length>0)
                gpo.Dias = (string)dr["PrimerDia"] + "-" + (string)dr["SegDia"];
                if (dr["Hora_inicio"].ToString().Length > 0 & dr["Hora_final"].ToString().Length>0)
                gpo.Horario = (string)dr["Hora_inicio"] + "-" + (string)dr["Hora_final"];
                gpo.inscritos = int.Parse(dr["Inscritos"].ToString());
                gpo.Grupo = (string)dr["GrupoID"];
                gpo.Nombre = (string)dr["Nombre"];
                Grupos.Add(gpo);
            }
            return Grupos;
        }
        public List<GruposDetalle> mapearObjetosA(SqlDataReader dr)
        {
            List<GruposDetalle> alumnos = new List<GruposDetalle>();
            while (dr.Read())
            {
                GruposDetalle alumno = new GruposDetalle();
                alumno.Nombre = (string)dr["Nombre"];
                alumno.NoSocio = int.Parse(dr["SocioId"].ToString());
                alumnos.Add(alumno);
            }
            return alumnos;

        }

        public List<GruposDetalle> obtenAlumnos(string GrupoID)//
        {
            List< GruposDetalle> alumnos = new List< GruposDetalle>();
            AccesoBD conexionlc=new AccesoBD();
            conexionlc.Cmd.Connection.Open();
            conexionlc.Cmd.CommandText = "sp_Grupodet";
            conexionlc.Cmd.Parameters.Clear();
            conexionlc.Cmd.CommandType = CommandType.StoredProcedure;
            conexionlc.Cmd.Parameters.Add(new SqlParameter("Id", GrupoID));
            SqlDataReader dr = conexionlc.Cmd.ExecuteReader();
            if (dr.HasRows)
                alumnos = mapearObjetosA(dr);
            dr.Close();
            conexionlc.Cmd.Connection.Close();
            return alumnos;
        }
        public List<GruposListado> mapearObjetosL(SqlDataReader dr)
        {
            List<GruposListado> Grupos = new List<GruposListado>();
            while (dr.Read())
            {
                GruposListado gpo = new GruposListado();
                gpo.Categoria = (string)dr["Categoria"];
                gpo.Cupo = int.Parse(dr["Cupo"].ToString());
                if (dr["PrimerDia"].ToString().Length>0 && dr["SegDia"].ToString().Length>0)
                     gpo.Dias = (string)dr["PrimerDia"] + "-" + (string)dr["SegDia"];
                if (dr["Hora_inicio"].ToString().Length>0 && dr["Hora_final"].ToString().Length>0)
                gpo.Horario = (string)dr["Hora_inicio"] + "-" + (string)dr["Hora_final"];
                gpo.inscritos = int.Parse(dr["Inscritos"].ToString());
                gpo.Grupo = (string)dr["GrupoID"];
                gpo.Nombre = (string)dr["Nombre"];
                gpo.Alumnos = obtenAlumnos(gpo.Grupo);
                Grupos.Add(gpo);
            }
            return Grupos;
        }
        public List<GruposListado> GetListado(int SucursalID)//
        { List<GruposListado> Grupos = new List<GruposListado>();
            try
           {
            conexion.Cmd.Connection.Open();
            conexion.Cmd.CommandText = "sp_Grupos";
            conexion.Cmd.Parameters.Clear();
            conexion.Cmd.CommandType = CommandType.StoredProcedure;
            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", SucursalID));
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

        public List<GruposHoraDistinct> mapearObjetosH(SqlDataReader dr)
        {
            List<GruposHoraDistinct> Grupos = new List<GruposHoraDistinct>();
            while (dr.Read())
            {
                GruposHoraDistinct gpo = new GruposHoraDistinct();
                gpo.Horario = (string)dr["Hora_Inicio"] + "-"+(string)dr["Hora_Final"];
                gpo.Sucursal = int.Parse(dr["SucursalID"].ToString());
                Grupos.Add(gpo);
            }
            return Grupos;
        }
        public List<GruposHoraDistinct> GetHorario(int SucursalID)
        {
            List<GruposHoraDistinct> Grupos = new List<GruposHoraDistinct>();
            try
           {
            conexion.Cmd.Connection.Open();
            conexion.Cmd.CommandText = "sp_GrupoHorarioDistinct";
            conexion.Cmd.Parameters.Clear();
            conexion.Cmd.CommandType = CommandType.StoredProcedure;
            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", SucursalID));
            SqlDataReader dr = conexion.Cmd.ExecuteReader();
            if (dr.HasRows)
                Grupos = mapearObjetosH(dr);
            dr.Close();
            conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return Grupos;


        }
        public List<GruposListado> getAll(int SucursalID)
        {
            List<GruposListado> Grupos = new List<GruposListado>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Grupos";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", SucursalID));

                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Grupos = mapearObjetos(dr);
                    dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
            return Grupos;
        }
        public Grupos mapearObjeto(SqlDataReader dr)
        {
            
            while (dr.Read())
            {
                grupo = new Grupos(
                       (string) dr["GrupoID"],
                        (string) dr["Nombre"],
                        (string) dr["Duracion"],
                        (string) dr["Salon"],
                        int.Parse( dr["cupo"].ToString()),
                        int.Parse (dr["inscritos"].ToString()),
                        int.Parse( dr["Apartado"].ToString()),
                        (string) dr["Categoria"],
                        (string) dr["InstructorID"],
                        DateTime.Parse( dr["PeriodoId_Inicio"].ToString()),
                        DateTime.Parse( dr["PeriodoId_Final"].ToString()),
                        int.Parse( dr["orden"].ToString()),
                        int.Parse(dr["SucursalID"].ToString()));
                //obtenemos los 
                grupo.Horario = obtenHorario((string)dr["GrupoID"]);
            }
            return grupo;
        }

        public List<GruposHorario> obtenHorario(string GrupoID)
        {
            List<GruposHorario> horario = new List<GruposHorario>();
            AccesoBD conexionlc = new AccesoBD();
            conexionlc.Cmd.Connection.Open();
            conexionlc.Cmd.CommandText = "sp_GrupoHorario";
            conexionlc.Cmd.Parameters.Clear();
            conexionlc.Cmd.CommandType = CommandType.StoredProcedure;
            conexionlc.Cmd.Parameters.Add(new SqlParameter("Id", GrupoID));
            SqlDataReader dr = conexionlc.Cmd.ExecuteReader();
            if (dr.HasRows)
                horario = mapearHorario(dr);
            dr.Close();
            conexionlc.Cmd.Connection.Close();
            return horario;
        }

        private List<GruposHorario> mapearHorario(SqlDataReader dr)
        {
            List<GruposHorario> horarios = new List<GruposHorario>();
            GruposHorario horario;
            horario = new GruposHorario();
            
            while (dr.Read())
            {
                if ((horario.Entrada != (string)dr["Hora_Inicio"]) && (horario.Salida != (string)dr["Hora_Final"]))
                {
                   if (horario.Entrada!=null)
                       horarios.Add(horario);

                    horario = new GruposHorario();
                    horario.Entrada = (string)dr["Hora_Inicio"];
                    horario.Salida = (string)dr["Hora_Final"];
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
        public Grupos getById(Grupos a)
        {
            grupo = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoIdNew ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Salon", 1));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    grupo = mapearObjeto(dr);
                
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return grupo;
        }
        public void create(Grupos a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoAdd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Duracion", a.Duracion));
                conexion.Cmd.Parameters.Add(new SqlParameter("Salon", a.Salon));
                conexion.Cmd.Parameters.Add(new SqlParameter("Cupo", a.Cupo));
                conexion.Cmd.Parameters.Add(new SqlParameter("Inscritos", a.Inscritos));
                conexion.Cmd.Parameters.Add(new SqlParameter("Apartado", a.Apartado));
                conexion.Cmd.Parameters.Add(new SqlParameter("Categoria", a.Categoria));
                conexion.Cmd.Parameters.Add(new SqlParameter("InstructorId", a.InstructorID));
                conexion.Cmd.Parameters.Add(new SqlParameter("PeriodoId_Inicio", a.PeriodoID_Inicio));
                conexion.Cmd.Parameters.Add(new SqlParameter("PeriodoId_Final", a.PeriodoID_Final));
                conexion.Cmd.Parameters.Add(new SqlParameter("orden", a.Orden));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();
                conexion.Cmd.CommandText = "sp_HrgpGrupoDel ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.ExecuteNonQuery();
                foreach (HorariosGpo x in a.Hrgpo)
                {
                    conexion.Cmd.CommandText = "sp_HrgpGrupoAdd ";
                    conexion.Cmd.Parameters.Clear();
                    conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Dia", x.Dia));
                    conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Hora_Inicio", x.Hora_Inicio));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Hora_Final", x.Hora_Final));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Salon", x.Salon));
                    conexion.Cmd.ExecuteNonQuery();
                }
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public void update(Grupos a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_GrupoAct";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Duracion", a.Duracion));
                conexion.Cmd.Parameters.Add(new SqlParameter("Salon", a.Salon));
                conexion.Cmd.Parameters.Add(new SqlParameter("Cupo", a.Cupo));
                conexion.Cmd.Parameters.Add(new SqlParameter("Inscritos", a.Inscritos));
                conexion.Cmd.Parameters.Add(new SqlParameter("Apartado", a.Apartado));
                conexion.Cmd.Parameters.Add(new SqlParameter("Categoria", a.Categoria));
                conexion.Cmd.Parameters.Add(new SqlParameter("InstructorId", a.InstructorID));
                conexion.Cmd.Parameters.Add(new SqlParameter("PeriodoId_Inicio", a.PeriodoID_Inicio));
                conexion.Cmd.Parameters.Add(new SqlParameter("PeriodoId_Final", a.PeriodoID_Final));
                conexion.Cmd.Parameters.Add(new SqlParameter("orden", a.Orden));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID)); 
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();
                conexion.Cmd.CommandText = "sp_HrgpGrupoDel ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.ExecuteNonQuery();
                foreach (HorariosGpo x in a.Hrgpo)
                {
                    conexion.Cmd.CommandText = "sp_HrgpGrupoAdd ";
                    conexion.Cmd.Parameters.Clear();
                    conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Dia", x.Dia));
                    conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Hora_Inicio", x.Hora_Inicio));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Hora_Final", x.Hora_Final));
                    conexion.Cmd.Parameters.Add(new SqlParameter("Salon", x.Salon));
                    conexion.Cmd.ExecuteNonQuery();
                }
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
                conexion.Cmd.CommandText = "sp_GrupoDel" ;
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
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

        public void GeneraListas(string a,Dias b,int SucursalID)
        {
            try
            {



                conexion.Cmd.Connection.Open();

                conexion.Cmd.CommandText = "sp_dias";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia1", b.dia[0]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia2", b.dia[1]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia3", b.dia[2]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia4", b.dia[3]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia5", b.dia[4]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia6", b.dia[5]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia7", b.dia[6]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia8", b.dia[7]));
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia9", b.dia[8]));
                conexion.Cmd.Parameters.Add(new SqlParameter("mes", b.mes));
                conexion.Cmd.Parameters.Add(new SqlParameter("año", b.año));

                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();

                conexion.Cmd.CommandText = "sp_GeneraListas";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Dia", a));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", SucursalID));
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

        internal void updateins(Grupos a)
        {
            conexion.Cmd.Connection.Open();
            conexion.Cmd.CommandText = "sp_GrupoAct";
            conexion.Cmd.Parameters.Clear();
            conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.GrupoID));
            conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
            conexion.Cmd.Parameters.Add(new SqlParameter("Duracion", a.Duracion));
            conexion.Cmd.Parameters.Add(new SqlParameter("Salon", a.Salon));
            conexion.Cmd.Parameters.Add(new SqlParameter("Cupo", a.Cupo));
            conexion.Cmd.Parameters.Add(new SqlParameter("Inscritos", a.Inscritos));
            conexion.Cmd.Parameters.Add(new SqlParameter("Apartado", a.Apartado));
            conexion.Cmd.Parameters.Add(new SqlParameter("Categoria", a.Categoria));
            conexion.Cmd.Parameters.Add(new SqlParameter("InstructorId", a.InstructorID));
            conexion.Cmd.Parameters.Add(new SqlParameter("PeriodoId_Inicio", a.PeriodoID_Inicio));
            conexion.Cmd.Parameters.Add(new SqlParameter("PeriodoId_Final", a.PeriodoID_Final));
            conexion.Cmd.Parameters.Add(new SqlParameter("orden", a.Orden));
            conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
            conexion.Cmd.CommandType = CommandType.StoredProcedure;
            conexion.Cmd.ExecuteNonQuery();
            conexion.Cmd.Connection.Close();    
        }
    }
}
