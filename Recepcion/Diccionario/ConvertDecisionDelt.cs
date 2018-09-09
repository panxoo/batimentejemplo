using System;
using System.Windows.Data;


namespace Recepcion.Diccionario
{
    public class ConvertDecisionDelt : IValueConverter
    {
        public ConvertDecisionDelt() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null || value.ToString() == "")
                return "";

            string val = "";
            string[] ValSt;

            ValSt = value.ToString().Split(';');

            switch (ValSt[0])
            {
                case "mdpp":
                    switch (ValSt[1])
                    {
                        case "1":
                            val = "¿Se desea desabilitar el modelo?";
                            break;
                        case "0":
                            val = "¿Se desea habilitar el modelo?";
                            break;
                    }
                    break;

                case "tpsv":
                    switch (ValSt[1])
                    {
                        case "1":
                            val = "¿Se desea desabilitar el tipo de servicio?";
                            break;
                        case "0":
                            val = "¿Se desea habilitar el tipo de servicio?";
                            break;
                    }
                    break;

                case "srvi":
                    switch (ValSt[1])
                    {
                        case "1":
                            val = "¿Se desea desabilitar el servicio?";
                            break;
                        case "0":
                            val = "¿Se desea habilitar el servicio?";
                            break;
                    }
                    break;
            }


            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || value.ToString() == "")
                return "";

            string bValue;
            string TipoMsg;

            TipoMsg = value.ToString().Substring(0, 4);

            bValue = value.ToString().Substring(4);

            if (TipoMsg == "mdpp")
            {
                if (bValue == "1")
                    return "¿Se desea desabilitar el modelo?";
                else if (bValue == "2")
                    return "¿Se desea habilitar el modelo?";
            }

            return "";
        }
    }
}
