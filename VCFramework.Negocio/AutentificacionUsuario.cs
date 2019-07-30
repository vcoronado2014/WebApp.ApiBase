using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using VCFramework.Negocio.Factory;

namespace VCFramework.Negocio
{
    public class AutentificacionUsuario
    {
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static VCFramework.Entidad.AutentificacionUsuario ObtenerPorUsuarioPassword(string nombreUsuario, string password)
        {
            VCFramework.Negocio.Factory.Factory fac = new VCFramework.Negocio.Factory.Factory();
            List<VCFramework.Entidad.AutentificacionUsuario> lista2 = new List<VCFramework.Entidad.AutentificacionUsuario>();
            VCFramework.Entidad.AutentificacionUsuario entidad = new Entidad.AutentificacionUsuario();
            //agregamos filtros
            VCFramework.Negocio.Factory.FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "NOMBRE_USUARIO";
            filtro.TipoDato = TipoDatoGeneral.Varchar;
            filtro.Valor = nombreUsuario.Trim();

            VCFramework.Negocio.Factory.FiltroGenerico filtro1 = new FiltroGenerico();
            filtro1.Campo = "PASSWORD";
            filtro1.TipoDato = TipoDatoGeneral.Varchar;
            filtro1.Valor =Utiles.Encriptar(password.Trim());

            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            filtros.Add(filtro);
            filtros.Add(filtro1);

            List<object> lista = fac.Leer<VCFramework.Entidad.AutentificacionUsuario>(filtros, setCnsWebLun);


            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.AutentificacionUsuario>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                entidad = lista2[0];
            }

            return entidad;
        }
    }
}
