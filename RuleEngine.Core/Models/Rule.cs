using System;
using System.Collections.Generic;
using System.Linq;
using RuleEngine.Core.Exceptions;

namespace RuleEngine.Core.Models
{
    public sealed class Rule
    {
        private readonly IList<RuleItem> _ruleItems = new List<RuleItem>();

        public Rule(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }
        public string Message { get; }
        public IEnumerable<RuleItem> RuleItems => _ruleItems;

        public void AddRuleItem(RuleItem ruleItem)
        {
            if (ruleItem == null)
                throw new ArgumentNullException(nameof(ruleItem));

            if (!ruleItem.IsValid())
                throw new FailedValidationException();

            if (_ruleItems.Any() && ruleItem.JoinType == JoinType.None)
                throw new InvalidOperationException();

            if (_ruleItems.Contains(ruleItem))
                return;

            _ruleItems.Add(ruleItem);
        }

        public void RemoveRuleItem(RuleItem ruleItem)
        {
            _ruleItems.Remove(ruleItem);
        }

        internal bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Code))
                return false;

            if (string.IsNullOrWhiteSpace(Message))
                return false;

            if (!RuleItems.Any())
                return false;

            return true;
        }
    }
}
