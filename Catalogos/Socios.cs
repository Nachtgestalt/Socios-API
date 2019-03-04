using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Socio
    {
        private int _SocioID;
        private string _Nombre;
          [System.Runtime.Serialization.DataMember]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _LugarNac;
          [System.Runtime.Serialization.DataMember]
        public string LugarNac
        {
            get { return _LugarNac; }
            set { _LugarNac = value; }
        }
        private DateTime _FechaNac;
          [System.Runtime.Serialization.DataMember]
        public DateTime FechaNac
        {
            get { return _FechaNac; }
            set { _FechaNac = value; }
        }
        private int _Edad;
          [System.Runtime.Serialization.DataMember]
        public int Edad
        {
            get { return _Edad; }
            set { _Edad = value; }
        }
        private string _Nacionalidad;
          [System.Runtime.Serialization.DataMember]
        public string Nacionalidad
        {
            get { return _Nacionalidad; }
            set { _Nacionalidad = value; }
        }
        private string _Calle;
          [System.Runtime.Serialization.DataMember]
        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }
        private string _Colonia;
          [System.Runtime.Serialization.DataMember]
        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
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
        private int _Promocion;
          [System.Runtime.Serialization.DataMember]
        public int Promocion
        {
            get { return _Promocion; }
            set { _Promocion = value; }
        }
        private char _Status;
          [System.Runtime.Serialization.DataMember]
        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private char _Socio_anterior;
          [System.Runtime.Serialization.DataMember]
        public char Socio_anterior
        {
            get { return _Socio_anterior; }
            set { _Socio_anterior = value; }
        }
        private string _Razon;
          [System.Runtime.Serialization.DataMember]
        public string Razon
        {
            get { return _Razon; }
            set { _Razon = value; }
        }
        private DateTime _Fecha_Alta;
          [System.Runtime.Serialization.DataMember]
        public DateTime Fecha_Alta
        {
            get { return _Fecha_Alta; }
            set { _Fecha_Alta = value; }
        }
        private DateTime _Fecha_Baja;
          [System.Runtime.Serialization.DataMember]
        public DateTime Fecha_Baja
        {
            get { return _Fecha_Baja; }
            set { _Fecha_Baja = value; }
        }
        private string _Observacion;
          [System.Runtime.Serialization.DataMember]
        public int Actividad
        {
            get { return _Actividad; }
            set { _Actividad = value; }
        }
        private int _Actividad;
          [System.Runtime.Serialization.DataMember]
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        private DateTime _FechaRein;
          [System.Runtime.Serialization.DataMember]
        public DateTime FechaRein
        {
            get { return _FechaRein; }
            set { _FechaRein = value; }
        }
        private Boolean _ExpDif;
          [System.Runtime.Serialization.DataMember]
        public Boolean ExpDif
        {
            get { return _ExpDif; }
            set { _ExpDif = value; }
        }
        private string _Expectativas;
          [System.Runtime.Serialization.DataMember]
        public string Expectativas
        {
            get { return _Expectativas; }
            set { _Expectativas = value; }
        }
        private string _Email;
          [System.Runtime.Serialization.DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
          [System.Runtime.Serialization.DataMember]
        public int SocioID
        {
            get { return _SocioID; }
            set { _SocioID = value; }
        }
        private bool _ExaUbicacion;
          [System.Runtime.Serialization.DataMember]
        public bool ExaUbicacion
        {
            get { return _ExaUbicacion; }
            set { _ExaUbicacion = value; }
        }

        private List<SocioAsistencias> _Asitencia;
          [System.Runtime.Serialization.DataMember]
        public List<SocioAsistencias> Asitencia
        {
            get { return _Asitencia; }
            set { _Asitencia = value; }
        }
        private List<SociosHorario> _Horario;
          [System.Runtime.Serialization.DataMember]
        public List<SociosHorario> Horario
        {
            get { return _Horario; }
            set { _Horario = value; }
        }

        private List<SociosHorariodet> _Horariodet;
          [System.Runtime.Serialization.DataMember]
        public List<SociosHorariodet> Horariodet
        {
            get { return _Horariodet; }
            set { _Horariodet = value; }
        }
        private int _SucursalID;
          [System.Runtime.Serialization.DataMember]
        public int SucursalID
        {
            get { return _SucursalID; }
            set { _SucursalID = value; }
        }
        ~Socio()
        {
            
        }

        public Socio(int SocioID)
        {
            _SocioID = SocioID;
        }

        public Socio()
        {
            
        }

        public Socio(string id, int sucursalID)
        {
            
            _SocioID = int.Parse(id);
            _SucursalID = sucursalID;
        }
    }
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class SocioListado
    {
          [System.Runtime.Serialization.DataMember]
        public string NoSocio { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Nombre { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string status { get; set; }
          [System.Runtime.Serialization.DataMember]
        public int sucursalID { get; set; }
        
    }
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class SocioAsistencias
    {
          [System.Runtime.Serialization.DataMember]
        public string Dia { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Asi { get; set; }
        
    }
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class SociosHorario
    {
          [System.Runtime.Serialization.DataMember]
        public string Grupo { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Nombre { get; set; }
          [System.Runtime.Serialization.DataMember]
          public string Categoria { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Instructor { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Horario { get; set; }
          [System.Runtime.Serialization.DataMember]
        public Boolean Domingo { get; set; }
          [System.Runtime.Serialization.DataMember]
        public Boolean Lunes { get; set; }
          [System.Runtime.Serialization.DataMember]
        public Boolean Martes { get; set; }
          [System.Runtime.Serialization.DataMember]
        public Boolean Miercoles { get; set; }
          [System.Runtime.Serialization.DataMember]
        public Boolean Jueves { get; set; }
          [System.Runtime.Serialization.DataMember]
        public Boolean Viernes { get; set; }
          [System.Runtime.Serialization.DataMember]
        public Boolean Sabado { get; set; }

    }
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class SociosHorariodet
    {
          [System.Runtime.Serialization.DataMember]
        public string Grupo { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Nombre { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Categoria { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Instructor { get; set; }
          [System.Runtime.Serialization.DataMember]
        public string Horario { get; set; }
          [System.Runtime.Serialization.DataMember]

        public string Dia { get; set; }
        
    }
 }
