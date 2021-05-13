using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;
using DesignPatternsInCSharp.ApplicationCore.Services;
using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.UnitTests.ApplicationCore.Services.GildedRoseTests
{
    public class GildedRoseUpdateQualityGivenSulfuras : TestBase
    {
        private GildedRose _service;
        private IList<IItem> _items = new List<IItem>();
        private const int INITIAL_QUALITY = 80;
        private const int INITIAL_SELL_IN = 15;

        public GildedRoseUpdateQualityGivenSulfuras()
        {
            _items.Add(GetSulfurasItem());
            _service = new GildedRose(_items, GetRules());
        }

        private ItemProxy GetSulfurasItem()
        {
            return new ItemProxy{ Name = "Sulfuras, Hand of Ragnaros", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void DoesNotIncreaseQualityWhenPostiveSellIn()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY, _items[0].Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void DoesNotIncreaseQualityWhenNonPostiveSellIn(int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY, _items[0].Quality);
        }

        [Fact]
        public void DoesNotIncreaseSellIn()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_SELL_IN, _items[0].SellIn);
        }
    }
}
