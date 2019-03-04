using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.SocioDoc
{
    public class Doc : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Doc()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_SociosDocumentos doc)
        {
            bool resultado = false;
            try
            {
                var vCat = from Cat in _db.T_SociosDocumentos where Cat.DocSocioID == doc.DocSocioID select Cat;
                if (vCat.Count() == 0)
                {
                    _db.T_SociosDocumentos.InsertOnSubmit(doc);
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
        public uFacturaEDatos.T_SociosDocumentos Obten(uFacturaEDatos.T_SociosDocumentos doc)
        {
            try
            {
                var vCatego = from cli in _db.T_SociosDocumentos where cli.DocSocioID == doc.DocSocioID select cli;

                if (vCatego.Count() > 0)
                {
                    return vCatego.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El Catego " + doc.DocSocioID.ToString() + " no existe y no es posible obtener el registro.";
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


        
        public bool Eliminar(uFacturaEDatos.T_SociosDocumentos documento)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.T_SociosDocumentos where doc.DocSocioID == documento.DocSocioID select doc;

                if (vDocumento.Count() > 0)
                {
                    documento = vDocumento.First();
                    _db.T_SociosDocumentos.DeleteOnSubmit(documento);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + documento.DocSocioID.ToString() + " no existe y no es posible eliminar el registro.";
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

        


        public List<uFacturaEDatos.T_SociosDocumentos> ObtenLista(uFacturaEDatos.T_SociosDocumentos sucursal)
        {
            try
            {
                var vDocumento = from doc in _db.T_SociosDocumentos where doc.SocioID == sucursal.SocioID select doc;
                return vDocumento.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_SociosDocumentos>();
            }
        }
    }
}
