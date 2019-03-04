using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Conceptos
{
    public class Concepto : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Concepto()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Conceptos concepto)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Conceptos where concept.ConceptoId == concepto.ConceptoId select concept;
                if (vConcepto.Count() == 0)
                {
                    _db.T_Conceptos.InsertOnSubmit(concepto);
                }
                else
                {
                    uFacturaEDatos.T_Conceptos conceptod = vConcepto.First();
                    conceptod.ClaveSat = concepto.ClaveSat;
                    conceptod.ConceptoSts = concepto.ConceptoSts;
                    conceptod.Fecha_Final = concepto.Fecha_Final;
                    conceptod.Fecha_Inicio = concepto.Fecha_Inicio;
                    conceptod.Fecha_Registro = concepto.Fecha_Registro;
                    conceptod.Importe = concepto.Importe;
                    conceptod.IVA = concepto.IVA;
                    conceptod.Nombre = concepto.Nombre;
                    conceptod.Orden = concepto.Orden;
                    conceptod.PIva = concepto.PIva;
                    conceptod.Tipo_Cuota = concepto.Tipo_Cuota;
                }


                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar el concepto");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.T_Conceptos concepto)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Conceptos where concept.ConceptoId == concepto.ConceptoId select concept;

                if (vConcepto.Count() > 0)
                {
                    concepto = vConcepto.First();
                    _db.T_Conceptos.DeleteOnSubmit(concepto);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + concepto.ConceptoId.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Conceptos Obten(uFacturaEDatos.T_Conceptos concepto)
        {
            try
            {
                var vConcepto = from concept in _db.T_Conceptos where concept.ConceptoId == concepto.ConceptoId select concept;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + concepto.ConceptoId.ToString() + " no existe y no es posible obtener el registro.";
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

        public uFacturaEDatos.T_Conceptos ObtenMax()
        {
            try
            {
                var vConcepto = from concept in _db.T_Conceptos orderby concept.ConceptoId                    descending select concept;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " +  " no existe y no es posible obtener el registro.";
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
        public List<uFacturaEDatos.T_Conceptos> ObtenLista()
        {
            try
            {
                var vConcepto = from concept in _db.T_Conceptos orderby concept.Nombre where concept.ConceptoSts=='S' orderby concept.ConceptoId select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Conceptos>();
            }
        }
    }
}
