using System.Linq;

namespace AdventOfCode._2023.Day09;

public static class StepsExtensions
{
    public static long[] Differences(this long[] steps)
        => steps.Zip(steps.Skip(1)).Select(Difference).ToArray();

    private static long Difference((long First, long Second) step)
        => step.Second - step.First;
}