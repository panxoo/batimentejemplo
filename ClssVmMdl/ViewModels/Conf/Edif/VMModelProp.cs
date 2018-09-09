using ClssVmMdl.Models.Conf.Edif;
using Prism.Mvvm;
using ClssVmMdl.Calling;
using Prism.Commands;
using ClssVmMdl.Models.Parametros;
using ClssVmMdl.Validacion;
using System.Collections.Generic;
using ClssVmMdl.VarStatic;
using System.Linq;
using System;

namespace ClssVmMdl.ViewModels.Conf.Edif
{
    public class VMModelProp : BindableBase
    {

        public VMModelProp()
        {
            mod = "mdpp";
            vargnrl = new MDVarGnrl();
            camp = new MDModelProp();
            calldp = new CallDep(mod);
            callvr = new CallVariables(mod);
            val = new ValElemment();
            MsgEv = new MsgEvents();

            camp.MultiEd = ParSistem.MultiEdef;

            DelSaveMod = new DelegateCommand<object>(ExcSaveMod);
            DelActUpdtMod = new DelegateCommand<object[]>(ExcActUpdtMod);
            DelDeletMod = new DelegateCommand<object[]>(ExcDeltMod);
            DelSelEdit = new DelegateCommand<object>(ExcDelSelEdit);
            DelDeletAct = new DelegateCommand<object>(ExcDeltAct);
            DelCloseMsgError = new DelegateCommand(ExcCloseMsgError);

            inicio();
        }


        #region Propiedades

        private CallVariables callvr;
        private CallDep calldp;
        private ValElemment val;
        private MsgEvents MsgEv;
        private string mod;

        public Action<int> SelPantalla { get; set; }

        public DelegateCommand<object> DelSelEdit { get; set; }
        public DelegateCommand<object> DelSaveMod { get; set; }
        public DelegateCommand<object[]> DelActUpdtMod { get; set; }
        public DelegateCommand<object[]> DelDeletMod { get; set; }
        public DelegateCommand<object> DelDeletAct { get; set; }
        public DelegateCommand DelCloseMsgError { get; set; }

        private MDVarGnrl vargnrl;
        public MDVarGnrl Vargnrl
        {
            get { return vargnrl; }
            set { SetProperty(ref vargnrl, value); }
        }

        private MDModelProp camp;
        public MDModelProp Camp
        {
            get { return camp; }
            set { SetProperty(ref camp, value); }
        }

        #endregion


        #region Command Execute

        private void ExcActUpdtMod(object[] parm)
        {
                   CargParametro(Convert.ToInt16(parm[0]));
            CargaUpdt(Convert.ToInt16(parm[0]), Convert.ToInt16(parm[1]));
        }


        private void ExcSaveMod(object parm)
        {
            MsgEvents MsgEv = new MsgEvents();
            //  MsgEv.MsgAlmacenar("", "0");
            AlmacModi(Convert.ToInt16(parm));
        }

        private void ExcDeltMod(object[] parm)
        {
            vargnrl.selDeci = true;
            camp.TpDel = Convert.ToInt16(parm[0]);
            camp.IdDel = (int)parm[1];
            vargnrl.MsgDesicion = mod + ";" + parm[2].ToString();
            //camp.EstDelAct = Convert.ToInt16(parm[2]);
        }

        private void ExcDeltAct(object parm)
        {
            if (Convert.ToBoolean(parm) == true)
            {
                DeltModel(camp.IdDel, camp.TpDel);
            }
            camp.TpDel = new int();
            camp.IdDel = new int();
            vargnrl.selDeci = false;
        }

        private void ExcDelSelEdit(object parm)
        {
            CargParametro(Convert.ToInt16(parm));
            SelPantalla(Convert.ToInt16(parm));
        }

        private void ExcCloseMsgError()
        {
            vargnrl.MsgError = "";
            vargnrl.selMsg = false;
        }

        #endregion


        #region Metodos

        private void inicio()
        {
            CargaTabGrd(-1);
            CargaTabGrd(1);
            CargaTabGrd(2);
        }

        private void CargParametro(int tp)
        {
            if (tp == 1)
            {
                vargnrl.tpdep = callvr.PRGN_tpdep(ParSistem.IdCond);
                //if (vargnrl.tpdep.Count > 0)
                    camp.didtpdep = -1;
            }
            if (ParSistem.MultiEdef == true)
            {
                vargnrl.edific = callvr.PRGN_Edif(ParSistem.IdCond);
                if (vargnrl.edific.Count > 0)
                    switch (tp)
                    {
                        case 1:
                            camp.diddep = -1;
                            break;
                        case 2:
                            camp.eiddep = -1;
                            break;
                        case 3:
                            camp.biddep = -1;
                            break;
                    }
            }
        }

        private void CargaTabGrd(int tp)
        {
            switch (tp)
            {
                case 2:
                    camp.tabbod = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
                case 1:
                    camp.tabest = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
                case -1:
                    camp.tabed = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
            }
        }

        private void CargaUpdt(int tp, int id)
        {
            camp.idMod = id;
            camp.UpdtAct = true;

            switch (tp)
            {
                case -1:

                    foreach (var c in camp.tabed.Select("id = " + id))
                    {
                        if (vargnrl.tpdep.Any(p => p.Id == (int)c["id_tp"]))
                            camp.didtpdep = Convert.ToInt32(c["id_tp"]);
                        else
                            camp.didtpdep = vargnrl.tpdep[0].Id;

                        if (ParSistem.MultiEdef == true)
                            if (vargnrl.edific.Any(p => p.Id == Convert.ToInt16(c["id_ed"])))
                                camp.diddep = Convert.ToInt32(c["id_ed"]);
                            else
                                camp.diddep = vargnrl.edific[0].Id;

                        camp.dnom = c["name"].ToString();
                        camp.dban = Convert.ToInt32(c["bano"]);
                        camp.ddor = Convert.ToInt32(c["pieza"]);
                        camp.dtamall = Convert.ToDouble(c["tamtot"]);
                        camp.dtamut = Convert.ToDouble(c["tamuti"]);
                    }
                    break;

                case 1:

                    foreach (var c in camp.tabest.Select("id = " + id + " and tp = 1"))
                    {
                        if (ParSistem.MultiEdef == true)
                        {
                            camp.econdsel = Convert.ToInt16(c["cond"]);

                            if (vargnrl.edific.Any(p => p.Id == Convert.ToInt16(c["id_ed"])) && camp.econdsel == 0)
                                camp.eiddep = Convert.ToInt16(c["id_ed"]);
                            else
                                camp.eiddep = vargnrl.edific[0].Id;
                        }
                        else
                            camp.econdsel = 1;

                        camp.enom = c["name"].ToString();
                        camp.etam = Convert.ToDouble(c["tam"]);
                    }
                    break;

                default:

                    foreach (var c in camp.tabbod.Select("id = " + id + " and tp = 2"))
                    {
                        if (ParSistem.MultiEdef == true)
                        {
                            camp.bcondsel = Convert.ToInt16(c["cond"]);

                            if (vargnrl.edific.Any(p => p.Id == Convert.ToInt16(c["id_ed"])) && camp.bcondsel == 0)
                                camp.biddep = Convert.ToInt32(c["id_ed"]);
                            else
                                camp.biddep = vargnrl.edific[0].Id;
                        }
                        else
                            camp.bcondsel = 1;

                        camp.bnom = c["name"].ToString();
                        camp.btam = Convert.ToDouble(c["tam"]);
                    }
                    break;
            }
        }


        private void AlmacModi(int Tp)
        {
            string rsp = "";
            int aux_idDep;

            switch (Tp)
            {

                case 2://Bod

                    if ((val.EmptyStrg(new List<string>(new string[] { camp.bnom }))) && (val.NumMayCero(new List<double>(new double[] { camp.btam })))
                       && (camp.bcondsel == 1 || vargnrl.edific.Count > 0))
                    {
                        if (camp.bcondsel == 1) aux_idDep = 0;
                        else aux_idDep = camp.biddep;
                        if (camp.UpdtAct == false)
                            rsp = calldp.MDPP_SvtModOtro(Tp, camp.bnom.ToString().Trim(), camp.btam, aux_idDep, camp.bcondsel, ParSistem.IdCond);
                        else
                            rsp = calldp.MDPP_SvtModOtro(camp.bnom.ToString().Trim(), camp.btam, aux_idDep, camp.bcondsel, camp.idMod, ParSistem.IdCond, Tp);
                    }
                    else
                        rsp = "2";

                    break;

                case 1: //Est

                    if ((val.EmptyStrg(new List<string>(new string[] { camp.enom }))) && (val.NumMayCero(new List<double>(new double[] { camp.etam })))
                        && (camp.econdsel == 1 || vargnrl.edific.Count > 0))
                    {
                        if (camp.econdsel == 1) aux_idDep = 0;
                        else aux_idDep = camp.eiddep;
                        if (camp.UpdtAct == false)
                            rsp = calldp.MDPP_SvtModOtro(Tp, camp.enom.ToString().Trim(), camp.etam, aux_idDep, camp.econdsel, ParSistem.IdCond);
                        else
                            rsp = calldp.MDPP_SvtModOtro(camp.enom.ToString().Trim(), camp.etam, aux_idDep, camp.econdsel, camp.idMod, ParSistem.IdCond, Tp);
                    }
                    else
                        rsp = "2";

                    break;

                case -1: //Dep

                    if ((val.EmptyStrg(new List<string>(new string[] { camp.dnom }))) && (val.NumMayCero(new List<int>(new int[] { camp.dban })))
                        && (val.NumMayCero(new List<double>(new double[] { camp.dtamut, camp.dtamall }))) && vargnrl.edific.Count > 0 && vargnrl.tpdep.Count > 0)
                    {
                        if (camp.UpdtAct == false)
                            rsp = calldp.SvtModDep(camp.diddep, camp.didtpdep, camp.dnom.ToString().Trim(), camp.ddor, camp.dban, camp.dtamall, camp.dtamut, ParSistem.IdCond);
                        else
                            rsp = calldp.SvtModDep(camp.idMod, camp.diddep, camp.didtpdep, camp.dnom.ToString().Trim(), camp.ddor, camp.dban, camp.dtamall, camp.dtamut, ParSistem.IdCond);
                    }
                    else
                        rsp = "2";

                    break;
            }


            if (rsp == "1")
            {
                CargaTabGrd(Tp);
                ExcDelSelEdit(0);
                MsgEv.MsgAlmacenar(mod, rsp);
            }
            else
            {
                MsgEv.MsgAlmacenar(mod, rsp);
                vargnrl.MsgError = mod + ";" + rsp;
                vargnrl.selMsg = true;
            }

        }



        private void DeltModel(int id, int tp)
        {

            List<object> Lst = new List<object>();
            string a;

            switch (tp)
            {
                case -1:

                    foreach (var c in camp.tabed.Select("id = " + id))
                    {
                        Lst.Add(c["id_ed"]);
                        Lst.Add(c["idCond"]);
                        Lst.Add(c["name"]);
                    }

                    a = calldp.SvtModDep(id, Convert.ToInt16(Lst[0]), Convert.ToInt16(Lst[1]), Lst[2].ToString());
                    break;

                case 1:

                    foreach (var c in camp.tabest.Select("id = " + id + " and tp = " + tp))
                    {
                        Lst.Add(c["id_ed"]);
                        Lst.Add(c["idCond"]);
                        Lst.Add(c["name"]);
                        Lst.Add(c["cond"]);
                    }

                    a = calldp.MDPP_SvtModOtro(id, Convert.ToInt16(Lst[0]), Convert.ToInt16(Lst[1]), Lst[2].ToString(), tp, Convert.ToInt16(Lst[3]));
                    break;


                default:


                    foreach (var c in camp.tabbod.Select("id = " + id + " and tp = " + tp))
                    {
                        Lst.Add(c["id_ed"]);
                        Lst.Add(c["idCond"]);
                        Lst.Add(c["name"]);
                        Lst.Add(c["cond"]);
                    }

                    a = calldp.MDPP_SvtModOtro(id, Convert.ToInt16(Lst[0]), Convert.ToInt16(Lst[1]), Lst[2].ToString(), tp, Convert.ToInt16(Lst[3]));
                    break;

            }
            Lst.Clear();

            if (a == "1")
            {
                CargaTabGrd(tp);
                ExcDelSelEdit(0);
                MsgEv.MsgAlmacenar("mdpp", a);
            }
            else
            {
                ExcDelSelEdit(0);
                MsgEv.MsgAlmacenar("mdpp", a);
                vargnrl.MsgError = mod + ";" + a;
                vargnrl.selMsg = true;
            }
        }


        #endregion
    }
}
