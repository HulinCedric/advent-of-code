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
    {
        var bids = OrderedBids(input);

        TotalWinnings(bids).Should().Be(result);
    }

    private static int TotalWinnings(IEnumerable<int> bidsByRanking)
        => bidsByRanking.Select((bid, rank) => (rank + 1) * bid).Sum();

    private static IEnumerable<int> OrderedBids(string input)
        => from line in input.Split("\n")
           let part = line.Split(" ")
           let hand = Hand.Parse(part[0])
           let bid = int.Parse(part[1])
           orderby hand
           select bid;
}