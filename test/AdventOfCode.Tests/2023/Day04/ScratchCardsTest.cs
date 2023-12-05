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
    [InputFileData("2023/Day04/input.txt", 24542)]
    public void Should_calculate_total_points(string table, int expectedTotalPoints)
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
    public void Should_parse_all_scratch_cards_on_table(string table)
        => Table.Parse(table).Should().HaveCount(6);

    [Fact]
    public void Should_score_zero_with_no_matches()
        => new ScratchCard(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }).GetPoints().Should().Be(0);

    [Fact]
    public void Should_score_one_with_one_match()
        => new ScratchCard(new[] { 1, 2, 3 }, new[] { 3, 4, 5 }).GetPoints().Should().Be(1);

    [Fact]
    public void Should_score_two_with_two_matches()
        => new ScratchCard(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 5, 6 }).GetPoints().Should().Be(2);

    [Fact]
    public void Should_score_four_with_three_matches()
        => new ScratchCard(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 5 }).GetPoints().Should().Be(4);

    [Fact]
    public void Should_score_eight_with_four_matches()
        => new ScratchCard(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 }).GetPoints().Should().Be(8);
}

public class Table
{
    public static IEnumerable<ScratchCard> Parse(string table)
        => table.Split('\n')
            .Select(
                cardInformation =>
                {
                    var cardParts = cardInformation.Split(':', '|');

                    var winningNumbers = cardParts[1]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    var numberYouHave = cardParts[2]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    return new ScratchCard(winningNumbers, numberYouHave);
                });
}

public class ScratchCard
{
    private readonly int[] numbersYouHave;
    private readonly int[] winningNumbers;

    public ScratchCard(int[] winningNumbers, int[] numbersYouHave)
    {
        this.winningNumbers = winningNumbers;
        this.numbersYouHave = numbersYouHave;
    }

    public int GetPoints()
        => (int)Math.Pow(2, Matches() - 1);

    private int Matches()
        => winningNumbers.Intersect(numbersYouHave).Count();
}