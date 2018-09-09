using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;
using System.Data;

namespace ClssVmMdl.Models.Confirma.Conf
{
   public class MDEditPisoEdificio : Confirmation
    {

        public MDEditPisoEdificio()
        {
            VarCpis = 0;
            VarCspis = 0;
        }

        public DataTable VarPisoGrd { get; set; }
        public DataTable VarSpisoGrd { get; set; }
        public int VarValid { get; set; }
        public int VarValcond { get; set; }
        public bool VarCond { get; set; }

        public int VarCpis { get; set; }
        public int VarCspis { get; set; }


    }
}
