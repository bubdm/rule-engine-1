using System;
using System.Linq;
using RuleEngine.Core.Compilers;
using RuleEngine.Core.Exceptions;
using RuleEngine.Core.Models;

namespace RuleEngine.Core
{
    public static class RuleEngineFactory
    {
        public static IRuleEngine<T> Create<T>(RuleSet ruleSet)
        {
            if (ruleSet == null)
                throw new ArgumentNullException(nameof(ruleSet));

            if (!ruleSet.IsValid())
                throw new FailedValidationException(nameof(ruleSet));

            IRuleItemCompiler ruleItemCompiler = new RuleItemCompiler();
            IRuleCompiler ruleCompiler = new RuleCompiler(ruleItemCompiler);

            return new RuleEngine<T>(ruleSet, ruleCompiler);
        }
    }
}
