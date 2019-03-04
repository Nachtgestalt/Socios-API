using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Libreta
{
    public class Libreta : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Libreta()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Apartados apartados)
        {
            bool resultado = false;
            try
            {
                var vFamiliar = from fami in _db.T_Apartados where fami.ApartaID == apartados.ApartaID select fami;
                if (vFamiliar.Count() == 0)
                {
                    _db.T_Apartados.InsertOnSubmit(apartados);
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

        public bool Eliminar(DateTime dateTime)
        {
            bool resultado = false;
            try
            {
                var vFamilia = from famili in _db.T_Apartados where famili.Fecha < dateTime select famili;

                if (vFamilia.Count() > 0)
                {

                    _db.T_Apartados.DeleteAllOnSubmit(vFamilia.ToList());
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    
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

        public List<uFacturaEDatos.Cs_Horario> ObtenHorarios()
        {
            try
            {
                var vFamilia = from fami in _db.Cs_Horario orderby fami.Hora select fami;

                if (vFamilia.Count() > 0)
                {
                    return vFamilia.ToList();
                }
                else
                {
                    
                    return new List<Cs_Horario>();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return null;
            }
        }
        public List<uFacturaEDatos.Cs_ListaGpoDet> ObtenGrupos(String hora, char Dia)
        {
            try
            {
                string dias = Dia.ToString();
                int idia = int.Parse(dias);
                var vFamilia = from fami in _db.Cs_ListaGpoDet where (fami.Hora==hora) && ( fami.Dia==Dia) ||
                               (fami.Hora == hora) && (fami.Dia == (idia + 3).ToString()[0])
                               select fami;

                if (vFamilia.Count() > 0)
                {
                    return vFamilia.ToList();
                }
                else
                {

                    return new List<Cs_ListaGpoDet>();
                }
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return null;
            }
        }
      
        public uFacturaEDatos.T_Apartados ObtenS(uFacturaEDatos.T_Apartados familia)
        {
            try
            {
                var vCliente = from fami in _db.T_Apartados where fami.GrupoID == familia.GrupoID  &  fami.NoLista==familia.NoLista select fami;

                if (vCliente.Count() > 0)
                {
                    return vCliente.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El  no existe y no es posible obtener el registro.";
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
