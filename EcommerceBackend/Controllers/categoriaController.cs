using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using backendED;
using backendTD;

namespace EcommerceBackend.Controllers
{
    public class categoriaController : ApiController
    {
        tdCategoria itdCategoria;

        [HttpGet]
        public int APIAgregarCategoria(string wsnombre, string wsiconoCodigo)
        {
            try
            {
                int iresutado = -2;
                itdCategoria = new tdCategoria();
                iresutado = itdCategoria.tdAgregarCategoria(wsnombre, wsiconoCodigo);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIActualizarCategoria(int wscategoriaid, string wsnombre, string wscodigo)
        {
            try
            {
                int iresutado = -2;
                itdCategoria = new tdCategoria();
                iresutado = itdCategoria.tdActualizarCategoria(wscategoriaid, wsnombre, wscodigo);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public int APIEliminarCategoria(int wscategoriaid)
        {
            try
            {
                int iresutado = -2;
                itdCategoria = new tdCategoria();
                iresutado = itdCategoria.tdEliminarCategoria(wscategoriaid);
                return iresutado;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        [HttpGet]
        public string APIListarCategoria(int wsvalor)
        {
            try
            {
                List<edCategoria> loenproducto = new List<edCategoria>();
                itdCategoria = new tdCategoria();
                loenproducto = itdCategoria.tdListarCategoria();
                return JsonConvert.SerializeObject(loenproducto);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

    }
}