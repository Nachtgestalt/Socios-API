using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.C_Aduana
{
    public class CAduana : OperacionA
    {
        public CAduana()
        {
        }

        public List<uFacturaEDatos.DatosSat.c_AduanaRow> GetAduanas()
        {
            try
            {

                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_Aduana", connection);
                    adaptador.Fill(db, "c_Aduana");

                    var codigosPostales = from cp in db.c_Aduana select cp;

                    return codigosPostales.ToList();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.DatosSat.c_AduanaRow>();
            }
        }
    }
}
