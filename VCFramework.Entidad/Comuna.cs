using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCFramework.Entidad
{
    public class Comuna
    {
        public int Id { get; set; }
        public int PrvId { get; set; }
        public string Nombre { get; set; }
        public int Eliminado { get; set; }
    }
}
