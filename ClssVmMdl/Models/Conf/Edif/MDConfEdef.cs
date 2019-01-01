using Prism.Mvvm;
using System.Data;
using ClssVmMdl.Validacion;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ClssVmMdl.Models.Conf.Edif
{
    public class MDConfEdef : BindableBase
    {

        public MDConfEdef()
        {
            //selgnrl = false;
            //moddep = false;
            Eupdt = false;
            Cupdt = false;
            val = new ValTam();
        }

        private ValTam val;

        //private bool selgnrl;
        //public bool Selgnrl
        //{
        //    get { return selgnrl; }
        //    set { SetProperty(ref selgnrl, value); }
        //}

        private bool cupdt;
        public bool Cupdt
        {
            get => cupdt;
            set
            {
                SetProperty(ref cupdt, value);
                if (cupdt == false)
                    LimpCond();
            }
        }

        private bool eupdt;
        public bool Eupdt
        {
            get => eupdt;
            set
            {
                SetProperty(ref eupdt, value);
                if (eupdt == false)
                {
                    IdEdf = new int();
                    LimpEdf();
                }
            }
        }

        private int idEdf;
        public int IdEdf
        {
            get => idEdf;
            set => SetProperty(ref idEdf, value);
        }



        #region Condominio

        private string cnom;
        public string Cnom
        {
            get
            {
                cnom = val.LimitStrg(cnom, 500);
                return cnom;
            }
            set => SetProperty(ref cnom, value);
        }

        private int idPais;
        public int IdPais
        {
            get => idPais;
            set => SetProperty(ref idPais, value);
        }

        private int idRegion;
        public int IdRegion
        {
            get => idRegion;
            set => SetProperty(ref idRegion, value);
        }

        private string city;
        public string City
        {
            get
            {
                city = val.LimitStrg(city, 100);
                return city;
            }
            set => SetProperty(ref city, value);
        }

        private string calle;
        public string Calle
        {
            get
            {
                calle = val.LimitStrg(calle, 500);
                return calle;
            }
            set => SetProperty(ref calle, value);
        }

        private string numDir;
        public string NumDir
        {
            get
            {
                numDir = val.LimitStrg(numDir, 50);
                return numDir;
            }
            set => SetProperty(ref numDir, value);
        }

        private string postal;
        public string Postal
        {
            get
            {
                postal = val.LimitStrg(postal, 50);
                return postal;
            }
            set => SetProperty(ref postal, value);
        }

        private string ctel;
        public string CTel
        {
            get
            {
                ctel = val.LimitStrg(ctel, 15);
                return ctel;
            }
            set => SetProperty(ref ctel, value);
        }

        private string ctel2;
        public string CTel2
        {
            get
            {
                ctel2 = val.LimitStrg(ctel2, 15);
                return ctel2;
            }
            set => SetProperty(ref ctel2, value);
        }

        private string ccorreo;
        public string CCorreo
        {
            get
            {
                ccorreo = val.LimitStrg(ccorreo, 50);
                return ccorreo;
            }
            set => SetProperty(ref ccorreo, value);
        }

        private string ccorreo2;
        public string CCorreo2
        {
            get
            {
                ccorreo2 = val.LimitStrg(ccorreo2, 50);
                return ccorreo2;
            }
            set => SetProperty(ref ccorreo2, value);
        }


        private bool multiEd;
        public bool MultiEd
        {
            get => multiEd;
            set => SetProperty(ref multiEd, value);
        }

        #endregion



        #region Edificio

        private DataTable edif;
        public DataTable Edif
        {
            get => edif;
            set => SetProperty(ref edif, value);
        }


        private string enom;
        [Required(ErrorMessage = "Se debe llenar los campos.")]
        public string Enom
        {
            get
            {
                enom = val.LimitStrg(enom, 500);
                return enom;
            }
            set => SetProperty(ref enom, value);
        }

        private string idNomEdf;
        public string IdNomEdf
        {
            get
            {
                idNomEdf = val.LimitStrg(idNomEdf, 50);
                return idNomEdf;
            }
            set => SetProperty(ref idNomEdf, value);
        }

        private string numEdf;
        public string NumEdf
        {
            get
            {
                numEdf = val.LimitStrg(numEdf, 10);
                return numEdf;
            }
            set => SetProperty(ref numEdf, value);
        }

        private string etel;
        public string ETel
        {
            get
            {
                etel = val.LimitStrg(etel, 15);
                return etel;
            }
            set => SetProperty(ref etel, value);
        }

        private string etel2;
        public string ETel2
        {
            get
            {
                etel2 = val.LimitStrg(etel2, 15);
                return etel2;
            }
            set => SetProperty(ref etel2, value);
        }

        private string ecorreo;
        public string ECorreo
        {
            get
            {
                ecorreo = val.LimitStrg(ecorreo, 50);
                return ecorreo;
            }
            set => SetProperty(ref ecorreo, value);
        }

        private string ecorreo2;
        public string ECorreo2
        {
            get
            {
                ecorreo2 = val.LimitStrg(ecorreo2, 50);
                return ecorreo2;
            }
            set => SetProperty(ref ecorreo2, value);
        }

        private int spisos;
        public int Spisos
        {
            get => spisos;
            set => SetProperty(ref spisos, value);
        }

        private int pisos;
        public int Pisos
        {
            get => pisos;
            set => SetProperty(ref pisos, value);
        }



        #endregion

        #region Metodo

        public void LimpCond()
        {
            Cnom = "";
            MultiEd = false;

            Calle = "";
            NumDir = "";
            City = "";
            IdPais = -1;
            IdRegion = -1;
            Postal = "";

            CTel = "";
            CTel2 = "";
            CCorreo = "";
            CCorreo2 = "";

        }

        public void LimpEdf()
        {
            Enom = "";
            IdNomEdf = "";
            NumEdf = "";

            ETel = "";
            ETel2 = "";
            ECorreo = "";
            ECorreo2 = "";

            Pisos = 0;
            Spisos = 0;
        }

        #endregion
    }
}
