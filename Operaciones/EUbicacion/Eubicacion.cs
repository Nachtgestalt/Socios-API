using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.EUbicacion
{
    public class Eubicacion : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Eubicacion()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.C_Examen_Ubicacion eubica)
        {
            bool resultado = false;
            try
            {
                var vEUbica = from ubica in _db.C_Examen_Ubicacion where ubica.ID == eubica.ID select ubica;
                if (vEUbica.Count() == 0)
                {
                    _db.C_Examen_Ubicacion.InsertOnSubmit(eubica);
                    // actualizamos el nivel del socio 
                    var vsocioCatego = from catego in _db.T_SocioCatego where catego.SocioId == eubica.Clave select catego;
                    if (vsocioCatego.Count()==0)
                    {
                        //insertamos el nivel
                        T_SocioCatego categ = new T_SocioCatego();
                        categ.SocioId = eubica.Clave;
                        categ.Categoria = eubica.Categoria_max;
                        categ.Fecha = DateTime.Today;
                        categ.Entrego = false;
                        categ.SucursalID = 0;
                        _db.T_SocioCatego.InsertOnSubmit(categ);
                    }
                    else
                    vsocioCatego.First().Categoria = eubica.Categoria_max;
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar Los dados del examen");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.C_Examen_Ubicacion eubica)
        {
            bool resultado = false;
            try
            {
                var vEubica = from ubica in _db.C_Examen_Ubicacion where ubica.ID == eubica.ID select ubica;

                if (vEubica.Count() > 0)
                {
                    eubica = vEubica.First();
                    _db.C_Examen_Ubicacion.DeleteOnSubmit(eubica);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El id " + eubica.ID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.C_Examen_Ubicacion Obten(uFacturaEDatos.C_Examen_Ubicacion eubica)
        {
            try
            {
                var vEubica = from ubica in _db.C_Examen_Ubicacion where ubica.ID == eubica.ID select ubica;

                if (vEubica.Count() > 0)
                {
                    return vEubica.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El " + eubica.ID.ToString() + " no existe y no es posible obtener el registro.";
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
      
        public uFacturaEDatos.C_Examen_Ubicacion ObtenS(uFacturaEDatos.C_Examen_Ubicacion ubica)
        {
            try
            {
                var vEubica = from eubica in _db.C_Examen_Ubicacion where eubica.Clave == ubica.Clave  &  eubica.SucursalID==ubica.SucursalID select eubica;

                if (vEubica.Count() > 0)
                {
                    return vEubica.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El SocioId" + ubica.Clave.ToString() + " no existe y no es posible obtener el registro.";
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
