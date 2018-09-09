using Prism.Mvvm;
using ClssVmMdl.Validacion;
using System.Data;
using ClssVmMdl.VarStatic;

namespace ClssVmMdl.Models.Conf.Servicios
{
    public class MDServicios : BindableBase
    {

        public MDServicios()
        {
            vali = new ValTam();
            IdMinEd = -1;
            IdMinTp = -1;
            ModAdd = false;
            Idedf = -1;
        }

        #region Preporty

        private ValTam vali;

        #endregion

        #region Campo Extra

        private bool costAct;
        public bool CostAct
        {
            get
            {
                if (costAct == false)
                    CostUso = false;

                return costAct;
            }
            set => SetProperty(ref costAct, value);
        }

        private int costValAct;
        public int CostValAct
        {
            get => costValAct;
            set => SetProperty(ref costValAct, value);
        }

        private bool updtAct;
        public bool UpdtAct
        {
            get => updtAct;
            set => SetProperty(ref updtAct, value);
        }

        private int updtId;
        public int UpdtInt
        {
            get => updtId;
            set => SetProperty(ref updtId, value);
        }

        private int idDelt;
        public int IdDelt
        {
            get => idDelt;
            set => SetProperty(ref idDelt, value);
        }

        private bool modAdd;
        public bool ModAdd
        {
            get
            {
                if (modAdd == false)
                    LimpCamp();
                return modAdd;
            }
            set => SetProperty(ref modAdd, value);
        }

        private int idMinEd;
        public int IdMinEd
        {
            get => idMinEd;
            set
            {
                SetProperty(ref idMinEd, value);
                //Idedf = idMinEd;
            }
        }

        private int idMinTp;
        public int IdMinTp
        {
            get => idMinTp;
            set
            {
                SetProperty(ref idMinTp, value);
                IdTpsrv = idMinTp;
            }
        }

        #endregion


        #region campos

        private DataTable dtServ;
        public DataTable DtServ
        {
            get => dtServ;
            set => SetProperty(ref dtServ, value);
        }

        private DataTable dtTpSrv;
        public DataTable DtTpSrv
        {
            get => dtTpSrv;
            set => SetProperty(ref dtTpSrv, value);
        }

        private int idsrv;
        public int Idsrv
        {
            get => idsrv;
            set => SetProperty(ref idsrv, value);
        }

        private int idedf;
        public int Idedf
        {
            get
            {
                return idedf;
            }

            set => SetProperty(ref idedf, value);
        }

        private int idTpsrv;
        public int IdTpsrv
        {
            get { return idTpsrv; }
            set => SetProperty(ref idTpsrv, value);
        }

        private string nomsrv;
        public string Nomsrv
        {
            get
            {
                nomsrv = vali.LimitStrg(nomsrv, 100);
                return nomsrv;
            }
            set => SetProperty(ref nomsrv, value);
        }

        private bool costfj;
        public bool Costfj
        {
            get
            {
                if (costfj == false)
                {
                    CostFjval = 0;
                    CostFjd = true;
                    CostFjm = false;
                }

                return costfj;
            }

            set => SetProperty(ref costfj, value);
        }

        private int costFjval;
        public int CostFjval
        {
            get => costFjval;
            set => SetProperty(ref costFjval, value);
        }

        private bool costFjd;
        public bool CostFjd
        {
            get => costFjd;
            set => SetProperty(ref costFjd, value);
        }

        private bool costFjm;
        public bool CostFjm
        {
            get => costFjm;
            set => SetProperty(ref costFjm, value);
        }

        private bool costUso;
        public bool CostUso
        {
            get
            {
                if (costUso == false)
                    CostUsval = 0;

                return costUso;
            }

            set => SetProperty(ref costUso, value);
        }

        private int costUsval;
        public int CostUsval
        {
            get => costUsval;
            set => SetProperty(ref costUsval, value);
        }

        private bool condUs;
        public bool CondUs
        {
            get
            {
                return condUs;
            }

            set => SetProperty(ref condUs, value);
        }




        #endregion


        #region Metodo

        private void LimpCamp()
        {
            Nomsrv = "";
            if (ParSistem.MultiEdef == true)
            {
                CondUs = false;
                Idedf = -1;
            }
            CostUso = false;
            Costfj = false;
            IdTpsrv = idMinTp;
            UpdtAct = false;
            IdDelt = new int();
            Idsrv = new int();
        }




        #endregion

    }
}
