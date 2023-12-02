using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day19
{
    internal record CharRule(int RuleId, char Char) : Rule(RuleId)
    {
        public override void Resolve(Dictionary<int, Rule> allRules)
        {}

        public override IEnumerable<Match> Matches(string input)
            => input.FirstOrDefault() == Char
                   ? new[] { new Match(input.Substring(1)) }
                   : Array.Empty<Match>();

        public override string ToString()
            => Char.ToString();
    }
}