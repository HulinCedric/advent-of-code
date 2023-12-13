using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day07;

public class PartOneTest
{
    [Theory]
    [InputFileData("2023/Day07/sample.txt", 6_440)]
    [InputFileData("2023/Day07/input.txt", 246_912_307)]
    public void Total_winnings(string input, int result)
        => TotalWinnings(OrderBidsByHandStrength(input)).Should().Be(result);

    private static int TotalWinnings(IEnumerable<int> bids)
        => bids.Select((bid, rank) => bid * (rank + 1)).Sum();

    private static IEnumerable<int> OrderBidsByHandStrength(string input)
        => from handAndBid in input.Split("\n")
           let part = handAndBid.Split(" ")
           let hand = Hand.Parse(part[0])
           let bid = int.Parse(part[1])
           orderby hand
           select bid;
}