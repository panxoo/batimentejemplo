using System;
using System.Windows.Data;

namespace Recepcion.Diccionario
{
    class ConvertFalsTrue : IValueConverter
    {
        public ConvertFalsTrue() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Boolean bValue = (Boolean)value;

            if (bValue == false)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Boolean bValue = (Boolean)value;

            if (bValue == false)
            {
                return true;
            }
            else
            {
                return false;

            }
        }


    }
}
