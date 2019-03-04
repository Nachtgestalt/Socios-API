using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Familiar
{
    public class Familiar : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Familiar()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Familiar familia)
        {
            bool resultado = false;
            try
            {
                var vFamiliar = from fami in _db.T_Familiar where fami.ID == familia.ID select fami;
                if (vFamiliar.Count() == 0)
                {
                    _db.T_Familiar.InsertOnSubmit(familia);
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar Los dados del socio");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.T_Familiar fami)
        {
            bool resultado = false;
            try
            {
                var vFamilia = from famili in _db.T_Familiar where famili.ID == fami.ID select famili;

                if (vFamilia.Count() > 0)
                {
                    fami = vFamilia.First();
                    _db.T_Familiar.DeleteOnSubmit(fami);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El id " + fami.ID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Familiar Obten(uFacturaEDatos.T_Familiar famili)
        {
            try
            {
                var vFamilia = from fami in _db.T_Familiar where fami.ID == famili.ID select fami;

                if (vFamilia.Count() > 0)
                {
                    return vFamilia.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El " + famili.ID.ToString() + " no existe y no es posible obtener el registro.";
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
      
        public uFacturaEDatos.T_Familiar ObtenS(uFacturaEDatos.T_Familiar familia)
        {
            try
            {
                var vCliente = from fami in _db.T_Familiar where fami.SocioId == familia.SocioId  &  fami.SucursalID==familia.SucursalID select fami;

                if (vCliente.Count() > 0)
                {
                    return vCliente.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El SocioId" + familia.SocioId.ToString() + " no existe y no es posible obtener el registro.";
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
