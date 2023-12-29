namespace AdventOfCode._2023.Day16.Tiles;

public record HorizontalSplitter
    : Tile
{
    public const char Tile = '-';

    public Direction[] Reflect(Direction direction)
    {
        if (direction == Direction.Up ||
            direction == Direction.Down)
        {
            return [Direction.Left, Direction.Right];
        }

        return EmptySpace.Instance.Reflect(direction);
    }
}