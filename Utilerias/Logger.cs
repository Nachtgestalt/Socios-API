using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Socios.Datos.Utilerias
{
    class Logger
    {
        
         private static string logFile="log.txt";

        public static void Log(string cadena)
        {
            try
            {
                StreamWriter sw = new StreamWriter(logFile,true);
                sw.WriteLine(DateTime.Now + ": " + cadena);
                sw.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("No se pudo guardar el log del error: " 
                    + cadena + "..." + ex.Message);
            }
        }
    }
}
