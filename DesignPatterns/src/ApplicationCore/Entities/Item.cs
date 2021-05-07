using ApplicationCore.Interfaces;

namespace DesignPatternsInCSharp.ApplicationCore.Entities
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}