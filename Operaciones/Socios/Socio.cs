using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.Socios
{
    public class Socio : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Socio()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Socio catego)
        {
            bool resultado = false;
            try
            {
                var vCat = from Cat in _db.T_Socio where Cat.SocioId == catego.SocioId select Cat;
                if (vCat.Count() == 0)
                {
                    _db.T_Socio.InsertOnSubmit(catego);
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
        public uFacturaEDatos.T_Socio Obten(uFacturaEDatos.T_Socio Catego)
        {
            try
            {
                var vCatego = from cli in _db.T_Socio where cli.SocioId == Catego.SocioId select cli;

                if (vCatego.Count() > 0)
                {
                    return vCatego.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El Catego " + Catego.SocioId.ToString() + " no existe y no es posible obtener el registro.";
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
        public List<uFacturaEDatos.T_Socio> ObtenLista()
        {
            try
            {
                var vConcepto = from concept in _db.T_Socio where concept.Socio_Anterior=='N' select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Socio>();
            }
        }


    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class LMV
    {
        [System.Runtime.Serialization.DataMember]
        public dias dias { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int mes { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int anio { get; set; }

        [System.Runtime.Serialization.DataMember]
        public horario horario { get; set; }

        [System.Runtime.Serialization.DataMember]
        public categoria categoria { get; set; }

        [System.Runtime.Serialization.DataMember]
        public instructor instructor { get; set; }

        [System.Runtime.Serialization.DataMember]
        public grupo grupo { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Char tipo { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int IDSucursal { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class dias
    {
        [System.Runtime.Serialization.DataMember]
        public char dia1 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia2 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia3 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia4 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia5 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia6 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia7 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia8 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public char dia9 { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class horario
    {
        [System.Runtime.Serialization.DataMember]
        public string hora1 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string hora2 { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class categoria
    {
        [System.Runtime.Serialization.DataMember]
        public string categoria1 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string categoria2 { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class instructor
    {
        [System.Runtime.Serialization.DataMember]
        public string instructor1 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string instructor2 { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class grupo
    {
        [System.Runtime.Serialization.DataMember]
        public string grupo1 { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string grupo2 { get; set; }
    }
}
