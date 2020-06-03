using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using backendED;
using backendTD;

namespace EcommerceBackend.Controllers
{
    public class productoController : ApiController
    {
        tdProducto itdProducto;

        [HttpGet]
        public string APIBuscarProducto(int wstipofiltro, string wsnombre, Int16 wscategoria)
        {
            try
            {
                List<edProducto> loenproducto = new List<edProducto>();
                itdProducto = new tdProducto();
                loenproducto = itdProducto.tdBuscarProducto(wstipofiltro, wsnombre, wscategoria);
                return JsonConvert.SerializeObject(loenproducto);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        public string APIListarProducto(int wsvendedorid)
        {
            try
            {
                List<edProducto> loenproducto = new List<edProducto>();
                itdProducto = new tdProducto();
                loenproducto = itdProducto.tdListarProducto(wsvendedorid);
                return JsonConvert.SerializeObject(loenproducto);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        public string APIListarProductoDetalle(int wstipromocion, int wsproductoid)
        {
            try
            {
                edProducto loenproducto = new edProducto();
                itdProducto = new tdProducto();
                loenproducto = itdProducto.tdListarProductoDetalle(wstipromocion, wsproductoid);
                return JsonConvert.SerializeObject(loenproducto);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        //VENDEDOR
        [HttpGet]
        public int APIRegistrarProducto(int wsvendedorid, Int16 wscategoria_type, string wsnombre, string wsdescripcion, decimal wsprecio
                                    , string wsimagen1, string wsimagen2, string wsimagen3, string wsimagen4, string wsimagen5, string wsfechareg)
        {
            try
            {
                int iresutado = -2;
                itdProducto = new tdProducto();
                iresutado = itdProducto.tdRegistrarProducto(wsvendedorid, wscategoria_type, wsnombre, wsdescripcion, wsprecio, wsimagen1
                                                            , wsimagen2, wsimagen3, wsimagen4, wsimagen5, wsfechareg);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIActualizarProducto(int wsproducto_id, int wsmarca, Int16 wscategoria, string wsnombre, string wsdescripcion
                                    , string wsmaterial, decimal wsprecio, string wsmodelo, string wsmedida, string wsimagen1
                                    , string wsimagen2, string wsimagen3, string wsimagen4, string wsimagen5, decimal wspeso
                                    , string wsfechamod, Int16 wsmodificado)
        {
            try
            {
                int iresutado = -2;
                itdProducto = new tdProducto();
                iresutado = itdProducto.tdActualizarProducto(wsproducto_id, wsmarca, wscategoria, wsnombre, wsdescripcion, wsmaterial
                                                            , wsprecio, wsmodelo, wsmedida, wsimagen1, wsimagen2, wsimagen3, wsimagen4
                                                            , wsimagen5, wspeso, wsfechamod, wsmodificado);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIEliminarProducto(int wsproductoid)
        {
            try
            {
                int iresutado = -2;
                itdProducto = new tdProducto();
                iresutado = itdProducto.tdEliminarProducto(wsproductoid);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public string APIListarProductoVendedor(string wsnombre, int wsNumeroPagina, int wsCantidadMostrar)
        {
            try
            {
                List<edProducto> loenproducto = new List<edProducto>();
                itdProducto = new tdProducto();
                loenproducto = itdProducto.tdListarProductoVendedor(wsnombre, wsNumeroPagina, wsCantidadMostrar);
                return JsonConvert.SerializeObject(loenproducto);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        public string APIEditarProductoVendedor(int wsproductoidEditar)
        {
            try
            {
                edProducto loenproducto = new edProducto();
                itdProducto = new tdProducto();
                loenproducto = itdProducto.tdEditarProductoVendedor(wsproductoidEditar);
                return JsonConvert.SerializeObject(loenproducto);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        public int APIActivarPromocionProducto(int wsproductoid, decimal wsprecio, Int16 wstipopromocion, decimal wspreciopromocion
                                                , string wsfechainipromocion, string wsfechafinpromocion)
        {
            try
            {
                int iresultado = -2;
                itdProducto = new tdProducto();
                iresultado = itdProducto.tdActivarPromocionProducto(wsproductoid, wsprecio, wstipopromocion, wspreciopromocion
                                                                    , wsfechainipromocion, wsfechafinpromocion);
                return iresultado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

    }
}