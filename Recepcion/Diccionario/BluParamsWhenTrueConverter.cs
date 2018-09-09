using SciChart.Wpf.UI.Transitionz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Recepcion.Diccionario
{
   public class BluParamsWhenTrueConverter : IValueConverter
    {
        public double Duration { get; set; }
        public double From { get; set; }
        public double To { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ?
                new BlurParams() { Duration = Duration, From = From, To = To, TransitionOn = TransitionOn.Once } :
                new BlurParams() { Duration = 200, From = To, To = From, TransitionOn = TransitionOn.Once };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
