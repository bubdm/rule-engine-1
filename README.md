# Rule Engine using .net standard, Linq Expressions and the Specification Design Pattern

This project presents a .net rule engine that can be used to build and execute custom rule sets.

### Example

```csharp

public sealed class Customer
{
    public decimal Salary { get; set; }
    public decimal Expenses { get; set; }

    ...
}

internal sealed class CustomerRuleSet : RuleSet
{
    private const string _name = "Customer Rule Set";
    private const string _description = "Business rules for creating a new customer.";
    private const string _version = "1";

    public CustomerRuleSet()
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

        ...
    }
}

Customer customer = new Customer
{
    Salary = 1000,
    Expenses = 3000
};

CustomerRuleSet customerRuleSet = new CustomerRuleSet();
IRuleEngine<Customer> customerRuleEngine = RuleEngineFactory.Create<Customer>(customerRuleSet);

IEnumerable<RuleResult> ruleResults = customerRuleEngine.RunOn(customer);

```

### dotnet core Commands

```

dotnet new sln -n RuleEngine

dotnet new classlib -n RuleEngine.Core
dotnet sln add ./RuleEngine.Core/RuleEngine.Core.csproj

dotnet new xunit -n RuleEngine.Core.Tests
dotnet sln add ./RuleEngine.Core.Tests/RuleEngine.Core.Tests.csproj

cd RuleEngine.Core.Tests
dotnet add reference ../RuleEngine.Core/RuleEngine.Core.csproj
dotnet add package fluentassertions
dotnet add package autofixture
dotnet add package moq
dotnet add package xbehave

```
