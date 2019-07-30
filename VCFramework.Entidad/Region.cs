using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCFramework.Entidad
{
    public class Region
    {
        public int Id { get; set; }
        public int PaiId { get; set; }
        public string Nombre { get; set; }
        public int Eliminado { get; set; }
        public List<VCFramework.Entidad.Provincia> Provincias { get; set; }
    }
}
