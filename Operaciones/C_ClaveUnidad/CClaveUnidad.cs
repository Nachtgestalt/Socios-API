using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.C_ClaveUnidad
{
    public class CClaveUnidad : OperacionA
    {
        public CClaveUnidad()
        {
        }

        public List<uFacturaEDatos.DatosSat.c_ClaveUnidadRow> GetClaveUnidad()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_ClaveUnidad", connection);
                    adaptador.Fill(db, "c_ClaveUnidad");
                    var codigosPostales = from cp in db.c_ClaveUnidad select cp;

                    return codigosPostales.ToList();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.DatosSat.c_ClaveUnidadRow>();
            }
        }
    }
}
