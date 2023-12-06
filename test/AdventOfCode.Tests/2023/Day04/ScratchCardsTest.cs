using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day04;

public class ScratchCardsTest
{
    [Theory]
    [InputFileData("2023/Day04/sample.txt", 13)]
    [InputFileData("2023/Day04/input.txt", 24542)]
    public void Should_calculate_total_points(string table, int totalPoints)
        => Table.Parse(table)
            .Select(card => card.GetPoints())
            .Sum()
            .Should()
            .Be(totalPoints);

    [Theory]
    [InputFileData("2023/Day04/sample.txt", 30)]
    [InputFileData("2023/Day04/input.txt", 8736438)]
    public void Should_calculate_total_scratch_cards(string table, int totalCards)
        => ScratchCards.CountTotalCards(Table.Parse(table).ToList())
            .Should()
            .Be(totalCards);

    [Theory]
    [InputFileData("2023/Day04/sample.txt")]
    public void Should_parse_all_scratch_cards_on_table(string table)
        => Table.Parse(table)
            .Should()
            .HaveCount(6);

    [Fact]
    public void Should_score_zero_with_no_matches()
        => new ScratchCard(new[] { 1, 2, 3 }, new[] { 4, 5, 6 })
            .GetPoints()
            .Should()
            .Be(0);

    [Fact]
    public void Should_score_one_with_one_match()
        => new ScratchCard(new[] { 1, 2, 3 }, new[] { 3, 4, 5 })
            .GetPoints()
            .Should()
            .Be(1);

    [Fact]
    public void Should_score_two_with_two_matches()
        => new ScratchCard(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 5, 6 })
            .GetPoints()
            .Should()
            .Be(2);

    [Fact]
    public void Should_score_four_with_three_matches()
        => new ScratchCard(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 5 })
            .GetPoints()
            .Should()
            .Be(4);

    [Fact]
    public void Should_score_eight_with_four_matches()
        => new ScratchCard(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 })
            .GetPoints()
            .Should()
            .Be(8);
}