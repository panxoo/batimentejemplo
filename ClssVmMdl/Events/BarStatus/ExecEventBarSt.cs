using System;
using Prism.Events;
using System.Timers;
using ClssVmMdl.VarStatic;

namespace ClssVmMdl.Events.BarStatus
{
    class ExecEventBarSt
    {

        internal ExecEventBarSt(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            TimActNormal = new Timer();

            TimActNormal.Elapsed += TimActNormal_Elapsed;

        }

        private void TimActNormal_Elapsed(object sender, ElapsedEventArgs e)
        {
            MessagShowNorm();
            TimActNormal.Stop();
        }

        private Timer TimActNormal;

        protected readonly IEventAggregator _eventAggregator;

        private FundParmStatBar _statusItem;
        public FundParmStatBar StatusItem
        {
            get { return _statusItem; }
            set
            {
                _statusItem = value;
                _eventAggregator.GetEvent<FundAddStatusBarEvent>().Publish(_statusItem);
            }
        }

        internal void MessagShow(int est, string MsgEvent, string MsgError)
        {
            //if (TimActNormal.Enabled == true)
                TimActNormal.Stop();


            switch (est)
            {
                case 1:
                    StatusItem = new FundParmStatBar
                    {
                        ColorBar = 1,
                        MessgeBar = "Dato resgistrado,  Hora: " + DateTime.Now,
                        MessgErrorBar = "",
                        VisProgres = false
                    };
                    ParSistem.InsPanelLog("Fecha: " + DateTime.Now + " Datos Registrados");
                    TimActNormal.Interval = 4000;
                    break;

                case 2:
                    StatusItem = new FundParmStatBar
                    {
                        ColorBar = 0,
                        MessgeBar = "Error en el Resgistro, " + MsgEvent + "  Hora: " + DateTime.Now,
                        MessgErrorBar = "Error: " + MsgError,
                        VisProgres = false
                    };
                    ParSistem.InsPanelLog("Fecha: " + DateTime.Now + " Error en el Resgistro, " + MsgEvent + " Error: " + MsgError);
                    TimActNormal.Interval = 8000;
                    break;

                case 3:
                    StatusItem = new FundParmStatBar
                    {
                        ColorBar = 2,
                        MessgeBar = "Guardando.  ",
                        MessgErrorBar = "",
                        VisProgres = true
                    };
                    break;

                default:
                    MessagShowNorm();
                    break;
            }
            if (est == 1 || est == 2)
                TimActNormal.Start();
        }

        internal void MessagShow()
        {

            if (TimActNormal.Enabled)
            {
                TimActNormal.Stop();
                //TimActNormal.Interval = 1;
                //TimActNormal.Start();
            }
        }

        private void MessagShowNorm()
        {
            StatusItem = new FundParmStatBar
            {
                ColorBar = 3,
                MessgeBar = "",
                MessgErrorBar = "",
                VisProgres = false,
                MessgSelDepart = ParSistem.TipSelDepart + ": " + ParSistem.NomSelDepart
            };
        }
    }
}
