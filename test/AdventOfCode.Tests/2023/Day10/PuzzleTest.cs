using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day10;

public class PuzzleTest
{
    [Fact]
    public void Parse_ground_returns_tiles_with_their_position()
    {
        var ground = "S7\nLJ";
        var result = ground.ParseGround();

        result.Should()
            .BeEquivalentTo(
                new Dictionary<(int, int), char>
                {
                    { (0, 0), 'S' }, { (0, 1), '7' },
                    { (1, 0), 'L' }, { (1, 1), 'J' }
                });
    }
}