using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Trabajo
{
    public class Trabajo : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Trabajo()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Trabajo concepto)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Trabajo where concept.SocioId == concepto.SocioId select concept;
                if (vConcepto.Count() == 0)
                {
                    _db.T_Trabajo.InsertOnSubmit(concepto);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar los datos de facturación");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.T_Trabajo concepto)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Trabajo where concept.SocioId == concepto.SocioId select concept;

                if (vConcepto.Count() > 0)
                {
                    concepto = vConcepto.First();
                    _db.T_Trabajo.DeleteOnSubmit(concepto);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + concepto.SocioId.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Trabajo Obten(uFacturaEDatos.T_Trabajo concepto)
        {
            try
            {
                var vConcepto = from concept in _db.T_Trabajo where concept.SocioId== concepto.SocioId select concept;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + concepto.SocioId.ToString() + " no existe y no es posible obtener el registro.";
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

        public List<uFacturaEDatos.T_Trabajo> ObtenLista()
        {
            try
            {
                var vConcepto = from concept in _db.T_Trabajo where concept.Nombre!="" select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                List<uFacturaEDatos.T_Trabajo> listT = new List<uFacturaEDatos.T_Trabajo>();
                T_Trabajo t = new T_Trabajo();
                t.Referencia = ex.Message;
                listT.Add(t);
                return listT;
            }
        }
    }
}
