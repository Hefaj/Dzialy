using System.Windows.Input;
using Dzialy.Przyjecia.View;
using Dzialy.Wspolne.Controller;

namespace Dzialy.ViewModel
{
    public class MainWindowViewModel
    {
        private ICommand przyjecie;
        public ICommand Przyjecia => przyjecie ?? (przyjecie = new RelayCommand(OpenPrzyjecie));

        public MainWindowViewModel()
        {
            DzialController.WybranyDzial = Dzial.Opony;
        }
        private static void OpenPrzyjecie(object obj)
        {
            var window = new PrzyjeciaView();
            window.Show();
        }
    }
}