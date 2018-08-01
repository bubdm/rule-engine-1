using System;
using AutoFixture;
using FluentAssertions;
using RuleEngine.Core.Models;
using Xbehave;
using Xunit;

namespace RuleEngine.Core.Tests.Models
{
    public sealed class RuleFeature
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void Constructor_WhenCodeAndMessageAreSpecified_ShouldConstructRule()
        {
            string code = _fixture.Create<string>();
            string message = _fixture.Create<string>();

            Rule rule = new Rule(code, message);

            rule.Code.Should().Be(code);
            rule.Message.Should().Be(message);
            rule.RuleItems.Should().HaveCount(0);
        }

        [Scenario]
        public void AddRuleItem_WhenRuleItemIsEmpty_ShouldDisplayError(Rule rule, Action action)
        {
            "Given a rule"
                .x(() =>
                {
                    string code = _fixture.Create<string>();
                    string message = _fixture.Create<string>();

                    rule = new Rule(code, message);
                });

            "When an empty rule item is added to the rule"
                .x(() => action = () => rule.AddRuleItem(null));

            "Then an error should be displayed."
                .x(() => action.Should().Throw<ArgumentNullException>());
        }
    }
}
