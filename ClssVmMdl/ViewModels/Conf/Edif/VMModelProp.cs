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

            camp.MultEdf = ParSistem.MultiEdef;

            DelSelEdit = new DelegateCommand<object>(ExcDelSelEdit);
            DelActUpdtMod = new DelegateCommand<object[]>(ExcActUpdtMod);
            DelSaveMod = new DelegateCommand<object>(ExcSaveMod);
            DelDeletMod = new DelegateCommand<object[]>(ExcDeltMod);
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
            get => vargnrl;
            set => SetProperty(ref vargnrl, value);
        }

        private MDModelProp camp;
        public MDModelProp Camp
        {
            get => camp;
            set => SetProperty(ref camp, value);
        }

        #endregion


        #region Command Execute

        private void ExcDelSelEdit(object parm)
        {
            CargParametro(Convert.ToInt16(parm));
            SelPantalla(Convert.ToInt16(parm));
        }

        private void ExcActUpdtMod(object[] parm)
        {
            CargParametro(Convert.ToInt16(parm[0]));
            CargaUpdt(Convert.ToInt16(parm[0]), Convert.ToInt16(parm[1]));
        }


        private void ExcSaveMod(object parm)
        {
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
                Vargnrl.Tpdep = callvr.PRGN_tpdep(ParSistem.IdCond);
                //if (vargnrl.tpdep.Count > 0)
            }

            if (ParSistem.MultiEdef == true)
            {
                Vargnrl.Edific = callvr.PRGN_Edif(ParSistem.IdCond);
                Camp.Idedf = -1;
            }
        }

        private void CargaTabGrd(int tp)
        {
            switch (tp)
            {
                case 2:
                    camp.Tabbod = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
                case 3:
                    camp.Tabest = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
                case 1:
                    camp.Tabed = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
            }
        }

        private void CargaUpdt(int tp, int id)
        {
            Camp.IdModSel = id;
            Camp.UpdtAct = true;

            switch (tp)
            {
                case 1:

                    foreach (var c in camp.Tabed.Select("id = " + id))
                    {
                        if (vargnrl.Tpdep.Any(p => p.Id == (int)c["id_tp"]))
                            Camp.Idtpedf = Convert.ToInt32(c["id_tp"]);
                        else
                            Camp.Idtpedf = vargnrl.Tpdep[0].Id;

                        if (Camp.MultEdf == true)
                            if (vargnrl.Edific.Any(p => p.Id == Convert.ToInt16(c["id_ed"])))
                                Camp.Idedf = Convert.ToInt32(c["id_ed"]);
                            else
                                Camp.Idedf = vargnrl.Edific[0].Id;

                        Camp.Nomb = c["name"].ToString();
                        Camp.Cantban = Convert.ToInt32(c["bano"]);
                        Camp.Cantdor = Convert.ToInt32(c["pieza"]);
                        Camp.Tamall = Convert.ToDouble(c["tamtot"]);
                        Camp.Tamut = Convert.ToDouble(c["tamuti"]);
                    }
                    break;

                case 3:

                    foreach (var c in camp.Tabest.Select("id = " + id + " and tp = 1"))
                    {
                        if (Camp.MultEdf == true)
                        {
                            Camp.Condsel = Convert.ToBoolean(c["cond"]);

                            if (vargnrl.Edific.Any(p => p.Id == Convert.ToInt16(c["id_ed"])) && camp.Condsel == false)
                                camp.Idedf = Convert.ToInt16(c["id_ed"]);
                            else
                                camp.Idedf = vargnrl.Edific[0].Id;
                        }
                        else
                            camp.Condsel = true;

                        camp.Nomb = c["name"].ToString();
                        camp.Tamall = Convert.ToDouble(c["tam"]);
                    }
                    break;

                default:

                    foreach (var c in camp.Tabbod.Select("id = " + id + " and tp = 2"))
                    {
                        if (Camp.MultEdf == true)
                        {
                            camp.Condsel = Convert.ToBoolean(c["cond"]);

                            if (vargnrl.Edific.Any(p => p.Id == Convert.ToInt16(c["id_ed"])) && camp.Condsel == false)
                                camp.Idedf = Convert.ToInt32(c["id_ed"]);
                            else
                                camp.Idedf = vargnrl.Edific[0].Id;
                        }
                        else
                            camp.Condsel = true;

                        camp.Nomb = c["name"].ToString();
                        camp.Tamall = Convert.ToDouble(c["tam"]);
                    }
                    break;
            }
        }


        private void AlmacModi(int Tp)
        {
            string a = "";

            switch (Tp)
            {

                case 2://Bod

                    if ((val.EmptyStrg(new List<string>(new string[] { camp.bnom }))) && (val.NumMayCero(new List<double>(new double[] { camp.btam })))
                       && (camp.bcondsel == 1 || vargnrl.edific.Count > 0))
                    {
                        if (camp.bcondsel == 1) aux_idDep = 0;
                        else aux_idDep = camp.biddep;
                        if (camp.UpdtAct == false)
                            a = calldp.MDPP_SvtModOtro(Tp, camp.bnom.ToString().Trim(), camp.btam, aux_idDep, camp.bcondsel, ParSistem.IdCond);
                        else
                            a = calldp.MDPP_SvtModOtro(camp.bnom.ToString().Trim(), camp.btam, aux_idDep, camp.bcondsel, camp.idMod, ParSistem.IdCond, Tp);
                    }
                    else
                        a = "2";

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
