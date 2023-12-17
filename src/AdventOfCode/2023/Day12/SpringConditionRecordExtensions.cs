using static AdventOfCode._2023.Day12.SpringConditionRecord;

namespace AdventOfCode._2023.Day12;

public static class SpringConditionRecordExtensions
{
    public static SpringConditionRecord Unfold(this SpringConditionRecord record, int repeatCount)
        => new(
            UnfoldExtensions.Unfold(record.Springs, Spring.Unknown, repeatCount),
            ContiguousGroupOfDamagedSpringsExtensions.Unfold(record.ContiguousGroupOfDamagedSprings, repeatCount));

    public static SpringConditionRecord SpringConditionRecord(string record)
    {
        var part = record.Split(Separator);

        var springs = part[0];
        var contiguousGroupOfDamagedSprings = part[1].Parse();

        return new SpringConditionRecord(springs, contiguousGroupOfDamagedSprings);
    }
}