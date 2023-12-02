using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day19
{
    internal record LinkRule(int RuleId, int[] LinkedRuleNumbers) : Rule(RuleId)
    {
        private Rule[] LinkedRules { get; set; } = Array.Empty<Rule>();

        public override IEnumerable<Match> Matches(string input)
            => LinkedRules.Aggregate(
                new[] { new Match(input) },
                (acc, rule) => acc.SelectMany(m => rule.Matches(m.Remaining))
                    .ToArray());

        public override void Resolve(Dictionary<int, Rule> allRules)
            => LinkedRules = LinkedRuleNumbers.Select(x => allRules[x]).ToArray();

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var rule in LinkedRules)
                result = result + rule;
            return result;
        }
    }
}