using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Actividades
    {
        private int _AreaID;
        private String _Nombre;
        private String _DeporteID;
        private String _Status;
        private String _Areap;
        private int _NoDias;


        [System.Runtime.Serialization.DataMember]
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        [System.Runtime.Serialization.DataMember]
        public String DeporteID
        {
            get { return _DeporteID; }
            set { _DeporteID = value; }
        }

        [System.Runtime.Serialization.DataMember]
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        [System.Runtime.Serialization.DataMember]
        public String Areap
        {
            get { return _Areap; }
            set { _Areap = value; }
        }

        [System.Runtime.Serialization.DataMember]
        public int NoDias
        {
            get { return _NoDias; }
            set { _NoDias = value; }
        }
        [System.Runtime.Serialization.DataMember]
        public int AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; }
        }

        public Actividades( int AreaID,
        String Nombre,
        String DeporteID,
        String Status,
        String Areap,
        int NoDias)
        {
            _AreaID = AreaID;
            _Nombre = Nombre;
            _DeporteID = DeporteID;
            _Status = Status;
            _Areap = Areap;
            _NoDias = NoDias;
        }

        public Actividades()
        {
            
        }

        public Actividades(int id)
        {
            
            _AreaID = id;
        }

        ~Actividades()
        {
            
        }
    }
}
