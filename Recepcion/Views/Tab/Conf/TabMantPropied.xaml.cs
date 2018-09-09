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
using ClssVmMdl.ViewModels.Conf.Edif;

namespace Recepcion.Views.Tab.Conf
{
    /// <summary>
    /// Lógica de interacción para TabMantPropied.xaml
    /// </summary>+
    public partial class TabMantPropied : UserControl
    {
        public TabMantPropied()
        {
            InitializeComponent();
            DataContext = new VMMantPropied();
        }



    }
}
