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
    public class ComunasController : ApiController
    {
        [AcceptVerbs("OPTIONS")]
        public void Options()
        { }
        [System.Web.Http.AcceptVerbs("POST")]
        public HttpResponseMessage Post(dynamic DynamicClass)
        {

            string Input = JsonConvert.SerializeObject(DynamicClass);

            dynamic data = JObject.Parse(Input);
            string regIdstr = "";
            string idStr = "";

            //validaciones antes de ejecutar la llamada.
            if (data.RegId != null)
                regIdstr = data.RegId;
            if (data.Id != null)
                idStr = data.Id;


            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                if (idStr != "")
                {
                    VCFramework.Entidad.Comuna comuna = VCFramework.Negocio.Comuna.ObtenerPorId(int.Parse(idStr));
                    if (comuna != null && comuna.Id > 0)
                    {
                        httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        String JSON = JsonConvert.SerializeObject(comuna);
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
                    List<VCFramework.Entidad.Comuna> comunas = VCFramework.Negocio.Comuna.ListarPorRegion(int.Parse(regIdstr));
                    if (comunas != null && comunas.Count > 0)
                    {
                        httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
                        String JSON = JsonConvert.SerializeObject(comunas);
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