namespace DesignPatternsInCSharp
{
    public class ItemProxy
    {
        private Item _item;

        public ItemProxy(Item item)
        {
            _item = item;
        }
        
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;
        public string Name => _item.Name;

        public void IncrementQuality()
        {
            if (_item.Quality < 50)
            {
                _item.Quality++;
            }
        }

        public void DecreaseQuality()
        { 
            if(_item.Quality > 0)
            {
                _item.Quality--;
            }
        }
    }
}
