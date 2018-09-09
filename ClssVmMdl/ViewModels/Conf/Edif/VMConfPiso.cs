using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClssVmMdl.Models.Conf.Edif;
using Prism.Mvvm;

namespace ClssVmMdl.ViewModels.Conf.Edif
{
   public class VMConfPiso:BindableBase
    {
        public VMConfPiso()
        {
            _camp = new MDConfPiso();
        }

        #region Constructor

        private MDConfPiso _camp;
        public MDConfPiso camp
        {
            get { return _camp; }
            set { SetProperty(ref _camp, value); }
        }





        #endregion

        #region Execute

#endregion

        #region Metodos


        #endregion
    }
}
