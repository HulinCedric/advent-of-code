using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day19
{
    internal record CompoundRule(int RuleId, params Rule[] Rules) : Rule(RuleId)
    {
        public override IEnumerable<Match> Matches(string input)
            => from rule in Rules
               from match in rule.Matches(input)
               select match;

        public override void Resolve(Dictionary<int, Rule> allRules)
        {
            foreach (var rule in Rules)
                rule.Resolve(allRules);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var rule in Rules)
                result = result + "|" + rule;

            return result.Trim('|').Replace("|", " | ");
        }
    }
}