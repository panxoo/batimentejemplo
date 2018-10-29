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
            DelSavUpdt = new DelegateCommand<object>(ExcSavUpdt);


            DelActUpdtDep = new DelegateCommand<object>(ExActUpdtEd);
            DelSvDepa = new DelegateCommand(ExSvEdificio);
            DelAddDep = new DelegateCommand(ExAddEdificio);

            DelPisoPopUp = new DelegateCommand<object[]>(RaisePisoPopUpModExc);
            DelCloseMsgError = new DelegateCommand(ExCloseMsgError);
        }


        #region Contructor

        private CallVariables calvar;
        private CallDep caldep;
        private MsgEvents msgev;
        private ValElemment vali;
        private string mod;

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
        public DelegateCommand<object> DelSavUpdt { get; set; }

        public DelegateCommand<object> DelCanMod { get; set; }

        public DelegateCommand<object> DelActUpdtDep { get; set; }
        public DelegateCommand DelAddDep { get; set; }
        public DelegateCommand DelSvDepa { get; set; }

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
            }
        }

        private void ExActUpdtEd(object Edef)
        {
            camp.Eupdt = true;
            //_camp.Selgnrl = true;
            CargEdif((int)Edef);
        }
        
        private void ExcSavUpdt(object parm) => AlmacenarCond((int)parm);

        private void ExSvEdificio()
        {
            AlmacenarEdf();
        }

        private void ExAddEdificio()
        {
            //_camp.Moddep = true;

        }

        private void ExSelectionPais()
        {
            CargaReg(camp.IdPais, 0);
        }

        private void ExCloseMsgError()
        {
            //vargnrl.selMsg = false;
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

        private void AlmacenarCond(int tp)
        {
            string a;

            //if (vali.EmptyStrg(new List<string>(new string[] {_camp.cnom,_camp.ccity,_camp.ccalle,_camp.cNumDir,_camp.cpostal,
            //    _camp.ctel,_camp.ccorreo})))
            //{
            //    a = caldep.CFED_SavCond(_camp.cnom.Trim(), _camp.cIdPais, _camp.cIdRegion, _camp.ccity.Trim(), _camp.ccalle.Trim(),
            //        _camp.cNumDir.Trim(), _camp.cpostal.Trim(), _camp.ctel.Trim(), _camp.ctel2.Trim(), _camp.ccorreo.Trim(),
            //        _camp.ccorreo2.Trim(), Convert.ToInt16(_camp.cmultied), ParSistem.IdCond);
            //}
            //else
            //{
            //    a = "2";
            //}
            //msgproc(a, 0);
        }

        #endregion


        #region metodos Edif

        private void CargEdifGrd()
        {
            camp.Edif = caldep.CFED_DatosEdificios(ParSistem.IdCond);
        }




        private void AlmacenarEdf()
        {
            string a = "";

            //if (vali.EmptyStrg(new List<string>(new string[] { _camp.enom, _camp.eidnom, _camp.enumd })) &&
            //    (vali.NumMayCero(new List<int>(new int[] { _camp.episo }))) && (vali.NumCeroMay(new List<int>(new int[] { _camp.espiso }))))
            //{
            //    if (_camp.eidDep == -1)
            //        a = caldep.CFED_SavDep(ParSistem.IdCond, _camp.enom.Trim(), _camp.eidnom.Trim(), _camp.enumd.Trim(), _camp.etel.Trim(),
            //            _camp.etel2.Trim(), _camp.ecor.Trim(), _camp.ecor2.Trim(), _camp.episo, _camp.espiso);
            //    else
            //        a = caldep.CFED_SavDep(ParSistem.IdCond, _camp.enom.Trim(), _camp.eidnom.Trim(), _camp.enumd.Trim(), _camp.etel.Trim(),
            //            _camp.etel2.Trim(), _camp.ecor.Trim(), _camp.ecor2.Trim(), _camp.episo, _camp.espiso, _camp.eidDep);
            //}
            //else
            //{
            //    a = "2";
            //}

            msgproc(a, 1);

        }

        #endregion



        private void msgproc(string a, int tp)
        {
            if (a == "1")
            {
                msgev.MsgAlmacenar("", "1");
                if (tp == 0)
                {
                    CallCondominio();
                    ParSistem.Carga(false);
                }
                else
                {
                    //_camp.Moddep = false;
                    //_camp.Selgnrl = false;
                    CargEdifGrd();
                }
            }
            else
            {
                msgev.MsgAlmacenar("cfed", a);
                //vargnrl.MsgError = mod + ";" + a;
                //vargnrl.selMsg = true;
            }
        }


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
