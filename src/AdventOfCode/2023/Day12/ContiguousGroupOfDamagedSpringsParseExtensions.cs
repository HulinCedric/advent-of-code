using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day12;

public static class ContiguousGroupOfDamagedSpringsExtensions
{
    public static int[] Parse(this string raw)
        => raw.Split(ContiguousGroupOfDamagedSprings.SpringsSeparator).Select(int.Parse).ToArray();

    public static IEnumerable<int> Unfold(IEnumerable<int> values, int repeatCount)
        => UnfoldExtensions.Unfold(
                values.String(),
                ContiguousGroupOfDamagedSprings.SpringsSeparator,
                repeatCount)
            .Parse();
}