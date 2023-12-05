using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day04;

public class ScratchCardsTest
{
    [Theory]
    [InputFileData("2023/Day04/sample.txt", 13)]
    public void Total_points(string table, int expectedTotalPoints)
    {
        // Arrange
        var cards = Table.Parse(table);

        // Act
        var totalPoints = cards.Select(card => card.GetPoints()).Sum();

        // Assert
        totalPoints.Should().Be(expectedTotalPoints);
    }
    
    [Theory]
    [InputFileData("2023/Day04/sample.txt")]
    public void Table_parse_all_scratch_cards(string table)
    {
        // Act
        var cards = Table.Parse(table);

        // Assert
        cards.Should().HaveCount(6);
    }
}

public class Table
{
    public static IEnumerable<ScratchCard> Parse(string table)
    {
        return table.Split('\n').Select(line => new ScratchCard());
    }
}

public class ScratchCard
{
    public int GetPoints()
    {
        return 0;
    }
}