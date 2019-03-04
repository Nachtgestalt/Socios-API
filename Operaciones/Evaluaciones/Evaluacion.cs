using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace uFacturaEDatos.Operaciones.Evaluaciones
{
    public class Evaluaciones : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Evaluaciones()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Evaluaciones evalua)
        {
            bool resultado = false;
            try
            {
                var vEvalua = from eval in _db.T_Evaluaciones where eval.EvaluacionID == evalua.EvaluacionID select eval;
                if (vEvalua.Count() == 0)
                {
                    _db.T_Evaluaciones.InsertOnSubmit(evalua);
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

        public bool Eliminar(uFacturaEDatos.T_Evaluaciones evalua)
        {
            bool resultado = false;
            try
            {
                var vEubica = from ubica in _db.T_Evaluaciones where ubica.EvaluacionID == evalua.EvaluacionID select ubica;

                if (vEubica.Count() > 0)
                {
                    evalua = vEubica.First();
                    _db.T_Evaluaciones.DeleteOnSubmit(evalua);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El id " + evalua.EvaluacionID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Evaluaciones Obten(uFacturaEDatos.T_Evaluaciones evalua)
        {
            try
            {
                var vEubica = from ubica in _db.T_Evaluaciones where ubica.EvaluacionID == evalua.EvaluacionID select ubica;

                if (vEubica.Count() > 0)
                {
                    return vEubica.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El " + evalua.EvaluacionID.ToString() + " no existe y no es posible obtener el registro.";
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
      
        public List<uFacturaEDatos.T_Evaluaciones> ObtenS(uFacturaEDatos.T_Evaluaciones evalua)
        {
            try
            {
                var vEubica = from eubica in _db.T_Evaluaciones where eubica.CategoriaID == evalua.CategoriaID select eubica;

                if (vEubica.Count() > 0)
                {
                    return vEubica.ToList();
                }
                else
                {
                    _mensajeErrorUsuario = "El SocioId" + evalua.CategoriaID.ToString() + " no existe y no es posible obtener el registro.";
                    return new List<T_Evaluaciones>();
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
