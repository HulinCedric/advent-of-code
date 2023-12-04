using System;
using System.Collections.Generic;
using System.Linq;
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
    [InputFileData("2023/Day03/sample.txt", new[] { 467, 35, 633, 617, 592, 755, 664, 598 })]
    public void All_part_numbers(string schematic, int[] expectedPartNumbers)
    {
        // Arrange
        var map = schematic.Split('\n');

        var numbers = GondolaEngine.ParseNumberInMap(map).ToArray();
        var symbols = GondolaEngine.ParseSymbolInMap(map).ToArray();

        // Act
        var partNumbers = numbers
            .Where(n => n.IsAdjacent(symbols))
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
        // Arrange
        var map = schematic.Split('\n');

        // Act
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
    [InlineData("467.\n...*")]
    [InlineData("..*.\n.35.\n....")]
    [InlineData(".....\n.633.\n.#...")]
    [InlineData("....\n617*\n....")]
    public void Parse_symbol_in_map(string schematic)
    {
        // Arrange
        var map = schematic.Split('\n');

        // Act
        var symbols = GondolaEngine.ParseSymbolInMap(map);

        // Assert
        symbols.Should().HaveCount(1);
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
        var symbols = GondolaEngine.ParseSymbolInMap(map).ToArray();

        // Act
        var isPartNumber = number.IsAdjacent(symbols);

        // Assert
        isPartNumber.Should().Be(expectedIsPartNumber);
    }
}

public static class GondolaEngine
{
    public static int CalculatePartNumbersSum(string[] map)
    {
        var partNumbers = ParseNumberInMap(map);
        var symbols = ParseSymbolInMap(map);

        return (from number in partNumbers
                from symbol in symbols
                where number.IsAdjacent(symbol)
                select number.Value).Sum();
    }

    public static IEnumerable<Symbol> ParseSymbolInMap(string[] map)
    {
        var symbolRegex = new Regex("[^.0-9]");

        var symbols = new List<Symbol>();
        for (var rowIndex = 0; rowIndex < map.Length; rowIndex++)
        {
            foreach (Match found in symbolRegex.Matches(map[rowIndex]))
            {
                symbols.Add(new Symbol(found.Value, rowIndex, found.Index));
            }
        }

        return symbols;
    }

    public static IEnumerable<Number> ParseNumberInMap(string[] map)
    {
        var numberRegex = new Regex(@"\d+");

        var numbers = new List<Number>();
        for (var rowIndex = 0; rowIndex < map.Length; rowIndex++)
        {
            foreach (Match found in numberRegex.Matches(map[rowIndex]))
            {
                numbers.Add(new Number(found.Value, rowIndex, found.Index));
            }
        }

        return numbers;
    }
}

public class Symbol
{
    public Symbol(string text, int rowIndex, int columnIndex)
    {
        Text = text;
        RowIndex = rowIndex;
        ColumnIndex = columnIndex;
    }

    public int ColumnIndex { get; }
    public int RowIndex { get; }
    public string Text { get; }
}

public class Number
{
    public Number(string text, int rowIndex, int columnIndex)
    {
        Value = int.Parse(text);
        Text = text;
        RowIndex = rowIndex;
        ColumnIndex = columnIndex;
    }

    public int ColumnIndex { get; }
    public int RowIndex { get; }
    public string Text { get; }
    public int Value { get; }

    public bool IsAdjacent(Symbol[] symbols)
        => symbols.Any(IsAdjacent);

    public bool IsAdjacent(Symbol symbol)
        => Math.Abs(symbol.RowIndex - RowIndex) <= 1 &&
           ColumnIndex <= symbol.ColumnIndex + symbol.Text.Length &&
           symbol.ColumnIndex <= ColumnIndex + Text.Length;
}