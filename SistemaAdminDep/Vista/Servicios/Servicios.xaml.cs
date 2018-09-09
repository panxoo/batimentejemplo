﻿using ClssVmMdl.ViewModels.Conf.Servicios;
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

namespace SistemaAdminDep.Vista.Servicios
{
    /// <summary>
    /// Lógica de interacción para Servicios.xaml
    /// </summary>
    public partial class Servicios : UserControl
    {
        public Servicios()
        {
            vm = new VMServicios();
            DataContext = vm;
            InitializeComponent();
            Transitioner.SelectedIndex = 1;
        }

        VMServicios vm;
    }
}
