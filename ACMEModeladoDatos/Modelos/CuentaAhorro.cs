using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Modelos
{
   public  class CuentaAhorro
    {
        public int Id { get; set; }
        public  string NumeroCuenta { get; set; }
        public decimal SaldoTotal { get; set; }
        public decimal SaldoCanje { get; set; }
        public decimal SaldoDisponible { get; set; }
        public  string Estado { get; set; }

        public ICollection<CuentaAhorroTitular> Titulares { get; set; } = new List<CuentaAhorroTitular>();
        public ICollection<MovimientoCuenta> Movimientos { get; set; } = new List<MovimientoCuenta>();
    }
}
