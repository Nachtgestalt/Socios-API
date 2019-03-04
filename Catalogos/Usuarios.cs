using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Socios.Datos.Catalogos
{
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Usuarios
    {
        private int _User_Nip;
         [System.Runtime.Serialization.DataMember]
        public int User_Nip
        {
            get { return _User_Nip; }
            set { _User_Nip = value; }
        }
        private string _User_ID;
         [System.Runtime.Serialization.DataMember]
        public string User_ID
        {
            get { return _User_ID; }
            set { _User_ID = value; }
        }
        private string _User_Name;
         [System.Runtime.Serialization.DataMember]
        public string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        private string _User_Pwd;
         [System.Runtime.Serialization.DataMember]
        public string User_Pwd
        {
            get { return _User_Pwd; }
            set { _User_Pwd = value; }
        }
        private string _User_Type;
         [System.Runtime.Serialization.DataMember]
        public string User_Type
        {
            get { return _User_Type; }
            set { _User_Type = value; }
        }
        private string _User_Depto;
         [System.Runtime.Serialization.DataMember]
        public string User_Depto
        {
            get { return _User_Depto; }
            set { _User_Depto = value; }
        }
        private string _User_Pusto;
         [System.Runtime.Serialization.DataMember]
        public string User_Pusto
        {
            get { return _User_Pusto; }
            set { _User_Pusto = value; }
        }
        private string _User_Sts;
         [System.Runtime.Serialization.DataMember]
        public string User_Sts
        {
            get { return _User_Sts; }
            set { _User_Sts = value; }
        }

        public Usuarios()
        {
            
        }

        ~Usuarios()
        {
            
        }
    }
}
