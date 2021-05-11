using ApplicationCore.Interfaces;
using ApplicationCore.Rules;
using DesignPatternsInCSharp.ApplicationCore.Proxies;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.ApplicationCore.Services
{
    public class GildedRose : IGildedRose
    {
        private readonly IList<IItem> _items;

        public GildedRose(IList<IItem> items)
        {
            _items = items;
        }

        public void UpdateQuality(ItemProxy item)
        {
            var rules = new List<IRule>
            {
                new AgedBrieRule(),
                new SulfurasRule(),
                new BackstagePassRule(),
                new ConjuredRule(),
                new ConjuredRule(),
                new NormalRule()
            };

            foreach (var rule in rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.UpdateItem(item);
                    break;
                }
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                UpdateQuality((ItemProxy)_items[i]);
            }
        }
    }
}

