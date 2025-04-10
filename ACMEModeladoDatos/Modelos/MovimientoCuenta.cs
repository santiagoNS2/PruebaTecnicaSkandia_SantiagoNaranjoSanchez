using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Modelos
{
   public class MovimientoCuenta
    {
        public int Id { get; set; }
        public int CuentaAhorroId { get; set; }
        public   CuentaAhorro CuentaAhorro { get; set; } 

        public  string TipoMovimiento { get; set; } // Deposito, Retiro, etc.
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }
}
