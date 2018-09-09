using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data;

namespace ClssVmMdl.Calling
{
    class CallParmtGen
    {

        Conexion Conn;

        public CallParmtGen(string mod)
        {
            Conn = new Conexion(mod);
        }

        public DataTable SelParGnrl(int parm)
        {
            try
            {                
                DataTable dt;

                if (parm == 1)
                    dt = Conn.SelectGridProc("Select * FROM vwParGnrltpdep");
                else if (parm == 2)
                    dt = Conn.SelectGridProc("Select * FROM vwParGnrltpdepOt");
                else if (parm == 3)
                    dt = Conn.SelectGridProc("Select * FROM vwParGnrltpNot");
                else if (parm == 4)
                    dt = Conn.SelectGridProc("Select * FROM vwParGnrlNvlNot");
                else
                    dt = new DataTable();

                return dt;
            }
            catch (Exception ex) { }
            return null;
        }

        public void delParametro(int par, int val)
        {
            try
            {
                Conn.InsertSQLvar("call dl_parmtgnral (" + par + "," + val + ");");
            }
            catch (Exception ex) { }

        }

        public void savParametro(int par, string val)
        {
            try
            {
                Conn.InsertSQLvar("call sv_parmtgnral (" + par + ",'" + val + "');");
            }
            catch (Exception ex) { }

        }

        public void updParametro(int par, string val, int id)
        {
            try
            {
                Conn.InsertSQLvar("call up_parmtgnral ('" + val + "'," + par + "," + id + ");");
            }
            catch (Exception ex) { }

        }



    }
}
