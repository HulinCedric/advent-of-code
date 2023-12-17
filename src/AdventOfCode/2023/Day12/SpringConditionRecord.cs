using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode._2023.Day12;

using Cache = Dictionary<(string, ImmutableStack<int>), long>;

public readonly record struct SpringConditionRecord(string Springs, IEnumerable<int> ContiguousGroupOfDamagedSprings)
{
    public const char ContiguousGroupOfDamagedSpringsSeparator = ',';

    public string ContiguousGroupOfDamagedSpringsString()
        => string.Join(ContiguousGroupOfDamagedSpringsSeparator, ContiguousGroupOfDamagedSprings);

    public long Arrangements()
        => SpringConditionRecordArrangementExtensions.Arrangements(
            Springs,
            ImmutableStack.CreateRange(ContiguousGroupOfDamagedSprings.Reverse()),
            new Cache());
}