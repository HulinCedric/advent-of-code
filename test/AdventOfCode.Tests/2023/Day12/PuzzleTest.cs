using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day12;

public class PuzzleTest
{
    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 4)]
    public void todo(
        string springsRow,
        int arrangements)
        => arrangements.Should()
            .Be(arrangements);
}