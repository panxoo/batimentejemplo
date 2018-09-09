using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Data;

namespace SistemaAdminDep.Diccionario
{
   public class ConvertSoloNumero : IValueConverter
    {
        public ConvertSoloNumero() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "0")
                return "";
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
            if (value.ToString() == "0")
                return "";
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
