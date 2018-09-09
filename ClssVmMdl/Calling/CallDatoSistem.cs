using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Collections;
using AccesoDatos.TypeVar;

namespace ClssVmMdl.Calling
{
    public class CallDatoSistem
    {
        Conexion conn;

        public CallDatoSistem(string mod)
        {
            conn = new Conexion(mod);
        }

        public ArrayList SIST_ParamCond()
        {
            try
            {
                ArrayList res;
                res = conn.SelectColectProc("select * from vwsist_parmcond");
                return res;
            }
            catch (Exception ex)
            { return null; }
        }

        public List<ColIdNameTip> SIST_DepartColect(int cond, bool MltEdf)
        {
            try
            {
                List<ColIdNameTip> Colc;
                string Sql;
                if (MltEdf == true)
                    Sql = "select * from vwsist_parmdep where cond = " + cond;
                else
                    Sql = "select * from vwsist_parmdep where cond = " + cond + " and tip = 1";
                Colc = conn.SelectColect3Proc(Sql);
                return Colc;
            }
            catch (Exception ex)
            { return null; }
        }
    }
}
