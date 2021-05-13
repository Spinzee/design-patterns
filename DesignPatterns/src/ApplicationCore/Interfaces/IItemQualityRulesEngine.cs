using DesignPatternsInCSharp.ApplicationCore.Proxies;

namespace ApplicationCore.Interfaces
{
    public interface IItemQualityRulesEngine
    {
        void ApplyRules(ItemProxy item);
    }
}
