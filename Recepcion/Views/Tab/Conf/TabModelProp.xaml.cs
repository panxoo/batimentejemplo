using System.Windows.Controls;
using ClssVmMdl.ViewModels.Conf.Edif;

namespace Recepcion.Views.Tab.Conf
{
    /// <summary>
    /// Lógica de interacción para TabModelProp.xaml
    /// </summary>
    public partial class TabModelProp : UserControl
    {
        public TabModelProp()
        {
            InitializeComponent();
            DataContext = new VMModelProp();
        }

    }
}
