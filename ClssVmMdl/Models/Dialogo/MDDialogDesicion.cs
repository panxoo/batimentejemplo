using Prism.Mvvm;

namespace ClssVmMdl.Models.Dialogo
{
    public class MDDialogDesicion:BindableBase
    {
        private string titulo;
        public  string Titulo
        {
            get => titulo;
            set => SetProperty(ref titulo, value);
        }

        private string detalle;
        public  string Detalle
        {
            get => detalle;
            set => SetProperty(ref detalle, value);
        }
    }
}
