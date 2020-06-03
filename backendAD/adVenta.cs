using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using backendED;

namespace backendAD
{
    public class adVenta : ad_global
    {
        public adVenta(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public List<edVenta> adListarVenta(int adusuarioid)
        {
            try
            {
                List<edVenta> loenventa = new List<edVenta>();

                using (MySqlCommand cmd = new MySqlCommand("s_venta_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pUsuarioId", MySqlDbType.Int32).Value = adusuarioid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edVenta oenventa = null;
                            int pos_vendedorid = mdrd.GetOrdinal("vendedor_id");
                            int pos_ventaid = mdrd.GetOrdinal("venta_id");
                            int pos_usuarioid = mdrd.GetOrdinal("usuario_id");
                            int pos_montodec = mdrd.GetOrdinal("monto_dec");
                            int pos_igvdec = mdrd.GetOrdinal("igv_dec");
                            int pos_totaldec = mdrd.GetOrdinal("total_dec");
                            int pos_ventatype = mdrd.GetOrdinal("venta_type");
                            int pos_pagodesc = mdrd.GetOrdinal("pago_desc");
                            int pos_comisiondec = mdrd.GetOrdinal("comision_dec");
                            int pos_observaciondesc = mdrd.GetOrdinal("observacion_desc");
                            int pos_pagotype = mdrd.GetOrdinal("pago_type");
                            int pos_fecharegdate = mdrd.GetOrdinal("fechareg_date");
                            int pos_activotype = mdrd.GetOrdinal("activo_type");

                            while (mdrd.Read())
                            {
                                oenventa = new edVenta();
                                oenventa.vendedorid = (mdrd.IsDBNull(pos_vendedorid) ? 0 : mdrd.GetInt32(pos_vendedorid));
                                oenventa.ventaid = (mdrd.IsDBNull(pos_ventaid) ? 0 : mdrd.GetInt32(pos_ventaid));
                                oenventa.usuarioid = (mdrd.IsDBNull(pos_usuarioid) ? 0 : mdrd.GetInt32(pos_usuarioid));
                                oenventa.dmonto = (mdrd.IsDBNull(pos_montodec) ? 0 : mdrd.GetDecimal(pos_montodec));
                                oenventa.digv = (mdrd.IsDBNull(pos_igvdec) ? 0 : mdrd.GetInt32(pos_igvdec));
                                oenventa.dtotal = (mdrd.IsDBNull(pos_totaldec) ? 0 : mdrd.GetDecimal(pos_totaldec));
                                oenventa.stipoventa = (mdrd.IsDBNull(pos_ventatype) ? "-" : mdrd.GetString(pos_ventatype));
                                oenventa.spagodescripcion = (mdrd.IsDBNull(pos_pagodesc) ? "-" : mdrd.GetString(pos_pagodesc));
                                oenventa.dcomision = (mdrd.IsDBNull(pos_comisiondec) ? 0 : mdrd.GetInt16(pos_comisiondec));
                                oenventa.sobservacion = (mdrd.IsDBNull(pos_observaciondesc) ? "-" : mdrd.GetString(pos_observaciondesc));
                                oenventa.stipopago = (mdrd.IsDBNull(pos_pagotype) ? "-" : mdrd.GetString(pos_pagotype));
                                oenventa.sfecha_registro = (mdrd.IsDBNull(pos_fecharegdate) ? "-" : mdrd.GetString(pos_fecharegdate));
                                oenventa.iactivo = (mdrd.IsDBNull(pos_activotype) ? 0 : mdrd.GetInt16(pos_activotype));
                                loenventa.Add(oenventa);
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

        public int adRegistrarValoracion(int advendedorid, int adusuarioid, string adventaid, int adpuntaje, string advaloracion)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_valoracion_vendedor_registrar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pVendedorId", MySqlDbType.Int32).Value = advendedorid;
                cmd.Parameters.Add("@_pUsuarioId", MySqlDbType.Int32).Value = adusuarioid;
                cmd.Parameters.Add("@_pVentaId", MySqlDbType.Int32).Value = adventaid;
                cmd.Parameters.Add("@_pPuntajeNum", MySqlDbType.Int32).Value = adpuntaje;
                cmd.Parameters.Add("@_pValoracionDesc", MySqlDbType.VarChar, 250).Value = advaloracion;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        // ---------------- vendedor ---------------------
        public List<edVenta> adListarVentaVendedor(int advendedorid)
        {
            try
            {
                List<edVenta> loenventa = new List<edVenta>();

                using (MySqlCommand cmd = new MySqlCommand("s_venta_listar_vendedor", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pvendedor_id", MySqlDbType.Int32).Value = advendedorid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edVenta oenventa = null;
                            int pos_vendedorid = mdrd.GetOrdinal("vendedor_data");
                            int pos_ventaid = mdrd.GetOrdinal("venta_id");
                            int pos_usuariodata = mdrd.GetOrdinal("usuario_data");
                            int pos_montodec = mdrd.GetOrdinal("monto_dec");
                            int pos_igvdec = mdrd.GetOrdinal("igv_dec");
                            int pos_totaldec = mdrd.GetOrdinal("total_dec");
                            int pos_ventatype = mdrd.GetOrdinal("venta_type");
                            int pos_pagodesc = mdrd.GetOrdinal("pago_desc");
                            int pos_comisiondec = mdrd.GetOrdinal("comision_dec");
                            int pos_observaciondesc = mdrd.GetOrdinal("observacion_desc");
                            int pos_pagotype = mdrd.GetOrdinal("pago_type");
                            int pos_fecharegdate = mdrd.GetOrdinal("fechareg_date");
                            int pos_activotype = mdrd.GetOrdinal("activo_type");

                            while (mdrd.Read())
                            {
                                oenventa = new edVenta();
                                oenventa.vendedorid = (mdrd.IsDBNull(pos_vendedorid) ? 0 : mdrd.GetInt32(pos_vendedorid));
                                oenventa.ventaid = (mdrd.IsDBNull(pos_ventaid) ? 0 : mdrd.GetInt32(pos_ventaid));
                                oenventa.susuarioNombre = (mdrd.IsDBNull(pos_usuariodata) ? "-" : mdrd.GetString(pos_usuariodata));
                                oenventa.dmonto = (mdrd.IsDBNull(pos_montodec) ? 0 : mdrd.GetDecimal(pos_montodec));
                                oenventa.digv = (mdrd.IsDBNull(pos_igvdec) ? 0 : mdrd.GetInt32(pos_igvdec));
                                oenventa.dtotal = (mdrd.IsDBNull(pos_totaldec) ? 0 : mdrd.GetDecimal(pos_totaldec));
                                oenventa.stipoventa = (mdrd.IsDBNull(pos_ventatype) ? "-" : mdrd.GetString(pos_ventatype));
                                oenventa.spagodescripcion = (mdrd.IsDBNull(pos_pagodesc) ? "-" : mdrd.GetString(pos_pagodesc));
                                oenventa.dcomision = (mdrd.IsDBNull(pos_comisiondec) ? 0 : mdrd.GetInt16(pos_comisiondec));
                                oenventa.sobservacion = (mdrd.IsDBNull(pos_observaciondesc) ? "-" : mdrd.GetString(pos_observaciondesc));
                                oenventa.stipopago = (mdrd.IsDBNull(pos_pagotype) ? "-" : mdrd.GetString(pos_pagotype));
                                oenventa.sfecha_registro = (mdrd.IsDBNull(pos_fecharegdate) ? "-" : mdrd.GetString(pos_fecharegdate));
                                oenventa.iactivo = (mdrd.IsDBNull(pos_activotype) ? 0 : mdrd.GetInt16(pos_activotype));
                                loenventa.Add(oenventa);
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

        public int adRegistrarVenta(int advendedorid, int adusuarioid, decimal admonto, decimal adigv, decimal adtotal,
             Int16 aditipoventa, Int16 aditipopago, string adpagodescripcion, decimal adcomision, string adobservacion, string adfecharegistro)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_venta_registrar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pvendedor_id", MySqlDbType.Int32).Value = advendedorid;
                cmd.Parameters.Add("@_pusuario_id", MySqlDbType.Int32).Value = adusuarioid;
                cmd.Parameters.Add("@_pmonto_dec", MySqlDbType.Decimal).Value = admonto;
                cmd.Parameters.Add("@_pigv_dec", MySqlDbType.Decimal).Value = adigv;
                cmd.Parameters.Add("@_ptotal_dec", MySqlDbType.Decimal).Value = adtotal;
                cmd.Parameters.Add("@_pventa_type", MySqlDbType.Int16).Value = aditipoventa;
                cmd.Parameters.Add("@_ppago_type", MySqlDbType.Int16).Value = aditipopago;
                cmd.Parameters.Add("@_ppago_desc", MySqlDbType.VarChar, 250).Value = adpagodescripcion;
                cmd.Parameters.Add("@_pcomision_dec", MySqlDbType.Decimal).Value = adcomision;
                cmd.Parameters.Add("@_pobservacion_desc", MySqlDbType.VarChar, 500).Value = adobservacion;
                cmd.Parameters.Add("@_pfechareg_date", MySqlDbType.VarChar, 25).Value = adfecharegistro;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        // cambia la venta desde pendiente, hasta finalizado
        public int adActualizarVenta(int adventaid, Int16 adventaTipo, string adfechaModificacion)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_venta_actualizar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pventa_id", MySqlDbType.Int32).Value = adventaid;
                cmd.Parameters.Add("@_pventa_type", MySqlDbType.Int16).Value = adventaTipo;
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

        public int adRegistrarSubVenta(int adventaid, int adproductoid, int adcantidad, decimal adsubtotal, string adfechaRegistro)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_subventa_registrar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pventa_id", MySqlDbType.Int32).Value = adventaid;
                cmd.Parameters.Add("@_pproducto_id", MySqlDbType.Int32).Value = adproductoid;
                cmd.Parameters.Add("@_pcantidad_num", MySqlDbType.Int32).Value = adcantidad;
                cmd.Parameters.Add("@_psubtotal_dec", MySqlDbType.Decimal).Value = adsubtotal;
                cmd.Parameters.Add("@_pfechareg_date", MySqlDbType.VarChar, 25).Value = adfechaRegistro;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edVenta> adListarSubVenta(int adventaid)
        {
            try
            {
                List<edVenta> loenventa = new List<edVenta>();

                using (MySqlCommand cmd = new MySqlCommand("s_subventa_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pVentaId", MySqlDbType.Int32).Value = adventaid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edVenta oenventa = null;
                            int pos_ventaid = mdrd.GetOrdinal("venta_id");
                            int pos_subventaid = mdrd.GetOrdinal("subventa_id");
                            int pos_productodata = mdrd.GetOrdinal("producto_data");
                            int pos_cantidadnum = mdrd.GetOrdinal("cantidad_num");
                            int pos_subtotaldec = mdrd.GetOrdinal("subtotal_dec");
                            int pos_fecharegdate = mdrd.GetOrdinal("fechareg_date");
                            int pos_activotype = mdrd.GetOrdinal("activo_type");

                            while (mdrd.Read())
                            {
                                oenventa = new edVenta();
                                oenventa.vendedorid = (mdrd.IsDBNull(pos_ventaid) ? 0 : mdrd.GetInt32(pos_ventaid));
                                oenventa.usuarioid = (mdrd.IsDBNull(pos_subventaid) ? 0 : mdrd.GetInt32(pos_subventaid));
                                oenventa.dmonto = (mdrd.IsDBNull(pos_productodata) ? 0 : mdrd.GetDecimal(pos_productodata));
                                oenventa.digv = (mdrd.IsDBNull(pos_cantidadnum) ? 0 : mdrd.GetDecimal(pos_cantidadnum));
                                oenventa.dtotal = (mdrd.IsDBNull(pos_subtotaldec) ? 0 : mdrd.GetDecimal(pos_subtotaldec));
                                oenventa.stipoventa = (mdrd.IsDBNull(pos_fecharegdate) ? "-" : mdrd.GetString(pos_fecharegdate));
                                oenventa.iactivo = (mdrd.IsDBNull(pos_activotype) ? 0 : mdrd.GetInt16(pos_activotype));
                                loenventa.Add(oenventa);
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

    }
}
