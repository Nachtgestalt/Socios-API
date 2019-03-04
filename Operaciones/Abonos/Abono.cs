using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace uFacturaEDatos.Operaciones.Abonos
{
    public class Abono : Operacion
    {
        uFacturaEDatos.BasedatosDataContext _db = null;

        public Abono()
        {
            _db = new BasedatosDataContext(_connectionString);
            _db.CommandTimeout = 240;
        }

        public bool Guardar(uFacturaEDatos.Cuentas_Por_Cobrar abono)
        {
            bool resultado = false;
            try
            {
                _db.Cuentas_Por_Cobrars.InsertOnSubmit(abono);
                _db.SubmitChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                _mensajeErrorSistema = ex.Message;
                GrabarLogError(ex);
                throw new Exception("No fué posible guardar abono");
            }

            return resultado;
        }
    }
}
