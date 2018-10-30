using System;
using System.Windows.Controls;
using ClssVmMdl.ViewModels.Conf.Servicios;
using MaterialDesignThemes.Wpf;
using SistemaAdminDep.Dialogo;

namespace SistemaAdminDep.Vista.Servicios
{
    /// <summary>
    /// Lógica de interacción para TipoServicios.xaml
    /// </summary>
    public partial class TipoServicios : UserControl
    {
        public TipoServicios()
        {
            InitializeComponent();
            vm = new VMTipoServicios();
            this.DataContext = vm;

            vm.ActUpdate = new Action<bool>((bool arg) => Modificar(arg));
            vm.ActDesicion = new Action(() => Desicion());
            vm.ActError = new Action(() => Error());
           
        }

        VMTipoServicios vm;

        private void Modificar(bool opt)
        {
            if (opt)
                Transitioner.SelectedIndex = 1;
            else
                Transitioner.SelectedIndex = 0;
        }

        private async void Desicion()
        {
            DialogDesicion view = new DialogDesicion
            {
                //MnsjDesicion = vm.Vargnrl.MsgDesicion,
                MnsjTitulo = "tpsv"
            };

            var result = await DialogHost.Show(view, "RootDialog");
            vm.ExcDelectAct((bool)(result ?? false));
            GC.Collect();
        }

        private async void Error()
        {
            DialogError view = new DialogError
            {
                //MnsjError = vm.Vargnrl.MsgError,
                TitlError = "tpsv"
            };

            await DialogHost.Show(view, "RootDialog");

            GC.Collect();
        }

    }
}
