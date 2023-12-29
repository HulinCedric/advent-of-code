namespace AdventOfCode._2023.Day16.Tiles;

// ReSharper disable once InconsistentNaming
public interface Tile
{
    Direction[] Reflect(Direction direction);
}