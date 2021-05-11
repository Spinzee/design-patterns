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
            //TODO turn this into a rules engine

            var agedBrieRule = new AgedBrieRule();
            var sulfurasRule = new SulfurasRule();
            var backstageRule = new BackstagePassRule();
            var conjuredRule = new ConjuredRule();
            var normalRule = new NormalRule();

            if (agedBrieRule.IsMatch(item))
            {
                agedBrieRule.UpdateItem(item);
                return;
            }

            if (sulfurasRule.IsMatch(item))
            {
                sulfurasRule.UpdateItem(item);
                return;
            }

            if (backstageRule.IsMatch(item))
            {
                backstageRule.UpdateItem(item);
                return;
            }

            if (conjuredRule.IsMatch(item))
            {
                conjuredRule.UpdateItem(item);
                return;
            }

            if (normalRule.IsMatch(item))
            {
                normalRule.UpdateItem(item);
                return;
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

