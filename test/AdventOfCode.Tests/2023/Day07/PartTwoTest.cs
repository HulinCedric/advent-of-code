using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day07;

public class PartTwoTest
{
    [Theory]
    [InputFileData("2023/Day07/sample.txt", 5_905)]
    [InputFileData("2023/Day07/input.txt", 246_894_760)]
    public void Total_winnings(string input, int result)
        => TotalWinnings(OrderBidsByHandStrength(input)).Should().Be(result);

    private static int TotalWinnings(IEnumerable<int> bidsByRanking)
        => bidsByRanking.Select((bid, rank) => (rank + 1) * bid).Sum();

    private static IEnumerable<int> OrderBidsByHandStrength(string input)
        => from line in input.Split("\n")
           let part = line.Split(" ")
           let hand = StrongestHand(part[0])
           let bid = int.Parse(part[1])
           orderby hand
           select bid;

    private static Hand StrongestHand(string hand)
    {
        var originalCards = hand.ToCharArray().Select(c => Card.Parse(c, Card.LabelsWithJasJoker[c])).ToList();
        var possibleJokerHand = HandTypeCards(hand);
        return possibleJokerHand
            .Select(jokerHand => new Hand(originalCards, jokerHand))
            .Max()!;
    }

    private static IEnumerable<List<Card>> HandTypeCards(string hand)
        => Card.LabelsWithJasJoker.Keys
            .Select(ch => hand.Replace('J', ch))
            .Select(
                substituedHand => substituedHand.ToCharArray()
                    .Select(c => Card.Parse(c, Card.LabelsWithJasJoker[c]))
                    .ToList());
}