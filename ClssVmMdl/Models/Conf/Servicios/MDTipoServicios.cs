using System;
using System.Data;
using Prism.Mvvm;

namespace ClssVmMdl.Models.Conf.Servicios
{
    public class MDTipoServicios : BindableBase
    {

        public MDTipoServicios()
        {
            val = new Validacion.ValTam();
            AltGrid = 400;
            ModAdd = false;
        }

        private Validacion.ValTam val;


        #region Variables

        private DataTable dtTpSrv;
        public DataTable DtTpSrv
        {
            get => dtTpSrv;
            set => SetProperty(ref dtTpSrv, value);
        }

        private bool modAdd;
        public bool ModAdd
        {
            get => modAdd;
            set => SetProperty(ref modAdd, value);
        }

        private int idTS;
        public int IdTS
        {
            get => idTS;
            set => SetProperty(ref idTS, value);
        }

        private bool actUpdt;
        public bool ActUpdt
        {
            get => actUpdt;
            set => SetProperty(ref actUpdt, value);
        }

        private float altGrid;
        public float AltGrid
        {
            get => altGrid;
            set => SetProperty(ref altGrid, value);
        }

        #endregion

        #region campos

        private string nomTS;
        public string NomTS
        {
            get
            {
                nomTS = val.LimitStrg(nomTS, 10);
                return nomTS;
            }
            set => SetProperty(ref nomTS, value);
        }

        private int cobro;
        public int Cobro
        {
            get => cobro;
            set => SetProperty(ref cobro, value);
        }

        private bool rqReserv;
        public bool RqReserv
        {
            get
            {
                if (rqReserv == false || seCobra == false)
                {                    
                    ResDocum = false;
                    ResEfec = false;
                    ResTrans = false;
                    ResCobTot = false;
                }
                return rqReserv;
            }
            set => SetProperty(ref rqReserv, value);
        }

        private bool resDocum;
        public bool ResDocum
        {
            get => resDocum;
            set => SetProperty(ref resDocum, value);
        }

        private bool resEfec;
        public bool ResEfec
        {
            get => resEfec;
            set => SetProperty(ref resEfec, value);
        }

        private bool resTrans;
        public bool ResTrans
        {
            get => resTrans;
            set => SetProperty(ref resTrans, value);
        }

        private bool resCobTot;
        public bool ResCobTot
        {
            get
            {
                if (resCobTot == false)
                    ResCobMont = 0;
                return resCobTot;
            }
            set => SetProperty(ref resCobTot, value);
        }

        private int resCobMont;
        public int ResCobMont
        {
            get => resCobMont;
            set => SetProperty(ref resCobMont, value);
        }

        private bool rqGarant;
        public bool RqGarant
        {
            get
            {
                if (rqGarant == false)
                    GarValor = 0;
                return rqGarant;
            }
            set => SetProperty(ref rqGarant, value);
        }

        private int garValor;
        public int GarValor
        {
            get=> garValor;
            set => SetProperty(ref garValor, value);
        }

        private bool gcCobro;
        public bool GcCobro
        {
            get => gcCobro;
            set => SetProperty(ref gcCobro, value);
        }

        private bool seCobra;
        public bool SeCobra
        {
            get
            {
                if (seCobra == false)
                {
                    Cobro = 0;
                   // RqReserv = false;
                    GcCobro = false;
                }
                //else
                //    RqReserv = false;

                return seCobra;
            }
            set => SetProperty(ref seCobra, value);
        }

        #endregion
    }
}
