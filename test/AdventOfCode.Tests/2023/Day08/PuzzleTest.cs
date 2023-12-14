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

        // Act
        var location = "AAA";
        var steps = 0;
        while (location != "ZZZ")
        {
            var (left, right) = network[location];
            location = instructions[steps % instructions.Length] == 'R' ? right : left;
            steps++;
        }

        // Assert
        steps.Should().Be(expectedSteps);
    }

    [Theory]
    [InputFileData("2023/Day08/sample3.txt", 6)]
    [InputFileData("2023/Day08/input.txt", 20221)]
    public void ReachZZZInExpectedSteps_two(string mapDocument, long expectedSteps)
    {
        // Arrange
        var (instructions, network) = MapParser.Parse(mapDocument);

        // Act
        var locations = network.Keys.Where(location => location.EndsWith("A")).ToList();

        var steps = 0L;
        while (!locations.All(location => location.EndsWith('Z')))
        {
            for (var index = 0; index < locations.Count; index++)
            {
                var location = locations[index];
                var (left, right) = network[location];
                var newLocation = instructions[steps % instructions.Length] == 'R' ? right : left;
                locations[index] = newLocation;
            }

            steps++;
        }

        // Assert
        steps.Should().Be(expectedSteps);
    }
}