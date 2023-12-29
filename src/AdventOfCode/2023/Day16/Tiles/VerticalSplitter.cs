namespace AdventOfCode._2023.Day16.Tiles;

public record VerticalSplitter : Tile
{
    public const char Tile = '|';

    public Direction[] Reflect(Direction direction)
    {
        if (direction == Direction.Left ||
            direction == Direction.Right)
        {
            return [Direction.Up, Direction.Down];
        }

        return EmptySpace.Instance.Reflect(direction);
    }
}