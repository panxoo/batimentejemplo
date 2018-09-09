using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using Recepcion.Views.Ventanas.Conf;
using Recepcion.Ventanas;
using Recepcion.Views.Tab;
using Recepcion.Views.Tab.Conf;
using ClssVmMdl.ViewModels.Sist;
using ClssVmMdl.Events;
using System.Windows.Media.Animation;
using System;
using Recepcion.Views.Tab.Servicios;
using MahApps.Metro.Controls;

namespace Recepcion
{

    /// <summary>
    /// Interaction logic for PantPrincipal.xaml
    /// </summary>
    public partial class PantPrincipal : Window
    {
        public PantPrincipal()
        {
            VMPP = new VMPantPrincipal(ApplicationService.Instance.EventAggregator);
            DataContext = VMPP;
            HideDisplay = true;
            InitializeComponent();
            
        }

        private VMPantPrincipal VMPP;
        private bool HideDisplay; 

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Nuevo Propietario"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabNewPropiet PageControl = new TabNewPropiet();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Nuevo Propietario";
            NewItemTab.Content = PageControl;


            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();





        }

        private void BtnReservServ_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Reserva Servicios"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabReservServ PageControl = new TabReservServ();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Reserva Servicios";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void BtnConfReservServ_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Confirmar Reserva Servicios"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabConfReserva PageControl = new TabConfReserva();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Confirmar Reserva Servicios";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void BtnComent_Click(object sender, RoutedEventArgs e)
        {
            ComentNota Pag = new ComentNota();

            Pag.Show();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Configuracion Edificio"))
                {
                    tabList.Focus();
                    return;
                }

            }

            Views.Tab.Conf.TabConfEdef PageControl = new Views.Tab.Conf.TabConfEdef();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Configuracion Edificio";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void BtnNewEdif_Click(object sender, RoutedEventArgs e)
        {
            VentAgregarEdificio Pag = new VentAgregarEdificio();

            Pag.Show();
        }

        private void BtnNewMod_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Nuevo Modelo"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabModelProp PageControl = new TabModelProp();
            //TabParametros  PageControl = new TabParametros();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Nuevo Modelo";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void BtnTpServ_Click(object sender, RoutedEventArgs e)
        {
            VentParServ Pag = new VentParServ();

            Pag.Show();
        }

        private void BtnTpNt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNewServ_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Servicios"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabServicios PageControl = new TabServicios();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Servicios";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void BtnMantServ_Click(object sender, RoutedEventArgs e)
        {
            VentManServ Pag = new VentManServ();

            Pag.Show();
        }

        private void TabItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConfPar_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Conf Parametro"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabParametros PageControl = new TabParametros();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Conf Parametro";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }



        private void BtnMantDep_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Conf Departamento"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabMantPropied PageControl = new TabMantPropied();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Conf Departamento";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VMPP.CargaHistLog();
            Storyboard sb = Resources["sbShowBottomMenu"] as Storyboard;
            sb.Begin(pnlBottomMenu);
            HideDisplay = false;

           
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HidePanel();

        }

        private void HidePanel()
        {
            if (HideDisplay == false)
            {
                try
                {
                    Storyboard sb = Resources["sbHideBottomMenu"] as Storyboard;
                    sb.Begin(pnlBottomMenu);
                    HideDisplay = true;
                }
                catch (Exception ex) { }
            }
        }


        private void tc_GotFocus(object sender, RoutedEventArgs e) => HidePanel();

        private void BtnMantTpSrv_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabList in tc.Items)
            {
                if (tabList.Header.Equals("Tipo Servicio"))
                {
                    tabList.Focus();
                    return;
                }

            }

            TabTipoServicios PageControl = new TabTipoServicios();
            TabItem NewItemTab = new TabItem();

            NewItemTab.Header = "Tipo Servicio";
            NewItemTab.Content = PageControl;

            tc.Items.Add(NewItemTab);
            NewItemTab.Focus();
        }
    }
}
