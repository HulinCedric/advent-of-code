using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day13;

public class PuzzleTest
{
    [Theory]
    [InputFileData("2023/Day13/sample.txt", 405)]
    [InputFileData("2023/Day13/input.txt", 33195)]
    public void Solve(
        string mapsInformation,
        int expected)
    {
        var maps = mapsInformation.Split("\n\n")
            .Select(MapParser.Parse);

        var mirrorPositions = maps
            .SelectMany(map => map.GetMirrorPosition());

        var summary = mirrorPositions.Select(mirror => mirror.Summary()).Sum();

        summary.Should().Be(expected);
    }
}