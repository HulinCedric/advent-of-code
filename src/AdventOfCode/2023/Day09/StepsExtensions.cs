using System.Linq;

namespace AdventOfCode._2023.Day09;

public static class StepsExtensions
{
    public static int[] Differences(this int[] steps)
        => steps.Zip(steps.Skip(1)).Select(Difference).ToArray();

    private static int Difference((int First, int Second) step)
        => step.Second - step.First;
}