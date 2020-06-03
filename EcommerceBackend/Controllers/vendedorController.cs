using Newtonsoft.Json;
using System;
using System.Web.Http;
using backendED;
using backendTD;

namespace EcommerceBackend.Controllers
{
    public class vendedorController : ApiController
    {
        tdVendedor itdvendedor;

        [HttpGet]
        public int APIValidarCorreo(string wscorreo)
        {
            try
            {
                int iresutado = -2;
                itdvendedor = new tdVendedor();
                iresutado = itdvendedor.tdValidarCorreo(wscorreo);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIAccesoVendedor(string wscorreo, string wsclave)
        {
            try
            {
                int iresutado = -2;
                itdvendedor = new tdVendedor();
                iresutado = itdvendedor.tdAccesoVendedor(wscorreo, wsclave);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public string APIListarVendedor(int wsvendedorid)
        {
            try
            {
                edUsuario oenusuario = new edUsuario();
                itdvendedor = new tdVendedor();
                oenusuario = itdvendedor.tdListarVendedor(wsvendedorid);
                return JsonConvert.SerializeObject(oenusuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIRegistrarVendedor(string wsnombre, string wsapellido, string wscelular, string wscorreo, string wsclave)
        {
            try
            {
                int iresutado = -2;
                itdvendedor = new tdVendedor();
                iresutado = itdvendedor.tdRegistrarVendedor(wsnombre, wsapellido, wscelular, wscorreo, wsclave);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIRegistrarSesionVendedor(int wsvendedorid, string wsdireccionip, string wsdireccionmac, int wstipoconexion)
        {
            try
            {
                int iresutado = -2;
                itdvendedor = new tdVendedor();
                iresutado = itdvendedor.tdRegistrarSesionVendedor(wsvendedorid, wsdireccionip, wsdireccionmac, wstipoconexion);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

    }
}