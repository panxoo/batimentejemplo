using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.TypeVar;
using MySql.Data.MySqlClient;

namespace ClssVmMdl.Calling
{
    public class CallNota
    {

        public CallNota(string mod)
        {
            conn = new Conexion(mod);
        }

        private Conexion conn;
        private string resp;


        #region Pantalla Nota

        public List<ColIdName> PTNT_Tpnota(int cond)
        {
            List<ColIdName> Lst;
            const string V = "select * from vwptnt_tpnota where idcond = ";
            Lst = conn.SelectColect2Proc(V + cond);
            return Lst;
        }

        public List<ColIdName> PTNT_Tpnvl()
        {
            List<ColIdName> Lst;
            const string Sql = "select * from vwtpnt_ntnvl";
            Lst = conn.SelectColect2Proc(Sql);
            return Lst;
        }

        public DataTable PTNT_GrdNotas(int cond, int edf, int vigent)
        {
            DataTable Dt = new DataTable();
            const string Sql = "Call sf_ptnt_selectnotas (";
            Dt = conn.SelectGridProc(Sql + cond + "," + edf + "," + vigent + ");");
            return Dt;
        }

        public string PTNT_SavNota(string nt, int edf, int tpmsg, int nvl, bool tper, DateTime ftper)
        {
            List<MySqlParameter> Lst = new List<MySqlParameter>();
            Lst.Add(new MySqlParameter("@ftoer", ftper));

            const string V = "Call sv_ptnt_newnota ('";
            resp = conn.InsertSQLvarResp(V + nt.Trim() + "'," + edf + "," + tpmsg + "," + nvl + "," + tper + ",@ftoer);", Lst);

            return resp;
        }

        public List<ColComent> PTNT_Coments(int cond, int idmsg)
        {
            List<ColComent> Lst;
            string Sql = "select * from vwptnt_comentarios where id_nt = " + idmsg.ToString() + " and cond = " + cond ;
            Lst = conn.SelectColect4Proc(Sql);
            return Lst;
        }

        public string PTNT_SavComent(int cond, int mnsg, string coment)
        {
            int a = conn.InsertSQLvar("Call sv_ptnt_comentario(" + mnsg + ",'" + coment + "');");
            return a.ToString();
        }

        public string PTNT_DelMessage(int cond, int mnsg)
        {
            //          resp = conn.InsertSQLvarResp("Call sv_ptnt_newnota ('" + nt.Trim() + "'," + edf + "," + tpmsg + "," + nvl + "," + tper + ",@ftoer);", Lst);
            return resp;
        }

        public string PTNT_DelMessage(int cond, int mnsg, int coment)
        {
            //          resp = conn.InsertSQLvarResp("Call sv_ptnt_newnota ('" + nt.Trim() + "'," + edf + "," + tpmsg + "," + nvl + "," + tper + ",@ftoer);", Lst);
            return resp;
        }
        #endregion
    }
}
