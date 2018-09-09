using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using ClssVmMdl.Models.Confirma.Conf;
using ClssVmMdl.Calling;
using System.Windows.Input;

namespace ClssVmMdl.ViewModels.Confirma.Conf
{
   public class VMModParametros :BindableBase, IInteractionRequestAware
    {
        private MDModParametros notification;

        public VMModParametros()
        {
            CallPG = new CallParmtGen("mdpr");

            AceptCommand = new DelegateCommand(AcceptUpdt);
            CancelCommand = new DelegateCommand(CancelUpdt);
        }

        public Action FinishInteraction { get; set; }

        public ICommand AceptCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        private CallParmtGen CallPG;

        public INotification Notification
        {
            get { return notification; }
            set
            {
                if (value is MDModParametros)
                {
                    notification = value as MDModParametros;
                    this.OnPropertyChanged(() => this.Notification);
                }
            }

        }

        public void AcceptUpdt()
        {
            if (this.notification != null)
            {
                if (string.IsNullOrEmpty(notification.parmod.ToString().Trim()))
                {
                    notification.LblMsg = "Se debe ingesar nombre del parametro";
                    return;
                }
                else if (notification.parmod.ToString().Trim() == notification.parname)
                {
                    notification.LblMsg = "Se debe ingresar un parametro distinto";
                    return;
                }

                CallPG.updParametro(notification.tipoParm, notification.parmod, notification.valor);
                this.notification.Confirmed = true;
            }

            this.FinishInteraction();
        }

        public void CancelUpdt()
        {
            if (this.notification != null)
            {
                this.notification.Confirmed = false;
            }

            this.FinishInteraction();
        }
    }
}
