using System.Collections.Generic;

namespace AdventOfCode._2023.Day16.Tiles;

public static class TileFactory
{
    private static readonly Dictionary<char, Tile> Tiles = new()
    {
        { Mirror45Degrees.Tile, new Mirror45Degrees() },
        { Mirror135Degrees.Tile, new Mirror135Degrees() },
        { VerticalSplitter.Tile, new VerticalSplitter() },
        { HorizontalSplitter.Tile, new HorizontalSplitter() },
        { EmptySpace.Tile, EmptySpace.Instance }
    };

    public static Tile Tile(char tile)
        => Tiles[tile];
}