﻿using ClssVmMdl.ViewModels;
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

namespace SistemaAdminDep.Vista
{
    /// <summary>
    /// Lógica de interacción para Prueba.xaml
    /// </summary>
    public partial class Prueba : UserControl
    {
        public Prueba()
        {
            DataContext =new VMPrueba();
            st = "haloja";
            InitializeComponent();
        }

        public string st;

        private void StackPanel_Error(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}
