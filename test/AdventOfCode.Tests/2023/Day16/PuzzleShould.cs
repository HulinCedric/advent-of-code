using System.Linq;
using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day16.Beam;
using static AdventOfCode._2023.Day16.ContraptionParser;

namespace AdventOfCode._2023.Day16;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day16/sample.txt", 46)]
    [InputFileData("2023/Day16/input.txt", 6740)]
    public void Count_energized_tiles(string contraptionLayout, int energizedTiles)
    {
        var contraption = Parse(contraptionLayout);
        var startingBeam = new Beam(contraption.TopLeft(), Direction.Right);
        contraption
            .EnergizedTilesCount(startingBeam)
            .Should()
            .Be(energizedTiles);
    }

    [Theory]
    [InputFileData("2023/Day16/sample.txt", 51)]
    [InputFileData("2023/Day16/input.txt", 7041)]
    public void Count_most_energized_starting_beam_tiles(string contraptionLayout, int energizedTiles)
    {
        var contraption = Parse(contraptionLayout);
        StartingBeams(contraption)
            .Select(startingBeam => contraption.EnergizedTilesCount(startingBeam))
            .Max()
            .Should()
            .Be(energizedTiles);
    }
}