using System;
using System.Linq;

namespace AdventOfCode._2023.Day18;

public static class DigPlanParser
{
    public static DigPlan Parse(string input, Func<string, DigInstruction> parse)
        => new(
            from line in input.Split('\n')
            let instruction = parse(line)
            select instruction);
}