using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prism.Mvvm;

namespace ClssVmMdl.Models.Conf.Edif
{
   public class MDMantPropied : BindableBase
    {

        public MDMantPropied()
        {
            _selmod = false;
            _selgnrl = false;
            _selUpdt = false;
            _selDep = 0;
        }


        #region datos departamento

        private string _dname;
        public string dname
        {
            get { return _dname; }
            set { SetProperty(ref _dname, value); }
        }

        private int _dnum;
        public int dnum
        {
            get { return _dnum; }
            set { SetProperty(ref _dnum, value); }
        }

        private DataTable _grddepart;
        public DataTable grddepart
        {
            get { return _grddepart; }
            set { SetProperty(ref _grddepart, value); }
        }

        #endregion



        #region Seleccion

     
        private int _dselmom;
        public int dselmod
        {
            get { return _dselmom; }
            set { SetProperty(ref _dselmom, value); }
        }

        private int _dselori;
        public int dselori
        {
            get { return _dselori; }
            set { SetProperty(ref _dselori, value); }
        }

        private int _seledef;
        public int seledef
        {
            get { return _seledef; }
            set { SetProperty(ref _seledef, value); }
        }

        private int _selpiso;
        public int selpiso
        {
            get { return _selpiso; }
            set { SetProperty(ref _selpiso, value); }
        }

        #endregion



        #region Event


        private bool _selmod;
        public bool selmod
        {
            get { return _selmod; }
            set { SetProperty(ref _selmod, value); }
        }

        private bool _selgnrl;
        public bool selgnrl
        {
            get { return _selgnrl; }
            set { SetProperty(ref _selgnrl, value); }
        }

        private bool _selUpdt;
        public bool selUpdt
        {
            get { return _selUpdt; }
            set { SetProperty(ref _selUpdt, value); }
        }

        private int _selDep;
        public int selDep
        {
            get { return _selDep; }
            set { SetProperty(ref _selDep, value); }
        }

      

        #endregion

        #region Coleccion



        #endregion


    }
}
