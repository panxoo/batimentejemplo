using System;
using System.Linq;
using ClssVmMdl.Models.Conf.Parametros;
using ClssVmMdl.Calling;
using System.Data;
using Prism.Mvvm;
using Prism.Commands;
using ClssVmMdl.Models.Confirma.Conf;
using Prism.Interactivity.InteractionRequest;
using ClssVmMdl.Events.BarStatus;
using ClssVmMdl.Events;


namespace ClssVmMdl.ViewModels.Conf.Parametros
{
    public class VMParametros : BindableBase
    {

        public VMParametros()
        {
            ExEvent = new ExecEventBarSt(ApplicationService.Instance.EventAggregator);
            CallPar = new CallParmtGen("mtpr");
            _varPar = new MDParametros();

            CargParam();

            ConfirmPopUpDel = new InteractionRequest<IConfirmation>();
            ConfirmPopUpUpdt = new InteractionRequest<MDModParametros>();

            delCommand = new DelegateCommand<object[]>(RaiseConfirmPopUpDelExc);
            SvCommand = new DelegateCommand<object>(ExcSvPar);
            UpdCommand = new DelegateCommand<object[]>(RaiseConfirmPopUpUdtExc);

        }


        #region Constructor Var

        private ExecEventBarSt ExEvent;

        public InteractionRequest<IConfirmation> ConfirmPopUpDel { get; private set; }
        public InteractionRequest<MDModParametros> ConfirmPopUpUpdt { get; private set; }

        private CallParmtGen CallPar;


        private MDParametros _varPar;
        public MDParametros varPar
        {
            get { return _varPar; }
            set { SetProperty(ref _varPar, value); }
        }

        public DelegateCommand<object[]> delCommand { get; set; }
        public DelegateCommand<object> SvCommand { get; set; }
        public DelegateCommand<object[]> UpdCommand { get; set; }

        private string messageDel(string val) { if (val == "1") return "Desabilitar parametro"; else return "Habilitacion parametro"; }

        #endregion

        #region Carga Grid

        private void CargParam()
        {
            _varPar.LtTpDep = new DataTable();
            _varPar.LtTpDepOt = new DataTable();
            _varPar.LtTpNot = new DataTable();
            _varPar.LtNvlNot = new DataTable();

            _varPar.LtTpDep = CallPar.SelParGnrl(1);
            _varPar.LtTpDepOt = CallPar.SelParGnrl(2);
            _varPar.LtTpNot = CallPar.SelParGnrl(3);
            _varPar.LtNvlNot = CallPar.SelParGnrl(4);
        }

        private void CargParam(int parm)
        {
            if (parm == 1)
                _varPar.LtTpDep = CallPar.SelParGnrl(parm);
            else if (parm == 2)
                _varPar.LtTpDepOt = CallPar.SelParGnrl(parm);
            else if (parm == 3)
                _varPar.LtTpNot = CallPar.SelParGnrl(parm);
            else if (parm == 4)
                _varPar.LtNvlNot = CallPar.SelParGnrl(parm);
        }

        #endregion


        #region EXC Command

        private void ExcDelPar(object[] val)
        {
            int parm = Convert.ToInt32(val[1]);
            int id = Convert.ToInt32(val[2]);

            CallPar.delParametro(parm, id);
            CargParam(parm);
        }




        private void ExcSvPar(object val)
        {
            int parm = Convert.ToInt32(val);
            string nom = "";
            ExEvent.MessagShow();




            if (parm == 1)
                if (_varPar.LtTpDep.Select("name = '" + _varPar.TpDep + "'").Count() == 0)
                    nom = _varPar.TpDep.ToString().Trim();
                else
                {
                    ExEvent.MessagShow(2, "NO SE REGISTRO DATO", "Ya esiste parametro registrado, Seleccionar otro parametro");
                    return;
                }
            else if (parm == 2)
                if (_varPar.LtTpDepOt.Select("name = '" + _varPar.TpDepOt + "'").Count() == 0)
                    nom = _varPar.TpDepOt.ToString().Trim();
                else
                {
                    ExEvent.MessagShow(2, "NO SE REGISTRO DATO", "Ya esiste parametro registrado, Seleccionar otro parametro");
                    return;
                }
            else if (parm == 3)
                if (_varPar.LtTpNot.Select("name = '" + _varPar.TpNot + "'").Count() == 0)
                    nom = _varPar.TpNot.ToString().Trim();
                else
                {
                    ExEvent.MessagShow(2, "NO SE REGISTRO DATO", "Ya esiste parametro registrado, Seleccionar otro parametro");
                    return;
                }
            else if (parm == 4)
                if (_varPar.LtNvlNot.Select("name = '" + _varPar.NvlNot + "'").Count() == 0)
                    nom = _varPar.NvlNot.ToString().Trim();
                else
                {
                    ExEvent.MessagShow(2, "NO SE REGISTRO DATO", "Ya esiste parametro registrado, Seleccionar otro parametro");
                    return;
                }

            if (string.IsNullOrEmpty(nom))
            { return; }

            ExEvent.MessagShow(1, "", "");

            CallPar.savParametro(parm, nom);
            LimpVar(parm);

            CargParam(parm);

        }

        #endregion


        #region ClearVar

        private void LimpVar()
        {
            _varPar.TpDep = "";
            _varPar.TpDepOt = "";
            _varPar.TpNot = "";
            _varPar.NvlNot = "";
        }

        private void LimpVar(int parm)
        {
            if (parm == 1)
                _varPar.TpDep = "";
            else if (parm == 2)
                _varPar.TpDepOt = "";
            else if (parm == 3)
                _varPar.TpNot = "";
            else if (parm == 4)
                _varPar.NvlNot = "";
        }

        #endregion

        #region PopUp

        private void RaiseConfirmPopUpDelExc(object[] val)
        {
            this.ConfirmPopUpDel.Raise(
                           new Confirmation { Content = messageDel(val[0].ToString()), Title = "Confirmación" },
                           c => { if (c.Confirmed == true) ExcDelPar(val); });
        }

        private void RaiseConfirmPopUpUdtExc(object[] val)
        {

            MDModParametros ConfUpdt = new MDModParametros();

            ConfUpdt.parname = val[0].ToString();
            ConfUpdt.tipoParm = Convert.ToInt32(val[1].ToString());
            ConfUpdt.valor = Convert.ToInt32(val[2].ToString());

            ConfUpdt.Title = "Modificar Atributo";

            ConfirmPopUpUpdt.Raise(ConfUpdt,
                 returned =>
                 {
                     if (returned != null && returned.Confirmed)
                     {
                         CargParam(Convert.ToInt32(val[1].ToString()));
                     }

                 });
        }

        #endregion



    }
}
