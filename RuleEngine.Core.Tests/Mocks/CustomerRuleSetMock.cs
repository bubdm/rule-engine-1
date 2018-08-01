using RuleEngine.Core.Models;

namespace RuleEngine.Core.Tests.Mocks
{
    public sealed class CustomerRuleSetMock : RuleSet
    {
        private const string _name = "Customer Rule Set";
        private const string _description = "Business rules for creating a new customer.";
        private const string _version = "1";

        public CustomerRuleSetMock()
            : base(_name, _description, _version)
        {
            /* if (customer.Expenses > customer.Salary) ... */
            Rule rule001 = new Rule("Rule_001", "Customer's expenses are more than salary.");
            rule001.AddRuleItem(new PropertyRuleItem("Expenses", OperatorType.GreaterThan, "Salary"));

            AddRule(rule001);

            /* if (customer.Expenses > 1000 && customer.Expenses < 5000) ... */
            Rule rule002 = new Rule("Rule_002", "Customer's expense is between 1000 and 5000.");
            rule002.AddRuleItem(new ConstantRuleItem("Expenses", OperatorType.GreaterThan, "1000"));
            rule002.AddRuleItem(new ConstantRuleItem("Expenses", OperatorType.LessThan, "5000", JoinType.And));

            AddRule(rule002);
        }
    }
}
