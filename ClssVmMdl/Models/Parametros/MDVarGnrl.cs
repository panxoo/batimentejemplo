using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Data;
using AccesoDatos.TypeVar;
using ClssVmMdl.VarStatic;

namespace ClssVmMdl.Models.Parametros
{
    public class MDVarGnrl : BindableBase
    {
        public MDVarGnrl()
        {
            //_selDeci = false;
            //_selMsg = false;
            SelError = true;
        }

        private List<ColIdName> tpdep;
        public List<ColIdName> Tpdep
        {
            get { return tpdep; }
            set { SetProperty(ref tpdep, value); }
        }

        private List<ColIdName> pais;
        public List<ColIdName> Pais
        {
            get => pais; 
            set => SetProperty(ref pais, value); 
        }

        private List<ColIdName> region;
        public List<ColIdName> Region
        {
            get => region; 
            set => SetProperty(ref region, value); 
        }

        private List<ColIdName> edific;
        public List<ColIdName> Edific
        {
            get { return edific; }
            set { SetProperty(ref edific, value); }
        }

        private List<ColIdName> _modeldepa;
        public List<ColIdName> modeldepa
        {
            get { return _modeldepa; }
            set { SetProperty(ref _modeldepa, value); }
        }

        private List<ColIdName> _orient;
        public List<ColIdName> orient
        {
            get { return _orient; }
            set { SetProperty(ref _orient, value); }
        }

        private List<ColIdName> _piso;
        public List<ColIdName> piso
        {
            get { return _piso; }
            set { SetProperty(ref _piso, value); }
        }

        private List<ColIdName> tpserv;
        public List<ColIdName> Tpserv
        {
            get => tpserv;
            set => SetProperty(ref tpserv, value);
        }


        private bool selError;
        public bool SelError
        {
            get { return selError; }
            set { SetProperty(ref selError, value); }
        }

        //private string _MsgError;
        //public string MsgError
        //{
        //    get { return _MsgError; }
        //    set { SetProperty(ref _MsgError, value); }
        //}

        //private bool selDeci;
        //public bool SelDeci
        //{
        //    get { return selDeci; }
        //    set { SetProperty(ref selDeci, value); }
        //}      

        private bool multEdf;
        public bool MultEdf
        {
            get
            {
                multEdf = ParSistem.MultiEdef;
                return multEdf;
            }
            set => SetProperty(ref multEdf, value);
        }

    }
}
