using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.Sucursales
{
    public class Sucursal : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Sucursal()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.Sucursales sucursal)
        {
            uFacturaEDatos.Operaciones.Documentos.Documento docDefault = null;
            bool resultado = false;
            using (TransactionScope vTrasaction = new TransactionScope())
            {
                try
                {
                    var vSucursal = from suc in _db.Sucursales where suc.idSucursal == sucursal.idSucursal select suc;
                    if (vSucursal.Count() == 0)
                    {
                        //Crear documentos Default
                        docDefault = new Documentos.Documento();
                        List<uFacturaEDatos.Documento> lstDoc = docDefault.GenerarDocsDefault();
                        _db.Documentos.InsertAllOnSubmit(lstDoc);

                        _db.Sucursales.InsertOnSubmit(sucursal);
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
                    throw new Exception("No fué posible guardar la sucursal");
                }
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.Sucursales sucursal)
        {
            bool resultado = false;
            try
            {
                var vSucursal = from suc in _db.Sucursales where suc.idSucursal == sucursal.idSucursal select suc;

                if (vSucursal.Count() > 0)
                {
                    sucursal = vSucursal.First();
                    _db.Sucursales.DeleteOnSubmit(sucursal);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idSucursal " + sucursal.idSucursal.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.Sucursales Obten(uFacturaEDatos.Sucursales sucursal)
        {
            try
            {
                //Para cargar el objeto y al mismo tiempo traer todos los elementos internos que estan relacionados
                //_db.DeferredLoadingEnabled = false;

                var vSucursal = from suc in _db.Sucursales where suc.idSucursal == sucursal.idSucursal select suc;

                if (vSucursal.Count() > 0)
                {
                    return vSucursal.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idSucursal " + sucursal.idSucursal.ToString() + " no existe y no es posible obtener el registro.";
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

        public uFacturaEDatos.Sucursales ObtenMatriz(uFacturaEDatos.Empresa empresa)
        {
            try
            {
                //Para cargar el objeto y al mismo tiempo traer todos los elementos internos que estan relacionados
                //_db.DeferredLoadingEnabled = false;

                var vSucursal = from suc in _db.Sucursales
                                where suc.EsSucursal == false && suc.idEmpresa == empresa.idEmpresa
                                select suc;

                if (vSucursal.Count() > 0)
                {
                    return vSucursal.First();
                }
                else
                {
                    _mensajeErrorUsuario = "No se pudo determinar asociación entre el usuario y la matriz";
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

        public List<uFacturaEDatos.Sucursales> ObtenLista(uFacturaEDatos.Empresa empresa)
        {
            try
            {
                //Para cargar el objeto y al mismo tiempo traer todos los elementos internos que estan relacionados
                //_db.DeferredLoadingEnabled = false;

                var vSucursal = from suc in _db.Sucursales where suc.idSucursal == empresa.idEmpresa select suc;
                return vSucursal.ToList();
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
