using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Agrupacion
    {   
        private String _Nombre;

          [System.Runtime.Serialization.DataMember]
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private int _SocioID;
          [System.Runtime.Serialization.DataMember]
        public int SocioID
        {
            get { return _SocioID; }
            set { _SocioID = value; }
        }
        private int _AgrupacionID;
          [System.Runtime.Serialization.DataMember]
        public int AgrupacionID
        {
            get { return _AgrupacionID; }
            set { _AgrupacionID = value; }
        }
        private Boolean _Factura;
          [System.Runtime.Serialization.DataMember]
        public Boolean Factura
        {
            get { return _Factura; }
            set { _Factura = value; }
        }
        private int _SucursalID;
          [System.Runtime.Serialization.DataMember]
        public int SucursalID
        {
            get { return _SucursalID; }
            set { _SucursalID = value; }
        }

        
    }
}
