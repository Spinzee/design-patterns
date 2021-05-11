using DesignPatternsInCSharp.ApplicationCore.Proxies;

namespace ApplicationCore.Interfaces
{
    public interface IRule
    {
        bool IsMatch(ItemProxy item);

        void UpdateItem(ItemProxy item);
    }
}
