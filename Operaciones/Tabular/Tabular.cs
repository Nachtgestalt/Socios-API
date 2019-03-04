using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Tabular
{
    public class Tabular : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;
        public Tabular()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Tabular tabular)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.T_Tabular where doc.TabularID == tabular.TabularID select doc;
                if (vDocumento.Count() == 0)
                {
                    _db.T_Tabular.InsertOnSubmit(tabular);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el tabular");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.T_Tabular tabular)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.T_Tabular where doc.TabularID == tabular.TabularID select doc;

                if (vDocumento.Count() > 0)
                {
                    tabular = vDocumento.First();
                    _db.T_Tabular.DeleteOnSubmit(tabular);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + tabular.TabularID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Tabular Obten(uFacturaEDatos.T_Tabular tabular)
        {
            try
            {
                var vDocumento = from doc in _db.T_Tabular where doc.TabularID == tabular.TabularID select doc;

                if (vDocumento.Count() > 0)
                {
                    return vDocumento.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + tabular.TabularID.ToString() + " no existe y no es posible obtener el registro.";
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

        
        public List<uFacturaEDatos.T_Tabular> ObtenLista(string instID)
        {
            try
            {
                var vDocumento = from doc in _db.T_Tabular where doc.InstructorId==instID select doc;
                return vDocumento.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Tabular>();
            }
        }

       
    }
}
