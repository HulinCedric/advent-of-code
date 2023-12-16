using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static AdventOfCode._2023.Day10.Direction;

namespace AdventOfCode._2023.Day10;

public static class Tile
{
    public const char StartingTile = 'S';

    private static readonly Dictionary<char, Complex[]> TileDirections = new()
    {
        { '|', [North, South] },
        { '-', [East, West] },
        { 'L', [North, East] },
        { 'J', [North, West] },
        { '7', [South, West] },
        { 'F', [South, East] },
        { '.', None },
        { StartingTile, All }
    };

    public static Complex[] GetAllDirections(this char tile)
        => TileDirections[tile];

    public static Complex GetNextDirection(char tile, Complex currentDirection)
        => tile.GetAllDirections()
            .First(direction => direction.IsNotOppositeDirection(currentDirection));
}