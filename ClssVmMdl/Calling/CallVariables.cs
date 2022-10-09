using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data;
using AccesoDatos.TypeVar;
using ClssVmMdl.Validacion;

namespace ClssVmMdl.Calling
{
    public class CallVariables
    {
        private Conexion conn;

        public CallVariables(string mod)
        {
            conn = new Conexion(mod);
        }

        public DataTable Calltpnot()
        {
            DataTable dt;
            dt = conn.SelectGridProc("select * from vwtiponota");
            return dt;
        }

        public List<ColIdName> PRGN_tpdep(int cond)
        {
            List<ColIdName> Lst;
            Lst = conn.SelectColect2Proc("select * from vwprgn_tipodepartament where idcond = " + cond);
            return Lst;
        }

        public List<ColIdName> PRGN_Edif(int cond)
        {
            List<ColIdName> Lst;
                Lst = conn.SelectColect2Proc("select * from vwprgn_edificio where idcond = " + cond);
                return Lst;
                  }

        public List<ColIdName> PRGN_PaisReg(int tip, int val)
        {
            List<ColIdName> Lst;
            string sql = "";

            if (tip == 0)
                sql = "vwprgn_pais";
            else if (tip == 1)
                sql = "vwprgn_region WHERE pais = " + val;

            Lst = conn.SelectColect2Proc("select * from " + sql);
            return Lst;
        }


        public List<ColIdName> PRGN_Orient()
        {
            List<ColIdName> Lst;
            Lst = conn.SelectColect2Proc("select * from tp_orientacion");
            return Lst;
        }

        public List<ColIdName> PRGN_Piso(int edef, int idcond)
        {
            List<ColIdName> Lst;
            Lst = conn.SelectColect2Proc("select * from vwprgn_piso where edef = " + edef + " and cond = " + idcond);
            return Lst;
        }

        public List<ColIdName> PRGN_TipoServ(int idcond)
        {
            List<ColIdName> Lst;
            Lst = conn.SelectColect2Proc("select * from vwprgn_tiposerv where cond = " + idcond);
            return Lst;
        }

    }
}
