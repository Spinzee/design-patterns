using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;

namespace ApplicationCore.Rules
{
    public class NormalRule : IRule
    {
        public bool IsMatch(ItemProxy item)
        {
            return true;
        }

        public void UpdateItem(ItemProxy item)
        {
            item.DecreaseQuality();

            if (item.SellIn <= 0)
            {
                item.DecreaseQuality();
            }

            item.DecreaseSellIn();
        }
    }
}
