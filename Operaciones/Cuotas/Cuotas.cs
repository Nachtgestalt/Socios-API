using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Cuotas
{
    public class Cuotas : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Cuotas()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.T_Cuotas cuota)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from cuot in _db.T_Cuotas where cuot.ID == cuota.ID select cuot;
                if (vConcepto.Count() == 0)
                {
                    _db.T_Cuotas.InsertOnSubmit(cuota);
                }
                else{
                    vConcepto.First().Cantidad = cuota.Cantidad;
                    vConcepto.First().FecPago = cuota.FecPago;
                    vConcepto.First().Fecha = cuota.Fecha;
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

        public bool Eliminar(uFacturaEDatos.T_Cuotas cuota)
        {
            bool resultado = false;
            try
            {
                var vConcepto = from concept in _db.T_Cuotas where concept.ID == cuota.ID select concept;

                if (vConcepto.Count() > 0)
                {
                    cuota = vConcepto.First();
                    _db.T_Cuotas.DeleteOnSubmit(cuota);
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + cuota.ID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.T_Cuotas Obten(uFacturaEDatos.T_Cuotas cuota)
        {
            try
            {
                var vConcepto = from cout in _db.T_Cuotas where cout.ID == cuota.ID select cout;

                if (vConcepto.Count() > 0)
                {
                    return vConcepto.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El idConcepto " + cuota.ID.ToString() + " no existe y no es posible obtener el registro.";
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

        public List<uFacturaEDatos.T_Cuotas> ObtenLista(int socioID,int SucursalID)
        {
            try
            {
                var vConcepto = from concept in _db.T_Cuotas where concept.SocioID==socioID && concept.SucursalID==SucursalID orderby concept.Fecha select concept;
                return vConcepto.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                return new List<uFacturaEDatos.T_Cuotas>();
            }
        }

        public int  lastMonthDay(DateTime fecha)
        { int dia=1;
          int mes = fecha.Month;
          int año=fecha.Year;
          if (mes < 12)
              mes++;
          else
          {
              mes = 1;
              año++;
          }

        DateTime lastday = DateTime.Parse("01/" + mes + "/" + año);
        lastday = lastday.AddDays(-1);
        dia = lastday.Day;

          return dia;

        }
        private void elminacuotas(int socioID, int SucursalID)
        {
            var vConcepto = from concept in _db.T_Cuotas where concept.SocioID == socioID && concept.SucursalID == SucursalID orderby concept.Fecha select concept;
            if (vConcepto.Count() > 0)
            {
                foreach (T_Cuotas x in vConcepto)
                {
                    Eliminar(x);
                }
            }
        }
        public void creacuotas(int socioID,int Mes,int año,bool Nuevo,int SucursalID,Boolean anual)
        {
           
            int mes = Mes;

            int reno=0;
                   

            if (anual)
            {
                if (Nuevo)
                {
                    elminacuotas(socioID, SucursalID);
                    uFacturaEDatos.T_Cuotas cuot = new T_Cuotas();
                    cuot.SocioID = socioID;
                    cuot.Fecha = DateTime.Parse("01/" + Mes + "/" + año);
                    cuot.MesID = "INS";
                    cuot.SucursalID = SucursalID;
                    Guardar(cuot);
                }
                else
                {
                    var vreins = from concept in _db.T_Cuotas where concept.SocioID == socioID && (concept.MesID.Contains("INS") || concept.MesID.Contains("Re")) orderby concept.Fecha descending select concept;
                    string strRe = "";
                    string Tipo = "INS";
                    string gratis = "";
                     if (vreins.Count() > 0)
                    {
                        strRe = vreins.First().MesID.Substring(2);

                        bool isInt = int.TryParse(strRe, out reno);
                        if (!isInt)
                        { Tipo = "Re1";
                           reno = 1;
                        }
                        else
                        {
                            reno++;
                            Tipo = "Re" + reno.ToString();
                            if (reno > 2)
                            {
                                gratis = "Cortesia";

                            }

                        }
                        //eliminamos las otras cuotas y creamos las nuevas
                        elminacuotas(socioID, SucursalID);
                        uFacturaEDatos.T_Cuotas cuot = new T_Cuotas();
                        cuot.SocioID = socioID;
                        cuot.Fecha = DateTime.Parse("01/" + Mes + "/" + año);
                        cuot.MesID = Tipo;
                        cuot.SucursalID = SucursalID;
                        cuot.Cantidad = gratis;
                        if (cuot.Cantidad == "Cortesia")
                            cuot.FecPago = DateTime.Today;
                        Guardar(cuot);
                    }
                }
            }
            if (!anual)
            {
                
                int dia = 1;
                DateTime fecha = DateTime.Parse("01/" + mes + "/" + año);
                for (int i = 1; i <= lastMonthDay(fecha); i++)
                {
                    uFacturaEDatos.T_Cuotas cuot = new T_Cuotas();
                    cuot.SocioID = socioID;
                    cuot.SucursalID = SucursalID;
                    
                    cuot.Fecha = DateTime.Parse(dia+"/" + mes + "/" + año);
                    if (dia<10)
                        cuot.MesID ='0'+ dia.ToString();
                    else
                    cuot.MesID = dia.ToString();
                    
                    if (cuot.Fecha.Value.DayOfWeek!=DayOfWeek.Sunday )  
                    Guardar(cuot);
                    dia++;
                }
            }
            else
            {
                string gratis="";
                for (int i = 1; i <= 12; i++)
                {
                    uFacturaEDatos.T_Cuotas cuot = new T_Cuotas();
                    cuot.SocioID = socioID;
                    cuot.SucursalID = SucursalID;
                    cuot.Fecha = DateTime.Parse("02/" + mes + "/" + año);
                    cuot.MesID = DateTime.Parse("02/" + mes + "/" + año).ToString("MMM").ToUpper();
                
                    mes++;
                    if (mes > 12)
                    {
                        mes = 1;
                        año++;
                    }
                    Guardar(cuot);
                }
            }
        }
    }
}
