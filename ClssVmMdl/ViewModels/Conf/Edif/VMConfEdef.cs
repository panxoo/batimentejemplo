using System;
using System.Linq;
using Prism.Mvvm;
using ClssVmMdl.Models.Conf.Edif;
using ClssVmMdl.Calling;
using Prism.Commands;
using System.Collections;
using ClssVmMdl.Validacion;
using ClssVmMdl.Models.Parametros;
using Prism.Interactivity.InteractionRequest;
using ClssVmMdl.Models.Confirma.Conf;
using ClssVmMdl.VarStatic;
using AccesoDatos.TypeVar;
using System.Collections.Generic;

namespace ClssVmMdl.ViewModels.Conf.Edif
{
    public class VMConfEdef : BindableBase
    {
        public VMConfEdef()
        {
            mod = "cfed";
            camp = new MDConfEdef();
            vargnrl = new MDVarGnrl();
            calvar = new CallVariables(mod);
            caldep = new CallDep(mod);
            msgev = new MsgEvents();
            vali = new ValElemment();

            CargaInicial();

            IntPisoPopUp = new InteractionRequest<MDEditPisoEdificio>();


            DelSelectionPais = new DelegateCommand(ExSelectionPais);
            DelActUpdt = new DelegateCommand(ExActUpdt);
            DelCanMod = new DelegateCommand<object>(ExCanMod);

            DelSav = new DelegateCommand<object>(ExcSavUpdt);

            DelActUpdtDep = new DelegateCommand<object>(ExActUpdtEd);
            DelAddDep = new DelegateCommand(ExAddEdificio);

            DelPisoPopUp = new DelegateCommand<object[]>(RaisePisoPopUpModExc);
            //DelCloseMsgError = new DelegateCommand(ExCloseMsgError);
        }


        #region Contructor

        private CallVariables calvar;
        private CallDep caldep;
        private MsgEvents msgev;
        private ValElemment vali;
        private string mod;

        public Action<bool> ACUpdtDep;

        public InteractionRequest<MDEditPisoEdificio> IntPisoPopUp { get; private set; }

        private MDConfEdef camp;
        public MDConfEdef Camp
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

        public DelegateCommand DelSelectionPais { get; set; }

        public DelegateCommand DelActUpdt { get; set; }
        public DelegateCommand<object> DelSav { get; set; }
        public DelegateCommand<object> DelCanMod { get; set; }

        public DelegateCommand<object> DelActUpdtDep { get; set; }
        public DelegateCommand DelAddDep { get; set; }

        public DelegateCommand<object[]> DelPisoPopUp { get; set; }
        public DelegateCommand DelCloseMsgError { get; set; }


        #endregion


        #region Execute

        private void ExActUpdt() => camp.Cupdt = true;

        private void ExCanMod(object parm)
        {
            if (Convert.ToInt16(parm) == 0)
            {
                camp.Cupdt = false;
                CallCondominio();
            }
            else
            {
                camp.Eupdt = false;
                ACUpdtDep(false);
            }
        }

        private void ExAddEdificio() => ACUpdtDep(true);

        private void ExActUpdtEd(object Edef)
        {
            camp.Eupdt = true;
            CargEdif((int)Edef);
            ACUpdtDep(true);
        }

        private void ExcSavUpdt(object parm) => Almacenar(Convert.ToInt16(parm));



        private void ExSelectionPais()
        {
            CargaReg(camp.IdPais, 0);
        }
           
        #endregion


        #region metodos cond



        private void CargaInicial()
        {
            vargnrl.Pais = calvar.PRGN_PaisReg(0, 0);
            CallCondominio();
        }

        private void CallCondominio()
        {
            ArrayList dtcond = new ArrayList();
            dtcond = caldep.CFED_SelCond(ParSistem.IdCond);

            camp.Cnom = dtcond[0].ToString();
            camp.IdPais = (int)dtcond[1];

            CargaReg((int)dtcond[1], (int)dtcond[2]);

            camp.City = dtcond[3].ToString();
            camp.Calle = dtcond[4].ToString();
            camp.NumDir = dtcond[5].ToString();
            camp.Postal = dtcond[6].ToString();
            camp.CTel = dtcond[7].ToString();
            camp.CTel2 = dtcond[8].ToString();
            camp.CCorreo = dtcond[9].ToString();
            camp.CCorreo2 = dtcond[10].ToString();
            camp.MultiEd = Convert.ToBoolean(dtcond[11]);

            CargEdifGrd();
        }


        private void CargaReg(int idpais, int idreg)
        {
            camp.IdRegion = new int();
            vargnrl.Region = new List<ColIdName>();

            vargnrl.Region = calvar.PRGN_PaisReg(1, idpais);

            if (vargnrl.Region.Exists(x => x.Id == idreg))
                camp.IdRegion = idreg;
            else
                camp.IdRegion = vargnrl.Region[0].Id;
        }

      

        private void Almacenar(int tp)
        {
            string a = "";

            if (tp == 0)
            {
                if (!vali.EmptyStrg(new List<string> { camp.Cnom, camp.Calle, camp.NumDir, camp.City }) || camp.IdPais == -1 || camp.IdRegion == -1)
                {
                    a = "2";
                }

                if (a == "")
                {
                    a = caldep.CFED_SavCond(camp.Cnom, camp.IdPais, camp.IdRegion, camp.City.Trim(), camp.Calle.Trim(), camp.NumDir.Trim(), camp.Postal.Trim(),
                        camp.CTel.Trim(), camp.CTel2.Trim(), camp.CCorreo.Trim(), camp.CCorreo2.Trim(), camp.MultiEd, ParSistem.IdCond);
                }
            }
            else
            {
                if (!vali.EmptyStrg(new List<string> { camp.Enom, camp.IdNomEdf, camp.NumEdf }) || camp.Pisos < 1)
                {
                    a = "2";
                }

                if (a == "")
                {
                    if (!camp.Eupdt)
                    {
                        a = caldep.CFED_SavDep(ParSistem.IdCond, camp.Enom.Trim(), camp.IdNomEdf.Trim(), camp.NumEdf.Trim(),
                                                string.IsNullOrEmpty(camp.ETel.Trim()) ? camp.CTel.Trim() : camp.ETel.Trim(),
                                                string.IsNullOrEmpty(camp.ETel2.Trim()) ? camp.CTel2.Trim() : camp.ETel2.Trim(),
                                                string.IsNullOrEmpty(camp.ECorreo.Trim()) ? camp.CCorreo.Trim() : camp.ECorreo.Trim(),
                                                string.IsNullOrEmpty(camp.ECorreo2.Trim()) ? camp.CCorreo2.Trim() : camp.ECorreo2.Trim(), camp.Pisos, camp.Spisos);
                    }
                    else
                    {
                        a = caldep.CFED_SavDep(ParSistem.IdCond, camp.Enom.Trim(), camp.IdNomEdf.Trim(), camp.NumEdf.Trim(),
                                                string.IsNullOrEmpty(camp.ETel.Trim()) ? camp.CTel.Trim() : camp.ETel.Trim(),
                                                string.IsNullOrEmpty(camp.ETel2.Trim()) ? camp.CTel2.Trim() : camp.ETel2.Trim(),
                                                string.IsNullOrEmpty(camp.ECorreo.Trim()) ? camp.CCorreo.Trim() : camp.ECorreo.Trim(),
                                                string.IsNullOrEmpty(camp.ECorreo2.Trim()) ? camp.CCorreo2.Trim() : camp.ECorreo2.Trim(), camp.Pisos, camp.Spisos, camp.IdEdf);
                    }
                }

            }

            Mensaje(a, tp);
        }


        private void Mensaje(string a, int Tp)
        {
            if (a == "1")
            {
                if(Tp==0)
                {
                    camp.Cupdt = false;
                    CallCondominio();
                }
                else
                {
                    camp.Eupdt = false;
                    ACUpdtDep(false);
                    CargEdifGrd();
                }

                msgev.MsgAlmacenar(mod, a);
            }
            else
            {
                //ErrorVal(Tp);
                //MsgEv.MsgAlmacenar(mod, a);
                //vargnrl.SelError = true;
                //ActError(mod, mod + ";" + a);
            }
        }

        #endregion


        #region metodos Edif

        private void CargEdifGrd()
        {
            camp.Edif = caldep.CFED_DatosEdificios(ParSistem.IdCond);
        }

        private void CargEdif(int ed)
        {
            ArrayList lst = caldep.CFED_SelEdef(ed, ParSistem.IdCond);

            if (lst.Count > 0)
            {
                camp.Enom = lst[0].ToString();
                camp.IdNomEdf = lst[1].ToString();
                camp.NumEdf = lst[2].ToString();
                camp.ETel = lst[3].ToString();
                camp.ETel2 = lst[4].ToString();
                camp.ECorreo = lst[5].ToString();
                camp.ECorreo2 = lst[6].ToString();
                camp.Pisos = Convert.ToInt32(lst[7]);
                camp.Spisos = Convert.ToInt32(lst[8]);
                camp.IdEdf = ed;
            }
        }

        #endregion

        #region Interaccion

        private void RaisePisoPopUpModExc(object[] val)
        {
            MDEditPisoEdificio VarEditPs = new MDEditPisoEdificio();

            VarEditPs.VarCond = Convert.ToBoolean(val[0]);
            VarEditPs.VarValcond = Convert.ToInt32(val[1].ToString());
            VarEditPs.VarValid = Convert.ToInt32(val[2].ToString());

            VarEditPs.Title = "Configuracion de Piso";

            IntPisoPopUp.Raise(VarEditPs,
                 returned =>
                 {
                     if (returned != null && returned.Confirmed)
                     {

                     }

                 });
        }





        #endregion

    }
}
