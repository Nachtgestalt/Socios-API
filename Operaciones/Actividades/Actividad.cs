using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Actividades
{
    public class Actividad : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;
        public Actividad()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.C_Areas area)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.C_Areas where doc.AreaId == area.AreaId select doc;
                if (vDocumento.Count() == 0)
                {
                    _db.C_Areas.InsertOnSubmit(area);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el area");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.C_Areas area)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.C_Areas where doc.AreaId == area.AreaId select doc;

                if (vDocumento.Count() > 0)
                {
                    area = vDocumento.First();
                    _db.C_Areas.DeleteOnSubmit(area);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "La actividad " + area.AreaId.ToString() + " no existe o no es posible eliminar el registro.";
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

        public uFacturaEDatos.C_Areas Obten(uFacturaEDatos.C_Areas documento)
        {
            try
            {
                var vDocumento = from doc in _db.C_Areas where doc.AreaId == documento.AreaId select doc;

                if (vDocumento.Count() > 0)
                {
                    return vDocumento.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idDocumento " + documento.AreaId.ToString() + " no existe y no es posible obtener el registro.";
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

        
        public List<uFacturaEDatos.C_Areas> ObtenLista()
        {
            try
            {
                var vDocumento = from doc in _db.C_Areas  select doc;
                return vDocumento.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.C_Areas>();
            }
        }

       
    }
}
