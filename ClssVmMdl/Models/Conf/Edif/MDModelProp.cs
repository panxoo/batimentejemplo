using Prism.Mvvm;
using System.Data;
using ClssVmMdl.Validacion;
using System;

namespace ClssVmMdl.Models.Conf.Edif
{
    public class MDModelProp : BindableBase
    {

        public MDModelProp()
        {
            val = new ValTam();
            UpdtAct = false;
               LimpVar();
        }

        private ValTam val;


        #region Tab

        private DataTable tabbod;
        public DataTable Tabbod
        {
            get => tabbod;
            set => SetProperty(ref tabbod, value);
        }

        private DataTable tabest;
        public DataTable Tabest
        {
            get => tabest;
            set => SetProperty(ref tabest, value);
        }

        private DataTable tabed;
        public DataTable Tabed
        {
            get => tabed;
            set => SetProperty(ref tabed, value);
        }

        #endregion

        
        #region ModGeneral


        private int idedf;
        public int Idedf
        {
            get => idedf;
            set => SetProperty(ref idedf, value);
        }

        private string nomb;
        public string Nomb
        {
            get
            {
                nomb = val.LimitStrg(nomb, 50);
                return nomb;
            }
            set => SetProperty(ref nomb, value);
        }

        private bool condsel;
        public bool Condsel
        {
            get => condsel;
            set => SetProperty(ref condsel, value);
        }

        private double tamall;
        public double Tamall
        {
            get => tamall;
            set => SetProperty(ref tamall, value);

        }

        #endregion

        
        #region ModDepartament


        private int idtpedf;
        public int Idtpedf
        {
            get => idtpedf;
            set => SetProperty(ref idtpedf, value);
        }

        private double tamut;
        public double Tamut
        {
            get => tamut;
            set => SetProperty(ref tamut, value);
        }

        private int cantban;
        public int Cantban
        {
            get => cantban;
            set => SetProperty(ref cantban, value);
        }

        private int cantdor;
        public int Cantdor
        {
            get => cantdor;
            set => SetProperty(ref cantdor, value);
        }


        #endregion


        #region General

        private bool multEdf;
        public bool MultEdf
        {
            get => multEdf;
            set => SetProperty(ref multEdf, value);
        }

        private bool updtAct;
        public bool UpdtAct
        {
            get => updtAct;
            set => SetProperty(ref updtAct, value);
        }

        private int idModSel;
        public int IdModSel
        {
            get => idModSel;
            set => SetProperty(ref idModSel, value);
        }


        private int idTpModSel;
        public int IdTpModSel
        {
            get => idTpModSel;
            set => SetProperty(ref idTpModSel, value);
        }


        #endregion


        public void LimpVar()
        {
            Nomb = string.Empty;
            Cantban = 0;
            Cantdor = 0;
            Tamall = 0;
            Tamut = 0;

            Condsel = true;

            this.Idedf = -1;
            this.Idtpedf = -1;

        }


    }
}
