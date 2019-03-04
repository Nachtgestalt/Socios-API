using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.SocioCatego
{
    public class Catego : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Catego()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_SocioCatego catego)
        {
            bool resultado = false;
            try
            {
                var vCat = from Cat in _db.T_SocioCatego where Cat.ID == catego.ID select Cat;
                if (vCat.Count() == 0)
                {
                    _db.T_SocioCatego.InsertOnSubmit(catego);
                }

                _db.SubmitChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar la categoria");
            }

            return resultado;
        }
        public uFacturaEDatos.T_SocioCatego Obten(uFacturaEDatos.T_SocioCatego Catego)
        {
            try
            {
                var vCatego = from cli in _db.T_SocioCatego where cli.ID == Catego.ID select cli;

                if (vCatego.Count() > 0)
                {
                    return vCatego.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El Catego " + Catego.ID.ToString() + " no existe y no es posible obtener el registro.";
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
        public uFacturaEDatos.T_SocioCatego ObtenS(uFacturaEDatos.T_SocioCatego Catego)
        {
            try
            {
                var vCatego = from cli in _db.T_SocioCatego where cli.SocioId == Catego.SocioId && cli.Categoria==Catego.Categoria select cli;

                if (vCatego.Count() > 0)
                {
                    return vCatego.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El Catego " + Catego.ID.ToString() + " no existe y no es posible obtener el registro.";
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
    }
}
