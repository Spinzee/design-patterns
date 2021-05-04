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

        [Fact]
        public void IncreaseBackstagePassesQualityBy1WhenOver10days()
        {

        }

        [Fact]
        public void IncreaseBackstagePassesQualityBy2When6to10days()
        {

        }

        [Fact]
        public void IncreaseBackstagePassesQualityBy3When5to1Days()
        {

        }

        [Fact]
        public void ZeroBackstagePassesQualityWhen0Days()
        {

        }

        [Fact]
        public void DoNotIncreaseQualityPast50()
        {

        }

        [Fact]
        public void ReduceBackstagePassesSellInBy1()
        {

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
