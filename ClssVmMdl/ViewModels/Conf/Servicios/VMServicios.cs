using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClssVmMdl.Models.Conf.Servicios;
using ClssVmMdl.Models.Parametros;
using ClssVmMdl.Calling;
using Prism.Mvvm;
using Prism.Commands;
using ClssVmMdl.Validacion;
using ClssVmMdl.VarStatic;
using ClssTool;
using System.Collections;
using System.Data;

namespace ClssVmMdl.ViewModels.Conf.Servicios
{
    public class VMServicios : BindableBase
    {

        public VMServicios()
        {
            mod = "srvi";
            vargnrl = new MDVarGnrl();
            camp = new MDServicios();
            callsrv = new CallServicios(mod);
            callvar = new CallVariables(mod);
            msgev = new MsgEvents();
            vali = new ValElemment();
            CargaIni();

            DelSelctTpSrv = new DelegateCommand(ExcSelctTpSrv);
            DelAlmacenar = new DelegateCommand<object>(ExcAlmacenar);
            DelCancelar = new DelegateCommand(ExcCancelar);
            DelAgregar = new DelegateCommand(ExcAgregar);
            DelUpdate = new DelegateCommand<object>(ExcUpdate);
            DelDeleteMsg = new DelegateCommand<object[]>(ExcDeleteMsg);
            DelDeletAct = new DelegateCommand<object>(ExcDeltAct);
            DelCloseMsgError = new DelegateCommand(ExcCloseMsgError);
        }


        #region Property

        private MDServicios camp;
        public MDServicios Camp
        {
            get => camp;
            set => SetProperty(ref camp, value);
        }

        private MDVarGnrl vargnrl;
        public MDVarGnrl Vargnrl
        {
            get => vargnrl;
            set => SetProperty(ref vargnrl, value);
        }

        private CallServicios callsrv;
        private CallVariables callvar;

        private MsgEvents msgev;
        private ValElemment vali;
        private string mod;

        public DelegateCommand DelSelctTpSrv { get; set; }
        public DelegateCommand<object> DelAlmacenar { get; set; }
        public DelegateCommand DelCancelar { get; set; }
        public DelegateCommand DelAgregar { get; set; }
        public DelegateCommand<object> DelUpdate { get; set; }
        public DelegateCommand<object[]> DelDeleteMsg { get; set; }
        public DelegateCommand<object> DelDeletAct { get; set; }
        public DelegateCommand DelCloseMsgError { get; set; }

        #endregion

        #region Execute

        private void ExcSelctTpSrv()
        {
            CargaGrillaTpSrv();
        }

        private void ExcAlmacenar(object ac)
        {
            Almacenar(Convert.ToInt16(ac));
        }

        private void ExcCancelar()
        {
            camp.ModAdd = false;
            camp.UpdtAct = false;
            camp.UpdtInt = new int();
        }

        private void ExcAgregar()
        {
            camp.ModAdd = true;
        }

        private void ExcUpdate(object id)
        {
            CargaUpdt(int.Parse(id.ToString()));
            camp.ModAdd = true;
        }

        private void ExcDeleteMsg(object[] parm)
        {
            vargnrl.selDeci = true;
            camp.IdDelt = (int)parm[0];
            vargnrl.MsgDesicion = mod + ";" + parm[1].ToString();
        }

        private void ExcDeltAct(object parm)
        {
            if (Convert.ToBoolean(parm) == true)
            {
                Eliminar();
            }

            vargnrl.MsgDesicion = "";
            vargnrl.selDeci = false;
        }

        private void ExcCloseMsgError()
        {
            vargnrl.MsgError = "";
            vargnrl.selMsg = false;
        }


        #endregion

        #region Metodo

        private void CargaIni()
        {

            vargnrl.Tpserv = callvar.PRGN_TipoServ(ParSistem.IdCond);

            if (vargnrl.Tpserv.Count() > 0)
            {
                camp.IdMinTp = vargnrl.Tpserv.Min(P => P.Id);
            }

            CargaGrillaTpSrv();

            if (ParSistem.MultiEdef == true)
            {
                vargnrl.Edific = callvar.PRGN_Edif(ParSistem.IdCond);
            }
            else
            {
                vargnrl.Edific = new List<AccesoDatos.TypeVar.ColIdName>();
            }

            if (vargnrl.Edific.Count() > 0)
            {
                camp.IdMinEd = vargnrl.Edific.Min(p => p.Id);
            }

            camp.DtServ = callsrv.SRVI_Servicios(ParSistem.IdCond);

            vargnrl.MultEdf = ParSistem.MultiEdef;
        }


        private void CargaGrillaTpSrv()
        {
            camp.DtTpSrv = callsrv.SRVI_DetalleTpServicio(ParSistem.IdCond, camp.IdTpsrv);

            Camp.CostAct = Convert.ToBoolean(camp.DtTpSrv.Rows[0].ItemArray[2]);
            camp.CostValAct = Convert.ToInt32(camp.DtTpSrv.Rows[0].ItemArray[3]);
        }


        private void CargaUpdt(int Id)
        {
            try
            {
                camp.UpdtAct = true;
                camp.UpdtInt = Id;

                DataRow rw = camp.DtServ.Select("Id = " + Id).First();

                camp.CondUs = Convert.ToBoolean(rw["condus"]);
                camp.Idedf = Convert.ToInt16(rw["idedf"]);
                camp.Nomsrv = rw["nom"].ToString();
                if (vargnrl.Tpserv.Exists(P => P.Id == int.Parse(rw["idtpsrv"].ToString())))
                {
                    camp.IdTpsrv = int.Parse(rw["idtpsrv"].ToString());
                }
                else
                {
                    camp.IdTpsrv = vargnrl.Tpserv.Min(p => p.Id);
                }
                camp.Costfj = Convert.ToBoolean(rw["costfj"]);
                camp.CostFjval = Convert.ToInt32(rw["costfjval"]);
                camp.CostFjd = Convert.ToBoolean(rw["costfjd"]);
                camp.CostFjm = Convert.ToBoolean(rw["costfjm"]);

                camp.CostUso = Convert.ToBoolean(rw["costuso"]);
                camp.CostUsval = Convert.ToInt32(rw["costusval"]);

                CargaGrillaTpSrv();

            }
            catch (Exception ex)
            {
                ClLog.logger.Error("cgup-" + mod + "-" + ex);
            }


        }


        private void Almacenar(int Act)
        {
            string a = "";

            if (vali.EmptyStrg(new List<string> { camp.Nomsrv }) == false)
            {
                a = "2";
            }

            if (camp.Costfj == true && (vali.NumMayCero(new List<int> { camp.CostFjval }) == false))
            {
                if (a == "")
                    a = "3";
                else
                    a = a + ";3";
            }

            if (camp.CostUso == true && vali.NumMayCero(new List<int> { camp.CostUsval }) == false)
            {
                if (a == "")
                    a = "4";
                else
                    a = a + ";4";
            }

            if (a == "")
            {
                int edf;
                if (camp.CondUs == true)
                    edf = ParSistem.IdCondEdf;
                else
                    edf = camp.Idedf;

                if (camp.UpdtAct == false)
                    a = callsrv.SRVI_Almacenar(ParSistem.IdCond, edf, camp.IdTpsrv, camp.Nomsrv.Trim(), camp.Costfj, camp.CostFjval, camp.CostFjd, camp.CostFjm, camp.CostUso, camp.CostUsval, camp.CondUs);
                else
                    a = callsrv.SRVI_Almacenar(camp.UpdtInt, ParSistem.IdCond, edf, camp.Nomsrv.Trim(), camp.Costfj, camp.CostFjval, camp.CostFjd, camp.CostFjm, camp.CostUso, camp.CostUsval);
            }

            Mensaje(a, 0);
        }

        private void Eliminar()
        {
            string a = "";

            a = callsrv.SRVI_Delserv(camp.IdDelt, ParSistem.IdCond);

            Mensaje(a, 1);
        }

        private void Mensaje(string a, int tp)
        {
            if (a == "1")
            {
                camp.DtServ = callsrv.SRVI_Servicios(ParSistem.IdCond);
                msgev.MsgAlmacenar(mod, a);
                if (tp == 1)
                {

                }
            }
            else
            {

                msgev.MsgAlmacenar(mod, a);
                vargnrl.MsgError = mod + ";" + a;
                vargnrl.selMsg = true;
            }

        }

        #endregion

    }
}
