using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.OleDb;

namespace uFacturaEDatos.Operaciones.C_RegimenFiscal
{
    public class CRegimenFiscal : OperacionA
    {
        
        public CRegimenFiscal()
        {
            
        }
        public String Regimen(String clave)
        {
            String strrg;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_RegimenFiscal where clave=" + clave, connection);
                    adaptador.Fill(db, "c_RegimenFiscal");
                    var codigosPostales = from cp in db.c_RegimenFiscal select cp;

                    return codigosPostales.First().Descripción;
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return null;
            }

        }
      

        public List<uFacturaEDatos.DatosSat.c_RegimenFiscalRow> GetRegimenFiscal()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                
                   {
                       DatosSat db = new DatosSat();
                       OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_RegimenFiscal", connection);
                       adaptador.Fill(db, "c_RegimenFiscal");
                    
                     var codigosPostales = from cp in db.c_RegimenFiscal select cp;

                    return codigosPostales.ToList();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.DatosSat.c_RegimenFiscalRow>();
            }
        }
    }
}
