using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using backendAD;
using backendED;

namespace backendTD
{
    public class tdVenta : td_ageneral
    {
        adVenta iadventa;

        public List<edVenta> tdListarVenta(int tdusuarioid)
        {
            try
            {
                List<edVenta> loenventa = new List<edVenta>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadventa = new adVenta(con);
                    loenventa = iadventa.adListarVenta(tdusuarioid);
                }
                return loenventa;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarValoracion(int tdvendedorid, int tdusuarioid, string tdventaid, int tdpuntaje, string tdvaloracion)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadventa = new adVenta(con);
                    iresultado = iadventa.adRegistrarValoracion(tdvendedorid, tdusuarioid, tdventaid, tdpuntaje, tdvaloracion);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        // ---------------- vendedor ---------------------
        public List<edVenta> tdListarVentaVendedor(int tdvendedorid)
        {
            try
            {
                List<edVenta> loenventa = new List<edVenta>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadventa = new adVenta(con);
                    loenventa = iadventa.adListarVentaVendedor(tdvendedorid);
                }
                return loenventa;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarVenta(int tdvendedorid, int tdusuarioid, decimal tdmonto, decimal tdigv, decimal tdtotal,
                                    Int16 tditipoventa, Int16 tditipopago, string tdpagodescripcion, decimal tdcomision
                                    , string tdobservacion, string tdfecharegistro)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadventa = new adVenta(con);
                    iresultado = iadventa.adRegistrarVenta(tdvendedorid, tdusuarioid, tdmonto, tdigv, tdtotal,
                                                           tditipoventa, tditipopago, tdpagodescripcion, tdcomision
                                                          , tdobservacion, tdfecharegistro);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdActualizarVenta(int tdventaid, Int16 tdventaTipo, string tdfechaModificacion)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadventa = new adVenta(con);
                    iresultado = iadventa.adActualizarVenta(tdventaid, tdventaTipo, tdfechaModificacion);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarSubVenta(int tdventaid, int tdproductoid, int tdcantidad, decimal tdsubtotal, string tdfechaRegistro)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadventa = new adVenta(con);
                    iresultado = iadventa.adRegistrarSubVenta(tdventaid, tdproductoid, tdcantidad, tdsubtotal, tdfechaRegistro);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edVenta> tdListarSubVenta(int tdventaid)
        {
            try
            {
                List<edVenta> loenventa = new List<edVenta>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadventa = new adVenta(con);
                    loenventa = iadventa.adListarSubVenta(tdventaid);
                }
                return loenventa;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
