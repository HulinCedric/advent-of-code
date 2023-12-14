using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day08;

public class HauntedWastelandShould
{
    [Theory]
    [InputFileData("2023/Day08/sample1.txt", "AAA", "ZZZ", 2)]
    [InputFileData("2023/Day08/sample2.txt", "AAA", "ZZZ", 6)]
    [InputFileData("2023/Day08/input.txt", "AAA", "ZZZ", 20221)]
    [InputFileData("2023/Day08/sample3.txt", "A", "Z", 6)]
    [InputFileData("2023/Day08/input.txt", "A", "Z", 14616363770447)]
    public void Reach_ending_location_in_expected_steps(
        string mapDocument,
        string startingLocation,
        string endingLocation,
        long expectedSteps)
    {
        // Arrange
        var (instructions, network) = MapParser.Parse(mapDocument);

        // Act

        var steps = StartingLocations(startingLocation, network)
            .Select(location => StepsToEndingLocation(location, instructions, network, endingLocation))
            .Aggregate(1L, CommonEndSteps);

        // Assert
        steps.Should().Be(expectedSteps);
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

public static class MathUtils
{
    /// <seealso href="https://en.wikipedia.org/wiki/Least_common_multiple#Using_the_greatest_common_divisor" />
    public static long LeastCommonMultiple(long a, long b)
        => a / GreatestCommonDivisor(a, b) * b;

    /// <seealso href="https://en.wikipedia.org/wiki/Euclidean_algorithm#Implementations" />
    private static long GreatestCommonDivisor(long a, long b)
        => b == 0 ? a : GreatestCommonDivisor(b, a % b);
}