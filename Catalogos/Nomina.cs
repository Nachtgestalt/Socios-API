using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Nomina
    {
        private DateTime _FechaIni;
        [System.Runtime.Serialization.DataMember]
        public DateTime FechaIni
        {
            get { return _FechaIni; }
            set { _FechaIni = value; }
        }

        private DateTime _FechaFin;
        [System.Runtime.Serialization.DataMember]
        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
    }
}
