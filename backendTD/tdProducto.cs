using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using backendAD;
using backendED;

namespace backendTD
{
    public class tdProducto : td_ageneral
    {
        adProducto iadproducto;

        public List<edProducto> tdBuscarProducto(int tdtipofiltro, string tdnombre, Int16 tdcategoria)
        {
            try
            {
                List<edProducto> loenproducto = new List<edProducto>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    loenproducto = iadproducto.adBuscarProducto(tdtipofiltro, tdnombre, tdcategoria);
                }
                return loenproducto;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edProducto> tdListarProducto(int tdvendedorid)
        {
            try
            {
                List<edProducto> loenproducto = new List<edProducto>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    loenproducto = iadproducto.adListarProducto(tdvendedorid);
                }
                return loenproducto;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edProducto tdListarProductoDetalle(int tdtipromocion, int tdproductoid)
        {
            try
            {
                edProducto loenproducto = new edProducto();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    loenproducto = iadproducto.adListarProductoDetalle(tdtipromocion, tdproductoid);
                }
                return loenproducto;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }


        public int tdRegistrarProducto(int tdvendedorid, Int16 tdcategoria_type, string tdnombre, string tddescripcion, decimal tdprecio
                                    , string tdimagen1, string tdimagen2, string tdimagen3, string tdimagen4, string tdimagen5, string tdfechareg)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    iresultado = iadproducto.adRegistrarProducto(tdvendedorid, tdcategoria_type, tdnombre, tddescripcion, tdprecio
                                                                , tdimagen1, tdimagen2, tdimagen3, tdimagen4, tdimagen5, tdfechareg);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdActualizarProducto(int tdproducto_id, int tdmarca, Int16 tdcategoria, string tdnombre, string tddescripcion
                                    , string tdmaterial, decimal tdprecio, string tdmodelo, string tdmedida, string tdimagen1
                                    , string tdimagen2, string tdimagen3, string tdimagen4, string tdimagen5, decimal tdpeso
                                    , string tdfechamod, Int16 tdmodificado)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    iresultado = iadproducto.adActualizarProducto(tdproducto_id, tdmarca, tdcategoria, tdnombre, tddescripcion
                                    , tdmaterial, tdprecio, tdmodelo, tdmedida, tdimagen1, tdimagen2, tdimagen3, tdimagen4
                                    , tdimagen5, tdpeso, tdfechamod, tdmodificado);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdEliminarProducto(int tdproductoid)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    iresultado = iadproducto.adEliminarProducto(tdproductoid);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edProducto> tdListarProductoVendedor(string tdnombre, int tdNumeroPagina, int tdCantidadMostrar)
        {
            try
            {
                List<edProducto> loenproducto = new List<edProducto>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    loenproducto = iadproducto.adListarProductoVendedor(tdnombre, tdNumeroPagina, tdCantidadMostrar);
                }
                return loenproducto;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edProducto tdEditarProductoVendedor(int tdproductoid)
        {
            try
            {
                edProducto loenproducto = new edProducto();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    loenproducto = iadproducto.adEditarProductoVendedor(tdproductoid);
                }
                return loenproducto;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdActivarPromocionProducto(int tdproductoid, decimal tdprecio, Int16 tdtipopromocion, decimal tdpreciopromocion
                                            , string tdfechainipromocion, string tdfechafinpromocion)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadproducto = new adProducto(con);
                    iresultado = iadproducto.adActivarPromocionProducto(tdproductoid, tdprecio, tdtipopromocion
                                                                    , tdpreciopromocion, tdfechainipromocion, tdfechafinpromocion);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }


    }
}
