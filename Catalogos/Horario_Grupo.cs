using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class HorariosGpo
    {
        private string _GrupoID;

         [System.Runtime.Serialization.DataMember]
        public string GrupoID
        {
            get { return _GrupoID; }
            set { _GrupoID = value; }
        }
        private string _Salon;

         [System.Runtime.Serialization.DataMember]
        public string Salon
        {
            get { return _Salon; }
            set { _Salon = value; }
        }
        private string _Dia;

         [System.Runtime.Serialization.DataMember]
        public string Dia
        {
            get { return _Dia; }
            set { _Dia = value; }
        }
        private string _Hora_Inicio;

         [System.Runtime.Serialization.DataMember]
        public string Hora_Inicio
        {
            get { return _Hora_Inicio; }
            set { _Hora_Inicio = value; }
        }
        private string _Hora_Final;

         [System.Runtime.Serialization.DataMember]
        public string Hora_Final
        {
            get { return _Hora_Final; }
            set { _Hora_Final = value; }
        }

        public HorariosGpo(string GrupoId,
        string Salon,
        string Dia,
        string Hora_Inicio,
        string Hora_Final)
        {
            _GrupoID = GrupoId;
            _Salon = Salon;
            _Dia = Dia;
            _Hora_Inicio = Hora_Inicio;
            _Hora_Final = Hora_Final;
            
        }

        public HorariosGpo()
        {
            
        }

        ~HorariosGpo()
        {
            
        }
    }
}
