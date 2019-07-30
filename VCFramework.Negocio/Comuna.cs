using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using VCFramework.Negocio.Factory;

namespace VCFramework.Negocio
{
    public class Comuna
    {
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static List<VCFramework.Entidad.Comuna> ListarPorRegion(int regId)
        {
            List<Entidad.Comuna> listaDevolver = new List<Entidad.Comuna>();
            List<VCFramework.Entidad.Provincia> lista2 = Negocio.Provincia.ListarPorRegion(regId);



            if (lista2 != null)
            {
                foreach (Entidad.Provincia prov in lista2)
                {
                    List<Entidad.Comuna> comunas = ListarPorProvincia(prov.Id);
                    if (comunas != null && comunas.Count > 0)
                    {
                        foreach(Entidad.Comuna com in comunas)
                        {
                            listaDevolver.Add(com);
                        }
                    }
                }
                
            }


            return listaDevolver;
        }
        public static List<VCFramework.Entidad.Comuna> ListarPorProvincia(int prvId)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Comuna> lista2 = new List<VCFramework.Entidad.Comuna>();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "PRV_ID";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = prvId.ToString();

            List<object> lista = fac.Leer<VCFramework.Entidad.Comuna>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Comuna>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                lista2 = lista2.FindAll(p => p.Eliminado == 0).ToList();
            }

            return lista2;
        }
        public static VCFramework.Entidad.Comuna ObtenerPorId(int id)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.Comuna> lista2 = new List<VCFramework.Entidad.Comuna>();
            VCFramework.Entidad.Comuna entidad = new Entidad.Comuna();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.TipoDato = TipoDatoGeneral.Entero;
            filtro.Valor = id.ToString();

            List<object> lista = fac.Leer<VCFramework.Entidad.Comuna>(filtro, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.Comuna>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                entidad = lista2[0];
            }

            return entidad;
        }
    }
}
