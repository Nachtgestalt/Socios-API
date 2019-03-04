using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.Calificaciones
{
    public class Calificacion : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Calificacion()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.C_Calificaciones califica,short CategoriaID)
        {
            bool resultado = false;
            try
            {
                var vCliente = from agru in _db.C_Calificaciones where agru.ID == califica.ID select agru;
                if (vCliente.Count() == 0)
                {
                    _db.C_Calificaciones.InsertOnSubmit(califica);
                    //verificamos la calificacion para ver si lo promovemos de nivel
                    if (califica.Calificacion2 > decimal.Parse("7.5"))
                    {
                        T_SocioCatego _sociocatego= new T_SocioCatego();
                        _sociocatego.SucursalID=califica.SucursalID;
                        _sociocatego.SocioId=int.Parse( califica.ClaveSocio.ToString());
                        _sociocatego.Fecha=DateTime.Parse( califica.Fecha_Ev.ToString());
                        _sociocatego.Entrego = false;
                        _sociocatego.Categoria = califica.Categoria;

                        var vTsocioCatego = from socioCatego in _db.T_SocioCatego
                                            where socioCatego.Categoria == califica.Categoria &&
                                            socioCatego.SocioId == califica.ClaveSocio 
                                            select socioCatego;
                        if (vTsocioCatego.Count() == 0)
                        {
                            _db.T_SocioCatego.InsertOnSubmit(_sociocatego);
                        }
                        else
                        {
                            vTsocioCatego.First().Categoria = califica.Categoria;
                            vTsocioCatego.First().SocioId = int.Parse(califica.ClaveSocio.ToString());
                            vTsocioCatego.First().SucursalID = califica.SucursalID;
                            vTsocioCatego.First().Fecha = DateTime.Parse(califica.Fecha_Ev.ToString());
                            vTsocioCatego.First().Entrego = false; 

                            vTsocioCatego.First().Categoria = califica.Categoria;
                        }

                        //actualizamos su categoria en la otra tabla.
                        var vAresocio = from aresocio in _db.T_AreasSocio where aresocio.SocioId == califica.ClaveSocio && aresocio.SucursalID == califica.SucursalID select aresocio;
                        if (vAresocio.Count() > 0)
                        {
                            vAresocio.First().Categoriaid = CategoriaID;
                        }
                    }
                }

                _db.SubmitChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar la calificación");
            }

            return resultado;
        }

        public bool Eliminar(uFacturaEDatos.C_Calificaciones califica)
        {
            bool resultado = false;
            try
            {
                var vCliente = from agr in _db.C_Calificaciones where agr.ID == califica.ID select agr;

                if (vCliente.Count() > 0)
                {
                    califica = vCliente.First();
                    _db.C_Calificaciones.DeleteOnSubmit(califica);

                    var vsociocat = from a in _db.T_SocioCatego
                                    where a.SocioId == califica.ClaveSocio && a.Categoria == califica.Categoria 
                                    select a;
                    _db.T_SocioCatego.DeleteAllOnSubmit(vsociocat.ToList());
                    _db.SubmitChanges();

                    resultado = true;
                }
                else
                {
                    _mensajeErrorUsuario = "El ID " + califica.ID.ToString() + " no existe y no es posible eliminar el registro.";
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

        public uFacturaEDatos.C_Calificaciones Obten(uFacturaEDatos.C_Calificaciones califica)
        {
            try
            {
                var vCliente = from cli in _db.C_Calificaciones where cli.ID == califica.ID select cli;

                if (vCliente.Count() > 0)
                {
                    return vCliente.First();
                }
                else
                {
                    _mensajeErrorUsuario = "El ID" + califica.ID.ToString() + " no existe y no es posible obtener el registro.";
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



        public List<CalificacionesExa> ObtenLista(int SocioID, int sucursalID)
        {
            try
            {
                // verificamos la tabla de t_socioCatego
                Operaciones.SocioCatego.Catego oper = new SocioCatego.Catego();
                var verifica = from t in _db.C_Calificaciones
                               where
                                   t.ClaveSocio == SocioID
                               select t;
                foreach (C_Calificaciones cal in verifica.ToList())
                {
                    T_SocioCatego scat = new T_SocioCatego();
                    scat.Categoria = cal.Categoria;
                    scat.SucursalID=cal.SucursalID;
                    scat.SocioId = int.Parse(cal.ClaveSocio.ToString());
                    scat = oper.ObtenS(scat);
                    if (scat == null)
                    {
                        scat = new T_SocioCatego();
                        scat.Categoria = cal.Categoria;
                        scat.SocioId = int.Parse(cal.ClaveSocio.ToString());
                        scat.Entrego = false;
                        scat.SucursalID = cal.SucursalID;
                        scat.Fecha = DateTime.Today;
                        oper.Guardar(scat);
                    }
                }

                 var vReport_Dia = from t in _db.C_Calificaciones
                                  join  t0 in _db.T_SocioCatego on t.ClaveSocio equals t0.SocioId 
                                  join t1 in _db.C_Categorias on   t.Categoria  equals t1.Nombre

                                  where
                                   t.ClaveSocio == SocioID &&
                                   (t.Categoria == t0.Categoria && t0.Categoria != "PRINCIPIANTES")
                                   orderby t1.Nivel
                                   
                                  select new CalificacionesExa
                                  {
                                      Categoria = t0.Categoria,
                                      Examen = decimal.Parse(t.Calificacion2.ToString()),
                                      Fecha = t.Fecha_Ex == null ? t.Fecha_Ev.ToString() : t.Fecha_Ex.ToString(),
                                      Aplico = t.Aplico,
                                      Entrego = bool.Parse(t0.Entrego.ToString()),
                                      CategoID = t0.ID,
                                      ID = t.ID
                                  };
                return vReport_Dia.ToList();
            }
            catch (Exception ex)
            {
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No se obtubieron los datos " + ex.Message); 
                
            }
        }



        
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class CalificacionesExa
    {
        [System.Runtime.Serialization.DataMember]
        public int CategoID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public int ID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Categoria { get; set; }
        [System.Runtime.Serialization.DataMember]
        public decimal Examen { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Fecha { get; set; }
        [System.Runtime.Serialization.DataMember]
        public String Aplico { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Entrego { get; set; }

    }
}
