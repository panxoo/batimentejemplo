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
using System.Data;

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


            DelSelEdit = new DelegateCommand<object>(ExcDelSelEdit);
            DelActUpdtMod = new DelegateCommand<object[]>(ExcActUpdtMod);
            DelSaveMod = new DelegateCommand<object>(ExcSaveMod);
            DelDeletMod = new DelegateCommand<object[]>(ExcDeltMod);

            inicio();
        }


        #region Propiedades

        private CallVariables callvr;
        private CallDep calldp;
        private ValElemment val;
        private MsgEvents MsgEv;
        private string mod;

        public Action<int> SelPantalla { get; set; }
        public Action<string, string> ActDesicion { get; set; }
        public Action<string, string> ActError { get; set; }

        public DelegateCommand<object> DelSelEdit { get; set; }
        public DelegateCommand<object> DelSaveMod { get; set; }
        public DelegateCommand<object[]> DelActUpdtMod { get; set; }
        public DelegateCommand<object[]> DelDeletMod { get; set; }

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
            LimpGnrl();

            if (Convert.ToInt16(parm) != 0)
                CargParametro(Convert.ToInt16(parm));

            SelPantalla(Convert.ToInt16(parm));
        }

        private void ExcActUpdtMod(object[] parm)
        {
            CargParametro(Convert.ToInt16(parm[0]));
            CargaUpdt(Convert.ToInt16(parm[0]), Convert.ToInt16(parm[1]));
            SelPantalla(Convert.ToInt16(parm[0]));
        }


        private void ExcSaveMod(object parm)
        {
            AlmacModi(Convert.ToInt16(parm));
        }

        private void ExcDeltMod(object[] parm)
        {
            Camp.IdTpModSel = Convert.ToInt32(parm[1]);
            Camp.VigenteIdSel = Convert.ToBoolean(parm[2]);
            camp.TpModSel = Convert.ToInt16(parm[0]);
            ActDesicion(mod, mod + ";" + parm[2].ToString());
        }

        public void ExcDeltAct(bool parm)
        {
            if (parm == true)
            {
                DeltModel(camp.IdTpModSel, camp.TpModSel);
            }
        }


        #endregion


        #region Metodos

        private void inicio()
        {
            CargaTabGrd(-1);
            CargaTabGrd(2);
            CargaTabGrd(1);

            vargnrl.MultEdf = ParSistem.MultiEdef;
        }

        private void CargParametro(int tp)
        {
            if (tp == -1)
            {
                Vargnrl.Tpdep = callvr.PRGN_tpdep(ParSistem.IdCond);
                Camp.Idtpedf = -1;
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
                case 1:
                    camp.Tabest = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
                case -1:
                    camp.Tabed = calldp.MDPP_SelModelGrd(tp, ParSistem.IdCond);
                    break;
            }
        }

        private void CargaUpdt(int tp, int id)
        {
            Camp.IdTpModSel = id;
            Camp.UpdtAct = true;

            switch (tp)
            {
                case -1:

                    foreach (DataRow c in camp.Tabed.Select("id = " + id))
                    {
                        if (vargnrl.Tpdep.Any(p => p.Id == (int)c["id_tp"]))
                            Camp.Idtpedf = Convert.ToInt32(c["id_tp"]);
                        else
                            Camp.Idtpedf = -1;

                        if (vargnrl.MultEdf == true)
                            if (vargnrl.Edific.Any(p => p.Id == Convert.ToInt16(c["id_ed"])))
                                Camp.Idedf = Convert.ToInt32(c["id_ed"]);
                            else
                                Camp.Idedf = -1;

                        Camp.Nomb = c["name"].ToString();
                        Camp.Cantban = Convert.ToInt32(c["bano"]);
                        Camp.Cantdor = Convert.ToInt32(c["pieza"]);
                        Camp.Tamall = Convert.ToDouble(c["tamtot"]);
                        Camp.Tamut = Convert.ToDouble(c["tamuti"]);
                    }
                    break;

                case 2:

                    foreach (DataRow c in camp.Tabest.Select("id = " + id + " and tp = 1"))
                    {
                        CargaOtro(c);
                    }
                    break;

                default:

                    foreach (var c in camp.Tabbod.Select("id = " + id + " and tp = 2"))
                    {
                        CargaOtro(c);
                    }
                    break;
            }
        }


        private void CargaOtro(DataRow c)
        {
            if (vargnrl.MultEdf == true)
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


        private void AlmacModi(int Tp)
        {
            string a = "";


            if (val.EmptyStrg(new List<string>(new string[] { camp.Nomb })) == false || val.NumMayCero(new List<double>(new double[] { camp.Tamall })) == false)
                a = "2";


            if (Tp == -1) //Dep
            {
                if (val.NumMayCero(new List<int>(new int[] { camp.Cantban, camp.Cantdor })) == false
                    || val.NumMayCero(new List<double>(new double[] { camp.Tamut })) == false || camp.Idtpedf == -1 || camp.Idedf == -1)
                    a = "2";

                if (camp.Tamall < Camp.Tamut)
                {
                    if (a == "")
                        a = "4";
                    else
                        a = a + ";4";
                }
            }
            else
            {
                if (camp.Condsel == false && camp.Idedf == -1)
                    a = "2";
            }


            if (a == "")
            {
                int aux_idEdf;

                if ((vargnrl.MultEdf == false || camp.Condsel == true) && Tp != -1)
                    aux_idEdf = ParSistem.IdCondEdf;
                else if (vargnrl.MultEdf == true && Tp == -1)
                    aux_idEdf = camp.Idedf;
                else
                    aux_idEdf = camp.Idedf;


                if (camp.UpdtAct == true)
                {
                    if (Tp == -1)
                        a = calldp.SvtModDep(camp.IdTpModSel, aux_idEdf, camp.Idtpedf, camp.Nomb.ToString().Trim(), camp.Cantdor, camp.Cantban, camp.Tamall, camp.Tamut, ParSistem.IdCond);
                    else
                        a = calldp.MDPP_SvtModOtro(camp.Nomb.ToString().Trim(), camp.Tamall, aux_idEdf, camp.Condsel, camp.IdTpModSel, ParSistem.IdCond, Tp);

                }
                else
                {
                    if (Tp == -1)
                        a = calldp.SvtModDep(aux_idEdf, camp.Idtpedf, camp.Nomb.ToString().Trim(), camp.Cantdor, camp.Cantban, camp.Tamall, camp.Tamut, ParSistem.IdCond);
                    else
                        a = calldp.MDPP_SvtModOtro(Tp, camp.Nomb.ToString().Trim(), camp.Tamall, aux_idEdf, camp.Condsel, ParSistem.IdCond);
                }

            }

            Mensaje(a, Tp, Convert.ToInt16(camp.UpdtAct));
        }



        private void DeltModel(int id, int tp)
        {

            List<object> Lst = new List<object>();
            string a;

            switch (tp)
            {
                case -1:

                    foreach (var c in camp.Tabed.Select("id = " + id))
                    {
                        Lst.Add(c["id_ed"]);
                        Lst.Add(c["name"]);
                    }

                    a = calldp.SvtModDep(id, Convert.ToInt16(Lst[0]), Convert.ToInt16(Lst[1]), Lst[2].ToString());
                    break;

                case 1:

                    foreach (var c in camp.Tabest.Select("id = " + id + " and tp = " + tp))
                    {
                        Lst.Add(c["id_ed"]);
                        Lst.Add(c["name"]);
                        Lst.Add(c["cond"]);
                    }

                    a = calldp.MDPP_SvtModOtro(id, Convert.ToInt16(Lst[0]), Convert.ToInt16(Lst[1]), Lst[2].ToString(), tp, Convert.ToInt16(Lst[3]));
                    break;


                default:


                    foreach (var c in camp.Tabbod.Select("id = " + id + " and tp = " + tp))
                    {
                        Lst.Add(c["id_ed"]);
                        Lst.Add(c["name"]);
                        Lst.Add(c["cond"]);
                    }

                    a = calldp.MDPP_SvtModOtro(id, Convert.ToInt16(Lst[0]), Convert.ToInt16(Lst[1]), Lst[2].ToString(), tp, Convert.ToInt16(Lst[3]));
                    break;

            }
            Lst.Clear();

            Mensaje(a, tp, 2);
        }

        private void Mensaje(string a, int Tp, int TpMov)
        {
            if (a == "1")
            {
                if (TpMov != 2)
                    LimpGnrl();

                CargaTabGrd(Tp);
                MsgEv.MsgAlmacenar(mod, a);

                if (TpMov == 1)
                    ExcDelSelEdit(0);
            }
            else
            {
                MsgEv.MsgAlmacenar(mod, a);
                vargnrl.SelError = true;
                ActError(mod, mod + ";" + a);
            }
        }


        private void LimpGnrl()
        {
            Camp.LimpVar();
            Vargnrl.SelError = false;
        }

        #endregion
    }
}
