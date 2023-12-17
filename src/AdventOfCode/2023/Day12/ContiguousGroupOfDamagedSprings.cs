using System.Collections.Generic;

namespace AdventOfCode._2023.Day12;

public static class ContiguousGroupOfDamagedSprings
{
    public const char SpringsSeparator = ',';

    public static string String(this IEnumerable<int> contiguousGroupOfDamagedSprings)
        => string.Join(SpringsSeparator, contiguousGroupOfDamagedSprings);
}