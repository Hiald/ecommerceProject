using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using backendAD;
using backendED;

namespace backendTD
{
    public class tdMaestro : td_ageneral
    {
        adMaestro iadmestro;

        public List<edMaestro> tdMaestroListar(int admaestroid)
        {
            try
            {
                List<edMaestro> loenmaestro = new List<edMaestro>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadmestro = new adMaestro(con);
                    loenmaestro = iadmestro.adMaestroListar(admaestroid);
                }
                return loenmaestro;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
