using System;
using System.Globalization;
using System.Linq.Expressions;
using RuleEngine.Core.Models;
using RuleEngine.Core.Specifications;

namespace RuleEngine.Core.Compilers
{
    internal sealed class RuleItemCompiler : IRuleItemCompiler
    {
        public ISpecification<T> Compile<T>(RuleItem ruleItem)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));

            Expression leftExpression = Expression.Property(parameterExpression, ruleItem.LeftPredicate);
            ExpressionType expressionType = (ExpressionType)Enum.Parse(typeof(ExpressionType), ruleItem.OperatorType.ToString());

            Expression rightExpression;

            if (ruleItem.IsRightPredicateConstant)
            {
                object value = Convert.ChangeType(ruleItem.RightPredicate, leftExpression.Type, CultureInfo.CurrentCulture);
                rightExpression = Expression.Constant(value);
            }
            else
            {
                rightExpression = Expression.Property(parameterExpression, ruleItem.RightPredicate);
            }

            BinaryExpression binaryExpression = Expression.MakeBinary(expressionType, leftExpression, rightExpression);
            Func<T, bool> function = Expression.Lambda<Func<T, bool>>(binaryExpression, parameterExpression).Compile();

            return new ExpressionSpecification<T>(function);
        }
    }
}
