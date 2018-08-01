using AutoFixture;
using FluentAssertions;
using Moq;
using RuleEngine.Core.Models;
using RuleEngine.Core.Specifications;
using Xunit;

namespace RuleEngine.Core.Tests.Specifications
{
    public sealed class AndSpecificationTests
    {
        private readonly IFixture _fixture = new Fixture();
        private readonly Mock<ISpecification<object>> _mockLeftSpecification;
        private readonly Mock<ISpecification<object>> _mockRightSpecification;
        private readonly AndSpecification<object> _andSpecification;

        public AndSpecificationTests()
        {
            _mockLeftSpecification = new Mock<ISpecification<object>>();
            _mockRightSpecification = new Mock<ISpecification<object>>();

            _andSpecification = new AndSpecification<object>(_mockLeftSpecification.Object, _mockRightSpecification.Object);
        }

        [Fact]
        public void IsSatisfiedBy_WhenLeftAndRightSpecificationsAreSatisfied_ShouldReturnTrue()
        {
            object obj = _fixture.Create<object>();
            _mockLeftSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(true);
            _mockRightSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(true);

            bool isSatisfiedBy = _andSpecification.IsSatisfiedBy(obj);

            isSatisfiedBy.Should().BeTrue();
        }

        [Fact]
        public void IsSatisfiedBy_WhenLeftSpecificationIsNotSatisfied_ShouldReturnFalse()
        {
            object obj = _fixture.Create<object>();
            _mockLeftSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(false);
            _mockRightSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(true);

            bool isSatisfiedBy = _andSpecification.IsSatisfiedBy(obj);

            isSatisfiedBy.Should().BeFalse();
        }

        [Fact]
        public void IsSatisfiedBy_WhenRightSpecificationIsNotSatisfied_ShouldReturnFalse()
        {
            object obj = _fixture.Create<object>();
            _mockLeftSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(true);
            _mockRightSpecification.Setup(call => call.IsSatisfiedBy(obj)).Returns(false);

            bool isSatisfiedBy = _andSpecification.IsSatisfiedBy(obj);

            isSatisfiedBy.Should().BeFalse();
        }
    }
}
