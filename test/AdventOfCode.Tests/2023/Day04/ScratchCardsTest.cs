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
}

public class Table
{
    public static IEnumerable<ScratchCard> Parse(string table)
    {
        return ArraySegment<ScratchCard>.Empty;
    }
}

public class ScratchCard
{
    public int GetPoints()
    {
        return 0;
    }
}