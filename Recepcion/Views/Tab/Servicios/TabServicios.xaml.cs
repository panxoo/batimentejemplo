using System.Windows.Controls;
using ClssVmMdl.ViewModels.Conf.Servicios;

namespace Recepcion.Views.Tab.Servicios
{
    /// <summary>
    /// Lógica de interacción para TabServicios.xaml
    /// </summary>
    public partial class TabServicios : UserControl
    {
        public TabServicios()
        {
            InitializeComponent();
            DataContext = new VMServicios();

        }
    }
}
