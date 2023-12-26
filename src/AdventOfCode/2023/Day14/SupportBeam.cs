using System.Linq;

namespace AdventOfCode._2023.Day14;

public static class SupportBeam
{
    /// <summary>
    ///     The total load is the sum of the load caused by all of the rounded rocks.
    /// </summary>
    public static int TotalLoad(Map map)
        => map
            .Select(row => row.RoundedRockLoad())
            .Sum();
}