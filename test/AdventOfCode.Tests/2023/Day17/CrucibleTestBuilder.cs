namespace AdventOfCode._2023.Day17;

public class CrucibleTestBuilder
{
    public static CrucibleTestBuilder Crucible()
        => new();

    private Direction _direction = Direction.Right;
    private int _maxStraight = 5;
    private int _minStraight = 0;
    private Position _position = new(1, 1);
    private int _straight = 0;

    public CrucibleTestBuilder WithPosition(Position position)
    {
        _position = position;
        return this;
    }

    public CrucibleTestBuilder WithDirection(Direction direction)
    {
        _direction = direction;
        return this;
    }

    public CrucibleTestBuilder WithMinStraight(int minStraight)
    {
        _minStraight = minStraight;
        return this;
    }

    public CrucibleTestBuilder WithMaxStraight(int maxStraight)
    {
        _maxStraight = maxStraight;
        return this;
    }

    public CrucibleTestBuilder WithStraight(int straight)
    {
        _straight = straight;
        return this;
    }

    public Crucible Build()
        => new(_position, _direction, _minStraight, _maxStraight, _straight);
}