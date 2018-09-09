using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace ClssVmMdl.Models.Confirma.Conf
{
    public class MDModParametros : Confirmation
    {
        public MDModParametros()
        {
            tipoParm = 0;
            valor = 0;
            parname = null;
            parmod = "";
            LblMsg = "";
        }


        public int tipoParm { get; set; }
        public int valor { get; set; }
        public string parname { get; set; }
        public string parmod { get; set; }
        public string LblMsg { get; set; }


    }
}
