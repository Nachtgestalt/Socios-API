using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Privilegios
{
    public class Privilegio : Operacion
    {


        uFacturaEDatos.BasedatosDataContext _db = null;

        public Privilegio()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(List<uFacturaEDatos.T_Grants> Privi)
        {
            bool resultado = false;
            try
            {   
                if (Eliminar(Privi[0].Grant_UserNIP))
                    _db.T_Grants.InsertAllOnSubmit(Privi);
                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar los privilegios");
            }

            return resultado;
        }

        public bool Eliminar(int UserNip)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Grants where concept.Grant_UserNIP == UserNip select concept;

                if (vConcepto.Count() > 0)
                {

                    _db.T_Grants.DeleteAllOnSubmit(vConcepto);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
            
                    resultado = true;
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


        public uFacturaEDatos.T_Grants Obten(uFacturaEDatos.T_Grants grant)
        {
            try
            {
                var vConcepto = from concept in _db.T_Grants where concept.Grant_UserNIP == grant.Grant_UserNIP && concept.GrantId==grant.GrantId select concept;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + grant.GrantId.ToString() + " no existe y no es posible obtener el registro.";
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

        public List<uFacturaEDatos.T_Grants> ObtenLista(int  userNip)
        {
            try
            {
                var vConcepto = from concept in _db.T_Grants where concept.Grant_UserNIP == userNip select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Grants>();
            }
        }




        public bool ver(string Modulo, int User_nip)
        {
            bool ena = false;
            var vConcepto = from concept in _db.T_Grants where concept.Grant_UserNIP == User_nip && concept.GrantId.Substring(0,2)==Modulo select concept;
            if (vConcepto.Count() > 0)
                ena = true;
            return ena;
        }
        public bool verop(string Modulo, int User_nip)
        {
            bool ena = false;
            var vConcepto = from concept in _db.T_Grants where concept.Grant_UserNIP == User_nip && concept.GrantId == Modulo select concept;
            if (vConcepto.Count() > 0)
                ena = true;
            return ena;
        }
    }
}
