using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Folios
{
    public class Folio : Operacion
    {
        public Folio() { }

        public int GetFolioNuevo(uFacturaEDatos.Documento documento, uFacturaEDatos.Sucursales sucursal)
        {
            BasedatosDataContext db = new BasedatosDataContext(_connectionString);
            string resultado = db.GenerarFolioComprobante(documento.idDocumento, sucursal.idSucursal);
            if (resultado.Contains("Error:"))
            {
                throw new Exception(resultado);
            }
            else
            {
                return Convert.ToInt32(resultado.Trim());
            }
        }
    }
}
