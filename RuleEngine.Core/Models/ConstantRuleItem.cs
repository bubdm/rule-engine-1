namespace RuleEngine.Core.Models
{
    public sealed class ConstantRuleItem : RuleItem
    {
        public ConstantRuleItem(string leftPredicate, OperatorType operatorType, string rightPredicate, JoinType joinType = JoinType.None)
            : base(leftPredicate, operatorType, rightPredicate, true, joinType) { }
    }
}
