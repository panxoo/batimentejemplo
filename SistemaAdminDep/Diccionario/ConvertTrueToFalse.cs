using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SistemaAdminDep.Diccionario
{
   public class ConvertTrueToFalse : IValueConverter             
    {

        public ConvertTrueToFalse()
        {        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;

            if (bValue == true)
                return false;
            else 
                return true;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;

            if (bValue == true)
                return false;
            else
                return true;
        }

    }
}
