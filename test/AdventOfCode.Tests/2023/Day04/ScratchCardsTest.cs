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

    [Fact]
    public void CardWithNoMatches_ShouldScoreZero()
        => new ScratchCard(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }).GetPoints().Should().Be(0);
}

public class Table
{
    public static IEnumerable<ScratchCard> Parse(string table)
        => table.Split('\n')
            .Select(
                cardInformation =>
                {
                    var cardParts = cardInformation.Split(':', '|');

                    var winningNumbers = cardParts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    var numberYouHave = cardParts[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    return new ScratchCard(winningNumbers, numberYouHave);
                });
}

public class ScratchCard
{
    public ScratchCard(int[] winningNumbers, int[] numbersYouHave)
    {
    }

    public int GetPoints()
        => 0;
}