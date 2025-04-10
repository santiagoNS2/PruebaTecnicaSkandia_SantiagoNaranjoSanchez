using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Modelos
{
    public class TarjetaCredito
    {
        public int Id { get; set; }
        public   string Franquicia { get; set; }
        public   string NumeroTarjeta { get; set; }
        public decimal CupoAprobado { get; set; }
        public decimal CupoDisponible { get; set; }
        public  string Estado { get; set; }

        public int PersonaId { get; set; }
        public    Persona Persona { get; set; }

        public ICollection<MovimientoTarjeta> Movimientos { get; set; } = new List<MovimientoTarjeta>();
    }
}
