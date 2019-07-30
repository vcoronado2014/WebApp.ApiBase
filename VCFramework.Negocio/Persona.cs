using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using VCFramework.Negocio.Factory;

namespace VCFramework.Negocio
{
    public class Persona
    {
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static VCFramework.Entidad.Persona ObtenerPorId(int id)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Persona> lista2 = new List<VCFramework.Entidad.Persona>();
            VCFramework.Entidad.Persona entidad = new Entidad.Persona();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = id.ToString();

            List<object> lista = fac.Leer<VCFramework.Entidad.Persona>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Persona>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                entidad = lista2[0];
            }

            return entidad;
        }
        public static VCFramework.Entidad.Persona ObtenerPorAusId(int ausId)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Persona> lista2 = new List<VCFramework.Entidad.Persona>();
            VCFramework.Entidad.Persona entidad = new Entidad.Persona();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "AUS_ID";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = ausId.ToString();

            List<object> lista = fac.Leer<VCFramework.Entidad.Persona>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Persona>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                entidad = lista2[0];
            }

            return entidad;
        }

    }
}
