using MySql.Data.MySqlClient;
using System;
using backendAD;
using backendED;

namespace backendTD
{
    public class tdUsuario : td_ageneral
    {
        adUsuario iadusuario;

        public int tdValidarCorreo(string tdcorreo)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadusuario = new adUsuario(con);
                    iresultado = iadusuario.adValidarCorreo(tdcorreo);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdAccesoUsuario(string tdcorreo, string tdclave)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadusuario = new adUsuario(con);
                    iresultado = iadusuario.adAccesoUsuario(tdcorreo, tdclave);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edUsuario tdListarUsuario(int tdidusuario)
        {
            try
            {
                edUsuario oenusuario = new edUsuario();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadusuario = new adUsuario(con);
                    oenusuario = iadusuario.adListarUsuario(tdidusuario);
                }
                return oenusuario;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarUsuario(string tdnombre, string tdapellido, string tdcorreo, string tdclave)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadusuario = new adUsuario(con);
                    iresultado = iadusuario.adRegistrarUsuario(tdnombre, tdapellido, tdcorreo, tdclave);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdRegistrarSesionUsuario(int tdusuarioid, string tddireccionip, string tddireccionmac, int tdtipoconexion)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadusuario = new adUsuario(con);
                    iresultado = iadusuario.adRegistrarSesionUsuario(tdusuarioid, tddireccionip, tddireccionmac, tdtipoconexion);
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
