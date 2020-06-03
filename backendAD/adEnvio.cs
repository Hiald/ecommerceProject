using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using backendED;

namespace backendAD
{
    public class adEnvio : ad_global
    {
        public adEnvio(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public List<edEnvio> adListarEnvio(int advendedorid)
        {
            try
            {
                List<edEnvio> loenventa = new List<edEnvio>();

                using (MySqlCommand cmd = new MySqlCommand("s_envio_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pvendedorid", MySqlDbType.Int32).Value = advendedorid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edEnvio oenenvio = null;
                            int pos_envioid = mdrd.GetOrdinal("envio_id");
                            int pos_usuariodata = mdrd.GetOrdinal("usuario_data");
                            int pos_usuarioid = mdrd.GetOrdinal("usuario_id");
                            int pos_vendedorid = mdrd.GetOrdinal("vendedor_id");
                            int pos_vendedordata = mdrd.GetOrdinal("vendedor_data");
                            int pos_ventaid = mdrd.GetOrdinal("venta_id");
                            int pos_entregadotype = mdrd.GetOrdinal("entregado_type");
                            int pos_estadoenviotype = mdrd.GetOrdinal("estado_envio_type");
                            int pos_direcciondesc = mdrd.GetOrdinal("direccion_desc");
                            int pos_numerodata = mdrd.GetOrdinal("numero_data");
                            int pos_estadoprovinciaregionnum = mdrd.GetOrdinal("estado_provincia_region_num");
                            int pos_ciudadnum = mdrd.GetOrdinal("ciudad_num");
                            int pos_fechaentregadate = mdrd.GetOrdinal("fecha_entrega_date");
                            int pos_horaentrega = mdrd.GetOrdinal("hora_entrega");
                            int pos_activotype = mdrd.GetOrdinal("activo_type");
                            int pos_fecharegdate = mdrd.GetOrdinal("fechareg_date");

                            while (mdrd.Read())
                            {
                                oenenvio = new edEnvio();
                                oenenvio.envioid = (mdrd.IsDBNull(pos_envioid) ? 0 : mdrd.GetInt32(pos_envioid));
                                oenenvio.susuarioNombre = (mdrd.IsDBNull(pos_usuariodata) ? "-" : mdrd.GetString(pos_usuariodata));
                                oenenvio.usuarioid = (mdrd.IsDBNull(pos_usuarioid) ? 0 : mdrd.GetInt32(pos_usuarioid));
                                oenenvio.vendedorid = (mdrd.IsDBNull(pos_vendedorid) ? 0 : mdrd.GetInt32(pos_vendedorid));
                                oenenvio.svendedorNombre = (mdrd.IsDBNull(pos_vendedordata) ? "-" : mdrd.GetString(pos_vendedordata));
                                oenenvio.ventaid = (mdrd.IsDBNull(pos_ventaid) ? 0 : mdrd.GetInt32(pos_ventaid));
                                oenenvio.sentregado_type = (mdrd.IsDBNull(pos_entregadotype) ? "-" : mdrd.GetString(pos_entregadotype));
                                oenenvio.sestado_envio_type = (mdrd.IsDBNull(pos_estadoenviotype) ? "-" : mdrd.GetString(pos_estadoenviotype));
                                oenenvio.sdireccion_desc = (mdrd.IsDBNull(pos_direcciondesc) ? "-" : mdrd.GetString(pos_direcciondesc));
                                oenenvio.snumero_data = (mdrd.IsDBNull(pos_numerodata) ? "-" : mdrd.GetString(pos_numerodata));
                                oenenvio.iestado_provincia_region_num = (mdrd.IsDBNull(pos_estadoprovinciaregionnum) ? 0 : mdrd.GetInt32(pos_estadoprovinciaregionnum));
                                oenenvio.iciudad_num = (mdrd.IsDBNull(pos_ciudadnum) ? 0 : mdrd.GetInt16(pos_ciudadnum));
                                oenenvio.sfecha_entrega_date = (mdrd.IsDBNull(pos_fechaentregadate) ? "-" : mdrd.GetString(pos_fechaentregadate));
                                oenenvio.hora_entrega = (mdrd.IsDBNull(pos_horaentrega) ? "-" : mdrd.GetString(pos_horaentrega));
                                oenenvio.iactivo = (mdrd.IsDBNull(pos_activotype) ? 0 : mdrd.GetInt16(pos_activotype));
                                oenenvio.sfechareg = (mdrd.IsDBNull(pos_fecharegdate) ? 0 : mdrd.GetInt16(pos_fecharegdate));
                                loenventa.Add(oenenvio);
                            }
                        }
                    }
                    return loenventa;
                }
            }
            catch (Exception ex)
            {
                //  UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adRegistrarEnvio(int adusuarioid, int adventaid, int advendedorid, Int16 adentregadoTipo, Int16 adestadoEnvio,
                                    string addireccion, string adnumero, int adestadoProvincia, int adciudad, string adfechaEntrega
                                    , string adhoraEntrega)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_envio_registrar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pusuario_id", MySqlDbType.Int32).Value = adusuarioid;
                cmd.Parameters.Add("@_pventa_id", MySqlDbType.Int32).Value = adventaid;
                cmd.Parameters.Add("@_pvendedor_id", MySqlDbType.Int32).Value = advendedorid;
                cmd.Parameters.Add("@_pentregado_type", MySqlDbType.Int16).Value = adentregadoTipo;
                cmd.Parameters.Add("@_pestado_envio_type", MySqlDbType.Int16).Value = adestadoEnvio;
                cmd.Parameters.Add("@_pdireccion_desc", MySqlDbType.VarChar, 250).Value = addireccion;
                cmd.Parameters.Add("@_pnumero_data", MySqlDbType.VarChar, 25).Value = adnumero;
                cmd.Parameters.Add("@_pestado_provincia_region_num", MySqlDbType.Int32).Value = adestadoProvincia;
                cmd.Parameters.Add("@_ciudad_num", MySqlDbType.Int32).Value = adciudad;
                cmd.Parameters.Add("@_pfecha_entrega_date", MySqlDbType.VarChar, 25).Value = adfechaEntrega;
                cmd.Parameters.Add("@_phora_entrega", MySqlDbType.VarChar, 25).Value = adhoraEntrega;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adActualizarEnvio(int adenvioid, Int16 adentregadoTipo, Int16 adestadoEnvio, string adfechaEntrega
                                    , string adhoraEntrega, string adfechaModificacion)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_envio_actualizar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pidenvio", MySqlDbType.Int32).Value = adenvioid;
                cmd.Parameters.Add("@_pentregado_type", MySqlDbType.Int16).Value = adentregadoTipo;
                cmd.Parameters.Add("@_pestado_envio_type", MySqlDbType.Int16).Value = adestadoEnvio;
                cmd.Parameters.Add("@_pfecha_entrega_date", MySqlDbType.VarChar, 25).Value = adfechaEntrega;
                cmd.Parameters.Add("@_phora_entrega", MySqlDbType.VarChar, 25).Value = adhoraEntrega;
                cmd.Parameters.Add("@_pfechamod_date", MySqlDbType.VarChar, 25).Value = adfechaModificacion;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
