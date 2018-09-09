using System.Windows.Data;
using System;

namespace SistemaAdminDep.Diccionario
{
    public class ConvertIcoDel : IValueConverter
    {
        public ConvertIcoDel() { }
        public int Opcion { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int16 bValue = (Int16)value;

            switch(Opcion)
            {
                case 0:
                    if (bValue != 1)
                    {
                        return "DeleteRestore";
                    }
                    else
                    {
                        return "Delete";

                    }

                case 1:
                    if (bValue != 1)
                    {
                        return "Close";
                    }
                    else
                    {
                        return "Check";
                                            }
                                }
            return null;
           
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
