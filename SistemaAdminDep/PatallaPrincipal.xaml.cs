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
using SistemaAdminDep.Vista.Sistema;
using ClssVmMdl.ViewModels.Sist;
using ClssVmMdl.Events;
using SistemaAdminDep.Vista.Servicios;
using SistemaAdminDep.Vista.Conf.Edif;

namespace SistemaAdminDep
{
    /// <summary>
    /// Lógica de interacción para PatallaPrincipal.xaml
    /// </summary>
    public partial class PatallaPrincipal : Window
    {
        public PatallaPrincipal()
        {

            VMPantPrincipal vm = new VMPantPrincipal(ApplicationService.Instance.EventAggregator);

            DataContext = vm;

            InitializeComponent();

            //UserControl UCMenu = new ControlMenu();
            //GridPrincipal.Children.Add(UCMenu);
            vm.CloseTab = new Action<string>((string hd) => tc_Close(hd));
            hola = "hola Mundo";
        }

        public string hola;

        public void cargar(string sdf) => hola = sdf;

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Hola", e.Parameter.ToString());

            //UserControl ass;


        }

        private void BtnReservServ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConfReservServ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnComent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem ti in TbCont.Items)
            {
                if (ti.Header.ToString() == "Condominio")
                {
                    ti.Focus();
                    return;
                }
            }

            ConfEdef PageControl = new ConfEdef();

            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Condominio";

            NewItemTab.Content = PageControl;

            TbCont.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void BtnNewEdif_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNewMod_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem ti in TbCont.Items)
            {
                if (ti.Header.ToString() == "Nue")
                {
                    ti.Focus();
                    return;
                }
            }

            ModelProp PageControl = new ModelProp();

            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Tn Servicio";

            NewItemTab.Content = PageControl;

            TbCont.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void BtnTpServ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTpNt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNewServ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMantServ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConfPar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMantDep_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMantTpSrv_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem ti in TbCont.Items)
            {
                if (ti.Header.ToString() == "Tipo Servicio")
                {
                    ti.Focus();
                    return;
                }
            }

            TipoServicios PageControl = new TipoServicios();

            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Tipo Servicio";

            NewItemTab.Content = PageControl;

            TbCont.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tc_Close(string Hd)
        {

            TabItem sd = new TabItem();
            foreach (TabItem tab in TbCont.Items)
            {
                if (tab.Header.ToString() == Hd)
                    sd = tab;
            }

            TbCont.Items.Remove(sd);
            //TbCont.Items.Refresh();
            GC.Collect();

        }
    }
}
