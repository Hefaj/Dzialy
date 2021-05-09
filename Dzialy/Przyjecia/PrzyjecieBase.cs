using System.Collections.ObjectModel;
using Dzialy.Controller;
using Dzialy.Model;

namespace Dzialy.Przyjecia
{
    public class PrzyjecieBase : IPrzyjecie
    {
        public virtual ObservableCollection<Produkt> PobierzListeProduktow()
        {
            return ProduktController.GetAll();
        }

        public OperationStatus UsunProdukt(Produkt produkt)
        {
            return ProduktController.RemoveItem(produkt);
        }
    }
}