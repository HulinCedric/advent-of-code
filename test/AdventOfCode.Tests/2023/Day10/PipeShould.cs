using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day10;

public class PipeShould
{
    [Theory]
    [InputFileData("2023/Day10/sample1.txt", 4)]
    [InputFileData("2023/Day10/sample2.txt", 8)]
    [InputFileData("2023/Day10/input.txt", 6867)]
    public void Find_farthest_position_from_stating_position(string ground, int distance)
    {
        var pipeLength = Pipe.RunThrough(ground.ParseGround(), Tile.StartingTile).Count();

        var farthestPosition = pipeLength / 2;

        farthestPosition.Should().Be(distance);
    }

    [Theory]
    [InputFileData("2023/Day10/input.txt", 595)]
    public void Count_enclosed_tiles_in_pipe_loop(string groundTopology, int expectedTilesCount)
    {
        var ground = groundTopology.ParseGround();
        var pipe = Pipe.RunThrough(ground, Tile.StartingTile).ToHashSet();

        var tilesCount = Pipe.CountEnclosedTiles(ground, pipe);

        tilesCount.Should().Be(expectedTilesCount);
    }
}