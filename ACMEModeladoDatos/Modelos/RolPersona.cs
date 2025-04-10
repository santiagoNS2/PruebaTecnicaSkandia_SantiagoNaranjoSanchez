using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Modelos
{
    public class RolPersona
    {
        public int Id { get; set; }
        public   string Rol { get; set; } // Cliente, Accionista, etc.

        public int PersonaId { get; set; }
        public   Persona Persona { get; set; }
    }
}
