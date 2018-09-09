using System;
using System.Collections.Generic;
using AccesoDatos;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using ClssVmMdl.Validacion;
using AccesoDatos.TypeVar;

namespace ClssVmMdl.Calling
{
    class CallDep
    {

        private Conexion Conn;
        private MsgEvents MsgEv;
        private string Resp;
        private int Respi;


        public CallDep(string mod)
        {
            Conn = new Conexion(mod);
        }

        public DataTable ViewDesp()
        {
            DataTable Dt = new DataTable();
            Dt = Conn.SelectGridProc("Select * From vwinfdep");
            return Dt;
        }

        public void svtinfdep(int mod, string nom, string id, string num, string tel,
            string tel2, string em, string em2, int ps, int sbps)
        {
            Conn.InsertSQLvar("call sv_infdep (" + mod + ",'" + nom + "','" + id + "','" + num + "','" + tel + "','" +
                                                tel2 + "','" + em + "','" + em2 + "'," + ps + "," + sbps + ");");
        }

        public ArrayList seldepup(string nom)
        {
            try
            {
                ArrayList Colect;
                Colect = Conn.SelectColectProc("Select * FROM vwinfdepupdt where nom_dep = '" + nom + "'");
                return Colect;
            }
            catch (Exception ex) { }
            return null;
        }



        #region Configurado Edificio

        public ArrayList CFED_SelCond(int idCond)
        {
            ArrayList Colect;
            Colect = Conn.SelectColectProc("Select * FROM vwcfed_condominio where id_cond = " + idCond);
            return Colect;
        }

        public DataTable CFED_DatosEdificios(int cond)
        {
            DataTable Colect;
            Colect = Conn.SelectGridProc("Select * FROM vwcfed_datosedificios where cond = " + cond);
            return Colect;
        }

        public ArrayList CFED_SelEdef(int dep, int idcond)
        {
            ArrayList Colect;
            Colect = Conn.SelectColectProc("Select * FROM vwcfed_infdepart where id_edf = " + dep + " and idcond = " + idcond);
            return Colect;
        }


        public string CFED_SavCond(string cond, int pai, int reg, string ciu, string calle, string numd, string post, string tel, 
            string tel2, string cor, string cor2, int tpCond, int idcond)
        {
            Respi = Conn.InsertSQLvar("call up_cfed_condominio('" + cond + "'," + pai + "," + reg + ",'" + ciu + "','" + calle + "','" + numd + "','" + tel + "','" + tel2 + "','" + cor + "','" + cor2 + "','" + post + "'," + tpCond + "," + idcond + ");");
            return Respi.ToString();
        }


        public string CFED_SavDep(int cond, string nom, string idnom, string numdired, string tel, string tel2, string cor, string cor2, int piso, int spiso)
        {
            Resp = Conn.InsertSQLvarResp("call sv_cfed_edificio(" + cond + ",'" + nom + "','" + idnom + "','" + numdired + "','" + tel + "','" + tel2 + "','" + cor + "','" + cor2 + "'," + piso + "," + spiso + ");");
            return Resp;
        }

        public string CFED_SavDep(int cond, string nom, string idnom, string numdired, string tel, string tel2, string cor, string cor2, int piso, int spiso, int idDep)
        {
            Resp = Conn.InsertSQLvarResp("call up_cfed_edificio(" + cond + ",'" + nom + "','" + idnom + "','" + numdired + "','" + tel + "','" + tel2 + "','" + cor + "','" + cor2 + "'," + piso + "," + spiso + "," + idDep + ");");
            return Resp;
        }

        #endregion


        #region Model

        public string SvtModDep(int dep, int tpdep, string nom, int dor, int ban, double tamall, double tamut, int idCond)
        {
            List<MySqlParameter> ParUnit = new List<MySqlParameter>();
            ParUnit.Add(new MySqlParameter("@tamall", tamall));
            ParUnit.Add(new MySqlParameter("@tamut", tamut));

            Resp = Conn.InsertSQLvarResp("call sv_mdpp_moddep(" + dep + "," + tpdep + ",'" + nom + "'," + dor + "," + ban + ",@tamall,@tamut," + idCond + ");", ParUnit);
            return Resp;
        }

        public string SvtModDep(int id, int dep, int tpdep, string nom, int dor, int ban, double tamall, double tamut, int idCond)
        {
            List<MySqlParameter> ParUnit = new List<MySqlParameter>();
            ParUnit.Add(new MySqlParameter("@tamall", tamall));
            ParUnit.Add(new MySqlParameter("@tamut", tamut));

            Resp = Conn.InsertSQLvarResp("call up_mdpp_moddep(" + id + "," + dep + "," + tpdep + ",'" + nom + "'," + dor + "," + ban + ",@tamall,@tamut," + idCond + ");", ParUnit);
            return Resp;

        }

        public string SvtModDep(int idMod, int idedf, int idcondom, string nomod)
        {
            Resp = Conn.InsertSQLvarResp("call dl_mdpp_moddep(" + idMod + "," + idedf + "," + idcondom + ",'" + nomod + "');");
            return Resp;
        }

        public string MDPP_SvtModOtro(int TipOtro, string nom, double tam, int dep, int cond, int id_cond)
        {
            List<MySqlParameter> ParUnit = new List<MySqlParameter>();
            ParUnit.Add(new MySqlParameter("@tam", tam));

            Resp = Conn.InsertSQLvarResp("Call sv_mdpp_modot (" + TipOtro + "," + cond + "," + dep + ",'" + nom + "',@tam," + id_cond + ");", ParUnit);

            return Resp;
        }

        public string MDPP_SvtModOtro(string nom, double tam, int dep, int cond, int id, int id_cond, int tp_otro)
        {
            List<MySqlParameter> ParUnit = new List<MySqlParameter>();
            ParUnit.Add(new MySqlParameter("@tam", tam));

            Resp = Conn.InsertSQLvarResp("Call up_mdpp_modot (" + id + "," + cond + "," + dep + ",'" + nom + "',@tam," + id_cond + "," + tp_otro + ");", ParUnit);

            return Resp;
        }

        public string MDPP_SvtModOtro(int idMod, int idedf, int idcondom, string nomod, int tpmod, int condAct)
        {
            Resp = Conn.InsertSQLvarResp("Call dl_mdpp_modot (" + idMod + "," + idedf + "," + idcondom + "," + tpmod + "," + condAct + ",'" + nomod + "');");
            return Resp;

        }

        public DataTable MDPP_SelModelGrd(int tp, int idcond)
        {
            DataTable dt;

            if (tp == -1)
                dt = Conn.SelectGridProc("Select * FROM vwmdpp_modelodepartament where idCond = " + idcond);
            else
                dt = Conn.SelectGridProc("Select * FROM vwmdpp_modelootro Where tp=" + tp + "  and idCond = " + idcond);

            return dt;
        }

        //public ArrayList SelModeloCamp(int id, int tp)
        //{
        //    try
        //    {
        //        ArrayList Colect;
        //        string Sql;

        //        if (tp == 0)
        //            Sql = "";
        //        else if (tp == 1)
        //            Sql = "";
        //        else
        //            Sql = "";

        //        Colect = Conn.SelectColectProc("Select * FROM " + Sql);
        //        return Colect;
        //    }
        //    catch (Exception ex) { return null; }
        //}

        #endregion

        #region Mant Departament


        public List<ColIdName> MTDP_CallModelDepa(int edef, int idcond)
        {
            List<ColIdName> Lst;
            Lst = Conn.SelectColect2Proc("select * from vwmtdp_modeldep where edef = " + edef + " and cond = " + idcond);
            return Lst;
        }

        public DataTable MTDP_SelDepartamentxPiso(int ps, int edef, int idcond)
        {
            DataTable dt;
            dt = Conn.SelectGridProc("Select * FROM vwmtdp_DepartamentXPiso Where edef = " + edef + " and pis =" + ps + " and cond =" + idcond);
            return dt;
        }

        public string MTDP_SavDepartament(int ps, int ede, int mod, int ori, string nom, int num)
        {
            Resp = Conn.InsertSQLvarResp("call sv_mtdp_departament(" + ps + "," + ede + "," + mod + "," + ori + ",'" + nom + "'," + num + ");");
            return Resp;
        }

        public string MTDP_UpdDepartament(int ps, int ede, int mod, int ori, string nom, int num, int dep)
        {
                Resp = Conn.InsertSQLvarResp("call up_mtdp_departament(" + ps + "," + ede + "," + mod + "," + ori + ",'" + nom + "'," + num + "," + dep + ");");
                MsgEv = new MsgEvents();
                MsgEv.MsgAlmacenar("mtdp", Resp);
                return Resp;
                 }

        public ArrayList MTDP_ViewDepartUpdt(int id_dep, int piso, int edf)
        {
            try
            {
                ArrayList Colect;
                Colect = Conn.SelectColectProc("select * from vwmtdp_DepartUpdt where id = " + id_dep + " and pis = " + piso + " and ed = " + edf);
                return Colect;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
