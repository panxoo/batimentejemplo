using System;
using ClssVmMdl.Models.Conf.Edif;
using ClssVmMdl.Calling;
using Prism.Mvvm;
using Prism.Commands;
using System.Collections;


namespace ClssVmMdl.ViewModels.Conf.Edif
{
    public class VMAddEd : BindableBase
    {

        public VMAddEd()
        {
            varini();
            _varb.nomCamDis = true;
            _varb.mod = false;
            _varb.UpdCamVis = "Visible";
        }

        public VMAddEd(string ed)
        {
            varini();
            _varb.nomCamDis = false;
            _varb.mod = true;
            _varb.UpdCamVis = "Hidden";
            CargCamp(ed);
        }

        private void varini()
        {
            _varb = new MDAddEd();
            callsv = new CallDep("addp");
            SaveCommand = new DelegateCommand(ExcSav, CanExcSav);
        }

        private void CargCamp(string ed)
        {
            try
            {
                ArrayList dat;
                dat = callsv.seldepup(ed);
                _varb.nom = dat[0].ToString();
                _varb.ident = dat[1].ToString();
                _varb.numdir = dat[2].ToString();
                _varb.tel = dat[3].ToString();
                _varb.tel2 = dat[4].ToString();
                _varb.email = dat[5].ToString();
                _varb.email2 = dat[6].ToString();
                _varb.ps = Convert.ToInt32(dat[7].ToString());
                _varb.sbps = Convert.ToInt32(dat[8].ToString());
            }
            catch (Exception ex)
            {
            }

        }

        private CallDep callsv;

        private MDAddEd _varb;
        public MDAddEd varb
        {
            get { return _varb; }
            set
            {
                SetProperty(ref _varb, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }


        #region savecomand
        public DelegateCommand SaveCommand { get; set; }

        private bool CanExcSav()
        {
            return true;
        }

        private void ExcSav()
        {
            if (_varb.mod == false)
            {
                callsv.svtinfdep(0, _varb.nom, _varb.ident, _varb.numdir, _varb.tel, _varb.tel2, _varb.email, _varb.email2, _varb.ps, _varb.sbps);
                LimpCamp();
            }
            else
            {
                callsv.svtinfdep(1, _varb.nom, _varb.ident, _varb.numdir, _varb.tel, _varb.tel2, _varb.email, _varb.email2,0,0);
            }

        }
        private void LimpCamp()
        {
            _varb.nom = "";
            _varb.ident = "";
            _varb.numdir = "";
            _varb.tel = "";
            _varb.tel2 = "";
            _varb.email = "";
            _varb.email2 = "";
            _varb.ps = 0;
            _varb.sbps = 0;
        }



        #endregion






    }
}
