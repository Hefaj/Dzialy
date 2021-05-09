using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Dzialy.Model;

namespace Dzialy.Controller
{
    public static class ProduktController
    {
        private static List<Produkt> baza = new List<Produkt>
        {
            new Produkt("O1-11", "ołówek", 8, "Katowice 1"),
            new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2"),
            new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1"),
            new Produkt("DZ-12", "długopis kulkowy", 280, "Katowice 2")
        };

        public static ObservableCollection<Produkt> GetAll() => new ObservableCollection<Produkt>(baza);

        public static OperationStatus RemoveItem(Produkt produkt)
        {
            // walidacja
            if (!baza.Contains(produkt))
            {
                return OperationStatus.NotExits;
            }
            
            // usuwanie
            baza.Remove(produkt);
            return OperationStatus.Ok;
        }
    }
}