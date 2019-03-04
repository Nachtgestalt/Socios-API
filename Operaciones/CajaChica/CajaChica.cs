using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.CajaChica
{
    public class CajaChica : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public CajaChica()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_CChica cCajaChica)
        {
            bool resultado = false;
            try
            {
                _db.T_CChica.InsertOnSubmit(cCajaChica);
                _db.SubmitChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar abono");
            }

            return resultado;
        }
        public bool Eliminar(uFacturaEDatos.T_CChica cCajaChica)
        {
            bool resultado = false;
            try
            {
                var vCliente = from caj in _db.T_CChica where caj.CajaID== cCajaChica.CajaID select caj;

                if (vCliente.Count() > 0)
                {
                    cCajaChica = vCliente.First();
                    _db.T_CChica.DeleteOnSubmit(cCajaChica);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El AgrupacionID " + cCajaChica.CajaID.ToString() + " no existe y no es posible eliminar el registro.";
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


        public bool GuardaCaja(List<T_CChica> caja)
        {
            bool resultado = false;
            try
            {
                if (caja.Count > 0)
                {
                    var vCliente = from caj in _db.T_CChica where caj.Fecha == caja[0].Fecha select caj;
                    if (DateTime.Today == caja[0].Fecha)
                    {
                        if (vCliente.Count() > 0)
                        {
                            _db.T_CChica.DeleteAllOnSubmit(vCliente.ToList());
                        }
                        _db.T_CChica.InsertAllOnSubmit(caja);
                        resultado = true;
                    }
                    else
                    {
                        //verificamos que no exista nada en ese dia para poder cambiarlo
                        if (vCliente.Count() > 0)
                        {
                            resultado = false;
                        }
                        else
                        {
                            _db.T_CChica.InsertAllOnSubmit(caja);
                            resultado = true;
                        }

                    }
                }
                else
                {
                    var vCliente = from caj in _db.T_CChica where caj.Fecha == DateTime.Today select caj;
                                      
                       if (vCliente.Count() > 0)
                       {
                           _db.T_CChica.DeleteAllOnSubmit(vCliente.ToList());
                       }
                       resultado = true;
                }
                _db.SubmitChanges();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                resultado = false;

            }
            return resultado;
        }
    }
}
