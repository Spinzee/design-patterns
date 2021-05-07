using DesignPatternsInCSharp.ApplicationCore.Proxies;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.ApplicationCore.Services
{
    public class GildedRose
    {
        private List<ItemProxy> _items;

        public GildedRose(List<ItemProxy> items)
        {
            _items = items;
        }

        public void UpdateQuality(ItemProxy item)
        { 
            switch (item.Name)
            {
                case "Aged Brie":
                    item.IncrementQuality();

                    if (item.SellIn <= 0)
                    {
                        item.IncrementQuality();
                    }
                    item.DecreaseSellIn();
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
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
                    break;
                case "Conjured hat":
                    item.DecreaseQuality();
                    item.DecreaseQuality();

                    if (item.SellIn <= 0)
                    {
                        item.DecreaseQuality();
                        item.DecreaseQuality();
                    }

                    item.DecreaseSellIn();
                    break;
                default:
                    item.DecreaseQuality();

                    if (item.SellIn <= 0)
                    {
                        item.DecreaseQuality();
                    }

                    item.DecreaseSellIn();
                    break;
            }            
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                UpdateQuality(_items[i]);
            }
        }
    }
}

