using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using VCFramework.Negocio.Factory;

namespace VCFramework.Negocio
{
    public class Rol
    {
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];

        public static VCFramework.Entidad.Rol ObtenerPorId(int id)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Rol> lista2 = new List<VCFramework.Entidad.Rol>();
            VCFramework.Entidad.Rol entidad = new Entidad.Rol();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = id.ToString();

            List<object> lista = fac.Leer<VCFramework.Entidad.Rol>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Rol>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                entidad = lista2[0];
            }

            return entidad;
        }

        public static List<VCFramework.Entidad.Rol> Listar()
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Rol> lista2 = new List<VCFramework.Entidad.Rol>();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ELIMINADO";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = "0";

            List<object> lista = fac.Leer<VCFramework.Entidad.Rol>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Rol>().ToList();
            }

            return lista2;
        }


    }
}
