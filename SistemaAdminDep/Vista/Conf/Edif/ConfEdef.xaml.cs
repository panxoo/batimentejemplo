using System;
using System.Windows.Controls;
using ClssVmMdl.ViewModels.Conf.Edif;
using MaterialDesignThemes.Wpf;
using SistemaAdminDep.Dialogo;

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
            //TRANS.SelectedIndex = 0;
            InitializeComponent();

            VM.ACUpdtDep = new Action<bool>((bool Arg) => ActUpdt(Arg));
        }

        private VMConfEdef VM;

        private void ActUpdt(bool opt)
        {
            if (opt == false)
                Trans.SelectedIndex = 0;
            else
                Trans.SelectedIndex = 1;
        }
    }
}
