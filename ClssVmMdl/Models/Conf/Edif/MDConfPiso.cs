using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Data;
using Prism.Commands;

namespace ClssVmMdl.Models.Conf.Edif
{
  public  class MDConfPiso : BindableBase
    {

        private DataTable _VarPisoGrd;
        public DataTable VarPisoGrd
        {
            get { return _VarPisoGrd; }
            set { SetProperty(ref _VarPisoGrd, value); }
        }

        private DataTable _VarSpisoGrd;
        public DataTable VarSpisoGrd
        {
            get { return _VarSpisoGrd; }
            set { SetProperty(ref _VarSpisoGrd, value); }
        }

        public int VarValid { get; set; }
        public int VarValcond { get; set; }
        public bool VarCond { get; set; }

        public int VarCpis { get; set; }
        public int VarCspis { get; set; }

        //DelegateCommand 

    }
}
