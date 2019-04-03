using Prism.Mvvm;
using System.Data;
using ClssVmMdl.Validacion;
using System;
using Prism.Validation;
using System.ComponentModel.DataAnnotations;

namespace ClssVmMdl.Models.Conf.Edif
{
    public class MDModelProp : ValidatableBindableBase
    {

        public MDModelProp()
        {
            val = new ValTam();
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
                nomb = val.LimitStrg(nomb, 5);
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
        
        private bool updtAct;
        public bool UpdtAct
        {
            get => updtAct;
            set => SetProperty(ref updtAct, value);
        }

        private bool selMod;
        public bool SelMod
        {
            get => selMod;
            set => SetProperty(ref selMod, value);
        }

        private int idTpModSel;
        public int IdTpModSel
        {
            get => idTpModSel;
            set => SetProperty(ref idTpModSel, value);
        }

        private int tpModSel;
        public int TpModSel
        {
            get => tpModSel;
            set => SetProperty(ref tpModSel, value);
        }

        private bool vigenteIdSel;
        public bool VigenteIdSel
        {
            get => vigenteIdSel;
            set => SetProperty(ref vigenteIdSel, value);
        }

        #endregion


        public void LimpVar()
        {
            Nomb = null;
            Cantban = 1;
            Cantban = new int();

            Cantdor = 1;
            Cantdor = new int();

            Tamall = 1;
            Tamall = new double();

            Tamut = 1;
            Tamut = new double();

            UpdtAct = false;
            SelMod = false;
            IdTpModSel = -1;

            Condsel = true;

            Idedf = 1;
            Idtpedf = 1;
            Idedf = new int();
            Idtpedf = new int();

        }


    }
}
