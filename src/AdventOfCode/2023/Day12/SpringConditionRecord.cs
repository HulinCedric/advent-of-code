using System.Collections.Generic;

namespace AdventOfCode._2023.Day12;

public readonly record struct SpringConditionRecord(string Springs, IEnumerable<int> ContiguousGroupOfDamagedSprings)
{
    public const char ContiguousGroupOfDamagedSpringsSeparator = ',';

    public string ContiguousGroupOfDamagedSpringsString()
        => string.Join(ContiguousGroupOfDamagedSpringsSeparator, ContiguousGroupOfDamagedSprings);
}