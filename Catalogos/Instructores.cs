using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Instructores
    {
        private String _InstructorID;
        private String _Nombre;
        private string _Calle;
        private string _Colonia;
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
        [System.Runtime.Serialization.DataMember]
        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }
        [System.Runtime.Serialization.DataMember]
        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }
         [System.Runtime.Serialization.DataMember]
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
         [System.Runtime.Serialization.DataMember]
        public string InstructorID
        {
            get { return _InstructorID; }
            set { _InstructorID = value; }
        }

        private string _Cp;
         [System.Runtime.Serialization.DataMember]
        public string Cp
        {
            get { return _Cp; }
            set { _Cp = value; }
        }

        private string _Telefono;
        [System.Runtime.Serialization.DataMember]
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _RFC;
         [System.Runtime.Serialization.DataMember]
        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }

        private string _CURP;
         [System.Runtime.Serialization.DataMember]
        public string CURP
        {
            get { return _CURP; }
            set { _CURP = value; }
        }
        private string _IMSS;
         [System.Runtime.Serialization.DataMember]
        public string IMSS
        {
            get { return _IMSS; }
            set { _IMSS = value; }
        }
        private string _DeporteID;
         [System.Runtime.Serialization.DataMember]
        public string DeporteID
        {
            get { return _DeporteID; }
            set { _DeporteID = value; }
        }

        private string _Pais;
         [System.Runtime.Serialization.DataMember]
        public string Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
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

        private byte[] _Foto;
         [System.Runtime.Serialization.DataMember]
        public byte[] Foto
        {
            get { return _Foto; }
            set { _Foto = value; }
        }

        private string _Status;
         [System.Runtime.Serialization.DataMember]
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _Indicador;
         [System.Runtime.Serialization.DataMember]
        public int Indicador
        {
            get { return _Indicador; }
            set { _Indicador = value; }
        }

        private string _Sangre;
         [System.Runtime.Serialization.DataMember]
        public string Sangre
        {
            get { return _Sangre; }
            set { _Sangre = value; }
        }

        private double _Salario;
         [System.Runtime.Serialization.DataMember]
        public double Salario
        {
            get { return _Salario; }
            set { _Salario = value; }
        }

        private double _Percepciones;
         [System.Runtime.Serialization.DataMember]
        public double Percepciones
        {
            get { return _Percepciones; }
            set { _Percepciones = value; }
        }

        private double _Deduciones;
         [System.Runtime.Serialization.DataMember]
        public double Deduciones
        {
            get { return _Deduciones; }
            set { _Deduciones = value; }
        }

        private double _Incentivos;
         [System.Runtime.Serialization.DataMember]
        public double Incentivos
        {
            get { return _Incentivos; }
            set { _Incentivos = value; }
        }

        private int _SucursalID;
         [System.Runtime.Serialization.DataMember]
        public int SucursalID
        {
            get { return _SucursalID; }
            set { _SucursalID = value; }
        }

        public Instructores(string InstructorId,
            string Nombre,string Calle,
            string Colonia,
            string Ciudad,
            string Estado,
            string CP,
            string Telefono,
            string RFC,
            string CURP,
            string IMSS,
            string DeporteId,
            string Pais,
            string LugarNac,
            DateTime FechaNac,
            int Edad,
            string Nacionalidad,
            byte[] Foto,
            string Status,
            int Indicador,
            string Sangre,
            double Salario,
            string Observaciones,
            double SalarioMH,
            double Percepciones,
            double Deduciones,
            double Incentivos,
            int SucursalID)
        {
        _InstructorID=InstructorId;
        _Nombre= Nombre;
        _Calle= Calle;
        _Colonia=Colonia;
        _Ciudad=Ciudad;
        _Estado=Estado;
        _Cp=Cp;
        _Telefono=Telefono;
        _RFC=RFC;
        _CURP=CURP;
        _IMSS=IMSS;
        _DeporteID = DeporteId;
        _Pais=Pais;
        _LugarNac=LugarNac;
        _FechaNac=FechaNac;
        _Edad=Edad;
        _Nacionalidad=Nacionalidad;
        _Foto=Foto;
        _Status=Status;
        _Indicador=Indicador;
        _Sangre=Sangre;
        _Salario=Salario;
        _Observaciones=Observaciones;
        _SalarioMH=SalarioMH;
        _Percepciones=Percepciones;
        _Deduciones=Deduciones;
        _Incentivos=Incentivos;
        _SucursalID = SucursalID;
        }

        public Instructores()
        {
            
        }

        public Instructores(String id)
        {

            _InstructorID = id;
        }

        ~Instructores()
        {
            
        }

        private string _Observaciones;
        [System.Runtime.Serialization.DataMember]
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private double _SalarioMH;

        [System.Runtime.Serialization.DataMember]
        public double SalarioMH
        {
            get { return _SalarioMH; }
            set { _SalarioMH = value; }
        }
    }
}
