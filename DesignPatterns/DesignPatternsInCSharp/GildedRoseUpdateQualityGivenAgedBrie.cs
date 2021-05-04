using System;
using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp
{
    public class GildedRoseUpdateQualityGivenAgedBrie
    {
        private GildedRose _service;
        private List<Item> _items = new List<Item>();
        private const int INITIAL_QUALITY = 14;
        private const int INITIAL_SELL_IN = 25;

        public GildedRoseUpdateQualityGivenAgedBrie()
        {
            _items.Add(GetAgedBrie());
            _service = new GildedRose(_items);
        }

        private Item GetAgedBrie()
        {
            return new Item { Name = "Aged Brie", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void IncreaseAgedBrieQualityBy1WhenPositiveSellIn()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY + 1, _items[0].Quality);
        }

        [Fact]
        public void IncreaseAgedBrieQualityBy2WhenNegativeSellIn()
        {
            _items[0].SellIn = -1;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY + 2, _items[0].Quality);
        }

        [Fact]
        public void DoNotIncreaseQualityPast50()
        {
            _items[0].Quality = 50;
            _service.UpdateQuality();
            Assert.Equal(50, _items[0].Quality);
        }

        [Fact]
        public void ReduceAgedBrieSellInBy1()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_SELL_IN - 1, _items[0].SellIn);
        }

        [Fact]
        public void ReduceAgedBrieSellInBelowZero()
        {
            _items[0].SellIn = 0;
            _service.UpdateQuality();
            Assert.Equal(-1, _items[0].SellIn);
        }
    }
}
