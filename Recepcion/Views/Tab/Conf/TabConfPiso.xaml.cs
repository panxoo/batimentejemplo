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

namespace Recepcion.Views.Tab.Conf
{
    /// <summary>
    /// Lógica de interacción para TabConfPiso.xaml
    /// </summary>
    public partial class TabConfPiso : UserControl
    {

        public static readonly DependencyProperty MyCustomProperty =
   DependencyProperty.Register("MyCustom", typeof(string), typeof(TabConfPiso));
        public string MyCustom
        {
            get
            {
                return this.GetValue(MyCustomProperty) as string;
            }
            set
            {
                this.SetValue(MyCustomProperty, value);
            }
        }

        public TabConfPiso()
        {
            InitializeComponent();

            string asddd = MyCustom;
        }
    }
}
