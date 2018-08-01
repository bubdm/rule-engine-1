using FluentAssertions;
using RuleEngine.Core.Models;
using Xunit;

namespace RuleEngine.Core.Tests.Models
{
    public sealed class OperatorTypeTests
    {
        [Fact]
        public void OperatorType_CheckEnumValues()
        {
            GetEnumValue(OperatorType.None).Should().Be(0);
            GetEnumValue(OperatorType.Equal).Should().Be(1);
            GetEnumValue(OperatorType.NotEqual).Should().Be(2);
            GetEnumValue(OperatorType.GreaterThan).Should().Be(3);
            GetEnumValue(OperatorType.LessThan).Should().Be(4);
            GetEnumValue(OperatorType.GreaterThanOrEqual).Should().Be(5);
            GetEnumValue(OperatorType.LessThanOrEqual).Should().Be(6);
            GetEnumValue(OperatorType.FoundIn).Should().Be(7);
            GetEnumValue(OperatorType.NotFoundIn).Should().Be(8);
            GetEnumValue(OperatorType.Like).Should().Be(9);
        }

        private static int GetEnumValue(OperatorType operatorType)
        {
            return (int)operatorType;
        }
    }
}
