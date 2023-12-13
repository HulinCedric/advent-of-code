using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day08;

public class HauntedWastelandShould
{
    [Theory]
    [InputFileData("2023/Day08/sample1.txt", 2)]
    [InputFileData("2023/Day08/sample2.txt", 6)]
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
}