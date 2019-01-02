using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using ClssVmMdl.ViewModels.Conf.Edif;
using MaterialDesignThemes.Wpf;
using SistemaAdminDep.Dialogo;

namespace SistemaAdminDep.Vista.Conf.Edif
{
    /// <summary>
    /// Lógica de interacción para ConfEdef.xaml
    /// </summary>
    public partial class ConfEdef : UserControl 
    {
        public ConfEdef()
        {
            vm = new VMConfEdef();
            DataContext = vm;
            //TRANS.SelectedIndex = 0;
            InitializeComponent();

            vm.ACUpdtDep = new Action<bool>((bool Arg) => ActUpdt(Arg));

            vm.ActDesicion = new Action<string, string>((string tit, string mns) => Desicion(tit, mns));
            vm.ActError = new Action<string, string>((string tit, string mns) => Error(tit, mns));

        }

        private VMConfEdef vm;

        private void ActUpdt(bool opt)
        {
            if (opt == false)
                Trans.SelectedIndex = 0;
            else
                Trans.SelectedIndex = 1;
        }


        private async Task<bool> Desicion(string titulo, string mnsg)
        {
            DialogDesicion view = new DialogDesicion
            {
                MnsjDesicion = mnsg,
                MnsjTitulo = titulo
            };

            var result = await DialogHost.Show(view, "RootDialog");
            //vm.ExcDeltAct((bool)(result ?? false));

            return (bool)(result ?? false);
            //GC.Collect();
        }

        private async void Error(string titulo, string mnsg)
        {
            DialogError view = new DialogError
            {
                MnsjError = mnsg,
                TitlError = titulo
            };

            await DialogHost.Show(view, "RootDialog");

            GC.Collect();
        }
    }
}
