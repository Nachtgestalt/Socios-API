using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Documentos_Formatos
{
    public class Formato : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Formato()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public List<uFacturaEDatos.Documentos_Formato> ObtenLista()
        {
            try
            {
                var vFormato = from forma in _db.Documentos_Formatos select forma;
                return vFormato.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.Documentos_Formato>();
            }
        }
    }
}
