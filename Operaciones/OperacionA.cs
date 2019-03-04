using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones
{
    public abstract class OperacionA
    {
        protected static readonly string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        protected static readonly string DbPath = Path.Combine(AppPath+@"\Datos", "datosver33.mdb");
        protected static readonly string DbConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + DbPath + "';Persist Security Info=False;";

        
        protected static string _connectionString = "Data Source=.; Initial Catalog=ufacturaesql; User ID=sa; Password=COMR850106qqa;";
        //protected static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ufacturaesql;Integrated Security=SSPI;";

        public OperacionA()
        {
            
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
