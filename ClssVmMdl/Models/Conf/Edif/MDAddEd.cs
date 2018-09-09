using Prism.Mvvm;

namespace ClssVmMdl.Models.Conf.Edif
{
    public class MDAddEd : BindableBase
    {

        private string _nom;
        public string nom
        {
            get { return _nom; }
            set { SetProperty(ref _nom, value); }
        }

        private string _ident;
        public string ident
        {
            get { return _ident; }
            set { SetProperty(ref _ident, value); }
        }

        private string _numdir;
        public string numdir
        {
            get { return _numdir; }
            set { SetProperty(ref _numdir, value); }
        }

        private string _tel;
        public string tel
        {
            get { return _tel; }
            set { SetProperty(ref _tel, value); }
        }

        private string _tel2;
        public string tel2
        {
            get { return _tel2; }
            set { SetProperty(ref _tel2, value); }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _email2;
        public string email2
        {
            get { return _email2; }
            set { SetProperty(ref _email2, value); }
        }

        private bool _nomCamdis;
        public bool nomCamDis
        {
            get { return _nomCamdis; }
            set { SetProperty(ref _nomCamdis, value); }
        }

        private bool _mod;
        public bool mod
        {
            get { return _mod; }
            set { SetProperty(ref _mod, value); }
        }

        private int _ps;
        public int ps
        {
            get { return _ps; }
            set { SetProperty(ref _ps, value); }
        }

        private int _sbps;
        public int sbps
        {
            get { return _sbps; }
            set { SetProperty(ref _sbps, value); }
        }

        private string _UpdCamVis;
        public string UpdCamVis
        {
            get { return _UpdCamVis; }
            set { SetProperty(ref _UpdCamVis, value); }
        }


    }
}
