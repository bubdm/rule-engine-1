using System;
using System.Collections.Generic;
using RuleEngine.Core.Compilers;
using RuleEngine.Core.Exceptions;
using RuleEngine.Core.Models;
using RuleEngine.Core.Specifications;

namespace RuleEngine.Core
{
    internal sealed class RuleEngine<T> : IRuleEngine<T>
    {
        private readonly IDictionary<RuleResult, ISpecification<T>> _ruleSpecifications = new Dictionary<RuleResult, ISpecification<T>>();

        public RuleEngine(RuleSet ruleSet, IRuleCompiler ruleCompiler)
        {
            foreach (Rule rule in ruleSet.Rules)
            {
                RuleResult ruleResult = new RuleResult(rule.Code, rule.Message);
                ISpecification<T> ruleSpecification = ruleCompiler.Compile<T>(rule);

                _ruleSpecifications.Add(ruleResult, ruleSpecification);
            }
        }

        public IEnumerable<RuleResult> RunOn(T obj)
        {
            IList<RuleResult> ruleResults = new List<RuleResult>();

            foreach (KeyValuePair<RuleResult, ISpecification<T>> ruleSpecification in _ruleSpecifications)
            {
                if (!ruleSpecification.Value.IsSatisfiedBy(obj))
                    continue;

                ruleResults.Add(ruleSpecification.Key);
            }

            return ruleResults;
        }
    }
}
