using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;

namespace ApplicationCore.Rules
{
    public class ConjuredRule : IRule
    {
        public bool IsMatch(ItemProxy item)
        {
            return item.Name == "Conjured hat";
        }

        public void UpdateItem(ItemProxy item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();

            if (item.SellIn <= 0)
            {
                item.DecreaseQuality();
                item.DecreaseQuality();
            }

            item.DecreaseSellIn();
        }
    }
}
