using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.C_FormaPago
{
    public class CFormaPago : OperacionA
    {
        public CFormaPago()
        {
        }

        public List<uFacturaEDatos.DatosSat.c_FormaPagoRow> GetFormaPago()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_FormaPago", connection);
                    adaptador.Fill(db, "c_FormaPago");
                    var codigosPostales = from cp in db.c_FormaPago select cp;

                    return codigosPostales.ToList();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.DatosSat.c_FormaPagoRow>();
            }
        }
    }
}
