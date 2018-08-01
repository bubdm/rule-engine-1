using System;

namespace RuleEngine.Core.Specifications
{
    internal sealed class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private readonly Func<T, bool> _expression;

        public ExpressionSpecification(Func<T, bool> expression)
        {
            _expression = expression;
        }

        public override bool IsSatisfiedBy(T obj)
        {
            return _expression(obj);
        }
    }
}
