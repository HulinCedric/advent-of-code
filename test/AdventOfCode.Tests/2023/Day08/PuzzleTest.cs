using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day08;

public class HauntedWastelandShould
{
    [Theory]
    [InputFileData("2023/Day08/sample1.txt", 2)]
    [InputFileData("2023/Day08/sample2.txt", 6)]
    [InputFileData("2023/Day08/input.txt", 20221)]
    public void ReachZZZInExpectedSteps(string mapDocument, int expectedSteps)
    {
        // Arrange
        var (instructions, network) = MapParser.Parse(mapDocument);
        var startingLocation = "AAA";
        var endingLocation = "ZZZ";

        // Act
        var steps = FindEndLocation(startingLocation, network, instructions, endingLocation);

        // Assert
        steps.Should().Be(expectedSteps);
    }

    [Theory]
    [InputFileData("2023/Day08/sample3.txt", 6)]
    [InputFileData("2023/Day08/input.txt", 14616363770447)]
    public void ReachZZZInExpectedSteps_two(string mapDocument, long expectedSteps)
    {
        // Arrange
        var (instructions, network) = MapParser.Parse(mapDocument);

        // Act
        var startingLocations = network.Keys.Where(location => location.EndsWith("A")).ToList();

        var step = startingLocations
            .Select(startingLocation => FindEndLocation(startingLocation, network, instructions, "Z"))
            .Aggregate(1L, CommonEndSteps);

        // Assert
        step.Should().Be(expectedSteps);
    }

    private static long FindEndLocation(
        string location,
        IReadOnlyDictionary<string, (string, string)> network,
        char[] instructions,
        string endLocation)
    {
        var steps = 0L;
        while (!location.EndsWith(endLocation))
        {
            var (left, right) = network[location];
            location = instructions[steps % instructions.Length] == 'R' ? right : left;
            steps++;
        }

        return steps;
    }

    private static long CommonEndSteps(long a, long b)
        => LeastCommonMultiple(a, b);

    /// <summary>
    ///     Calculates the least common multiple (LCM) of two numbers.
    /// </summary>
    /// <seealso href="https://en.wikipedia.org/wiki/Least_common_multiple#Using_the_greatest_common_divisor" />
    private static long LeastCommonMultiple(long a, long b)
        => a / GreatestCommonDivisor(a, b) * b;

    /// <remarks>
    ///     Recursive implementation of GCD
    /// </remarks>
    /// <seealso href="https://en.wikipedia.org/wiki/Euclidean_algorithm#Implementations" />
    private static long GreatestCommonDivisor(long a, long b)
        => b == 0 ? a : GreatestCommonDivisor(b, a % b);
}