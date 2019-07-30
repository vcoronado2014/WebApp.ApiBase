using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VCFramework.Entidad;
using VCFramework.Negocio;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using System.Xml;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;

namespace WebApp.ApiBase.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [AcceptVerbs("OPTIONS")]
        public void Options()
        { }

        [System.Web.Http.AcceptVerbs("POST")]
        public HttpResponseMessage Post(dynamic DynamicClass)
        {

            string Input = JsonConvert.SerializeObject(DynamicClass);

            dynamic data = JObject.Parse(Input);
            string usuario = "";
            string password = "";

            //validaciones antes de ejecutar la llamada.
            if (data.Usuario != null)
                usuario = data.Usuario;
            if (data.Password != null)
                password = data.Password;


            HttpResponseMessage httpResponse = new HttpResponseMessage();
            VCFramework.Entidad.UsuarioEnvoltorio usu = new UsuarioEnvoltorio();
            try
            {

                VCFramework.Entidad.AutentificacionUsuario aus = VCFramework.Negocio.AutentificacionUsuario.ObtenerPorUsuarioPassword(usuario, password);
                if (aus != null && aus.Id > 0)
                {
                    usu.AutentificacionUsuario = new VCFramework.Entidad.AutentificacionUsuario();
                    usu.AutentificacionUsuario = aus;
                    usu.Rol = new VCFramework.Entidad.Rol();
                    usu.Rol = VCFramework.Negocio.Rol.ObtenerPorId(aus.RolId);
                    usu.Persona = new VCFramework.Entidad.Persona();
                    usu.Persona = VCFramework.Negocio.Persona.ObtenerPorAusId(aus.Id);
                    if (usu.Persona != null && usu.Persona.Id > 0)
                    {
                        usu.Region = VCFramework.Negocio.Region.ObtenerPorId(usu.Persona.RegId);
                        usu.Comuna = VCFramework.Negocio.Comuna.ObtenerPorId(usu.Persona.ComId);
                    }
                    httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
                    //retornamos entidad envoletorio
                    String JSON = JsonConvert.SerializeObject(usu);
                    httpResponse.Content = new StringContent(JSON);
                    httpResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(VCFramework.Negocio.Utiles.JSON_DOCTYPE);
                }
                else
                {
                    httpResponse = new HttpResponseMessage(HttpStatusCode.NoContent);
                }


            }
            catch (Exception ex)
            {
                httpResponse = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                throw ex;
            }
            return httpResponse;


        }
    }
}