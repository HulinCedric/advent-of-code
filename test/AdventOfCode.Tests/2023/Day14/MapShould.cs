using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day14.Map;

namespace AdventOfCode._2023.Day14;

public class MapShould
{
    [Fact]
    public void Return_tilted_map()
        => Parse(
                "O....#....\n" +
                "O.OO#....#\n" +
                ".....##...\n" +
                "OO.#O....O\n" +
                ".O.....O#.\n" +
                "O.#..O.#.#\n" +
                "..O..#O..O\n" +
                ".......O..\n" +
                "#....###..\n" +
                "#OO..#....")
            .Tilt()
            .ToString()
            .Should()
            .Be(
                "OOOO.#.O..\n" +
                "OO..#....#\n" +
                "OO..O##..O\n" +
                "O..#.OO...\n" +
                "........#.\n" +
                "..#....#.#\n" +
                "..O..#.O.O\n" +
                "..O.......\n" +
                "#....###..\n" +
                "#....#....");
    
    [Theory]
    [InputFileData("2023/Day14/sample.txt")]
    public void Immutable_tilt(string map)
    {
        var original = Parse(map);
        var tilted = Parse(map);

        tilted.Tilt();
        
        tilted.ToString().Should().BeEquivalentTo(original.ToString());
    }
}