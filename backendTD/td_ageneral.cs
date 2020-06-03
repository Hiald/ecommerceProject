using System;
using System.Configuration;

namespace backendTD
{
    public class td_ageneral
    {
        public String mysqlConexion { get; set; }

        public td_ageneral()
        {
            mysqlConexion = ConfigurationManager.ConnectionStrings["cnMysql"].ConnectionString;
        }
    }
}
