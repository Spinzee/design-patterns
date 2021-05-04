using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatternsInCSharp
{
    public class GildedRoseUpdateQualityGivenBackstagePasses
    {
        private GildedRose _service;
        private List<Item> _items = new List<Item>();
        private const int INITIAL_QUALITY = 25;
        private const int INITIAL_SELL_IN = 15;

        public GildedRoseUpdateQualityGivenBackstagePasses()
        {
            _items.Add(GetBackstagePassesItem());
            _service = new GildedRose(_items);
        }

        private Item GetBackstagePassesItem()
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(20)]
        public void IncreaseBackstagePassesQualityBy1WhenSellInOver10days(int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY + 1, _items[0].Quality);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void IncreaseBackstagePassesQualityBy2WhenSellIn6to10days(int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY + 2, _items[0].Quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void IncreaseBackstagePassesQualityBy3WhenSellIn1to5Days(int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _service.UpdateQuality();
            Assert.Equal(INITIAL_QUALITY + 3, _items[0].Quality);
        }

        [Fact]
        public void ZeroBackstagePassesQualityWhenSellIn0Days()
        {
            _items[0].SellIn = 0;
            _service.UpdateQuality();
            Assert.Equal(0, _items[0].Quality);
        }

        [Theory]
        [InlineData(50, 1)]
        [InlineData(50, 6)]
        [InlineData(50, 11)]
        [InlineData(49, 1)]
        [InlineData(49, 6)]
        [InlineData(49, 11)]
        [InlineData(48, 1)]
        [InlineData(47, 5)]
        public void DoNotIncreaseQualityPast50(int quality, int sellInDays)
        {
            _items[0].SellIn = sellInDays;
            _items[0].Quality = quality;
            _service.UpdateQuality();
            Assert.Equal(50, _items[0].Quality);
        }

        [Fact]
        public void ReduceBackstagePassesSellInBy1()
        {
            _service.UpdateQuality();
            Assert.Equal(INITIAL_SELL_IN - 1, _items[0].SellIn);
        }

        [Fact]
        public void ReduceBackstagePassesSellInBelowZero()
        {
            _items[0].SellIn = 0;
            _service.UpdateQuality();
            Assert.Equal(-1, _items[0].SellIn);
        }
    }
}
