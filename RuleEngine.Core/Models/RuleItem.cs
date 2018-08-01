namespace RuleEngine.Core.Models
{
    public abstract class RuleItem
    {
        public RuleItem(string leftPredicate, OperatorType operatorType, string rightPredicate, bool isRightPredicateConstant, JoinType joinType)
        {
            LeftPredicate = leftPredicate;
            OperatorType = operatorType;
            RightPredicate = rightPredicate;
            IsRightPredicateConstant = isRightPredicateConstant;
            JoinType = joinType;
        }

        public string LeftPredicate { get; }
        public OperatorType OperatorType { get; }
        public string RightPredicate { get; }
        public JoinType JoinType { get; }
        internal bool IsRightPredicateConstant { get; }

        internal bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(LeftPredicate))
                return false;

            if (OperatorType == OperatorType.None)
                return false;

            return true;
        }
    }
}
