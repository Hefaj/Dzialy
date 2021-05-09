using System.Windows;

namespace Dzialy.Wspolne.Controller
{
    public static class MessageBoxController
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Powiadomienie", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}