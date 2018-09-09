using ClssVmMdl.ViewModels.Conf.Edif;
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

namespace Recepcion.Ventanas
{
    /// <summary>
    /// Lógica de interacción para VentManServ.xaml
    /// </summary>
    public partial class VentManServ : Window
    {
        public VentManServ()
        {
            InitializeComponent();
            //DataContext = new VMMantPropied();
        }

        private bool UpdtAct;

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (UpdtAct == false)
            {
                Dgrid.SelectedCells.Last().Column.IsReadOnly = false;
                UpdtAct = true;
            }
        }
        private void Dgrid_GotFocus(object sender, RoutedEventArgs e)
        {
            ((SolidColorBrush)Dgrid.Resources["SelectionColorKey"]).Color = SystemColors.HighlightColor;
        }

        private void Dgrid_LostFocus(object sender, RoutedEventArgs e)
        {
            ((SolidColorBrush)Dgrid.Resources["SelectionColorKey"]).Color = Colors.DarkOrange;
        }

        private void Dgrid_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ((SolidColorBrush)Dgrid.Resources["SelectionColorKey"]).Color = Colors.DarkOrange;
        }
    }
}
