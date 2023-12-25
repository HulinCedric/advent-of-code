using System.Linq;
using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day13.MapParser;

namespace AdventOfCode._2023.Day13;

public class PuzzleTest
{
    [Theory]
    [InputFileData("2023/Day13/sample.txt", 405)]
    [InputFileData("2023/Day13/input.txt", 33195)]
    public void Summary_mirror(
        string maps,
        int summary)
        => ParseMany(maps)
            .SelectMany(map => map.MirrorPosition())
            .Select(mirror => mirror.Summary())
            .Sum()
            .Should()
            .Be(summary);

    [Theory]
    [InputFileData("2023/Day13/sample.txt", 400)]
    [InputFileData("2023/Day13/input.txt", 31836)]
    public void Summary_mirror_with_smudges(
        string maps,
        int summary)
        => ParseMany(maps)
            .SelectMany(map => map.MirrorWithSmudgePosition())
            .Select(mirror => mirror.Summary())
            .Sum()
            .Should()
            .Be(summary);
}