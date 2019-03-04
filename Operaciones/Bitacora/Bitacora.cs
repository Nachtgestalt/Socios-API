using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Bitacora
{
    public class Bitacora : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;
        public Bitacora()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Bitacora bitacora)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.T_Bitacora where doc.Bitacora_NIP == bitacora.Bitacora_NIP select doc;
                if (vDocumento.Count() == 0)
                {
                    _db.T_Bitacora.InsertOnSubmit(bitacora);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar la bitacora");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.T_Bitacora bitacora)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.T_Bitacora where doc.Bitacora_NIP == bitacora.Bitacora_NIP select doc;

                if (vDocumento.Count() > 0)
                {
                    bitacora = vDocumento.First();
                    _db.T_Bitacora.DeleteOnSubmit(bitacora);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + bitacora.Bitacora_NIP.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Bitacora Obten(uFacturaEDatos.T_Bitacora bitacora)
        {
            try
            {
                var vDocumento = from doc in _db.T_Bitacora where doc.Bitacora_NIP == bitacora.Bitacora_NIP select doc;

                if (vDocumento.Count() > 0)
                {
                    return vDocumento.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + bitacora.Bitacora_NIP.ToString() + " no existe y no es posible obtener el registro.";
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

        
        public List<uFacturaEDatos.T_Bitacora> ObtenLista(int UserID,DateTime Fecini,DateTime FecFin)
        {
            try
            {
                var vDocumento = from doc in _db.T_Bitacora  where doc.Bitacora_User_NIP==UserID && doc.Bitacora_Date>=Fecini && doc.Bitacora_Date<=FecFin select doc;
                return vDocumento.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Bitacora>();
            }
        }

       
    }
}
