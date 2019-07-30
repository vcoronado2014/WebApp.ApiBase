using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCFramework.Entidad
{
    public class AutentificacionUsuario
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int Eliminado { get; set; }
        public string CorreoElectronico { get; set; }
        public int EsVigente { get; set; }
        public int RolId { get; set; }
        public int NodId { get; set; }
        public int Id { get; set; }
    }
}
