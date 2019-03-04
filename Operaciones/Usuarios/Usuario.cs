using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Usuarios
{
    public class Usuario : Operacion
    {


        uFacturaEDatos.BasedatosDataContext _db = null;

        public Usuario()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Users usuario)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Users where concept.User_NIP == usuario.User_NIP select concept;
                if (vConcepto.Count() == 0)
                {
                    _db.T_Users.InsertOnSubmit(usuario);
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

        public bool Eliminar(uFacturaEDatos.T_Users usuario)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Users where concept.User_ID == usuario.User_ID select concept;

                if (vConcepto.Count() > 0)
                {
                    usuario = vConcepto.First();
                    _db.T_Users.DeleteOnSubmit(usuario);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + usuario.User_ID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Users Obten(uFacturaEDatos.T_Users usuario)
        {
            try
            {
                var vConcepto = from concept in _db.T_Users where concept.User_NIP == usuario.User_NIP select concept;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + usuario.User_ID.ToString() + " no existe y no es posible obtener el registro.";
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

        public uFacturaEDatos.T_Users ObtenMax()
        {
            try
            {
                var vConcepto = from concept in _db.T_Users orderby concept.User_NIP descending select concept;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto  no existe y no es posible obtener el registro.";
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
        public List<uFacturaEDatos.T_Users> ObtenLista()
        {
            try
            {
                var vConcepto = from concept in _db.T_Users orderby concept.User_Name where concept.User_Sts=='S' select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Users>();
            }
        }

        public void create(T_Users usuario)
        {
            throw new NotImplementedException();
        }
    }
}
