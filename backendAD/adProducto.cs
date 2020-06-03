using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using backendED;

namespace backendAD
{
    public class adProducto : ad_global
    {
        public adProducto(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public List<edProducto> adBuscarProducto(int adtipofiltro, string adnombre, Int16 adcategoria)
        {
            try
            {
                List<edProducto> loenproducto = new List<edProducto>();

                using (MySqlCommand cmd = new MySqlCommand("s_producto_buscar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pFilterType", MySqlDbType.Int32).Value = adtipofiltro;
                    cmd.Parameters.Add("@_pProducto_data", MySqlDbType.VarChar, 150).Value = adnombre;
                    cmd.Parameters.Add("@_pcategoria_type", MySqlDbType.Int16).Value = adcategoria;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edProducto oenproducto = null;
                            int pos_productoid = mdrd.GetOrdinal("producto_id");
                            int pos_proveedorid = mdrd.GetOrdinal("vendedor_id");
                            int pos_categoriatype = mdrd.GetOrdinal("categoria_type");
                            int pos_productodata = mdrd.GetOrdinal("producto_data");
                            int pos_productodesc = mdrd.GetOrdinal("producto_desc");
                            int pos_preciodec = mdrd.GetOrdinal("precio_dec");
                            int pos_imagen1data = mdrd.GetOrdinal("imagen1_data");
                            int pos_preciopromociondec = mdrd.GetOrdinal("preciopromocion_dec");
                            int pos_promociontype = mdrd.GetOrdinal("promocion_type");
                            int pos_fecinipromdate = mdrd.GetOrdinal("fecha_ini_promocion_date");
                            int pos_fecfinpromdate = mdrd.GetOrdinal("fecha_fin_promocion_date");

                            while (mdrd.Read())
                            {
                                oenproducto = new edProducto();
                                oenproducto.productoid = (mdrd.IsDBNull(pos_productoid) ? 0 : mdrd.GetInt32(pos_productoid));
                                oenproducto.vendedorid = (mdrd.IsDBNull(pos_proveedorid) ? 0 : mdrd.GetInt32(pos_proveedorid));
                                oenproducto.scategoria = (mdrd.IsDBNull(pos_categoriatype) ? "-" : mdrd.GetString(pos_categoriatype));
                                oenproducto.snombre = (mdrd.IsDBNull(pos_productodata) ? "-" : mdrd.GetString(pos_productodata));
                                oenproducto.sdescripcion = (mdrd.IsDBNull(pos_productodesc) ? "-" : mdrd.GetString(pos_productodesc));
                                oenproducto.dprecio = (mdrd.IsDBNull(pos_preciodec) ? 0 : mdrd.GetDecimal(pos_preciodec));
                                oenproducto.simagen1 = (mdrd.IsDBNull(pos_imagen1data) ? "-" : mdrd.GetString(pos_imagen1data));
                                oenproducto.dpreciopromocion = (mdrd.IsDBNull(pos_preciopromociondec) ? 0 : mdrd.GetDecimal(pos_preciopromociondec));
                                oenproducto.ipromociontipo = (mdrd.IsDBNull(pos_promociontype) ? 0 : mdrd.GetInt32(pos_promociontype));
                                oenproducto.sfecha_ini_promocion = (mdrd.IsDBNull(pos_fecinipromdate) ? "-" : mdrd.GetString(pos_fecinipromdate));
                                oenproducto.sfecha_fin_promocion = (mdrd.IsDBNull(pos_fecfinpromdate) ? "-" : mdrd.GetString(pos_fecfinpromdate));
                                loenproducto.Add(oenproducto);
                            }
                        }
                    }
                    return loenproducto;
                }
            }
            catch (Exception ex)
            {
                //  UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edProducto> adListarProducto(int advendedorid)
        {
            try
            {
                List<edProducto> loenusuario = new List<edProducto>();

                using (MySqlCommand cmd = new MySqlCommand("s_producto_vendedor_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pVendedorId", MySqlDbType.Int32).Value = advendedorid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edProducto oenproducto = null;
                            int pos_productoid = mdrd.GetOrdinal("producto_id");
                            int pos_proveedorid = mdrd.GetOrdinal("vendedor_id");
                            int pos_categoriatype = mdrd.GetOrdinal("categoria_type");
                            int pos_productodata = mdrd.GetOrdinal("producto_data");
                            int pos_preciopromociondec = mdrd.GetOrdinal("preciopromocion_dec");
                            int pos_preciodesc = mdrd.GetOrdinal("precio_dec");
                            int pos_productodesc = mdrd.GetOrdinal("producto_desc");
                            int pos_promociontype = mdrd.GetOrdinal("promocion_type");

                            while (mdrd.Read())
                            {
                                oenproducto = new edProducto();
                                oenproducto.productoid = (mdrd.IsDBNull(pos_productoid) ? 0 : mdrd.GetInt32(pos_productoid));
                                oenproducto.vendedorid = (mdrd.IsDBNull(pos_proveedorid) ? 0 : mdrd.GetInt32(pos_proveedorid));
                                oenproducto.scategoria = (mdrd.IsDBNull(pos_categoriatype) ? "-" : mdrd.GetString(pos_categoriatype));
                                oenproducto.snombreProducto = (mdrd.IsDBNull(pos_productodata) ? "-" : mdrd.GetString(pos_productodata));
                                oenproducto.dpreciopromocion = (mdrd.IsDBNull(pos_preciopromociondec) ? 0 : mdrd.GetDecimal(pos_preciopromociondec));
                                oenproducto.dprecio = (mdrd.IsDBNull(pos_preciodesc) ? 0 : mdrd.GetDecimal(pos_preciodesc));
                                oenproducto.sdescripcionProducto = (mdrd.IsDBNull(pos_productodesc) ? "-" : mdrd.GetString(pos_productodesc));
                                oenproducto.ipromociontipo = (mdrd.IsDBNull(pos_promociontype) ? 0 : mdrd.GetInt32(pos_promociontype));
                                loenusuario.Add(oenproducto);
                            }
                        }
                    }
                    return loenusuario;
                }
            }
            catch (Exception ex)
            {
                //  UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edProducto adListarProductoDetalle(int adtipromocion, int adproductoid)
        {
            try
            {
                edProducto oenproducto = null;
                using (MySqlCommand cmd = new MySqlCommand("s_producto_detalle_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pPromocion_type", MySqlDbType.Int32).Value = adtipromocion;
                    cmd.Parameters.Add("@_pProductoId", MySqlDbType.Int32).Value = adproductoid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_productoid = mdrd.GetOrdinal("producto_id");
                            int pos_vendedorid = mdrd.GetOrdinal("vendedor_id");
                            int pos_categoriatype = mdrd.GetOrdinal("categoria_type");
                            int pos_marcatype = mdrd.GetOrdinal("marca_type");
                            int pos_productodata = mdrd.GetOrdinal("producto_data");
                            int pos_productodesc = mdrd.GetOrdinal("producto_desc");
                            int pos_materialdesc = mdrd.GetOrdinal("material_desc");
                            int pos_promociontype = mdrd.GetOrdinal("promocion_type");
                            int pos_fechafinpromociondate = mdrd.GetOrdinal("fecha_fin_promocion_date");
                            int pos_modelodesc = mdrd.GetOrdinal("modelo_desc");
                            int pos_preciodec = mdrd.GetOrdinal("precio_dec");
                            int pos_preciopromociondec = mdrd.GetOrdinal("preciopromocion_dec");
                            int pos_medidadesc = mdrd.GetOrdinal("medida_desc");
                            int pos_imagen1data = mdrd.GetOrdinal("imagen1_data");
                            int pos_imagen2data = mdrd.GetOrdinal("imagen2_data");
                            int pos_imagen3data = mdrd.GetOrdinal("imagen3_data");
                            int pos_imagen4data = mdrd.GetOrdinal("imagen4_data");
                            int pos_imagen5data = mdrd.GetOrdinal("imagen5_data");
                            int pos_pesodec = mdrd.GetOrdinal("peso_dec");
                            int pos_fecharegdate = mdrd.GetOrdinal("fechareg_date");
                            int pos_activotype = mdrd.GetOrdinal("activo_type");

                            while (mdrd.Read())
                            {
                                oenproducto = new edProducto();
                                oenproducto.productoid = (mdrd.IsDBNull(pos_productoid) ? 0 : mdrd.GetInt32(pos_productoid));
                                oenproducto.vendedorid = (mdrd.IsDBNull(pos_vendedorid) ? 0 : mdrd.GetInt32(pos_vendedorid));
                                oenproducto.scategoria = (mdrd.IsDBNull(pos_categoriatype) ? "-" : mdrd.GetString(pos_categoriatype));
                                oenproducto.smarca = (mdrd.IsDBNull(pos_marcatype) ? "-" : mdrd.GetString(pos_marcatype));
                                oenproducto.snombreProducto = (mdrd.IsDBNull(pos_productodata) ? "-" : mdrd.GetString(pos_productodata));
                                oenproducto.sdescripcionProducto = (mdrd.IsDBNull(pos_productodesc) ? "-" : mdrd.GetString(pos_productodesc));
                                oenproducto.smaterial = (mdrd.IsDBNull(pos_materialdesc) ? "-" : mdrd.GetString(pos_materialdesc));
                                oenproducto.ipromociontipo = (mdrd.IsDBNull(pos_promociontype) ? 0 : mdrd.GetInt16(pos_promociontype));
                                oenproducto.sfecha_fin_promocion = (mdrd.IsDBNull(pos_fechafinpromociondate) ? "-" : mdrd.GetString(pos_fechafinpromociondate));
                                oenproducto.smodelo = (mdrd.IsDBNull(pos_modelodesc) ? "-" : mdrd.GetString(pos_modelodesc));
                                oenproducto.dprecio = (mdrd.IsDBNull(pos_preciodec) ? 0 : mdrd.GetDecimal(pos_preciodec));
                                oenproducto.dpreciopromocion = (mdrd.IsDBNull(pos_preciopromociondec) ? 0 : mdrd.GetDecimal(pos_preciopromociondec));
                                oenproducto.smedida = (mdrd.IsDBNull(pos_medidadesc) ? "-" : mdrd.GetString(pos_medidadesc));
                                oenproducto.simagen1 = (mdrd.IsDBNull(pos_imagen1data) ? "-" : mdrd.GetString(pos_imagen1data));
                                oenproducto.simagen2 = (mdrd.IsDBNull(pos_imagen2data) ? "-" : mdrd.GetString(pos_imagen2data));
                                oenproducto.simagen3 = (mdrd.IsDBNull(pos_imagen3data) ? "-" : mdrd.GetString(pos_imagen3data));
                                oenproducto.simagen4 = (mdrd.IsDBNull(pos_imagen4data) ? "-" : mdrd.GetString(pos_imagen4data));
                                oenproducto.simagen5 = (mdrd.IsDBNull(pos_imagen5data) ? "-" : mdrd.GetString(pos_imagen5data));
                                oenproducto.dpeso = (mdrd.IsDBNull(pos_pesodec) ? 0 : mdrd.GetDecimal(pos_pesodec));
                                oenproducto.sfecha_registro = (mdrd.IsDBNull(pos_fecharegdate) ? "-" : mdrd.GetString(pos_fecharegdate));
                                oenproducto.iactivo = (mdrd.IsDBNull(pos_activotype) ? 0 : mdrd.GetInt16(pos_activotype));
                            }
                        }
                    }
                    return oenproducto;
                }
            }
            catch (Exception ex)
            {
                //  UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }


        public int adRegistrarProducto(int advendedorid, Int16 adcategoria_type, string adnombre, string addescripcion, decimal adprecio
                                    , string adimagen1, string adimagen2, string adimagen3, string adimagen4, string adimagen5, string adfechareg)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_producto_registrar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pvendedor_id", MySqlDbType.Int32).Value = advendedorid;
                cmd.Parameters.Add("@_pcategoria_type", MySqlDbType.Int16).Value = adcategoria_type;
                cmd.Parameters.Add("@_pproducto_data", MySqlDbType.VarChar, 150).Value = adnombre;
                cmd.Parameters.Add("@_pproducto_desc", MySqlDbType.VarChar, 250).Value = addescripcion;
                cmd.Parameters.Add("@_pprecio_dec", MySqlDbType.Decimal).Value = adprecio;
                cmd.Parameters.Add("@_pimagen1_data", MySqlDbType.VarChar, 250).Value = adimagen1;
                cmd.Parameters.Add("@_pimagen2_data", MySqlDbType.VarChar, 250).Value = adimagen2;
                cmd.Parameters.Add("@_pimagen3_data", MySqlDbType.VarChar, 250).Value = adimagen3;
                cmd.Parameters.Add("@_pimagen4_data", MySqlDbType.VarChar, 250).Value = adimagen4;
                cmd.Parameters.Add("@_pimagen5_data", MySqlDbType.VarChar, 250).Value = adimagen5;
                cmd.Parameters.Add("@_pfechareg_date", MySqlDbType.VarChar, 25).Value = adfechareg;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adActualizarProducto(int adproducto_id, int admarca, Int16 adcategoria, string adnombre, string addescripcion
                                    , string admaterial, decimal adprecio, string admodelo, string admedida, string adimagen1
                                    , string adimagen2, string adimagen3, string adimagen4, string adimagen5, decimal adpeso
                                    , string adfechamod, Int16 admodificado)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_producto_actualizar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pproducto_id", MySqlDbType.Int32).Value = adproducto_id;
                cmd.Parameters.Add("@_pmarca_type", MySqlDbType.Int32).Value = admarca;
                cmd.Parameters.Add("@_pcategoria_type", MySqlDbType.Int16).Value = adcategoria;
                cmd.Parameters.Add("@_pproducto_data", MySqlDbType.VarChar, 150).Value = adnombre;
                cmd.Parameters.Add("@_pproducto_desc", MySqlDbType.VarChar, 250).Value = addescripcion;
                cmd.Parameters.Add("@_pmaterial_desc", MySqlDbType.VarChar, 250).Value = admaterial;
                cmd.Parameters.Add("@_pprecio_dec", MySqlDbType.Decimal).Value = adprecio;
                cmd.Parameters.Add("@_pmodelo_desc", MySqlDbType.VarChar, 150).Value = admodelo;
                cmd.Parameters.Add("@_pmedida_desc", MySqlDbType.VarChar, 150).Value = admedida;
                cmd.Parameters.Add("@_pimagen1_data", MySqlDbType.VarChar, 250).Value = adimagen1;
                cmd.Parameters.Add("@_pimagen2_data", MySqlDbType.VarChar, 250).Value = adimagen2;
                cmd.Parameters.Add("@_pimagen3_data", MySqlDbType.VarChar, 250).Value = adimagen3;
                cmd.Parameters.Add("@_pimagen4_data", MySqlDbType.VarChar, 250).Value = adimagen4;
                cmd.Parameters.Add("@_pimagen5_data", MySqlDbType.VarChar, 250).Value = adimagen5;
                cmd.Parameters.Add("@_ppeso_dec", MySqlDbType.Decimal).Value = adpeso;
                cmd.Parameters.Add("@_pfechamod_date", MySqlDbType.VarChar, 25).Value = adfechamod;
                cmd.Parameters.Add("@_pmodificado_type", MySqlDbType.Int16).Value = admodificado;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adEliminarProducto(int adproductoid)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_producto_eliminar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pproducto_id", MySqlDbType.Int32).Value = adproductoid;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edProducto> adListarProductoVendedor(string adnombre, int adNumeroPagina, int adCantidadMostrar)
        {
            try
            {
                List<edProducto> loenProducto = new List<edProducto>();
                using (MySqlCommand cmd = new MySqlCommand("s_productoVendedor_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pproducto_data", MySqlDbType.VarChar, 150).Value = adnombre;
                    cmd.Parameters.Add("@_pNumeroPagina", MySqlDbType.Int32).Value = adNumeroPagina;
                    cmd.Parameters.Add("@_pTotalPagina", MySqlDbType.Int32).Value = adCantidadMostrar;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edProducto oenproducto = null;
                            int pos_productoid = mdrd.GetOrdinal("producto_id");
                            int pos_productodata = mdrd.GetOrdinal("producto_data");
                            int pos_nombredata = mdrd.GetOrdinal("nombre_data");
                            int pos_categoriaid = mdrd.GetOrdinal("categoria_id");
                            int pos_preciodec = mdrd.GetOrdinal("precio_dec");

                            while (mdrd.Read())
                            {
                                oenproducto = new edProducto();
                                oenproducto.productoid = (mdrd.IsDBNull(pos_productoid) ? 0 : mdrd.GetInt32(pos_productoid));
                                oenproducto.snombre = (mdrd.IsDBNull(pos_productodata) ? "-" : mdrd.GetString(pos_productodata));
                                oenproducto.categoriaid = (mdrd.IsDBNull(pos_categoriaid) ? 0 : mdrd.GetInt32(pos_categoriaid));
                                oenproducto.scategoria = (mdrd.IsDBNull(pos_nombredata) ? "-" : mdrd.GetString(pos_nombredata));
                                oenproducto.dprecio = (mdrd.IsDBNull(pos_preciodec) ? 0 : mdrd.GetDecimal(pos_preciodec));
                                loenProducto.Add(oenproducto);
                            }
                        }
                    }
                    return loenProducto;
                }
            }
            catch (Exception ex)
            {
                //  UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edProducto adEditarProductoVendedor(int adproductoid)
        {
            try
            {
                edProducto oenproducto = null;
                using (MySqlCommand cmd = new MySqlCommand("s_productoVendedor_editar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_pproductoid", MySqlDbType.Int32).Value = adproductoid;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_productoid = mdrd.GetOrdinal("producto_id");
                            int pos_vendedorid = mdrd.GetOrdinal("vendedor_id");
                            int pos_productodata = mdrd.GetOrdinal("producto_data");
                            int pos_productodesc = mdrd.GetOrdinal("producto_desc");
                            int pos_materialdesc = mdrd.GetOrdinal("material_desc");
                            int pos_preciodec = mdrd.GetOrdinal("precio_dec");
                            int pos_modelodesc = mdrd.GetOrdinal("modelo_desc");
                            int pos_medidadesc = mdrd.GetOrdinal("medida_desc");
                            int pos_imagen1data = mdrd.GetOrdinal("imagen1_data");
                            int pos_imagen2data = mdrd.GetOrdinal("imagen2_data");
                            int pos_imagen3data = mdrd.GetOrdinal("imagen3_data");
                            int pos_imagen4data = mdrd.GetOrdinal("imagen4_data");
                            int pos_imagen5data = mdrd.GetOrdinal("imagen5_data");
                            int pos_pesodec = mdrd.GetOrdinal("peso_dec");
                            int pos_fecharegdate = mdrd.GetOrdinal("fechareg_date");
                            int pos_nombredata = mdrd.GetOrdinal("nombre_data");
                            int pos_categoriaid = mdrd.GetOrdinal("categoria_id");

                            while (mdrd.Read())
                            {
                                oenproducto = new edProducto();
                                oenproducto.productoid = (mdrd.IsDBNull(pos_productoid) ? 0 : mdrd.GetInt32(pos_productoid));
                                oenproducto.vendedorid = (mdrd.IsDBNull(pos_vendedorid) ? 0 : mdrd.GetInt32(pos_vendedorid));
                                oenproducto.snombre = (mdrd.IsDBNull(pos_productodata) ? "-" : mdrd.GetString(pos_productodata));
                                oenproducto.sdescripcion = (mdrd.IsDBNull(pos_productodesc) ? "-" : mdrd.GetString(pos_productodesc));
                                oenproducto.smaterial = (mdrd.IsDBNull(pos_materialdesc) ? "-" : mdrd.GetString(pos_materialdesc));
                                oenproducto.dprecio = (mdrd.IsDBNull(pos_preciodec) ? 0 : mdrd.GetDecimal(pos_preciodec));
                                oenproducto.smodelo = (mdrd.IsDBNull(pos_modelodesc) ? "-" : mdrd.GetString(pos_modelodesc));
                                oenproducto.smedida = (mdrd.IsDBNull(pos_medidadesc) ? "-" : mdrd.GetString(pos_medidadesc));
                                oenproducto.simagen1 = (mdrd.IsDBNull(pos_imagen1data) ? "-" : mdrd.GetString(pos_imagen1data));
                                oenproducto.simagen2 = (mdrd.IsDBNull(pos_imagen2data) ? "-" : mdrd.GetString(pos_imagen2data));
                                oenproducto.simagen3 = (mdrd.IsDBNull(pos_imagen3data) ? "-" : mdrd.GetString(pos_imagen3data));
                                oenproducto.simagen4 = (mdrd.IsDBNull(pos_imagen4data) ? "-" : mdrd.GetString(pos_imagen4data));
                                oenproducto.simagen5 = (mdrd.IsDBNull(pos_imagen5data) ? "-" : mdrd.GetString(pos_imagen5data));
                                oenproducto.dpeso = (mdrd.IsDBNull(pos_pesodec) ? 0 : mdrd.GetDecimal(pos_pesodec));
                                oenproducto.sfecha_registro = (mdrd.IsDBNull(pos_fecharegdate) ? "-" : mdrd.GetString(pos_fecharegdate));
                                oenproducto.snombreCategoria = (mdrd.IsDBNull(pos_nombredata) ? "-" : mdrd.GetString(pos_nombredata));
                                oenproducto.categoriaid = (mdrd.IsDBNull(pos_categoriaid) ? 0 : mdrd.GetInt32(pos_categoriaid));
                            }
                        }
                    }
                    return oenproducto;
                }
            }
            catch (Exception ex)
            {
                //  UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adActivarPromocionProducto(int adproductoid, decimal adprecio, Int16 adtipopromocion, decimal adpreciopromocion
                                                , string adfechainipromocion, string adfechafinpromocion)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_producto_actualizar_promocion", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pproducto_id", MySqlDbType.Int32).Value = adproductoid;
                cmd.Parameters.Add("@_pprecio_dec", MySqlDbType.Decimal).Value = adprecio;
                cmd.Parameters.Add("@_ppromocion_type", MySqlDbType.Int16).Value = adtipopromocion;
                cmd.Parameters.Add("@_ppreciopromocion_dec", MySqlDbType.Decimal).Value = adpreciopromocion;
                cmd.Parameters.Add("@_pfecha_ini_promocion_date", MySqlDbType.VarChar, 25).Value = adfechainipromocion;
                cmd.Parameters.Add("@_pfecha_fin_promocion_date", MySqlDbType.VarChar, 25).Value = adfechafinpromocion;

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
