namespace RuleEngine.Core.Specifications
{
    internal interface ISpecification<T>
    {
        ISpecification<T> And(ISpecification<T> specification);

        ISpecification<T> Or(ISpecification<T> specification);

        bool IsSatisfiedBy(T obj);
    }
}
