using System;
using System.Windows.Data;


namespace Recepcion.Diccionario
{
    class ConvertParameter : IMultiValueConverter
    { 

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
