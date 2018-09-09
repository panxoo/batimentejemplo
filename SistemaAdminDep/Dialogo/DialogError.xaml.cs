using ClssVmMdl.ViewModels.Dialogo;
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

namespace SistemaAdminDep.Dialogo
{
    /// <summary>
    /// Lógica de interacción para DialogError.xaml
    /// </summary>
    public partial class DialogError : UserControl
    {
        public DialogError()
        {
            vm = new VMDialogError();
            DataContext = vm;

            InitializeComponent();
        }

        VMDialogError vm;
        public string TitlError;
        public string MnsjError;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            vm.Camp.Detalle = MnsjError;
            vm.Camp.Titulo = TitlError;
        }
    }
}
