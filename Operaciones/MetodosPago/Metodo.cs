using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uFacturaEDatos.Operaciones.MetodosPago
{
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class Metodo
    {
        private string clave;
        private string descripcion;
        public Metodo()
        {
            descripcion = "";
            clave = "";
        }
        public Metodo(string Descripcion, string Clave)
        {
            descripcion = Descripcion;
            clave = Clave;
        }
        [System.Runtime.Serialization.DataMember]
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        [System.Runtime.Serialization.DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
