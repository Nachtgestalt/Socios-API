using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections;

namespace uFacturaEDatos.Operaciones.MetodosPago
{

    public class Metodos : IEnumerator, IEnumerable
    {
        private Metodo[] metodoslist;
        int position = -1;

        //Create internal array in constructor.
        public Metodos()
        {
            metodoslist = new Metodo[21]
      {
         new Metodo("Efectivo","01"),
         new Metodo("Cheque","02"),
         new Metodo("Transferencia electronica de fondos","03"),
         new Metodo("Tarjetas de crédito","04"),
         new Metodo("Tarjetas de debito","28"),
         new Metodo("Tarjetas de servicio","29"),
         new Metodo("Monederos electrónicos","05"),
         new Metodo("Dinero electrónico","06"),
         new Metodo("Tarjetas digitales","07"),
         new Metodo("Vales de despensa","08"),
         new Metodo("Bienes","09"),
         new Metodo("Servicio","10"),
         new Metodo("Por cuenta de tercero","11"),
         new Metodo("Dación en pago","12"),
         new Metodo("Pago por subrogación","13"),
         new Metodo("Pago por consignación","14"),
         new Metodo("Condonación","15"),
         new Metodo("Cancelación","16"),
         new Metodo("Compensación","17"),
         new Metodo("Por definir","99"),
         new Metodo("Otros","98"),
      };
        }

        //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < metodoslist.Length);
        }

        //IEnumerable
        public void Reset()
        { position = 0; }

        //IEnumerable
        public object Current
        {
            get { return metodoslist[position]; }
        }
        public Metodo obtener(string p)
        {
            foreach (Metodo x in metodoslist)
            {
                if (x.Clave == p)
                {
                    return x;
                }

            }
            return null;
        }
        

        public Metodo obtenerD(string p)
        {
            foreach (Metodo x in metodoslist)
            {
                if (x.Descripcion.ToUpper() == p.ToUpper())
                {
                    return x;
                }

            }
            return null;
        }
    }
}

