using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    class empresas
    {
        private int _idEmpresa;
        private string _rfcEmpresa;

          [System.Runtime.Serialization.DataMember]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }
           [System.Runtime.Serialization.DataMember]
        public string RfcEmpresa
        {
            get { return _rfcEmpresa; }
            set { _rfcEmpresa = value; }
        }
        private string _Nombre;

           [System.Runtime.Serialization.DataMember]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _RegimenFiscal;

           [System.Runtime.Serialization.DataMember]
        public string RegimenFiscal
        {
            get { return _RegimenFiscal; }
            set { _RegimenFiscal = value; }
        }
        private string _Timbrado_Clave;

           [System.Runtime.Serialization.DataMember]
        public string Timbrado_Clave
        {
            get { return _Timbrado_Clave; }
            set { _Timbrado_Clave = value; }
        }
    }
}
