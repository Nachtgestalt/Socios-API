using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Socios.Datos.Catalogos;
using uFacturaEDatos;


namespace Socios.Rest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AquaraLomas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AquaraLomas.svc o AquaraLomas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AquaraLomas : IAquaraLomas
    {
        public void DoWork()
        {
        }
        #region Socios
        #region(Actividades)

        public List<Socios.Datos.Catalogos.Actividades> Actividades_GetActividades()
        {
            Socios.Datos.Catalogos.DAO.ActividadesDAO actividades = new Datos.Catalogos.DAO.ActividadesDAO();
            var lista = actividades.getAll();
            return lista;
        }

        public Actividades Actividades_GetById(Actividades actividades)
        {
            Socios.Datos.Catalogos.DAO.ActividadesDAO actividadesDao = new Datos.Catalogos.DAO.ActividadesDAO();
            var act = actividadesDao.getById(actividades);
            return act;
        }


        public int Actividades_create(Actividades actividades)
        {
            Socios.Datos.Catalogos.DAO.ActividadesDAO actividadesDao = new Datos.Catalogos.DAO.ActividadesDAO();
            int result = 0;
            try
            {
                actividadesDao.create(actividades);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }


        public int Actividades_update(Actividades actividades)
        {
            Socios.Datos.Catalogos.DAO.ActividadesDAO actividadesDao = new Datos.Catalogos.DAO.ActividadesDAO();
            int result = 0;
            try
            {
                actividadesDao.update(actividades);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Actividades_delete(Actividades actividades)
        {
            Socios.Datos.Catalogos.DAO.ActividadesDAO actividadesDao = new Datos.Catalogos.DAO.ActividadesDAO();
            int result = 0;
            try
            {
                actividadesDao.delete(actividades);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(Agrupacion)

        public List<Agrupacion> Agrupacion_GetAgrupaciones()
        {
            Socios.Datos.Catalogos.DAO.AgrupacionDAO agrupaciones = new Datos.Catalogos.DAO.AgrupacionDAO();
            var lista = agrupaciones.getAll();
            return lista;
        }

        public Agrupacion Agrupacion_GetByIdI(Agrupacion agrupacion)
        {
            Socios.Datos.Catalogos.DAO.AgrupacionDAO agrupacionDao = new Datos.Catalogos.DAO.AgrupacionDAO();
            var agr = agrupacionDao.getById(agrupacion);
            return agr;
        }

        public int Agrupacion_create(Agrupacion agrupacion)
        {
            Socios.Datos.Catalogos.DAO.AgrupacionDAO agrupacionDao = new Datos.Catalogos.DAO.AgrupacionDAO();
            int result = 0;
            try
            {
                agrupacionDao.create(agrupacion);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Agrupacion_update(Agrupacion agrupacion)
        {
            Socios.Datos.Catalogos.DAO.AgrupacionDAO agrupacionDao = new Datos.Catalogos.DAO.AgrupacionDAO();
            int result = 0;
            try
            {
                agrupacionDao.update(agrupacion);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Agrupacion_delete(Agrupacion agrupacion)
        {
            Socios.Datos.Catalogos.DAO.AgrupacionDAO agrupacionDao = new Datos.Catalogos.DAO.AgrupacionDAO();
            int result = 0;
            try
            {
                agrupacionDao.delete(agrupacion);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(Categorias)

        public List<Categorias> Categorias_GetCategorias()
        {
            Socios.Datos.Catalogos.DAO.CategoriasDAO categorias = new Datos.Catalogos.DAO.CategoriasDAO();
            var lista = categorias.getAll();
            return lista;
        }

        public int Categorias_Nuevo()
        {
            Socios.Datos.Catalogos.DAO.CategoriasDAO categorias = new Datos.Catalogos.DAO.CategoriasDAO();
            int categoid = categorias.Nuevo();
            return categoid;
        }

        public Categorias Categorias_GetById(Categorias categoria)
        {
            Socios.Datos.Catalogos.DAO.CategoriasDAO categorias = new Datos.Catalogos.DAO.CategoriasDAO();
            var cat = categorias.getById(categoria);
            return cat;
        }

        public Categorias Categorias_GetByOrden(Categorias categoria)
        {
            Socios.Datos.Catalogos.DAO.CategoriasDAO categorias = new Datos.Catalogos.DAO.CategoriasDAO();
            var cat = categorias.getById(categoria);
            return cat;
        }

        public int Categorias_create(Categorias categoria)
        {
            Socios.Datos.Catalogos.DAO.CategoriasDAO categorias = new Datos.Catalogos.DAO.CategoriasDAO();
            int result = 0;
            try
            {
                categorias.create(categoria);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Categorias_update(Categorias categoria)
        {
            Socios.Datos.Catalogos.DAO.CategoriasDAO categorias = new Datos.Catalogos.DAO.CategoriasDAO();
            int result = 0;
            try
            {
                categorias.update(categoria);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Categorias_delete(Categorias categoria)
        {
            Socios.Datos.Catalogos.DAO.CategoriasDAO categorias = new Datos.Catalogos.DAO.CategoriasDAO();
            int result = 0;
            try
            {
                categorias.delete(categoria);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(DatoSFactura)

        public List<DatosFactura> DatosFactura_GetDatosFactura()
        {
            Socios.Datos.Catalogos.DAO.DatosFacturaDAO datos = new Datos.Catalogos.DAO.DatosFacturaDAO();
            var lista = datos.getAll();
            return lista;
        }

        public DatosFactura DatosFactura_GetById(DatosFactura factura)
        {
            Socios.Datos.Catalogos.DAO.DatosFacturaDAO datos = new Datos.Catalogos.DAO.DatosFacturaDAO();
            var fac = datos.getById(factura);
            return fac;
        }

        public int DatosFactura_create(DatosFactura factura)
        {
            Socios.Datos.Catalogos.DAO.DatosFacturaDAO datos = new Datos.Catalogos.DAO.DatosFacturaDAO();
            int result = 0;
            try
            {
                datos.create(factura);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int DatosFactura_update(DatosFactura factura)
        {
            Socios.Datos.Catalogos.DAO.DatosFacturaDAO datos = new Datos.Catalogos.DAO.DatosFacturaDAO();
            int result = 0;
            try
            {
                datos.update(factura);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }



        #endregion

        #region(Deportes)

        public List<Deportes> Deportes_GetDeportes()
        {
            Socios.Datos.Catalogos.DAO.DeportesDAO deportes = new Datos.Catalogos.DAO.DeportesDAO();
            var lista = deportes.getAll();
            return lista;
        }

        public Deportes Deportes_GetById(Deportes deporte)
        {
            Socios.Datos.Catalogos.DAO.DeportesDAO deportes = new Datos.Catalogos.DAO.DeportesDAO();
            var lista = deportes.getById(deporte);
            return lista;
        }

        public Deportes Deportes_GetByOrden(Deportes deporte)
        {
            Socios.Datos.Catalogos.DAO.DeportesDAO deportes = new Datos.Catalogos.DAO.DeportesDAO();
            var lista = deportes.getByNombre(deporte);
            return lista;
        }

        public int Deportes_create(Deportes deporte)
        {
            Socios.Datos.Catalogos.DAO.DeportesDAO deportes = new Datos.Catalogos.DAO.DeportesDAO();
            int result = 0;
            try
            {
                deportes.create(deporte);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Deportes_update(Deportes deporte)
        {
            Socios.Datos.Catalogos.DAO.DeportesDAO deportes = new Datos.Catalogos.DAO.DeportesDAO();
            int result = 0;
            try
            {
                deportes.update(deporte);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Deportes_delete(Deportes deporte)
        {
            Socios.Datos.Catalogos.DAO.DeportesDAO deportes = new Datos.Catalogos.DAO.DeportesDAO();
            int result = 0;
            try
            {
                deportes.delete(deporte);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(Grupos)

        public List<GruposDetalle> Grupos_GetAlumnos(string grupoId)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            var lista = grupos.obtenAlumnos(grupoId);
            return lista;
        }

        public List<GruposListado> Grupos_GetListado(int sucursalId)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            var lista = grupos.GetListado(sucursalId);
            return lista;
        }

        public List<GruposHoraDistinct> Grupos_GetHorario(int sucursalId)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            var lista = grupos.GetHorario(sucursalId);
            return lista;
        }

        public List<GruposListado> Grupos_GetGrupos(int sucursalId)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            var lista = grupos.getAll(sucursalId);
            return lista;
        }

        public List<GruposHorario> Grupos_ObtenerHorario(string grupoId)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            var lista = grupos.obtenHorario(grupoId);
            return lista;
        }

        public Grupos Grupos_GetById(Grupos grupo)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            var lista = grupos.getById(grupo);
            return lista;
        }

        public int Grupos_create(Grupos grupo)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            int result = 0;
            try
            {
                grupos.create(grupo);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Grupos_update(Grupos grupo)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            int result = 0;
            try
            {
                grupos.update(grupo);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Grupos_delete(Grupos grupo)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            int result = 0;
            try
            {
                grupos.delete(grupo);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Grupos_GeneraListas(string v_a, Dias v_b, int sucursalId)
        {
            Socios.Datos.Catalogos.DAO.GruposDAO grupos = new Datos.Catalogos.DAO.GruposDAO();
            int result = 0;
            try
            {
                grupos.GeneraListas(v_a, v_b, sucursalId);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }




        #endregion

        #region(HorariosGrupos)


        public List<HorariosGpo> HorarioGrupos_GetHorarioGrupos()
        {
            Socios.Datos.Catalogos.DAO.HorarioGruposDAO horarios = new Datos.Catalogos.DAO.HorarioGruposDAO();
            var lista = horarios.getAll();
            return lista;
        }

        public HorariosGpo HorarioGrupos_GetByIdI(HorariosGpo horario)
        {
            Socios.Datos.Catalogos.DAO.HorarioGruposDAO horarios = new Datos.Catalogos.DAO.HorarioGruposDAO();
            var act = horarios.getById(horario);
            return act;
        }

        public int HorarioGrupos_create(HorariosGpo horario)
        {
            Socios.Datos.Catalogos.DAO.HorarioGruposDAO horarios = new Datos.Catalogos.DAO.HorarioGruposDAO();
            int result = 0;
            try
            {
                horarios.create(horario);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int HorarioGrupos_update(HorariosGpo horario)
        {
            Socios.Datos.Catalogos.DAO.HorarioGruposDAO horarios = new Datos.Catalogos.DAO.HorarioGruposDAO();
            int result = 0;
            try
            {
                horarios.update(horario);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int HorarioGrupos_delete(HorariosGpo horario)
        {
            Socios.Datos.Catalogos.DAO.HorarioGruposDAO horarios = new Datos.Catalogos.DAO.HorarioGruposDAO();
            int result = 0;
            try
            {
                horarios.delete(horario);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(Instructores)

        public List<Instructores> Instructoress_GetInstructores(string sucursalId)
        {
            Socios.Datos.Catalogos.DAO.InstructoresDAO instructores = new Datos.Catalogos.DAO.InstructoresDAO();
            var lista = instructores.getAll(int.Parse(sucursalId));
            return lista;
        }

        public Instructores Instructores_GetByIdI(Instructores instructor)
        {
            Socios.Datos.Catalogos.DAO.InstructoresDAO instructores = new Datos.Catalogos.DAO.InstructoresDAO();
            var act = instructores.getById(instructor);
            return act;
        }

        public int Instructores_create(Instructores instructor)
        {
            Socios.Datos.Catalogos.DAO.InstructoresDAO instructores = new Datos.Catalogos.DAO.InstructoresDAO();
            int result = 0;
            try
            {
                instructores.create(instructor);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Instructores_update(Instructores instructor)
        {
            Socios.Datos.Catalogos.DAO.InstructoresDAO instructores = new Datos.Catalogos.DAO.InstructoresDAO();
            int result = 0;
            try
            {
                instructores.update(instructor);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Instructores_delete(Instructores instructor)
        {
            Socios.Datos.Catalogos.DAO.InstructoresDAO instructores = new Datos.Catalogos.DAO.InstructoresDAO();
            int result = 0;
            try
            {
                instructores.delete(instructor);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(Nomina)

        public int Nomina_create(Nomina nomina)
        {
            Socios.Datos.Catalogos.DAO.NominaDAO nominas = new Datos.Catalogos.DAO.NominaDAO();
            int result = 0;
            try
            {
                nominas.create(nomina);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(Socios)

        public List<SocioListado> Socios_GetListado(string sucursalId)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            var lista = socios.GetListado(int.Parse(sucursalId));
            return lista;
        }

        public List<SocioListado> Socios_GetListadoE(int sucursalId)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            var lista = socios.GetListadoE(sucursalId);
            return lista;
        }

        public List<SocioListado> Socios_GetListadoEC(int sucursalId, int socioIni, int socioFin, int socioLun, int socioMar, int socioMie, int socioJue, int socioVie, int socioSab)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            var lista = socios.GetListadoEC(sucursalId, socioIni, socioFin, socioLun, socioMar, socioMie, socioJue, socioVie, socioSab);
            return lista;
        }

        public List<SocioAsistencias> Socios_ObtenAsistencias(int socioId, int sucursalId, int mes, int anio)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            var lista = socios.obtenAsitencias(socioId, sucursalId, mes, anio);
            return lista;
        }

        public List<SociosHorario> Socios_ObtenHorario(string socioId, int sucursalId)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            var lista = socios.obtenHorario(socioId, sucursalId);
            return lista;
        }

        public List<SociosHorariodet> Socios_ObtenHorarioDet(string socioId, int sucursalId)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            var lista = socios.obtenHorarioDet(socioId, sucursalId);
            return lista;
        }

        public Socio Socios_GetByIdI(Socio socio)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            var soc = socios.getById(socio);
            return soc;
        }

        public int Socios_create(Socio socio)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            int result = 0;
            try
            {
                result = socios.create(socio);
                //result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Socios_update(Socio socio)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            int result = 0;
            try
            {
                socios.update(socio);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Socios_delete(Socio socio)
        {
            Socios.Datos.Catalogos.DAO.SociosDAO socios = new Datos.Catalogos.DAO.SociosDAO();
            int result = 0;
            try
            {
                socios.delete(socio);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion

        #region(Sucursal)



        public List<Sucursal> Sucursal_GetSucursales()
        {
            Socios.Datos.Catalogos.DAO.sucursalDAO sucursales = new Datos.Catalogos.DAO.sucursalDAO();
            var lista = sucursales.getAll();
            return lista;
        }

        public Sucursal Sucursal_GetById(Sucursal sucursales)
        {
            Socios.Datos.Catalogos.DAO.sucursalDAO sucursalesDao = new Datos.Catalogos.DAO.sucursalDAO();
            var act = sucursalesDao.getById(sucursales);
            return act;
        }

        #endregion

        #region(Usuarios)


        public List<Usuarios> Usuarios_GetUsuarios()
        {
            Socios.Datos.Catalogos.DAO.UsuariosDAO usuarios = new Datos.Catalogos.DAO.UsuariosDAO();
            var lista = usuarios.getAll();
            return lista;
        }

        public Usuarios Usuarios_GetById(Usuarios usuario)
        {
            Socios.Datos.Catalogos.DAO.UsuariosDAO usuarios = new Datos.Catalogos.DAO.UsuariosDAO();
            var usu = usuarios.getById(usuario);
            return usu;
        }

        public Usuarios Usuarios_GetByNombre(Usuarios usuario)
        {
            Socios.Datos.Catalogos.DAO.UsuariosDAO usuarios = new Datos.Catalogos.DAO.UsuariosDAO();
            var usu = usuarios.getByNombre(usuario);
            return usu;
        }

        public int Usuarios_create(Usuarios usuario)
        {
            Socios.Datos.Catalogos.DAO.UsuariosDAO usuarios = new Datos.Catalogos.DAO.UsuariosDAO();
            int result = 0;
            try
            {
                usuarios.create(usuario);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Usuarios_update(Usuarios usuario)
        {
            Socios.Datos.Catalogos.DAO.UsuariosDAO usuarios = new Datos.Catalogos.DAO.UsuariosDAO();
            int result = 0;
            try
            {
                usuarios.update(usuario);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        public int Usuarios_delete(Usuarios usuario)
        {
            Socios.Datos.Catalogos.DAO.UsuariosDAO usuarios = new Datos.Catalogos.DAO.UsuariosDAO();
            int result = 0;
            try
            {
                usuarios.delete(usuario);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }
        #endregion
        #endregion


        #region Operaciones
        #region (Abonos)
        public bool AbonosSave(Cuentas_Por_Cobrar abono)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Abonos.Abono oAbono = new uFacturaEDatos.Operaciones.Abonos.Abono();
                bRes = oAbono.Guardar(abono);
            }
            catch (Exception _X)
            {
                bRes = false;
            }
            return bRes;
        }

        #endregion
        #region (Actividades)

        public List<C_Areas> ActividadesGetAll()
        {
            List<C_Areas> lstAreas = new List<C_Areas>();
            try
            {
                uFacturaEDatos.Operaciones.Actividades.Actividad actividad = new uFacturaEDatos.Operaciones.Actividades.Actividad();
                lstAreas = actividad.ObtenLista();
            }
            catch (Exception _x)
            {

                throw;
            }
            return lstAreas;
        }

        public C_Areas ActividadesGet(C_Areas documento)
        {
            C_Areas c_Areas = new C_Areas();
            try
            {
                uFacturaEDatos.Operaciones.Actividades.Actividad actividad = new uFacturaEDatos.Operaciones.Actividades.Actividad();
                c_Areas = actividad.Obten(documento);
            }
            catch (Exception _X)
            {

                throw;
            }
            return c_Areas;
        }

        public bool ActividadesEliminar(C_Areas area)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Actividades.Actividad actividad = new uFacturaEDatos.Operaciones.Actividades.Actividad();
                bRes = actividad.Eliminar(area);
            }
            catch (Exception _x)
            {

                throw;
            }
            return bRes;
        }

        public bool ActividadesGuardar(C_Areas area)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Actividades.Actividad actividad = new uFacturaEDatos.Operaciones.Actividades.Actividad();
                bRes = actividad.Guardar(area);
            }
            catch (Exception _x)
            {

                throw;
            }
            return bRes;
        }




        #endregion
        #region (Documento)
        public bool GuardarActividadDocto(C_AreasDocumentos documento)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.ActividadesDoc.Documento oDocto = new uFacturaEDatos.Operaciones.ActividadesDoc.Documento();
                bRes = oDocto.Guardar(documento);
            }
            catch (Exception _x)
            {

                throw;
            }
            return bRes;
        }

        public bool EliminarActividadDocto(C_AreasDocumentos documento)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.ActividadesDoc.Documento oDocto = new uFacturaEDatos.Operaciones.ActividadesDoc.Documento();
                bRes = oDocto.Eliminar(documento);
            }
            catch (Exception _x)
            {

                throw;
            }
            return bRes;
        }

        public C_AreasDocumentos ObtenActividadDocto(C_AreasDocumentos documento)
        {
            C_AreasDocumentos area = new C_AreasDocumentos();
            try
            {
                uFacturaEDatos.Operaciones.ActividadesDoc.Documento oDocto = new uFacturaEDatos.Operaciones.ActividadesDoc.Documento();
                area = oDocto.Obten(documento);
            }
            catch (Exception _x)
            {

                throw;
            }
            return area;
        }

        public List<C_AreasDocumentos> ObtenListaActividadDocto(C_AreasDocumentos area)
        {
            List<C_AreasDocumentos> lstArea = new List<C_AreasDocumentos>();
            try
            {
                uFacturaEDatos.Operaciones.ActividadesDoc.Documento oDocto = new uFacturaEDatos.Operaciones.ActividadesDoc.Documento();
                lstArea = oDocto.ObtenLista(area);
            }
            catch (Exception _x)
            {


            }
            return lstArea;
        }


        #endregion

        #region (Agrupacion)
        public bool GuardarAgrupacion(T_Agrupacion agrupa)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Agrupacion.Agrupacion agrupacion = new uFacturaEDatos.Operaciones.Agrupacion.Agrupacion();
                bRes = agrupacion.Guardar(agrupa);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool EliminarAgrupacion(T_Agrupacion agrupa)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Agrupacion.Agrupacion agrupacion = new uFacturaEDatos.Operaciones.Agrupacion.Agrupacion();
                bRes = agrupacion.Eliminar(agrupa);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Agrupacion ObtenAgrupacion(T_Agrupacion agrupacion)
        {
            T_Agrupacion a = new T_Agrupacion();
            try
            {
                uFacturaEDatos.Operaciones.Agrupacion.Agrupacion agr = new uFacturaEDatos.Operaciones.Agrupacion.Agrupacion();
                a = agr.Obten(agrupacion);
            }
            catch (Exception _x)
            {

            }
            return a;
        }

        public T_Agrupacion ObtenFAgrupacion(T_Agrupacion agrupacion)
        {
            T_Agrupacion a = new T_Agrupacion();
            try
            {
                uFacturaEDatos.Operaciones.Agrupacion.Agrupacion agr = new uFacturaEDatos.Operaciones.Agrupacion.Agrupacion();
                a = agr.ObtenF(agrupacion);
            }
            catch (Exception _x)
            {

            }
            return a;
        }

        public T_Agrupacion ObtenSAgrupacion(T_Agrupacion agrupacion)
        {
            T_Agrupacion a = new T_Agrupacion();
            try
            {
                uFacturaEDatos.Operaciones.Agrupacion.Agrupacion agr = new uFacturaEDatos.Operaciones.Agrupacion.Agrupacion();
                a = agr.ObtenS(agrupacion);
            }
            catch (Exception _x)
            {

            }
            return a;
        }

        public List<uFacturaEDatos.Operaciones.Agrupacion.AgrupacionN> ObtenDatosAgrupacion(decimal AgrupaID, int SucursalID)
        {
            List<uFacturaEDatos.Operaciones.Agrupacion.AgrupacionN> a = new List<uFacturaEDatos.Operaciones.Agrupacion.AgrupacionN>();
            try
            {
                uFacturaEDatos.Operaciones.Agrupacion.Agrupacion agr = new uFacturaEDatos.Operaciones.Agrupacion.Agrupacion();
                a = agr.ObtenDatos(AgrupaID, SucursalID);
            }
            catch (Exception _x)
            {

            }
            return a;
        }

        public List<T_Agrupacion> ObtenListaAgrupacion(int SocioID)
        {
            List<T_Agrupacion> lstAgr = new List<T_Agrupacion>();
            try
            {
                uFacturaEDatos.Operaciones.Agrupacion.Agrupacion a = new uFacturaEDatos.Operaciones.Agrupacion.Agrupacion();
                lstAgr = a.ObtenLista(SocioID);
            }
            catch (Exception _x)
            {

            }
            return lstAgr;
        }




        #endregion
        #region (Bitacora)

        public bool Guardar(T_Bitacora bitacora)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Bitacora.Bitacora b = new uFacturaEDatos.Operaciones.Bitacora.Bitacora();
                bRes = b.Guardar(bitacora);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Eliminar(T_Bitacora bitacora)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Bitacora.Bitacora b = new uFacturaEDatos.Operaciones.Bitacora.Bitacora();
                bRes = b.Eliminar(bitacora);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Bitacora Obten(T_Bitacora bitacora)
        {
            T_Bitacora b = new T_Bitacora();
            try
            {
                uFacturaEDatos.Operaciones.Bitacora.Bitacora oBitacora = new uFacturaEDatos.Operaciones.Bitacora.Bitacora();
                b = oBitacora.Obten(bitacora);
            }
            catch (Exception _x)
            {

            }
            return b;
        }

        public List<T_Bitacora> ObtenLista(int UserID, DateTime Fecini, DateTime FecFin)
        {
            List<T_Bitacora> lstBit = new List<T_Bitacora>();
            try
            {
                uFacturaEDatos.Operaciones.Bitacora.Bitacora b = new uFacturaEDatos.Operaciones.Bitacora.Bitacora();
                lstBit = b.ObtenLista(UserID, Fecini, FecFin);
            }
            catch (Exception _x)
            {

            }
            return lstBit;
        }


        #endregion
        #region (Aduanas)
        public List<uFacturaEDatos.DatosSat.c_AduanaRow> GetAduanas()
        {
            List<uFacturaEDatos.DatosSat.c_AduanaRow> lst = new List<DatosSat.c_AduanaRow>();
            try
            {
                uFacturaEDatos.Operaciones.C_Aduana.CAduana cAduana = new uFacturaEDatos.Operaciones.C_Aduana.CAduana();
                lst = cAduana.GetAduanas();
            }
            catch (Exception _x)
            {

            }
            return lst;
        }
        #endregion
        #region (ClaveProdServ)
        public  List<uFacturaEDatos.DatosSat.c_ClaveProdServRow> GetClaveProdServ()
        {
            List<uFacturaEDatos.DatosSat.c_ClaveProdServRow> oClave = new List<DatosSat.c_ClaveProdServRow>();
            try
            {
                uFacturaEDatos.Operaciones.C_ClaveProdServ.CClaveProdServ C = new uFacturaEDatos.Operaciones.C_ClaveProdServ.CClaveProdServ();
                oClave = C.GetClaveProdServ();
            }
            catch (Exception _x)
            {

            }
            return oClave;
        }
        #endregion
        #region (ClaveUnidad)
        public List<uFacturaEDatos.DatosSat.c_ClaveUnidadRow> GetClaveUnidad()
        {
            List<uFacturaEDatos.DatosSat.c_ClaveUnidadRow> list = new List<DatosSat.c_ClaveUnidadRow>();
            try
            {
                uFacturaEDatos.Operaciones.C_ClaveUnidad.CClaveUnidad clave = new uFacturaEDatos.Operaciones.C_ClaveUnidad.CClaveUnidad();
                list = clave.GetClaveUnidad();
            }
            catch (Exception _x)
            {

            }

            return list;
        }
        #endregion
        #region (FormaPago)
        public List<uFacturaEDatos.DatosSat.c_FormaPagoRow> GetFormaPago()
        {
            List<uFacturaEDatos.DatosSat.c_FormaPagoRow> list = new List<DatosSat.c_FormaPagoRow>();
            try
            {
                uFacturaEDatos.Operaciones.C_FormaPago.CFormaPago formaPago = new uFacturaEDatos.Operaciones.C_FormaPago.CFormaPago();
                list = formaPago.GetFormaPago();
            }
            catch (Exception _x)
            {

            }
            return list;
        }
        #endregion
        #region (MetodoPago)

        public string GetDescripcion(string clave)
        {
            string res = string.Empty;
            try
            {
                uFacturaEDatos.Operaciones.C_Metodo.CMetodPago m = new uFacturaEDatos.Operaciones.C_Metodo.CMetodPago();

                res = m.GetDescripcion(clave);
            }
            catch (Exception _x)
            {

            }
            return res;
        }
        public string GetMetodoPago()
        {
            string list = string.Empty;
            try
            {
                uFacturaEDatos.Operaciones.C_Metodo.CMetodPago m = new uFacturaEDatos.Operaciones.C_Metodo.CMetodPago();
                list = m.GetMetodoPago();
            }
            catch (Exception _x)
            {

            }
            return list;
        }

        #endregion
        #region (RegimanFiscal)
        public string Regimen(string clave)
        {
            string res = string.Empty;
            try
            {
                uFacturaEDatos.Operaciones.C_RegimenFiscal.CRegimenFiscal reg = new uFacturaEDatos.Operaciones.C_RegimenFiscal.CRegimenFiscal();
                res = reg.Regimen(clave);
            }
            catch (Exception _x)
            {

            }
            return res;
        }

        public List<uFacturaEDatos.DatosSat.c_RegimenFiscalRow> GetRegimenFiscal()
        {
            List<uFacturaEDatos.DatosSat.c_RegimenFiscalRow> list = new List<DatosSat.c_RegimenFiscalRow>();
            try
            {
                uFacturaEDatos.Operaciones.C_RegimenFiscal.CRegimenFiscal reg = new uFacturaEDatos.Operaciones.C_RegimenFiscal.CRegimenFiscal();
                list = reg.GetRegimenFiscal();
            }
            catch (Exception _x)
            {

            }
            return list;
        }
        #endregion
        //

        #region(UsoCFDI)

        public string UsoCFDI_GetDescr(string clave)
        {
            string res = string.Empty;
            try
            {
                uFacturaEDatos.Operaciones.C_UsoCFDI.CUsoCFDI reg = new uFacturaEDatos.Operaciones.C_UsoCFDI.CUsoCFDI();
                res = reg.GetDescr(clave);
            }
            catch (Exception _x)
            {

            }
            return res;
        }

        public string UsoCFDI_GetUsoCFDI()
        {
            string list = string.Empty;
            try
            {
                uFacturaEDatos.Operaciones.C_UsoCFDI.CUsoCFDI reg = new uFacturaEDatos.Operaciones.C_UsoCFDI.CUsoCFDI();
                list = reg.GetUsoCFDI();
            }
            catch (Exception _x)
            {
               

            }
            return list;
        }

        #endregion
        #region(CajaChica)
        public bool CajaChica_Guardar(T_CChica cCajaChica)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.CajaChica.CajaChica caja = new uFacturaEDatos.Operaciones.CajaChica.CajaChica();
                bRes = caja.Guardar(cCajaChica);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool CajaChica_Eliminar(T_CChica cCajaChica)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.CajaChica.CajaChica caja = new uFacturaEDatos.Operaciones.CajaChica.CajaChica();
                bRes = caja.Eliminar(cCajaChica);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool CajaChica_GuardarCaja(List<T_CChica> caja)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.CajaChica.CajaChica c = new uFacturaEDatos.Operaciones.CajaChica.CajaChica();
                bRes = c.GuardaCaja(caja);
            }
            catch (Exception _x)
            {

            }
            return bRes;

        }
        #endregion
        #region(Calificaciones)

        public bool Calificaciones_Guardar(C_Calificaciones califica, short categoriaId)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Calificaciones.Calificacion cal = new uFacturaEDatos.Operaciones.Calificaciones.Calificacion();
                bRes = cal.Guardar(califica, categoriaId);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Calificaciones_Eliminar(C_Calificaciones califica)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Calificaciones.Calificacion cal = new uFacturaEDatos.Operaciones.Calificaciones.Calificacion();
                bRes = cal.Eliminar(califica);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public C_Calificaciones Calificaciones_Obten(C_Calificaciones califica)
        {
            C_Calificaciones c = new C_Calificaciones();
            try
            {
                uFacturaEDatos.Operaciones.Calificaciones.Calificacion cal = new uFacturaEDatos.Operaciones.Calificaciones.Calificacion();
                c = cal.Obten(califica);
            }
            catch (Exception _x)
            {

            }
            return c;
        }

        public List<uFacturaEDatos.Operaciones.Calificaciones.CalificacionesExa> Calificaciones_ObtenLista(int socioId, int sucursalId)
        {
            List<uFacturaEDatos.Operaciones.Calificaciones.CalificacionesExa> lstcal = new List<uFacturaEDatos.Operaciones.Calificaciones.CalificacionesExa>();
            try
            {
                uFacturaEDatos.Operaciones.Calificaciones.Calificacion cal = new uFacturaEDatos.Operaciones.Calificaciones.Calificacion();
                lstcal = cal.ObtenLista(socioId, sucursalId);
            }
            catch (Exception _x)
            {

            }
            return lstcal;
        }
        #endregion
        #region(CDocumentos)

        public bool CDocumentos_Guardar(C_Documentos documento)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.CDocumentos.Documento oDocto = new uFacturaEDatos.Operaciones.CDocumentos.Documento();
                bRes = oDocto.Guardar(documento);
            }
            catch (Exception _x)
            {

                throw;
            }
            return bRes;
        }

        public bool CDocumentos_Eliminar(C_Documentos documento)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.CDocumentos.Documento oDocto = new uFacturaEDatos.Operaciones.CDocumentos.Documento();
                bRes = oDocto.Eliminar(documento);
            }
            catch (Exception _x)
            {

                throw;
            }
            return bRes;
        }

        public C_Documentos CDocumentos_Obten(C_Documentos documento)
        {
            C_Documentos docto = new C_Documentos();
            try
            {
                uFacturaEDatos.Operaciones.CDocumentos.Documento oDocto = new uFacturaEDatos.Operaciones.CDocumentos.Documento();
                docto = oDocto.Obten(documento);
            }
            catch (Exception _x)
            {

                throw;
            }
            return docto;
        }

        public List<C_Documentos> CDocumentos_ObtenLista()
        {
            List<C_Documentos> lstDoctos = new List<C_Documentos>();
            try
            {
                uFacturaEDatos.Operaciones.CDocumentos.Documento oDocto = new uFacturaEDatos.Operaciones.CDocumentos.Documento();
                lstDoctos = oDocto.ObtenLista();
            }
            catch (Exception _x)
            {


            }
            return lstDoctos;
        }

        #endregion
        #region(CodigosPostales)

        public List<CodigosPostale> CodigosPostales_ConsultaCP(int codePostal)
        {
            List<CodigosPostale> lstCodes = new List<CodigosPostale>();
            try
            {
                uFacturaEDatos.Operaciones.Codigos_Postales.CodigoPostal codigosP = new uFacturaEDatos.Operaciones.Codigos_Postales.CodigoPostal();
                lstCodes = codigosP.ConsultaCP(codePostal);
            }
            catch (Exception _x)
            {


            }
            return lstCodes;
        }

        #endregion
        #region(Comprobantes)

        public bool Comprobantes_Guardar(Comprobante comprobante, uFacturaEDatos.Operaciones.Recibo.Recibos recibo)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                bRes = comp.Guardar(comprobante, recibo);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Comprobantes_Eliminar(Comprobante comprobante)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                bRes = comp.Eliminar(comprobante);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public Comprobante Comprobantes_Obten(Comprobante comprobante)
        {
            Comprobante co = new Comprobante();
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                co = comp.Obten(comprobante);
            }
            catch (Exception _x)
            {

            }
            return co;
        }

        public List<Comprobante> Comprobantes_ObtenLista(Sucursales sucursal)
        {
            List<Comprobante> lstCo = new List<Comprobante>();
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                lstCo = comp.ObtenLista(sucursal);
            }
            catch (Exception _x)
            {

            }
            return lstCo;
        }

        public List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos> Comprobantes_Reporte_ComprobantesC(int idsucursal, DateTime fecha, bool mes)
        {
            List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos> lstCo = new List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos>();
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                lstCo = comp.Reporte_ComprobantesC(idsucursal, fecha, mes);
            }
            catch (Exception _x)
            {

            }
            return lstCo;
        }

        public List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos> Comprobantes_Reporte_Comprobantes(int idsucursal, DateTime fecha, bool mes)
        {
            List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos> lstCo = new List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos>();
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                lstCo = comp.Reporte_Comprobantes(idsucursal, fecha, mes);
            }
            catch (Exception _x)
            {

            }
            return lstCo;
        }

        public List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidosDetalle> Comprobantes_Reporte_Comprobantes_Detalle(int idsucursal, DateTime fecha, bool mes)
        {
            List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidosDetalle> lstCo = new List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidosDetalle>();
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                lstCo = comp.Reporte_Comprobantes_Detalle(idsucursal, fecha, mes);
            }
            catch (Exception _x)
            {

            }
            return lstCo;
        }

        public List<uFacturaEDatos.Operaciones.Comprobantes.ReporteCobranza> Comprobantes_Reporte_Cobranza(int idsucursal)
        {
            List<uFacturaEDatos.Operaciones.Comprobantes.ReporteCobranza> lstCo = new List<uFacturaEDatos.Operaciones.Comprobantes.ReporteCobranza>();
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                lstCo = comp.Reporte_Cobranza(idsucursal);
            }
            catch (Exception _x)
            {

            }
            return lstCo;
        }

        public List<uFacturaEDatos.Operaciones.Comprobantes.ReporteAbonos> Comprobantes_Reporte_Abonos(int idcomprobante)
        {
            List<uFacturaEDatos.Operaciones.Comprobantes.ReporteAbonos> lstCo = new List<uFacturaEDatos.Operaciones.Comprobantes.ReporteAbonos>();
            try
            {
                uFacturaEDatos.Operaciones.Comprobantes.Comprobante comp = new uFacturaEDatos.Operaciones.Comprobantes.Comprobante();
                lstCo = comp.Reporte_Abonos(idcomprobante);
            }
            catch (Exception _x)
            {

            }
            return lstCo;
        }

        #endregion
        #region(Concepto)

        public bool Concepto_Guardar(T_Conceptos concepto)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Conceptos.Concepto con = new uFacturaEDatos.Operaciones.Conceptos.Concepto();
                bRes = con.Guardar(concepto);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Concepto_Eliminar(T_Conceptos concepto)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Conceptos.Concepto con = new uFacturaEDatos.Operaciones.Conceptos.Concepto();
                bRes = con.Eliminar(concepto);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Conceptos Concepto_Obten(T_Conceptos concepto)
        {
            T_Conceptos b = new T_Conceptos();
            try
            {
                uFacturaEDatos.Operaciones.Conceptos.Concepto con = new uFacturaEDatos.Operaciones.Conceptos.Concepto();
                b = con.Obten(concepto);
            }
            catch (Exception _x)
            {

            }
            return b;
        }

        public T_Conceptos Concepto_ObtenMax()
        {
            T_Conceptos b = new T_Conceptos();
            try
            {
                uFacturaEDatos.Operaciones.Conceptos.Concepto con = new uFacturaEDatos.Operaciones.Conceptos.Concepto();
                b = con.ObtenMax();
            }
            catch (Exception _x)
            {

            }
            return b;
        }

        public List<T_Conceptos> Concepto_ObtenLista()
        {
            List<T_Conceptos> lisCon = new List<T_Conceptos>();
            try
            {
                uFacturaEDatos.Operaciones.Conceptos.Concepto con = new uFacturaEDatos.Operaciones.Conceptos.Concepto();
                lisCon = con.ObtenLista();
            }
            catch (Exception _x)
            {

            }
            return lisCon;
        }

        #endregion
        #region(Cuotas)

        public bool Cuotas_Guardar(T_Cuotas cuota)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Cuotas.Cuotas c = new uFacturaEDatos.Operaciones.Cuotas.Cuotas();
                bRes = c.Guardar(cuota);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Cuotas_Eliminar(T_Cuotas cuota)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Cuotas.Cuotas c = new uFacturaEDatos.Operaciones.Cuotas.Cuotas();
                bRes = c.Eliminar(cuota);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Cuotas Cuotas_Obten(T_Cuotas cuota)
        {
            T_Cuotas resCuo = new T_Cuotas();
            try
            {
                uFacturaEDatos.Operaciones.Cuotas.Cuotas c = new uFacturaEDatos.Operaciones.Cuotas.Cuotas();
                resCuo = c.Obten(cuota);
            }
            catch (Exception _x)
            {

            }
            return resCuo;
        }

        public List<T_Cuotas> Cuotas_ObtenLista(int socioId, int sucursalId)
        {
            List<T_Cuotas> resLisCuo = new List<T_Cuotas>();
            try
            {
                uFacturaEDatos.Operaciones.Cuotas.Cuotas c = new uFacturaEDatos.Operaciones.Cuotas.Cuotas();
                resLisCuo = c.ObtenLista(socioId, sucursalId);
            }
            catch (Exception _x)
            {

            }
            return resLisCuo;
        }

        public int Cuotas_CreaCuotas(int socioId, int mes, int año, bool nuevo, int sucursalId, bool anual)
        {

            int result = 0;
            try
            {
                uFacturaEDatos.Operaciones.Cuotas.Cuotas c = new uFacturaEDatos.Operaciones.Cuotas.Cuotas();
                c.creacuotas(socioId, mes, año, nuevo, sucursalId, anual);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return result;
        }

        #endregion
        #region(Documentos)

        public bool Documentos_Guardar(Documento documento)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Documentos.Documento doc = new uFacturaEDatos.Operaciones.Documentos.Documento();
                bRes = doc.Guardar(documento);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Documentos_Eliminar(Documento documento)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Documentos.Documento doc = new uFacturaEDatos.Operaciones.Documentos.Documento();
                bRes = doc.Eliminar(documento);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public Documento Documentos_ObtenD(Documento documento)
        {
            Documento resDoc = new Documento();
            try
            {
                uFacturaEDatos.Operaciones.Documentos.Documento doc = new uFacturaEDatos.Operaciones.Documentos.Documento();
                resDoc = doc.Obten(documento);
            }
            catch (Exception _x)
            {

            }
            return resDoc;
        }

        public Documento Documentos_Obten(int idFormato, Sucursales sucursal)
        {
            Documento resDoc = new Documento();
            try
            {

                uFacturaEDatos.Operaciones.Documentos.Documento doc = new uFacturaEDatos.Operaciones.Documentos.Documento();
                resDoc = doc.Obten(idFormato, sucursal);
            }
            catch (Exception _x)
            {

            }
            return resDoc;
        }

        public List<Documento> Documentos_ObtenLista(Sucursales sucursal)
        {
            List<Documento> resDoc = new List<Documento>();
            try
            {
                uFacturaEDatos.Operaciones.Documentos.Documento doc = new uFacturaEDatos.Operaciones.Documentos.Documento();
                resDoc = doc.ObtenLista(sucursal);
            }
            catch (Exception _x)
            {

            }
            return resDoc;
        }

        public List<Documento> Documentos_GenerarDocsDefault()
        {
            List<Documento> resDoc = new List<Documento>();
            try
            {
                uFacturaEDatos.Operaciones.Documentos.Documento doc = new uFacturaEDatos.Operaciones.Documentos.Documento();
                resDoc = doc.GenerarDocsDefault();
            }
            catch (Exception _x)
            {

            }
            return resDoc;
        }

        #endregion
        #region(DocumentosFormatos)

        public List<Documentos_Formato> DocumentosFormatos_ObtenLista()
        {
            List<Documentos_Formato> resDoc = new List<Documentos_Formato>();
            try
            {
                uFacturaEDatos.Operaciones.Documentos_Formatos.Formato doc = new uFacturaEDatos.Operaciones.Documentos_Formatos.Formato();
                resDoc = doc.ObtenLista();
            }
            catch (Exception _x)
            {

            }
            return resDoc;
        }

        #endregion
        #region(Empresas)

        public bool Empresa_Guardar(Empresa empresa)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Empresa.Empresa emp = new uFacturaEDatos.Operaciones.Empresa.Empresa();
                bRes = emp.Guardar(empresa);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Empresa_Eliminar(Empresa empresa)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Empresa.Empresa emp = new uFacturaEDatos.Operaciones.Empresa.Empresa();
                bRes = emp.Eliminar(empresa);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public Empresa Empresa_Obten(Empresa empresa)
        {
            Empresa empr = new Empresa();
            try
            {
                uFacturaEDatos.Operaciones.Empresa.Empresa emp = new uFacturaEDatos.Operaciones.Empresa.Empresa();
                empr = emp.Obten(empresa);
            }
            catch (Exception _x)
            {

            }
            return empr;
        }

        #endregion
        #region(EUbicacion)

        public bool EUbicacion_Guardar(C_Examen_Ubicacion eubica)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.EUbicacion.Eubicacion ub = new uFacturaEDatos.Operaciones.EUbicacion.Eubicacion();
                bRes = ub.Guardar(eubica);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool EUbicacion_Eliminar(C_Examen_Ubicacion eubica)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.EUbicacion.Eubicacion ub = new uFacturaEDatos.Operaciones.EUbicacion.Eubicacion();
                bRes = ub.Eliminar(eubica);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public C_Examen_Ubicacion EUbicacion_Obten(C_Examen_Ubicacion eubica)
        {
            C_Examen_Ubicacion ubica = new C_Examen_Ubicacion();
            try
            {
                uFacturaEDatos.Operaciones.EUbicacion.Eubicacion ub = new uFacturaEDatos.Operaciones.EUbicacion.Eubicacion();
                ubica = ub.Obten(eubica);
            }
            catch (Exception _x)
            {

            }
            return ubica;
        }

        public C_Examen_Ubicacion EUbicacion_ObtenS(C_Examen_Ubicacion eubica)
        {
            C_Examen_Ubicacion ubica = new C_Examen_Ubicacion();
            try
            {
                uFacturaEDatos.Operaciones.EUbicacion.Eubicacion ub = new uFacturaEDatos.Operaciones.EUbicacion.Eubicacion();
                ubica = ub.ObtenS(eubica);
            }
            catch (Exception _x)
            {

            }
            return ubica;
        }

        #endregion
        #region(Evaluaciones)

        public bool Evaluaciones_Guardar(T_Evaluaciones evalua)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones ev = new uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones();
                bRes = ev.Guardar(evalua);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Evaluaciones_Eliminar(T_Evaluaciones evalua)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones ev = new uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones();
                bRes = ev.Eliminar(evalua);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Evaluaciones Evaluaciones_Obten(T_Evaluaciones evalua)
        {
            T_Evaluaciones eval = new T_Evaluaciones();
            try
            {
                uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones ev = new uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones();
                eval = ev.Obten(evalua);
            }
            catch (Exception _x)
            {

            }
            return eval;
        }

        public List<T_Evaluaciones> Evaluaciones_ObtenS(T_Evaluaciones evalua)
        {
            List<T_Evaluaciones> evalList = new List<T_Evaluaciones>();
            try
            {
                uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones ev = new uFacturaEDatos.Operaciones.Evaluaciones.Evaluaciones();
                evalList = ev.ObtenS(evalua);
            }
            catch (Exception _x)
            {

            }
            return evalList;
        }

        #endregion
        #region(Familiar)

        public bool Familiar_Guardar(T_Familiar familia)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Familiar.Familiar fam = new uFacturaEDatos.Operaciones.Familiar.Familiar();
                bRes = fam.Guardar(familia);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Familiar_Eliminar(T_Familiar familia)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Familiar.Familiar fam = new uFacturaEDatos.Operaciones.Familiar.Familiar();
                bRes = fam.Eliminar(familia);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Familiar Familiar_Obten(T_Familiar familia)
        {
            T_Familiar resf = new T_Familiar();
            try
            {
                uFacturaEDatos.Operaciones.Familiar.Familiar fam = new uFacturaEDatos.Operaciones.Familiar.Familiar();
                resf = fam.Obten(familia);
            }
            catch (Exception _x)
            {

            }
            return resf;
        }

        public T_Familiar Familiar_ObtenS(T_Familiar familia)
        {
            T_Familiar resf = new T_Familiar();
            try
            {
                uFacturaEDatos.Operaciones.Familiar.Familiar fam = new uFacturaEDatos.Operaciones.Familiar.Familiar();
                resf = fam.ObtenS(familia);
            }
            catch (Exception _x)
            {

            }
            return resf;
        }

        #endregion
        #region(Folios)

        public int Folios_GetFolioNuevo(Documento documento, Sucursales sucursal)
        {
            int bRes = 0;
            try
            {
                uFacturaEDatos.Operaciones.Folios.Folio folios = new uFacturaEDatos.Operaciones.Folios.Folio();
                bRes = folios.GetFolioNuevo(documento, sucursal);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        #endregion
        #region(Instructores)

        public bool Instructores_Guardar(C_Instructores catego)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Instructor.Instructor ins = new uFacturaEDatos.Operaciones.Instructor.Instructor();
                bRes = ins.Guardar(catego);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public C_Instructores Instructores_Obten(C_Instructores catego)
        {
            C_Instructores instruc = new C_Instructores();
            try
            {
                uFacturaEDatos.Operaciones.Instructor.Instructor ins = new uFacturaEDatos.Operaciones.Instructor.Instructor();
                instruc = ins.Obten(catego);
            }
            catch (Exception _x)
            {

            }
            return instruc;
        }

        public List<C_Instructores> Instructores_ObtenLista()
        {
            List<C_Instructores> instrucList = new List<C_Instructores>();
            try
            {
                uFacturaEDatos.Operaciones.Instructor.Instructor ins = new uFacturaEDatos.Operaciones.Instructor.Instructor();
                instrucList = ins.ObtenLista();
            }
            catch (Exception _x)
            {

            }
            return instrucList;
        }

        #endregion
        #region(Libreta)

        public bool Libreta_Guardar(T_Apartados apartado)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Libreta.Libreta lib = new uFacturaEDatos.Operaciones.Libreta.Libreta();
                bRes = lib.Guardar(apartado);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Libreta_Eliminar(DateTime date)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Libreta.Libreta lib = new uFacturaEDatos.Operaciones.Libreta.Libreta();
                bRes = lib.Eliminar(date);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public List<Cs_Horario> Libreta_ObtenHorarios()
        {
            List<Cs_Horario> lstHor = new List<Cs_Horario>();
            try
            {
                uFacturaEDatos.Operaciones.Libreta.Libreta lib = new uFacturaEDatos.Operaciones.Libreta.Libreta();
                lstHor = lib.ObtenHorarios();
            }
            catch (Exception _x)
            {

            }
            return lstHor;
        }

        public List<Cs_ListaGpoDet> Libreta_ObtenGrupos(string hora, char dia)
        {
            List<Cs_ListaGpoDet> lstGpo = new List<Cs_ListaGpoDet>();
            try
            {
                uFacturaEDatos.Operaciones.Libreta.Libreta lib = new uFacturaEDatos.Operaciones.Libreta.Libreta();
                lstGpo = lib.ObtenGrupos(hora, dia);
            }
            catch (Exception _x)
            {

            }
            return lstGpo;
        }

        public T_Apartados Libreta_ObtenS(T_Apartados apartado)
        {
            T_Apartados apar = new T_Apartados();
            try
            {
                uFacturaEDatos.Operaciones.Libreta.Libreta lib = new uFacturaEDatos.Operaciones.Libreta.Libreta();
                apar = lib.ObtenS(apartado);
            }
            catch (Exception _x)
            {

            }
            return apar;
        }

        #endregion



        //
        #region (MetodosPago)
        public uFacturaEDatos.Operaciones.MetodosPago.Metodo MetodosPago_Obtener(string metodo)
        {
            uFacturaEDatos.Operaciones.MetodosPago.Metodo met = new uFacturaEDatos.Operaciones.MetodosPago.Metodo();
            uFacturaEDatos.Operaciones.MetodosPago.Metodos metodos = new uFacturaEDatos.Operaciones.MetodosPago.Metodos();
            met = metodos.obtener(metodo);

            return met;
        }
        public uFacturaEDatos.Operaciones.MetodosPago.Metodo MetodosPago_ObtenerD(string metodo)
        {
            uFacturaEDatos.Operaciones.MetodosPago.Metodo met = new uFacturaEDatos.Operaciones.MetodosPago.Metodo();
            uFacturaEDatos.Operaciones.MetodosPago.Metodos metodos = new uFacturaEDatos.Operaciones.MetodosPago.Metodos();
            met = metodos.obtenerD(metodo);
            return met;
        }


        #endregion
        #region (Perfiles)
        public bool Perfiles_Guardar(uFacturaEDatos.T_Perfiles usuario)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Perfil.Perfil perfil = new uFacturaEDatos.Operaciones.Perfil.Perfil();
                bRes = perfil.Guardar(usuario);

            }
            catch (Exception _x)
            {

            }
            return bRes;
        }
        public bool Perfiles_Eliminar(uFacturaEDatos.T_Perfiles usuario)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Perfil.Perfil perfil = new uFacturaEDatos.Operaciones.Perfil.Perfil();
                bRes = perfil.Eliminar(usuario);

            }
            catch (Exception _x)
            {

            }
            return bRes;
        }
        public uFacturaEDatos.T_Perfiles Perfiles_Obten(uFacturaEDatos.T_Perfiles usuario)
        {
            uFacturaEDatos.T_Perfiles perfil = new T_Perfiles();
            try
            {
                uFacturaEDatos.Operaciones.Perfil.Perfil perfils = new uFacturaEDatos.Operaciones.Perfil.Perfil();
                perfil = perfils.Obten(usuario);
            }
            catch (Exception _x)
            {

            }
            return perfil;
        }
        public List<uFacturaEDatos.T_Perfiles> Perfiles_ObtenLista()
        {
            List<uFacturaEDatos.T_Perfiles> perfiles = new List<T_Perfiles>();
            try
            {
                uFacturaEDatos.Operaciones.Perfil.Perfil perfils = new uFacturaEDatos.Operaciones.Perfil.Perfil();
                perfiles = perfils.ObtenLista();
            }
            catch (Exception _x)
            {

                throw;
            }
            return perfiles;
        }
        #endregion
        #region (Privilegios)

        public bool Privilegios_Guardar(List<uFacturaEDatos.T_Grants> Privi)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Privilegios.Privilegio priv = new uFacturaEDatos.Operaciones.Privilegios.Privilegio();
                bRes = priv.Guardar(Privi);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }
        public bool Privilegios_Eliminar(int UserNip)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Privilegios.Privilegio priv = new uFacturaEDatos.Operaciones.Privilegios.Privilegio();
                bRes = priv.Eliminar(UserNip);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }
        public uFacturaEDatos.T_Grants Privilegios_Obten(uFacturaEDatos.T_Grants grant)
        {
            uFacturaEDatos.T_Grants grants = new T_Grants();
            try
            {
                uFacturaEDatos.Operaciones.Privilegios.Privilegio priv = new uFacturaEDatos.Operaciones.Privilegios.Privilegio();
                grants = priv.Obten(grant);
            }
            catch (Exception _x)
            {

                throw;
            }
            return grants;
        }
        public List<uFacturaEDatos.T_Grants> Privilegios_ObtenLista(int userNip)
        {
            List<uFacturaEDatos.T_Grants> list = new List<T_Grants>();
            try
            {
                uFacturaEDatos.Operaciones.Privilegios.Privilegio priv = new uFacturaEDatos.Operaciones.Privilegios.Privilegio();
                list = priv.ObtenLista(userNip);
            }
            catch (Exception _x)
            {

                throw;
            }
            return list;
        }
        public bool Privilegios_ver(string Modulo, int User_nip)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Privilegios.Privilegio privilegio = new uFacturaEDatos.Operaciones.Privilegios.Privilegio();
            res = privilegio.ver(Modulo, User_nip);
            return res;
        }
        public bool Privilegios_verop(string Modulo, int User_nip)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Privilegios.Privilegio privilegio = new uFacturaEDatos.Operaciones.Privilegios.Privilegio();
            res = privilegio.verop(Modulo, User_nip);
            return res;
        }

        #endregion
        #region (Recibo)

        public bool Recibo_Guardar(uFacturaEDatos.Operaciones.Recibo.Recibos recibo)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.Guardar(recibo);
            return res;
        }

        public Stream Recibo_Imprimir(uFacturaEDatos.Operaciones.Recibo.Recibos recibo)
        //public byte[] Recibo_Imprimir(uFacturaEDatos.Operaciones.Recibo.Recibos recibo)
        {
            bool res = false;
            Socios.Datos.Catalogos.DAO.SociosDAO rec = new Socios.Datos.Catalogos.DAO.SociosDAO();
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/pdf";
            MemoryStream stream = new MemoryStream(rec.printRecibo(recibo));
            stream.Position = 0;
            return stream;
            //return  rec.printRecibo(recibo);

            //return res;
        }
        public bool Recibo_Eliminar(int SucursalID, int ReciboID)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.Eliminar(SucursalID,ReciboID);
            return res;
        }
        public bool Recibo_RIngresoDiario(List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> detalle, List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> pago)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.RIngresoDiario(detalle,pago);
            return res;
        }
        public uFacturaEDatos.T_Cuotas Recibo_Obten(uFacturaEDatos.T_Cuotas cuota)
        {
            uFacturaEDatos.T_Cuotas cuotas = new T_Cuotas();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            cuotas = rec.Obten(cuota);
            return cuotas;

        }
        public int Recibo_Nuevo(int SucursalID, String Cual)
        {
            int res = 0;

            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.Nuevo(SucursalID, Cual);
            return res;
        }

        public bool Consulta_Folio(int SucursalID, int RemRecId)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.ConsultaFolio(SucursalID, RemRecId);
            return res;
        }
        public bool Recibo_ActFol(int SucursalID, String Cual, int Folio)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.ActFol(SucursalID, Cual, Folio);
            return res;
        }
        public List<uFacturaEDatos.T_Cuotas> Recibo_ObtenLista(int socioID)
        {
            List<uFacturaEDatos.T_Cuotas> list = new List<T_Cuotas>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.ObtenLista(socioID);
            return list;
        }
        public bool Recibo_Cancelar(int SucursalID, int ReciboID)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.Cancelar(SucursalID, ReciboID);
            return res;
        }
        public bool Recibo_CancelarFactura(int FacturaID)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            res = rec.CancelarFactura(FacturaID);
            return res;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> Recibo_DetalleIngreso(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> list = new List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.DetalleIngreso(f1, f2, Sini, sfin);
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> Recibo_DetalleIngresoS(int socioID)
        {
            List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> list = new List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.DetalleIngresoS(socioID);
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> Recibo_DetalleIngresoF(DateTime f1, DateTime f2, int Sini, int sfin, int idSucursal)
        {
            List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> list = new List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.DetalleIngresoF(f1,f2,Sini,sfin,idSucursal);
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso> Recibo_ConceptoIngresoF(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso> list = new List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.ConceptoIngresoF(f1,f2,Sini,sfin);
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso> Recibo_ConceptoIngreso(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso> list = new List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.ConceptoIngreso(f1, f2, Sini, sfin);
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> Recibo_PagoIngresoM(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> list = new List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.PagoIngresoM(f1, f2, Sini, sfin);
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> Recibo_PagoIngreso(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> list = new List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.PagoIngreso(f1, f2, Sini, sfin);
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Recibo.CajaChica> Recibo_cajaChica(DateTime f1)
        {
            List<uFacturaEDatos.Operaciones.Recibo.CajaChica> list = new List<uFacturaEDatos.Operaciones.Recibo.CajaChica>();
            uFacturaEDatos.Operaciones.Recibo.Recibo rec = new uFacturaEDatos.Operaciones.Recibo.Recibo();
            list = rec.cajaChica(f1);
            return list;
        }


        #endregion

        #region (Catego)
        public bool Catego_Guardar(uFacturaEDatos.T_SocioCatego catego)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.SocioCatego.Catego cat = new uFacturaEDatos.Operaciones.SocioCatego.Catego();
            res = cat.Guardar(catego);
            return res;
        }
        public uFacturaEDatos.T_SocioCatego Catego_Obten(uFacturaEDatos.T_SocioCatego Catego)
        {
            uFacturaEDatos.T_SocioCatego cate = new T_SocioCatego();
            uFacturaEDatos.Operaciones.SocioCatego.Catego cat = new uFacturaEDatos.Operaciones.SocioCatego.Catego();
            cate = cat.Obten(Catego);
            return cate;
        }
        public uFacturaEDatos.T_SocioCatego Catego_ObtenS(uFacturaEDatos.T_SocioCatego Catego)
        {
            uFacturaEDatos.T_SocioCatego cate = new T_SocioCatego();
            uFacturaEDatos.Operaciones.SocioCatego.Catego cat = new uFacturaEDatos.Operaciones.SocioCatego.Catego();
            cate = cat.ObtenS(Catego);
            return cate;
        }
        #endregion
        #region (SociosDoc)
        public bool Doc_Guardar(uFacturaEDatos.T_SociosDocumentos doc)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.SocioDoc.Doc oDoc = new uFacturaEDatos.Operaciones.SocioDoc.Doc();
            res = oDoc.Guardar(doc);
            return res;
        }
        public uFacturaEDatos.T_SociosDocumentos Doc_Obten(uFacturaEDatos.T_SociosDocumentos doc)
        {
            T_SociosDocumentos d = new T_SociosDocumentos();
            uFacturaEDatos.Operaciones.SocioDoc.Doc oDoc = new uFacturaEDatos.Operaciones.SocioDoc.Doc();
            d = oDoc.Obten(doc);
            return d;
        }
        public bool Doc_Eliminar(uFacturaEDatos.T_SociosDocumentos documento)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.SocioDoc.Doc oDoc = new uFacturaEDatos.Operaciones.SocioDoc.Doc();
            res = oDoc.Eliminar(documento);
            return res;
        }
        public List<uFacturaEDatos.T_SociosDocumentos> Doc_ObtenLista(uFacturaEDatos.T_SociosDocumentos sucursal)
        {
            List<uFacturaEDatos.T_SociosDocumentos> list = new List<T_SociosDocumentos>();
            uFacturaEDatos.Operaciones.SocioDoc.Doc oDoc = new uFacturaEDatos.Operaciones.SocioDoc.Doc();
            list = oDoc.ObtenLista(sucursal);
            return list;
        }
        #endregion
        #region (Socios)
        public bool Socios_Guardar(uFacturaEDatos.T_Socio catego)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Socios.Socio oSoc = new uFacturaEDatos.Operaciones.Socios.Socio();
            res = oSoc.Guardar(catego);
            return res;
        }
        public uFacturaEDatos.T_Socio Socios_Obten(uFacturaEDatos.T_Socio Catego)
        {
            T_Socio soc = new T_Socio();
            uFacturaEDatos.Operaciones.Socios.Socio oSoc = new uFacturaEDatos.Operaciones.Socios.Socio();
            soc = oSoc.Obten(Catego);
            return soc;
        }
        public List<uFacturaEDatos.T_Socio> Socios_ObtenLista()
        {
            List<uFacturaEDatos.T_Socio> list = new List<T_Socio>();
            uFacturaEDatos.Operaciones.Socios.Socio oSoc = new uFacturaEDatos.Operaciones.Socios.Socio();
            list = oSoc.ObtenLista();
            return list;
        }

        #endregion
        #region (Sucursal)
        public bool Sucursal_Guardar(uFacturaEDatos.Sucursales sucursal)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Sucursales.Sucursal oSuc = new uFacturaEDatos.Operaciones.Sucursales.Sucursal();
            res = oSuc.Guardar(sucursal);
            return res;
        }
        public bool Sucursal_Eliminar(uFacturaEDatos.Sucursales sucursal)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Sucursales.Sucursal oSuc = new uFacturaEDatos.Operaciones.Sucursales.Sucursal();
            res = oSuc.Eliminar(sucursal);
            return res;
        }
        public uFacturaEDatos.Sucursales Sucursal_Obten(uFacturaEDatos.Sucursales sucursal)
        {
            uFacturaEDatos.Operaciones.Sucursales.Sucursal oSuc = new uFacturaEDatos.Operaciones.Sucursales.Sucursal();
            uFacturaEDatos.Sucursales suc = new Sucursales();
            suc = oSuc.Obten(sucursal);
            return suc;
        }
        public uFacturaEDatos.Sucursales Sucursal_ObtenMatriz(uFacturaEDatos.Empresa empresa)
        {
            uFacturaEDatos.Operaciones.Sucursales.Sucursal oSuc = new uFacturaEDatos.Operaciones.Sucursales.Sucursal();
            uFacturaEDatos.Sucursales suc = new Sucursales();
            suc = oSuc.ObtenMatriz(empresa);
            return suc;

        }
        public List<uFacturaEDatos.Sucursales> Sucursal_ObtenLista(uFacturaEDatos.Empresa empresa)
        {
            List<uFacturaEDatos.Sucursales> list = new List<Sucursales>();
            uFacturaEDatos.Operaciones.Sucursales.Sucursal oSuc = new uFacturaEDatos.Operaciones.Sucursales.Sucursal();
            list = oSuc.ObtenLista(empresa);
            return list;
        }
        #endregion
        #region (Tabular)
        public bool Tabluar_Guardar(uFacturaEDatos.T_Tabular tabular)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Tabular.Tabular oTab = new uFacturaEDatos.Operaciones.Tabular.Tabular();
            res = oTab.Guardar(tabular);
            return res;
        }
        public bool Tabluar_Eliminar(uFacturaEDatos.T_Tabular tabular)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Tabular.Tabular oTab = new uFacturaEDatos.Operaciones.Tabular.Tabular();
            res = oTab.Eliminar(tabular);
            return res;
        }
        public uFacturaEDatos.T_Tabular Tabluar_Obten(uFacturaEDatos.T_Tabular tabular)
        {
            uFacturaEDatos.T_Tabular res = new T_Tabular(); ;
            uFacturaEDatos.Operaciones.Tabular.Tabular oTab = new uFacturaEDatos.Operaciones.Tabular.Tabular();
            res = oTab.Obten(tabular);
            return res;
        }
        public List<uFacturaEDatos.T_Tabular> Tabluar_ObtenLista(string instID)
        {
            List<uFacturaEDatos.T_Tabular> list = new List<T_Tabular>();
            uFacturaEDatos.Operaciones.Tabular.Tabular oTab = new uFacturaEDatos.Operaciones.Tabular.Tabular();
            list = oTab.ObtenLista(instID);
            return list;
        }
        #endregion
        #region (Tarjetas)
        public bool Tarjetas_Guardar(uFacturaEDatos.SociosTarjetas doc)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Tarjeta.Tarjetas oTar = new uFacturaEDatos.Operaciones.Tarjeta.Tarjetas();
            res = oTar.Guardar(doc);
            return res;
        }
        public uFacturaEDatos.SociosTarjetas Tarjetas_Obten(uFacturaEDatos.SociosTarjetas doc)
        {
            uFacturaEDatos.SociosTarjetas res = new SociosTarjetas();
            uFacturaEDatos.Operaciones.Tarjeta.Tarjetas oTar = new uFacturaEDatos.Operaciones.Tarjeta.Tarjetas();
            res = oTar.Obten(doc);
            return res;
        }
        public bool Tarjetas_Eliminar(uFacturaEDatos.SociosTarjetas documento)
        {
            bool res = false;
            uFacturaEDatos.Operaciones.Tarjeta.Tarjetas oTar = new uFacturaEDatos.Operaciones.Tarjeta.Tarjetas();
            res = oTar.Eliminar(documento);
            return res;
        }
        public List<uFacturaEDatos.SociosTarjetas> Tarjetas_ObtenListaS(uFacturaEDatos.SociosTarjetas sucursal)
        {
            List<uFacturaEDatos.SociosTarjetas> list = new List<SociosTarjetas>();
            uFacturaEDatos.Operaciones.Tarjeta.Tarjetas oTar = new uFacturaEDatos.Operaciones.Tarjeta.Tarjetas();
            list = oTar.ObtenLista(sucursal);
            return list;
        }
        public List<uFacturaEDatos.SociosTarjetas> Tarjetas_ObtenLista()
        {
            List<uFacturaEDatos.SociosTarjetas> list = new List<SociosTarjetas>();
            uFacturaEDatos.Operaciones.Tarjeta.Tarjetas oTar = new uFacturaEDatos.Operaciones.Tarjeta.Tarjetas();
            list = oTar.ObtenLista();
            return list;
        }
        public List<uFacturaEDatos.Operaciones.Tarjeta.STarjetas> Tarjetas_obtentar()
        {
            List<uFacturaEDatos.Operaciones.Tarjeta.STarjetas> list = new List<uFacturaEDatos.Operaciones.Tarjeta.STarjetas>();
            uFacturaEDatos.Operaciones.Tarjeta.Tarjetas oTar = new uFacturaEDatos.Operaciones.Tarjeta.Tarjetas();
            list = oTar.obtentar();

            return list;
        }


        #endregion

        #region(Trabajo)

        public bool Trabajo_Guardar(T_Trabajo concepto)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Trabajo.Trabajo trabajo = new uFacturaEDatos.Operaciones.Trabajo.Trabajo();
                bRes = trabajo.Guardar(concepto);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Trabajo_Eliminar(T_Trabajo concepto)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Trabajo.Trabajo trabajo = new uFacturaEDatos.Operaciones.Trabajo.Trabajo();
                bRes = trabajo.Eliminar(concepto);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Trabajo Trabajo_Obten(T_Trabajo concepto)
        {
            T_Trabajo trab = new T_Trabajo();
            try
            {
                uFacturaEDatos.Operaciones.Trabajo.Trabajo trabajo = new uFacturaEDatos.Operaciones.Trabajo.Trabajo();
                trab = trabajo.Obten(concepto);
            }
            catch (Exception _x)
            {

            }
            return trab;
        }

        public List<T_Trabajo> Trabajo_ObtenLista()
        {
            List<T_Trabajo> trabList = new List<T_Trabajo>();
            try
            {
                uFacturaEDatos.Operaciones.Trabajo.Trabajo trabajo = new uFacturaEDatos.Operaciones.Trabajo.Trabajo();
                trabList = trabajo.ObtenLista();
            }
            catch (Exception _x)
            {

            }
            return trabList;
        }

        #endregion
        #region(Usuarios)

        public bool Usuarios_Guardar(T_Users usuario)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Usuarios.Usuario usu = new uFacturaEDatos.Operaciones.Usuarios.Usuario();
                bRes = usu.Guardar(usuario);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public bool Usuarios_Eliminar(T_Users usuario)
        {
            bool bRes = false;
            try
            {
                uFacturaEDatos.Operaciones.Usuarios.Usuario usu = new uFacturaEDatos.Operaciones.Usuarios.Usuario();
                bRes = usu.Eliminar(usuario);
            }
            catch (Exception _x)
            {

            }
            return bRes;
        }

        public T_Users Usuarios_Obten(T_Users usuario)
        {
            T_Users user = new T_Users();
            try
            {
                uFacturaEDatos.Operaciones.Usuarios.Usuario usu = new uFacturaEDatos.Operaciones.Usuarios.Usuario();
                user = usu.Obten(usuario);
            }
            catch (Exception _x)
            {

            }
            return user;
        }

        public T_Users Usuarios_ObtenMax()
        {
            T_Users user = new T_Users();
            try
            {
                uFacturaEDatos.Operaciones.Usuarios.Usuario usu = new uFacturaEDatos.Operaciones.Usuarios.Usuario();
                user = usu.ObtenMax();
            }
            catch (Exception _x)
            {

            }
            return user;
        }

        public List<T_Users> Usuarios_ObtenLista()
        {
            List<T_Users> users = new List<T_Users>();
            try
            {
                uFacturaEDatos.Operaciones.Usuarios.Usuario usu = new uFacturaEDatos.Operaciones.Usuarios.Usuario();
                users = usu.ObtenLista();
            }
            catch (Exception _x)
            {

            }
            return users;
        }

        #endregion


        #endregion

    }
}
