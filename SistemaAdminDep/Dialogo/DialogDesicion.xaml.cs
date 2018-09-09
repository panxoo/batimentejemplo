using System.Windows;
using System.Windows.Controls;
using ClssVmMdl.ViewModels.Dialogo;

namespace SistemaAdminDep.Dialogo
{

    public partial class DialogDesicion : UserControl 
    {
        public DialogDesicion()
        {
            vm = new VMDialogDesicion();
            DataContext = vm;

            InitializeComponent();
        }

        private VMDialogDesicion vm;
        public string MnsjDesicion;
        public string MnsjTitulo;
                       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm.Camp.Detalle = MnsjDesicion;
            vm.Camp.Titulo = MnsjTitulo;

        }

        
    }
}
