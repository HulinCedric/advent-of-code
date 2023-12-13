using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day07.BidExtensions;
using static AdventOfCode._2023.Day07.Parser;

namespace AdventOfCode._2023.Day07;

public class PuzzleTest
{
    [Theory]
    [InputFileData("2023/Day07/sample.txt", 6_440)]
    [InputFileData("2023/Day07/input.txt", 246_912_307)]
    public void Total_winnings_with_J_as_Jack(string input, int result)
        => TotalWinnings(OrderBidsByHandStrength(input, HandParserWithJAsJack.Parse)).Should().Be(result);

    [Theory]
    [InputFileData("2023/Day07/sample.txt", 5_905)]
    [InputFileData("2023/Day07/input.txt", 246_894_760)]
    public void Total_winnings_with_J_as_Joker(string input, int result)
        => TotalWinnings(OrderBidsByHandStrength(input, HandParserWithJAsJoker.Parse)).Should().Be(result);
}