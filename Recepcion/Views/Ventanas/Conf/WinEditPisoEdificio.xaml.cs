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
using System.Windows.Shapes;
using ClssVmMdl.ViewModels.Confirma.Conf;

namespace Recepcion.Views.Ventanas.Conf
{
    /// <summary>
    /// Lógica de interacción para WinEditPisoEdificio.xaml
    /// </summary>
    public partial class WinEditPisoEdificio : UserControl
    {
        public WinEditPisoEdificio()
        {
            InitializeComponent();
            DataContext = new VMEditPisoEdificio();
        }
    }
}
