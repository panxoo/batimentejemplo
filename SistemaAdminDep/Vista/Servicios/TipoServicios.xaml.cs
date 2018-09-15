using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
