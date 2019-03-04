using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Socios.Datos.Catalogos
{
     [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Grupos
    {
        private string _GrupoID;

        private List<GruposHorario> _Horario;
          [System.Runtime.Serialization.DataMember]
        public  List<GruposHorario> Horario
        {
            get { return _Horario; }
            set { _Horario = value; }
        }

        private List<HorariosGpo> _Hrgpo;
          [System.Runtime.Serialization.DataMember]
        public List<HorariosGpo> Hrgpo
        {
            get { return _Hrgpo; }
            set { _Hrgpo = value; }
        }
          [System.Runtime.Serialization.DataMember]
        public string GrupoID
        {
            get { return _GrupoID; }
            set { _GrupoID = value; }
        }
        private String _Nombre;

          [System.Runtime.Serialization.DataMember]
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _Duracion;

          [System.Runtime.Serialization.DataMember]
        public string Duracion
        {
            get { return _Duracion; }
            set { _Duracion = value; }
        }
        private string _Salon;

          [System.Runtime.Serialization.DataMember]
        public string Salon
        {
            get { return _Salon; }
            set { _Salon = value; }
        }
        private int _Cupo;

          [System.Runtime.Serialization.DataMember]
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        private int _Inscritos;

          [System.Runtime.Serialization.DataMember]
        public int Inscritos
        {
            get { return _Inscritos; }
            set { _Inscritos = value; }
        }
        private int _Apartado;

          [System.Runtime.Serialization.DataMember]
        public int Apartado
        {
            get { return _Apartado; }
            set { _Apartado = value; }
        }
        private string _Categoria;

          [System.Runtime.Serialization.DataMember]
        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
        private string _InstructorID;

          [System.Runtime.Serialization.DataMember]
        public string InstructorID
        {
            get { return _InstructorID; }
            set { _InstructorID = value; }
        }
        private DateTime _PeriodoID_Inicio;

          [System.Runtime.Serialization.DataMember]
        public DateTime PeriodoID_Inicio
        {
            get { return _PeriodoID_Inicio; }
            set { _PeriodoID_Inicio = value; }
        }
        private DateTime _PeriodoID_Final;

          [System.Runtime.Serialization.DataMember]
        public DateTime PeriodoID_Final
        {
            get { return _PeriodoID_Final; }
            set { _PeriodoID_Final = value; }
        }
        private int _orden;

          [System.Runtime.Serialization.DataMember]
        public int Orden
        {
            get { return _orden; }
            set { _orden = value; }
        }

        public Grupos(string GrupoId,
   String Nombre,
   String Duracion,
   String Salon,
   int Cupo,
   int Inscritos,
   int Apartado,
   string Categoria,
   string InstructorId,
   DateTime PeriodoId_Inicio,
   DateTime PeriodoId_Final,
   int orden,
   int SucursalID
)
        {
            _GrupoID = GrupoId;
            _Nombre = Nombre;
            _Duracion = Duracion;
            _Salon = Salon;
            _Cupo = Cupo;
            _Inscritos = Inscritos;
            _Apartado = Apartado;
            _Categoria = Categoria;
            _InstructorID = InstructorId;
            _PeriodoID_Inicio = PeriodoId_Inicio;
            _PeriodoID_Final = PeriodoId_Final;
            _orden = orden;
            _SucursalID = SucursalID;
        }
        private int _SucursalID;

          [System.Runtime.Serialization.DataMember]
        public int SucursalID
        {
            get { return _SucursalID; }
            set { _SucursalID = value; }
        }

        public Grupos()
        {
            
        }

        public Grupos(string id,int SucursalID)
        {
            // TODO: Complete member initialization
            _GrupoID = id;
            _SucursalID = SucursalID;
        }

        ~Grupos()
        {
            
        }
    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Dias
    {
         [System.Runtime.Serialization.DataMember]
        public List<string> dia { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int mes { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int año { get; set; }
            
    }

    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class GruposHoraDistinct
    {
         [System.Runtime.Serialization.DataMember]
         public string Horario { get; set; }
         [System.Runtime.Serialization.DataMember]
         public int Sucursal { get; set; }

    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class GruposListado
    {
         [System.Runtime.Serialization.DataMember]
        public string Grupo { get; set; }
         [System.Runtime.Serialization.DataMember]
        public string Nombre { get; set; }
         [System.Runtime.Serialization.DataMember]
        public string Categoria { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int Cupo { get; set; }
         [System.Runtime.Serialization.DataMember]
        public int inscritos { get; set; }
         [System.Runtime.Serialization.DataMember]
        public string Horario { get; set; }
         [System.Runtime.Serialization.DataMember]
        public string Dias { get; set; }
         [System.Runtime.Serialization.DataMember]
        public List<GruposDetalle> Alumnos { get; set; }
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class GruposHorario
    {
         [System.Runtime.Serialization.DataMember]
        public string Entrada { get; set; }
         [System.Runtime.Serialization.DataMember]
        public string Salida  { get; set; }
         [System.Runtime.Serialization.DataMember]
        public Boolean Domingo { get; set; }
         [System.Runtime.Serialization.DataMember]
        public Boolean Lunes  { get; set; }
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
    public class GruposDetalle
    {
         [System.Runtime.Serialization.DataMember]
        public int NoSocio { get; set; }
         [System.Runtime.Serialization.DataMember]
        public String Nombre { get; set; }
        
        
    }
}
