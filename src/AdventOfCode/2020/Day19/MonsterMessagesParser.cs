using System;
using System.Collections.Generic;

namespace AdventOfCode._2020.Day19
{
    public static class MonsterMessagesParser
    {
        public static (Dictionary<int, Rule>rules, string[] messages) Parse(string input)
        {
            var parts = input.Split(Environment.NewLine + Environment.NewLine);
            var messages = parts[1].Split(Environment.NewLine);
            return (RuleParser.Parse(parts[0]), messages);
        }
    }
}