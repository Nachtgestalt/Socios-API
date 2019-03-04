using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Socios.Datos.Utilerias;


namespace Socios.Datos.Catalogos.DAO
{
    class CategoriasDAO
    {
        #region Atributos
        private AccesoBD conexion;
        private Categorias categoria;
        #endregion

        #region PropiedadesAcceso
        #endregion

        #region Constructores
        public CategoriasDAO()
        {
            conexion = new AccesoBD();
            categoria = new Categorias();
        }
        #endregion

        #region Metodos
        public List<Categorias> mapearObjetos(SqlDataReader dr)
        {
            List<Categorias> Categorias = new List<Categorias>();
            while (dr.Read())
            {
                byte[] imagen = null;
               
                Categorias.Add(new Categorias(int.Parse(dr["CategoriaID"].ToString()), double.Parse(dr["Nivel"].ToString()), dr["Nombre"].ToString(), !DBNull.Value.Equals(dr["Orden"])?int.Parse(dr["Orden"].ToString()) : 0,imagen)
                    );
            }
            return Categorias;
        }
        public List<Categorias> getAll()
        {
            List<Categorias> Categorias = new List<Categorias>();
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_Categorias";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    Categorias = mapearObjetos(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                Logger.Log(ex.Message);
            }
            return Categorias;
        
        }
        public int Nuevo()
        {
            int categoID = 0;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "select max(Categoriaid) + 1 as folio from C_categorias";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.Text;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    categoID = int.Parse(dr["folio"].ToString());
                }
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {

                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return categoID;
            
        }
        public Categorias mapearObjeto(SqlDataReader dr)
        {
            while (dr.Read())
            {
               
                byte[] imagen=null;
                string strOrden = dr["Orden"].ToString();
                if (strOrden == "") strOrden = "0";
                if (!DBNull.Value.Equals(dr["IMAGEN"]))
                    imagen = (byte[])dr["IMAGEN"];
                categoria = new Categorias(
                       int.Parse(dr["CategoriaID"].ToString()),
                        double.Parse(dr["Nivel"].ToString()),
                        dr["Nombre"].ToString(),
                        int.Parse(strOrden), imagen);

            }
            return categoria;
        }
        public Categorias getById(Categorias a)
        {
            categoria = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_CategoriasId ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.CategoriaID));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    categoria = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return categoria;
        }
        public Categorias getByOrden(Categorias a)
        {
            categoria = null;
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "Select * from C_categorias where orden=" + a.Orden;
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.CommandType = CommandType.Text;
                SqlDataReader dr = conexion.Cmd.ExecuteReader();
                if (dr.HasRows)
                    categoria = mapearObjeto(dr);
                //conexion.Cerrar();
                dr.Close();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {

                conexion.Cmd.Connection.Close();
                Logger.Log(ex.Message);
            }
            return categoria;
        }
        public void create(Categorias a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_CategoriasAdd ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.CategoriaID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nivel", a.Nivel));
                conexion.Cmd.Parameters.Add(new SqlParameter("orden", a.Orden));
                conexion.Cmd.Parameters.Add(new SqlParameter("imagen", a.Imagen));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();
                //conexion.Cerrar();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                Logger.Log(ex.Message);
            }
        }

        public void update(Categorias a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_CategoriasAct ";
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.CategoriaID));
                conexion.Cmd.Parameters.Add(new SqlParameter("nombre", a.Nombre));
                conexion.Cmd.Parameters.Add(new SqlParameter("Nivel", a.Nivel));
                conexion.Cmd.Parameters.Add(new SqlParameter("orden", a.Orden));
                conexion.Cmd.Parameters.Add(new SqlParameter("imagen", a.Imagen));
                conexion.Cmd.CommandType = CommandType.StoredProcedure;
                conexion.Cmd.ExecuteNonQuery();
                //conexion.Cerrar();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                Logger.Log(ex.Message);
            }
        }

        public void delete(Categorias a)
        {
            try
            {
                conexion.Cmd.Connection.Open();
                conexion.Cmd.CommandText = "sp_CategoriasDelete" ;
                conexion.Cmd.Parameters.Clear();
                conexion.Cmd.Parameters.Add(new SqlParameter("Id", a.CategoriaID));
                conexion.Cmd.ExecuteNonQuery();
                conexion.Cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                
                Logger.Log(ex.Message);
            }
        }
        #endregion

        internal Categorias getByNombre(Categorias _categoria)
        {
           categoria = null;
           try
           {
               conexion.Cmd.Connection.Open();
               conexion.Cmd.CommandText = "Select * from C_categorias where Nombre='" + _categoria.Nombre + "'"; 
               conexion.Cmd.Parameters.Clear();
               conexion.Cmd.CommandType = CommandType.Text;
               SqlDataReader dr = conexion.Cmd.ExecuteReader();
               if (dr.HasRows)
                   categoria = mapearObjeto(dr);
               //conexion.Cerrar();
               dr.Close();
               conexion.Cmd.Connection.Close();
           }
           catch (SqlException ex)
           {

               conexion.Cmd.Connection.Close();
               Logger.Log(ex.Message);
           }
           return categoria;
        }
    }
}
