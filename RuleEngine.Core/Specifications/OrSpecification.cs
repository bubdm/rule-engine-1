namespace RuleEngine.Core.Specifications
{
    internal sealed class OrSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override bool IsSatisfiedBy(T obj)
        {
            return _leftSpecification.IsSatisfiedBy(obj) || _rightSpecification.IsSatisfiedBy(obj);
        }
    }
}
