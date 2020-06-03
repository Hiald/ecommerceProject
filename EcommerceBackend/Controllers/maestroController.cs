using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using backendED;
using backendTD;

namespace EcommerceBackend.Controllers
{
    public class maestroController : ApiController
    {
        tdMaestro itdMaestro;

        [HttpGet]
        public string APIMaestroListar(int wsmaestroid)
        {
            try
            {
                List<edMaestro> loenmaestro = new List<edMaestro>();
                itdMaestro = new tdMaestro();
                loenmaestro = itdMaestro.tdMaestroListar(wsmaestroid);
                return JsonConvert.SerializeObject(loenmaestro);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }
    }
}