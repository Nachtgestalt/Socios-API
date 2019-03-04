using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
    [System.Runtime.Serialization.DataContract(Namespace = "")]
  public  class Deportes
    {  
        #region Atributos
        private int _DeporteID;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private Boolean _Status;
        
        #endregion

        #region Constructores
        public Deportes(int DeporteID, string Nombre, string Descripcion, byte[] Imagen, Boolean Status)
        {
            _DeporteID = DeporteID;
            _Descripcion = Descripcion;
            _Imagen = Imagen;
            _Nombre = Nombre;
            _Status = Status;

        }

        public Deportes()
        {
            
        }

        public Deportes(int id)
        {
            // TODO: Complete member initialization
            _DeporteID = id;
        }
        public Deportes(String nombre)
        {
            // TODO: Complete member initialization
            _Nombre = nombre;
        }
        #endregion

        #region PropiedadesAcceso
        [System.Runtime.Serialization.DataMember]
        public Boolean Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        [System.Runtime.Serialization.DataMember]
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        [System.Runtime.Serialization.DataMember]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        [System.Runtime.Serialization.DataMember]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        [System.Runtime.Serialization.DataMember]
        public int DeporteID
        {
            get { return _DeporteID; }
            set { _DeporteID = value; }
        }
        #endregion
    }
}
