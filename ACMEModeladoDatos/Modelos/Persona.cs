using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Modelos
{
   public  class Persona
    {
        public int Id { get; set; }
        public  string TipoPersona { get; set; } // Natural o Juridica
        public string TipoDocumento { get; set; }
        public  string NumeroDocumento { get; set; }
        public  string Nombres { get; set; }
        public  string Apellidos { get; set; }

        public   string DepartamentoResidencia { get; set; }
        public   string MunicipioResidencia { get; set; }

        // Relaciones
        public ICollection<RolPersona> Roles { get; set; } = new List<RolPersona>();
        public ICollection<CuentaAhorroTitular> Cuentas { get; set; } = new List<CuentaAhorroTitular>();
        public ICollection<TarjetaCredito> Tarjetas { get; set; } = new List<TarjetaCredito>();
    }
}
