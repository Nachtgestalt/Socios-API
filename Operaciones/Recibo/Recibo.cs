using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Socios.Datos.Utilerias;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Socios.Datos.Catalogos.DAO;
using System.Data;

namespace uFacturaEDatos.Operaciones.Recibo
{
    public class Recibo : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;



        public Recibo()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
            
        }

        public bool Guardar(Recibos recibo)
        {
            bool resultado = false;
            try
            {

                // Obtenemos El Folio del recibo
                if (recibo.bCambioFol)
                {
                    //Eliminamos el registro anterior
                    Eliminar(recibo.recibo.SucursalID, recibo.recibo.RemRecId);

                    //
                }
                    //recibo.recibo.RemRecId = Nuevo(recibo.recibo.SucursalID, recibo.tipo);
                    ////actualizamos el folio
                    //var vfolio = from fol in _db.T_Folios where fol.IdSucursal == recibo.recibo.SucursalID && fol.FolioId == recibo.tipo select fol;
                    //vfolio.First().Contador = recibo.recibo.RemRecId + 1;

                var vConcepto = from recip in _db.T_RemRec where recip.RemRecId == recibo.recibo.RemRecId && recip.SucursalID==recibo.recibo.SucursalID select recip;
                if (vConcepto.Count() == 0)
                {
                    _db.T_RemRec.InsertOnSubmit(recibo.recibo);
                    foreach (T_RemRecDet x in recibo.ReciboDet)
                    {
                        x.RemRecId = recibo.recibo.RemRecId;
                        _db.T_RemRecDet.InsertOnSubmit(x);
                    }
                    if (recibo.Cuotas != null)
                    {
                        foreach (T_Cuotas c in recibo.Cuotas)
                        {
                            var vCuota = from cuot in _db.T_Cuotas where cuot.ID == c.ID select cuot;
                            if (vCuota.Count() == 0)
                            { _db.T_Cuotas.InsertOnSubmit(c); }
                            else
                            {
                                if (vCuota.First().NoRemision == null)
                                {
                                    vCuota.First().FecPago = c.FecPago;
                                    vCuota.First().NoRemision = recibo.recibo.RemRecId;
                                    vCuota.First().Cantidad = decimal.Parse(c.Cantidad).ToString("$##,##0.00");
                                    vCuota.First().SucursalID = c.SucursalID;
                                }
                                else
                                {
                                    T_Cuotas cuo = new T_Cuotas();
                                    cuo.FecPago = c.FecPago;
                                    cuo.NoRemision = recibo.recibo.RemRecId;
                                    cuo.Cantidad = decimal.Parse(c.Cantidad).ToString("$##,##0.00");
                                    cuo.SucursalID = c.SucursalID;
                                    cuo.Fecha = vCuota.First().Fecha;
                                    cuo.MesID = vCuota.First().MesID;
                                    cuo.SocioID = vCuota.First().SocioID;
                                    _db.T_Cuotas.InsertOnSubmit(cuo);
                                }
                            }
                        }
                    }
                    if (recibo.formadepago != null)
                    {
                        List<T_Pagos> pagos = new List<T_Pagos>();
                        foreach (DetPago c in recibo.formadepago)
                        {
                            T_Pagos pago= new T_Pagos();
                            pago.Importe = c.Importe;
                            pago.PagoID=c.PagoID;
                            pago.ReciboID=recibo.recibo.RemRecId;
                            pago.Cancelado = 'N';
                            pago.Fecha = DateTime.Now;
                            pagos.Add(pago);
                        }
                        _db.T_Pagos.InsertAllOnSubmit(pagos);
                    }
                    _db.SubmitChanges();
                    resultado = true;
                }
                else
                {
                    resultado = false;
                    _mensajeErrorSistema = "";
                }    
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el recibo");
            }

            return resultado;
        }

        public bool Eliminar(int SucursalID, int ReciboID)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from recip in _db.T_RemRec where recip.SucursalID == SucursalID && recip.RemRecId == ReciboID select recip;

                if (vConcepto.Count() > 0)
                {
                    
                    _db.T_RemRec.DeleteOnSubmit(vConcepto.First());
                    var vrecdet = from recipdet in _db.T_RemRecDet where recipdet.RemRecId == ReciboID && recipdet.SucursalID == SucursalID select recipdet;
                    foreach (T_RemRecDet x in vrecdet.ToList())
                    {
                        
                       var vcuota= from cuotas in _db.T_Cuotas where (cuotas.ID==x.IDCuota) && (cuotas.NoRemision==x.RemRecId) select cuotas;
                       if (vcuota.Count() > 0)
                       {
                           vcuota.First().Cantidad = "CANCELADO";
                           vcuota.First().NoRemision = null;
                       }
                       _db.T_RemRecDet.DeleteOnSubmit(x);
                    }

                    var vpagos = from pagos in _db.T_Pagos where pagos.ReciboID == ReciboID select pagos;
                    if (vpagos.Count() > 0)
                    {
                        foreach (T_Pagos x in vpagos.ToList())
                            _db.T_Pagos.DeleteOnSubmit(x);
                    }
                    _db.SubmitChanges();
                    
                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + ReciboID + " no existe y no es posible eliminar el registro.";
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

        public bool RIngresoDiario(List<DetalleIngreso> detalle, List<PagosIngreso> pago)
        {
            bool resultado = false;
            try
            {
                List<I_IngresoDiario> ingreso = new List<I_IngresoDiario>();
                var vConcepto = from recip in _db.I_IngresoDiario  select recip;

                if (vConcepto.Count() > 0)
                {

                    _db.I_IngresoDiario.DeleteAllOnSubmit(vConcepto);
                    
                }
                foreach (DetalleIngreso x in detalle)
                { 
                     I_IngresoDiario ingre= new I_IngresoDiario();
                    ingre.Cajero=x.User_ID;
                    ingre.Cancelado=x.Cancelado;
                    ingre.Cantidad=x.Cantidad;
                    ingre.Concepto=x.Concepto;
                    if (x.Cancelado == 'S')
                    {
                        ingre.Import = 0;
                        ingre.Otros = 0;
                    }
                    else
                    {
                        ingre.Import = x.Total;
                        ingre.Otros = x.Otros;
                    }
                    ingre.Nombre=x.Nombre;
                    
                    ingre.Recibo=decimal.Parse(x.FacRecID);
                    ingre.Fecha=x.Fecha;
                    ingreso.Add(ingre);
                }
                if (detalle.Count == 0)
                {

                    I_IngresoDiario ingre = new I_IngresoDiario();
                    ingre.Cajero = "ADMIN";
                    ingre.Cancelado ='S';
                    ingre.Cantidad = 0;
                    ingre.Concepto = "Sin Datos";
                    ingre.Import = 0;
                    ingre.Nombre = "Sin Datos";
                    ingre.Otros = 0;
                    ingre.Recibo = 0;
                    ingre.Fecha = DateTime.Today;
                    ingreso.Add(ingre);
                }
                _db.I_IngresoDiario.InsertAllOnSubmit(ingreso);

                var vpagos = from pagos in _db.I_TipoIngreso select pagos;
                if (vpagos.Count() > 0)
                    _db.I_TipoIngreso.DeleteAllOnSubmit(vpagos);

                List<I_TipoIngreso> lpagos = new List<I_TipoIngreso>();
                foreach (PagosIngreso x in pago)
                {
                    I_TipoIngreso pa = new I_TipoIngreso();
                    pa.Importe = x.Total;
                    pa.Tipo = x.TipoPago;
                    lpagos.Add(pa);
                }
                _db.I_TipoIngreso.InsertAllOnSubmit(lpagos);
                resultado = true;
                _db.SubmitChanges();
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
            }

            return resultado;
        }

        public uFacturaEDatos.T_Cuotas Obten(uFacturaEDatos.T_Cuotas cuota)
        {
            try
            {
                var vConcepto = from cout in _db.T_Cuotas where cout.ID == cuota.ID select cout;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + cuota.ID.ToString() + " no existe y no es posible obtener el registro.";
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

        public int Nuevo(int SucursalID, String Cual)
        {
            try
            {
                var vConcepto = from cout in _db.T_Folios where cout.IdSucursal == SucursalID & cout.FolioId==Cual select cout.Contador;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return 0;
            }
        }
        public bool ActFol(int SucursalID, String Cual, int Folio)
        {
            try
            {
                var vConcepto = from cout in _db.T_Folios where cout.IdSucursal == SucursalID & cout.FolioId == Cual select cout;

                if (vConcepto.Count() > 0)
                {
                     vConcepto.First().Contador=Folio;
                     _db.SubmitChanges();
                     return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return false;
            }
        }

        public List<uFacturaEDatos.T_Cuotas> ObtenLista(int socioID)
        {
            try
            {
                var vConcepto = from concept in _db.T_Cuotas where concept.SocioID==socioID select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Cuotas>();
            }
        }

        public bool Cancelar(int SucursalID, int ReciboID)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from recip in _db.T_RemRec where recip.SucursalID == SucursalID && recip.RemRecId == ReciboID select recip;

                if (vConcepto.Count() > 0)
                {
                    vConcepto.First().Cancelado = 'S';
                 
                    var vrecdet = from recipdet in _db.T_RemRecDet where recipdet.RemRecId == ReciboID && recipdet.SucursalID == SucursalID select recipdet;
                    foreach (T_RemRecDet x in vrecdet.ToList())
                    {
                        var vcuota = from cuotas in _db.T_Cuotas where (cuotas.ID == x.IDCuota) && (cuotas.NoRemision==x.RemRecId) select cuotas;
                        if (vcuota.Count() > 0)
                        {
                            vcuota.First().Cantidad = null;
                            vcuota.First().FecPago = null;
                        }
                    }
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + ReciboID + " no existe y no es posible eliminar el registro.";
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

        public bool CancelarFactura( int FacturaID)
        {
            bool resultado = false;
            try
            {
                        var vcuota = from cuotas in _db.T_Cuotas where (cuotas.NoFactura == FacturaID) && (cuotas.Facturado=='F') select cuotas;
                        if (vcuota.Count() > 0)
                        {
                            foreach (T_Cuotas cuot in vcuota.ToList())
                            {
                             cuot.Cantidad = null;
                             cuot.FecPago = null;
                             cuot.NoFactura = null;
                             cuot.Facturado = null;
                            }
                        }
                    
                    _db.SubmitChanges();
                     resultado = true;
                    _mensajeErrorUsuario = "El idConcepto " + FacturaID + " no existe y no es posible eliminar el registro.";
                    resultado = false;
                
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
            }

            return resultado;
        }

        public bool ConsultaFolio(int SucursalID, int RemRecId)
        {
            try
            {
                var vConcepto = from cout in _db.T_RemRec where cout.SucursalID == SucursalID & cout.RemRecId == RemRecId select cout.RemRecId;

                if (vConcepto.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return false;
            }
        }


        public List<DetalleIngreso> DetalleIngreso(DateTime f1,DateTime f2, int Sini,int sfin)
        {
            try
            {

                var vReporte = from rep in _db.sp_DetalleIngreso(f1, f2.AddHours(23), Sini, sfin)
                               select new DetalleIngreso
                               {
                                   SocioID =(int) rep.SocioId,
                                   Nombre = rep.Nombre,
                                   FacRecID = rep.FacRecID.ToString(),
                                   ConceptoID = rep.ConceptoId,
                                   Concepto = rep.Concepto,
                                   Total =(decimal) rep.Total,
                                   Fecha =(DateTime) rep.Fecha,
                                   Cancelado =(char) rep.Cancelado,
                                   Periodo = rep.periodo,
                                   User_ID = rep.User_ID,
                                   Cantidad = (int) rep.Cantidad,
                                   Otros =(decimal) rep.Otros
                               };

                
                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<DetalleIngreso>();
            }
        }
        public List<DetalleIngreso> DetalleIngresoS(int socioID)
        {
            try
            {
                List<DetalleIngreso> ingreso = new List<Operaciones.Recibo.DetalleIngreso>();

                var vReporte =  (from rep in _db.T_RemRecDet join
                               t in _db.T_RemRec on rep.RemRecId equals t.RemRecId
                               join t0 in _db.T_Users on t.User_NIP equals
                               t0.User_NIP
                               where rep.SocioId==socioID &
                               t.Cancelado=='N'
                               orderby t.Fecha descending
                               select new DetalleIngreso
                               {
                                   SocioID = (int)rep.SocioId,
                                   Nombre = "",
                                   FacRecID = rep.RemRecId.ToString(),
                                   ConceptoID = 0,
                                   Concepto = "",
                                   Total = (decimal)rep.Total,
                                   Fecha = (DateTime)t.Fecha,
                                   Cancelado = (char)t.Cancelado,
                                   Periodo = "",
                                   User_ID = t0.User_ID,
                                   Cantidad = (int)rep.Cantidad,
                                   Otros = (decimal) t.Otros
                               }).Take(14);

                if (vReporte.ToList().Count != 0)
                {
                    foreach (DetalleIngreso x in vReporte)
                    {
                        ingreso.Add(x);
                    }
                }

                if (vReporte.ToList().Count <= 14)
                {
                    
                    //checamos si hay facturas
                   var  vReporte1 = (from rep in _db.Comprobantes_Detalles
                                    join
                                        t in _db.Comprobantes on rep.idComprobante equals t.idComprobante
                                    join t0 in _db.T_Users on t.idUsuario equals
                                    t0.User_NIP
                                    where rep.SocioID == socioID &
                                    t.Cancelado == false
                                    orderby t.FechaEmision descending
                                    select new DetalleIngreso
                                    {
                                        SocioID = (int)rep.SocioID,
                                        Nombre = "",
                                        FacRecID = t.Serie + rep.Comprobante.Folio.ToString(),
                                        ConceptoID = 0,
                                        Concepto = "",
                                        Total = (decimal)rep.Importe+rep.Impuestos_IVATraslado_Importe,
                                        Fecha = (DateTime)t.FechaEmision,
                                        Cancelado = t.Cancelado?'S':'N',
                                        Periodo = "",
                                        User_ID = t0.User_ID,
                                        Cantidad = (int)rep.Cantidad,
                                        Otros =0
                                    }).Take(14);
                   foreach (DetalleIngreso x in vReporte1)
                   {
                       ingreso.Add(x);
                   }

                }
                return ingreso;
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<DetalleIngreso>();
            }
        }
        public List<DetalleIngreso> DetalleIngresoF(DateTime f1, DateTime f2, int Sini, int sfin,int idSucursal)
        {
            try
            {

                var vReporte = from t in _db.sp_DetalleIngresoFac(f1, f2, Sini, sfin)
                               select new DetalleIngreso
                               {
                                   SocioID = (int)t.SocioId,
                                   Nombre = t.Nombre,
                                   FacRecID = t.FacRecId.ToString(),
                                   ConceptoID = t.idConcepto,
                                   Concepto = t.Descripcion,
                                   Total = (decimal)(t.Cancelado!=0? 0:t.Total),
                                   Fecha = (DateTime)t.Fecha,
                                   Cancelado = (char)(t.Cancelado!=0? 'S':'N'),
                                   Periodo = t.Fecha.Year.ToString(),
                                   User_ID = t.User_ID.ToString(),
                                   Cantidad =(int) t.Cantidad,
                                   Otros = (decimal)0
                               };


                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<DetalleIngreso>();
            }
        }
        public List<ConceptoIngreso> ConceptoIngresoF(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            try
            {

                var vReporte = from rep in _db.sp_ConceptoIngresoFac(f1, f2, Sini, sfin)
                               select new ConceptoIngreso
                               {

                                   Nombre = rep.Nombre,
                                   Totales = (decimal)rep.Totales


                               };


                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<ConceptoIngreso>();
            }
        }
        public List<ConceptoIngreso> ConceptoIngreso(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            try
            {

                var vReporte = from rep in _db.sp_ConceptoIngreso(f1, f2.AddHours(23), Sini, sfin)
                               select new ConceptoIngreso
                               {
                                   
                                   Nombre = rep.Nombre,
                                   Totales = (decimal)rep.Totales
                                   
                                  
                               };


                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<ConceptoIngreso>();
            }
        }
        public List<PagosIngreso> PagoIngresoM(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            try
            {

                var vReporte = from rep in _db.sp_PagosIngreso1(f1, f2.AddHours(23), Sini, sfin)
                               select new PagosIngreso
                               {
                                   PagoID=rep.Pagoid,
                                   TipoPago = rep.TipoPago,
                                   Total = (decimal)rep.Total


                               };


                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<PagosIngreso>();
            }
        }
        public List<PagosIngreso> PagoIngreso(DateTime f1, DateTime f2, int Sini, int sfin)
        {
            try
            {

                var vReporte = from rep in _db.sp_PagosIngreso(f1, f2.AddHours(23), Sini, sfin)
                               select new PagosIngreso
                               {

                                   TipoPago = rep.TipoPago,
                                   Total = (decimal)rep.Total


                               };


                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<PagosIngreso>();
            }
        }
        public List<CajaChica> cajaChica(DateTime f1)
        {
            try
            {

                var vReporte = from rep in _db.Sp_CajaChica(f1.ToString("dd/MM/yyyy"))
                               select new CajaChica
                               {

                                   Mov = rep.NoFactura,
                                   Referencia=rep.Referencia ,
                                   Monto=decimal.Parse(rep.Monto.ToString()),                                  
                                   Saldo = decimal.Parse(rep.Saldo.ToString()),
                                   Total = decimal.Parse((rep.Saldo + rep.Monto).ToString())

                               };
            
                return vReporte.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<CajaChica>();
            }
        }


      








    }




    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Recibos
    {
        [System.Runtime.Serialization.DataMember]
        public T_RemRec recibo{ get; set; }
        [System.Runtime.Serialization.DataMember]
        public List<T_RemRecDet> ReciboDet { get; set; }
        [System.Runtime.Serialization.DataMember]
        public List<T_Cuotas> Cuotas { get; set; }
        [System.Runtime.Serialization.DataMember]
        public String tipo{ get; set; } // cual recibo 1000 o 2000
        [System.Runtime.Serialization.DataMember]
        public bool bCambioFol { get; set; }
        [System.Runtime.Serialization.DataMember]
        public int SocioIDfact { get; set; }
        [System.Runtime.Serialization.DataMember]
        public String Coment { get; set; } // cual recibo 1000 o 2000
        [System.Runtime.Serialization.DataMember]
        public String Comentario { get; set; } // comnetario
        [System.Runtime.Serialization.DataMember]
        public List<DetPago> formadepago { get; set; } // detalle de pagos 
                
    }
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Recibodet
    {
         [System.Runtime.Serialization.DataMember]
        public int Clave { get; set; }
         [System.Runtime.Serialization.DataMember]
        public string Descripcion { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int Cantidad { get; set; }
         [System.Runtime.Serialization.DataMember]
        public decimal Descto { get; set; }
         [System.Runtime.Serialization.DataMember]
        public decimal precio { get; set; }
         [System.Runtime.Serialization.DataMember]
        public decimal Total { get; set; }
         [System.Runtime.Serialization.DataMember]
        public decimal Otros { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int Norecibo { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int NoSocio { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int IDCuota { get; set; }
       
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class DetalleIngreso
    {
        [System.Runtime.Serialization.DataMember]
        public int SocioID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Nombre { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string FacRecID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public int ConceptoID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public String Concepto { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Total { get; set; }
        [System.Runtime.Serialization.DataMember]
        public DateTime Fecha { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char Cancelado { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Periodo { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string User_ID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public int Cantidad { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Otros { get; set; }
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class ConceptoIngreso
    {
        [System.Runtime.Serialization.DataMember]
        public string Nombre { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Totales { get; set; }
        
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class DetPago
    {
        [System.Runtime.Serialization.DataMember]
        public int PagoID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Importe { get; set; }

    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class PagosIngreso
    {
        [System.Runtime.Serialization.DataMember]
        public int PagoID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string TipoPago { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Total { get; set; }
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class CajaChica
    {
        [System.Runtime.Serialization.DataMember]
        public string Mov { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Referencia { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Monto { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Saldo { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Total { get; set; }
    }

}
