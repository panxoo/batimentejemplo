using System;
using System.Windows.Data;

namespace SistemaAdminDep.Diccionario
{
    public class ConvertColorActive : IValueConverter
    {
        public ConvertColorActive() { }


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int16 bValue = (Int16)value;

            if (bValue != 1)
            {
                return "/SistemaAdminDep;component/Imagen/Grid/circle_red.png";
            }
            else
            {
                return "/SistemaAdminDep;component/Imagen/Grid/circle_green.png";

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int16 bValue = (Int16)value;

            if (bValue != 1)
            {
                return "/SistemaAdminDep;component/Imagen/Grid/circle_red.png";
            }
            else
            {
                return "/SistemaAdminDep;component/Imagen/Grid/circle_green.png";

            }
        }
    }
}
