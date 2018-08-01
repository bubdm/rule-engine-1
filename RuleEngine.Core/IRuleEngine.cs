using System.Collections.Generic;
using RuleEngine.Core.Models;

namespace RuleEngine.Core
{
    public interface IRuleEngine<in T>
    {
        IEnumerable<RuleResult> RunOn(T obj);
    }
}
