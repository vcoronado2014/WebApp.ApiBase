using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCFramework.Entidad
{
    public class UsuarioEnvoltorio
    {
        public Entidad.AutentificacionUsuario AutentificacionUsuario { get; set; }
        public Entidad.Persona Persona { get; set; }
        public Entidad.Region Region { get; set; }
        public Entidad.Comuna Comuna { get; set; }
        public Entidad.Rol Rol { get; set; }
    }
}
