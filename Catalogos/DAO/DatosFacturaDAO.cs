using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Socios.Datos.Utilerias;

namespace Socios.Datos.Catalogos.DAO
{
    class DatosFacturaDAO
    {
         #region Atributos
        private AccesoBD conexion;
        private DatosFactura datosfactura;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public DatosFacturaDAO()
        {
            conexion = new AccesoBD();
            datosfactura = new DatosFactura();
        }
        #endregion

        #region Metodos
        public List<DatosFactura> mapearObjetos(SqlDataReader dr)
        {
            List<DatosFactura> Datosfactura = new List<DatosFactura>();
            while (dr.Read())
            {
                DatosFactura DatosFac = new DatosFactura();
                
                Datosfactura.Add(DatosFac);
            }
            return Datosfactura;
        }
        public List<DatosFactura> getAll()
        {
            List<DatosFactura> Datosfactura = new List<DatosFactura>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_DtosFact";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Datosfactura = mapearObjetos(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {

                Logger.Log(ex.Message);
            }
            return Datosfactura;
        }
        public DatosFactura mapearObjeto(SqlDataReader dr)
        {
            while (dr.Read())
            {
                DatosFactura dtofac = new DatosFactura();
                dtofac.Nombre = dr["Nombre"].ToString();
                dtofac.Puesto = dr["Puesto"].ToString();
                dtofac.Calle= dr["Calle"].ToString();
                dtofac.NoExterior = dr["NoExterior"].ToString();
                dtofac.NoInterior = dr["NoInterior"].ToString();
                dtofac.Localidad = dr["Localidad"].ToString();
                dtofac.Colonia = dr["Colonia"].ToString();
                dtofac.Referencia = dr["Referencia"].ToString();
                dtofac.Ciudad = dr["Ciudad"].ToString();
                dtofac.Estado = dr["Estado"].ToString();
                dtofac.Pais = dr["Pais"].ToString();
                dtofac.CP = dr["CP"].ToString();
                dtofac.Telefono = dr["Telefono"].ToString();
                dtofac.Fax = dr["Fax"].ToString();
                dtofac.EMail = dr["eMail"].ToString();
                dtofac.RFC = dr["RFC"].ToString();
                dtofac.MetodoPago = dr["MetodoPago"].ToString();
                dtofac.Cuenta = dr["Cuenta"].ToString();
                dtofac.SucursalID = int.Parse(dr["SucursalID"].ToString());
                dtofac.SocioID = int.Parse(dr["SocioID"].ToString());


                datosfactura = dtofac;

            }
            return datosfactura;
        }
        public DatosFactura getById(DatosFactura a)
        {
            datosfactura = new DatosFactura();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_DatosFactId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    datosfactura = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                
                Logger.Log(ex.Message);
            }
            return datosfactura;
        }
        public void create(DatosFactura a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "sp_Areadd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Execute();
                
            }
            catch (SqlException ex)
            {
                throw;
                Logger.Log(ex.Message);
            }
        }

        public void update(DatosFactura a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "sp_DtoFactAct";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.SocioID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Puesto", a.Puesto));
                conexion.Cmd.Parameters.Add(new SqlParameter("Calle", a.Calle));
                conexion.Cmd.Parameters.Add(new SqlParameter("NoExterior", a.NoExterior));
                conexion.Cmd.Parameters.Add(new SqlParameter("NoInterior", a.NoInterior));
                conexion.Cmd.Parameters.Add(new SqlParameter("Localidad", a.Localidad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Colonia", a.Colonia));
                conexion.Cmd.Parameters.Add(new SqlParameter("Referencia", a.Referencia));
                conexion.Cmd.Parameters.Add(new SqlParameter("Ciudad", a.Ciudad));
                conexion.Cmd.Parameters.Add(new SqlParameter("Estado", a.Estado));
                conexion.Cmd.Parameters.Add(new SqlParameter("Pais", a.Pais));

                conexion.Cmd.Parameters.Add(new SqlParameter("CP", a.CP));
                conexion.Cmd.Parameters.Add(new SqlParameter("Telefono", a.Telefono));
                conexion.Cmd.Parameters.Add(new SqlParameter("Fax", a.Fax));

                conexion.Cmd.Parameters.Add(new SqlParameter("eMail", a.EMail));
                conexion.Cmd.Parameters.Add(new SqlParameter("RFC", a.RFC));
                conexion.Cmd.Parameters.Add(new SqlParameter("MetodoPago", a.MetodoPago));
                conexion.Cmd.Parameters.Add(new SqlParameter("Cuenta", a.Cuenta));
                conexion.Cmd.Parameters.Add(new SqlParameter("SucursalID", a.SucursalID));
                
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Execute();
                
            }
            catch (SqlException ex)
            {
               
                Logger.Log(ex.Message);
            }
        }
        ///No implementado por que no tiene logica ya que hace relacion a Actividades
        public void delete(Actividades a)
        {
            try
            {
                
                conexion.Cmd.CommandText = "Delete from C_Areas where AreaID=" + a.DeporteID;
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.ExecuteNonQuery();
                conexion.Execute();
            }
            catch (SqlException ex)
            {
                Logger.Log(ex.Message);
            }
        }
        #endregion

    }
}
