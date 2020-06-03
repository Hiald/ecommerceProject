using MySql.Data.MySqlClient;
using System;
using backendAD;
using backendED;

namespace backendTD
{
    public class tdVendedor : td_ageneral
    {
        adVendedor iadVendedor;

        public int tdValidarCorreo(string tdcorreo)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadVendedor = new adVendedor(con);
                    iresultado = iadVendedor.adValidarCorreo(tdcorreo);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdAccesoVendedor(string tdcorreo, string tdclave)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadVendedor = new adVendedor(con);
                    iresultado = iadVendedor.adAccesoVendedor(tdcorreo, tdclave);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edUsuario tdListarVendedor(int tdidusuario)
        {
            try
            {
                edUsuario oenusuario = new edUsuario();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadVendedor = new adVendedor(con);
                    oenusuario = iadVendedor.adListarVendedor(tdidusuario);
                }
                return oenusuario;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarVendedor(string tdnombre, string tdapellido, string tdcelular, string tdcorreo, string tdclave)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadVendedor = new adVendedor(con);
                    iresultado = iadVendedor.adRegistrarVendedor(tdnombre, tdapellido, tdcelular, tdcorreo, tdclave);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarSesionVendedor(int tdvendedorid, string tddireccionip, string tddireccionmac, int tdtipoconexion)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadVendedor = new adVendedor(con);
                    iresultado = iadVendedor.adRegistrarSesionVendedor(tdvendedorid, tddireccionip, tddireccionmac, tdtipoconexion);
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
