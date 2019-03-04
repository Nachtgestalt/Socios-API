using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Agrupacion
{
    public class Agrupacion : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Agrupacion()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Agrupacion agrupa)
        {
            bool resultado = false;
            try
            {
                var vCliente = from agru in _db.T_Agrupacion where agru.SocioId == agrupa.SocioId && agru.AgrupacionID==agrupa.AgrupacionID select agru;
                if (vCliente.Count() == 0)
                {
                    _db.T_Agrupacion.InsertOnSubmit(agrupa);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar cliente");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.T_Agrupacion agrupa)
        {
            bool resultado = false;
            try
            {
                var vCliente = from agr in _db.T_Agrupacion where agr.ID == agrupa.ID select agr;

                if (vCliente.Count() > 0)
                {
                    agrupa = vCliente.First();
                    _db.T_Agrupacion.DeleteOnSubmit(agrupa);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El id " + agrupa.AgrupacionID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Agrupacion Obten(uFacturaEDatos.T_Agrupacion agrupacion)
        {
            try
            {
                var vCliente = from cli in _db.T_Agrupacion where cli.ID == agrupacion.ID select cli;

                if (vCliente.Count() > 0)
                {
                    return vCliente.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El AgrupacionID" + agrupacion.AgrupacionID.ToString() + " no existe y no es posible obtener el registro.";
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
        public uFacturaEDatos.T_Agrupacion ObtenF(uFacturaEDatos.T_Agrupacion agrupacion)
        {
            try
            {
                var vClien = from cli in _db.T_Agrupacion
                               where cli.SocioId==agrupacion.SocioId
                                 select cli;
                foreach (T_Agrupacion x in vClien.ToList())
                {
                    var vCliente = from cli in _db.T_Agrupacion
                                 join trab in _db.T_Trabajo on cli.SocioId equals trab.SocioId
                                 where cli.AgrupacionID == x.AgrupacionID
                                 select cli;

                    if (vCliente.Count() > 0)
                    {
                        return vCliente.First();
                    }
                    
                }
                        _mensajeErrorUsuario = "El SocioId" + agrupacion.SocioId.ToString() + " no existe y no es posible obtener el registro.";
                        return null;
                
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return null;
            }
        }
        public uFacturaEDatos.T_Agrupacion ObtenS(uFacturaEDatos.T_Agrupacion agrupacion)
        {
            try
            {
                var vCliente = from cli in _db.T_Agrupacion where cli.SocioId == agrupacion.SocioId  select cli;

                if (vCliente.Count() > 0)
                {
                    return vCliente.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El SocioId" + agrupacion.SocioId.ToString() + " no existe y no es posible obtener el registro.";
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
        public List<AgrupacionN> ObtenDatos(decimal AgrupaID, int SucursalID)
        {
            try
            {

                var vReporte_Dia = from t in _db.T_Agrupacion
                                   join t0 in _db.T_Socio on t.SocioId equals t0.SocioId 
                                   where t.AgrupacionID == AgrupaID
                                 
                                   select new AgrupacionN
                                   {
                                       ID=t.ID,
                                       agrupacionID = t.AgrupacionID,
                                       SocioID = t.SocioId,
                                       Nombre = t0.Nombre
                                       
                                   };

                return vReporte_Dia.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<AgrupacionN>();
            }
        }

        
        public List<uFacturaEDatos.T_Agrupacion> ObtenLista(int SocioID)
        {
            try
            {
                var vCliente = from agr in _db.T_Agrupacion where agr.SocioId == SocioID select agr;
                return vCliente.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Agrupacion>();
            }
        }

        public int nuevo(int SucursalID)
        {
            try
            {
                var vCliente = from agr in _db.T_Agrupacion where agr.SucursalID==SucursalID
                               orderby agr.AgrupacionID  descending
                               select agr.AgrupacionID ;
                return int.Parse(vCliente.First().ToString());
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return 1;
            }
        }

        public bool verfica(T_Agrupacion agrupacion)
        {
            var vCliente = from agr in _db.T_Agrupacion
                           where agr.SocioId == agrupacion.SocioId
                            select agr;
            if (vCliente.Count() > 0)
                return true;
            else
                return false;

        }
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class AgrupacionN
    {
        [System.Runtime.Serialization.DataMember] public int ID { get; set; }
        [System.Runtime.Serialization.DataMember] public decimal agrupacionID { get; set; }
        [System.Runtime.Serialization.DataMember] public int SocioID { get; set; }
        [System.Runtime.Serialization.DataMember] public string Nombre { get; set; }
        
       
    }
}
