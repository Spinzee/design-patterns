using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp
{
    public class GildedRoseUpdateQualityGivenSulfuras
    {
        private GildedRose _service;
        private List<Item> _items = new List<Item>();
        private const int INITIAL_QUALITY = 25;
        private const int INITIAL_SELL_IN = 15;

        public GildedRoseUpdateQualityGivenSulfuras()
        {
            _items.Add(GetSulfurasItem());
            _service = new GildedRose(_items);
        }

        private Item GetSulfurasItem()
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void DoesNotIncreaseQualityWhenPostiveSellIn()
        {

        }

        [Fact]
        public void DoesNotIncreaseQualityWhenNonPostiveSellIn()
        {

        }

        [Fact]
        public void DoesNotIncreaseSellIn()
        {

        }
    }
}
