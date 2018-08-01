namespace RuleEngine.Core.Models
{
    public sealed class PropertyRuleItem : RuleItem
    {
        public PropertyRuleItem(string leftPredicate, OperatorType operatorType, string rightPredicate, JoinType joinType = JoinType.None)
            : base(leftPredicate, operatorType, rightPredicate, false, joinType) { }
    }
}
