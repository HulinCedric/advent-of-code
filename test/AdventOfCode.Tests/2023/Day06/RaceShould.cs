using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day06;

public class RaceShould
{
    [Theory]
    [InlineData(7, 9, 4)]
    [InlineData(15, 40, 8)]
    [InlineData(30, 200, 9)]
    public void Calculate_ways_to_win(int time, int distance, int waysToWin)
        => new Race(time, distance)
            .CalculateWaysToWin()
            .Should()
            .Be(waysToWin);
}