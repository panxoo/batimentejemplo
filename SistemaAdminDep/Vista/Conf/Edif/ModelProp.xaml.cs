using System;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using ClssVmMdl.ViewModels.Conf.Edif;
using SistemaAdminDep.Dialogo;
using SistemaAdminDep.Validacion;

namespace SistemaAdminDep.Vista.Conf.Edif
{
    /// <summary>
    /// Lógica de interacción para ModelProp.xaml
    /// </summary>
    public partial class ModelProp : UserControl
    {
        public ModelProp()
        {
            vm = new VMModelProp();
            DataContext = vm;

            vm.SelPantalla = new Action<int>((int arg) => SelecMant(arg));
            vm.ActDesicion = new Action<string, string>((string tit, string mns) => Desicion(tit, mns));
            vm.ActError = new Action<string, string>((string tit, string mns) => Error(tit, mns));
            vm.ErrorVal = new Action<int>((int Arg) => prueba(Arg));
            InitializeComponent();
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

        private void prueba(int tp)
        {
            //ValidacionTextVacio val = new ValidacionTextVacio();
            //tbox1.BindingGroup.ValidationRules.Add(val);
            switch (tp)
            {
                case -1:
                    DTboxNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    DTboxNumBa.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    DTboxNumPi.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    DTboxTall.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    DTboxTamu.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    break;

                case 2:
                    BTboxName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    BTboxTamall.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    break;

                case 1:
                    ETboxName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    ETboxTamall.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    ECboxEdf.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
                    break;

            }


        }
    }
}
