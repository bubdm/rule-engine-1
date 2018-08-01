using AutoFixture;
using FluentAssertions;
using Moq;
using RuleEngine.Core.Models;
using RuleEngine.Core.Specifications;
using Xunit;

namespace RuleEngine.Core.Tests.Specifications
{
    public sealed class OrSpecificationTests
    {
        private readonly IFixture _fixture = new Fixture();
        private readonly Mock<ISpecification<object>> _mockLeftSpecification;
        private readonly Mock<ISpecification<object>> _mockRightSpecification;
        private readonly OrSpecification<object> _orSpecification;

        public OrSpecificationTests()
        {
            _mockLeftSpecification = new Mock<ISpecification<object>>();
            _mockRightSpecification = new Mock<ISpecification<object>>();

            _orSpecification = new OrSpecification<object>(_mockLeftSpecification.Object, _mockRightSpecification.Object);
        }

        [Fact]
        public void IsSatisfiedBy_WhenLeftAndRightSpecificationsAreNotSatisfied_ShouldReturnFalse()
        {
            object obj = _fixture.Create<object>();
            _mockLeftSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(false);
            _mockRightSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(false);

            bool isSatisfiedBy = _orSpecification.IsSatisfiedBy(obj);

            isSatisfiedBy.Should().BeFalse();
        }
    }
}
