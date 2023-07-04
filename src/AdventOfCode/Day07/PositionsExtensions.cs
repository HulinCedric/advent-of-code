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

    public static long GetCheapestTotalFuelCost2(int[] crabPositions)
        => GetMapPositions(crabPositions)
            .Select(position => crabPositions.GetTotalFuelCostAt(position))
            .Min();

    private static IEnumerable<int> GetMapPositions(int[] crabPositions)
    {
        for (var position = crabPositions.Min(); position <= crabPositions.Max(); position++)
            yield return position;
    }

    private static int GetTotalFuelCostAt(this int[] crabPositions, int mapPosition)
        => crabPositions
            .Select(crabPosition => GetDistance(mapPosition, crabPosition))
            .Select(distance => GetFuelCost(distance))
            .Sum();

    private static int GetFuelCost(int distance)
        => distance * (distance + 1) / 2;

    private static int GetDistance(int position, int item)
        => Math.Abs(item - position);
}