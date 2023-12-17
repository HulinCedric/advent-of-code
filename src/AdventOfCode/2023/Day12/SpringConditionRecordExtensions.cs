using System.Linq;

namespace AdventOfCode._2023.Day12;

public static class SpringConditionRecordExtensions
{
    public static SpringConditionRecord Unfold(this SpringConditionRecord record, int repeatCount)
        => new(
            Unfold(record.Springs, Spring.Unknown, repeatCount),
            Unfold(
                    record.ContiguousGroupOfDamagedSpringsString(),
                    Day12.SpringConditionRecord.ContiguousGroupOfDamagedSpringsSeparator,
                    repeatCount)
                .ParseContiguousGroupOfDamagedSprings());

    public static string Unfold(string value, char separator, int repeatCount)
        => string.Join(separator, Enumerable.Repeat(value, repeatCount));

    public static SpringConditionRecord SpringConditionRecord(string record)
    {
        var part = record.Split(Day12.SpringConditionRecord.Separator);

        var springs = part[0];
        var contiguousGroupOfDamagedSprings = part[1].ParseContiguousGroupOfDamagedSprings();

        return new SpringConditionRecord(springs, contiguousGroupOfDamagedSprings);
    }

    private static int[] ParseContiguousGroupOfDamagedSprings(this string part)
        => part.Split(Day12.SpringConditionRecord.ContiguousGroupOfDamagedSpringsSeparator).Select(int.Parse).ToArray();
}