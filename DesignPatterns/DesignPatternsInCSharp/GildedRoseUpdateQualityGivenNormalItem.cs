﻿using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp
{
    public class GildedRoseUpdateQualityGivenNormalItem
    {
        private GildedRose _service;
        private List<Item> _items = new List<Item>();
        private const int INITIAL_QUALITY = 14;
        private const int INITIAL_SELL_IN = 25;

        public GildedRoseUpdateQualityGivenNormalItem()
        {
            _items.Add(GetNormalItem());
            _service = new GildedRose(_items);
        }

        private Item GetNormalItem()
        {
            return new Item { Name = "Normal Item", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void ReduceNormalItemQualityBy1WhenPostiveSellIn()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY - 1, _items[0].Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ReduceNormalItemQualityBy2WhenNonPostiveSellIn(int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY - 2, _items[0].Quality);
        }

        [Theory]
        [InlineData(1, -1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        public void DoNotReduceQualityBelowZero(int quality, int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _items[0].Quality = quality;
            _service.UpdateQuality();
            Assert.Equal(0, _items[0].Quality);
        }

        [Fact]
        public void ReduceNormalItemSellInBy1()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_SELL_IN - 1, _items[0].SellIn);
        }

        [Fact]
        public void ReduceNormalItemSellInBelowZero()
        {
            _items[0].SellIn = 0;
            _service.UpdateQuality();
            Assert.Equal(-1, _items[0].SellIn);
        }
    }
}
