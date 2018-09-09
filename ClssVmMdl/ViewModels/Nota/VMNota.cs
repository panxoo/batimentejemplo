using System.Linq;
using ClssVmMdl.Models.Nota;
using Prism.Mvvm;
using ClssVmMdl.Calling;
using ClssVmMdl.Models.Parametros;
using ClssVmMdl.VarStatic;
using ClssVmMdl.Validacion;
using Prism.Commands;
using System.Collections.Generic;
using System;

namespace ClssVmMdl.ViewModels.Nota
{
    public class VMNota : BindableBase
    {

        public VMNota()
        {
            mod = "ptnt";
            camp = new MDNota();
            vargnrl = new MDVarGnrl();
            msgev = new MsgEvents();
            vali = new ValElemment();
            callnt = new CallNota(mod);
            callvar = new CallVariables(mod);

            Inicio();

            DelAlmacenar = new DelegateCommand(ExcAlmacenar);
            DelComent = new DelegateCommand<object[]>(ExcComent);
            DelSavComent = new DelegateCommand(ExcSavComent);
        }



        #region Property

        private MDNota camp;
        public MDNota Camp
        {
            get => camp;
            set => SetProperty(ref camp, value);
        }

        private MDVarGnrl vargnrl;
        public MDVarGnrl Vargnrl
        {
            get => vargnrl;
            set => SetProperty(ref vargnrl, value);
        }

        private CallNota callnt;
        private CallVariables callvar;

        private MsgEvents msgev;
        private ValElemment vali;

        private string mod;

        public DelegateCommand DelAlmacenar { get; set; }
        public DelegateCommand<object[]> DelComent { get; set; }
        public DelegateCommand<object> DelDeletMsj { get; set; }
        public DelegateCommand<object> DelDeletComent { get; set; }
        public DelegateCommand DelSavComent { get; set; }
        public DelegateCommand DelCancel { get; set; }
        

        #endregion



        #region Execute

        private void ExcAlmacenar() => Almacenar();

        private void ExcComent(object[] parm)
        {
            CargaComent(Convert.ToInt32(parm[0]));
            camp.IdMnsg = Convert.ToInt32(parm[0]);
            camp.Mnsg = parm[1].ToString(); //camp.DtNotas.Select("id = " + camp.IdMnsg.ToString()).First().ItemArray[3].ToString();
            Camp.SelComnt = true;
        } 

        private void ExcDeletMsj(object id)
        {
           string fech= camp.DtNotas.Select("id = " + id.ToString()).GetValue(2).ToString();  
            Eliminar(Convert.ToInt32(id), 0);
        }

        private void ExcDeletComent(object id)
        {
            Eliminar(Convert.ToInt32(id), 1);
        }

        private void ExcSavComent()
        {
            AlmacenarComnt();
        }

        private void ExcCancel()
        {
            Camp.SelComnt = false;
        }

        #endregion



        #region Metodo

        private void Inicio()
        {

            camp.DtNotas = callnt.PTNT_GrdNotas(ParSistem.IdCond,ParSistem.IdSelDepart,1);

            camp.TpNota = callnt.PTNT_Tpnota(ParSistem.IdCond);
            camp.TpNvl = callnt.PTNT_Tpnvl();

            if (camp.TpNota.Count() > 0)
            {
                camp.IdTpNota = camp.TpNota.Min(p => p.Id);
            }

            if (camp.TpNvl.Count() > 0)
            {
                camp.IdNvl = camp.TpNvl.Min(p => p.Id);
            }

            if (ParSistem.MultiEdef == true)
            {
                vargnrl.edific = callvar.PRGN_Edif(ParSistem.IdCond);
                vargnrl.MultEdf = ParSistem.MultiEdef;
            }
        }

        private void CargaComent(int id)
        {
          camp.LtComent = callnt.PTNT_Coments(ParSistem.IdCond, id);
        }

        private void Almacenar()
        {
            string a = "";

            if (vali.EmptyStrg(new List<string> { camp.Nt_txt }) == false)
            {
                a = "2";
            }

            if (a == "")
            {
                int Edf;
                if (camp.SelCond == true)
                    Edf = ParSistem.IdCondEdf;
                else
                    Edf = camp.IdEdf;
                if (camp.SelTAct == false)
                    camp.FFinal = DateTime.Now;

                a = callnt.PTNT_SavNota(camp.Nt_txt, camp.IdEdf, camp.IdTpNota, camp.IdNvl, camp.SelTAct, camp.FFinal);
            }

            Mensaje(a, 0);
        }

        private void AlmacenarComnt()
        {
            string a = "";

            if(vali.EmptyStrg(new List<string> { camp.MnsgComnt}) == false)
            {
                a = "2";
            }

            if(a == "")
            {
                a = callnt.PTNT_SavComent(ParSistem.IdCond, camp.IdMnsg, camp.MnsgComnt);
            }

            Mensaje(a, 1);
        }

        private void Eliminar(int id, int tp)
        {
            string a = "";

            switch (tp)
            {
                case 0:

                    a = callnt.PTNT_DelMessage(ParSistem.IdCond, id);

                    break;
                case 1:

                    a = callnt.PTNT_DelMessage(ParSistem.IdCond, camp.IdMnsg, id);

                    break;
            }

            Mensaje(a, tp);
        }

        private void Mensaje(string a, int tp)
        {
            if (a == "1")
            {
                //  camp.DtServ = callsrv.SRVI_Servicios(ParSistem.IdCond);
                msgev.MsgAlmacenar(mod, a);
                if (tp == 1)
                {
                    CargaComent(camp.IdMnsg);
                    //camp.DtNotas = callnt.PTNT_GrdNotas(ParSistem.IdCond,par);
                }
            }
            else
            {
                msgev.MsgAlmacenar(mod, a);
                vargnrl.MsgError = mod + ";" + a;
                vargnrl.selMsg = true;
            }

        }

        #endregion
    }
}
