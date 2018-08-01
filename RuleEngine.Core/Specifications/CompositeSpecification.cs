namespace RuleEngine.Core.Specifications
{
    internal abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public abstract bool IsSatisfiedBy(T obj);
    }
}
