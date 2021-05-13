using ApplicationCore.Interfaces;
using DesignPatternsInCSharp.ApplicationCore.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Rules
{
    // not in use
    public class ItemQualityRulesEngine 
    {
        private IEnumerable<IRule> _rules = new List<IRule>();

        public ItemQualityRulesEngine()
        {
            // if order of rules doesn't matter
            // can use reflection and a rules engine.  
            // I have used the IoC container to achieve the same behaviour
            var ruleType = typeof(IRule);
            IEnumerable<IRule> rules = this.GetType().Assembly.GetTypes()
                .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                .Select(r => Activator.CreateInstance(r) as IRule);

            _rules = rules;
        }

        public void ApplyRules(ItemProxy item)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.UpdateItem(item);
                    break;
                }
            }
        }
    }
}
