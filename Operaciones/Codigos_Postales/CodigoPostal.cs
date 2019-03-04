using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Codigos_Postales
{
    public class CodigoPostal : Operacion
    {
        public CodigoPostal()
        {
        }

        public List<uFacturaEDatos.CodigosPostale> ConsultaCP(int codigoPostal)
        {
            try
            {
                uFacturaEDatos.CodigosPostalesDataContext db = new uFacturaEDatos.CodigosPostalesDataContext(_connectionString);
                var codigosPostales = from cp in db.CodigosPostales where cp.d_codigo == codigoPostal select cp;

                return codigosPostales.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.CodigosPostale>();
            }
        }
    }
}
