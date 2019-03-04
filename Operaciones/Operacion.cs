using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones
{
    public abstract class Operacion
    {
        protected static string _connectionString = ConfigurationManager.ConnectionStrings["cnxOpe"].ConnectionString;
        //protected static string _connectionString = "Data Source=palmserver; Initial Catalog=Acuatica; User ID=sa; Password=Aquara01.;";
        //protected static string _connectionString = "Data Source=.; Initial Catalog=uFacturaESQL; User ID=sa; Password=COMR850106qqa;";
        //protected static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=uFacturaESQL;Integrated Security=SSPI;";

        public Operacion()
        {


            if ( Conexion.Connection()!=null)
            _connectionString = Conexion.Connection();
                    
            
        }

        protected static string _mensajeErrorUsuario = "No fué posible realizar la operación";
        public string MensajeErrorUsuario
        {
            get { return _mensajeErrorUsuario; }
        }

        protected static string _mensajeErrorSistema = string.Empty;
        public string MensajeErrorSistema
        {
            get { return _mensajeErrorSistema; }
        }

        protected void GrabarLogError(Exception ex)
        {
            //nada aún
        }

        private string GetAppPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        }
    }
}
