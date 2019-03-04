using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace uFacturaEDatos.Operaciones.C_UsoCFDI
{
    public class CUsoCFDI : OperacionA
    {
        public CUsoCFDI()
        {
        }
        public String GetDescr(String Clave)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_UsoCFDI where clave='" + Clave + "'", connection);
                    adaptador.Fill(db, "c_UsoCFDI");
                    var codigosPostales = from cp in db.c_UsoCFDI select cp;

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
        public string GetUsoCFDI()
        {
            try
            {
                DataTable dt = new DataTable(); 
                DatosSat.c_UsoCFDIDataTable f = new DatosSat.c_UsoCFDIDataTable();
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_UsoCFDI", connection);
                    adaptador.Fill(db, "c_UsoCFDI");
                    var codigosPostales = from cp in db.c_UsoCFDI select cp;
                    dt = codigosPostales.CopyToDataTable();

                    var list = new List<Dictionary<string, object>>();

                    foreach (DataRow row in dt.Rows)
                    {
                        var dict = new Dictionary<string, object>();
                       
                        foreach (DataColumn col in dt.Columns)
                        {
                            dict[col.ColumnName] = (Convert.ToString(row[col]));
                        }
                        list.Add(dict);
                    }
                    
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Serialize(list);
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                
                return ex.Message;
            }
        }
    }
}
