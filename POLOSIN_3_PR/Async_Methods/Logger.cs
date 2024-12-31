using System.Windows;

namespace POLOSIN_3_PR.Async_Methods
{
    public class Logger
    {
        public static async void PrintMessageAsync(string message, MessageBoxImage messageBoxImage)
        {
            await Task.Run(() =>
            {
                MessageBox.Show($"{message}!", "Уведомление", MessageBoxButton.OK, messageBoxImage);
            });
        }
    }
}
