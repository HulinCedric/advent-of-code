using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day17.CrucibleTestBuilder;

namespace AdventOfCode._2023.Day17;

public class CrucibleShould
{
    [Fact]
    public void Have_initial_straight_to_zero()
        => Crucible()
            .Build()
            .Straight.Should()
            .Be(0);

    [Fact]
    public void Reset_straight_when_rotate()
    {
        Crucible()
            .WithStraight(3)
            .Build()
            .Rotate90ClockWise()
            .Straight.Should()
            .Be(0);

        Crucible()
            .WithStraight(3)
            .Build()
            .Rotate90CounterClockwise()
            .Straight.Should()
            .Be(0);
    }

    [Fact]
    public void Change_direction_when_rotate90_clockwise()
        => Crucible()
            .WithDirection(Direction.Right)
            .Build()
            .Rotate90ClockWise()
            .Direction.Should()
            .Be(Direction.Down);

    [Fact]
    public void Change_direction_when_rotate90_counter_clockwise()
        => Crucible()
            .WithDirection(Direction.Right)
            .Build()
            .Rotate90CounterClockwise()
            .Direction.Should()
            .Be(Direction.Up);

    [Fact]
    public void Change_position_when_move()
        => Crucible()
            .WithPosition(new Position(1, 1))
            .WithDirection(Direction.Right)
            .Build()
            .Move()
            .Position.Should()
            .Be(new Position(1, 2));

    [Fact]
    public void Increment_straight_when_move()
        => Crucible()
            .WithStraight(1)
            .Build()
            .Move()
            .Straight.Should()
            .Be(2);


    [Fact]
    public void Move_when_straight_is_less_than_max_straight()
        => Crucible()
            .WithMinStraight(0)
            .WithMaxStraight(2)
            .WithStraight(1)
            .WithPosition(new Position(1, 1))
            .Build()
            .Move()
            .Position
            .Should()
            .NotBe(new Position(1, 1));

    [Fact]
    public void Can_not_move_when_straight_max_straight_is_reached()
    {
        var crucible = Crucible()
            .WithMaxStraight(5)
            .WithStraight(5)
            .Build();

        crucible
            .Move()
            .Should()
            .Be(crucible);
    }


    [Fact]
    public void Can_not_rotate_when_straight_is_less_than_min_straight()
    {
        var crucible = Crucible()
            .WithMinStraight(2)
            .WithStraight(1)
            .Build();

        crucible.Rotate90ClockWise().Should().Be(crucible);
        crucible.Rotate90CounterClockwise().Should().Be(crucible);
    }

    [Fact]
    public void Moves_should_return_possible_moves()
    {
        var crucible = Crucible()
            .WithStraight(3)
            .WithDirection(Direction.Right)
            .WithPosition(new Position(1, 1))
            .Build();

        crucible.Moves()
            .Should()
            .BeEquivalentTo(
                new List<Crucible>
                {
                    Crucible()
                        .WithStraight(4)
                        .WithPosition(new Position(1, 2))
                        .Build(),

                    Crucible()
                        .WithStraight(1)
                        .WithDirection(Direction.Down)
                        .WithPosition(new Position(2, 1))
                        .Build(),

                    Crucible()
                        .WithStraight(1)
                        .WithDirection(Direction.Up)
                        .WithPosition(new Position(0, 1))
                        .Build()
                });
    }

    [Fact]
    public void Can_stop_when_straight_is_greater_than_or_equal_to_min_straight()
    {
        Crucible()
            .WithMinStraight(2)
            .WithStraight(2)
            .Build()
            .CanStop()
            .Should()
            .BeTrue();

        Crucible()
            .WithMinStraight(2)
            .WithStraight(3)
            .Build()
            .CanStop()
            .Should()
            .BeTrue();
    }
}