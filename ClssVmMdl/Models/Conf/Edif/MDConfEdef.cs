using Prism.Mvvm;
using System.Data;
using ClssVmMdl.Validacion;
using System.Collections;

namespace ClssVmMdl.Models.Conf.Edif
{
    public class MDConfEdef : BindableBase
    {

        public MDConfEdef()
        {
            _eidDep = -1;
            selgnrl = false;
            moddep = false;
            val = new ValTam();
        } 

        private ValTam val;

        private string _panam;
        public string panam
        {
            get { return _panam; }
            set { SetProperty(ref _panam, value); }
        }

        private string _renam;
        public string renam
        {
            get { return _renam; }
            set { SetProperty(ref _renam, value); }
        }

        private bool selgnrl;
        public bool Selgnrl
        {
            get { return selgnrl; }
            set { SetProperty(ref selgnrl, value); }
        }

        private bool moddep;
        public bool Moddep
        {
            get { return moddep; }
            set { SetProperty(ref moddep, value); }
        }

        #region Condominio

        private ArrayList dtcond;
        public ArrayList Dtcond
        {
            get => dtcond;
            set => SetProperty(ref dtcond, value);
        }

        private string _cnom;
        public string cnom
        {
            get
            {
                _cnom = val.LimitStrg(_cnom, 500);
                return _cnom;
            }
            set { SetProperty(ref _cnom, value); }
        }

        private int _cIdPais;
        public int cIdPais
        {
            get { return _cIdPais; }
            set { SetProperty(ref _cIdPais, value); }
        }

        private int _cIdRegion;
        public int cIdRegion
        {
            get { return _cIdRegion; }
            set { SetProperty(ref _cIdRegion, value); }
        }

        private string _ccity;
        public string ccity
        {
            get
            {
                _ccity = val.LimitStrg(_ccity, 100);
                return _ccity;
            }
            set { SetProperty(ref _ccity, value); }
        }

        private string _ccalle;
        public string ccalle
        {
            get
            {
                _ccalle = val.LimitStrg(_ccalle, 500);
                return _ccalle;
            }
            set { SetProperty(ref _ccalle, value); }
        }

        private string _cNumDir;
        public string cNumDir
        {
            get
            {
                _cNumDir = val.LimitStrg(_cNumDir, 50);
                return _cNumDir;
            }
            set { SetProperty(ref _cNumDir, value); }
        }

        private string _cpostal;
        public string cpostal
        {
            get
            {
                _cpostal = val.LimitStrg(_cpostal, 50);
                return _cpostal;
            }
            set { SetProperty(ref _cpostal, value); }
        }

        private string _ctel;
        public string ctel
        {
            get
            {
                _ctel = val.LimitStrg(_ctel, 15);
                return _ctel;
            }
            set { SetProperty(ref _ctel, value); }
        }

        private string _ctel2;
        public string ctel2
        {
            get
            {
                _ctel2 = val.LimitStrg(_ctel2, 15);
                return _ctel2;
            }
            set { SetProperty(ref _ctel2, value); }
        }

        private string _ccorreo;
        public string ccorreo
        {
            get
            {
                _ccorreo = val.LimitStrg(_ccorreo, 50);
                return _ccorreo;
            }
            set { SetProperty(ref _ccorreo, value); }
        }

        private string _ccorreo2;
        public string ccorreo2
        {
            get
            {
                _ccorreo2 = val.LimitStrg(_ccorreo2, 50);
                return _ccorreo2;
            }
            set { SetProperty(ref _ccorreo2, value); }
        }

        private bool _cupdt;
        public bool cupdt
        {
            get { return _cupdt; }
            set { SetProperty(ref _cupdt, value); }
        }

        private bool _cmultied;
        public bool cmultied
        {
            get { return _cmultied; }
            set { SetProperty(ref _cmultied, value); }
        }

        #endregion



        #region Edificio

        private DataTable _eedif;
        public DataTable eedif
        {
            get { return _eedif; }
            set { SetProperty(ref _eedif, value); }
        }

        private int _eidDep;
        public int eidDep
        {
            get { return _eidDep; }
            set { SetProperty(ref _eidDep, value); }
        }

        private string _enom;
        public string enom
        {
            get
            {
                _enom = val.LimitStrg(_enom, 500);
                return _enom;
            }
            set { SetProperty(ref _enom, value); }
        }

        private string _eidnom;
        public string eidnom
        {
            get
            {
                _eidnom = val.LimitStrg(_eidnom, 50);
                return _eidnom;
            }
            set { SetProperty(ref _eidnom, value); }
        }

        private string _enumd;
        public string enumd
        {
            get
            {
                _enumd = val.LimitStrg(_enumd, 10);
                return _enumd;
            }
            set { SetProperty(ref _enumd, value); }
        }

        private string _etel;
        public string etel
        {
            get
            {
                _etel = val.LimitStrg(_etel, 15);
                return _etel;
            }
            set { SetProperty(ref _etel, value); }
        }

        private string _etel2;
        public string etel2
        {
            get
            {
                _etel2 = val.LimitStrg(_etel2, 15);
                return _etel2;
            }
            set { SetProperty(ref _etel2, value); }
        }

        private string _ecor;
        public string ecor
        {
            get
            {
                _ecor = val.LimitStrg(_ecor, 50);
                return _ecor;
            }
            set { SetProperty(ref _ecor, value); }
        }

        private string _ecor2;
        public string ecor2
        {
            get
            {
                _ecor2 = val.LimitStrg(_ecor2, 50);
                return _ecor2;
            }
            set { SetProperty(ref _ecor2, value); }
        }

        private int _espiso;
        public int espiso
        {
            get { return _espiso; }
            set { SetProperty(ref _espiso, value); }
        }

        private int _episo;
        public int episo
        {
            get { return _episo; }
            set { SetProperty(ref _episo, value); }
        }



        #endregion
    }
}
