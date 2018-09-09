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
//using Microsoft.Windows.;
using System.Windows.Controls.Ribbon;
using SistemaAdminDep.Clase;

namespace SistemaAdminDep.Vista.Sistema
{
    /// <summary>
    /// Lógica de interacción para ControlMenu.xaml
    /// </summary>
    public partial class ControlMenu : UserControl
    {
        public ControlMenu()
        {
            InitializeComponent();

            //PatallaPrincipal win = (PatallaPrincipal)Window.GetWindow(this);

            //child

            // PatallaPrincipal.cargar("asd");
            asss asds = new asss();

            
            asd.CommandParameter = asds;
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
