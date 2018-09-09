using System.Collections.Generic;
using Prism.Mvvm;
using System.Data;
using AccesoDatos.TypeVar;
using System;

namespace ClssVmMdl.Models.Nota
{
    public class MDNota : BindableBase
    {

        public MDNota()
        {
            LtComent = new List<ColComent>();
            SelCond = false;
            SelTAct = false;
            SelComnt = false;
            Selgnrl = false;
        }

        #region Campos Extra

        private DataTable dtNotas;
        public DataTable DtNotas
        {
            get => dtNotas;
            set => SetProperty(ref dtNotas, value);
        }

        private bool selCond;
        public bool SelCond
        {
            get => selCond;
            set => SetProperty(ref selCond, value);
        }

        private List<ColComent> ltComent;
        public List<ColComent> LtComent
        {
            get => ltComent;
            set => SetProperty(ref ltComent, value);
        }

        private bool selComnt;
        public bool SelComnt
        {
            get
            {
                if(selComnt == false)
                {
                    LtComent.Clear();
                    IdMnsg = new int();
                    Mnsg = "";
                    MnsgComnt = "";
                }
                return selComnt;
            }
            set => SetProperty(ref selComnt, value);
        }

        private int idMnsg;
        public int IdMnsg
        {
            get => idMnsg;
            set => SetProperty(ref idMnsg, value);
        }

        private bool selgnrl;
        public bool Selgnrl
        {
            get => selgnrl;
            set => SetProperty(ref selgnrl, value);
        }


        #endregion

        #region Campos

        private string nt_txt;
        public string Nt_txt
        {
            get => nt_txt;
            set => SetProperty(ref nt_txt, value);
        }

        private List<ColIdName> tpNota;
        public List<ColIdName> TpNota
        {
            get => tpNota;
            set => SetProperty(ref tpNota, value);
        }

        private List<ColIdName> tpNvl;
        public List<ColIdName> TpNvl
        {
            get => tpNvl;
            set => SetProperty(ref tpNvl, value);
        }

        private int idTpNota;
        public int IdTpNota
        {
            get => idTpNota;
            set => SetProperty(ref idTpNota, value);
        }

        private int idNvl;
        public int IdNvl
        {
            get => idNvl;
            set => SetProperty(ref idNvl, value);
        }

        private int idEdf;
        public int IdEdf
        {
            get => idEdf;
            set => SetProperty(ref idEdf, value);
        }

        private bool selTAct;
        public bool SelTAct
        {
            get
            {
                if(selTAct == false)
                {
                    FFinal = DateTime.Now;
                }
              return  selTAct;
            }
            set => SetProperty(ref selTAct, value);
        }

        private DateTime fFinal;
        public DateTime FFinal
        {
            get => fFinal;
            set => SetProperty(ref fFinal, value);
        }

        #endregion

        #region Coment

        private string mnsg;
        public string Mnsg
        {
            get => mnsg;
            set => SetProperty(ref mnsg, value);
        }

        private string mnsgComnt;
        public string MnsgComnt
        {
            get => mnsgComnt;
            set => SetProperty(ref mnsgComnt, value);
        }

        #endregion
    }
}
