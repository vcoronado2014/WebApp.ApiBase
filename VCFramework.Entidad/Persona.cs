using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCFramework.Entidad
{
    public class Persona
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int PaisId { get; set; }
        public int RegId { get; set; }
        public int ComId { get; set; }
        public string DireccionCompleta { get; set; }
        public int InstId { get; set; }

        public int UsuId { get; set; }

        public string Telefonos { get; set; }
        public int Eliminado { get; set; }
    }
}
