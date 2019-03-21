using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Socios.Datos.Utilerias
{
    class Logger
    {
        

        public static void Log(string cadena)
        {
            string directory = System.Web.Hosting.HostingEnvironment.MapPath("~/log.txt");
            string logFile = "log.txt";
            string path = Path.Combine(directory, logFile);
            try
            {
                StreamWriter sw = new StreamWriter(directory, true);
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
