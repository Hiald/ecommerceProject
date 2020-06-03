using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using backendED;

namespace backendAD
{
    public class adMaestro : ad_global
    {
        public adMaestro(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public List<edMaestro> adMaestroListar(int admaestroid)
        {
            try
            {
                List<edMaestro> loenmaestro = new List<edMaestro>();

                using (MySqlCommand cmd = new MySqlCommand("s_maestro_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pMaestroId", MySqlDbType.Int32).Value = admaestroid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edMaestro oenmaestro = null;
                            int pos_maestroid = mdrd.GetOrdinal("maestro_id");
                            int pos_nombredata = mdrd.GetOrdinal("nombre_data");
                            int pos_submaestroid = mdrd.GetOrdinal("submaestro_id");
                            int pos_submaestrodata = mdrd.GetOrdinal("submaestro_data");
                            int pos_submaestrodesc = mdrd.GetOrdinal("submaestro_desc");
                            int pos_fecharegistrodate = mdrd.GetOrdinal("fechareg_date");
                            int pos_activotype = mdrd.GetOrdinal("activo_type");

                            while (mdrd.Read())
                            {
                                oenmaestro = new edMaestro();
                                oenmaestro.maestroid = (mdrd.IsDBNull(pos_maestroid) ? 0 : mdrd.GetInt32(pos_maestroid));
                                oenmaestro.snombre = (mdrd.IsDBNull(pos_nombredata) ? "-" : mdrd.GetString(pos_nombredata));
                                oenmaestro.submaestroid = (mdrd.IsDBNull(pos_submaestroid) ? 0 : mdrd.GetInt32(pos_submaestroid));
                                oenmaestro.snombresub = (mdrd.IsDBNull(pos_submaestrodata) ? "-" : mdrd.GetString(pos_submaestrodata));
                                oenmaestro.sdescripcionsub = (mdrd.IsDBNull(pos_submaestrodesc) ? "-" : mdrd.GetString(pos_submaestrodesc));
                                oenmaestro.sfechareg = (mdrd.IsDBNull(pos_fecharegistrodate) ? "-" : mdrd.GetString(pos_fecharegistrodate));
                                oenmaestro.iactivo = (mdrd.IsDBNull(pos_activotype) ? 0 : mdrd.GetInt16(pos_activotype));
                                loenmaestro.Add(oenmaestro);
                            }
                        }
                    }
                    return loenmaestro;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
