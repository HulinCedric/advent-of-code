using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day03;

public class GondolaEngineTest
{
    [Theory]
    [InputFileData("2023/Day03/sample.txt", 4361)]
    [InputFileData("2023/Day03/input.txt", 531932)]
    public void Sum_of_all_part_numbers(string schematic, int expectedSum)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var actualSum = GondolaEngine.CalculatePartNumbersSum(map);

        // Assert
        actualSum.Should().Be(expectedSum);
    }

    [Theory]
    [InputFileData("2023/Day03/sample.txt", 467835)]
    [InputFileData("2023/Day03/input.txt", 73646890)]
    public void Sum_of_all_gear_ratio(string schematic, int expectedSum)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var actualSum = GondolaEngine.CalculateGearRatioSum(map);

        // Assert
        actualSum.Should().Be(expectedSum);
    }

    [Theory]
    [InlineData(".114.\n.....")]
    [InlineData("467.\n...*")]
    [InlineData("..*.\n.35.\n....")]
    [InlineData(".....\n.633.\n.#...")]
    [InlineData("....\n617*\n....")]
    public void Parse_number_in_map(string schematic)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var numbers = GondolaEngine.ParseInSchematic<Number>(map);

        // Assert
        numbers.Should().HaveCount(1);
    }

    [Theory]
    [InlineData("467.\n...*")]
    [InlineData("..*.\n.35.\n....")]
    [InlineData(".....\n.633.\n.#...")]
    [InlineData("....\n617*\n....")]
    public void Parse_symbol_in_map(string schematic)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var symbols = GondolaEngine.ParseInSchematic<Symbol>(map);

        // Assert
        symbols.Should().HaveCount(1);
    }

    [Theory]
    [InlineData("467.\n...*")]
    [InlineData("..*.\n.35.\n....")]
    [InlineData("....\n617*\n....")]
    public void Parse_gears_in_map(string schematic)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var numbers = GondolaEngine.ParseInSchematic<Gear>(map);

        // Assert
        numbers.Should().HaveCount(1);
    }
}