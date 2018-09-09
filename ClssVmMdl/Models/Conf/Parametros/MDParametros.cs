using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prism.Mvvm;

namespace ClssVmMdl.Models.Conf.Parametros
{
   public class MDParametros : BindableBase
    {

        private DataTable _LtTpDep;
        public DataTable LtTpDep
        {
            get { return _LtTpDep; }
            set { SetProperty(ref _LtTpDep, value); }
        }

        private string _TpDep;
        public string TpDep
        {
            get { return _TpDep; }
            set { SetProperty(ref _TpDep, value); }
        }
        
        private DataTable _LtTpDepOt;
        public DataTable LtTpDepOt
        {
            get { return _LtTpDepOt; }
            set { SetProperty(ref _LtTpDepOt, value); }
        }

        private string _TpDepOt;
        public string TpDepOt
        {
            get { return _TpDepOt; }
            set { SetProperty(ref _TpDepOt, value); }
        }

        private DataTable _LtTpNot;
        public DataTable LtTpNot
        {
            get { return _LtTpNot; }
            set { SetProperty(ref _LtTpNot, value); }
        }

        private string _TpNot;
        public string TpNot
        {
            get { return _TpNot; }
            set { SetProperty(ref _TpNot, value); }
        }

        private DataTable _LtNvlNot;
        public DataTable LtNvlNot
        {
            get { return _LtNvlNot; }
            set { SetProperty(ref _LtNvlNot, value); }
        }

        private string _NvlNot;
        public string NvlNot
        {
            get { return _NvlNot; }
            set { SetProperty(ref _NvlNot, value); }
        }
    }
}
