using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020.Day19
{
    public abstract record Rule
    {
        protected Rule(int ruleId)
            => RuleId = ruleId;

        public int RuleId { get; }

        public abstract void Resolve(Dictionary<int, Rule> allRules);


        public abstract IEnumerable<Match> Matches(string input);

        public static Rule Parse(string input)
        {
            var match = Regex.Match(
                input,
                "(?<num>\\d*): (?:(?:\\\"(?<char>.*)\\\")|(?<numlist1>.*) \\| (?<numlist2>.*)|(?<numlist>.*))");

            var ruleId = int.Parse(match.Groups["num"].Value);

            LinkRule ParseLinkRule(string value)
                => new(ruleId, value.Split(' ').Select(int.Parse).ToArray());

            return match switch
            {
                { } m when m.Groups["numlist"].Success =>
                    ParseLinkRule(match.Groups["numlist"].Value),

                { } m when m.Groups["numlist1"].Success && m.Groups["numlist2"].Success =>
                    new CompoundRule(
                        ruleId,
                        ParseLinkRule(match.Groups["numlist1"].Value),
                        ParseLinkRule(match.Groups["numlist2"].Value)),

                { } m when m.Groups["char"].Success =>
                    new CharRule(ruleId, match.Groups["char"].Value.Single()),

                _ => throw new InvalidOperationException("Can't parse rule")
            };
        }
    }
}