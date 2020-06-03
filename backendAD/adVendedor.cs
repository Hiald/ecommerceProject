using MySql.Data.MySqlClient;
using System;
using System.Data;
using backendED;

namespace backendAD
{
    public class adVendedor : ad_global
    {
        public adVendedor(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public int adValidarCorreo(string adcorreo)
        {
            try
            {
                int result = -2;
                using (MySqlCommand cmd = new MySqlCommand("s_vendedor_validarcorreo", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pCorreoData", MySqlDbType.VarChar, 150).Value = adcorreo;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_result = mdrd.GetOrdinal("_result");
                            while (mdrd.Read())
                            {
                                result = (mdrd.IsDBNull(pos_result) ? 0 : mdrd.GetInt16(pos_result));
                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adAccesoVendedor(string adcorreo, string adclave)
        {
            try
            {
                int result = -2;
                using (MySqlCommand cmd = new MySqlCommand("s_proveedor_acceso", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pCorreoData", MySqlDbType.VarChar, 150).Value = adcorreo;
                    cmd.Parameters.Add("@_pClaveData", MySqlDbType.VarChar, 50).Value = adclave;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_result = mdrd.GetOrdinal("_result");
                            while (mdrd.Read())
                            {
                                result = (mdrd.IsDBNull(pos_result) ? 0 : mdrd.GetInt16(pos_result));
                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edUsuario adListarVendedor(int advendedorid)
        {
            try
            {
                edUsuario senUsuario = null;
                using (MySqlCommand cmd = new MySqlCommand("s_vendedor_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pVendedorId", MySqlDbType.Int32).Value = advendedorid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_vendedorid = mdrd.GetOrdinal("vendedor_id");
                            int pos_nombredata = mdrd.GetOrdinal("nombre_data");
                            int pos_apellidodata = mdrd.GetOrdinal("apellido_data");
                            int pos_fechregdate = mdrd.GetOrdinal("fechareg_date");
                            int pos_activotype = mdrd.GetOrdinal("activo_type");
                            int pos_nombrecompletodata = mdrd.GetOrdinal("nombrecompleto_data");
                            int pos_correodata = mdrd.GetOrdinal("correo_data");
                            while (mdrd.Read())
                            {
                                senUsuario = new edUsuario();
                                senUsuario.vendedorid = (mdrd.IsDBNull(pos_vendedorid) ? 0 : mdrd.GetInt32(pos_vendedorid));
                                senUsuario.snombre = (mdrd.IsDBNull(pos_nombredata) ? "-" : mdrd.GetString(pos_nombredata));
                                senUsuario.sapellido = (mdrd.IsDBNull(pos_apellidodata) ? "-" : mdrd.GetString(pos_apellidodata));
                                senUsuario.sfecha_registro = (mdrd.IsDBNull(pos_fechregdate) ? "-" : mdrd.GetString(pos_fechregdate));
                                senUsuario.iactivo = (mdrd.IsDBNull(pos_activotype) ? 0 : mdrd.GetInt32(pos_activotype));
                                senUsuario.snombrelargo = (mdrd.IsDBNull(pos_nombrecompletodata) ? "-" : mdrd.GetString(pos_nombrecompletodata));
                                senUsuario.scorreo = (mdrd.IsDBNull(pos_correodata) ? "-" : mdrd.GetString(pos_correodata));
                            }
                        }
                    }
                    return senUsuario;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adRegistrarVendedor(string adnombre, string adapellido, string adcelular, string adcorreo, string adclave)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_vendedor_registrar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pNombreData", MySqlDbType.VarChar, 150).Value = adnombre;
                cmd.Parameters.Add("@_pApellidoData", MySqlDbType.VarChar, 150).Value = adapellido;
                cmd.Parameters.Add("@_pCelular1Data", MySqlDbType.VarChar, 15).Value = adcelular;
                cmd.Parameters.Add("@_pCorreoData", MySqlDbType.VarChar, 150).Value = adcorreo;
                cmd.Parameters.Add("@_pClaveData", MySqlDbType.VarChar, 50).Value = adclave;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adRegistrarSesionVendedor(int advendedorid, string addireccionip, string addireccionmac, int adtipoconexion)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("s_historial_vendedor_insertar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pvendedor_id", MySqlDbType.Int32).Value = advendedorid;
                cmd.Parameters.Add("@_pdireccionip_data", MySqlDbType.VarChar, 250).Value = addireccionip;
                cmd.Parameters.Add("@_pdireccionmac_data", MySqlDbType.VarChar, 150).Value = addireccionmac;
                cmd.Parameters.Add("@_pconexion_type", MySqlDbType.Int16).Value = adtipoconexion;

                result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

    }
}
