using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using AccesoDatos.TypeVar;
using ClssTool;

namespace AccesoDatos
{
    public class Conexion
    {

        private MySqlConnectionStringBuilder objconexionCons = new MySqlConnectionStringBuilder();
        private MySqlConnection objconexion;
        private MySqlCommand comando;
        private MySqlDataReader recupera;

        private string retorno;
        private string mensaje;
        private string mod;
        private ColRespCallDb Resp;

        public Conexion(string md)
        {
          // objconexionCons.Server = "190.47.138.170";
            objconexionCons.Server = "localhost";

            objconexionCons.Password = "123456";
            objconexionCons.Database = "EdificioMain";
            objconexionCons.UserID = "root";

            mod = md;
            objconexion = new MySqlConnection(objconexionCons.ToString());

            //comando = new MySqlCommand(strComando, objconexion);
        }


        private bool OpenConexion()
        {
            try
            {
                objconexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                ClLog.logger.Error("conx-" + mod + "-" + ex);
                return false;
            }

        }

        #region Insert


        public void InsertSQLvar(string sql, List<MySqlParameter> ParCol)
        {
            comando = new MySqlCommand(sql, objconexion);
            comando.CommandText = sql;
            comando.Parameters.AddRange(ParCol.ToArray<MySqlParameter>());
            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                { comando.ExecuteNonQuery(); }
            }
            catch (MySqlException ex)
            { ClLog.logger.Error("invr-" + mod + "-" + ex); }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
                comando.Dispose();
            }
        }


        public int InsertSQLvar(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);

            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                { comando.ExecuteNonQuery(); }
                return 1;
            }
            catch (MySqlException ex)
            {
                ClLog.logger.Error("invr-" + mod + "-" + ex);
                return -1;
            }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
            }
        }

        public string InsertSQLvarResp(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);

            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        retorno = recupera.GetValue(0).ToString();
                        mensaje = recupera.GetValue(1).ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                ClLog.logger.Error("inrr-" + mod + "-" + ex);
                return "-1";
            }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
            }
            if (retorno.EndsWith(";"))
                return retorno.Substring(0, retorno.Length);
            else
                return retorno;
        }

        public string InsertSQLvarResp(string sql, List<MySqlParameter> ParCol)
        {
            comando = new MySqlCommand(sql, objconexion);
            comando.CommandText = sql;
            comando.Parameters.AddRange(ParCol.ToArray<MySqlParameter>());
            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        retorno = recupera.GetValue(0).ToString();
                        mensaje = recupera.GetValue(1).ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                ClLog.logger.Error("inrr-" + mod + "-" + ex);
                return "-1";
            }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
                comando.Dispose();
            }
            if (retorno.EndsWith(";"))
                return retorno.Substring(0, retorno.Length-1);
            else
                return retorno;
        }

        public ColRespCallDb InsertSQLvarMsg(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);
            Resp = new ColRespCallDb();
            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        Resp.Est = Convert.ToInt16(recupera.GetValue(0));
                        Resp.Msg = recupera.GetValue(1).ToString();
                    }
                }
                return Resp;
            }
            catch (MySqlException ex)
            {
                ClLog.logger.Error("invm-" + mod + "-" + ex);
                Resp.Est = -1;
                Resp.Msg = "";
                return Resp;
            }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
                comando.Dispose();
            }
        }


        public ColRespCallDb InsertSQLvarMsg(string sql, List<MySqlParameter> ParCol)
        {
            comando = new MySqlCommand(sql, objconexion);
            comando.CommandText = sql;
            comando.Parameters.AddRange(ParCol.ToArray<MySqlParameter>());
            Resp = new ColRespCallDb();
            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        Resp.Est = Convert.ToInt16(recupera.GetValue(0));
                        Resp.Msg = recupera.GetValue(1).ToString();
                    }
                }
                return Resp;
            }
            catch (MySqlException ex)
            {
                ClLog.logger.Error("invm-" + mod + "-" + ex);
                Resp.Est = -1;
                Resp.Msg = "";
                return Resp;
            }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
                comando.Dispose();
            }
        }

        #endregion

        #region Select

        public DataTable SelectGridProc(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);
            DataTable tabla = new DataTable();

            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    MySqlDataAdapter Data_Adapter = new MySqlDataAdapter(comando);
                    Data_Adapter.Fill(tabla);
                    return tabla;
                }
            }
            catch (MySqlException ex)
            { ClLog.logger.Error("selg-" + mod + "-" + ex); }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
                tabla.Dispose();
            }
            return null;

        }



        public ArrayList SelectColectProc(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);
            ArrayList rec = new ArrayList();
            int a;
            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        a = recupera.FieldCount;
                        for (int i = 0; i < a; i++)
                        { rec.Add(recupera.GetValue(i)); }
                    }
                }
            }
            catch (MySqlException ex)
            { ClLog.logger.Error("selc-" + mod + "-" + ex); }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
            }
            return rec;
        }


        public List<ColIdName> SelectColect2Proc(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);
            List<ColIdName> ColDat = new List<ColIdName>();

            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        ColIdName dat = new ColIdName();

                        dat.Id = (int)recupera.GetValue(0);
                        dat.Name = recupera.GetValue(1).ToString();

                        ColDat.Add(dat);
                    }
                }
            }
            catch (MySqlException ex)
            {
                ClLog.logger.Error("sl2p-" + mod + "-" + ex);
                return null;
            }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
            }

            return ColDat;
        }


        public List<ColIdNameTip> SelectColect3Proc(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);
            List<ColIdNameTip> ColDat = new List<ColIdNameTip>();

            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        ColIdNameTip dat = new ColIdNameTip();

                        dat.Id = (int)recupera.GetValue(0);
                        dat.Name = recupera.GetValue(1).ToString();
                        dat.Tip = recupera.GetInt32(2);

                        ColDat.Add(dat);
                    }
                }
            }
            catch (MySqlException ex)
            { ClLog.logger.Error("sl3p-" + mod + "-" + ex); }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
            }

            return ColDat;
        }

        public List<ColComent> SelectColect4Proc(string sql)
        {
            comando = new MySqlCommand(sql, objconexion);
            List<ColComent> ColDat = new List<ColComent>();

            try
            {
                objconexion.Open();
                if (objconexion.State == ConnectionState.Open)
                {
                    recupera = comando.ExecuteReader();
                    while (recupera.Read())
                    {
                        ColComent dat = new ColComent();

                        dat.Id = (int)recupera.GetValue(0);
                        dat.Mnsj = recupera.GetValue(1).ToString();
                        dat.Fecha = recupera.GetDateTime(2);

                        ColDat.Add(dat);
                    }
                }
            }
            catch (MySqlException ex)
            { ClLog.logger.Error("sl4p-" + mod + "-" + ex); }
            finally
            {
                if (objconexion.State == ConnectionState.Open)
                    objconexion.Close();
            }

            return ColDat;
        }

        #endregion


    }
}
