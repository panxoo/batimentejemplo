using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using AccesoDatos.TypeVar;
using ClssVmMdl.Validacion;

namespace ClssVmMdl.Models.Sist
{
    public class MDPantPrincipal : BindableBase
    {

        public MDPantPrincipal()
        {
            msg = new MsgEvents();
        }

        private MsgEvents msg;

        private List<ColIdNameTip> _colecDepart;
        public List<ColIdNameTip> colectDepart
        {
            get { return _colecDepart; }
            set { SetProperty(ref _colecDepart, value); }
        }

        private int _selDepId;
        public int selDepId
        {
            get { return _selDepId; }
            set { SetProperty(ref _selDepId, value); }
        }

        private List<string> _ListHistLog;
        public List<string> ListHistLog
        {
            get { return _ListHistLog; }
            set { SetProperty(ref _ListHistLog, value); }
        }

        private string tabSelect;
        public string TabSelect
        {
            get { return tabSelect; }
            set { SetProperty(ref tabSelect, value); }
        }

        private string item;
        public string Item
        {
            get
            {
                msg.MsgNormal();
                return item;
            }
            set { SetProperty(ref item, value);}
        }
    }
}
