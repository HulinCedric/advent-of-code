using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day15;

public static class InitializationSequence
{
    public static IEnumerable<Step> Parse(string initializationSequence)
        => initializationSequence
            .Split(',')
            .Select(Step.Parse);
}