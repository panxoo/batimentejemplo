using System;
using System.Collections.Generic;
using System.Linq;
using ClssVmMdl.Models.Conf.Edif;
using ClssVmMdl.Models.Parametros;
using ClssVmMdl.Calling;
using Prism.Mvvm;
using Prism.Commands;
using ClssVmMdl.Validacion;
using System.Collections;
using ClssVmMdl.VarStatic;


namespace ClssVmMdl.ViewModels.Conf.Edif
{
    public class VMMantPropied : BindableBase
    {

        public VMMantPropied()
        {
            mod = "mtdp";
            MsgEv = new MsgEvents();
            _vargnrl = new MDVarGnrl();
            callvar = new CallVariables(mod);
            valst = new ValElemment();
            calldp = new CallDep(mod);
            MsgEv = new MsgEvents();

            _camp = new MDMantPropied();

            inicio();

            DelSelectionPiso = new DelegateCommand(ExcSelectionPiso);
            DelSelectionEdef = new DelegateCommand(ExcSelectionEdef);
            DelAlmDep = new DelegateCommand<object>(ExcAlmDep);
            DelOpenMod = new DelegateCommand<object[]>(ExcOpenMod);
            DelCloseMsgError = new DelegateCommand(ExcCloseMsgError);
            DelCloseMod = new DelegateCommand(ExcCloseMod);
        }

        #region Property

        private string mod;
        private MsgEvents MsgEv;

        private MDVarGnrl _vargnrl;
        public MDVarGnrl Vargnrl
        {
            get { return _vargnrl; }
            set { SetProperty(ref _vargnrl, value); }
        }

        private MDMantPropied _camp;
        public MDMantPropied camp
        {
            get { return _camp; }
            set { SetProperty(ref _camp, value); }
        }

        private CallVariables callvar;
        private CallDep calldp;
        private ValElemment valst;

        public DelegateCommand DelSelectionPiso { get; set; }
        public DelegateCommand DelSelectionEdef { get; set; }
        public DelegateCommand<object> DelAlmDep { get; set; }
        public DelegateCommand<object[]> DelOpenMod { get; set; }
        public DelegateCommand DelCloseMsgError { get; set; }
        public DelegateCommand DelCloseMod { get; set; }



        #endregion

        #region Execute

        private void ExcSelectionPiso()
        {
            CargaDepxPiso(_camp.selpiso, _camp.seledef);
        }

        private void ExcSelectionEdef()
        {
            CargaPiso(_camp.seledef);
        }

        private void ExcAlmDep(object val)
        {
            AlmacenarDep(Convert.ToInt16(val));
        }

        private void ExcOpenMod(object[] val)
        {
            _camp.selmod = true;
            _camp.selgnrl = true;

            if (val[0].ToString() == "1")
            {
                _camp.selUpdt = true;
                _camp.selDep = Convert.ToInt16(val[1]);
                LimpCamp();
                SelDepUpdt();
            }
            else
            {
                _camp.selUpdt = false;
                LimpCamp();
            }
        }

        private void ExcCloseMsgError()
        {
            //_vargnrl.selMsg = false;
        }

        private void ExcCloseMod()
        {
            CloseMod();
        }

        #endregion


        #region Metodos

        private void inicio()
        {
            _vargnrl.Edific = callvar.PRGN_Edif(ParSistem.IdCond);
            _vargnrl.orient = callvar.PRGN_Orient();
            _camp.dselori = _vargnrl.orient[0].Id;
            _camp.seledef = _vargnrl.Edific[0].Id;
            CargaPiso(_vargnrl.Edific[0].Id);
        }


        private void CargaDepxPiso(int ps, int edf)
        {
            _camp.grddepart = calldp.MTDP_SelDepartamentxPiso(ps, edf, ParSistem.IdCond);
        }

        private void CargaPiso(int edf)
        {
            _vargnrl.piso = new List<AccesoDatos.TypeVar.ColIdName>();
            _vargnrl.piso = callvar.PRGN_Piso(edf, ParSistem.IdCond);

            if (_vargnrl.piso.Count() > 0)
            {
                _camp.selpiso = _vargnrl.piso[0].Id;
                CargaDepxPiso(_camp.selpiso, edf);
            }

            _vargnrl.modeldepa = calldp.MTDP_CallModelDepa(edf, ParSistem.IdCond);

            if (_vargnrl.modeldepa.Count() > 0)
                _camp.dselmod = _vargnrl.modeldepa[0].Id;

        }

        private void AlmacenarDep(int close)
        {
            string a;

            if ((valst.EmptyStrg(new List<string>(new string[] { _camp.dname }))) && (valst.NumMayCero(new List<int>(new int[] { _camp.dnum }))))
            {
                if (_camp.selUpdt == false)
                {
                    a = calldp.MTDP_SavDepartament(_camp.selpiso, _camp.seledef, _camp.dselmod, _camp.dselori, _camp.dname, _camp.dnum);
                }
                else
                {
                    a = calldp.MTDP_UpdDepartament(_camp.selpiso, _camp.seledef, _camp.dselmod, _camp.dselori, _camp.dname, _camp.dnum, _camp.selDep);
                }
            }
            else
                a = "2";

            MsgAlma(a);

        }


        private void MsgAlma(string msg)
        {
            if (msg == "1")
            {
                MsgEv.MsgAlmacenar(mod, msg);
                CargaDepxPiso(_camp.selpiso, _camp.seledef);
                LimpCamp();
                CloseMod();
            }
            else
            {
                MsgEv.MsgAlmacenar(mod, msg);
                //_vargnrl.MsgError = mod + ";" + msg;
                //_vargnrl.selMsg = true;
            }

            return;
        }

        private void LimpCamp()
        {
            _camp.dname = "";
            _camp.dnum = 0;
            _camp.dselori = _vargnrl.orient[0].Id;
            if (_vargnrl.modeldepa.Count > 0)
                _camp.dselmod = _vargnrl.modeldepa[0].Id;
        }


        private void SelDepUpdt()
        {
            ArrayList Colect;
            Colect = calldp.MTDP_ViewDepartUpdt(_camp.selDep, _camp.selpiso, _camp.seledef);

            if (_vargnrl.modeldepa.Any(p => p.Id == (int)Colect[0]))
                _camp.dselmod = (int)Colect[0];
            else
                _camp.dselmod = _vargnrl.modeldepa[0].Id;

            _camp.dselori = (int)Colect[1];
            _camp.dname = Colect[2].ToString();
            _camp.dnum = (int)Colect[3];

            Colect.Clear();

        }

        private void CloseMod()
        {
            _camp.selgnrl = false;
            _camp.selmod = false;
            _camp.selDep = 0;
            _camp.selUpdt = false;
        }
        #endregion

    }
}
