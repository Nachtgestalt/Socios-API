using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones
{
    public static class Conexion
    {
        
            private static string stringConnection;
            public static string Connection()
            {
                return stringConnection;
            }

            public static void SetStringConnection(string connection)
            {
                stringConnection = connection;
            }
        
    }
}
