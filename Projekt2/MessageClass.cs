using System.Windows;

namespace Projekt2
{
    public class MessageClass
    {
        public static void MessageErrorWithDefaultCaption(string message)
        {
            MessageBox.Show(message, "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void MessageError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}