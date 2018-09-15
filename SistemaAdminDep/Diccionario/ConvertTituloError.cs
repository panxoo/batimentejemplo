using System;
using System.Windows.Data;

namespace SistemaAdminDep.Diccionario
{
    class ConvertTituloError : IValueConverter
    {
        public ConvertTituloError() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";

            string val = "";
            string ValSt = value.ToString();

            switch (ValSt)
            {
                case "mdpp":
                    val = "Error tipo de modelo";
                    break;
                case "tpsv":
                    val = "Error tipo de servicio";
                    break;
                case "srvi":
                    val = "¿Se desea desabilitar el servicio?";
                    break;
            }

            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";

            string val = "";
            string ValSt = value.ToString();

            switch (ValSt)
            {
                case "mdpp":
                    val = "¿Se desea desabilitar el modelo?";
                    break;
                case "tpsv":
                    val = "Error tipo de servicio";
                    break;
                case "srvi":
                    val = "¿Se desea desabilitar el servicio?";
                    break;
            }

            return val;
        }
    }
}
