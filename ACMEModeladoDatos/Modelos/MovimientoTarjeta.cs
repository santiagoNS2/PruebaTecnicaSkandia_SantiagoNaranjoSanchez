using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Modelos
{
   public  class MovimientoTarjeta
    {
        public int Id { get; set; }
        public int TarjetaCreditoId { get; set; }
        public   TarjetaCredito TarjetaCredito { get; set; }

        public  string TipoMovimiento { get; set; } // Compra, Pago, etc.
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }
}
