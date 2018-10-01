using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ClssVmMdl.Models
{
    public class MDPrueba : BindableBase
    {

        public MDPrueba()
        {
            limp();
        }

        private string nomb;
        public string Nomb
        {
            get => nomb;
            set => SetProperty(ref nomb, value);
        }

        private int numb;
        public int Numb
        {
            get => numb;
            set => SetProperty(ref numb, value);
        }

        public void limp ()
        {
            Nomb = "";
            Numb = 1;
            Numb = 0;
        }


    }
}
