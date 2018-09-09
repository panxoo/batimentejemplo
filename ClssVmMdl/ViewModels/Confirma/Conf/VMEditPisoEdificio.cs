using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;
using ClssVmMdl.Models.Confirma.Conf;
using Prism.Commands;
using ClssVmMdl.Calling;

namespace ClssVmMdl.ViewModels.Confirma.Conf
{
   public class VMEditPisoEdificio : BindableBase , IInteractionRequestAware 
    {
        public VMEditPisoEdificio()
        {
            caldep = new CallDep("piso");
            notification = new MDEditPisoEdificio();

            //CEdit = new DelegateCommand();
        }

        public Action FinishInteraction { get; set; }
        private MDEditPisoEdificio notification;

        public DelegateCommand CEdit { get; private set; }
        public DelegateCommand CUpdate { get; private set; }
        public DelegateCommand CCancel { get; private set; }
        public DelegateCommand PUpdt { get; private set; }
        public DelegateCommand SUpdt { get; private set; }
        public DelegateCommand Close { get; private set; }

        private CallDep caldep;

        public INotification Notification
        {
            get { return notification; }
            set
            {
                if (value is MDEditPisoEdificio)
                {
                    notification = value as MDEditPisoEdificio;
                    this.OnPropertyChanged(() => this.Notification);
                }
            }
                    }

        public void AcceptUpdt()
        {
            if (this.notification != null)
            {
                //if (string.IsNullOrEmpty(notification.parmod.ToString().Trim()))
                //{
                //    notification.LblMsg = "Se debe ingesar nombre del parametro";
                //    return;
                //}
                //else if (notification.parmod.ToString().Trim() == notification.parname)
                //{
                //    notification.LblMsg = "Se debe ingresar un parametro distinto";
                //    return;
                //}

                //CallPG.updParametro(notification.tipoParm, notification.parmod, notification.valor);
                //this.notification.Confirmed = true;
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

        private void CargaEdf()
        {
        
        }

    }
}
