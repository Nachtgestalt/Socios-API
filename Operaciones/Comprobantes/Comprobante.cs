using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Comprobantes
{
    public class Comprobante : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Comprobante()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.Comprobante comprobante, uFacturaEDatos.Operaciones.Recibo.Recibos recibo)
        {
            bool resultado = false;
            try
            {
                var vComprobante = from cf in _db.Comprobantes where cf.idComprobante == comprobante.idComprobante select cf;
                if (vComprobante.Count() == 0)
                {
                    comprobante.Folio = Convert.ToInt32(_db.GenerarFolioComprobante(comprobante.idDocumento, comprobante.idSucursal));
                    _db.Comprobantes.InsertOnSubmit(comprobante);
                    
                    if (recibo != null)
                    {
                        if (recibo.Cuotas != null)
                        {
                            foreach (uFacturaEDatos.T_Cuotas cuota in recibo.Cuotas)
                            {
                                cuota.Facturado = 'S';
                                cuota.NoFactura = comprobante.Folio;
                                cuota.FecPago = comprobante.FechaEmision;
                                cuota.Cantidad = cuota.Cantidad;

                                var vCuota = from ct in _db.T_Cuotas where ct.ID == cuota.ID select ct;
                                if (vCuota.Count() > 0)
                                {
                                    //verificamos si ya se facturo una vez
                                    if (vCuota.First().Cantidad == null)
                                    {
                                        vCuota.First().Facturado = 'S';
                                        vCuota.First().NoFactura = comprobante.Folio;
                                        vCuota.First().FecPago = comprobante.FechaEmision;
                                        vCuota.First().Cantidad = cuota.Cantidad;
                                    }
                                    else
                                    {if (vCuota.First().Cantidad=="")
                                        {
                                            vCuota.First().Facturado = 'S';
                                            vCuota.First().NoFactura = comprobante.Folio;
                                            vCuota.First().FecPago = comprobante.FechaEmision;
                                            vCuota.First().Cantidad = cuota.Cantidad;
                                        }
                                        else
                                        {
                                        uFacturaEDatos.T_Cuotas ncuota = new T_Cuotas();
                                        ncuota.Facturado = 'S';
                                        ncuota.NoFactura = comprobante.Folio;
                                        ncuota.FecPago = comprobante.FechaEmision;
                                        ncuota.Cantidad = cuota.Cantidad;
                                        ncuota.FecPago = vCuota.First().FecPago;
                                        ncuota.SocioID = vCuota.First().SocioID;
                                        ncuota.SucursalID = vCuota.First().SucursalID;
                                        ncuota.MesID = vCuota.First().MesID;
                                        ncuota.Linea = vCuota.First().Linea;
                                        ncuota.Fecha = vCuota.First().Fecha;
                                        _db.T_Cuotas.InsertOnSubmit(ncuota);
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
               
                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el comprobante.:" + ex.Message);
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.Comprobante comprobante)
        {
            bool resultado = false;
            try
            {
                var vComprobante = from cf in _db.Comprobantes where cf.idComprobante == comprobante.idComprobante select cf;

                if (vComprobante.Count() > 0)
                {
                    comprobante = vComprobante.First();
                    _db.Comprobantes.DeleteOnSubmit(comprobante);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idComprobante " + comprobante.idComprobante.ToString() + " no existe y no es posible eliminar el registro.";
                    resultado = false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
            }

            return resultado;
        }

        public uFacturaEDatos.Comprobante Obten(uFacturaEDatos.Comprobante comprobante)
        {
            try
            {
                var vComprobante = from cf in _db.Comprobantes where cf.idComprobante == comprobante.idComprobante select cf;

                if (vComprobante.Count() > 0)
                {
                    return vComprobante.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idComprobante " + comprobante.idComprobante.ToString() + " no existe y no es posible obtener el registro.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return null;
            }
        }

        public List<uFacturaEDatos.Comprobante> ObtenLista(uFacturaEDatos.Sucursales sucursal)
        {
            try
            {
                var vComprobante = from cf in _db.Comprobantes where cf.idSucursal == sucursal.idSucursal select cf;
                return vComprobante.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.Comprobante>();
            }
        }
        public List<ReporteComprobantesEmitidos> Reporte_ComprobantesC(int idSucursal, DateTime fecha, bool mes)
        {
            try
            {
                if (!mes)
                {
                    var vReport_Dia = from t in _db.Comprobantes
                                      join t0 in _db.T_Trabajo on t.idCliente equals t0.SocioId
                                      join t1 in _db.Documentos on t.idDocumento equals t1.idDocumento
                                      where
                                        t.idSucursal == idSucursal &&
                                        t.Generado == true &&
                                        t.FechaCancelado.Value.Year == fecha.Year &&
                                        t.FechaCancelado.Value.Month == fecha.Month &&
                                        t.FechaCancelado.Value.Day == fecha.Day
                                      orderby t.Serie, t.Folio ascending
                                      select new ReporteComprobantesEmitidos
                                      {
                                          idComprobante = t.idComprobante,
                                          TipoDocumento = t1.Nombre,
                                          Serie = t.Serie,
                                          Folio = t.Folio,
                                          FechaEmision = t.FechaEmision,
                                          RfcCliente = t0.RFC,
                                          RazonSocial = t0.Nombre,
                                          Version = t.Version,
                                          Total = t.Total,
                                          Impuestos_IVATraslado_Importe = t.Impuestos_IVATraslado_Importe,
                                          Impuestos_IEPSTraslado_Importe = t.Impuestos_IEPSTraslado_Importe,
                                          Impuestos_IVARetencion_Importe = t.Impuestos_IVARetencion_Importe,
                                          Impuestos_ISRRetencion_Importe = t.Impuestos_ISRRetencion_Importe,
                                          Cancelado = t.Cancelado
                                      };

                    return vReport_Dia.ToList();
                }
                else
                {
                    var vReport_Mes = from t in _db.Comprobantes
                                      join t0 in _db.T_Trabajo on t.idCliente equals t0.SocioId
                                      join t1 in _db.Documentos on t.idDocumento equals t1.idDocumento
                                      where
                                        t.idSucursal == idSucursal &&
                                        t.Generado == true &&
                                        t.FechaCancelado.Value.Year == fecha.Year &&
                                        t.FechaCancelado.Value.Month == fecha.Month
                                      orderby t.Serie, t.Folio ascending
                                      select new ReporteComprobantesEmitidos
                                      {
                                          idComprobante = t.idComprobante,
                                          TipoDocumento = t1.Nombre,
                                          Serie = t.Serie,
                                          Folio = t.Folio,
                                          FechaEmision = t.FechaEmision,
                                          RfcCliente = t0.RFC,
                                          RazonSocial = t0.Nombre,
                                          Version = t.Version,
                                          Total = t.Total,
                                          Impuestos_IVATraslado_Importe = t.Impuestos_IVATraslado_Importe,
                                          Impuestos_IEPSTraslado_Importe = t.Impuestos_IEPSTraslado_Importe,
                                          Impuestos_IVARetencion_Importe = t.Impuestos_IVARetencion_Importe,
                                          Impuestos_ISRRetencion_Importe = t.Impuestos_ISRRetencion_Importe,
                                          Cancelado = t.Cancelado
                                      };

                    return vReport_Mes.ToList();
                }

            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<ReporteComprobantesEmitidos>();
            }
        }
        public List<ReporteComprobantesEmitidos> Reporte_Comprobantes(int idSucursal, DateTime fecha, bool mes)
        {
            try
            {
                if (!mes)
                {
                    var vReport_Dia = from t in _db.Comprobantes
                                      join t0 in _db.T_Trabajo on t.idCliente equals t0.SocioId
                                      join t1 in _db.Documentos on t.idDocumento equals t1.idDocumento
                                      where
                                        t.idSucursal == idSucursal &&
                                        t.Generado == true &&
                                        t.FechaEmision.Year == fecha.Year &&
                                        t.FechaEmision.Month == fecha.Month &&
                                        t.FechaEmision.Day == fecha.Day
                                      orderby t.Serie, t.Folio ascending
                                      select new ReporteComprobantesEmitidos
                                      {
                                          idComprobante = t.idComprobante,
                                          TipoDocumento = t1.Nombre,
                                          Serie = t.Serie,
                                          Folio = t.Folio,
                                          FechaEmision = t.FechaEmision,
                                          RfcCliente = t0.RFC,
                                          RazonSocial = t0.Nombre,
                                          Version = t.Version,
                                          Total = t.Cancelado ? 0 : t.Total,
                                          Impuestos_IVATraslado_Importe = t.Cancelado ? 0 : t.Impuestos_IVATraslado_Importe,
                                          Impuestos_IEPSTraslado_Importe = t.Cancelado ? 0 : t.Impuestos_IEPSTraslado_Importe,
                                          Impuestos_IVARetencion_Importe = t.Cancelado ? 0 : t.Impuestos_IVARetencion_Importe,
                                          Impuestos_ISRRetencion_Importe = t.Cancelado ? 0 : t.Impuestos_ISRRetencion_Importe,
                                          Cancelado = t.Cancelado
                                      };

                    return vReport_Dia.ToList();
                }
                else
                {
                    var vReport_Mes = from t in _db.Comprobantes
                                      join t0 in _db.T_Trabajo on t.idCliente equals t0.SocioId
                                      join t1 in _db.Documentos on t.idDocumento equals t1.idDocumento
                                      where
                                        t.idSucursal == idSucursal &&
                                        t.Generado == true &&
                                        t.FechaEmision.Year == fecha.Year &&
                                        t.FechaEmision.Month == fecha.Month
                                      orderby t.Serie, t.Folio ascending
                                      select new ReporteComprobantesEmitidos
                                      {
                                          idComprobante = t.idComprobante,
                                          TipoDocumento = t1.Nombre,
                                          Serie = t.Serie,
                                          Folio = t.Folio,
                                          FechaEmision = t.FechaEmision,
                                          RfcCliente = t0.RFC,
                                          RazonSocial = t0.Nombre,
                                          Version = t.Version,
                                          Total = t.Cancelado ? 0 : t.Total,
                                          Impuestos_IVATraslado_Importe = t.Cancelado ? 0 : t.Impuestos_IVATraslado_Importe,
                                          Impuestos_IEPSTraslado_Importe = t.Cancelado ? 0 : t.Impuestos_IEPSTraslado_Importe,
                                          Impuestos_IVARetencion_Importe = t.Cancelado ? 0 : t.Impuestos_IVARetencion_Importe,
                                          Impuestos_ISRRetencion_Importe = t.Cancelado ? 0 : t.Impuestos_ISRRetencion_Importe,
                                          Cancelado = t.Cancelado
                                      };

                    return vReport_Mes.ToList();
                }

            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<ReporteComprobantesEmitidos>();
            }
        }

        public List<ReporteComprobantesEmitidosDetalle> Reporte_Comprobantes_Detalle(int idSucursal, DateTime fecha, bool mes)
        {
            try
            {
                if (mes)
                {
                    var vReporte_Mes = from t in _db.Comprobantes_Detalles
                                       join t0 in _db.Comprobantes on t.idComprobante equals t0.idComprobante
                                       join t1 in _db.Documentos on t0.idDocumento equals t1.idDocumento
                                       where
                                         t0.idSucursal == idSucursal &&
                                         t0.Generado == true &&
                                         t0.FechaEmision.Year == fecha.Year &&
                                         t0.FechaEmision.Month == fecha.Month
                                       orderby
                                         t0.Serie,
                                         t0.Folio
                                       select new ReporteComprobantesEmitidosDetalle
                                       {
                                           idComprobante = t0.idComprobante,
                                           TipoDocumento = t1.Nombre,
                                           Serie = t0.Serie,
                                           Folio = t0.Folio,
                                           FechaEmision = t0.FechaEmision,
                                           Cancelado = t0.Cancelado,
                                           NoIdentificacion = t.NoIdentificacion,
                                           Descripcion = t.Descripcion,
                                           Unidad = t.Unidad,
                                           Cantidad = t.Cantidad,
                                           ValorUnitario = t.ValorUnitario,
                                           Importe = t.Importe,
                                           Descuento_Importe = t.Descuento_Importe,
                                           Impuestos_IVATraslado_Importe = t.Impuestos_IVATraslado_Importe,
                                           Impuestos_IEPSTraslado_Importe = t.Impuestos_IEPSTraslado_Importe,
                                           Impuestos_IVARetencion_Importe = t.Impuestos_IVARetencion_Importe,
                                           Impuestos_ISRRetencion_Importe = t.Impuestos_ISRRetencion_Importe
                                       };

                    return vReporte_Mes.ToList();
                }
                else
                {
                    var vReporte_Dia = from t in _db.Comprobantes_Detalles
                                       join t0 in _db.Comprobantes on t.idComprobante equals t0.idComprobante
                                       join t1 in _db.Documentos on t0.idDocumento equals t1.idDocumento
                                       where
                                         t0.idSucursal == idSucursal &&
                                         t0.Generado == true &&
                                         t0.FechaEmision.Year == fecha.Year &&
                                         t0.FechaEmision.Month == fecha.Month &&
                                         t0.FechaEmision.Day == fecha.Day
                                       orderby
                                         t0.Serie,
                                         t0.Folio
                                       select new ReporteComprobantesEmitidosDetalle
                                       {
                                           idComprobante = t0.idComprobante,
                                           TipoDocumento = t1.Nombre,
                                           Serie = t0.Serie,
                                           Folio = t0.Folio,
                                           FechaEmision = t0.FechaEmision,
                                           Cancelado = t0.Cancelado,
                                           NoIdentificacion = t.NoIdentificacion,
                                           Descripcion = t.Descripcion,
                                           Unidad = t.Unidad,
                                           Cantidad = t.Cantidad,
                                           ValorUnitario = t.ValorUnitario,
                                           Importe = t.Importe,
                                           Descuento_Importe = t.Descuento_Importe,
                                           Impuestos_IVATraslado_Importe = t.Impuestos_IVATraslado_Importe,
                                           Impuestos_IEPSTraslado_Importe = t.Impuestos_IEPSTraslado_Importe,
                                           Impuestos_IVARetencion_Importe = t.Impuestos_IVARetencion_Importe,
                                           Impuestos_ISRRetencion_Importe = t.Impuestos_ISRRetencion_Importe
                                       };

                    return vReporte_Dia.ToList();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<ReporteComprobantesEmitidosDetalle>();
            }
        }

        public List<ReporteCobranza> Reporte_Cobranza(int idSucursal)
        {
            try
            {
                List<ReporteCobranza> lst = new List<ReporteCobranza>();

                var vReporte = from rep in _db.sp_Reporte_Cobranza(idSucursal)
                               select new ReporteCobranza
                               {
                                   NombreSucursal = rep.NombreSucursal,
                                   TipoDocumento = rep.TipoDocumento,
                                   Serie = rep.Serie,
                                   Folio = rep.Folio,
                                   RfcCliente = rep.RfcCliente,
                                   RazonSocial = rep.RazonSocial,
                                   Total = rep.Total,
                                   Saldo = rep.Saldo,
                                   Pagado = rep.Pagado,
                                   PlazoPagoDias = rep.PlazoPagoDias,
                                   FechaEmision = rep.FechaEmision,
                                   DiasTranscurridos = Convert.ToInt32(rep.DiasTranscurridos),
                                   idComprobante = rep.idComprobante
                               };

                foreach (ReporteCobranza rep in vReporte)
                {
                    rep.Abonos = Reporte_Abonos(rep.idComprobante);
                    lst.Add(rep);
                }

                return lst;
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<ReporteCobranza>();
            }
        }

        public List<ReporteAbonos> Reporte_Abonos(int idComprobante)
        {
            try
            {
                var vReporte = from rep in _db.sp_Reporte_Abonos_Comprobante(idComprobante)
                               select new ReporteAbonos
                               {
                                   //idCXC = rep.idCXC,
                                   idComprobante = rep.idComprobante,
                                   Importe = rep.Importe,
                                   Abono = rep.Abono,
                                   Saldo = rep.Saldo,
                                   Fecha = rep.Fecha,
                                   Referencia = rep.Referencia
                               };

                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<ReporteAbonos>();
            }
        }
    }

    public class ReporteComprobantesEmitidos
    {
        public int idComprobante { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public DateTime FechaEmision { get; set; }
        public string RfcCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Version { get; set; }
        public decimal Total { get; set; }
        public decimal Impuestos_IVATraslado_Importe { get; set; }
        public decimal Impuestos_IEPSTraslado_Importe { get; set; }
        public decimal Impuestos_IVARetencion_Importe { get; set; }
        public decimal Impuestos_ISRRetencion_Importe { get; set; }
        public bool Cancelado { get; set; }
    }

    public class ReporteComprobantesEmitidosDetalle
    {
        public int idComprobante { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool Cancelado { get; set; }
        public string NoIdentificacion { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento_Importe { get; set; }
        public decimal Impuestos_IVATraslado_Importe { get; set; }
        public decimal Impuestos_IEPSTraslado_Importe { get; set; }
        public decimal Impuestos_IVARetencion_Importe { get; set; }
        public decimal Impuestos_ISRRetencion_Importe { get; set; }
    }

    public class ReporteCobranza
    {
        public string NombreSucursal { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public string RfcCliente { get; set; }
        public string RazonSocial { get; set; }
        public decimal Total { get; set; }
        public decimal Saldo { get; set; }
        public bool Pagado { get; set; }
        public int PlazoPagoDias { get; set; }
        public DateTime FechaEmision { get; set; }
        public int DiasTranscurridos { get; set; }
        public int idComprobante { get; set; }
        public List<ReporteAbonos> Abonos { get; set; }
    }

    public class ReporteAbonos
    {
        //public int idCXC { get; set; }
        public int idComprobante { get; set; }
        public decimal Importe { get; set; }
        public decimal Abono { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha { get; set; }
        public string Referencia { get; set; }
    }
}
