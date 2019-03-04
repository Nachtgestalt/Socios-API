using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.Tarjeta
{
    public class Tarjetas : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Tarjetas()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.SociosTarjetas doc)
        {
            bool resultado = false;
            try
            {
                doc.Tarjeta = App_Code.cGlobal.Encrypt(doc.Tarjeta);
                var vCat = from Cat in _db.SociosTarjetas where Cat.SocioID == doc.SocioID select Cat;
                if (vCat.Count() == 0)
                {
                    _db.SociosTarjetas.InsertOnSubmit(doc);
                }

                _db.SubmitChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el documento");
            }

            return resultado;
        }
        public uFacturaEDatos.SociosTarjetas Obten(uFacturaEDatos.SociosTarjetas doc)
        {
            try
            {
                var vCatego = from cli in _db.SociosTarjetas where cli.SocioID == doc.SocioID select cli;

                if (vCatego.Count() > 0)
                {
                    SociosTarjetas tar = vCatego.First();
                    tar.Tarjeta = App_Code.cGlobal.Decrypt(tar.Tarjeta);

                    return tar;
                }
                else
                {
                    _mensajeErrorUsuario = "la tarjeta " + doc.SocioID.ToString() + " no existe y no es posible obtener el registro.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return null;
            }
        }


        
        public bool Eliminar(uFacturaEDatos.SociosTarjetas documento)
        {
            bool resultado = false;
            try
            {
                var vDocumento = from doc in _db.SociosTarjetas where doc.SocioID == documento.SocioID select doc;

                if (vDocumento.Count() > 0)
                {
                    documento = vDocumento.First();
                    _db.SociosTarjetas.DeleteOnSubmit(documento);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "la tarjeta " + documento.SocioID.ToString() + " no existe y no es posible eliminar el registro.";
                    resultado = false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
            }

            return resultado;
        }

        


        public List<uFacturaEDatos.SociosTarjetas> ObtenLista(uFacturaEDatos.SociosTarjetas sucursal)
        {
            try
            {
                var vDocumento = from doc in _db.SociosTarjetas where doc.SocioID == sucursal.SocioID select doc;
                return vDocumento.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.SociosTarjetas>();
            }
        }
        public List<uFacturaEDatos.SociosTarjetas> ObtenLista()
        {
            try
            {
                var vDocumento = from doc in _db.SociosTarjetas  select doc;
                return vDocumento.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.SociosTarjetas>();
            }
        }
        private string limpia(string s)
        {
            string no = "1234567890";
            string res = "";
            foreach (Char c in s.ToCharArray())
            {
                if (no.IndexOf(c) > -1)
                {
                    res = res + c;
                }
            }
            return res;
        }
        public List<STarjetas> obtentar()
        {
            var vReport_Mes = from t in _db.T_Socio
                              join t0 in _db.SociosTarjetas on t.SocioId equals t0.SocioID
                               where
                                t.Socio_Anterior == 'N' && t.Nombre != ""
                                orderby t0.Tarjeta   
                              select new STarjetas
                              {
                                  tarjeta = App_Code.cGlobal.Decrypt(t0.Tarjeta),
                                  NoSocio=t.SocioId.ToString(),
                                  Socio = t.Nombre,
                                  Importe = limpia(t.Nacionalidad),
                                  sel=false
                              };
            List<STarjetas> listado = new List<STarjetas>();
            string tarjeta = "";
            STarjetas tar= new STarjetas();
            foreach (STarjetas x in vReport_Mes.ToList())
            {
                if (tarjeta != x.tarjeta)
                {
                    tar = new STarjetas();
                    tarjeta = x.tarjeta;
                    tar.Importe = x.Importe;
                    tar.NoSocio = x.NoSocio;
                    tar.sel = x.sel;
                    tar.Socio = x.Socio;
                    tar.tarjeta = x.tarjeta;
                    listado.Add(tar);
                    
                }
                else
                {
                    listado.Remove(tar);
                    if (x.Importe.Length>0)
                    { 
                    tar.Importe = (double.Parse(tar.Importe) + double.Parse(x.Importe)).ToString();
                    listado.Add(tar);
                    }
                }
            }
            
            return listado;



        }
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class STarjetas
    {
        [System.Runtime.Serialization.DataMember]
        public String tarjeta { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string NoSocio { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Socio { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Importe { get; set; }
        [System.Runtime.Serialization.DataMember]
        public Boolean sel { get; set; }
       
    }

}
