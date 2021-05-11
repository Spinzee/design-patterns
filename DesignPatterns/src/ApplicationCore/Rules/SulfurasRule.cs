using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;

namespace ApplicationCore.Rules
{
    public class SulfurasRule : IRule
    {
        public bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public void UpdateItem(ItemProxy item)
        {
            // do nothing
        }
    }
}
