using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using backendAD;
using backendED;

namespace backendTD
{
    public class tdCategoria : td_ageneral
    {
        adCategoria iadCategoria;

        public int tdAgregarCategoria(string tdnombre, string tdiconoCodigo)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadCategoria = new adCategoria(con);
                    iresultado = iadCategoria.adAgregarCategoria(tdnombre, tdiconoCodigo);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdActualizarCategoria(int tdcategoriaid, string tdnombre, string tdcodigo)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadCategoria = new adCategoria(con);
                    iresultado = iadCategoria.adActualizarCategoria(tdcategoriaid, tdnombre, tdcodigo);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdEliminarCategoria(int tdcategoriaid)
        {
            try
            {
                int iresultado = -2;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadCategoria = new adCategoria(con);
                    iresultado = iadCategoria.adEliminarCategoria(tdcategoriaid);
                }
                return iresultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edCategoria> tdListarCategoria()
        {
            try
            {
                List<edCategoria> loenproducto = new List<edCategoria>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    iadCategoria = new adCategoria(con);
                    loenproducto = iadCategoria.adListarCategoria();
                }
                return loenproducto;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaRN, UtlConstantes.LogNamespace_ventaRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
