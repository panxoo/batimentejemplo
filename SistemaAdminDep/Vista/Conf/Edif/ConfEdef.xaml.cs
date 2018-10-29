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

namespace SistemaAdminDep.Vista.Conf.Edif
{
    /// <summary>
    /// Lógica de interacción para ConfEdef.xaml
    /// </summary>
    public partial class ConfEdef : UserControl
    {
        public ConfEdef()
        {
            VM = new VMConfEdef();
            DataContext = VM;
            InitializeComponent();
        }

        private VMConfEdef VM;
    }
}
