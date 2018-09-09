using System.Windows.Input;

namespace SistemaAdminDep.Clase
{
   public class CustomComand
    {
        public static readonly RoutedCommand simpleCommand = new RoutedCommand("simpleCommand", typeof(CustomComand));
    }
}
