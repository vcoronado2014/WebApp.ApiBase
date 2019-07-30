using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using VCFramework.Negocio.Factory;

namespace VCFramework.Negocio
{
    public class Region
    {
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static List<VCFramework.Entidad.Region> ListarRegiones(bool traeSeleccione)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Region> lista2 = new List<VCFramework.Entidad.Region>();

            List<object> lista = fac.Leer<VCFramework.Entidad.Region>(setCnsWebLun);


            if (lista != null)
            {
                if (traeSeleccione)
                {
                    Entidad.Region regInicio = new Entidad.Region();
                    regInicio.Id = 0;
                    regInicio.Nombre = "Seleccione";
                    regInicio.Provincias = new List<Entidad.Provincia>();
                    lista.Insert(0, regInicio);
                }
                

                lista2 = lista.Cast<VCFramework.Entidad.Region>().ToList();
            }
            //ahora procesamos la lista para agregar las provincias
            if (lista2 != null && lista2.Count > 0)
            {
                foreach(Entidad.Region reg in lista2)
                {
                    if (reg.Id > 0)
                    {
                        reg.Provincias = new List<Entidad.Provincia>();
                        reg.Provincias = Negocio.Provincia.ListarPorRegion(reg.Id);
                    }
                }
            }

            return lista2;
        }
        public static VCFramework.Entidad.Region ObtenerPorId(int id)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Region> lista2 = new List<VCFramework.Entidad.Region>();
            VCFramework.Entidad.Region entidad = new Entidad.Region();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = id.ToString();

            List<object> lista = fac.Leer<VCFramework.Entidad.Region>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Region>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                lista2[0].Provincias = new List<Entidad.Provincia>();
                lista2[0].Provincias = Negocio.Provincia.ListarPorRegion(lista2[0].Id);
                entidad = lista2[0];
            }

            return entidad;
        }
    }
}
