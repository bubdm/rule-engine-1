using FluentAssertions;
using RuleEngine.Core.Models;
using Xunit;

namespace RuleEngine.Core.Tests.Models
{
    public sealed class JoinTypeTests
    {
        [Fact]
        public void JoinType_CheckEnumValues()
        {
            GetEnumValue(JoinType.None).Should().Be(0);
            GetEnumValue(JoinType.And).Should().Be(1);
            GetEnumValue(JoinType.Or).Should().Be(2);
        }

        private static int GetEnumValue(JoinType joinType)
        {
            return (int)joinType;
        }
    }
}
