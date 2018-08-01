using System;
using System.Collections.Generic;
using System.Linq;
using RuleEngine.Core.Exceptions;

namespace RuleEngine.Core.Models
{
    public class RuleSet
    {
        private readonly IList<Rule> _rules = new List<Rule>();

        public RuleSet(string name, string description, string version)
        {
            Name = name;
            Description = description;
            Version = version;
        }

        public string Name { get; }
        public string Description { get; }
        public string Version { get; }
        public IEnumerable<Rule> Rules => _rules;

        public void AddRule(Rule rule)
        {
            if (rule == null)
                throw new ArgumentNullException(nameof(rule));

            if (!rule.IsValid())
                throw new FailedValidationException();

            if (_rules.Contains(rule))
                return;

            _rules.Add(rule);
        }

        public void RemoveRule(Rule rule)
        {
            _rules.Remove(rule);
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            if (string.IsNullOrEmpty(Description))
                return false;

            if (string.IsNullOrEmpty(Version))
                return false;

            if (!Rules.Any())
                return false;

            return true;
        }
    }
}
