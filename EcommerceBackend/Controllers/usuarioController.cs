using Newtonsoft.Json;
using System;
using System.Web.Http;
using backendED;
using backendTD;

namespace EcommerceBackend.Controllers
{
    public class usuarioController : ApiController
    {
        tdUsuario itdusuario;

        [HttpGet]
        public int APIValidarCorreo(string wscorreo)
        {
            try
            {
                int iresutado = -2;
                itdusuario = new tdUsuario();
                iresutado = itdusuario.tdValidarCorreo(wscorreo);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIAccesoUsuario(string wscorreo, string wsclave)
        {
            try
            {
                int iresutado = -2;
                itdusuario = new tdUsuario();
                iresutado = itdusuario.tdAccesoUsuario(wscorreo, wsclave);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public string APIListarUsuario(int wsusuarioid)
        {
            try
            {
                edUsuario oenusuario = new edUsuario();
                itdusuario = new tdUsuario();
                oenusuario = itdusuario.tdListarUsuario(wsusuarioid);
                return JsonConvert.SerializeObject(oenusuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIRegistrarUsuario(string wsnombre, string wsapellido, string wscorreo, string wsclave)
        {
            try
            {
                int iresutado = -2;
                itdusuario = new tdUsuario();
                iresutado = itdusuario.tdRegistrarUsuario(wsnombre, wsapellido, wscorreo, wsclave);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIRegistrarSesionUsuario(int wsusuarioid, string wsdireccionip, string wsdireccionmac, int wstipoconexion)
        {
            try
            {
                int iresutado = -2;
                itdusuario = new tdUsuario();
                iresutado = itdusuario.tdRegistrarSesionUsuario(wsusuarioid, wsdireccionip, wsdireccionmac, wstipoconexion);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

    }
}