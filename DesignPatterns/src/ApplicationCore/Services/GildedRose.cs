using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.ApplicationCore.Services
{
    public class GildedRose : IGildedRose
    {
        private readonly IList<IItem> _items;
        private readonly IList<IRule> _rules;

        public GildedRose(IList<IItem> items, IList<IRule> rules)
        {
            _items = items;
            _rules = rules;
        }

        public void UpdateQuality(ItemProxy item)
        {
            foreach (var rule in _rules)
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

