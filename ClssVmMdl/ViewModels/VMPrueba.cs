using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using ClssVmMdl.Models;

namespace ClssVmMdl.ViewModels
{
    public class VMPrueba : BindableBase
    {
        public VMPrueba()
        {
            camp = new MDPrueba();
            DelGuardar = new DelegateCommand(ExcGuardar);
            DelCancelar = new DelegateCommand(ExcCancelar);
        }

        private MDPrueba camp;
        public MDPrueba Camp
        {
            get => camp;
            set => SetProperty(ref camp, value);
        }

        public DelegateCommand DelGuardar { get; set; }
        public DelegateCommand DelCancelar { get; set; }
        
        private void ExcGuardar()
        {

        }

        private void ExcCancelar()
        {
            camp.limp();
        }
    }
}
