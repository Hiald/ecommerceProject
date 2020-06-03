using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using backendED;
using backendTD;

namespace EcommerceBackend.Controllers
{
    public class ventaController : ApiController
    {
        tdVenta itdVenta;

        [HttpGet]
        public string APIListarVenta(int wsusuarioid)
        {
            try
            {
                List<edVenta> loenventa = new List<edVenta>();
                itdVenta = new tdVenta();
                loenventa = itdVenta.tdListarVenta(wsusuarioid);
                return JsonConvert.SerializeObject(loenventa);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        public int APIRegistrarValoracion(int wsvendedorid, int wsusuarioid, string wsventaid, int wspuntaje, string wsvaloracion)
        {
            try
            {
                int iresutado = -2;
                itdVenta = new tdVenta();
                iresutado = itdVenta.tdRegistrarValoracion(wsvendedorid, wsusuarioid, wsventaid, wspuntaje, wsvaloracion);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        // ---------------- vendedor ---------------------

        [HttpGet]
        public string APIListarVentaVendedor(int wsvendedorid)
        {
            try
            {
                List<edVenta> loencarro = new List<edVenta>();
                itdVenta = new tdVenta();
                loencarro = itdVenta.tdListarVentaVendedor(wsvendedorid);
                return JsonConvert.SerializeObject(loencarro);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        public int APIRegistrarVenta(int wsvendedorid, int wsusuarioid, decimal wsmonto, decimal wsigv, decimal wstotal,
                                    Int16 wsitipoventa, Int16 wsitipopago, string wspagodescripcion, decimal wscomision
                                    , string wsobservacion, string wsfecharegistro)
        {
            try
            {
                int iresutado = -2;
                itdVenta = new tdVenta();
                iresutado = itdVenta.tdRegistrarVenta(wsvendedorid, wsusuarioid, wsmonto, wsigv, wstotal,
                                                    wsitipoventa, wsitipopago, wspagodescripcion, wscomision
                                                    , wsobservacion, wsfecharegistro);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIActualizarVenta(int wsventaid, Int16 wsventaTipo, string wsfechaModificacion)
        {
            try
            {
                int iresutado = -2;
                itdVenta = new tdVenta();
                iresutado = itdVenta.tdActualizarVenta(wsventaid, wsventaTipo, wsfechaModificacion);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIRegistrarSubVenta(int wsventaid, int wsproductoid, int wscantidad, decimal wssubtotal, string wsfechaRegistro)
        {
            try
            {
                int iresutado = -2;
                itdVenta = new tdVenta();
                iresutado = itdVenta.tdRegistrarSubVenta(wsventaid, wsproductoid, wscantidad, wssubtotal, wsfechaRegistro);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public string APIListarSubVenta(int wsventaid)
        {
            try
            {
                List<edVenta> loencarro = new List<edVenta>();
                itdVenta = new tdVenta();
                loencarro = itdVenta.tdListarSubVenta(wsventaid);
                return JsonConvert.SerializeObject(loencarro);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

    }
}