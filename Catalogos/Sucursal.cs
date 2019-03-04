using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
      [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Sucursal
    {
        private int _idsucursal;
            [System.Runtime.Serialization.DataMember]
        public int Idsucursal
        {
            get { return _idsucursal; }
            set { _idsucursal = value; }
        }
        private int _idempresa;
            
        [System.Runtime.Serialization.DataMember]
        public int Idempresa
        {
            get { return _idempresa; }
            set { _idempresa = value; }
        }
        private Boolean _essucursal;
        
        [System.Runtime.Serialization.DataMember]
        public Boolean Essucursal
        {
            get { return _essucursal; }
            set { _essucursal = value; }
        }
        private string _nombresucursal;
        [System.Runtime.Serialization.DataMember]
        public string Nombresucursal
        {
            get { return _nombresucursal; }
            set { _nombresucursal = value; }
        }
        private string _LugarExpedicion;
        [System.Runtime.Serialization.DataMember]
        public string LugarExpedicion
        {
            get { return _LugarExpedicion; }
            set { _LugarExpedicion = value; }
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
        private string _Nointerior;
          [System.Runtime.Serialization.DataMember]
        public string Nointerior
        {
            get { return _Nointerior; }
            set { _Nointerior = value; }
        }
        private string _cp;
        [System.Runtime.Serialization.DataMember]
        public string Cp
        {
            get { return _cp; }
            set { _cp = value; }
        }
        private string _colonia;
          [System.Runtime.Serialization.DataMember]
        public string Colonia
        {
            get { return _colonia; }
            set { _colonia = value; }
        }
        private string _localidad;
          [System.Runtime.Serialization.DataMember]
        public string Localidad
        {
            get { return _localidad; }
            set { _localidad = value; }
        }
        private string _municipio;
          [System.Runtime.Serialization.DataMember]
        public string Municipio
        {
            get { return _municipio; }
            set { _municipio = value; }
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
        private string _Logotipo;
          [System.Runtime.Serialization.DataMember]
        public string Logotipo
        {
            get { return _Logotipo; }
            set { _Logotipo = value; }
        }
        private string _DirectorioTrabajo;
        [System.Runtime.Serialization.DataMember]
        public string DirectorioTrabajo
        {
            get { return _DirectorioTrabajo; }
            set { _DirectorioTrabajo = value; }
        }
        private string _Correo_Servidor;
        [System.Runtime.Serialization.DataMember]
        public string Correo_Servidor
        {
            get { return _Correo_Servidor; }
            set { _Correo_Servidor = value; }
        }
        private int _Correo_Puerto;
        [System.Runtime.Serialization.DataMember]
        public int Correo_Puerto
        {
            get { return _Correo_Puerto; }
            set { _Correo_Puerto = value; }
        }
        private string _Correo_Correo;
          [System.Runtime.Serialization.DataMember]
        public string Correo_Correo
        {
            get { return _Correo_Correo; }
            set { _Correo_Correo = value; }
        }
        private string _Correo_Usuario;
          [System.Runtime.Serialization.DataMember]
        public string Correo_Usuario
        {
            get { return _Correo_Usuario; }
            set { _Correo_Usuario = value; }
        }
        private string _Correo_Clave;
          [System.Runtime.Serialization.DataMember]
        public string Correo_Clave
        {
            get { return _Correo_Clave; }
            set { _Correo_Clave = value; }
        }
        private Boolean _Correo_RequiereSSL;
          [System.Runtime.Serialization.DataMember]
        public Boolean Correo_RequiereSSL
        {
            get { return _Correo_RequiereSSL; }
            set { _Correo_RequiereSSL = value; }
        }
        private bool _Correo_RequiereAuth;
          [System.Runtime.Serialization.DataMember]
        public bool Correo_RequiereAuth
        {
            get { return _Correo_RequiereAuth; }
            set { _Correo_RequiereAuth = value; }
        }
        private string _Correo_Asunto;
          [System.Runtime.Serialization.DataMember]
        public string Correo_Asunto
        {
            get { return _Correo_Asunto; }
            set { _Correo_Asunto = value; }
        }
        private String _Correo_Mensaje;
          [System.Runtime.Serialization.DataMember]
        public String Correo_Mensaje
        {
            get { return _Correo_Mensaje; }
            set { _Correo_Mensaje = value; }
        }
        private string _Sello_Certificado;
          [System.Runtime.Serialization.DataMember]
        public string Sello_Certificado
        {
            get { return _Sello_Certificado; }
            set { _Sello_Certificado = value; }
        }
        private DateTime _Sello_VigenciaDesde;
          [System.Runtime.Serialization.DataMember]
        public DateTime Sello_VigenciaDesde
        {
            get { return _Sello_VigenciaDesde; }
            set { _Sello_VigenciaDesde = value; }
        }
        private DateTime _Sello_VigenciaHasta;
          [System.Runtime.Serialization.DataMember]
        public DateTime Sello_VigenciaHasta
        {
            get { return _Sello_VigenciaHasta; }
            set { _Sello_VigenciaHasta = value; }
        }
        private string _Sello_Serie;
          [System.Runtime.Serialization.DataMember]
        public string Sello_Serie
        {
            get { return _Sello_Serie; }
            set { _Sello_Serie = value; }
        }
        private string _Sello_CertificadoBase64;
          [System.Runtime.Serialization.DataMember]
        public string Sello_CertificadoBase64
        {
            get { return _Sello_CertificadoBase64; }
            set { _Sello_CertificadoBase64 = value; }
        }
        private string _Sello_Llave;
          [System.Runtime.Serialization.DataMember]
        public string Sello_Llave
        {
            get { return _Sello_Llave; }
            set { _Sello_Llave = value; }
        }
        private string _Sello_Clave;
          [System.Runtime.Serialization.DataMember]
        public string Sello_Clave
        {
            get { return _Sello_Clave; }
            set { _Sello_Clave = value; }
        }
        private string _Sello_Cancela;
          [System.Runtime.Serialization.DataMember]
        public string Sello_Cancela
        {
            get { return _Sello_Cancela; }
            set { _Sello_Cancela = value; }
        }
        private bool _Timbrado_ModoPrueba;
          [System.Runtime.Serialization.DataMember]
        public bool Timbrado_ModoPrueba
        {
            get { return _Timbrado_ModoPrueba; }
            set { _Timbrado_ModoPrueba = value; }
        }
        private string _Licencia;
          [System.Runtime.Serialization.DataMember]
        public string Licencia
        {
            get { return _Licencia; }
            set { _Licencia = value; }
        }

        
    }
}
