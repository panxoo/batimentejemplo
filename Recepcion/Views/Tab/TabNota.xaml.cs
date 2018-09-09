using System.Windows.Controls;
using ClssVmMdl.ViewModels.Nota; 

namespace Recepcion.Views.Tab
{
    /// <summary>
    /// Lógica de interacción para TabNota.xaml
    /// </summary>
    public partial class TabNota : UserControl
    {
        public TabNota()
        {
            InitializeComponent();
            DataContext = new VMNota();
        }
    }
}
