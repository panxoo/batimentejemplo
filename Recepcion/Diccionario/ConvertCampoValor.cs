using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace Recepcion.Diccionario
{
    public class ConvertCampoValor : IValueConverter
    {

        public string Modulo { set; get; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string camp = value.ToString();
            string retorno = "";
            switch (Modulo)
            {
                case "srvi":
                    switch (camp)
                    {
                        case "CstM":
                            retorno = "Mensual";
                            break;
                        case "CstD":
                            retorno = "Diario";
                            break;
                        default:
                            retorno = "";
                            break;
                    }
                    break;
            }

            return retorno;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string camp = value.ToString();
            string retorno = "";
            switch (Modulo)
            {
                case "srvi":
                    switch (camp)
                    {
                        case "CstM":
                            retorno = "Mensual";
                            break;
                        case "CstD":
                            retorno = "Diario";
                            break;
                        default:
                            retorno = "";
                            break;
                    }
                    break;
            }

            return retorno;
        }
    }
}
