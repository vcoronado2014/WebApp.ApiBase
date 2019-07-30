using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using VCFramework.Negocio.Factory;

namespace VCFramework.Negocio
{
    
    public class Provincia
    {
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static List<VCFramework.Entidad.Provincia> ListarPorRegion(int regId)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Provincia> lista2 = new List<VCFramework.Entidad.Provincia>();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "REG_ID";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = regId.ToString();

            List<object> lista = fac.Leer<VCFramework.Entidad.Provincia>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Provincia>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                lista2 = lista2.FindAll(p => p.Eliminado == 0).ToList();
            }

            return lista2;
        }

    }
}
