using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Socios.Rest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAquaraLomas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAquaraLomas
    {
        [OperationContract]
        void DoWork();
        #region Socios
        #region(Actividades)
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Actividades/GetActividades")]
        List<Socios.Datos.Catalogos.Actividades> Actividades_GetActividades();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Actividades/GetById")]
        Socios.Datos.Catalogos.Actividades Actividades_GetById(Socios.Datos.Catalogos.Actividades actividades);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Actividades/Create")]
        int Actividades_create(Socios.Datos.Catalogos.Actividades actividades);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Actividades/Update")]
        int Actividades_update(Socios.Datos.Catalogos.Actividades actividades);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Actividades/Delete")]
        int Actividades_delete(Socios.Datos.Catalogos.Actividades actividades);


        #endregion

        #region(Agrupacion)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Agrupacion/GetAgrupaciones")]
        List<Socios.Datos.Catalogos.Agrupacion> Agrupacion_GetAgrupaciones();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Agrupacion/GetById")]
        Socios.Datos.Catalogos.Agrupacion Agrupacion_GetByIdI(Socios.Datos.Catalogos.Agrupacion agrupacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Agrupacion/Create")]
        int Agrupacion_create(Socios.Datos.Catalogos.Agrupacion agrupacion);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Agrupacion/Update")]
        int Agrupacion_update(Socios.Datos.Catalogos.Agrupacion agrupacion);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Agrupacion/Delete")]
        int Agrupacion_delete(Socios.Datos.Catalogos.Agrupacion agrupacion);

        #endregion

        #region(Categorias)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Categorias/GetCategorias")]
        List<Socios.Datos.Catalogos.Categorias> Categorias_GetCategorias();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Categorias/Nuevo")]
        int Categorias_Nuevo();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Categorias/GetById")]
        Socios.Datos.Catalogos.Categorias Categorias_GetById(Socios.Datos.Catalogos.Categorias categoria);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Categorias/GetByOrden")]
        Socios.Datos.Catalogos.Categorias Categorias_GetByOrden(Socios.Datos.Catalogos.Categorias categoria);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Categorias/Create")]
        int Categorias_create(Socios.Datos.Catalogos.Categorias categoria);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Categorias/Update")]
        int Categorias_update(Socios.Datos.Catalogos.Categorias categoria);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Categorias/Delete")]
        int Categorias_delete(Socios.Datos.Catalogos.Categorias categoria);

        #endregion

        #region(DatosFactura)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "DatosFactura/GetDatosFactura")]
        List<Socios.Datos.Catalogos.DatosFactura> DatosFactura_GetDatosFactura();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "DatosFactura/GetById")]
        Socios.Datos.Catalogos.DatosFactura DatosFactura_GetById(Socios.Datos.Catalogos.DatosFactura factura);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "DatosFactura/Create")]
        int DatosFactura_create(Socios.Datos.Catalogos.DatosFactura factura);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "DatosFactura/Update")]
        int DatosFactura_update(Socios.Datos.Catalogos.DatosFactura factura);

        ///DELETE No implementado por que no tiene logica ya que hace relacion a Actividades


        #endregion

        #region(Deportes)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Deportes/GetDeportes")]
        List<Socios.Datos.Catalogos.Deportes> Deportes_GetDeportes();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Deportes/GetById")]
        Socios.Datos.Catalogos.Deportes Deportes_GetById(Socios.Datos.Catalogos.Deportes deporte);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Deportes/GetByNombre")]
        Socios.Datos.Catalogos.Deportes Deportes_GetByOrden(Socios.Datos.Catalogos.Deportes deporte);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Deportes/Create")]
        int Deportes_create(Socios.Datos.Catalogos.Deportes deporte);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Deportes/Update")]
        int Deportes_update(Socios.Datos.Catalogos.Deportes deporte);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Deportes/Delete")]
        int Deportes_delete(Socios.Datos.Catalogos.Deportes deporte);

        #endregion

        #region(Grupos)

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/GetAlumnos")]
        List<Socios.Datos.Catalogos.GruposDetalle> Grupos_GetAlumnos(string grupoId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/GetListado")]
        List<Socios.Datos.Catalogos.GruposListado> Grupos_GetListado(int sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/GetHorario")]
        List<Socios.Datos.Catalogos.GruposHoraDistinct> Grupos_GetHorario(int sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/GetGrupos")]
        List<Socios.Datos.Catalogos.GruposListado> Grupos_GetGrupos(int sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/ObtenerHorario")]
        List<Socios.Datos.Catalogos.GruposHorario> Grupos_ObtenerHorario(string grupoId);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/GetById")]
        Socios.Datos.Catalogos.Grupos Grupos_GetById(Socios.Datos.Catalogos.Grupos grupo);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/Create")]
        int Grupos_create(Socios.Datos.Catalogos.Grupos grupo);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/Update")]
        int Grupos_update(Socios.Datos.Catalogos.Grupos grupo);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/Delete")]
        int Grupos_delete(Socios.Datos.Catalogos.Grupos grupo);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Grupos/GeneraListas")]
        int Grupos_GeneraListas(string v_a, Socios.Datos.Catalogos.Dias v_b, int sucursalId);


        #endregion

        #region(HorarioGrupos)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "HorarioGrupos/GetHorarioGrupos")]
        List<Socios.Datos.Catalogos.HorariosGpo> HorarioGrupos_GetHorarioGrupos();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "HorarioGrupos/GetById")]
        Socios.Datos.Catalogos.HorariosGpo HorarioGrupos_GetByIdI(Socios.Datos.Catalogos.HorariosGpo agrupacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "HorarioGrupos/Create")]
        int HorarioGrupos_create(Socios.Datos.Catalogos.HorariosGpo agrupacion);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "HorarioGrupos/Update")]
        int HorarioGrupos_update(Socios.Datos.Catalogos.HorariosGpo agrupacion);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "HorarioGrupos/Delete")]
        int HorarioGrupos_delete(Socios.Datos.Catalogos.HorariosGpo agrupacion);

        #endregion

        #region(Instructores)

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            // RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Instructores/GetInstructores")]
        List<Socios.Datos.Catalogos.Instructores> Instructoress_GetInstructores(string sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Instructores/GetById")]
        Socios.Datos.Catalogos.Instructores Instructores_GetByIdI(Socios.Datos.Catalogos.Instructores instructor);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Instructores/Create")]
        int Instructores_create(Socios.Datos.Catalogos.Instructores instructor);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Instructores/Update")]
        int Instructores_update(Socios.Datos.Catalogos.Instructores instructor);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Instructores/Delete")]
        int Instructores_delete(Socios.Datos.Catalogos.Instructores instructor);

        #endregion

        #region(Nomina)

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Nomina/Create")]
        int Nomina_create(Socios.Datos.Catalogos.Nomina nomina);

        #endregion  

        #region(Socios)

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/GetListado")]
        List<Socios.Datos.Catalogos.SocioListado> Socios_GetListado(string sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/GetListadoE")]
        List<Socios.Datos.Catalogos.SocioListado> Socios_GetListadoE(int sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/GetListadoEC")]
        List<Socios.Datos.Catalogos.SocioListado> Socios_GetListadoEC(int sucursalId, int socioIni, int socioFin, int socioLun, int socioMar, int socioMie, int socioJue, int socioVie, int socioSab);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/ObtenAsistencias")]
        List<Socios.Datos.Catalogos.SocioAsistencias> Socios_ObtenAsistencias(int socioId, int sucursalId, int mes, int anio);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/ObtenHorario")]
        List<Socios.Datos.Catalogos.SociosHorario> Socios_ObtenHorario(string socioId, int sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/ObtenHorarioDet")]
        List<Socios.Datos.Catalogos.SociosHorariodet> Socios_ObtenHorarioDet(string socioId, int sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/GetById")]
        Socios.Datos.Catalogos.Socio Socios_GetByIdI(Socios.Datos.Catalogos.Socio socio);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/Create")]
        int Socios_create(Socios.Datos.Catalogos.Socio socio);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/Update")]
        int Socios_update(Socios.Datos.Catalogos.Socio socio);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Socios/Delete")]
        int Socios_delete(Socios.Datos.Catalogos.Socio socio);

        #endregion

        #region(Sucursal)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Sucursal/GetSucursales")]
        List<Socios.Datos.Catalogos.Sucursal> Sucursal_GetSucursales();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Sucursal/GetById")]
        Socios.Datos.Catalogos.Sucursal Sucursal_GetById(Socios.Datos.Catalogos.Sucursal sucursales);

        #endregion

        #region(Usuarios)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Usuarios/GetUsuarios")]
        List<Socios.Datos.Catalogos.Usuarios> Usuarios_GetUsuarios();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Usuarios/GetById")]
        Socios.Datos.Catalogos.Usuarios Usuarios_GetById(Socios.Datos.Catalogos.Usuarios usuario);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Usuarios/GetByNombre")]
        Socios.Datos.Catalogos.Usuarios Usuarios_GetByNombre(Socios.Datos.Catalogos.Usuarios usuario);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Usuarios/Create")]
        int Usuarios_create(Socios.Datos.Catalogos.Usuarios usuario);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Usuarios/Update")]
        int Usuarios_update(Socios.Datos.Catalogos.Usuarios usuario);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Usuarios/Delete")]
        int Usuarios_delete(Socios.Datos.Catalogos.Usuarios usuario);

        #endregion
        #endregion



        #region Operaciones
        #region (Abonos)

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Abono/Save")]
        bool AbonosSave(uFacturaEDatos.Cuentas_Por_Cobrar abono);


        #endregion
        #region (Actividades)
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "Operaciones/Actividades/GetAll")]
        List<uFacturaEDatos.C_Areas> ActividadesGetAll();

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/Actividades/Get")]
        uFacturaEDatos.C_Areas ActividadesGet(uFacturaEDatos.C_Areas documento);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/Actividades/Delete")]
        bool ActividadesEliminar(uFacturaEDatos.C_Areas area);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/Actividades/Save")]
        bool ActividadesGuardar(uFacturaEDatos.C_Areas area);

        #endregion
        #region (Documento)

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/ActividadDocto/Save")]
        bool GuardarActividadDocto(uFacturaEDatos.C_AreasDocumentos documento);

        [WebInvoke(Method = "DELETE",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/ActividadDocto/Delete")]
        bool EliminarActividadDocto(uFacturaEDatos.C_AreasDocumentos documento);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/ActividadDocto/Get")]
        uFacturaEDatos.C_AreasDocumentos ObtenActividadDocto(uFacturaEDatos.C_AreasDocumentos documento);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/ActividadDocto/GetList")]
        List<uFacturaEDatos.C_AreasDocumentos> ObtenListaActividadDocto(uFacturaEDatos.C_AreasDocumentos area);

        #endregion
        #region (Agrupacion)

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/Agrupacion/Save")]
        bool GuardarAgrupacion(uFacturaEDatos.T_Agrupacion agrupa);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Agrupacion/Delete")]
        bool EliminarAgrupacion(uFacturaEDatos.T_Agrupacion agrupa);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Agrupacion/Get")]
        uFacturaEDatos.T_Agrupacion ObtenAgrupacion(uFacturaEDatos.T_Agrupacion agrupacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Agrupacion/GetF")]
        uFacturaEDatos.T_Agrupacion ObtenFAgrupacion(uFacturaEDatos.T_Agrupacion agrupacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Agrupacion/GetS")]
        uFacturaEDatos.T_Agrupacion ObtenSAgrupacion(uFacturaEDatos.T_Agrupacion agrupacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Agrupacion/GetData")]
        List<uFacturaEDatos.Operaciones.Agrupacion.AgrupacionN> ObtenDatosAgrupacion(decimal AgrupaID, int SucursalID);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Agrupacion/GetList")]
        List<uFacturaEDatos.T_Agrupacion> ObtenListaAgrupacion(int SocioID);

        #endregion
        #region (Bitacora)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Bitacora/Save")]
        bool Guardar(uFacturaEDatos.T_Bitacora bitacora);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Bitacora/Delete")]
        bool Eliminar(uFacturaEDatos.T_Bitacora bitacora);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Bitacora/Get")]
        uFacturaEDatos.T_Bitacora Obten(uFacturaEDatos.T_Bitacora bitacora);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Bitacora/GetList")]
        List<uFacturaEDatos.T_Bitacora> ObtenLista(int UserID, DateTime Fecini, DateTime FecFin);
        #endregion
        #region (Aduana)

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Operaciones/Aduana/Get")]
        List<uFacturaEDatos.DatosSat.c_AduanaRow> GetAduanas();
        #endregion
        #region (ClaveProdSer)

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "Operaciones/ProdServ/Get")]
        List<uFacturaEDatos.DatosSat.c_ClaveProdServRow> GetClaveProdServ();
        #endregion
        #region (ClaveUnidad)

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "Operaciones/ClaveUnidad/Get")]
        List<uFacturaEDatos.DatosSat.c_ClaveUnidadRow> GetClaveUnidad();






        #endregion
        #region (FormaPago)
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/FormaPago/Get")]
        List<uFacturaEDatos.DatosSat.c_FormaPagoRow> GetFormaPago();
        #endregion
        #region (MetodoPago)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/MetodoPago/GetDescripcion")]
        string GetDescripcion(string clave);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/MetodoPago/Get")]
        string GetMetodoPago();
        #endregion
        #region (RegimenFiscal)

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/RegimenFiscal/GetByCve")]
        string Regimen(string clave);

        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/RegimenFiscal/Get")]
        List<uFacturaEDatos.DatosSat.c_RegimenFiscalRow> GetRegimenFiscal();
        #endregion

        #region (UsoCFDI)

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/UsoCFDI/GetDescr")]
        string UsoCFDI_GetDescr(string clave);

        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/UsoCFDI/GetUsoCFDI")]
        string UsoCFDI_GetUsoCFDI();
        #endregion
        #region (CajaChica)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/CajaChica/Save")]
        bool CajaChica_Guardar(uFacturaEDatos.T_CChica cCajaChica);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/CajaChica/Delete")]
        bool CajaChica_Eliminar(uFacturaEDatos.T_CChica cCajaChica);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/CajaChica/SaveCaja")]
        bool CajaChica_GuardarCaja(List<uFacturaEDatos.T_CChica> caja);


        #endregion
        #region (Calificaciones)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Calificaciones/Save")]
        bool Calificaciones_Guardar(uFacturaEDatos.C_Calificaciones califica, short categoriaId);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Calificaciones/Delete")]
        bool Calificaciones_Eliminar(uFacturaEDatos.C_Calificaciones califica);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Calificaciones/Get")]
        uFacturaEDatos.C_Calificaciones Calificaciones_Obten(uFacturaEDatos.C_Calificaciones califica);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Calificaciones/GetList")]
        List<uFacturaEDatos.Operaciones.Calificaciones.CalificacionesExa> Calificaciones_ObtenLista(int socioId, int sucursalId);
        #endregion
        #region (CDocumento)

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/CDocumentos/Save")]
        bool CDocumentos_Guardar(uFacturaEDatos.C_Documentos documento);

        [WebInvoke(Method = "DELETE",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/CDocumentos/Delete")]
        bool CDocumentos_Eliminar(uFacturaEDatos.C_Documentos documento);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/CDocumentos/Get")]
        uFacturaEDatos.C_Documentos CDocumentos_Obten(uFacturaEDatos.C_Documentos documento);

        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/CDocumentos/GetList")]
        List<uFacturaEDatos.C_Documentos> CDocumentos_ObtenLista();

        #endregion
        #region(CodigosPostales)

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/CodigosPostales/ConsultaCP")]
        List<uFacturaEDatos.CodigosPostale> CodigosPostales_ConsultaCP(int codePostal);

        #endregion
        #region(Comprobantes)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Save")]
        bool Comprobantes_Guardar(uFacturaEDatos.Comprobante comprobante, uFacturaEDatos.Operaciones.Recibo.Recibos recibo);




        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Delete")]
        bool Comprobantes_Eliminar(uFacturaEDatos.Comprobante comprobante);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Get")]
        uFacturaEDatos.Comprobante Comprobantes_Obten(uFacturaEDatos.Comprobante comprobante);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/GetList")]
        List<uFacturaEDatos.Comprobante> Comprobantes_ObtenLista(uFacturaEDatos.Sucursales sucursal);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Reporte_ComprobantesC")]
        List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos> Comprobantes_Reporte_ComprobantesC(int idsucursal, DateTime fecha, bool mes);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Reporte_Comprobantes")]
        List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidos> Comprobantes_Reporte_Comprobantes(int idsucursal, DateTime fecha, bool mes);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Reporte_Comprobantes_Detalle")]
        List<uFacturaEDatos.Operaciones.Comprobantes.ReporteComprobantesEmitidosDetalle> Comprobantes_Reporte_Comprobantes_Detalle(int idsucursal, DateTime fecha, bool mes);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Reporte_Cobranza")]
        List<uFacturaEDatos.Operaciones.Comprobantes.ReporteCobranza> Comprobantes_Reporte_Cobranza(int idsucursal);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Comprobantes/Reporte_Abonos")]
        List<uFacturaEDatos.Operaciones.Comprobantes.ReporteAbonos> Comprobantes_Reporte_Abonos(int idcomprobante);

        #endregion
        #region(Concepto)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Concepto/Save")]
        bool Concepto_Guardar(uFacturaEDatos.T_Conceptos concepto);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Concepto/Delete")]
        bool Concepto_Eliminar(uFacturaEDatos.T_Conceptos concepto);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Concepto/Get")]
        uFacturaEDatos.T_Conceptos Concepto_Obten(uFacturaEDatos.T_Conceptos concepto);

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Concepto/GetMax")]
        uFacturaEDatos.T_Conceptos Concepto_ObtenMax();

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Concepto/GetList")]
        List<uFacturaEDatos.T_Conceptos> Concepto_ObtenLista();

        #endregion
        #region(Cuotas)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Cuotas/Save")]
        bool Cuotas_Guardar(uFacturaEDatos.T_Cuotas cuota);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Cuotas/Delete")]
        bool Cuotas_Eliminar(uFacturaEDatos.T_Cuotas cuota);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Cuotas/Get")]
        uFacturaEDatos.T_Cuotas Cuotas_Obten(uFacturaEDatos.T_Cuotas cuota);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Cuotas/GetList")]
        List<uFacturaEDatos.T_Cuotas> Cuotas_ObtenLista(int socioId, int sucursalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Cuotas/CreaCuotas")]
        int Cuotas_CreaCuotas(int socioId, int mes, int año, bool nuevo, int sucursalId, Boolean anual);

        #endregion
        #region (Documentos)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Documentos/Save")]
        bool Documentos_Guardar(uFacturaEDatos.Documento documento);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Documentos/Delete")]
        bool Documentos_Eliminar(uFacturaEDatos.Documento documento);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Documentos/GetD")]
        uFacturaEDatos.Documento Documentos_ObtenD(uFacturaEDatos.Documento documento);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Documentos/Get")]
        uFacturaEDatos.Documento Documentos_Obten(int idFormato, uFacturaEDatos.Sucursales sucursal);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Documentos/GetList")]
        List<uFacturaEDatos.Documento> Documentos_ObtenLista(uFacturaEDatos.Sucursales sucursal);

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Documentos/GenerarDocsDefault")]
        List<uFacturaEDatos.Documento> Documentos_GenerarDocsDefault();
        #endregion
        #region (DocumentosFormatos)

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/DocumentosFormatos/GetList")]
        List<uFacturaEDatos.Documentos_Formato> DocumentosFormatos_ObtenLista();

        #endregion
        #region (Empresa)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Empresa/Save")]
        bool Empresa_Guardar(uFacturaEDatos.Empresa empresa);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Empresa/Delete")]
        bool Empresa_Eliminar(uFacturaEDatos.Empresa empresa);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Empresa/Get")]
        uFacturaEDatos.Empresa Empresa_Obten(uFacturaEDatos.Empresa empresa);


        #endregion
        #region (EUbicacion)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/EUbicacion/Save")]
        bool EUbicacion_Guardar(uFacturaEDatos.C_Examen_Ubicacion eubica);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/EUbicacion/Delete")]
        bool EUbicacion_Eliminar(uFacturaEDatos.C_Examen_Ubicacion eubica);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/EUbicacion/Get")]
        uFacturaEDatos.C_Examen_Ubicacion EUbicacion_Obten(uFacturaEDatos.C_Examen_Ubicacion eubica);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/EUbicacion/GetS")]
        uFacturaEDatos.C_Examen_Ubicacion EUbicacion_ObtenS(uFacturaEDatos.C_Examen_Ubicacion eubica);
        #endregion
        #region (Evaluaciones)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Evaluaciones/Save")]
        bool Evaluaciones_Guardar(uFacturaEDatos.T_Evaluaciones evalua);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Evaluaciones/Delete")]
        bool Evaluaciones_Eliminar(uFacturaEDatos.T_Evaluaciones evalua);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Evaluaciones/Get")]
        uFacturaEDatos.T_Evaluaciones Evaluaciones_Obten(uFacturaEDatos.T_Evaluaciones evalua);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Evaluaciones/GetS")]
        List<uFacturaEDatos.T_Evaluaciones> Evaluaciones_ObtenS(uFacturaEDatos.T_Evaluaciones evalua);
        #endregion
        #region (Familiar)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Familiar/Save")]
        bool Familiar_Guardar(uFacturaEDatos.T_Familiar familia);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Familiar/Delete")]
        bool Familiar_Eliminar(uFacturaEDatos.T_Familiar familia);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Familiar/Get")]
        uFacturaEDatos.T_Familiar Familiar_Obten(uFacturaEDatos.T_Familiar familia);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Familiar/GetS")]
        uFacturaEDatos.T_Familiar Familiar_ObtenS(uFacturaEDatos.T_Familiar familia);
        #endregion
        #region(Folios)
        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Folios/GetFolioNuevo")]
        int Folios_GetFolioNuevo(uFacturaEDatos.Documento documento, uFacturaEDatos.Sucursales sucursal);
        #endregion
        #region (Instructores)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Instructores/Save")]
        bool Instructores_Guardar(uFacturaEDatos.C_Instructores catego);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Instructores/Get")]
        uFacturaEDatos.C_Instructores Instructores_Obten(uFacturaEDatos.C_Instructores catego);

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Instructores/GetList")]
        List<uFacturaEDatos.C_Instructores> Instructores_ObtenLista();
        #endregion
        #region (Libreta)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Libreta/Save")]
        bool Libreta_Guardar(uFacturaEDatos.T_Apartados apartado);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Libreta/Delete")]
        bool Libreta_Eliminar(DateTime date);

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Libreta/GetHorarios")]
        List<uFacturaEDatos.Cs_Horario> Libreta_ObtenHorarios();

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Libreta/GetGrupos")]
        List<uFacturaEDatos.Cs_ListaGpoDet> Libreta_ObtenGrupos(string hora, char dia);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Libreta/GetS")]
        uFacturaEDatos.T_Apartados Libreta_ObtenS(uFacturaEDatos.T_Apartados apartado);

        #endregion





        #region (MetodosPago)

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/MetodosPago/Get")]
        uFacturaEDatos.Operaciones.MetodosPago.Metodo MetodosPago_Obtener(string metodo);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/MetodosPago/GetD")]
        uFacturaEDatos.Operaciones.MetodosPago.Metodo MetodosPago_ObtenerD(string metodo);

        #endregion
        #region (Perfiles)

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Perfiles/Save")]
        bool Perfiles_Guardar(uFacturaEDatos.T_Perfiles usuario);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Perfiles/Delete")]
        bool Perfiles_Eliminar(uFacturaEDatos.T_Perfiles usuario);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Perfiles/Get")]
        uFacturaEDatos.T_Perfiles Perfiles_Obten(uFacturaEDatos.T_Perfiles usuario);

        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Perfiles/GetList")]
        List<uFacturaEDatos.T_Perfiles> Perfiles_ObtenLista();
        #endregion
        #region (Privilegios)

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Privilegios/Save")]
        bool Privilegios_Guardar(List<uFacturaEDatos.T_Grants> Privi);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Privilegios/Delete")]
        bool Privilegios_Eliminar(int UserNip);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Privilegios/Get")]
        uFacturaEDatos.T_Grants Privilegios_Obten(uFacturaEDatos.T_Grants grant);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Privilegios/GetList")]
        List<uFacturaEDatos.T_Grants> Privilegios_ObtenLista(int userNip);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Privilegios/Ver")]
        bool Privilegios_ver(string Modulo, int User_nip);
    
        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Privilegios/VerOp")]
        bool Privilegios_verop(string Modulo, int User_nip);
        #endregion
        #region (Recibo)

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Save")]
        bool Recibo_Guardar(uFacturaEDatos.Operaciones.Recibo.Recibos recibo);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Operaciones/Recibo/GetFolio")]
        bool Consulta_Folio(int SucursalID, int RemRecId);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Imprimir")]
        Stream Recibo_Imprimir(uFacturaEDatos.Operaciones.Recibo.Recibos recibo);
        //byte[] Recibo_Imprimir(uFacturaEDatos.Operaciones.Recibo.Recibos recibo);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Delete")]
        bool Recibo_Eliminar(int SucursalID, int ReciboID);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/IngresoDiario")]
        bool Recibo_RIngresoDiario(List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> detalle, List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> pago);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Get")]
        uFacturaEDatos.T_Cuotas Recibo_Obten(uFacturaEDatos.T_Cuotas cuota);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/New")]
        int Recibo_Nuevo(int SucursalID, String Cual);

        [OperationContract]
        [WebInvoke(Method = "PUT",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Update")]
        bool Recibo_ActFol(int SucursalID, String Cual, int Folio);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/GetList")]
        List<uFacturaEDatos.T_Cuotas> Recibo_ObtenLista(int socioID);

         [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Recibo/Cancel")]
        bool Recibo_Cancelar(int SucursalID, int ReciboID);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/FacturaCancel")]
        bool Recibo_CancelarFactura(int FacturaID);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Detalle")]
        List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> Recibo_DetalleIngreso(DateTime f1, DateTime f2, int Sini, int sfin);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/DetalleS")]
        List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> Recibo_DetalleIngresoS(int socioID);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/DetalleF")]
        List<uFacturaEDatos.Operaciones.Recibo.DetalleIngreso> Recibo_DetalleIngresoF(DateTime f1, DateTime f2, int Sini, int sfin, int idSucursal);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/ConceptoF")]
        List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso> Recibo_ConceptoIngresoF(DateTime f1, DateTime f2, int Sini, int sfin);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Concepto")]
        List<uFacturaEDatos.Operaciones.Recibo.ConceptoIngreso> Recibo_ConceptoIngreso(DateTime f1, DateTime f2, int Sini, int sfin);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/PagoM")]
        List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> Recibo_PagoIngresoM(DateTime f1, DateTime f2, int Sini, int sfin);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/Pago")]
        List<uFacturaEDatos.Operaciones.Recibo.PagosIngreso> Recibo_PagoIngreso(DateTime f1, DateTime f2, int Sini, int sfin);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Recibo/CajaChica")]
        List<uFacturaEDatos.Operaciones.Recibo.CajaChica> Recibo_cajaChica(DateTime f1);

        #endregion
        #region (Catego)

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/Catego/Save")]
        bool Catego_Guardar(uFacturaEDatos.T_SocioCatego catego);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/Catego/Get")]
        uFacturaEDatos.T_SocioCatego Catego_Obten(uFacturaEDatos.T_SocioCatego Catego);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Operaciones/Catego/GetS")]
        uFacturaEDatos.T_SocioCatego Catego_ObtenS(uFacturaEDatos.T_SocioCatego Catego);
        #endregion
        #region (SociosDoc)

        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Doc/Save")]
        bool Doc_Guardar(uFacturaEDatos.T_SociosDocumentos doc);

        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Doc/Get")]
        uFacturaEDatos.T_SociosDocumentos Doc_Obten(uFacturaEDatos.T_SociosDocumentos doc);

        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Doc/Delete")]
        bool Doc_Eliminar(uFacturaEDatos.T_SociosDocumentos documento);

        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Doc/GetList")]
        List<uFacturaEDatos.T_SociosDocumentos> Doc_ObtenLista(uFacturaEDatos.T_SociosDocumentos sucursal);
        #endregion
        #region (Socios)

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Socios/Save")]
        bool Socios_Guardar(uFacturaEDatos.T_Socio catego);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Socios/Get")]
        uFacturaEDatos.T_Socio Socios_Obten(uFacturaEDatos.T_Socio Catego);

        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Operaciones/Socios/GetList")]
        List<uFacturaEDatos.T_Socio> Socios_ObtenLista();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Operaciones/Socios/Imprimir")]
        Stream ListSocios_Imprimir();

        #endregion
        #region (Sucursal)

        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Sucursal/Save")]
        bool Sucursal_Guardar(uFacturaEDatos.Sucursales sucursal);

        [WebInvoke(Method = "DELETE",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Sucursal/Delete")]
        bool Sucursal_Eliminar(uFacturaEDatos.Sucursales sucursal);

        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Sucursal/Get")]
        uFacturaEDatos.Sucursales Sucursal_Obten(uFacturaEDatos.Sucursales sucursal);

        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Sucursal/GetMatrix")]
        uFacturaEDatos.Sucursales Sucursal_ObtenMatriz(uFacturaEDatos.Empresa empresa);

        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "Operaciones/Sucursal/GetList")]
        List<uFacturaEDatos.Sucursales> Sucursal_ObtenLista(uFacturaEDatos.Empresa empresa);


        #endregion
        #region (Tabular)

        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Tabular/Save")]
        bool Tabluar_Guardar(uFacturaEDatos.T_Tabular tabular);

        [WebInvoke(Method = "DELETE",
      ResponseFormat = WebMessageFormat.Json,
      RequestFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "Operaciones/Tabular/Delete")]
        bool Tabluar_Eliminar(uFacturaEDatos.T_Tabular tabular);

        [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      RequestFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "Operaciones/Tabular/Get")]
        uFacturaEDatos.T_Tabular Tabluar_Obten(uFacturaEDatos.T_Tabular tabular);

        [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      RequestFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "Operaciones/Tabular/GetList")]
        List<uFacturaEDatos.T_Tabular> Tabluar_ObtenLista(string instID);
        #endregion
        #region (Tarjetas)

        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Tarjetas/Save")]
        bool Tarjetas_Guardar(uFacturaEDatos.SociosTarjetas doc);

        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Tarjetas/Get")]
        uFacturaEDatos.SociosTarjetas Tarjetas_Obten(uFacturaEDatos.SociosTarjetas doc);

        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Tarjetas/Delete")]
        bool Tarjetas_Eliminar(uFacturaEDatos.SociosTarjetas documento);

        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Tarjetas/GetList")]
        List<uFacturaEDatos.SociosTarjetas> Tarjetas_ObtenListaS(uFacturaEDatos.SociosTarjetas sucursal);

        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Tarjetas/GetList")]
        List<uFacturaEDatos.SociosTarjetas> Tarjetas_ObtenLista();

        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Tarjetas/GetTar")]
        List<uFacturaEDatos.Operaciones.Tarjeta.STarjetas> Tarjetas_obtentar();


        #endregion
        #region (Trabajo)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Trabajo/Save")]
        bool Trabajo_Guardar(uFacturaEDatos.T_Trabajo concepto);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Trabajo/Delete")]
        bool Trabajo_Eliminar(uFacturaEDatos.T_Trabajo concepto);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Trabajo/Get")]
        uFacturaEDatos.T_Trabajo Trabajo_Obten(uFacturaEDatos.T_Trabajo concepto);

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Trabajo/GetList")]
        List<uFacturaEDatos.T_Trabajo> Trabajo_ObtenLista();
        #endregion
        #region (Usuarios)

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Usuarios/Save")]
        bool Usuarios_Guardar(uFacturaEDatos.T_Users usuario);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Usuarios/Delete")]
        bool Usuarios_Eliminar(uFacturaEDatos.T_Users usuario);

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Usuarios/Get")]
        uFacturaEDatos.T_Users Usuarios_Obten(uFacturaEDatos.T_Users usuario);

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Usuarios/GetMax")]
        uFacturaEDatos.T_Users Usuarios_ObtenMax();

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "Operaciones/Usuarios/GetList")]
        List<uFacturaEDatos.T_Users> Usuarios_ObtenLista();
        #endregion


        #endregion
    }
}
