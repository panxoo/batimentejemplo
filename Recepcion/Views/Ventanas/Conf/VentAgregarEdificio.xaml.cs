using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClssVmMdl.ViewModels.Conf.Edif;

namespace Recepcion.Views.Ventanas.Conf
{
    /// <summary>
    /// Lógica de interacción para VentAgregarEdificio.xaml
    /// </summary>
    public partial class VentAgregarEdificio : Window
    {
        public VentAgregarEdificio()
        {
            InitializeComponent();
           DataContext = new VMAddEd();
        }

        public VentAgregarEdificio(string dep)
        {
            InitializeComponent();
            DataContext = new VMAddEd(dep);
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
