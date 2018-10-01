using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SistemaAdminDep.Validacion
{
    public class ValidacionFormulario
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
            int num;
            if (int.TryParse(value.ToString() ?? "", out num))

                return num < 1
                     ? new ValidationResult(false, "Se debe seleccionar una opción.")
                     : ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "");
        }
    }

    class RequiredRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            // Get and convert the value
            string stringValue = GetBoundValue(value) as string;

            // Specific ValidationRule implementation...
            if (String.IsNullOrWhiteSpace(stringValue))
            {
                return new ValidationResult(false, "Must not be empty");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }

        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;

                // Get the bound object and name of the property
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                // Extract the value of the property.
                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                // This is what we want.
                return propertyValue;
            }
            else
            {
                // ValidationStep was RawProposedValue or ConvertedProposedValue
                // The argument is already what we want!
                return value;
            }
        }

    }

    public class PurchaseItem
        {
        object item;
        
}

    public class ValidateDateAndPrice : ValidationRule
        {

            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                BindingGroup bg = value as BindingGroup;

                // Get the source object.
                PurchaseItem item = bg.Items[0] as PurchaseItem;

                object doubleValue;
                object dateTimeValue;

                // Get the proposed values for Price and OfferExpires.
                bool priceResult = bg.TryGetValue(item, "Price", out doubleValue);
                bool dateResult = bg.TryGetValue(item, "OfferExpires", out dateTimeValue);

                if (!priceResult || !dateResult)
                {
                    return new ValidationResult(false, "Properties not found");
                }

                double price = (double)doubleValue;
                DateTime offerExpires = (DateTime)dateTimeValue;

                // Check that an item over $100 is available for at least 7 days.
                if (price > 100)
                {
                    if (offerExpires < DateTime.Today + new TimeSpan(7, 0, 0, 0))
                    {
                        return new ValidationResult(false, "Items over $100 must be available for at least 7 days.");
                    }
                }

                return ValidationResult.ValidResult;

            }
        }

    
}
