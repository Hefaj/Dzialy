using Dzialy.Wspolne.Controller;

namespace Dzialy.Przyjecia
{
    public static class PrzyjecieSwitch
    {
        public static IPrzyjecie Get()
        {
            switch (DzialController.WybranyDzial)
            {
                // jezeli chcemy zmienic implementacje
                case Dzial.Dadelo:
                    return new PrzyjecieDadelo();
                default:
                    return new PrzyjecieBase();
            }
        }
    }
}