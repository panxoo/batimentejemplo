using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ClssVmMdl.Models.Parametros
{
   public class MDParGnrlPrin :BindableBase
    {
        private bool _condominio;
        public bool condominio
        {
            get { return _condominio; }
            set { SetProperty(ref _condominio, value); }
        }

        private string _selcondDep;
        public string selcondDep
        {
            get { return _selcondDep; }
            set { SetProperty(ref _selcondDep, value); }
        }
    }
}
