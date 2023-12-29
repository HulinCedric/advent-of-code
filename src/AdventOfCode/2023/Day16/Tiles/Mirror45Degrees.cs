namespace AdventOfCode._2023.Day16.Tiles;

public record Mirror45Degrees : Tile
{
    public const char Tile = '/';

    public Direction[] Reflect(Direction direction)
        => [direction.Orthogonal().OppositeDirection()];
}