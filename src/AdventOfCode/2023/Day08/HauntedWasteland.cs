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
            .Aggregate(1L, CommonEndSteps);
    }

    private static List<string> StartingLocations(string startingLocation, Dictionary<string, (string, string)> network)
        => network.Keys.Where(location => location.EndsWith(startingLocation)).ToList();

    private static long StepsToEndingLocation(
        string location,
        char[] instructions,
        IReadOnlyDictionary<string, (string, string)> network,
        string endingLocation)
    {
        var steps = 0L;
        while (!location.EndsWith(endingLocation))
        {
            var (left, right) = network[location];
            location = instructions[steps % instructions.Length] == 'R' ? right : left;
            steps++;
        }

        return steps;
    }

    private static long CommonEndSteps(long a, long b)
        => MathUtils.LeastCommonMultiple(a, b);
}