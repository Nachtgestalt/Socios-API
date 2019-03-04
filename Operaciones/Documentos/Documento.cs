using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Documentos
{
    public class Documento : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;
        public Documento()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.Documento documento)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.Documentos where doc.idDocumento == documento.idDocumento select doc;
                if (vDocumento.Count() == 0)
                {
                    _db.Documentos.InsertOnSubmit(documento);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el documento");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.Documento documento)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.Documentos where doc.idDocumento == documento.idDocumento select doc;

                if (vDocumento.Count() > 0)
                {
                    documento = vDocumento.First();
                    _db.Documentos.DeleteOnSubmit(documento);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + documento.idDocumento.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.Documento Obten(uFacturaEDatos.Documento documento)
        {
            try
            {
                var vDocumento = from doc in _db.Documentos where doc.idDocumento == documento.idDocumento select doc;

                if (vDocumento.Count() > 0)
                {
                    return vDocumento.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + documento.idDocumento.ToString() + " no existe y no es posible obtener el registro.";
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

        public uFacturaEDatos.Documento Obten(int idFormato, uFacturaEDatos.Sucursales sucursal)
        {
            try
            {
                var vDocumento = from doc in _db.Documentos where doc.idSucursal == sucursal.idSucursal && doc.idFormato == idFormato && doc.Activo == true select doc;

                if (vDocumento.Count() > 0)
                {
                    uFacturaEDatos.Documento d = new uFacturaEDatos.Documento();
                    d.Activo = vDocumento.FirstOrDefault().Activo;
                    d.AnoAprobacion = vDocumento.FirstOrDefault().AnoAprobacion;
                    d.Comprobantes = vDocumento.FirstOrDefault().Comprobantes;
                    d.FolioInicial = vDocumento.FirstOrDefault().FolioInicial;
                    d.FoliosFinal = vDocumento.FirstOrDefault().FoliosFinal;
                    d.FoliosSerie = vDocumento.FirstOrDefault().FoliosSerie;
                    d.idDocumento = vDocumento.FirstOrDefault().idDocumento;
                    d.idFormato = vDocumento.FirstOrDefault().idFormato;
                    d.idSucursal = vDocumento.FirstOrDefault().idSucursal;
                    d.Impuestos_TasaIEPSTraslado = vDocumento.FirstOrDefault().Impuestos_TasaIEPSTraslado;
                    d.Impuestos_TasaISRRetencion = vDocumento.FirstOrDefault().Impuestos_TasaISRRetencion;
                    d.Impuestos_TasaIVARetencion = vDocumento.FirstOrDefault().Impuestos_TasaIVARetencion;
                    d.Impuestos_TasaIVATraslado = vDocumento.FirstOrDefault().Impuestos_TasaIVATraslado;
                    d.NoAprobacion = vDocumento.FirstOrDefault().NoAprobacion;
                    d.Nombre = vDocumento.FirstOrDefault().Nombre;
                    d.OpLabel1 = vDocumento.FirstOrDefault().OpLabel1;
                    d.OpLabel2 = vDocumento.FirstOrDefault().OpLabel2;
                    d.OpLabel3 = vDocumento.FirstOrDefault().OpLabel3;
                    d.OpLabel4 = vDocumento.FirstOrDefault().OpLabel4;
                    d.OpLabel5 = vDocumento.FirstOrDefault().OpLabel5;
                    d.OpLabel6 = vDocumento.FirstOrDefault().OpLabel6;
                    d.OpLabel7 = vDocumento.FirstOrDefault().OpLabel7;
                    d.OpLabel8 = vDocumento.FirstOrDefault().OpLabel8;
                    d.OpLabel9 = vDocumento.FirstOrDefault().OpLabel9;
                    d.OpLabel10 = vDocumento.FirstOrDefault().OpLabel10;

                    d.Tipo = vDocumento.FirstOrDefault().Tipo;
                    d.Version = vDocumento.FirstOrDefault().Version;
                    d.VigenciaDesde = vDocumento.FirstOrDefault().VigenciaDesde;
                    d.VigenciaHasta = vDocumento.FirstOrDefault().VigenciaHasta;
                    return d;
                }
                else
                {
                    _mensajeErrorUsuario = "El tipo de documento no existe o no esta activo.";
                   
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

        public List<uFacturaEDatos.Documento> ObtenLista(uFacturaEDatos.Sucursales sucursal)
        {
            try
            {
                var vDocumento = from doc in _db.Documentos where doc.idSucursal == sucursal.idSucursal select doc;
                return vDocumento.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.Documento>();
            }
        }

        public List<uFacturaEDatos.Documento> GenerarDocsDefault()
        {
            uFacturaEDatos.Documento documento = null;
            List<uFacturaEDatos.Documento> lstResultado = null;
            try
            {
                lstResultado = new List<uFacturaEDatos.Documento>();

                documento = new uFacturaEDatos.Documento();
                documento.Nombre = "Factura";
                documento.Tipo = "Ingreso";
                documento.idFormato = 1;
                documento.Version = "3.2";
                documento.NoAprobacion = 0;
                documento.AnoAprobacion = DateTime.Now.Year;
                documento.FolioInicial = 1;
                documento.FoliosFinal = 9999;
                documento.FoliosSerie = "F";
                documento.RutaCBB = "";
                documento.VigenciaDesde = DateTime.Now;
                documento.VigenciaHasta = DateTime.Now.AddYears(2);
                documento.Impuestos_TasaIVATraslado = Convert.ToDecimal(0.16);
                documento.Activo = true;
                documento.OpLabel1 = "";
                documento.OpLabel2 = "";
                documento.OpLabel3 = "";
                documento.OpLabel4 = "";
                documento.OpLabel5 = "";
                documento.OpLabel6 = "";
                documento.OpLabel7 = "";
                documento.OpLabel8 = "";
                documento.OpLabel9 = "";
                documento.OpLabel10 = "";

                lstResultado.Add(documento);

                documento = new uFacturaEDatos.Documento();
                documento.Nombre = "Nota de venta";
                documento.Tipo = "Ingreso";
                documento.idFormato = 2;
                documento.Version = "N/A";
                documento.NoAprobacion = 0;
                documento.AnoAprobacion = DateTime.Now.Year;
                documento.FolioInicial = 1;
                documento.FoliosFinal = 9999;
                documento.FoliosSerie = "NV";
                documento.RutaCBB = "";
                documento.VigenciaDesde = DateTime.Now;
                documento.VigenciaHasta = DateTime.Now.AddYears(2);
                documento.Impuestos_TasaIVATraslado = Convert.ToDecimal(0.16);
                documento.Activo = true;
                documento.OpLabel1 = "";
                documento.OpLabel2 = "";
                documento.OpLabel3 = "";
                documento.OpLabel4 = "";
                documento.OpLabel5 = "";
                documento.OpLabel6 = "";
                documento.OpLabel7 = "";
                documento.OpLabel8 = "";
                documento.OpLabel9 = "";
                documento.OpLabel10 = "";

                lstResultado.Add(documento);

                documento = new uFacturaEDatos.Documento();
                documento.Nombre = "Nota de crédito";
                documento.Tipo = "Egreso";
                documento.idFormato = 3;
                documento.Version = "3.2";
                documento.NoAprobacion = 0;
                documento.AnoAprobacion = DateTime.Now.Year;
                documento.FolioInicial = 1;
                documento.FoliosFinal = 9999;
                documento.FoliosSerie = "NC";
                documento.RutaCBB = "";
                documento.VigenciaDesde = DateTime.Now;
                documento.VigenciaHasta = DateTime.Now.AddYears(2);
                documento.Impuestos_TasaIVATraslado = Convert.ToDecimal(0.16);
                documento.Activo = true;
                documento.OpLabel1 = "";
                documento.OpLabel2 = "";
                documento.OpLabel3 = "";
                documento.OpLabel4 = "";
                documento.OpLabel5 = "";
                documento.OpLabel6 = "";
                documento.OpLabel7 = "";
                documento.OpLabel8 = "";
                documento.OpLabel9 = "";
                documento.OpLabel10 = "";

                lstResultado.Add(documento);

                documento = new uFacturaEDatos.Documento();
                documento.Nombre = "Carta Porte";
                documento.Tipo = "Ingreso";
                documento.idFormato = 4;
                documento.Version = "3.2";
                documento.NoAprobacion = 0;
                documento.AnoAprobacion = DateTime.Now.Year;
                documento.FolioInicial = 1;
                documento.FoliosFinal = 9999;
                documento.FoliosSerie = "CP";
                documento.RutaCBB = "";
                documento.VigenciaDesde = DateTime.Now;
                documento.VigenciaHasta = DateTime.Now.AddYears(2);
                documento.Impuestos_TasaIVATraslado = Convert.ToDecimal(0.16);
                documento.Activo = true;
                documento.OpLabel1 = "";
                documento.OpLabel2 = "";
                documento.OpLabel3 = "";
                documento.OpLabel4 = "";
                documento.OpLabel5 = "";
                documento.OpLabel6 = "";
                documento.OpLabel7 = "";
                documento.OpLabel8 = "";
                documento.OpLabel9 = "";
                documento.OpLabel10 = "";

                lstResultado.Add(documento);
                
                documento = new uFacturaEDatos.Documento();
                documento.Nombre = "Recibo de honorarios";
                documento.Tipo = "Ingreso";
                documento.idFormato = 5;
                documento.Version = "3.2";
                documento.NoAprobacion = 0;
                documento.AnoAprobacion = DateTime.Now.Year;
                documento.FolioInicial = 1;
                documento.FoliosFinal = 9999;
                documento.FoliosSerie = "F";
                documento.RutaCBB = "";
                documento.VigenciaDesde = DateTime.Now;
                documento.VigenciaHasta = DateTime.Now.AddYears(2);
                documento.Impuestos_TasaIVATraslado = Convert.ToDecimal(0.16);
                documento.Activo = true;
                documento.OpLabel1 = "";
                documento.OpLabel2 = "";
                documento.OpLabel3 = "";
                documento.OpLabel4 = "";
                documento.OpLabel5 = "";
                documento.OpLabel6 = "";
                documento.OpLabel7 = "";
                documento.OpLabel8 = "";
                documento.OpLabel9 = "";
                documento.OpLabel10 = "";

                lstResultado.Add(documento);

                documento = new uFacturaEDatos.Documento();
                documento.Nombre = "Recibo de arrendamiento";
                documento.Tipo = "Ingreso";
                documento.idFormato = 6;
                documento.Version = "3.2";
                documento.NoAprobacion = 0;
                documento.AnoAprobacion = DateTime.Now.Year;
                documento.FolioInicial = 1;
                documento.FoliosFinal = 9999;
                documento.FoliosSerie = "F";
                documento.RutaCBB = "";
                documento.VigenciaDesde = DateTime.Now;
                documento.VigenciaHasta = DateTime.Now.AddYears(2);
                documento.Impuestos_TasaIVATraslado = Convert.ToDecimal(0.16);
                documento.Activo = true;
                documento.OpLabel1 = "";
                documento.OpLabel2 = "";
                documento.OpLabel3 = "";
                documento.OpLabel4 = "";
                documento.OpLabel5 = "";
                documento.OpLabel6 = "";
                documento.OpLabel7 = "";
                documento.OpLabel8 = "";
                documento.OpLabel9 = "";
                documento.OpLabel10 = "";

                lstResultado.Add(documento);

                return lstResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
