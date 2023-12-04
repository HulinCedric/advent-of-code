using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
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
        var numbers = GondolaEngine.ParseInMap<Number>(map);

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
        var symbols = GondolaEngine.ParseInMap<Symbol>(map);

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
        var numbers = GondolaEngine.ParseInMap<Gear>(map);

        // Assert
        numbers.Should().HaveCount(1);
    }
}

public static class GondolaEngine
{
    public static int CalculatePartNumbersSum(string[] map)
    {
        var partNumbers = ParseInMap<Number>(map);
        var symbols = ParseInMap<Symbol>(map);

        return (from number in partNumbers
                from symbol in symbols
                where number.IsAdjacent(symbol)
                select number.Value).Sum();
    }

    public static int CalculateGearRatioSum(string[] map)
    {
        var gears = ParseInMap<Gear>(map);
        var numbers = ParseInMap<Number>(map);

        return gears
            .Select(gear => numbers.Where(number => number.IsAdjacent(gear)).ToArray())
            .Where(gearPartNumbers => gearPartNumbers.Length == 2)
            .Sum(gearsPartNumbers => gearsPartNumbers[0].Value * gearsPartNumbers[1].Value);
    }

    public static List<TPart> ParseInMap<TPart>(string[] map) where TPart : Part
    {
        var regexMethod = typeof(TPart).GetMethod("Regex", BindingFlags.Static | BindingFlags.NonPublic);
        var regex = (Regex)regexMethod.Invoke(null, null);
        return ParseInMap<TPart>(map, regex);
    }

    private static List<TPart> ParseInMap<TPart>(string[] map, Regex regex) where TPart : Part
    {
        var parts = new List<TPart>();

        for (var rowIndex = 0; rowIndex < map.Length; rowIndex++)
        {
            foreach (Match found in regex.Matches(map[rowIndex]))
            {
                parts.Add(PartFactory.Create<TPart>(found.Value, rowIndex, found.Index));
            }
        }

        return parts;
    }
}

public class Part
{
    protected Part(string text, int rowIndex, int columnIndex)
    {
        ColumnIndex = columnIndex;
        RowIndex = rowIndex;
        Text = text;
    }

    public int ColumnIndex { get; }
    public int RowIndex { get; }
    public string Text { get; }
}

public partial class Symbol(string text, int rowIndex, int columnIndex) : Part(text, rowIndex, columnIndex)
{
    [GeneratedRegex("[^.0-9]")]
    internal static partial Regex Regex();
}

public partial class Gear(string text, int rowIndex, int columnIndex) : Part(text, rowIndex, columnIndex)
{
    [GeneratedRegex(@"\*")]
    internal static partial Regex Regex();
}

public partial class Number(string text, int rowIndex, int columnIndex) : Part(text, rowIndex, columnIndex)
{
    public int Value { get; } = int.Parse(text);

    [GeneratedRegex(@"\d+")]
    internal static partial Regex Regex();

    public bool IsAdjacent(Part part)
        => Math.Abs(part.RowIndex - RowIndex) <= 1 &&
           ColumnIndex <= part.ColumnIndex + part.Text.Length &&
           part.ColumnIndex <= ColumnIndex + Text.Length;
}

public static class PartFactory
{
    public static TPart Create<TPart>(string text, int rowIndex, int columnIndex) where TPart : Part
    {
        if (typeof(TPart) == typeof(Number))
        {
            return (TPart)(object)new Number(text, rowIndex, columnIndex);
        }

        if (typeof(TPart) == typeof(Symbol))
        {
            return (TPart)(object)new Symbol(text, rowIndex, columnIndex);
        }

        if (typeof(TPart) == typeof(Gear))
        {
            return (TPart)(object)new Gear(text, rowIndex, columnIndex);
        }

        throw new ArgumentException($"Unsupported type: {typeof(TPart)}");
    }
}