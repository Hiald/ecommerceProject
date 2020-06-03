using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using backendAD;
using backendED;

namespace backendTD
{
    public class tdEnvio : td_ageneral
    {
        adEnvio iadEnvio;

        public List<edEnvio> tdListarEnvio(int tdvendedorid)
        {
            try
            {
                List<edEnvio> loenventa = new List<edEnvio>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadEnvio = new adEnvio(con);
                    loenventa = iadEnvio.adListarEnvio(tdvendedorid);
                }
                return loenventa;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarEnvio(int tdusuarioid, int tdventaid, int tdvendedorid, Int16 tdentregadoTipo, Int16 tdestadoEnvio,
                                    string tddireccion, string tdnumero, int tdestadoProvincia, int tdciudad, string tdfechaEntrega
                                    , string tdhoraEntrega)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadEnvio = new adEnvio(con);
                    iresultado = iadEnvio.adRegistrarEnvio(tdusuarioid, tdventaid, tdvendedorid, tdentregadoTipo, tdestadoEnvio,
                                                          tddireccion, tdnumero, tdestadoProvincia, tdciudad, tdfechaEntrega
                                                          , tdhoraEntrega);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdActualizarEnvio(int tdenvioid, Int16 tdentregadoTipo, Int16 tdestadoEnvio, string tdfechaEntrega
                                    , string tdhoraEntrega, string tdfechaModificacion)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadEnvio = new adEnvio(con);
                    iresultado = iadEnvio.adActualizarEnvio(tdenvioid, tdentregadoTipo, tdestadoEnvio, tdfechaEntrega
                                                            , tdhoraEntrega, tdfechaModificacion);
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
