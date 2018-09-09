using System;
using System.Windows.Data;

namespace SistemaAdminDep.Diccionario
{
    public class ConvertColorBarStatus : IValueConverter
    {

        public ConvertColorBarStatus() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int bValue = (int)value;

            if (bValue == 0)
                return "#ea4333";
            else if (bValue == 1)
                return "#33a133";
            else if (bValue == 2)
                return "#FFF6D258";
            else
                return "#007acc";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int16 bValue = (Int16)value;

            if (bValue == 0)
                return "#ea4333";
            else if (bValue == 1)
                return "#33a133";
            else
                return "#007acc";
        }
    }
}
