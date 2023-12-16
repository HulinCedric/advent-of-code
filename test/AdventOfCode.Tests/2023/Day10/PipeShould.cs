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
}