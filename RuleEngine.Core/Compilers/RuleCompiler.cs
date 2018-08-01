using RuleEngine.Core.Models;
using RuleEngine.Core.Specifications;

namespace RuleEngine.Core.Compilers
{
    internal sealed class RuleCompiler : IRuleCompiler
    {
        private readonly IRuleItemCompiler _ruleItemCompiler;

        public RuleCompiler(IRuleItemCompiler ruleItemCompiler)
        {
            _ruleItemCompiler = ruleItemCompiler;
        }

        public ISpecification<T> Compile<T>(Rule rule)
        {
            ISpecification<T> ruleSpecification = null;

            foreach (RuleItem ruleItem in rule.RuleItems)
            {
                ISpecification<T> compiledRuleItem = _ruleItemCompiler.Compile<T>(ruleItem);
                ruleSpecification = ruleSpecification ?? compiledRuleItem;

                switch (ruleItem.JoinType)
                {
                    case JoinType.And:

                        ruleSpecification = ruleSpecification.And(compiledRuleItem);
                        break;

                    case JoinType.Or:

                        ruleSpecification = ruleSpecification.Or(compiledRuleItem);
                        break;
                }
            }

            return ruleSpecification;
        }
    }
}
