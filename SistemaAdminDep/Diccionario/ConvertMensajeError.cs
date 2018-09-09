using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace SistemaAdminDep.Diccionario
{
    class ConvertMensajeError : IValueConverter
    {
        public ConvertMensajeError() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string msg = "No se ha podido almacenar el registro, la razón es:&#xA;";

            if (value == null)
                return "";

            string TipoMsg = value.ToString().Substring(0, 4);
            List<int> numbers = new List<int>(Array.ConvertAll(value.ToString().Remove(0, 5).Split(';'), int.Parse));

            if (numbers.Contains(-1))
            {
                msg = msg + "- No se almaceno error de sistema&#xA;";
            }
            else if (numbers.Contains(2))
            {
                msg = msg + "- Se debe llenar todos los campos&#xA;";
            }
            else
            {
                switch (TipoMsg)
                {
                    case "mtdp":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- El nombre del departamento ya esta en uso&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- El numero del departamento ya esta en uso&#xA;";
                                    break;
                            }
                        }
                        break;

                    case "mdpp":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- El nombre del modelo ya esta en uso&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- Se encuentra nombre de modelo ya activo en otro modelo&#xA;";
                                    break;
                                case 6:
                                    msg = msg + "- Edificio seleccionado no se encuentra activo&#xA;";
                                    break;
                            }
                        }
                        break;

                    case "tpsv":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- Se debe seleccionar el tipo de reserva&#xA;";
                                    break;
                                case 4:
                                    msg = msg + "- Se debe ingresar el monto de la reserva&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- Se debe seleccionar el metodo de cobro&#xA;";
                                    break;
                                case 6:
                                    msg = msg + "- Se debe ingresar el monto de la garantia&#xA;";
                                    break;
                                case 7:
                                    msg = msg + "- Se debe seleccionar pago por gasto comun para el cobro del monto restante&#xA;";
                                    break;
                                case 8:
                                    msg = msg + "- El monto de reserva no puedo ser igual o mayor al monto de uso del servicio&#xA;";
                                    break;
                                case 9:
                                    msg = msg + "- El nombre del servicio ya se esta utilizando, ingresar un nuevo nombre&#xA;";
                                    break;
                                case 10:
                                    msg = msg + "- El nombre del servicio ya se encuentra activo en otro tipo de servicio&#xA;";
                                    break;
                            }
                        }
                        break;

                    case "srvi":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- Se debe ingresar el valor del costo fijo&#xA;";
                                    break;
                                case 4:
                                    msg = msg + "- Se debe ingresar el valor del costo por uso&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- El nombre del servicio ya se esta utilizando, ingresar un nuevo nombre&#xA;";
                                    break;
                                case 6:
                                    msg = msg + "- Se encuentra nombre de modelo ya activo en otro modelo&#xA;";
                                    break;
                            }
                        }
                        break;
                }

            }

            return msg.ToString().Replace("&#xA;", Environment.NewLine);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string msg = "No se ha podido almacenar el registro, la razón es:&#xA;";

            if (value == null)
                return "";

            string TipoMsg = value.ToString().Substring(0, 4);
            List<int> numbers = new List<int>(Array.ConvertAll(value.ToString().Remove(0, 5).Split(';'), int.Parse));

            if (numbers.Contains(-1))
            {
                msg = msg + "- No se almaceno error de sistema&#xA;";
            }
            else if (numbers.Contains(2))
            {
                msg = msg + "- Se debe llenar todos los campos&#xA;";
            }
            else
            {
                switch (TipoMsg)
                {
                    case "mtdp":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- El nombre del departamento ya esta en uso&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- El numero del departamento ya esta en uso&#xA;";
                                    break;
                            }
                        }
                        break;

                    case "mdpp":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- El nombre del modelo ya esta en uso&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- Se encuentra nombre de modelo ya activo en otro modelo&#xA;";
                                    break;
                                case 6:
                                    msg = msg + "- Edificio seleccionado no se encuentra activo&#xA;";
                                    break;
                            }
                        }
                        break;

                    case "tpsv":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- Se debe seleccionar el tipo de reserva&#xA;";
                                    break;
                                case 4:
                                    msg = msg + "- Se debe ingresar el monto de la reserva&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- Se debe seleccionar el metodo de cobro&#xA;";
                                    break;
                                case 6:
                                    msg = msg + "- Se debe ingresar el monto de la garantia&#xA;";
                                    break;
                                case 7:
                                    msg = msg + "- Se debe seleccionar pago por gasto comun para el cobro del monto restante&#xA;";
                                    break;
                                case 8:
                                    msg = msg + "- El monto de reserva no puedo ser igual o mayor al monto de uso del servicio&#xA;";
                                    break;
                                case 9:
                                    msg = msg + "- El nombre del servicio ya se esta utilizando, ingresar un nuevo nombre&#xA;";
                                    break;
                                case 10:
                                    msg = msg + "- El nombre del servicio ya se encuentra activo en otro tipo de servicio&#xA;";
                                    break;
                            }
                        }
                        break;

                    case "srvi":
                        foreach (int Val in numbers)
                        {
                            switch (Val)
                            {
                                case 3:
                                    msg = msg + "- Se debe ingresar el valor del costo fijo&#xA;";
                                    break;
                                case 4:
                                    msg = msg + "- Se debe ingresar el valor del costo por uso&#xA;";
                                    break;
                                case 5:
                                    msg = msg + "- El nombre del servicio ya se esta utilizando, ingresar un nuevo nombre&#xA;";
                                    break;
                                case 6:
                                    msg = msg + "- Se encuentra nombre de modelo ya activo en otro modelo&#xA;";
                                    break;
                            }
                        }
                        break;
                }

            }

            return msg.ToString().Replace("&#xA;", Environment.NewLine);
        }
    }
}
