using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day19
{
    public static class RuleParser
    {
        public static Dictionary<int, Rule> Parse(string input)
        {
            var rules = input
                .Split(Environment.NewLine)
                .Select(Rule.Parse)
                .ToDictionary(r => r.RuleId);

            foreach (var rule in rules.Values)
                rule.Resolve(rules);

            return rules;
        }


        public static IEnumerable<(int, string)> ParseRaw(string rulesDescription)
        {
            var split = rulesDescription.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            return split.Select(ParseSingle);
        }

        public static (int, string) ParseSingle(string ruleDescription)
        {
            var split = ruleDescription.Split(":", StringSplitOptions.TrimEntries);
            return (Convert.ToUInt16(split[0]), split[1]);
        }
    }
}