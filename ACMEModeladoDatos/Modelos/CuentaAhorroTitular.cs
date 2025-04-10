using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Modelos
{
   public  class CuentaAhorroTitular
    {
        public int CuentaAhorroId { get; set; }
        public  CuentaAhorro CuentaAhorro { get; set; } 

        public int PersonaId { get; set; }
        public   Persona Persona { get; set; }
    }
}
