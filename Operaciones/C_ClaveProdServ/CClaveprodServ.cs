using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.C_ClaveProdServ
{
    public class CClaveProdServ : OperacionA
    {
        public CClaveProdServ()
        {
        }

        public List<uFacturaEDatos.DatosSat.c_ClaveProdServRow> GetClaveProdServ()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_ClaveProdServ", connection);
                    adaptador.Fill(db, "c_ClaveProdServ");
                    var codigosPostales = from cp in db.c_ClaveProdServ select cp;

                    return codigosPostales.ToList();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.DatosSat.c_ClaveProdServRow>();
            }
        }
    }
}
