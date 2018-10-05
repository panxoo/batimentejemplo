using System.Data;
using AccesoDatos;

namespace ClssVmMdl.Calling
{
    public class CallServicios
    {

        public CallServicios(string mod)
        {
            conn = new Conexion(mod);
        }

        private Conexion conn;
        private string Resp;


        #region Tipo Servicios

        public DataTable TPSV_CargaGrillaTpSrv(int cond)
        {
            DataTable Dt = new DataTable();
            Dt = conn.SelectGridProc("select * from vwtpsv_tipo_servicio");
            return Dt;
        }

        public string TPSV_SaveTpSrv(int cond, string usr, string nom, bool rqcob, int? valor, bool rqgr, int valgr, bool rqgc, bool rqrsv,
            bool rsvvaltot, int rsvval, bool rsvche, bool rsvefe, bool rsvtra)
        {

            Resp = conn.InsertSQLvarResp("Call sv_tpsv_tiposervicio (" + cond + ",'" + nom + "'," + rqcob + "," + valor + "," + rqgr + "," + valgr
                + "," + rqgc + "," + rqrsv + "," + rsvvaltot + "," + rsvval + "," + rsvche + "," + rsvefe + "," + rsvtra + ");");

            return Resp;
        }

        public string TPSV_SaveTpSrv(int idSrv, int cond, string usr, string nom, bool rqcob, int? valor, bool rqgr, int valgr, bool rqgc, bool rqrsv,
          bool rsvvaltot, int rsvval, bool rsvche, bool rsvefe, bool rsvtra)
        {

            Resp = conn.InsertSQLvarResp("Call up_tpsv_tiposervicio (" + idSrv + "," + cond + ",'" + nom + "'," + rqcob + "," + valor + "," + rqgr + "," + valgr
                + "," + rqgc + "," + rqrsv + "," + rsvvaltot + "," + rsvval + "," + rsvche + "," + rsvefe + "," + rsvtra + ");");

            return Resp;
        }

        public string TPSV_RmvTpSrv(int idSrv, int cond, string usr)
        {
            Resp = conn.InsertSQLvarResp("Call rm_tpsv_tiposervicio (" + idSrv + "," + cond + ");");
            return Resp;
        }


        #endregion

        #region Servicios

        public DataTable SRVI_DetalleTpServicio(int cond, int IdTpSrv)
        {
            DataTable Dt;
            Dt = conn.SelectGridProc("select * from vwsrvi_detalle_tpsrvi where cond = " + cond + " and Id = " + IdTpSrv);
            return Dt;
        }

        public DataTable SRVI_Servicios(int cond)
        {
            DataTable Dt;
            Dt = conn.SelectGridProc("select * from vwsrvi_servicios where cond = " + cond);
            return Dt;
        }

        public string SRVI_Almacenar(int cond, int edfi, int tp_srv, string nom, bool cstFj, int cstFjVal, bool cstFjd, bool cstFjm, bool cstUso, int cstUsoVal, bool condUs)
        {
            Resp = conn.InsertSQLvarResp("Call sv_srvi_servicios (" + cond + "," + edfi + "," + tp_srv + ",'" + nom + "'," + cstFj + "," + cstFjVal + "," + cstFjd + "," + cstFjm +
                "," + cstUso + "," + cstUsoVal + "," + condUs + ");");
            return Resp;
        }

        public string SRVI_Almacenar(int id, int cond, int edfi,string nom, bool cstFj, int cstFjVal, bool cstFjd, bool cstFjm, bool cstUso, int cstUsoVal)
        {
            Resp = conn.InsertSQLvarResp("Call up_srvi_servicios (" + id + "," + cond + "," + edfi + ",'" + nom + "'," + cstFj + "," + cstFjVal + "," + cstFjd + "," +
                cstFjm + "," + cstUso + "," + cstUsoVal + ");");
            return Resp;
        }

        public string SRVI_Delserv(int id, int idcondom)
        {
            Resp = conn.InsertSQLvarResp("call dl_srvi_servicio(" + id + "," + idcondom + ");");
            return Resp;
        }

        #endregion

    }
}
