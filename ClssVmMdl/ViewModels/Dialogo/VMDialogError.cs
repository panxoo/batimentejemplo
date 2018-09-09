using ClssVmMdl.Models.Dialogo;
using Prism.Mvvm;

namespace ClssVmMdl.ViewModels.Dialogo
{
    public class VMDialogError:BindableBase
    {
        public VMDialogError()
        {
            camp = new MDDialogError();
        }

        private MDDialogError camp;
        public MDDialogError Camp
        {
            get => camp;
            set => SetProperty(ref camp, value);
        }
    }
}
