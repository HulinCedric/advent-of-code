using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day06;

public class BoatShould
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(6, 6)]
    [InlineData(7, 7)]
    public void Increase_speed_with_time_holding_button_by_one_millimeter_per_millisecond(int holdTime, int speed)
    {
        // Arrange
        var boat = new Boat();

        // Act
        boat.HoldButton(holdTime.Milliseconds());

        // Assert
        boat.Speed.Should().Be(speed.MillimetersPerMillisecond());
    }

    [Theory]
    [InlineData(0, 7, 0)]
    [InlineData(1, 6, 6)]
    [InlineData(2, 5, 10)]
    [InlineData(3, 4, 12)]
    [InlineData(4, 3, 12)]
    [InlineData(5, 2, 10)]
    [InlineData(6, 1, 6)]
    [InlineData(7, 0, 0)]
    public void Calculate_distance_by_speed_with_time(int holdTime, int moveTime, int distance)
    {
        // Arrange
        var boat = new Boat();
        boat.HoldButton(holdTime.Milliseconds());

        // Act
        boat.Move(moveTime.Milliseconds());

        // Assert
        boat.Distance.Should().Be(distance.Millimeters());
    }
}