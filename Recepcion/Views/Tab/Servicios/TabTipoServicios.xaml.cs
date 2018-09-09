using System.Windows.Controls;
using ClssVmMdl.ViewModels.Conf.Servicios;

namespace Recepcion.Views.Tab.Servicios
{
    /// <summary>
    /// Lógica de interacción para TabTipoServicios.xaml
    /// </summary>
    public partial class TabTipoServicios : UserControl
    {
        public TabTipoServicios()
        {
            InitializeComponent();
            DataContext = new VMTipoServicios();
        } 
    }
}
