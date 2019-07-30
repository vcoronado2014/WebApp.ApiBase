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
    public class RegionesController : ApiController
    {
        [AcceptVerbs("OPTIONS")]
        public void Options()
        { }
        [System.Web.Http.AcceptVerbs("POST")]
        public HttpResponseMessage Post(dynamic DynamicClass)
        {

            string Input = JsonConvert.SerializeObject(DynamicClass);

            dynamic data = JObject.Parse(Input);
            string traeSeleccioneStr = "";
            string idStr = "";
            bool traeSeleccione = false;

            //validaciones antes de ejecutar la llamada.
            if (data.TraeSeleccione != null)
                traeSeleccioneStr = data.TraeSeleccione;
            if (data.Id != null)
                idStr = data.Id;
            if (traeSeleccioneStr != "")
                traeSeleccione = Convert.ToBoolean(traeSeleccioneStr);


            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                if (idStr != "")
                {
                    VCFramework.Entidad.Region regiones = VCFramework.Negocio.Region.ObtenerPorId(int.Parse(idStr));
                    if (regiones != null && regiones.Id > 0)
                    {
                        httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        String JSON = JsonConvert.SerializeObject(regiones);
                        httpResponse.Content = new StringContent(JSON);
                        httpResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(VCFramework.Negocio.Utiles.JSON_DOCTYPE);
                    }
                    else
                    {
                        httpResponse = new HttpResponseMessage(HttpStatusCode.NoContent);
                    }
                }
                else
                {
                    List<VCFramework.Entidad.Region> regiones = VCFramework.Negocio.Region.ListarRegiones(traeSeleccione);
                    if (regiones != null && regiones.Count > 0)
                    {
                        httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        String JSON = JsonConvert.SerializeObject(regiones);
                        httpResponse.Content = new StringContent(JSON);
                        httpResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(VCFramework.Negocio.Utiles.JSON_DOCTYPE);
                    }
                    else
                    {
                        httpResponse = new HttpResponseMessage(HttpStatusCode.NoContent);
                    }
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