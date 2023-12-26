using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day14.MapParser;

namespace AdventOfCode._2023.Day14;

public class MapShould
{
    [Fact]
    public void Return_tilted_map()
        => Parse(
                """
                O....#....
                O.OO#....#
                .....##...
                OO.#O....O
                .O.....O#.
                O.#..O.#.#
                ..O..#O..O
                .......O..
                #....###..
                #OO..#....
                """)
            .Tilt()
            .ToString()
            .Should()
            .Be(
                """
                OOOO.#.O..
                OO..#....#
                OO..O##..O
                O..#.OO...
                ........#.
                ..#....#.#
                ..O..#.O.O
                ..O.......
                #....###..
                #....#....
                """);
}