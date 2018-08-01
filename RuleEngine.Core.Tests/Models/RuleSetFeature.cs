using System;
using AutoFixture;
using FluentAssertions;
using RuleEngine.Core.Exceptions;
using RuleEngine.Core.Models;
using Xbehave;
using Xunit;

namespace RuleEngine.Core.Tests.Models
{
    public sealed class RuleSetFeature
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void Constructor_WhenRuleSetParametersAreSpecified_ShouldConstructRuleSet()
        {
            string name = _fixture.Create<string>();
            string description = _fixture.Create<string>();
            string version = _fixture.Create<string>();

            RuleSet ruleSet = new RuleSet(name, description, version);

            ruleSet.Name.Should().Be(name);
            ruleSet.Description.Should().Be(description);
            ruleSet.Version.Should().Be(version);
            ruleSet.Rules.Should().HaveCount(0);
        }

        [Scenario]
        public void AddRule_WhenRuleIsEmpty_ShouldDisplayAnError(RuleSet ruleSet, Rule rule, Action action)
        {
            "Given a valid rule set"
                .x(() =>
                {
                    string name = _fixture.Create<string>();
                    string description = _fixture.Create<string>();
                    string version = _fixture.Create<string>();

                    ruleSet = new RuleSet(name, description, version);
                });

            "When an empty rule is added"
                .x(() =>
                {
                    action = () => ruleSet.AddRule(null);
                });

            "Then an error should be displayed."
                .x(() =>
                {
                    action.Should().Throw<ArgumentNullException>();
                });
        }

        [Scenario]
        public void AddRule_WhenARuleIsInvalid_ShouldDisplayAnError(RuleSet ruleSet, Rule rule, Action action)
        {
            "Given a valid rule set"
                .x(() =>
                {
                    string name = _fixture.Create<string>();
                    string description = _fixture.Create<string>();
                    string version = _fixture.Create<string>();

                    ruleSet = new RuleSet(name, description, version);
                });

            "And an invalid rule"
                .x(() =>
                {
                    rule = new Rule(string.Empty, string.Empty);
                });

            "When the invalid rule is added to the rule set"
                .x(() =>
                {
                    action = () => ruleSet.AddRule(rule);
                });

            "Then an error should be displayed."
                .x(() =>
                {
                    action.Should().Throw<FailedValidationException>();
                });
        }

        [Scenario]
        public void AddRule_WhenAnExistingRuleIsAddedToTheRuleSet_ShouldNotDuplicateRule(RuleSet ruleSet, Rule rule)
        {
            "Given a valid rule set"
                .x(() =>
                {
                    string name = _fixture.Create<string>();
                    string description = _fixture.Create<string>();
                    string version = _fixture.Create<string>();

                    ruleSet = new RuleSet(name, description, version);
                });

            "And the rule set has a rule"
                .x(() =>
                {
                    string code = _fixture.Create<string>();
                    string message = _fixture.Create<string>();

                    rule = new Rule(code, message);

                    string leftPredicate = _fixture.Create<string>();
                    OperatorType operatorType = OperatorType.Equal;
                    string rightPredicate = _fixture.Create<string>();

                    RuleItem ruleItem = new ConstantRuleItem(leftPredicate, operatorType, rightPredicate);

                    rule.AddRuleItem(ruleItem);
                    ruleSet.AddRule(rule);
                });

            "When the existing rule is added to the rule set"
                .x(() =>
                {
                    ruleSet.AddRule(rule);
                });

            "Then the rule should not be duplicated in the rule set."
                .x(() =>
                {
                    ruleSet.Rules.Should().HaveCount(1);
                });
        }

        [Scenario]
        public void AddRule_WhenAValidRuleIsAddedToARuleSet_ShouldAddRule(RuleSet ruleSet, Rule rule)
        {
            "Given a valid rule set"
                .x(() =>
                {
                    string name = _fixture.Create<string>();
                    string description = _fixture.Create<string>();
                    string version = _fixture.Create<string>();

                    ruleSet = new RuleSet(name, description, version);
                });

            "And a valid rule"
                .x(() =>
                {
                    string code = _fixture.Create<string>();
                    string message = _fixture.Create<string>();

                    rule = new Rule(code, message);

                    string leftPredicate = _fixture.Create<string>();
                    OperatorType operatorType = OperatorType.Equal;
                    string rightPredicate = _fixture.Create<string>();

                    RuleItem ruleItem = new ConstantRuleItem(leftPredicate, operatorType, rightPredicate);

                    rule.AddRuleItem(ruleItem);
                });

            "When the rule is added to the rule set"
                .x(() =>
                {
                    ruleSet.AddRule(rule);
                });

            "Then the list of rules in the rule set should be updated."
                .x(() =>
                {
                    ruleSet.Rules.Should().HaveCount(1);
                });
        }

        [Scenario]
        public void RemoveRule_WhenARuleIsRemovedFromARuleSet_ShouldUpdateListOfRules(RuleSet ruleSet, Rule rule)
        {
            "Given a valid rule set"
                .x(() =>
                {
                    string name = _fixture.Create<string>();
                    string description = _fixture.Create<string>();
                    string version = _fixture.Create<string>();

                    ruleSet = new RuleSet(name, description, version);
                });

            "And the rule set has a rule"
                .x(() =>
                {
                    string code = _fixture.Create<string>();
                    string message = _fixture.Create<string>();

                    rule = new Rule(code, message);

                    string leftPredicate = _fixture.Create<string>();
                    OperatorType operatorType = OperatorType.Equal;
                    string rightPredicate = _fixture.Create<string>();

                    RuleItem ruleItem = new ConstantRuleItem(leftPredicate, operatorType, rightPredicate);

                    rule.AddRuleItem(ruleItem);
                    ruleSet.AddRule(rule);
                });

            "When the existing rule is removed"
                .x(() =>
                {
                    ruleSet.RemoveRule(rule);
                });

            "Then the list of rules in the rule set should be updated."
                .x(() =>
                {
                    ruleSet.Rules.Should().HaveCount(0);
                });
        }

        [Scenario]
        public void IsValid_WhenARuleSetIsInValid_ShouldReturnFalse()
        {
            RuleSet ruleSet = null;
            string name = null;
            string description = null;
            string version = null;

            //When name is invalid.
            ruleSet = new RuleSet(name, description, version);
            ruleSet.IsValid().Should().BeFalse();

            //When description is invalid.
            name = _fixture.Create<string>();
            ruleSet = new RuleSet(name, description, version);
            ruleSet.IsValid().Should().BeFalse();

            //When version is invalid.
            description = _fixture.Create<string>();
            ruleSet = new RuleSet(name, description, version);
            ruleSet.IsValid().Should().BeFalse();

            //When rules are invalid.
            version = _fixture.Create<string>();
            ruleSet = new RuleSet(name, description, version);
            ruleSet.IsValid().Should().BeFalse();
        }

        [Scenario]
        public void IsValid_WhenARuleSetIsValid_ShouldReturnTrue()
        {
            string name = _fixture.Create<string>();
            string description = _fixture.Create<string>();
            string version = _fixture.Create<string>();

            RuleSet ruleSet = new RuleSet(name, description, version);

            string code = _fixture.Create<string>();
            string message = _fixture.Create<string>();

            Rule rule = new Rule(code, message);

            string leftPredicate = _fixture.Create<string>();
            OperatorType operatorType = OperatorType.Equal;
            string rightPredicate = _fixture.Create<string>();

            RuleItem ruleItem = new ConstantRuleItem(leftPredicate, operatorType, rightPredicate);

            rule.AddRuleItem(ruleItem);
            ruleSet.AddRule(rule);

            ruleSet.IsValid().Should().BeTrue();
        }
    }
}
