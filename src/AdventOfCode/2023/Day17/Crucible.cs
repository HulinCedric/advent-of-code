using System.Collections.Generic;

namespace AdventOfCode._2023.Day17;

public readonly record struct Crucible(
    Position Position,
    Direction Direction,
    int MinStraight,
    int MaxStraight,
    int Straight)
{
    private const int ResetStraight = 0;

    public static Crucible New(Position position, Direction direction, int minStraight, int maxStraight)
        => new(position, direction, minStraight, maxStraight, ResetStraight);

    public Crucible Rotate90ClockWise()
        => Rotate(Direction.Rotate90ClockWise());

    public Crucible Rotate90CounterClockwise()
        => Rotate(Direction.Rotate90CounterClockWise());

    private Crucible Rotate(Direction direction)
    {
        if (!CanRotate())
        {
            return this;
        }

        return this with
        {
            Direction = direction,
            Straight = ResetStraight
        };
    }

    public Crucible Move()
    {
        if (!CanMove())
        {
            return this;
        }

        return this with
        {
            Position = Position.GoTo(Direction),
            Straight = Straight + 1
        };
    }

    private bool CanMove()
        => Straight < MaxStraight;

    private bool CanRotate()
        => Straight >= MinStraight;

    public bool CanStop()
        => Straight >= MinStraight;

    public IEnumerable<Crucible> Moves()
    {
        yield return Move();
        yield return Rotate90ClockWise().Move();
        yield return Rotate90CounterClockwise().Move();
    }
}