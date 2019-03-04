using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace uFacturaEDatos.Operaciones.C_Metodo
{
    public class CMetodPago : OperacionA
    {
        public CMetodPago()
        {
        }
        public String GetDescripcion(String clave)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_MetodoPago where clave='" + clave + "'", connection);
                    adaptador.Fill(db, "c_MetodoPago");
                    var codigosPostales = from cp in db.c_MetodoPago select cp;

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
        public string GetMetodoPago()
        {
            try
            {
                DataTable dt = new DataTable();
                using (OleDbConnection connection = new OleDbConnection(DbConnString))
                {
                    DatosSat db = new DatosSat();
                    OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from c_MetodoPago", connection);
                    adaptador.Fill(db, "c_MetodoPago");
                    var codigosPostales = from cp in db.c_MetodoPago select cp;
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
                    //return codigosPostales.ToList();
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
