using System.Collections.ObjectModel;
using Dzialy.Model;

namespace Dzialy.Przyjecia
{
    public interface IPrzyjecie
    {
        ObservableCollection<Produkt> PobierzListeProduktow();
        OperationStatus UsunProdukt(Produkt produkt);
    }
}