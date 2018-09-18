using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SistemaAdminDep.Validacion
{
  public  class ValidacionFormulario
    {
    }

    public class BindingProxy : System.Windows.Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        public object Vargnrl
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Vargnrl", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));
    }



    public class ValidacionVaria : DependencyObject
    {
       public static readonly DependencyProperty SelErrorProperty = DependencyProperty.Register("SelError", typeof(bool),
       typeof(ValidacionVaria));

      
        public bool SelError
        {
            get { return (bool)GetValue(SelErrorProperty); }
            set { SetValue(SelErrorProperty, value); }
        }

    }


   public class ValidacionTextVacio : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
           return string.IsNullOrWhiteSpace((value ?? "").ToString()) 
                ? new ValidationResult(false, "Se debe llenar el campo.")
                : ValidationResult.ValidResult;
        }
    }

    public class ValidacionNumbCero : ValidationRule
    {
                public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int num;
            if (int.TryParse(value.ToString() ?? "", out num))

                return num == 0 || num < 0
                     ? new ValidationResult(false, "Se debe ingresar un valor mayor a 0.")
                     : ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "Se debe ingresar un numero");
        }
    }

    public class ValidacionDicimCero : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            float num;
            if (float.TryParse(value.ToString() ?? "", out num))

                return num == 0 || num < 0
                     ? new ValidationResult(false, "Se debe ingresar un valor mayor a 0.")
                     : ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "Se debe ingresar un numero");
        }
    }

    public class ValidacionSeleccionComb : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            float num;
            if (float.TryParse(value.ToString() ?? "", out num))

                return num == -1 
                     ? new ValidationResult(false, "Se debe ingresar un valor mayor a 0.")
                     : ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "");
        }
    }
}
