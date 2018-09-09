using System;
using System.Collections.Generic;
using Prism.Mvvm;
using Prism.Commands;
using ClssVmMdl.Models.Conf.Servicios;
using ClssVmMdl.Calling;
using ClssVmMdl.Validacion;
using ClssVmMdl.Models.Parametros;
using ClssVmMdl.VarStatic;
using ClssTool;

namespace ClssVmMdl.ViewModels.Conf.Servicios
{
    public class VMTipoServicios : BindableBase
    {

        public VMTipoServicios()
        {
            mod = "tpsv";
            camp = new MDTipoServicios();
            callsrv = new CallServicios(mod);
            vargnrl = new MDVarGnrl();
            msgev = new MsgEvents();
            vali = new ValElemment();

            DelAddTpSrv = new DelegateCommand(ExcAddTpSrv);
            DelUpdTpSrv = new DelegateCommand<object>(ExcUpdTpSrv);
            DelCanTpSrv = new DelegateCommand(ExcCanTpSrv);
            DelRmvTpSrv = new DelegateCommand<object[]>(ExcRmvTpSrv);
            DelSavTpSrv = new DelegateCommand<object>(ExcSavTpSrv);

            CargaGrillTpServ();
        }

        #region Property

        private MDTipoServicios camp;
        public MDTipoServicios Camp
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
        private string mod;
        private MsgEvents msgev;
        private ValElemment vali;

        public DelegateCommand DelAddTpSrv { get; set; }
        public DelegateCommand<object> DelUpdTpSrv { get; set; }
        public DelegateCommand DelCanTpSrv { get; set; }
        public DelegateCommand<object[]> DelRmvTpSrv { get; set; }
        public DelegateCommand<object> DelSavTpSrv { get; set; }

        public System.Action<bool> ActUpdate { get; set; }
        public System.Action ActDesicion { get; set; }
        public System.Action ActError { get; set; }

        #endregion


        #region Execute

        private void ExcAddTpSrv()
        {
            camp.ModAdd = true;
            camp.AltGrid = 200;
            ActUpdate(true);
        }

        private void ExcUpdTpSrv(object Tp)
        {
            CargaUpdt(Convert.ToInt32(Tp));
            ActUpdate(true);
            camp.AltGrid = 200;

        }

        private void ExcCanTpSrv()
        {
            CancelarMod();
            ActUpdate(false);
            camp.AltGrid = 400;

        }

        private void ExcRmvTpSrv(object[] Tp)
        {
            vargnrl.MsgDesicion = mod + ";" + Tp[0].ToString();
            camp.IdTS = Convert.ToInt32(Tp[1]);
            ActDesicion();
        }

        private void ExcSavTpSrv(object tp)
        {
            Almacenar(Convert.ToInt16(tp));
        }

        private void ExcCloseMsgError()
        {
            vargnrl.selMsg = false;
            vargnrl.MsgError = "";
        }

        public void ExcDelectAct(bool tp)
        {
            if (tp)
                RmvAlmacenar();

            vargnrl.MsgDesicion = "";
            camp.IdTS = new int();
        }
        #endregion


        #region Metodo

        private void CargaGrillTpServ()
        {
            camp.DtTpSrv = callsrv.TPSV_CargaGrillaTpSrv(ParSistem.IdCond);
        }

        private void CancelarMod()
        {
            camp.ModAdd = false;
            LimpCamp();
        }

        private void LimpCamp()
        {
            camp.IdTS = new int();
            camp.NomTS = "";
            camp.Cobro = new int();
            camp.RqReserv = false;
            camp.ResDocum = false;
            camp.ResEfec = false;
            camp.ResTrans = false;
            camp.ResCobTot = false;
            camp.ResCobMont = new int();
            camp.RqGarant = false;
            camp.GarValor = new int();
            camp.GcCobro = false;
            camp.SeCobra = false;
            camp.ActUpdt = false;
        }

        private void CargaUpdt(int IdTp)
        {
            try
            {
                camp.ActUpdt = true;
                camp.ModAdd = true;

                foreach (var c in camp.DtTpSrv.Select("Id = " + IdTp))
                {
                    camp.IdTS = IdTp;
                    camp.NomTS = c["Name"].ToString();
                    camp.SeCobra = Convert.ToBoolean(c["rqcobro"]);
                    camp.Cobro = (int)c["Cob"];
                    camp.RqReserv = Convert.ToBoolean(c["RqRsrv"]);
                    camp.ResDocum = Convert.ToBoolean(c["ResDoc"]);
                    camp.ResEfec = Convert.ToBoolean(c["ResEfc"]);
                    camp.ResTrans = Convert.ToBoolean(c["ResTra"]);
                    camp.ResCobTot = Convert.ToBoolean(c["ResCtt"]);
                    camp.ResCobMont = (int)c["ResCMn"];
                    camp.RqGarant = Convert.ToBoolean(c["RqGaran"]);
                    camp.GarValor = (int)c["GrMont"];
                    camp.GcCobro = Convert.ToBoolean(c["CobGC"]);
                }
            }
            catch (Exception ex)
            {
                ClLog.logger.Error("cgup-" + mod + "-" + ex);
            }

        }

        private void Almacenar(int tp)
        {
            string a = "";

            if (vali.EmptyStrg(new List<string> { camp.NomTS }) == false || (camp.SeCobra == true && vali.NumMayCero(new List<int> { camp.Cobro }) == false))
            {
                a = "2";
            }

            if (camp.SeCobra == true && camp.RqReserv == true && camp.ResDocum == false && camp.ResEfec == false && camp.ResTrans == false)
            {
                if (a == "")
                    a = "3";
                else
                    a = a + ";3";
            }

            if (camp.SeCobra == true && camp.RqReserv == true && camp.ResCobTot == true && vali.NumMayCero(new List<int> { camp.ResCobMont }) == false)
            {
                if (a == "")
                    a = "4";
                else
                    a = a + ";4";
            }

            if (camp.SeCobra == true && camp.RqReserv == false && camp.GcCobro == false)
            {
                if (a == "")
                    a = "5";
                else
                    a = a + ";5";
            }

            if (camp.RqGarant == true && vali.NumMayCero(new List<int> { camp.GarValor }) == false)
            {
                if (a == "")
                    a = "6";
                else
                    a = a + ";6";
            }

            if (camp.SeCobra == true && camp.RqReserv == true && camp.ResCobTot == true && camp.GcCobro == false)
            {
                if (a == "")
                    a = "7";
                else
                    a = a + ";7";
            }

            if (camp.SeCobra == true && camp.RqReserv == true && camp.ResCobTot == true && !(camp.ResCobMont < camp.Cobro))
            {
                if (a == "")
                    a = "8";
                else
                    a = a + ";8";
            }

            if (a == "")
            {

                if (camp.ActUpdt == false)
                    a = callsrv.TPSV_SaveTpSrv(ParSistem.IdCond, ParSistem.UsrSes, camp.NomTS.Trim(), camp.SeCobra, camp.Cobro, camp.RqGarant, camp.GarValor, camp.GcCobro, camp.RqReserv, camp.ResCobTot, camp.ResCobMont, camp.ResDocum, camp.ResEfec, camp.ResTrans);
                else
                    a = callsrv.TPSV_SaveTpSrv(camp.IdTS, ParSistem.IdCond, ParSistem.UsrSes, camp.NomTS.Trim(), camp.SeCobra, camp.Cobro, camp.RqGarant, camp.GarValor, camp.GcCobro, camp.RqReserv, camp.ResCobTot, camp.ResCobMont, camp.ResDocum, camp.ResEfec, camp.ResTrans);
            }

            MnsjEvent(a, tp);

        }

        private void RmvAlmacenar()
        {
            string a = "";
            a = callsrv.TPSV_RmvTpSrv(camp.IdTS, ParSistem.IdCond, ParSistem.UsrSes);

            MnsjEvent(a, 3);
        }


        private void MnsjEvent(string a, int tp)
        {
            msgev.MsgAlmacenar(mod, a);

            if (a == "1")
            {
                if (tp == 0)
                    camp.ModAdd = false;
                LimpCamp();
                CargaGrillTpServ();
                camp.AltGrid = 400;

            }
            else
            {
                vargnrl.MsgError = mod + ";" + a;
                ActError();
            }
        }




        #endregion

    }
}
