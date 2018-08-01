using AutoFixture;
using FluentAssertions;
using RuleEngine.Core.Models;
using Xunit;

namespace RuleEngine.Core.Tests.Models
{
    public sealed class ConstantRuleItemTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void Constructor_WhenNoJoinTypeIsSpecified_ShouldConstructObjectWithNoneJoinType()
        {
            string leftPredicate = _fixture.Create<string>();
            OperatorType operatorType = _fixture.Create<OperatorType>();
            string rightPredicate = _fixture.Create<string>();

            RuleItem ruleItem = new ConstantRuleItem(leftPredicate, operatorType, rightPredicate);

            ruleItem.LeftPredicate.Should().Be(leftPredicate);
            ruleItem.OperatorType.Should().Be(operatorType);
            ruleItem.RightPredicate.Should().Be(rightPredicate);
            ruleItem.JoinType.Should().Be(JoinType.None);
            ruleItem.IsRightPredicateConstant.Should().BeTrue();
        }

        [Fact]
        public void Constructor_WhenJoinTypeIsSpecified_ShouldConstructObjectWithJoinType()
        {
            string leftPredicate = _fixture.Create<string>();
            OperatorType operatorType = _fixture.Create<OperatorType>();
            string rightPredicate = _fixture.Create<string>();
            JoinType joinType = _fixture.Create<JoinType>();

            RuleItem ruleItem = new ConstantRuleItem(leftPredicate, operatorType, rightPredicate, joinType);

            ruleItem.LeftPredicate.Should().Be(leftPredicate);
            ruleItem.OperatorType.Should().Be(operatorType);
            ruleItem.RightPredicate.Should().Be(rightPredicate);
            ruleItem.JoinType.Should().Be(joinType);
            ruleItem.IsRightPredicateConstant.Should().BeTrue();
        }
    }
}
