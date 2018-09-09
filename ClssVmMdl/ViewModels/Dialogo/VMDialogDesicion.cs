using Prism.Mvvm;
using ClssVmMdl.Models.Dialogo;


namespace ClssVmMdl.ViewModels.Dialogo
{
    public class VMDialogDesicion : BindableBase
    {

        public VMDialogDesicion()
        {
            camp = new MDDialogDesicion();
        }

        private MDDialogDesicion camp;
        public MDDialogDesicion Camp
        {
            get => camp;
            set => SetProperty(ref camp, value);
        }


    }
}
