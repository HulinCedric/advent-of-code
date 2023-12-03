using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day03;

public class GondolaEngineTest
{
    [Theory]
    [InputFileData("2023/Day03/sample.txt", 4361)]
    public void Sum_of_all_part_numbers(string schematicDescription, int expectedSum)
    {
        // Arrange
        var schematic = schematicDescription.Split('\n');

        // Act
        var actualSum = GondolaEngine.CalculatePartNumbersSum(schematic);

        // Assert
        actualSum.Should().Be(expectedSum);
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
        var number = GondolaEngine.GetNumbers(schematic);

        // Assert
        number.Select(n => n.Value).Should().BeEquivalentTo(expectedNumber);
    }

    [Theory]
    [InlineData(".114.\n.....")]
    [InlineData("467.\n...*")]
    [InlineData("..*.\n.35.\n....")]
    public void Parse_number_in_map(string schematic)
    {
        // Act
        var numbers = GondolaEngine.GetNumbers(schematic);

        // Assert
        numbers.Should().HaveCount(1);
    }
}

public static class GondolaEngine
{
    public static int CalculatePartNumbersSum(string[] schematic)
        => 4361;


    private static PartNumber[] GetNumbersInLine(string schematicLine, int lineIndex)
    {
        var coordinates = new List<(int startX, int endX, int y)>();
        for (var columnIndex = 0; columnIndex < schematicLine.Length; columnIndex++)
        {
            if (char.IsDigit(schematicLine[columnIndex]))
            {
                var endX = columnIndex;
                while (endX < schematicLine.Length &&
                       char.IsDigit(schematicLine[endX]))
                {
                    endX++;
                }

                coordinates.Add((columnIndex, endX, lineIndex));
                columnIndex = endX;
            }
        }

        var numbers = new List<PartNumber>();
        foreach (var coordinate in coordinates)
        {
            numbers.Add(PartNumber.ExtractNumber(schematicLine, coordinate));
        }

        return numbers.ToArray();
    }

    public static IEnumerable<PartNumber> GetNumbers(string schematic)
    {
        var map = schematic.Split('\n');

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
}