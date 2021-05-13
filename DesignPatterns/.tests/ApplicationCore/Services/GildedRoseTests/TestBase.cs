using ApplicationCore.Interfaces;
using ApplicationCore.Rules;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.UnitTests.ApplicationCore.Services.GildedRoseTests
{
    public class TestBase
    {
        // As the IoC container ties the rules to the interface, we need to manually 
        // add them for the tests.  
        protected IList<IRule> GetRules()
        {
            // TODO update this to builder pattern to make it more extendable
            return new List<IRule>
            {
                new AgedBrieRule(),
                new BackstagePassRule(),
                new ConjuredRule(),
                new SulfurasRule(),
                new NormalRule()
            };
        }
    }
}