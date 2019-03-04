using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.Empresa
{
    public class Empresa : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Empresa()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.Empresa empresa)
        {
           // Operaciones.Usuarios.Usuario usuarioDefault = null;

            bool resultado = false;
            using (TransactionScope vTrasaction = new TransactionScope())
            {
                try
                {
                    var vEmpresa = from em in _db.Empresa where em.idEmpresa == empresa.idEmpresa select em;
                    if (vEmpresa.Count() == 0)
                    {                       
                        //Crear usuario Default
             //           usuarioDefault = new Usuarios.Usuario();
               //         empresa.Usuarios.Add(usuarioDefault.GenerarUsuarioDefault(empresa.rfcEmpresa.ToLower()));

                        _db.Empresa.InsertOnSubmit(empresa);
                    }
                    _db.SubmitChanges();

                    resultado = true;

                    vTrasaction.Complete();
                }
                catch (Exception ex)
                {
                    resultado = false;
                    _mensajeErrorSistema = ex.Message;
                    GrabarLogError(ex);
                    throw new Exception("No fué posible guardar la empresa");
                }
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.Empresa empresa)
        {
            bool resultado = false;
            try
            {
                var vEmpresa = from em in _db.Empresa where em.idEmpresa == empresa.idEmpresa select em;

                if (vEmpresa.Count() > 0)
                {
                    empresa = vEmpresa.First();
                    _db.Empresa.DeleteOnSubmit(empresa);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idEmpresa " + empresa.idEmpresa.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.Empresa Obten(uFacturaEDatos.Empresa empresa)
        {
            try
            {
                var vEmpresa = from em in _db.Empresa where em.idEmpresa == empresa.idEmpresa select em;

                if (vEmpresa.Count() > 0)
                {
                    return vEmpresa.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idEmpresa " + empresa.idEmpresa.ToString() + " no existe y no es posible obtener el registro.";
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
