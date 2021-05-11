using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;

namespace ApplicationCore.Rules
{
    public class BackstagePassRule : IRule
    {
        public bool IsMatch(ItemProxy item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public void UpdateItem(ItemProxy item)
        {
            item.IncrementQuality();

            if (item.SellIn <= 10)
            {
                item.IncrementQuality();
            }
            if (item.SellIn <= 5)
            {
                item.IncrementQuality();
            }
            if (item.SellIn <= 0)
            {
                item.ResetQuality();
            }

            item.DecreaseSellIn();
        }
    }
}
