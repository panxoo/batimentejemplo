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
using ClssVmMdl.ViewModels.Conf.Parametros;
using ClssVmMdl.Events;
using System.Data;

namespace Recepcion.Views.Tab.Conf
{
    /// <summary>
    /// Lógica de interacción para TabParametros.xaml
    /// </summary>
   public  partial class TabParametros : UserControl
    {
        public TabParametros()
        {
            InitializeComponent();
            DataContext = new VMParametros();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

          
        }

        private void btna_Click(object sender, RoutedEventArgs e)
        {
            //var row = GetParent<DataGridRow>((Button)sender);
            ////Grd.Items.IndexOf(row.Item).
            //    var index = Grd.Items.IndexOf(row.Item);
            //MessageBox.Show("Index = " + index, "Clicked Value");
            ////Grd.CurrentCell =

            //var col = Grd.Columns.IndexOf(row.Item);
            //var cu = Grd.CurrentCell;

         
            //DataGridRow dss = Grd.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //DataGridRow aa = Grd.SelectedItems[index] as DataGridRow;
            

            //    Grd.Columns[1].GetCellContent(row.Item) as DataGridCell;

            //Cel.IsSelec


        
        }

        private TargetType GetParent<TargetType>(DependencyObject o)  where TargetType : DependencyObject
        {
            if (o == null || o is TargetType)
                return (TargetType)o;
            return GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }



    }
}

