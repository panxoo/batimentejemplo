using System;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using ClssVmMdl.ViewModels.Conf.Edif;
using SistemaAdminDep.Dialogo;

namespace SistemaAdminDep.Vista.Conf.Edif
{
    /// <summary>
    /// Lógica de interacción para ModelProp.xaml
    /// </summary>
    public partial class ModelProp : UserControl
    {
        public ModelProp()
        {
            InitializeComponent();
            vm = new VMModelProp();
            DataContext = vm;

            vm.SelPantalla = new Action<int>((int arg) => SelecMant(arg));
            vm.ActDesicion = new Action<string,string>((string tit, string mns) => Desicion(tit,mns));
            vm.ActError = new Action<string,string>((string tit, string mns) => Error(tit, mns));
        }

        VMModelProp vm;


        private void SelecMant(int opc)
        {
            switch (opc)
            {
                case 0:
                    Transitioner.SelectedIndex = 0;
                    break;
                case -1:
                    Transitioner.SelectedIndex = 1;
                    break;
                case 2:
                    Transitioner.SelectedIndex = 2;
                    break;
                case 1:
                    Transitioner.SelectedIndex = 3;
                    break;
            }
        }

        private async void Desicion(string titulo, string mnsg)
        {
            DialogDesicion view = new DialogDesicion
            {
                MnsjDesicion = mnsg,
                MnsjTitulo = titulo
            };

            var result = await DialogHost.Show(view, "RootDialog");
            vm.ExcDeltAct((bool)(result ?? false));
            GC.Collect();
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
