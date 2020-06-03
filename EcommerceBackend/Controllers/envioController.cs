using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using backendED;
using backendTD;

namespace EcommerceBackend.Controllers
{
    public class envioController : ApiController
    {
        tdEnvio itdEnvio;

        [HttpGet]
        public string APIListarEnvio(int wsvendedorid)
        {
            try
            {
                List<edEnvio> loenEnvio = new List<edEnvio>();
                itdEnvio = new tdEnvio();
                loenEnvio = itdEnvio.tdListarEnvio(wsvendedorid);
                return JsonConvert.SerializeObject(loenEnvio);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        public int APIRegistrarEnvio(int wsusuarioid, int wsventaid, int wsvendedorid, Int16 wsentregadoTipo, Int16 wsestadoEnvio,
                                    string wsdireccion, string wsnumero, int wsestadoProvincia, int wsciudad, string wsfechaEntrega
                                    , string wshoraEntrega)
        {
            try
            {
                int iresutado = -2;
                itdEnvio = new tdEnvio();
                iresutado = itdEnvio.tdRegistrarEnvio(wsusuarioid, wsventaid, wsvendedorid, wsentregadoTipo, wsestadoEnvio,
                                                    wsdireccion, wsnumero, wsestadoProvincia, wsciudad, wsfechaEntrega, wshoraEntrega);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIActualizarEnvio(int wsenvioid, Int16 wsentregadoTipo, Int16 wsestadoEnvio, string wsfechaEntrega
                                    , string wshoraEntrega, string wsfechaModificacion)
        {
            try
            {
                int iresutado = -2;
                itdEnvio = new tdEnvio();
                iresutado = itdEnvio.tdActualizarEnvio(wsenvioid, wsentregadoTipo, wsestadoEnvio, wsfechaEntrega
                                                    , wshoraEntrega, wsfechaModificacion);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

    }
}