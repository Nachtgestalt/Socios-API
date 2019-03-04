using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Categorias
    {
        private int _CategoriaID;

   [System.Runtime.Serialization.DataMember]
        public int CategoriaID
        {
            get { return _CategoriaID; }
            set { _CategoriaID = value; }
        }
        private string _Nombre;

        [System.Runtime.Serialization.DataMember]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private double _Nivel;

        [System.Runtime.Serialization.DataMember]
        public double Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }
        private int _Orden;

        [System.Runtime.Serialization.DataMember]
        public int Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        public Categorias(int CategoriaID, double Nivel, string Nombre, int Orden, byte[] Imagen)
        {
            _CategoriaID = CategoriaID;
            _Nivel = Nivel;
            _Nombre = Nombre;
            _Orden = Orden;
            _Imagen = Imagen;
        }
        private byte[] _Imagen;
        [System.Runtime.Serialization.DataMember]
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public Categorias()
        {
            
        }

        public Categorias(int id)
        {
            _CategoriaID = id;
        }
    }
}
