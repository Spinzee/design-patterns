using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;

namespace ApplicationCore.Rules
{
    public class AgedBrieRule : IRule
    {
        public bool IsMatch(ItemProxy item)
        {
            return item.Name == "Aged Brie";
        }

        public void UpdateItem(ItemProxy item)
        {
            item.IncrementQuality();

            if (item.SellIn <= 0)
            {
                item.IncrementQuality();
            }

            item.DecreaseSellIn();
        }
    }
}
