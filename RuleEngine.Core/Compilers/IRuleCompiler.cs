using RuleEngine.Core.Models;
using RuleEngine.Core.Specifications;

namespace RuleEngine.Core.Compilers
{
    internal interface IRuleCompiler
    {
        ISpecification<T> Compile<T>(Rule rule);
    }
}
