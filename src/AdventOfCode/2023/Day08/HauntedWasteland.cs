using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day08;

public static class HauntedWasteland
{
    public static long Steps(this string mapDocument, string startingLocation, string endingLocation)
    {
        var (instructions, network) = MapParser.Parse(mapDocument);

        return StartingLocations(startingLocation, network)
            .Select(location => StepsToEndingLocation(location, instructions, network, endingLocation))
            .CommonEndSteps();
    }


    private static List<string> StartingLocations(string startingLocation, Dictionary<string, (string, string)> network)
        => network.Keys.Where(location => location.Is(startingLocation)).ToList();


    private static long StepsToEndingLocation(
        string location,
        char[] instructions,
        IReadOnlyDictionary<string, (string, string)> network,
        string endingLocation)
    {
        var steps = 0L;
        while (!location.Is(endingLocation))
        {
            location = GetNextLocation(location, steps, instructions, network);
            steps++;
        }

        return steps;
    }

    private static bool Is(this string location, string locationPattern)
        => location.EndsWith(locationPattern);

    private static string GetNextLocation(
        string location,
        long steps,
        char[] instructions,
        IReadOnlyDictionary<string, (string, string)> network)
    {
        var (left, right) = network[location];
        return instructions[steps % instructions.Length] == 'R' ? right : left;
    }

    private static long CommonEndSteps(this IEnumerable<long> steps)
        => steps.Aggregate(1L, MathUtils.LeastCommonMultiple);
}