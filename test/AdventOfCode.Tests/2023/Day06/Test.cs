using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day06;

public class Test
{
    [Theory]
    [InputFileData("2023/Day06/sample.txt", 288)]
    //[InputFileData("2023/Day06/input.txt", 288)]
    public void todo(string info, int expected)
    {
        var actual = 288;

        actual.Should().Be(expected);
    }
}