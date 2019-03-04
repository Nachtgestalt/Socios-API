using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Utilerias
{
    public class Func
    {
        public static DateTime LastMonthDay(DateTime Fecha)
        {
            DateTime mes = DateTime.Parse("01/" + Fecha.ToString("MM/yyyy"));
            return mes.AddMonths(1).AddDays(-1);
        }
    }
}
