using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using backendED;

namespace backendAD
{
    public class adCategoria : ad_global
    {
        public adCategoria(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public int adAgregarCategoria(string adnombre, string adiconoCodigo)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_categoria_registrar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pnombre_data", MySqlDbType.VarChar, 150).Value = adnombre;
                cmd.Parameters.Add("@_picono_codigo_data", MySqlDbType.VarChar, 50).Value = adiconoCodigo;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adActualizarCategoria(int adcategoriaid, string adnombre, string adcodigo)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_categoria_actualizar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pcategoria_id", MySqlDbType.Int32).Value = adcategoriaid;
                cmd.Parameters.Add("@_pnombre_data", MySqlDbType.VarChar, 150).Value = adnombre;
                cmd.Parameters.Add("@_picono_codigo_data", MySqlDbType.VarChar, 50).Value = adcodigo;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adEliminarCategoria(int adcategoriaid)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("s_categoria_eliminar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_pcategoria_id", MySqlDbType.Int32).Value = adcategoriaid;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edCategoria> adListarCategoria()
        {
            try
            {
                List<edCategoria> loenCategoria = new List<edCategoria>();
                using (MySqlCommand cmd = new MySqlCommand("s_categoria_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edCategoria oenproducto = null;
                            int pos_categoriaid = mdrd.GetOrdinal("categoria_id");
                            int pos_categorianombre = mdrd.GetOrdinal("nombre_data");
                            int pos_categoriaicono = mdrd.GetOrdinal("icono_codigo_data");
                            while (mdrd.Read())
                            {
                                oenproducto = new edCategoria();
                                oenproducto.categoriaid = (mdrd.IsDBNull(pos_categoriaid) ? 0 : mdrd.GetInt32(pos_categoriaid));
                                oenproducto.sNombre = (mdrd.IsDBNull(pos_categorianombre) ? "-" : mdrd.GetString(pos_categorianombre));
                                oenproducto.sIconoCodigo = (mdrd.IsDBNull(pos_categoriaicono) ? "-" : mdrd.GetString(pos_categoriaicono));
                                loenCategoria.Add(oenproducto);
                            }
                        }
                    }
                    return loenCategoria;
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
