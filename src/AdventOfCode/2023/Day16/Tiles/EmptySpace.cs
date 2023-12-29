namespace AdventOfCode._2023.Day16.Tiles;

public record EmptySpace : Tile
{
    public const char Tile = '.';

    private EmptySpace()
    {
    }

    public static EmptySpace Instance { get; } = new();

    public Direction[] Reflect(Direction direction)
        => [direction];
}