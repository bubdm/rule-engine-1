using System.Collections.Generic;
using FluentAssertions;
using RuleEngine.Core.Models;
using RuleEngine.Core.Tests.Mocks;
using Xunit;

namespace RuleEngine.Core.Tests
{
    public sealed class RuleEngineTests
    {
        [Fact]
        public void RunOn()
        {
            CustomerMock customer = new CustomerMock
            {
                Salary = 1000,
                Expenses = 3000
            };

            CustomerRuleSetMock customerRuleSet = new CustomerRuleSetMock();
            IRuleEngine<CustomerMock> customerRuleEngine = RuleEngineFactory.Create<CustomerMock>(customerRuleSet);

            IEnumerable<RuleResult> ruleResults = customerRuleEngine.RunOn(customer);
            ruleResults.Should().HaveCount(2);
        }
    }
}
