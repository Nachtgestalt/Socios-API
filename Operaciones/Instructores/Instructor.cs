using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.Instructor
{
    public class Instructor : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Instructor()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.C_Instructores catego)
        {
            bool resultado = false;
            try
            {
                var vCat = from Cat in _db.C_Instructores where Cat.InstructorId == catego.InstructorId select Cat;
                if (vCat.Count() == 0)
                {
                    _db.C_Instructores.InsertOnSubmit(catego);
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
        public uFacturaEDatos.C_Instructores Obten(uFacturaEDatos.C_Instructores Catego)
        {
            try
            {
                var vCatego = from cli in _db.C_Instructores where cli.InstructorId == Catego.InstructorId select cli;

                if (vCatego.Count() > 0)
                {
                    return vCatego.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El Catego " + Catego.InstructorId.ToString() + " no existe y no es posible obtener el registro.";
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
        public List<uFacturaEDatos.C_Instructores> ObtenLista()
        {
            try
            {
                var vConcepto = from concept in _db.C_Instructores  select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.C_Instructores>();
            }
        }
    }
}
