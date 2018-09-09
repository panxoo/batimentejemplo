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
            _selDeci = false;
            _selMsg = false;
        }

        private List<ColIdName> tpdep;
        public List<ColIdName> Tpdep
        {
            get { return tpdep; }
            set { SetProperty(ref tpdep, value); }
        }

        private List<ColIdName> _pais;
        public List<ColIdName> pais
        {
            get { return _pais; }
            set { SetProperty(ref _pais, value); }
        }

        private List<ColIdName> _region;
        public List<ColIdName> region
        {
            get { return _region; }
            set { SetProperty(ref _region, value); }
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


        private bool _selMsg;
        public bool selMsg
        {
            get { return _selMsg; }
            set { SetProperty(ref _selMsg, value); }
        }

        private string _MsgError;
        public string MsgError
        {
            get { return _MsgError; }
            set { SetProperty(ref _MsgError, value); }
        }

        private bool _selDeci;
        public bool selDeci
        {
            get { return _selDeci; }
            set { SetProperty(ref _selDeci, value); }
        }

        private string _MsgDesicion;
        public string MsgDesicion
        {
            get { return _MsgDesicion; }
            set { SetProperty(ref _MsgDesicion, value); }
        }

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
