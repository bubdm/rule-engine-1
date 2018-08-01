using RuleEngine.Core.Models;
using RuleEngine.Core.Specifications;

namespace RuleEngine.Core.Compilers
{
    internal interface IRuleItemCompiler
    {
        ISpecification<T> Compile<T>(RuleItem ruleItem);
    }
}
