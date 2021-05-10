using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;
using DesignPatternsInCSharp.ApplicationCore.Services;
using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.UnitTests.ApplicationCore.Services.GildedRoseTests
{
    public class GildedRoseUpdateQualityGivenAgedBrie
    {
        private GildedRose _service;
        private IList<IItem> _items = new List<IItem>();
        private const int INITIAL_QUALITY = 14;
        private const int INITIAL_SELL_IN = 25;

        public GildedRoseUpdateQualityGivenAgedBrie()
        {
            _items.Add(GetAgedBrie());
            _service = new GildedRose(_items);
        }

        private ItemProxy GetAgedBrie()
        {
            return new ItemProxy{ Name = "Aged Brie", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void IncreaseQualityBy1WhenPositiveSellIn()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY + 1, _items[0].Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IncreaseQualityBy2WhenNonPostiveSellIn(int sellIn)
        {
            _items[0].SellIn = sellIn;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY + 2, _items[0].Quality);
        }

        [Fact]
        public void DoesNotIncreaseQualityPast50()
        {
            _items[0].Quality = 50;
            _service.UpdateQuality();
            Assert.Equal(50, _items[0].Quality);
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
