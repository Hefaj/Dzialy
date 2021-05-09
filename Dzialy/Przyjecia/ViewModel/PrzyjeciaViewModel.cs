using System.Collections.ObjectModel;
using System.Windows.Input;
using Dzialy.Controller;
using Dzialy.Model;
using Dzialy.Wspolne;
using Dzialy.Wspolne.Controller;

namespace Dzialy.Przyjecia.ViewModel
{
    public class PrzyjeciaViewModel : NotifyPropertyChanged
    {
        private IPrzyjecie przyjecie;

        private ObservableCollection<Produkt> produktList;

        public ObservableCollection<Produkt> ProduktList
        {
            get => produktList;
            set
            {
                if (value != produktList)
                {
                    produktList = value;
                    OnPropertyChanged();
                }
            }
        }

        private string searchText;

        public string SearchText
        {
            get => searchText;
            set
            {
                if (value != searchText)
                {
                    searchText = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand usun;
        public ICommand Usun => usun ?? (usun = new RelayCommand(UsunProdukt));

        private ICommand usunZBazy;
        public ICommand UsunZBazy => usunZBazy ?? (usunZBazy = new RelayCommand(UsunProduktTylkoZBazy));

        private ICommand keyDown;
        public ICommand KeyDown => keyDown ?? (keyDown = new RelayCommand(Waliduj));
        
        private ICommand search;
        public ICommand Search => search ?? (search = new RelayCommand(SearchFunction));

        private void SearchFunction(object obj)
        {
        }

        private void Waliduj(object obj)
        {
        }

        public PrzyjeciaViewModel()
        {
            przyjecie = PrzyjecieSwitch.Get();
            ProduktList = przyjecie.PobierzListeProduktow();
        }

        private void UsunProdukt(object obj)
        {
            if (!(obj is Produkt produkt))
            {
                MessageBoxController.ShowError("Nie wybrano Produktu");
                return;
            }

            // Usuwamy z listy i z bazy

            // zalety:
            //  * usuwajac z listy sama nam sie zaktualizuje
            //  * nie pobieramy od nowa z bazy tylko pracujemy na lokalnej wersji

            // wady:
            //  * potrzeba oddzielnie usunac z listy i z bazy 
            //  * pracujemy na lokalnej wersji ktora moze byc nie aktualna,
            //      trzeba by było sprawdzać w kontrolerze czy udalo sie usunac element
            //      ** mozna dodać przycisk odswierz i tyle
            // czy EF poinformuje w przypadku pruby wywalenia nieistniejacego elementu? 
            // (ktos usunac element, zanim my go usunelismy), problem ten jest aktualnie
            ProduktList.Remove(produkt);
            if (przyjecie.UsunProdukt(produkt) != OperationStatus.Ok)
            {
                MessageBoxController.ShowInfo("Element już nie istniał w bazie.");
                ProduktList = przyjecie.PobierzListeProduktow();
            }
        }

        private void UsunProduktTylkoZBazy(object obj) // tylko do debugowania
        {
            ProduktController.RemoveItem((Produkt) obj);
        }
    }
}