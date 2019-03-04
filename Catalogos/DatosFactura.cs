using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
      [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class DatosFactura
    {
        private int _SocioID;

         [System.Runtime.Serialization.DataMember]
        public int SocioID
        {
            get { return _SocioID; }
            set { _SocioID = value; }
        }

        private int _SucursalID;

         [System.Runtime.Serialization.DataMember]
        public int SucursalID
        {
            get { return _SucursalID; }
            set { _SucursalID = value; }
        }
        private string _Nombre;

         [System.Runtime.Serialization.DataMember]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _Puesto;

         [System.Runtime.Serialization.DataMember]
        public string Puesto
        {
            get { return _Puesto; }
            set { _Puesto = value; }
        }
        private string _Calle;

         [System.Runtime.Serialization.DataMember]
        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }
        private string _NoExterior;

         [System.Runtime.Serialization.DataMember]
        public string NoExterior
        {
            get { return _NoExterior; }
            set { _NoExterior = value; }
        }
        private string _NoInterior;

         [System.Runtime.Serialization.DataMember]
        public string NoInterior
        {
            get { return _NoInterior; }
            set { _NoInterior = value; }
        }
        private string _Localidad;

         [System.Runtime.Serialization.DataMember]
        public string Localidad
        {
            get { return _Localidad; }
            set { _Localidad = value; }
        }
        private string _Colonia;

         [System.Runtime.Serialization.DataMember]
        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }
        private string _Referencia;

         [System.Runtime.Serialization.DataMember]
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }
        private string _Ciudad;

         [System.Runtime.Serialization.DataMember]
        public string Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }
        private string _Estado;

         [System.Runtime.Serialization.DataMember]
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private string _Pais;

         [System.Runtime.Serialization.DataMember]
        public string Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
        }
        private string _CP;

           [System.Runtime.Serialization.DataMember]
        public string CP
        {
            get { return _CP; }
            set { _CP = value; }
        }
        private string _Telefono;

           [System.Runtime.Serialization.DataMember]
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private string _Fax;

         [System.Runtime.Serialization.DataMember]
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        private string _eMail;

         [System.Runtime.Serialization.DataMember]
        public string EMail
        {
            get { return _eMail; }
            set { _eMail = value; }
        }
        private string _RFC;

         [System.Runtime.Serialization.DataMember]
        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }
        private string _MetodoPago;

         [System.Runtime.Serialization.DataMember]
        public string MetodoPago
        {
            get { return _MetodoPago; }
            set { _MetodoPago = value; }
        }
        private string _Cuenta;

         [System.Runtime.Serialization.DataMember]
        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        public DatosFactura()
        {
            
        }

    }
}
