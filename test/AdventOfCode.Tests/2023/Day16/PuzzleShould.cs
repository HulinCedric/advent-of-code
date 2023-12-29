using System.Numerics;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day16;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day16/sample.txt", 46)]
    [InputFileData("2023/Day16/input.txt", 6740)]
    public void Count_energized_tiles(string contraptionLayout, int energizedTiles)
        => Contraption.EnergizedCells(
                Contraption.ParseContraption(contraptionLayout),
                new Beam(new Position(0,0), Directions.Right))
            .Should()
            .Be(energizedTiles);
}