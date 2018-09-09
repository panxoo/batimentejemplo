using Prism.Events;
using ClssVmMdl.Events.BarStatus;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;
using ClssVmMdl.VarStatic;
using ClssVmMdl.Models.Sist;
using ClssVmMdl.Calling;
using System.Collections.Generic;

namespace ClssVmMdl.ViewModels.Sist
{
    public class VMPantPrincipal : INotifyPropertyChanged
    {

        public VMPantPrincipal(IEventAggregator eventAggregator)
        {
            mod = "ptpr";
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<FundAddStatusBarEvent>().Subscribe((item) => { Item = item; });
            _camp = new MDPantPrincipal();
            Call = new CallDatoSistem(mod);
            CargaIni();
            DelSelectionTab = new DelegateCommand<object>(ExcSelectionTab);
            DelSelectionDepart = new DelegateCommand(ExcSelectionDep);
            DelCloseTab = new DelegateCommand<string>(ExcCloseTab);
        }

        private string mod;
        public DelegateCommand<object> DelSelectionTab { get; set; }
        public DelegateCommand DelSelectionDepart { get; set; }
        public DelegateCommand<string> DelCloseTab { get; set; }

        public System.Action<string> CloseTab { get; set; }

        private CallDatoSistem Call;

        private FundParmStatBar _item;
        public FundParmStatBar Item
        {
            get { return _item; }
            set { _item = value; NotifyPropertyChanged(); }
        }

        private MDPantPrincipal _camp;
        public MDPantPrincipal camp
        {
            get { return _camp; }
            set { _camp = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected readonly IEventAggregator _eventAggregator;

        #region Excecute

        private void ExcSelectionDep()
        {
            SelDepComb();
        }

        private void ExcSelectionTab(object hd)
        {
            if (string.IsNullOrEmpty(_camp.TabSelect))
                _camp.TabSelect = hd.ToString();
            else if (_camp.TabSelect != hd.ToString())
            { 
                StatusBarNormal();
                _camp.TabSelect = hd.ToString();
            }
        }

        private void ExcCloseTab(string Hd)
        {
            CloseTab(Hd);
        }

        #endregion

        #region Metodos

        private void CargaIni()
        {
            ParSistem.Carga(true);
            _camp.colectDepart = Call.SIST_DepartColect(ParSistem.IdCond, ParSistem.MultiEdef);
            ParSistem.SelDep(_camp.colectDepart[0].Tip, _camp.colectDepart[0].Name, _camp.colectDepart[0].Id);
            _camp.selDepId = _camp.colectDepart[0].Id;
            StatusBarNormal();
        }

        private void StatusBarNormal()
        {
            Item = new FundParmStatBar
            {
                ColorBar = 3,
                MessgeBar = "",
                MessgErrorBar = "",
                VisProgres = false,
                MessgSelDepart = ParSistem.TipSelDepart + ": " + ParSistem.NomSelDepart
            };
        }

        private void SelDepComb()
        {
            int IdAux = _camp.colectDepart.FindIndex(x => x.Id == _camp.selDepId);
            ParSistem.SelDep(
                _camp.colectDepart[IdAux].Tip,
                _camp.colectDepart[IdAux].Name,
                _camp.colectDepart[IdAux].Id
                );
            StatusBarNormal();
        }

        public void CargaHistLog()
        {
            _camp.ListHistLog = new List<string>();
            _camp.ListHistLog = ParSistem.LogPanel;
        }

        #endregion
    }
}
