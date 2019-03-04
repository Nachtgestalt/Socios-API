using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Perfil
{
    public class Perfil : Operacion
    {


        uFacturaEDatos.BasedatosDataContext _db = null;

        public Perfil()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Perfiles usuario)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Perfiles where concept.Id == usuario.Id select concept;
                if (vConcepto.Count() == 0)
                {
                    _db.T_Perfiles.InsertOnSubmit(usuario);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el Usuario");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.T_Perfiles usuario)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Perfiles where concept.Id == usuario.Id select concept;

                if (vConcepto.Count() > 0)
                {
                    usuario = vConcepto.First();
                    _db.T_Perfiles.DeleteOnSubmit(usuario);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El id " + usuario.Id.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Perfiles Obten(uFacturaEDatos.T_Perfiles usuario)
        {
            try
            {
                var vConcepto = from concept in _db.T_Perfiles where concept.Id == usuario.Id select concept;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + usuario.Id.ToString() + " no existe y no es posible obtener el registro.";
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

        public List<uFacturaEDatos.T_Perfiles> ObtenLista()
        {
            try
            {
                var vConcepto = from concept in _db.T_Perfiles orderby concept.Perfil where concept.Activo ==true select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Perfiles>();
            }
        }

    }
}
