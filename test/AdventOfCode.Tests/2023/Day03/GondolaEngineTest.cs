using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day03;

public class GondolaEngineTest
{
    [Theory]
    [InputFileData("2023/Day03/sample.txt", 4361)]
    [InputFileData("2023/Day03/input.txt", 538792)]
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
    [InputFileData("2023/Day03/sample.txt", new[] { 467, 35, 633, 617, 592, 755, 664, 598 })]
    public void All_part_numbers(string schematic, int[] expectedPartNumbers)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var partNumbers = GondolaEngine.ParseNumberInMap(map)
            .Where(n => n.IsPartNumber(map))
            .Select(n => n.Value);

        // Assert
        partNumbers.Should().BeEquivalentTo(expectedPartNumbers);
    }

    [Theory]
    [InputFileData("2023/Day03/sample.txt", new[] { 467, 114, 35, 633, 617, 58, 592, 755, 664, 598 })]
    public void All_numbers(string schematic, int[] expectedPartNumbers)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var numbers = GondolaEngine.ParseNumberInMap(map)
            .Select(n => n.Value);

        // Assert
        numbers.Should().BeEquivalentTo(expectedPartNumbers);
    }

    [Theory]
    [InlineData("1", new[] { 1 })]
    [InlineData("114", new[] { 114 })]
    [InlineData(".114.", new[] { 114 })]
    [InlineData("467..114..", new[] { 467, 114 })]
    [InlineData("..35..633.", new[] { 35, 633 })]
    public void Identify_numbers(string schematic, int[] expectedNumber)
    {
        // Act
        var map = schematic.Split('\n');
        var number = GondolaEngine.ParseNumberInMap(map);

        // Assert
        number.Select(n => n.Value).Should().BeEquivalentTo(expectedNumber);
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
        var numbers = GondolaEngine.ParseNumberInMap(map);

        // Assert
        numbers.Should().HaveCount(1);
    }

    [Theory]
    [InlineData(".114.\n.....", false)]
    [InlineData("467.\n...*", true)]
    [InlineData("..*.\n.35.\n....", true)]
    [InlineData(".....\n.633.\n.#...", true)]
    [InlineData("....\n617*\n....", true)]
    [InlineData("....\n.58.\n....", false)]
    [InlineData("....+\n.592.\n.....", true)]
    [InlineData("...$.\n.664.", true)]
    public void Is_part_number(string schematic, bool expectedIsPartNumber)
    {
        // Arrange
        var map = schematic.Split('\n');
        var number = GondolaEngine.ParseNumberInMap(map).Single();

        // Act
        var isPartNumber = number.IsPartNumber(map);

        // Assert
        isPartNumber.Should().Be(expectedIsPartNumber);
    }
}

public static class GondolaEngine
{
    public static int CalculatePartNumbersSum(string[] map)
    {
        var partNumbers = ParseNumberInMap(map);
        return partNumbers.Where(n => n.IsPartNumber(map)).Sum(n => n.Value);
    }


    private static PartNumber[] GetNumbersInLine(string schematicLine, int lineIndex)
    {
        var coordinates = new List<(int startX, int endX, int y)>();
        for (var columnIndex = 0; columnIndex < schematicLine.Length; columnIndex++)
            if (char.IsDigit(schematicLine[columnIndex]))
            {
                var endX = columnIndex;
                while (endX < schematicLine.Length &&
                       char.IsDigit(schematicLine[endX]))
                    endX++;

                coordinates.Add((columnIndex, endX, lineIndex));
                columnIndex = endX;
            }

        var numbers = new List<PartNumber>();
        foreach (var coordinate in coordinates)
            numbers.Add(PartNumber.ExtractNumber(schematicLine, coordinate));

        return numbers.ToArray();
    }

    public static IEnumerable<PartNumber> ParseNumberInMap(string[] map)
    {
        var partNumbers = new List<PartNumber>();
        for (var lineIndex = 0; lineIndex < map.Length; lineIndex++)
        {
            var line = map[lineIndex];
            partNumbers.AddRange(GetNumbersInLine(line, lineIndex));
        }

        return partNumbers;
    }
}

public class PartNumber
{
    private PartNumber(int value, int startX, int endX, int y)
    {
        Value = value;
        StartX = startX;
        EndX = endX;
        Y = y;
    }

    public int EndX { get; }
    public int StartX { get; }
    public int Value { get; }
    public int Y { get; }

    internal static PartNumber ExtractNumber(string schematic, (int startX, int endX, int y) coordinate)
    {
        var number = 0;
        for (var i = coordinate.startX; i < coordinate.endX; i++)
            number = number * 10 + (schematic[i] - '0');

        return new PartNumber(number, coordinate.startX, coordinate.endX, coordinate.y);
    }

    public bool IsPartNumber(string[] map)
    {
        for (var x = StartX - 1; x <= EndX + 1; x++)
        for (var y = Y - 1; y <= Y + 1; y++)
            if (x >= 0 &&
                x < map[0].Length &&
                y >= 0 &&
                y < map.Length)
                if (!char.IsDigit(map[y][x]) &&
                    map[y][x] != '.')
                    return true;

        return false;
    }
}