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
            _camp = new MDConfEdef();
            vargnrl = new MDVarGnrl();
            calvar = new CallVariables(mod);
            caldep = new CallDep(mod);
            msgev = new MsgEvents();
            vali = new ValElemment();

            CargaInicial();

            IntPisoPopUp = new InteractionRequest<MDEditPisoEdificio>();


            DelSelectionPais = new DelegateCommand(ExSelectionPais);
            DelActUpdtC = new DelegateCommand(ExActUpdate);
            DelCanUpdtC = new DelegateCommand(ExCanUpdate);
            DelExeUpdtC = new DelegateCommand(ExUpdate);

            //DelViewDepa = new DelegateCommand<object>(ExCargEdif);
            DelCanDepa = new DelegateCommand(ExCanEdifi);
            DelUpdDep = new DelegateCommand<object>(ExCargUpdateEd);
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

        private MDConfEdef _camp;
        public MDConfEdef camp
        {
            get { return _camp; }
            set { SetProperty(ref _camp, value); }
        }

        private MDVarGnrl vargnrl;
        public MDVarGnrl Vargnrl
        {
            get { return vargnrl; }
            set { SetProperty(ref vargnrl, value); }
        }

        public DelegateCommand DelSelectionPais { get; set; }
        public DelegateCommand DelActUpdtC { get; set; }
        public DelegateCommand DelCanUpdtC { get; set; }
        public DelegateCommand DelExeUpdtC { get; set; }

        public DelegateCommand DelCanDepa { get; set; }
        public DelegateCommand DelSvDepa { get; set; }
        public DelegateCommand<object> DelUpdDep { get; set; }
        public DelegateCommand DelAddDep { get; set; }

        public DelegateCommand<object[]> DelPisoPopUp { get; set; }
        public DelegateCommand DelCloseMsgError { get; set; }


        #endregion


        #region Execute

        private void ExActUpdate()
        {
            _camp.cupdt = false;
        }

        private void ExCanUpdate()
        {
            CargaCond();
        }

        private void ExUpdate()
        {
            AlmacenarCond();
        }



        private void ExCanEdifi()
        {
            LimpEdif();
            _camp.Moddep = false;
            _camp.eidDep = -1;
            _camp.Selgnrl = false;
        }

        //private void ExCargEdif(object edef)
        //{
        //    CargEdif((int)edef);
        //    _camp.Moddep = true;
        //}

        private void ExCargUpdateEd(object Edef)
        {
            _camp.Moddep = true;
            _camp.Selgnrl = true;

            if (_camp.eidDep != (int)Edef || _camp.eidDep == -1)
                CargEdif((int)Edef);
        }

        private void ExSvEdificio()
        {
            SaveEdf();
        }

        private void ExAddEdificio()
        {
            _camp.Moddep = true;
            _camp.Selgnrl = true;
        }

        private void ExSelectionPais()
        {
            CargaReg(_camp.cIdPais, 0);
        }

        private void ExCloseMsgError()
        {
            vargnrl.selMsg = false;
        }

        #endregion


        #region metodos cond



        private void CargaInicial()
        {

            vargnrl.pais = calvar.PRGN_PaisReg(0, 0);
            CallCondominio();

            // _camp.cupdt = true;


        }

        private void CallCondominio()
        {
            _camp.Dtcond = new ArrayList();
            _camp.Dtcond = caldep.CFED_SelCond(ParSistem.IdCond);
            CargaCond();
        }

        private void CargaCond()
        {
            _camp.cnom = _camp.Dtcond[0].ToString();
            _camp.cIdPais = (int)_camp.Dtcond[1];

            CargaReg((int)_camp.Dtcond[1], (int)_camp.Dtcond[2]);

            _camp.ccity = _camp.Dtcond[3].ToString();
            _camp.ccalle = _camp.Dtcond[4].ToString();
            _camp.cNumDir = _camp.Dtcond[5].ToString();
            _camp.cpostal = _camp.Dtcond[6].ToString();
            _camp.ctel = _camp.Dtcond[7].ToString();
            _camp.ctel2 = _camp.Dtcond[8].ToString();
            _camp.ccorreo = _camp.Dtcond[9].ToString();
            _camp.ccorreo2 = _camp.Dtcond[10].ToString();
            _camp.cmultied = Convert.ToBoolean(_camp.Dtcond[11]);


            DisableModCond();

            if (_camp.cmultied == true)
                CargEdifGrd();
            else
                _camp.eedif = new System.Data.DataTable();

        }

        private void DisableModCond()
        {

            _camp.panam = (from p in vargnrl.pais
                           where p.Id == _camp.cIdPais
                           select p.Name.ToString()).First();

            _camp.renam = (from p in vargnrl.region
                           where p.Id == _camp.cIdRegion
                           select p.Name.ToString()).First();

            _camp.cupdt = true;

        }

        private void CargaReg(int idpais, int idreg)
        {
            _camp.cIdRegion = new int();
            vargnrl.region = new List<ColIdName>();

            vargnrl.region = calvar.PRGN_PaisReg(1, idpais);

            if (vargnrl.region.Exists(x => x.Id == idreg))
                _camp.cIdRegion = idreg;
            else
                _camp.cIdRegion = vargnrl.region[0].Id;
        }

        private void AlmacenarCond()
        {
            string a;

            if (vali.EmptyStrg(new List<string>(new string[] {_camp.cnom,_camp.ccity,_camp.ccalle,_camp.cNumDir,_camp.cpostal,
                _camp.ctel,_camp.ccorreo})))
            {
                a = caldep.CFED_SavCond(_camp.cnom.Trim(), _camp.cIdPais, _camp.cIdRegion, _camp.ccity.Trim(), _camp.ccalle.Trim(),
                    _camp.cNumDir.Trim(), _camp.cpostal.Trim(), _camp.ctel.Trim(), _camp.ctel2.Trim(), _camp.ccorreo.Trim(),
                    _camp.ccorreo2.Trim(), Convert.ToInt16(_camp.cmultied), ParSistem.IdCond);
            }
            else
            {
                a = "2";
            }
            msgproc(a, 0);
        }

        #endregion


        #region metodos Edif

        private void CargEdifGrd()
        {
            camp.eedif = caldep.CFED_DatosEdificios(ParSistem.IdCond);
        }

        private void CargEdif(int ed)
        {
            ArrayList lst = caldep.CFED_SelEdef(ed, ParSistem.IdCond);

            if (lst.Count > 0)
            {
                _camp.enom = lst[0].ToString();
                _camp.eidnom = lst[1].ToString();
                _camp.enumd = lst[2].ToString();
                _camp.etel = lst[3].ToString();
                _camp.etel2 = lst[4].ToString();
                _camp.ecor = lst[5].ToString();
                _camp.ecor2 = lst[6].ToString();
                _camp.episo = Convert.ToInt32(lst[7]);
                _camp.espiso = Convert.ToInt32(lst[8]);
                _camp.eidDep = (int)lst[9];
            }
        }

        private void LimpEdif()
        {
            _camp.enom = "";
            _camp.eidnom = "";
            _camp.enumd = "";
            _camp.etel = "";
            _camp.etel2 = "";
            _camp.ecor = "";
            _camp.ecor2 = "";
            _camp.episo = 0;
            _camp.espiso = 0;
            _camp.eidDep = -1;
        }

        private void SaveEdf()
        {
            string a;

            if (vali.EmptyStrg(new List<string>(new string[] { _camp.enom, _camp.eidnom, _camp.enumd })) &&
                (vali.NumMayCero(new List<int>(new int[] { _camp.episo }))) && (vali.NumCeroMay(new List<int>(new int[] { _camp.espiso }))))
            {
                if (_camp.eidDep == -1)
                    a = caldep.CFED_SavDep(ParSistem.IdCond, _camp.enom.Trim(), _camp.eidnom.Trim(), _camp.enumd.Trim(), _camp.etel.Trim(),
                        _camp.etel2.Trim(), _camp.ecor.Trim(), _camp.ecor2.Trim(), _camp.episo, _camp.espiso);
                else
                    a = caldep.CFED_SavDep(ParSistem.IdCond, _camp.enom.Trim(), _camp.eidnom.Trim(), _camp.enumd.Trim(), _camp.etel.Trim(),
                        _camp.etel2.Trim(), _camp.ecor.Trim(), _camp.ecor2.Trim(), _camp.episo, _camp.espiso, _camp.eidDep);
            }
            else
            {
                a = "2";
            }

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
                    LimpEdif();
                    _camp.Moddep = false;
                    _camp.Selgnrl = false;
                    CargEdifGrd();
                }
            }
            else
            {
                msgev.MsgAlmacenar("cfed", a);
                vargnrl.MsgError = mod + ";" + a;
                vargnrl.selMsg = true;
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
