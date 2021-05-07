using DesignPatternsInCSharp.ApplicationCore.Entities;
using DesignPatternsInCSharp.ApplicationCore.Proxies;
using DesignPatternsInCSharp.ApplicationCore.Services;
using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.UnitTests.ApplicationCore.Services.GildedRoseTests
{
    public class GildedRoseUpdateQualityGiveConjuredItem
    {
        private List<ItemProxy> _items = new List<ItemProxy>();
        private GildedRose _service;
        private const int INITIAL_QUALITY = 25;
        private const int INITIAL_SELL_IN = 10;

        public GildedRoseUpdateQualityGiveConjuredItem()
        {
            _items.Add(GetConjurdedItem());
            _service = new GildedRose(_items);
        }

        private ItemProxy GetConjurdedItem()
        {
            return new ItemProxy(new Item { Name = "Conjured hat", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN });
        }

        [Fact]
        public void ReducesQualityBy2WhenPositiveSellIn()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY - 2, _items[0].Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ReducesQualityBy4WhenNonPositiveSellIn(int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY - 4, _items[0].Quality);
        }

        [Theory]
        [InlineData(1, -1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        public void DoesNotReduceQualityBelowZero(int quality, int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _items[0].Quality = quality;
            _service.UpdateQuality();
            Assert.Equal(0, _items[0].Quality);
        }

        [Fact]
        public void ReduceSellInBy1()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_SELL_IN - 1, _items[0].SellIn);
        }

        [Fact]
        public void ReduceSellInBelowZero()
        {
            _items[0].SellIn = 0;
            _service.UpdateQuality();
            Assert.Equal(-1, _items[0].SellIn);
        }
    }
}
