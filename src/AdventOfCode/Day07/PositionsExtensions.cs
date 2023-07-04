using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day07;

public static class PositionsExtensions
{
    public static int Median(this IEnumerable<int> positions)
        => positions.OrderBy(position => position).ElementAt(positions.Count() / 2);

    public static long GetCheapestTotalFuelCost(IEnumerable<int> positions)
    {
        // Compute total distance between each position and the chosen position
        var chosenPosition = positions.Median();

        var totalFuelCost = positions.Sum(position => Math.Abs(position - chosenPosition));

        return totalFuelCost;
    }
}