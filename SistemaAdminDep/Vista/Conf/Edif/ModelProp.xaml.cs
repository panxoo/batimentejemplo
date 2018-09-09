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
using MaterialDesignThemes.Wpf;
using ClssVmMdl.ViewModels.Conf.Edif;

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
        }

        VMModelProp vm;

        
        private void SelecMant(int opc)
        {
            switch (opc)
            {
                case 0:
                    Transitioner.SelectedIndex = 0;
                    break;
                case 1:
                    Transitioner.SelectedIndex = 1;
                    break;
                case 2:
                    Transitioner.SelectedIndex = 2;
                    break;
                case 3:
                    Transitioner.SelectedIndex = 3;
                    break;
            }
        }
    }
}
