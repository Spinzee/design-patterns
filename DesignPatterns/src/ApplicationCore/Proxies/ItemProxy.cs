using ApplicationCore.Interfaces;

namespace DesignPatternsInCSharp.ApplicationCore.Proxies
{
    /// <summary>
    /// Item Proxy.
    /// Use for adding additional behaviours to a class 
    /// without modifying it. 
    /// </summary>
    public class ItemProxy : IItem
    {
        private IItem _item;

        public int SellIn
        {
            get { return _item.SellIn; }
            set { _item.SellIn = value; }
        }

        public string Name
        {
            get { return _item.Name; }
            set { _item.Name = value; }
        }

        public int Quality
        {
            get { return _item.Quality; }
            set { _item.Quality = value; }
        }

        public ItemProxy(IItem item)
        {
            _item = item;
        }        

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

        public void DecreaseSellIn() => _item.SellIn--;

        public void ResetQuality() => _item.Quality = 0;
    }
}
