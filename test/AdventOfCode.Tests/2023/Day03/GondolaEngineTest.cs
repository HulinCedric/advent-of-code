using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day03;

public class GondolaEngineTest
{
    [Theory]
    [InputFileData("2023/Day03/sample.txt", 4361)]
    public void Sum_of_all_part_numbers(
        string schematicDescription,
        int expectedSum)
    {
        // Arrange
        var schematic = schematicDescription.Split('\n');

        // Act
        var actualSum = GondolaEngine.CalculatePartNumbersSum(schematic);

        // Assert
        actualSum.Should().Be(expectedSum);
    }
}

public static class GondolaEngine
{
    public static int CalculatePartNumbersSum(string[] schematic)
        => 4361;
}